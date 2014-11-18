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
using System.Diagnostics;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public abstract class AzurePSCmdlet : PSCmdlet
    {
        private readonly RecordingTracingInterceptor httpTracingInterceptor = new RecordingTracingInterceptor();

        public AzurePSCmdlet()
        {
            DefaultProfileClient = new ProfileClient();

            if (AzureSession.CurrentContext.Subscription == null &&
               DefaultProfileClient.Profile.DefaultSubscription != null)
            {
                try
                {
                    AzureSession.SetCurrentContext(
                        DefaultProfileClient.Profile.DefaultSubscription,
                        DefaultProfileClient.GetEnvironmentOrDefault(
                            DefaultProfileClient.Profile.DefaultSubscription.Environment),
                        DefaultProfileClient.GetAccountOrNull(DefaultProfileClient.Profile.DefaultSubscription.Account));
                }
                catch
                {
                    // Ignore anything at this point
                }
            }

        }

        public AzureContext CurrentContext
        {
            get { return AzureSession.CurrentContext; }
        }

        public bool HasCurrentSubscription
        {
            get { return AzureSession.CurrentContext.Subscription != null; }
        }

        public ProfileClient DefaultProfileClient { get; private set; }

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
            FlushMessagesFromTracingInterceptor();
            base.WriteError(errorRecord);
        }

        public new void WriteObject(object sendToPipeline)
        {
            FlushMessagesFromTracingInterceptor();
            base.WriteObject(sendToPipeline);
        }

        public new void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            FlushMessagesFromTracingInterceptor();
            base.WriteObject(sendToPipeline, enumerateCollection);
        }

        public new void WriteVerbose(string text)
        {
            FlushMessagesFromTracingInterceptor();
            base.WriteVerbose(text);
        }

        public new void WriteWarning(string text)
        {
            FlushMessagesFromTracingInterceptor();
            base.WriteWarning(text);
        }

        public new void WriteCommandDetail(string text)
        {
            FlushMessagesFromTracingInterceptor();
            base.WriteCommandDetail(text);
        }

        public new void WriteProgress(ProgressRecord progressRecord)
        {
            FlushMessagesFromTracingInterceptor();
            base.WriteProgress(progressRecord);
        }

        public new void WriteDebug(string text)
        {
            FlushMessagesFromTracingInterceptor();
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

        /// <summary>
        /// Cmdlet begin process
        /// </summary>
        protected override void BeginProcessing()
        {
            if (string.IsNullOrEmpty(ParameterSetName))
            {
                WriteDebugWithTimestamp(string.Format(Resources.BeginProcessingWithoutParameterSetLog, this.GetType().Name));
            }
            else
            {
                WriteDebugWithTimestamp(string.Format(Resources.BeginProcessingWithParameterSetLog, this.GetType().Name, ParameterSetName));
            }

            if (CurrentContext != null && CurrentContext.Account != null && CurrentContext.Account.Id != null)
            {
                WriteDebugWithTimestamp(string.Format("using account id '{0}'...", CurrentContext.Account.Id));
            }

            RecordingTracingInterceptor.AddToContext(httpTracingInterceptor);

            base.BeginProcessing();
        }

        private void FlushMessagesFromTracingInterceptor()
        {
            string message;
            while (httpTracingInterceptor.MessageQueue.TryDequeue(out message))
            {
                base.WriteDebug(message);
            }
        }

        /// <summary>
        /// End processing
        /// </summary>
        protected override void EndProcessing()
        {
            string message = string.Format(Resources.EndProcessingLog, this.GetType().Name);
            WriteDebugWithTimestamp(message);

            RecordingTracingInterceptor.RemoveFromContext(httpTracingInterceptor);
            FlushMessagesFromTracingInterceptor();

            base.EndProcessing();
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
