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

using Microsoft.ApplicationInsights;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    /// <summary>
    /// Represents base class for all Azure cmdlets.
    /// </summary>
    public abstract class AzurePSCmdlet : PSCmdlet, IDisposable
    {
        public ConcurrentQueue<string> DebugMessages { get; private set; }

        private RecordingTracingInterceptor _httpTracingInterceptor;
        protected static AzurePSDataCollectionProfile _dataCollectionProfile = null;
        protected static string _errorRecordFolderPath = null;
        protected static string _sessionId = Guid.NewGuid().ToString();
        protected const string _fileTimeStampSuffixFormat = "yyyy-MM-dd-THH-mm-ss-fff";
        protected string _clientRequestId = Guid.NewGuid().ToString();
        protected MetricHelper _metricHelper;
        protected AzurePSQoSEvent _qosEvent;
        protected DebugStreamTraceListener _adalListener;

        protected virtual bool IsUsageMetricEnabled
        {
            get { return true; }
        }

        protected virtual bool IsErrorMetricEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the PowerShell module name used for user agent header.
        /// By default uses "Azure PowerShell"
        /// </summary>
        protected virtual string ModuleName { get { return "AzurePowershell"; } }

        /// <summary>
        /// Gets PowerShell module version used for user agent header.
        /// </summary>
        protected string ModuleVersion { get { return Assembly.GetCallingAssembly().GetName().Version.ToString(); } }

        /// <summary>
        /// The context for management cmdlet requests - includes account, tenant, subscription, 
        /// and credential information for targeting and authorizing management calls.
        /// </summary>
        protected abstract AzureContext DefaultContext { get; }

        /// <summary>
        /// Initializes AzurePSCmdlet properties.
        /// </summary>
        public AzurePSCmdlet()
        {
            DebugMessages = new ConcurrentQueue<string>();

            //TODO: Inject from CI server
            _metricHelper = new MetricHelper();
            _metricHelper.AddTelemetryClient(new TelemetryClient
            {
                InstrumentationKey = "7df6ff70-8353-4672-80d6-568517fed090"
            });
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
                    // Disable data collection only if it is explicitly set to 'false'.
                    _dataCollectionProfile = new AzurePSDataCollectionProfile(true);
                }
                else if (string.Equals(value, bool.TrueString, StringComparison.OrdinalIgnoreCase))
                {
                    // Enable data collection only if it is explicitly set to 'true'.
                    _dataCollectionProfile = new AzurePSDataCollectionProfile(false);
                }
            }

            // If the environment value is null or empty, or not correctly set, try to read the setting from default file location.
            if (_dataCollectionProfile == null)
            {
                string fileFullPath = Path.Combine(AzurePowerShell.ProfileDirectory,
                    AzurePSDataCollectionProfile.DefaultFileName);
                if (File.Exists(fileFullPath))
                {
                    string contents = File.ReadAllText(fileFullPath);
                    _dataCollectionProfile =
                        JsonConvert.DeserializeObject<AzurePSDataCollectionProfile>(contents);
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
        /// Check whether the data collection is opted in from user
        /// </summary>
        /// <returns>true if allowed</returns>
        public static bool IsDataCollectionAllowed()
        {
            if (_dataCollectionProfile != null &&
                _dataCollectionProfile.EnableAzureDataCollection.HasValue &&
                _dataCollectionProfile.EnableAzureDataCollection.Value)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Save the current data collection profile JSON data into the default file path
        /// </summary>
        protected abstract void SaveDataCollectionProfile();

        protected bool CheckIfInteractive()
        {
            bool interactive = true;
            if (this.Host == null ||
                this.Host.UI == null ||
                this.Host.UI.RawUI == null ||
                Environment.GetCommandLineArgs().Any(s =>
                    s.Equals("-NonInteractive", StringComparison.OrdinalIgnoreCase)))
            {
                interactive = false;
            }
            else
            {
                try
                {
                    var test = this.Host.UI.RawUI.KeyAvailable;
                }
                catch
                {
                    interactive = false;
                }
            }

            if (!interactive && !_dataCollectionProfile.EnableAzureDataCollection.HasValue)
            {
                _dataCollectionProfile.EnableAzureDataCollection = false;
            }
            return interactive;
        }

        /// <summary>
        /// Prompt for the current data collection profile
        /// </summary>
        protected abstract void PromptForDataCollectionProfileIfNotExists();

        protected virtual void LogCmdletStartInvocationInfo()
        {
            if (string.IsNullOrEmpty(ParameterSetName))
            {
                WriteDebugWithTimestamp(string.Format("{0} begin processing " +
                   "without ParameterSet.", this.GetType().Name));
            }
            else
            {
                WriteDebugWithTimestamp(string.Format("{0} begin processing " +
                   "with ParameterSet '{1}'.", this.GetType().Name, ParameterSetName));
            }
        }

        protected virtual void LogCmdletEndInvocationInfo()
        {
            string message = string.Format("{0} end processing.", this.GetType().Name);
            WriteDebugWithTimestamp(message);
        }

        protected virtual void SetupDebuggingTraces()
        {
            _httpTracingInterceptor = _httpTracingInterceptor ?? new
                RecordingTracingInterceptor(DebugMessages);
            _adalListener = _adalListener ?? new DebugStreamTraceListener(DebugMessages);
            RecordingTracingInterceptor.AddToContext(_httpTracingInterceptor);
            DebugStreamTraceListener.AddAdalTracing(_adalListener);
        }

        protected virtual void TearDownDebuggingTraces()
        {
            RecordingTracingInterceptor.RemoveFromContext(_httpTracingInterceptor);
            DebugStreamTraceListener.RemoveAdalTracing(_adalListener);
            FlushDebugMessages();
        }


        protected virtual void SetupHttpClientPipeline()
        {
            ProductInfoHeaderValue userAgentValue = new ProductInfoHeaderValue(
                ModuleName, string.Format("v{0}", ModuleVersion));
            AzureSession.ClientFactory.UserAgents.Add(userAgentValue);
            AzureSession.ClientFactory.AddHandler(
                new CmdletInfoHandler(this.CommandRuntime.ToString(),
                    this.ParameterSetName, this._clientRequestId));

        }

        protected virtual void TearDownHttpClientPipeline()
        {
            AzureSession.ClientFactory.UserAgents.RemoveWhere(u => u.Product.Name == ModuleName);
            AzureSession.ClientFactory.RemoveHandler(typeof(CmdletInfoHandler));
        }
        /// <summary>
        /// Cmdlet begin process. Write to logs, setup Http Tracing and initialize profile
        /// </summary>
        protected override void BeginProcessing()
        {
            PromptForDataCollectionProfileIfNotExists();
            InitializeQosEvent();
            LogCmdletStartInvocationInfo();
            SetupDebuggingTraces();
            SetupHttpClientPipeline();
            base.BeginProcessing();
        }

        /// <summary>
        /// Perform end of pipeline processing.
        /// </summary>
        protected override void EndProcessing()
        {
            LogQosEvent();
            LogCmdletEndInvocationInfo();
            TearDownDebuggingTraces();
            TearDownHttpClientPipeline();
            base.EndProcessing();
        }

        protected string CurrentPath()
        {
            // SessionState is only available within PowerShell so default to
            // the TestMockSupport.TestExecutionFolder when being run from tests.
            return (SessionState != null) ?
                SessionState.Path.CurrentLocation.Path :
                TestMockSupport.TestExecutionFolder;
        }

        protected bool IsVerbose()
        {
            bool verbose = MyInvocation.BoundParameters.ContainsKey("Verbose")
                && ((SwitchParameter)MyInvocation.BoundParameters["Verbose"]).ToBool();
            return verbose;
        }

        protected new void WriteError(ErrorRecord errorRecord)
        {
            FlushDebugMessages(IsDataCollectionAllowed());
            if (_qosEvent != null && errorRecord != null)
            {
                _qosEvent.Exception = errorRecord.Exception;
                _qosEvent.IsSuccess = false;
            }

            base.WriteError(errorRecord);
        }

        protected new void ThrowTerminatingError(ErrorRecord errorRecord)
        {
            FlushDebugMessages(IsDataCollectionAllowed());
            base.ThrowTerminatingError(errorRecord);
        }

        protected new void WriteObject(object sendToPipeline)
        {
            FlushDebugMessages();
            base.WriteObject(sendToPipeline);
        }

        protected new void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            FlushDebugMessages();
            base.WriteObject(sendToPipeline, enumerateCollection);
        }

        protected new void WriteVerbose(string text)
        {
            FlushDebugMessages();
            base.WriteVerbose(text);
        }

        protected new void WriteWarning(string text)
        {
            FlushDebugMessages();
            base.WriteWarning(text);
        }

        protected new void WriteCommandDetail(string text)
        {
            FlushDebugMessages();
            base.WriteCommandDetail(text);
        }

        protected new void WriteProgress(ProgressRecord progressRecord)
        {
            FlushDebugMessages();
            base.WriteProgress(progressRecord);
        }

        protected new void WriteDebug(string text)
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

        private void FlushDebugMessages(bool record = false)
        {
            if (record)
            {
                RecordDebugMessages();
            }

            string message;
            while (DebugMessages.TryDequeue(out message))
            {
                base.WriteDebug(message);
            }
        }

        protected abstract void InitializeQosEvent();

        private void RecordDebugMessages()
        {
            // Create 'ErrorRecords' folder under profile directory, if not exists
            if (string.IsNullOrEmpty(_errorRecordFolderPath)
                || !Directory.Exists(_errorRecordFolderPath))
            {
                _errorRecordFolderPath = Path.Combine(AzurePowerShell.ProfileDirectory,
                    "ErrorRecords");
                Directory.CreateDirectory(_errorRecordFolderPath);
            }

            CommandInfo cmd = this.MyInvocation.MyCommand;

            string filePrefix = cmd.Name;
            string timeSampSuffix = DateTime.Now.ToString(_fileTimeStampSuffixFormat);
            string fileName = filePrefix + "_" + timeSampSuffix + ".log";
            string filePath = Path.Combine(_errorRecordFolderPath, fileName);

            StringBuilder sb = new StringBuilder();
            sb.Append("Module : ").AppendLine(cmd.ModuleName);
            sb.Append("Cmdlet : ").AppendLine(cmd.Name);

            sb.AppendLine("Parameters");
            foreach (var item in this.MyInvocation.BoundParameters)
            {
                sb.Append(" -").Append(item.Key).Append(" : ");
                sb.AppendLine(item.Value == null ? "null" : item.Value.ToString());
            }

            sb.AppendLine();

            foreach (var content in DebugMessages)
            {
                sb.AppendLine(content);
            }

            AzureSession.DataStore.WriteFile(filePath, sb.ToString());
        }

        /// <summary>
        /// Invoke this method when the cmdlet is completed or terminated.
        /// </summary>
        protected void LogQosEvent()
        {
            if (_qosEvent == null)
            {
                return;
            }

            _qosEvent.FinishQosEvent();

            if (!IsUsageMetricEnabled && (!IsErrorMetricEnabled || _qosEvent.IsSuccess))
            {
                return;
            }

            if (!IsDataCollectionAllowed())
            {
                return;
            }

            WriteDebug(_qosEvent.ToString());

            try
            {
                _metricHelper.LogQoSEvent(_qosEvent, IsUsageMetricEnabled, IsErrorMetricEnabled);
                _metricHelper.FlushMetric();
                WriteDebug("Finish sending metric.");
            }
            catch (Exception e)
            {
                //Swallow error from Application Insights event collection.
                WriteWarning(e.ToString());
            }
        }

        /// <summary>
        /// Guards execution of the given action using ShouldProcess and ShouldContinue.  This is a legacy 
        /// version forcompatibility with older RDFE cmdlets.
        /// </summary>
        /// <param name="force">Do not ask for confirmation</param>
        /// <param name="continueMessage">Message to describe the action</param>
        /// <param name="processMessage">Message to prompt after the active is performed.</param>
        /// <param name="target">The target name.</param>
        /// <param name="action">The action code</param>
        protected virtual void ConfirmAction(bool force, string continueMessage, string processMessage, string target,
            Action action)
        {
            if (_qosEvent != null)
            {
                _qosEvent.PauseQoSTimer();
            }

            if (force || ShouldContinue(continueMessage, ""))
            {
                if (ShouldProcess(target, processMessage))
                {
                    if (_qosEvent != null)
                    {
                        _qosEvent.ResumeQosTimer();
                    }
                    action();
                }
            }
        }

        /// <summary>
        /// Guards execution of the given action using ShouldProcess and ShouldContinue.  The optional 
        /// useSHouldContinue predicate determines whether SHouldContinue should be called for this 
        /// particular action (e.g. a resource is being overwritten). By default, both 
        /// ShouldProcess and ShouldContinue will be executed.  Cmdlets that use this method overload 
        /// must have a force parameter.
        /// </summary>
        /// <param name="force">Do not ask for confirmation</param>
        /// <param name="continueMessage">Message to describe the action</param>
        /// <param name="processMessage">Message to prompt after the active is performed.</param>
        /// <param name="target">The target name.</param>
        /// <param name="action">The action code</param>
        /// <param name="useShouldContinue">A predicate indicating whether ShouldContinue should be invoked for thsi action</param>
        protected virtual void ConfirmAction(bool force, string continueMessage, string processMessage, string target, Action action, Func<bool> useShouldContinue)
        {
            if (null == useShouldContinue)
            {
                useShouldContinue = () => true;
            }
            if (_qosEvent != null)
            {
                _qosEvent.PauseQoSTimer();
            }

            if (ShouldProcess(target, processMessage))
            {
                if (force || !useShouldContinue() || ShouldContinue(continueMessage, ""))
                {
                    if (_qosEvent != null)
                    {
                        _qosEvent.ResumeQosTimer();
                    }
                    action();
                }
            }
        }

        /// <summary>
        /// Prompt for confirmation depending on the ConfirmLevel. By default No confirmation prompt 
        /// occurs unless ConfirmLevel >= $ConfirmPreference.  Guarding the actions of a cmdlet with this 
        /// method will enable the cmdlet to support -WhatIf and -Confirm parameters.
        /// </summary>
        /// <param name="processMessage">The change being made to the resource</param>
        /// <param name="target">The resource that is being changed</param>
        /// <param name="action">The action to perform if confirmed</param>
        protected virtual void ConfirmAction(string processMessage, string target, Action action)
        {
            if (_qosEvent != null)
            {
                _qosEvent.PauseQoSTimer();
            }

            if (ShouldProcess(target, processMessage))
            {
                if (_qosEvent != null)
                {
                    _qosEvent.ResumeQosTimer();
                }
                action();
            }
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

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                FlushDebugMessages();
            }
            catch { }
            if (disposing && _adalListener != null)
            {
                _adalListener.Dispose();
                _adalListener = null;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
