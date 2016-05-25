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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public abstract class CloudBaseCmdlet<T> : AzureSMCmdlet
        where T : class
    {
        private Binding _serviceBinding;

        public Binding ServiceBinding
        {
            get
            {
                if (_serviceBinding == null)
                {
                    _serviceBinding = ConfigurationConstants.WebHttpBinding(MaxStringContentLength);
                }

                return _serviceBinding;
            }

            set { _serviceBinding = value; }
        }

        public T Channel
        {
            get;
            set;
        }

        protected void OnCurrentSubscriptionUpdated()
        {
            // Recreate the channel if necessary
            if (!ShareChannel)
            {
                InitChannelCurrentSubscription(true);
            }
        }

        public int MaxStringContentLength
        {
            get;
            set;
        }


        protected void InitChannelCurrentSubscription()
        {
            InitChannelCurrentSubscription(false);
        }

        protected virtual void InitChannelCurrentSubscription(bool force)
        {
            DoInitChannelCurrentSubscription(force);
        }

        protected void DoInitChannelCurrentSubscription(bool force)
        {
            if (Profile.Context.Subscription == null)
            {
                throw new ArgumentException(Resources.InvalidDefaultSubscription);
            }

            if (Profile.Context.Account == null)
            {
                throw new ArgumentException(Resources.AccountNeedsToBeSpecified);
            }

            if (Channel == null || force)
            {
                Channel = CreateChannel();
            }
        }

        protected virtual void OnProcessRecord()
        {
            // Intentionally left blank
        }

        protected override void ProcessRecord()
        {
            Validate.ValidateInternetConnection();
            InitChannelCurrentSubscription();
            base.ProcessRecord();
            OnProcessRecord();
        }

        /// <summary>
        /// Gets or sets a flag indicating whether CreateChannel should share
        /// the command's current Channel when asking for a new one.  This is
        /// only used for testing.
        /// </summary>
        public bool ShareChannel { get; set; }

        protected virtual T CreateChannel()
        {
            // If ShareChannel is set by a unit test, use the same channel that
            // was passed into out constructor.  This allows the test to submit
            // a mock that we use for all network calls.
            if (ShareChannel)
            {
                return Channel;
            }

            string certificateThumbprint = Profile.Context.Account.Id;
            Debug.Assert(Profile.Accounts[certificateThumbprint].Type == AzureAccount.AccountType.Certificate);

            return ChannelHelper.CreateServiceManagementChannel<T>(
                ServiceBinding,
                Profile.Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ServiceManagement),
                AzureSession.DataStore.GetCertificate(certificateThumbprint),
                new HttpRestMessageInspector(WriteDebug));
        }

        protected void RetryCall(Action<string> call)
        {
            RetryCall(Profile.Context.Subscription.Id, call);
        }

        protected void RetryCall(Guid subsId, Action<string> call)
        {
            try
            {
                call(subsId.ToString());
            }
            catch (MessageSecurityException ex)
            {
                var webException = ex.InnerException as WebException;

                if (webException == null)
                {
                    throw;
                }

                var webResponse = webException.Response as HttpWebResponse;

                if (webResponse != null && webResponse.StatusCode == HttpStatusCode.Forbidden)
                {
                    WriteError(new ErrorRecord(new Exception(Resources.CommunicationCouldNotBeEstablished, ex), string.Empty, ErrorCategory.InvalidData, null));
                }
                else
                {
                    throw;
                }
            }
        }

        protected TResult RetryCall<TResult>(Func<string, TResult> call)
        {
            return RetryCall(Profile.Context.Subscription.Id, call);
        }

        protected TResult RetryCall<TResult>(Guid subsId, Func<string, TResult> call)
        {
            try
            {
                return call(subsId.ToString());
            }
            catch (MessageSecurityException ex)
            {
                var webException = ex.InnerException as WebException;

                if (webException == null)
                {
                    throw;
                }

                var webResponse = webException.Response as HttpWebResponse;

                if (webResponse != null && webResponse.StatusCode == HttpStatusCode.Forbidden)
                {
                    WriteError(new ErrorRecord(new Exception(Resources.CommunicationCouldNotBeEstablished, ex), string.Empty, ErrorCategory.InvalidData, null));
                    throw;
                }

                throw;
            }
        }

        /// <summary>
        /// Invoke the given operation within an OperationContextScope if the
        /// channel supports it.
        /// </summary>
        /// <param name="action">The action to invoke.</param>
        protected virtual void InvokeInOperationContext(Action action)
        {
            IContextChannel contextChannel = Channel as IContextChannel;
            if (contextChannel != null)
            {
                using (new OperationContextScope(contextChannel))
                {
                    action();
                }
            }
            else
            {
                action();
            }
        }

        protected virtual void WriteErrorDetails(CommunicationException exception)
        {
            ServiceManagementError error;
            ErrorRecord errorRecord = null;

            string operationId;
            if (ErrorHelper.TryGetExceptionDetails(exception, out error, out operationId))
            {
                string errorDetails = string.Format(
                    CultureInfo.InvariantCulture,
                    "HTTP Status Code: {0} - HTTP Error Message: {1}\nOperation ID: {2}",
                    error.Code,
                    error.Message,
                    operationId);

                errorRecord = new ErrorRecord(
                    new CommunicationException(errorDetails),
                    string.Empty,
                    ErrorCategory.CloseError,
                    null);
            }
            else
            {
                errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.CloseError, null);
            }

            if (CommandRuntime != null)
            {
                WriteError(errorRecord);
            }
        }
    }
}
