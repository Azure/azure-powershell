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
using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.Network;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    /// <summary>
    /// Base class of etw streaming cmdlets
    /// </summary>
    public class EtwStreamingCmdletBase : ComputeClientBaseCmdlet
    {
        private NetworkClient _networkClient;

        public NetworkClient NetworkClient
        {
            get
            {
                if (_networkClient == null)
                {
                    _networkClient = new NetworkClient(DefaultProfile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return _networkClient;
            }
        }

        public IVirtualMachinesOperations VirtualMachineClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachines;
            }
        }

        public IVirtualMachineScaleSetsOperations VirtualMachineScaleSetClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachineScaleSets;
            }
        }

        public INetworkSecurityGroupsOperations NetworkSecurityGroupClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.NetworkSecurityGroups;
            }
        }

        public INetworkInterfacesOperations NetworkInterfaceClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.NetworkInterfaces;
            }
        }

        public ILoadBalancersOperations LoadBalancerClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.LoadBalancers;
            }
        }

        public ISubnetsOperations SubnetClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.Subnets;
            }
        }

        private IKeyVaultClient keyVaultClient;

        public IKeyVaultClient KeyVaultClient
        {
            get
            {
                if (keyVaultClient == null)
                {
                    var credential = new DataServiceCredential(AzureSession.AuthenticationFactory, DefaultContext, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);
                    this.keyVaultClient = AzureSession.ClientFactory.CreateCustomArmClient<KeyVaultClient>(new KeyVaultClient.AuthenticationCallback(credential.OnAuthentication));
                }

                return this.keyVaultClient;
            }
        }

        private IKeyVaultManagementClient keyVaultManagementClient;

        public IKeyVaultManagementClient KeyVaultManagementClient
        {
            get
            {
                if (this.keyVaultManagementClient == null)
                {
                    this.keyVaultManagementClient = AzureSession.ClientFactory.CreateCustomArmClient<KeyVaultManagementClient>(AzureSession.AuthenticationFactory.GetServiceClientCredentials(DefaultContext));
                    this.keyVaultManagementClient.SubscriptionId = DefaultContext.Subscription.Id.ToString();
                }

                return this.keyVaultManagementClient;
            }
        }

        private ActiveDirectoryClient activeDirectoryClient;
        public ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {
                if (this.activeDirectoryClient == null)
                {
                    this.activeDirectoryClient = new ActiveDirectoryClient(DefaultContext);
                }

                return this.activeDirectoryClient;
            }
        }

        private Guid accountUniqueId;

        /// <summary>
        /// Azure Account Unique Id
        /// </summary>
        public Guid AccountUniqueId
        {
            get
            {
                if (accountUniqueId == Guid.Empty)
                {
                    var tokenItem = new TokenCache(DefaultContext.TokenCache).ReadItems().FirstOrDefault(v => v.UniqueId != null);
                    if (tokenItem == null || Guid.TryParse(tokenItem.UniqueId, out this.accountUniqueId))
                    {
                        ADObjectFilterOptions options;

                        switch (DefaultContext.Account.Type)
                        {
                            case AzureAccount.AccountType.User:
                                options = new ADObjectFilterOptions { UPN = DefaultContext.Account.Id };
                                break;
                            case AzureAccount.AccountType.ServicePrincipal:
                                options = new ADObjectFilterOptions { SPN = DefaultContext.Account.Id.Split('@')[0] };
                                break;
                            default:
                                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Properties.Resources.NotSupportedAccountType, DefaultContext.Account.Type));
                        }

                        // try to retrieve object id
                        var objectId = ActiveDirectoryClient.GetObjectId(options);
                        if (objectId != null && objectId != Guid.Empty)
                        {
                            this.accountUniqueId = objectId;
                        }
                    }
                }

                return this.accountUniqueId;
            }
        }

        private readonly ConcurrentQueue<DispatchMessage> messageQueue = new ConcurrentQueue<DispatchMessage>();

        /// <summary>
        /// Dispatch output message which targets to output pipe
        /// Can be invoked from background thread
        /// </summary>
        /// <param name="obj">Output object</param>
        public void DispatchOutputMessage(object obj)
        {
            this.messageQueue.Enqueue(new DispatchMessage { Type = DispatchMessageType.Output, Content = obj });
        }

        /// <summary>
        /// Dispatch message which targets to verbose message pipe
        /// Can be invoked from background thread
        /// </summary>
        /// <param name="message">Verbose message</param>
        public void DispatchVerboseMessage(string message)
        {
            this.messageQueue.Enqueue(new DispatchMessage { Type = DispatchMessageType.Verbose, Content = message });
        }

        /// <summary>
        /// Dispatch message which targets to warnning message pipe
        /// Can be invoked from background thread
        /// </summary>
        /// <param name="message">Warning message</param>
        public void DispatchWarningMessage(string message)
        {
            this.messageQueue.Enqueue(new DispatchMessage { Type = DispatchMessageType.Warning, Content = message });
        }

        /// <summary>
        /// Dispatch message which targets to debug message pipe
        /// Can be invoked from background thread
        /// </summary>
        /// <param name="message">Debug message</param>
        public void DispatchDebugMessage(string message)
        {
            this.messageQueue.Enqueue(new DispatchMessage { Type = DispatchMessageType.Debug, Content = message });
        }

        /// <summary>
        /// Wait for a task being completed.
        /// In the meantime, flush messages from the message queue.
        /// </summary>
        /// <param name="task"></param>
        public void FlushMessageWhileWait(Task task)
        {
            DispatchMessage message;
            while (!task.IsCompleted || this.messageQueue.Any())
            {
                if (this.messageQueue.TryDequeue(out message))
                {
                    switch (message.Type)
                    {
                        case DispatchMessageType.Output:
                            WriteObject(message.Content);
                            break;
                        case DispatchMessageType.Verbose:
                            WriteVerbose(message.Content as string);
                            break;
                        case DispatchMessageType.Debug:
                            WriteDebug(message.Content as string);
                            break;
                        case DispatchMessageType.Warning:
                            WriteWarning(message.Content as string);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Thread.Sleep(200);
                }
            }

            if (task.Exception != null)
            {
                if (task.Exception.InnerException != null)
                {
                    ExceptionDispatchInfo.Capture(task.Exception.InnerException).Throw();
                }

                ExceptionDispatchInfo.Capture(task.Exception).Throw();
            }
        }

        private enum DispatchMessageType
        {
            Debug,
            Warning,
            Verbose,
            Output
        }

        private class DispatchMessage
        {
            public DispatchMessageType Type { get; set; }

            public object Content { get; set; }
        }
    }
}
