// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Concurrent;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public abstract class AzurePSCmdlet : PSCmdlet
    {
        private readonly ConcurrentQueue<string> _debugMessages = new ConcurrentQueue<string>();
        private RecordingTracingInterceptor _httpTracingInterceptor;
        private DebugStreamTraceListener _adalListener;
        protected static AzureProfile _currentProfile = null;
        protected virtual bool IsMetricEnabled {
            get { return false; }
        }

        [Parameter(Mandatory = false, HelpMessage = "In-memory profile.")]
        public AzureProfile Profile { get; set; }

        /// <summary>
        /// Sets the current profile - the profile used when no Profile is explicitly passed in.  Should be used only by
        /// Profile cmdlets and tests that need to set up a particular profile
        /// </summary>
        public static AzureProfile CurrentProfile 
        {
            private get
            {
                if (_currentProfile == null)
                {
                    _currentProfile = InitializeDefaultProfile();
                    SetTokenCacheForProfile(_currentProfile);
                }

                return _currentProfile;
            }

            set
            {
                SetTokenCacheForProfile(value);
                _currentProfile = value;
            }
        }

        protected static TokenCache DefaultDiskTokenCache { get; set; }

        protected static TokenCache DefaultMemoryTokenCache { get; set; }

        static AzurePSCmdlet()
        {
            if (!TestMockSupport.RunningMocked)
            {
                AzureSession.ClientFactory.AddAction(new RPRegistrationAction());
            }

            AzureSession.ClientFactory.UserAgents.Add(AzurePowerShell.UserAgentValue);
            if (!TestMockSupport.RunningMocked)
            {
                InitializeTokenCaches();
                AzureSession.DataStore = new DiskDataStore();
                SetTokenCacheForProfile(CurrentProfile);
            }
        }

        /// <summary>
        /// Create the default profile, based on the default profile path
        /// </summary>
        /// <returns>The default profile, serialized from the default location on disk</returns>
        protected static AzureProfile InitializeDefaultProfile()
        {
            if (!string.IsNullOrEmpty(AzureSession.ProfileDirectory) && !string.IsNullOrEmpty(AzureSession.ProfileFile))
            {
                try
                {
                   GeneralUtilities.EnsureDefaultProfileDirectoryExists();
                   return new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
                }
                catch
                {
                    // swallow exceptions in creating the profile from disk
                }
            }

            return new AzureProfile();
        }

        /// <summary>
        /// Get the context for the current profile before BeginProcessing is called
        /// </summary>
        /// <returns>The context for the current profile</returns>
        protected AzureContext GetCurrentContext()
        {
            if (Profile != null)
            {
                return Profile.Context;
            }

            return CurrentProfile.Context;
        }

        protected static void InitializeTokenCaches()
        {
            DefaultMemoryTokenCache = new TokenCache();
            if (!string.IsNullOrWhiteSpace(AzureSession.ProfileDirectory) &&
                !string.IsNullOrWhiteSpace(AzureSession.TokenCacheFile))
            {
                GeneralUtilities.EnsureDefaultProfileDirectoryExists();
                DefaultDiskTokenCache = new ProtectedFileTokenCache(Path.Combine(AzureSession.ProfileDirectory, AzureSession.TokenCacheFile));
            }
            else
            {
                DefaultDiskTokenCache = DefaultMemoryTokenCache;
            }
        }

        /// <summary>
        /// Update the token cache when setting the profile
        /// </summary>
        /// <param name="profile"></param>
        protected static void SetTokenCacheForProfile(AzureProfile profile)
        {
            var defaultProfilePath = Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile);
            if (string.Equals(profile.ProfilePath, defaultProfilePath, StringComparison.OrdinalIgnoreCase))
            {
                AzureSession.TokenCache = DefaultDiskTokenCache;
            }
            else
            {
                AzureSession.TokenCache = DefaultMemoryTokenCache;
            }
        }

        /// <summary>
        /// Cmdlet begin process. Write to logs, setup Http Tracing and initialize profile
        /// </summary>
        protected override void BeginProcessing()
        {
            InitializeProfile();
            LogMetricHelperUsage();
            if (string.IsNullOrEmpty(ParameterSetName))
            {
                WriteDebugWithTimestamp(string.Format(Resources.BeginProcessingWithoutParameterSetLog, this.GetType().Name));
            }
            else
            {
                WriteDebugWithTimestamp(string.Format(Resources.BeginProcessingWithParameterSetLog, this.GetType().Name, ParameterSetName));
            }

            if (Profile != null && Profile.Context != null && Profile.Context.Account != null && Profile.Context.Account.Id != null)
            {
                WriteDebugWithTimestamp(string.Format("using account id '{0}'...", Profile.Context.Account.Id));
            }

            _httpTracingInterceptor = _httpTracingInterceptor?? new RecordingTracingInterceptor(_debugMessages);
            _adalListener = _adalListener?? new DebugStreamTraceListener(_debugMessages);
            RecordingTracingInterceptor.AddToContext(_httpTracingInterceptor);
            DebugStreamTraceListener.AddAdalTracing(_adalListener);

            base.BeginProcessing();
        }

        /// <summary>
        /// Ensure that there is a profile for the command
        /// </summary>
        protected  virtual void InitializeProfile()
        {
            if (Profile == null)
            {
                Profile = AzurePSCmdlet.CurrentProfile;
            }

            SetTokenCacheForProfile(Profile);
        }

        /// <summary>
        /// End processing. Flush messages in tracing interceptor and save profile.
        /// </summary>
        protected override void EndProcessing()
        {
            string message = string.Format(Resources.EndProcessingLog, this.GetType().Name);
            WriteDebugWithTimestamp(message);

            RecordingTracingInterceptor.RemoveFromContext(_httpTracingInterceptor);
            DebugStreamTraceListener.RemoveAdalTracing(_adalListener);
            FlushDebugMessages();
            if (IsMetricEnabled)
            {
                MetricHelper.FlushMetric();
            }

            base.EndProcessing();
        }

        public bool HasCurrentSubscription
        {
            get { return Profile.Context.Subscription != null; }
        }

        protected string CurrentPath()
        {
            // SessionState is only available within Powershell so default to
            // the CurrentDirectory when being run from tests.
            return (SessionState != null) ?
                SessionState.Path.CurrentLocation.Path :
                Environment.CurrentDirectory;
        }

        protected bool IsVerbose()
        {
            bool verbose = MyInvocation.BoundParameters.ContainsKey("Verbose") && ((SwitchParameter)MyInvocation.BoundParameters["Verbose"]).ToBool();
            return verbose;
        }

        public new void WriteError(ErrorRecord errorRecord)
        {
            FlushDebugMessages();
            LogMetricHelperErrorEvent(errorRecord);
            base.WriteError(errorRecord);
        }

        public new void WriteObject(object sendToPipeline)
        {
            FlushDebugMessages();
            base.WriteObject(sendToPipeline);
        }

        public new void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            FlushDebugMessages();
            base.WriteObject(sendToPipeline, enumerateCollection);
        }

        public new void WriteVerbose(string text)
        {
            FlushDebugMessages();
            base.WriteVerbose(text);
        }

        public new void WriteWarning(string text)
        {
            FlushDebugMessages();
            base.WriteWarning(text);
        }

        public new void WriteCommandDetail(string text)
        {
            FlushDebugMessages();
            base.WriteCommandDetail(text);
        }

        public new void WriteProgress(ProgressRecord progressRecord)
        {
            FlushDebugMessages();
            base.WriteProgress(progressRecord);
        }

        public new void WriteDebug(string text)
        {
            FlushDebugMessages();
            base.WriteDebug(text);
        }

        protected void WriteVerboseWithTimestamp(string message, params object[] args)
        {
            WriteVerbose(string.Format("{0:T} - {1}", DateTime.Now, string.Format(message, args)));
        }

        protected void WriteVerboseWithTimestamp(string message)
        {
            WriteVerbose(string.Format("{0:T} - {1}", DateTime.Now, message));
        }

        protected void WriteWarningWithTimestamp(string message)
        {
            WriteWarning(string.Format("{0:T} - {1}", DateTime.Now, message));
        }

        protected void WriteDebugWithTimestamp(string message, params object[] args)
        {
            WriteDebug(string.Format("{0:T} - {1}", DateTime.Now, string.Format(message, args)));
        }

        protected void WriteDebugWithTimestamp(string message)
        {
            WriteDebug(string.Format("{0:T} - {1}", DateTime.Now, message));
        }

        protected void WriteErrorWithTimestamp(string message)
        {
            WriteError(
                new ErrorRecord(new Exception(string.Format("{0:T} - {1}", DateTime.Now, message)),
                string.Empty,
                ErrorCategory.NotSpecified,
                null));
        }

        /// <summary>
        /// Write an error message for a given exception.
        /// </summary>
        /// <param name="ex">The exception resulting from the error.</param>
        protected virtual void WriteExceptionError(Exception ex)
        {
            Debug.Assert(ex != null, "ex cannot be null or empty.");
            WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
        }

        protected PSObject ConstructPSObject(string typeName, params object[] args)
        {
            return PowerShellUtilities.ConstructPSObject(typeName, args);
        }

        protected void SafeWriteOutputPSObject(string typeName, params object[] args)
        {
            PSObject customObject = this.ConstructPSObject(typeName, args);
            WriteObject(customObject);
        }

        public virtual void ExecuteCmdlet()
        {
            // Do nothing.
        }

        protected override void ProcessRecord()
        {
            try
            {
                base.ProcessRecord();
                ExecuteCmdlet();
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        private void FlushDebugMessages()
        {
            string message;
            while (_debugMessages.TryDequeue(out message))
            {
                base.WriteDebug(message);
            }
        }

        protected void LogMetricHelperUsage()
        {
            if (!IsMetricEnabled)
            {
                return;
            }

            try
            {
                MetricHelper.LogUsageEvent(this.Profile.DefaultSubscription.Id.ToString(), this.GetType().Name);
            }
            catch (Exception e)
            {
                //Swallow error from Application Insights event collection.
                WriteErrorWithTimestamp(e.ToString());
            }
        }

        protected void LogMetricHelperErrorEvent(ErrorRecord er)
        {
            if (!IsMetricEnabled)
            {
                return;
            }

            try
            {
                MetricHelper.LogErrorEvent(er, this.Profile.DefaultSubscription.Id.ToString(), this.GetType().Name);
            }
            catch (Exception e)
            {
                //Swallow error from Application Insights event collection.
                WriteErrorWithTimestamp(e.ToString());
            }
        }

        /// <summary>
        /// Asks for confirmation before executing the action.
        /// </summary>
        /// <param name="force">Do not ask for confirmation</param>
        /// <param name="actionMessage">Message to describe the action</param>
        /// <param name="processMessage">Message to prompt after the active is performed.</param>
        /// <param name="target">The target name.</param>
        /// <param name="action">The action code</param>
        protected void ConfirmAction(bool force, string actionMessage, string processMessage, string target, Action action)
        {
            if (force || ShouldContinue(actionMessage, ""))
            {
                if (ShouldProcess(target, processMessage))
                {
                    action();
                }
            }
        }
    }
}
