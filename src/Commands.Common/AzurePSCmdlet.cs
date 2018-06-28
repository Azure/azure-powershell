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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    /// <summary>
    /// Represents base class for all Azure cmdlets.
    /// </summary>
    public abstract class AzurePSCmdlet : PSCmdlet, IDisposable
    {
        private const string PSVERSION = "PSVersion";
        private const string DEFAULT_PSVERSION = "3.0.0.0";

        public ConcurrentQueue<string> DebugMessages { get; private set; }

        private RecordingTracingInterceptor _httpTracingInterceptor;
        private object lockObject = new object();
        private AzurePSDataCollectionProfile _cachedProfile = null;

        protected AzurePSDataCollectionProfile _dataCollectionProfile
        {
            get
            {
                lock (lockObject)
                {
                    DataCollectionController controller;
                    if (_cachedProfile == null && AzureSession.Instance.TryGetComponent(DataCollectionController.RegistryKey, out controller))
                    {
                        _cachedProfile = controller.GetProfile(() => WriteWarning(DataCollectionWarning));
                    }
                    else if (_cachedProfile == null)
                    {
                        _cachedProfile = new AzurePSDataCollectionProfile(true);
                        WriteWarning(DataCollectionWarning);
                    }

                    return _cachedProfile;
                }
            }

            set
            {
                lock (lockObject)
                {
                    _cachedProfile = value;
                }
            }
        }

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
        /// Indicates installed PowerShell version
        /// </summary>
        private string _psVersion;

        /// <summary>
        /// Get PsVersion returned from PowerShell.Runspace instance
        /// </summary>
        protected string PSVersion
        {
            get
            {
                if (string.IsNullOrEmpty(_psVersion))
                {
                    if (this.Host != null)
                    {
                        _psVersion = this.Host.Version.ToString();
                    }
                    else
                    {
                        //We are doing this for perf. reasons. This code will execute during tests and so reducing the perf. overhead while running tests.
                        _psVersion = DEFAULT_PSVERSION;
                    }
                }

                return _psVersion;
            }
        }

        /// <summary>
        /// Gets the PowerShell module name used for user agent header.
        /// By default uses "Azure PowerShell"
        /// </summary>
        protected virtual string ModuleName { get { return "AzurePowershell"; } }

        /// <summary>
        /// Gets PowerShell module version used for user agent header.
        /// </summary>
        protected string ModuleVersion { get { return AzurePowerShell.AssemblyVersion; } }

        /// <summary>
        /// The context for management cmdlet requests - includes account, tenant, subscription, 
        /// and credential information for targeting and authorizing management calls.
        /// </summary>
        protected abstract IAzureContext DefaultContext { get; }

        protected abstract string DataCollectionWarning { get; }

        private SessionState _sessionState;

        public new SessionState SessionState
        {
            get
            {
                return _sessionState;
            }
            set
            {
                _sessionState = value;
            }
        }

        private RuntimeDefinedParameterDictionary _asJobDynamicParameters;

        public RuntimeDefinedParameterDictionary AsJobDynamicParameters
        {
            get
            {
                if (_asJobDynamicParameters == null)
                {
                    _asJobDynamicParameters = new RuntimeDefinedParameterDictionary();
                }
                return _asJobDynamicParameters;
            }
            set
            {
                _asJobDynamicParameters = value;
            }
        }

        /// <summary>
        /// Initializes AzurePSCmdlet properties.
        /// </summary>
        public AzurePSCmdlet()
        {
            DebugMessages = new ConcurrentQueue<string>();
        }

        // Register Dynamic Parameters for use in long running jobs
        public void RegisterDynamicParameters(RuntimeDefinedParameterDictionary parameters)
        {
            this.AsJobDynamicParameters = parameters;
        }


        /// <summary>
        /// Check whether the data collection is opted in from user
        /// </summary>
        /// <returns>true if allowed</returns>
        public bool IsDataCollectionAllowed()
        {
            if (_dataCollectionProfile != null &&
                _dataCollectionProfile.EnableAzureDataCollection.HasValue &&
                _dataCollectionProfile.EnableAzureDataCollection.Value)
            {
                return true;
            }

            return false;
        }

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

            if (!interactive && _dataCollectionProfile != null && !_dataCollectionProfile.EnableAzureDataCollection.HasValue)
            {
                _dataCollectionProfile.EnableAzureDataCollection = false;
            }
            return interactive;
        }


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
            AzureSession.Instance.ClientFactory.AddUserAgent(ModuleName, string.Format("v{0}", ModuleVersion));
            AzureSession.Instance.ClientFactory.AddUserAgent(PSVERSION, string.Format("v{0}", PSVersion));

            AzureSession.Instance.ClientFactory.AddHandler(
                new CmdletInfoHandler(this.CommandRuntime.ToString(),
                    this.ParameterSetName, this._clientRequestId));

        }

        protected virtual void TearDownHttpClientPipeline()
        {
            AzureSession.Instance.ClientFactory.RemoveUserAgent(ModuleName);
            AzureSession.Instance.ClientFactory.RemoveHandler(typeof(CmdletInfoHandler));
        }
        /// <summary>
        /// Cmdlet begin process. Write to logs, setup Http Tracing and initialize profile
        /// </summary>
        protected override void BeginProcessing()
        {
            SessionState = base.SessionState;
            var profile = _dataCollectionProfile;
            //TODO: Inject from CI server
            lock (lockObject)
            {
                if (_metricHelper == null)
                {
                    _metricHelper = new MetricHelper(profile);
                    _metricHelper.AddTelemetryClient(new TelemetryClient
                    {
                        InstrumentationKey = "7df6ff70-8353-4672-80d6-568517fed090"
                    });
                }
            }

            InitializeQosEvent();
            LogCmdletStartInvocationInfo();
            SetupDebuggingTraces();
            SetupHttpClientPipeline();
            base.BeginProcessing();

            //Now see if the cmdlet has any Breaking change attributes on it and process them if it does
            //This will print any breaking change attribute messages that are applied to the cmdlet
            BreakingChangeAttributeHelper.ProcessCustomAttributesAtRuntime(this.GetType(), this.MyInvocation, WriteWarning);
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
            if (CommandRuntime != null)
            {
                WriteVerbose(string.Format("{0:T} - {1}", DateTime.Now, string.Format(message, args)));
            }
        }

        protected void WriteVerboseWithTimestamp(string message)
        {
            if (CommandRuntime != null)
            {
                WriteVerbose(string.Format("{0:T} - {1}", DateTime.Now, message));
            }
        }

        protected void WriteWarningWithTimestamp(string message)
        {
            if (CommandRuntime != null)
            {
                WriteWarning(string.Format("{0:T} - {1}", DateTime.Now, message));
            }
        }

        protected void WriteDebugWithTimestamp(string message, params object[] args)
        {
            if (CommandRuntime != null)
            {
                WriteDebug(string.Format("{0:T} - {1}", DateTime.Now, string.Format(message, args)));
            }
        }

        protected void WriteDebugWithTimestamp(string message)
        {
            if (CommandRuntime != null)
            {
                WriteDebug(string.Format("{0:T} - {1}", DateTime.Now, message));
            }
        }

        protected void WriteErrorWithTimestamp(string message)
        {
            if (CommandRuntime != null)
            {
                WriteError(
                new ErrorRecord(new Exception(string.Format("{0:T} - {1}", DateTime.Now, message)),
                string.Empty,
                ErrorCategory.NotSpecified,
                null));
            }
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
            try
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

                AzureSession.Instance.DataStore.WriteFile(filePath, sb.ToString());
            }
            catch
            {
                // do not throw an error if recording debug messages fails
            }
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
                _metricHelper.SetPSHost(this.Host);
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
                this.ExecuteSynchronouslyOrAsJob();
            }
            catch (Exception ex) when (!IsTerminatingError(ex))
            {
                WriteExceptionError(ex);
            }
        }

        private string _implementationBackgroundJobDescription;

        /// <summary>
        /// Job Name paroperty iof this cmdlet is run as a job
        /// </summary>
        public virtual string ImplementationBackgroundJobDescription
        {
            get
            {
                if (_implementationBackgroundJobDescription != null)
                {
                    return _implementationBackgroundJobDescription;
                }
                else
                {
                    string name = "Long Running Azure Operation";
                    string commandName = MyInvocation?.MyCommand?.Name;
                    string objectName = null;
                    if (this.IsBound("Name"))
                    {
                        objectName = MyInvocation.BoundParameters["Name"].ToString();
                    }
                    else if (this.IsBound("InputObject") == true)
                    {
                        var type = MyInvocation.BoundParameters["InputObject"].GetType();
                        var inputObject = Convert.ChangeType(MyInvocation.BoundParameters["InputObject"], type);
                        if (type.GetProperty("Name") != null)
                        {
                            objectName = inputObject.GetType().GetProperty("Name").GetValue(inputObject).ToString();
                        }
                        else if (type.GetProperty("ResourceId") != null)
                        {
                            string[] tokens = inputObject.GetType().GetProperty("ResourceId").GetValue(inputObject).ToString().Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                            if (tokens.Length >= 8)
                            {
                                objectName = tokens[tokens.Length - 1];
                            }
                        }
                    }
                    else if (this.IsBound("ResourceId") == true)
                    {
                        string[] tokens = MyInvocation.BoundParameters["ResourceId"].ToString().Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        if (tokens.Length >= 8)
                        {
                            objectName = tokens[tokens.Length - 1];
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(commandName))
                    {
                        if (!string.IsNullOrWhiteSpace(objectName))
                        {
                            name = string.Format("Long Running Operation for '{0}' on resource '{1}'", commandName, objectName);
                        }
                        else
                        {
                            name = string.Format("Long Running Operation for '{0}'", commandName);
                        }
                    }

                    return name;
                }
            }
            set
            {
                _implementationBackgroundJobDescription = value;
            }
        }

        public void SetBackgroundJobDescription(string jobName)
        {
            ImplementationBackgroundJobDescription = jobName;
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

        public virtual bool IsTerminatingError(Exception ex)
        {
            var pipelineStoppedEx = ex as PipelineStoppedException;
            if (pipelineStoppedEx != null && pipelineStoppedEx.InnerException == null)
            {
                return true;
            }

            return false;
        }
    }
}
