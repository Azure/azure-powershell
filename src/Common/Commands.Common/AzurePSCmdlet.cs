﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public abstract class AzurePSCmdlet : PSCmdlet
    {
        private readonly ConcurrentQueue<string> _debugMessages = new ConcurrentQueue<string>();
        private RecordingTracingInterceptor _httpTracingInterceptor;
        private DebugStreamTraceListener _adalListener;
        protected static AzureProfile _currentProfile = null;
        protected static AzurePSDataCollectionProfile _dataCollectionProfile = null;

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
            DefaultMemoryTokenCache = TokenCache.DefaultShared;
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
        /// Initialize the data collection profile
        /// </summary>
        protected static void InitializeDataCollectionProfile()
        {
            if (_dataCollectionProfile != null && _dataCollectionProfile.EnableAzureDataCollection.HasValue)
            {
                return;
            }

            // Get the value of the environment variable for Azure PS data collection setting.
            string value = Environment.GetEnvironmentVariable(AzurePSDataCollectionProfile.EnvironmentVariableName);
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, bool.FalseString, StringComparison.OrdinalIgnoreCase))
                {
                    // Disable data collection only if it is explictly set to 'false'.
                    _dataCollectionProfile = new AzurePSDataCollectionProfile(true);
                }
                else if (string.Equals(value, bool.TrueString, StringComparison.OrdinalIgnoreCase))
                {
                    // Enable data collection only if it is explictly set to 'true'.
                    _dataCollectionProfile = new AzurePSDataCollectionProfile(false);
                }
            }

            // If the environment value is null or empty, or not correctly set, try to read the setting from default file location.
            if (_dataCollectionProfile == null)
            {
                string fileFullPath = Path.Combine(AzureSession.ProfileDirectory, AzurePSDataCollectionProfile.DefaultFileName);
                if (File.Exists(fileFullPath))
                {
                    string contents = File.ReadAllText(fileFullPath);
                    _dataCollectionProfile = JsonConvert.DeserializeObject<AzurePSDataCollectionProfile>(contents);
                }
            }

            // If the environment variable or file content is not set, create a new profile object.
            if (_dataCollectionProfile == null)
            {
                _dataCollectionProfile = new AzurePSDataCollectionProfile();
            }
        }

        /// <summary>
        /// Get the data collection profile
        /// </summary>
        protected static AzurePSDataCollectionProfile GetDataCollectionProfile()
        {
            if (_dataCollectionProfile == null)
            {
                InitializeDataCollectionProfile();
            }

            return _dataCollectionProfile;
        }

        /// <summary>
        /// Save the current data collection profile Json data into the default file path
        /// </summary>
        /// <param name="profile"></param>
        protected void SaveDataCollectionProfile()
        {
            if (_dataCollectionProfile == null)
            {
                InitializeDataCollectionProfile();
            }

            string fileFullPath = Path.Combine(AzureSession.ProfileDirectory, AzurePSDataCollectionProfile.DefaultFileName);
            var contents = JsonConvert.SerializeObject(_dataCollectionProfile);
            AzureSession.DataStore.WriteFile(fileFullPath, contents);
            WriteWarning(string.Format(Resources.DataCollectionSaveFileInformation, fileFullPath));
        }

        /// <summary>
        /// Prompt for the current data collection profile
        /// </summary>
        /// <param name="profile"></param>
        protected void PromptForDataCollectionProfileIfNotExists()
        {
            // Initialize it from the environment variable or profile file.
            InitializeDataCollectionProfile();

            if (!_dataCollectionProfile.EnableAzureDataCollection.HasValue)
            {
                WriteWarning(Resources.DataCollectionPrompt);

                const double timeToWaitInSeconds = 60;
                var status = string.Format(Resources.DataCollectionConfirmTime, timeToWaitInSeconds);
                ProgressRecord record = new ProgressRecord(0, Resources.DataCollectionActivity, status);

                var startTime = DateTime.Now;
                var endTime = DateTime.Now;
                double elapsedSeconds = 0;

                while (!this.Host.UI.RawUI.KeyAvailable && elapsedSeconds < timeToWaitInSeconds)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(10));
                    endTime = DateTime.Now;

                    elapsedSeconds = (endTime - startTime).TotalSeconds;
                    record.PercentComplete = ((int)elapsedSeconds * 100 / (int)timeToWaitInSeconds);
                    WriteProgress(record);
                }

                bool enabled = false;
                if (this.Host.UI.RawUI.KeyAvailable)
                {
                    KeyInfo keyInfo = this.Host.UI.RawUI.ReadKey(ReadKeyOptions.NoEcho);
                    enabled = (keyInfo.Character == 'Y' || keyInfo.Character == 'y');
                }

                _dataCollectionProfile.EnableAzureDataCollection = enabled;

                WriteWarning(enabled ? Resources.DataCollectionConfirmYes : Resources.DataCollectionConfirmNo);

                SaveDataCollectionProfile();
            }
        }

        /// <summary>
        /// Cmdlet begin process. Write to logs, setup Http Tracing and initialize profile
        /// </summary>
        protected override void BeginProcessing()
        {
            PromptForDataCollectionProfileIfNotExists();

            InitializeProfile();
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
