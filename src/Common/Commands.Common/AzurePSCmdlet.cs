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

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Management.Automation;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json;
using System.IO;
using System.Management.Automation.Host;
using System.Text;
using System.Linq;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    /// <summary>
    /// Represents base class for all Azure cmdlets.
    /// </summary>
    public abstract class AzurePSCmdlet : PSCmdlet, IDisposable
    {
        protected readonly ConcurrentQueue<string> _debugMessages;

        private RecordingTracingInterceptor _httpTracingInterceptor;

        private DebugStreamTraceListener _adalListener;
        protected static AzurePSDataCollectionProfile _dataCollectionProfile = null;
        protected static string _errorRecordFolderPath = null;
        protected const string _fileTimeStampSuffixFormat = "yyyy-MM-dd-THH-mm-ss-fff";

        protected AzurePSQoSEvent QosEvent;

        protected virtual bool IsUsageMetricEnabled {
            get { return false; }
        }

        protected virtual bool IsErrorMetricEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the PowerShell module name used for user agent header.
        /// By default uses "Azurepowershell"
        /// </summary>
        protected virtual string ModuleName { get { return "AzurePowershell"; } }

        /// <summary>
        /// Gets PowerShell module version used for user agent header.
        /// </summary>
        protected string ModuleVersion { get { return Assembly.GetCallingAssembly().GetName().Version.ToString(); } }

        /// <summary>
        /// Gets the default Azure context.
        /// </summary>
        protected abstract AzureContext DefaultContext { get; }

        /// <summary>
        /// Initializes AzurePSCmdlet properties.
        /// </summary>
        public AzurePSCmdlet()
        {
            _debugMessages = new ConcurrentQueue<string>();
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
        /// Save the current data collection profile Json data into the default file path
        /// </summary>
        /// <param name="profile"></param>
        protected abstract void SaveDataCollectionProfile();

        protected bool CheckIfInteractive()
        {
            bool interactive = true;
            if (this.Host == null || 
                this.Host.UI == null || 
                this.Host.UI.RawUI == null ||
                Environment.GetCommandLineArgs().Any(s => s.Equals("-NonInteractive", StringComparison.OrdinalIgnoreCase)))
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
        /// <param name="profile"></param>
        protected abstract void PromptForDataCollectionProfileIfNotExists();

        /// <summary>
        /// Cmdlet begin process. Write to logs, setup Http Tracing and initialize profile
        /// </summary>
        protected override void BeginProcessing()
        {
            PromptForDataCollectionProfileIfNotExists();
            InitializeQosEvent();
            if (string.IsNullOrEmpty(ParameterSetName))
            {
                WriteDebugWithTimestamp(string.Format("{0} begin processing without ParameterSet.", this.GetType().Name));
            }
            else
            {
                WriteDebugWithTimestamp(string.Format("{0} begin processing with ParameterSet '{1}'.", this.GetType().Name, ParameterSetName));
            }

            if (DefaultContext != null && DefaultContext.Account != null && DefaultContext.Account.Id != null)
            {
                WriteDebugWithTimestamp(string.Format("using account id '{0}'...", DefaultContext.Account.Id));
            }

            _httpTracingInterceptor = _httpTracingInterceptor ?? new RecordingTracingInterceptor(_debugMessages);
            _adalListener = _adalListener ?? new DebugStreamTraceListener(_debugMessages);
            RecordingTracingInterceptor.AddToContext(_httpTracingInterceptor);
            DebugStreamTraceListener.AddAdalTracing(_adalListener);

            ProductInfoHeaderValue userAgentValue = new ProductInfoHeaderValue(
                ModuleName, string.Format("v{0}", ModuleVersion));
            AzureSession.ClientFactory.UserAgents.Add(userAgentValue);
            AzureSession.ClientFactory.AddHandler(new CmdletInfoHandler(this.CommandRuntime.ToString(), this.ParameterSetName));
            base.BeginProcessing();
        }

        /// <summary>
        /// End processing. Flush messages in tracing interceptor and save profile and removes user agent.
        /// </summary>
        protected override void EndProcessing()
        {
            LogQosEvent();
            string message = string.Format("{0} end processing.", this.GetType().Name);
            WriteDebugWithTimestamp(message);

            RecordingTracingInterceptor.RemoveFromContext(_httpTracingInterceptor);
            DebugStreamTraceListener.RemoveAdalTracing(_adalListener);
            FlushDebugMessages();

            AzureSession.ClientFactory.UserAgents.RemoveWhere(u => u.Product.Name == ModuleName);
            AzureSession.ClientFactory.RemoveHandler(typeof(CmdletInfoHandler));
            base.EndProcessing();
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

        protected new void WriteError(ErrorRecord errorRecord)
        {
            FlushDebugMessages(IsDataCollectionAllowed());
            if (QosEvent != null && errorRecord != null)
            {
                QosEvent.Exception = errorRecord.Exception;
                QosEvent.IsSuccess = false;
                LogQosEvent(true);
            }
            
            base.WriteError(errorRecord);
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
            while (_debugMessages.TryDequeue(out message))
            {
                base.WriteDebug(message);
            }
        }

        protected abstract void InitializeQosEvent();

        private void RecordDebugMessages()
        {
            // Create 'ErrorRecords' folder under profile directory, if not exists
            if (string.IsNullOrEmpty(_errorRecordFolderPath) || !Directory.Exists(_errorRecordFolderPath))
            {
                _errorRecordFolderPath = Path.Combine(AzureSession.ProfileDirectory, "ErrorRecords");
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

            foreach (var content in _debugMessages)
            {
                sb.AppendLine(content);
            }

            AzureSession.DataStore.WriteFile(filePath, sb.ToString());
        }

        /// <summary>
        /// Invoke this method when the cmdlet is completed or terminated.
        /// </summary>
        protected void LogQosEvent(bool waitForMetricSending = false)
        {
            if (QosEvent == null)
            {
                return;
            }

            QosEvent.FinishQosEvent();

            if (!IsUsageMetricEnabled && (!IsErrorMetricEnabled || QosEvent.IsSuccess))
            {
                return;
            }

            if (!IsDataCollectionAllowed())
            {
                return;
            }

            WriteDebug(QosEvent.ToString());

            try
            {
                MetricHelper.LogQoSEvent(QosEvent, IsUsageMetricEnabled, IsErrorMetricEnabled);
                MetricHelper.FlushMetric(waitForMetricSending);
                WriteDebug("Finish sending metric.");
            }
            catch (Exception e)
            {
                //Swallow error from Application Insights event collection.
                WriteWarning(e.ToString());
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
            if (QosEvent != null)
            {
                QosEvent.PauseQoSTimer();
            }
            
            if (force || ShouldContinue(actionMessage, ""))
            {
                if (ShouldProcess(target, processMessage))
                {                 
                    if (QosEvent != null)
                    {
                        QosEvent.ResumeQosTimer();
                    }
                    action();
                }
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
            if (_adalListener != null)
            {
                _adalListener.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
