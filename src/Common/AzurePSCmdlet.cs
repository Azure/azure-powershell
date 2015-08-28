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

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    /// <summary>
    /// Represents base class for all Azure cmdlets.
    /// </summary>
    public abstract class AzurePSCmdlet : PSCmdlet, IDisposable
    {
        private readonly ConcurrentQueue<string> _debugMessages;

        private RecordingTracingInterceptor _httpTracingInterceptor;

        private DebugStreamTraceListener _adalListener;

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
        /// Cmdlet begin process. Write to logs, setup Http Tracing and initialize profile and adds user agent.
        /// </summary>
        protected override void BeginProcessing()
        {
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

            base.BeginProcessing();
        }

        /// <summary>
        /// End processing. Flush messages in tracing interceptor and save profile and removes user agent.
        /// </summary>
        protected override void EndProcessing()
        {
            string message = string.Format("{0} end processing.", this.GetType().Name);
            WriteDebugWithTimestamp(message);

            RecordingTracingInterceptor.RemoveFromContext(_httpTracingInterceptor);
            DebugStreamTraceListener.RemoveAdalTracing(_adalListener);
            FlushDebugMessages();

            AzureSession.ClientFactory.UserAgents.RemoveAll(u => u.Product.Name == ModuleName);

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
            FlushDebugMessages();
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

        protected virtual void Dispose(bool disposing)
        {
            _adalListener.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
