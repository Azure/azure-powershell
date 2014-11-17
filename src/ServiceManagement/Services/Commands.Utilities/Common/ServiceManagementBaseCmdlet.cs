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
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using AutoMapper;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public abstract class ServiceManagementBaseCmdlet : CloudBaseCmdlet<IServiceManagement>
    {
        private Lazy<Runspace> runspace;

        protected ServiceManagementBaseCmdlet()
        {
            runspace = new Lazy<Runspace>(() => {
                var localRunspace = RunspaceFactory.CreateRunspace(this.Host);
                localRunspace.Open();
                return localRunspace;
            });
            client = new Lazy<ManagementClient>(CreateClient);
            computeClient = new Lazy<ComputeManagementClient>(CreateComputeClient);
            storageClient = new Lazy<StorageManagementClient>(CreateStorageClient);
            networkClient = new Lazy<NetworkManagementClient>(CreateNetworkClient);
        }

        public ManagementClient CreateClient()
        {
            return AzureSession.ClientFactory.CreateClient<ManagementClient>(CurrentContext.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        public ComputeManagementClient CreateComputeClient()
        {
            return AzureSession.ClientFactory.CreateClient<ComputeManagementClient>(CurrentContext.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        public StorageManagementClient CreateStorageClient()
        {
            return AzureSession.ClientFactory.CreateClient<StorageManagementClient>(CurrentContext.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        public NetworkManagementClient CreateNetworkClient()
        {
            return AzureSession.ClientFactory.CreateClient<NetworkManagementClient>(CurrentContext.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        private Lazy<ManagementClient> client;
        public ManagementClient ManagementClient 
        { 
            get { return client.Value; }
        }

        private Lazy<ComputeManagementClient> computeClient;
        public ComputeManagementClient ComputeClient 
        {
            get { return computeClient.Value; }
        }

        private Lazy<StorageManagementClient> storageClient;
        public StorageManagementClient StorageClient 
        {
            get { return storageClient.Value; }
        }

        private Lazy<NetworkManagementClient> networkClient;
        public NetworkManagementClient NetworkClient 
        {
            get { return networkClient.Value; }
        }

        protected override void InitChannelCurrentSubscription(bool force)
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the client would also dispose the channel we are returning.")]
        protected override IServiceManagement CreateChannel()
        {
            // If ShareChannel is set by a unit test, use the same channel that
            // was passed into out constructor.  This allows the test to submit
            // a mock that we use for all network calls.
            if (ShareChannel)
            {
                return Channel;
            }

            var messageInspectors = new List<IClientMessageInspector>
            {
                new ServiceManagementClientOutputMessageInspector(),
                new HttpRestMessageInspector(this.WriteDebug)
            };

            /*
            var clientOptions = new ServiceManagementClientOptions(null, null, null, 0, RetryPolicy.NoRetryPolicy, ServiceManagementClientOptions.DefaultOptions.WaitTimeForOperationToComplete, messageInspectors);
            var smClient = new ServiceManagementClient(new Uri(this.ServiceEndpoint), CurrentContext.Subscription.SubscriptionId, CurrentContext.Subscription.Certificate, clientOptions);

            Type serviceManagementClientType = typeof(ServiceManagementClient);
            PropertyInfo propertyInfo = serviceManagementClientType.GetProperty("SyncService", BindingFlags.Instance | BindingFlags.NonPublic);
            var syncService = (IServiceManagement)propertyInfo.GetValue(smClient, null);

            return syncService;
            */
            return null;
        }

        /// <summary>
        /// Invoke the given operation within an OperationContextScope if the
        /// channel supports it.
        /// </summary>
        /// <param name="action">The action to invoke.</param>
        protected override void InvokeInOperationContext(Action action)
        {
            IContextChannel contextChannel = ToContextChannel();
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

        protected virtual IContextChannel ToContextChannel()
        {
            try
            {
                //return Channel.ToContextChannel();
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected virtual void WriteExceptionDetails(Exception exception)
        {
            if (CommandRuntime != null)
            {
                WriteError(new ErrorRecord(exception, string.Empty, ErrorCategory.CloseError, null));
            }
        }

        protected OperationStatusResponse GetOperationStatusNewSM(string operationId)
        {
            OperationStatusResponse response = this.ManagementClient.GetOperationStatus(operationId);
            return response;
        }

        protected OperationStatusResponse GetOperationNewSM(string operationId)
        {
            OperationStatusResponse operation = null;

            try
            {
                operation = GetOperationStatusNewSM(operationId);

                if (operation.Status == OperationStatus.Failed)
                {
                    var errorMessage = string.Format(CultureInfo.InvariantCulture, "{0}: {1}", operation.Status, operation.Error.Message);
                    var exception = new Exception(errorMessage);
                    WriteError(new ErrorRecord(exception, string.Empty, ErrorCategory.CloseError, null));
                }
            }
            catch (AggregateException ex)
            {
                WriteExceptionDetails(ex);
            }

            return operation;
        }

        //TODO: Input argument is not used and should probably be removed.
        protected void ExecuteClientActionNewSM<TResult>(object input, string operationDescription, Func<TResult> action, Func<OperationStatusResponse, TResult, object> contextFactory) where TResult : OperationResponse
        {
            ExecuteClientActionNewSM(input, operationDescription, action, null, contextFactory);
        }

        protected void ExecuteClientActionNewSM<TResult>(object input, string operationDescription, Func<TResult> action, Func<string, string, OperationStatusResponse> waitOperation, Func<OperationStatusResponse, TResult, object> contextFactory) where TResult : OperationResponse
        {
            TResult result = null;
            OperationStatusResponse operation = null;
            WriteVerboseWithTimestamp(string.Format(Resources.ServiceManagementExecuteClientActionInOCSBeginOperation, operationDescription));
            try
            {
                try
                {
                    result = action();
                }
                catch (CloudException ex)
                {
                    WriteExceptionDetails(ex);
                }

                if (result is OperationStatusResponse)
                {
                    operation = result as OperationStatusResponse;
                }
                else
                {
                    if (waitOperation == null)
                    {
                        operation = result == null ? null : GetOperationNewSM(result.RequestId);
                    }
                    else
                    {
                        operation = result == null ? null : waitOperation(result.RequestId, operationDescription);
                    }
                }
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is CloudException)
                {
                    WriteExceptionDetails(ex.InnerException);
                }
                else
                {
                    WriteExceptionDetails(ex);
                }
            }

            WriteVerboseWithTimestamp(string.Format(Resources.ServiceManagementExecuteClientActionInOCSCompletedOperation, operationDescription));

            if (result != null)
            {
                var context = contextFactory(operation, result);
                if (context != null)
                {
                    WriteObject(context, true);
                }
            }
        }

        protected void ExecuteClientActionNewSM<TResult>(object input, string operationDescription, Func<TResult> action) where TResult : OperationResponse
        {
            this.ExecuteClientActionNewSM(input, operationDescription, action, (s, response) => this.ContextFactory<OperationResponse, ManagementOperationContext>(response, s));
        }

        protected T2 ContextFactory<T1, T2>(T1 source, OperationStatusResponse response) where T2 : ManagementOperationContext
        {
            var context = Mapper.Map<T1, T2>(source);
            context = Mapper.Map(response, context);
            context.OperationDescription = CommandRuntime.ToString();
            return context;
        }
    }
}