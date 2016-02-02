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
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common;
using Newtonsoft.Json;
using System.IO;
using System.Management.Automation.Host;
using System.Text;
using System.Linq;
using System.Threading;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Utilities.Common
{
    /// <summary>
    /// Represents base class for all Azure cmdlets.
    /// </summary>
    public abstract class AzurePSCmdlet : PSCmdlet, IDisposable
    {
        protected readonly ConcurrentQueue<string> _debugMessages;
        private DebugStreamTraceListener _adalListener;
        protected static string _errorRecordFolderPath = null;
        protected const string _fileTimeStampSuffixFormat = "yyyy-MM-dd-THH-mm-ss-fff";
        protected string _clientRequestId = Guid.NewGuid().ToString();
        public IClientFactory ClientFactory { get; set; }

        public IAuthenticationFactory AuthenticationFactory { get; set; }

        public IDataStore DataStore { get; set; }

        protected AzurePSQoSEvent QosEvent;

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
        /// By default uses "AzureCLU"
        /// </summary>
        protected virtual string ModuleName { get { return "AzureCLU"; } }

        /// <summary>
        /// Gets PowerShell module version used for user agent header.
        /// </summary>
        protected string ModuleVersion { get { return AzurePowerShell.AssemblyFileVersion; } }

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
            //TODO: Inject from CI server
            MetricHelper.AddTelemetryClient(new TelemetryClient
            {
                InstrumentationKey = "963c4276-ec20-48ad-b9ab-3968e9da5578"
            });
#if DEBUG
            if (!TestMockSupport.RunningMocked)
            {
#endif
                DataStore = DataStore ?? new DiskDataStore();
#if DEBUG
            }
            else
            {
                DataStore = DataStore ?? new MemoryDataStore();
            }
#endif
            AuthenticationFactory = AuthenticationFactory ?? new AuthenticationFactory(DataStore);
            ClientFactory =  ClientFactory?? new ClientFactory(DataStore, AuthenticationFactory);
        }

        protected virtual T GetSessionVariableValue<T>(string name, T defaultValue) where T : class
        {
            var returnValue = defaultValue;
            if (SessionState != null)
            {
                try
                {
                    returnValue = SessionState.PSVariable.Get<T>(name) ?? defaultValue;
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    var variablePath = GetPath(name);
                    var fileText = DataStore.ReadFileAsText(variablePath);
                    if (!string.IsNullOrEmpty(fileText))
                    {
                        returnValue = JsonConvert.DeserializeObject<T>(fileText);
                    }
                }
                catch
                {
                    
                }
            }

            return returnValue;
        }

        protected virtual string GetPath(string variableName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "sessions", variableName);
        }

        protected virtual void SetSessionVariable<T>(string name, T value) where T : class
        {
            if (SessionState != null)
            {
                SessionState.PSVariable.Set(name, value);
            }
            else
            {
                var variablePath = GetPath(name);
                DataStore.WriteFile(variablePath, JsonConvert.SerializeObject(value));
            }
        }

        /// <summary>
        /// Check whether the data collection is opted in from user
        /// </summary>
        /// <returns>true if allowed</returns>
        protected abstract bool IsTelemetryCollectionEnabled
        {
            get;
        }

        /// <summary>
        /// Cmdlet begin process. Write to logs, setup Http Tracing and initialize profile
        /// </summary>
        protected override void BeginProcessing()
        {
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

            DataStore = DataStore?? GetSessionVariableValue<IDataStore>(AzurePowerShell.DataStoreVariable, new DiskDataStore());
            _adalListener = _adalListener ?? new DebugStreamTraceListener(_debugMessages);
            DebugStreamTraceListener.AddAdalTracing(_adalListener);

            List<ProductInfoHeaderValue> headerList =
                GetSessionVariableValue(AzurePowerShell.UserAgentVariable, new List<ProductInfoHeaderValue>());
            foreach (var header in headerList)
            {
                ClientFactory.UserAgents.Add(header);
            }

            ProductInfoHeaderValue userAgentValue = new ProductInfoHeaderValue(
                ModuleName, string.Format("v{0}", ModuleVersion));
            ClientFactory.UserAgents.Add(userAgentValue);
            ClientFactory.AddHandler(new CmdletInfoHandler(this.CommandRuntime.ToString(), this.ParameterSetName, this._clientRequestId));
            ServiceClientTracing.AddTracingInterceptor(_adalListener);
            ServiceClientTracing.IsEnabled = true;
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

            DebugStreamTraceListener.RemoveAdalTracing(_adalListener);
            FlushDebugMessages();

            ClientFactory.UserAgents.RemoveWhere(u => u.Product.Name == ModuleName);
            ClientFactory.RemoveHandler(typeof(CmdletInfoHandler));
            var headerList = new List<ProductInfoHeaderValue>();
            foreach (var userAgent in ClientFactory.UserAgents)
            {
                headerList.Add(userAgent);
            }

            SetSessionVariable(AzurePowerShell.UserAgentVariable, headerList);
            if (!(DataStore is DiskDataStore))
            {
                SetSessionVariable(AzurePowerShell.DataStoreVariable, DataStore);
            }

            base.EndProcessing();
        }

        protected bool IsVerbose()
        {
            bool verbose = MyInvocation.BoundParameters.ContainsKey("Verbose") && ((SwitchParameter)MyInvocation.BoundParameters["Verbose"]).ToBool();
            return verbose;
        }

        protected new void WriteError(ErrorRecord errorRecord)
        {
            FlushDebugMessages(IsTelemetryCollectionEnabled);
            if (QosEvent != null && errorRecord != null)
            {
                QosEvent.Exception = errorRecord.Exception;
                QosEvent.IsSuccess = false;
                LogQosEvent();
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

        protected PSObject ConstructPSObject(params object[] args)
        {
            return PowerShellUtilities.ConstructPSObject(args);
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
                _errorRecordFolderPath = Path.Combine(AzurePowerShell.ProfileDirectory, "ErrorRecords");
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

            DataStore.WriteFile(filePath, sb.ToString());
        }

        /// <summary>
        /// Invoke this method when the cmdlet is completed or terminated.
        /// </summary>
        protected void LogQosEvent()
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

            if (!IsTelemetryCollectionEnabled)
            {
                return;
            }

            WriteDebug(QosEvent.ToString());

            try
            {
                MetricHelper.LogQoSEvent(QosEvent, 
                    IsUsageMetricEnabled && IsTelemetryCollectionEnabled, 
                    IsErrorMetricEnabled && IsTelemetryCollectionEnabled);
                MetricHelper.FlushMetric(IsTelemetryCollectionEnabled);
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
