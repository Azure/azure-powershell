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

using Commands.StorageSync.Interop.Clients;
using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Enums;
using Commands.StorageSync.Interop.Exceptions;
using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{
    /// <summary>
    /// Class RegisterServerCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsLifecycle.Register, StorageSyncNouns.NounAzureRmStorageSyncServer,
        DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSRegisteredServer))]
    public class RegisterServerCommand : StorageSyncClientCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        /// <value>The name of the resource group.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the storage sync service.
        /// </summary>
        /// <value>The name of the storage sync service.</value>
        [Parameter(
           Position = 1,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.ParentNameAlias)]
        public string StorageSyncServiceName { get; set; }

        /// <summary>
        /// Gets or sets the parent object.
        /// </summary>
        /// <value>The parent object.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ObjectParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.StorageSyncServiceObjectParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.StorageSyncServiceAlias)]
        public PSStorageSyncService ParentObject { get; set; }

        /// <summary>
        /// Gets or sets the parent resource identifier.
        /// </summary>
        /// <value>The parent resource identifier.</value>
        [Parameter(
          Position = 0,
          ParameterSetName = StorageSyncParameterSets.ParentStringParameterSet,
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = HelpMessages.StorageSyncServiceParentResourceIdParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter(StorageSyncConstants.StorageSyncServiceType)]
        [Alias(StorageSyncAliases.StorageSyncServiceIdAlias)]
        public string ParentResourceId { get; set; }


        /// <summary>
        /// Gets or sets as job.
        /// </summary>
        /// <value>As job.</value>
        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJobParameter)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        protected override string Target => StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? ParentResourceId;

        /// <summary>
        /// Gets or sets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected override string ActionMessage => $"{StorageSyncResources.RegisterServerActionMessage} {StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? ParentResourceId}";

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                var parentResourceIdentifier = default(ResourceIdentifier);

                if (this.IsParameterBound(c => c.ParentResourceId))
                {
                    parentResourceIdentifier = new ResourceIdentifier(ParentResourceId);

                    if (!string.Equals(StorageSyncConstants.StorageSyncServiceType, parentResourceIdentifier.ResourceType, System.StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException(StorageSyncResources.MissingParentResourceIdErrorMessage);
                    }
                }

                var resourceGroupName = ResourceGroupName ?? ParentObject?.ResourceGroupName ?? parentResourceIdentifier?.ResourceGroupName;
                var parentResourceName = StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? parentResourceIdentifier?.ResourceName;

                Target = string.Join("/", resourceGroupName, parentResourceName);

                if (ShouldProcess(Target, ActionMessage))
                {
                    try
                    {
                        RegisteredServer resource = PerformServerRegistration(resourceGroupName, SubscriptionId, parentResourceName);
                        WriteObject(resource);
                    }
                    catch(ServerRegistrationException ex)
                    {
                        this.StorageSyncClientWrapper.VerboseLogger.Invoke($"Registration failed with Category : {ex.Category} , ErrorCode : {ex.ExternalErrorCode} ");
                        this.StorageSyncClientWrapper.VerboseLogger.Invoke($"Exception details : {ex}");
                        throw;
                    }
                    
                }
            });
        }

        private string m_serverMachineName;
        protected string ServerMachineName
        {
            get
            {
                if (m_serverMachineName == null)
                {
                    m_serverMachineName = SystemUtility.GetMachineName();
                    if (string.IsNullOrEmpty(m_serverMachineName))
                    {
                        throw new ServerRegistrationException(ServerRegistrationErrorCode.ServerNameIsNullOrEmpty);
                    }
                }
                return m_serverMachineName;
            }
        }

        /// <summary>
        /// Performs the server registration.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <param name="storageSyncServiceName">Name of the storage sync service.</param>
        /// <returns>RegisteredServer.</returns>
        /// <exception cref="PSArgumentException">AfsAgentInstallerPath</exception>
        private RegisteredServer PerformServerRegistration(string resourceGroupName, Guid subscriptionId, string storageSyncServiceName)
        {
            using (ISyncServerRegistration syncServerRegistrationClient = StorageSyncClientWrapper.StorageSyncResourceManager.CreateSyncServerManagement())
            {
                if (string.IsNullOrEmpty(StorageSyncClientWrapper.AfsAgentInstallerPath))
                {
                    throw new PSArgumentException(StorageSyncResources.MissingAfsAgentInstallerPathErrorMessage);
                }

                return syncServerRegistrationClient.Register(
                    ProductionArmServiceHost.ToUri(),
                    subscriptionId,
                    storageSyncServiceName,
                    resourceGroupName,
                    ManagementInteropConstants.CertificateProviderName,
                    ManagementInteropConstants.CertificateHashAlgorithm,
                    ManagementInteropConstants.CertificateKeyLength,
                    Path.Combine(StorageSyncClientWrapper.AfsAgentInstallerPath, StorageSyncConstants.MonitoringAgentDirectoryName),
                    StorageSyncClientWrapper.AfsAgentVersion,
                    ServerMachineName,
                    (pResourceGroupName, pStorageSyncCerviceName, pServerRegistrationData) => CreateRegisteredResourceInCloud(pResourceGroupName, pStorageSyncCerviceName,
                            StorageSyncClientWrapper.StorageSyncResourceManager.UpdateServerRegistrationData(pServerRegistrationData)));
            }
        }

        /// <summary>
        /// Creates the registered resource in cloud.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="storageSyncServiceName">Name of the storage sync service.</param>
        /// <param name="serverRegistrationData">The server registration data.</param>
        /// <returns>RegisteredServer.</returns>
        private RegisteredServer CreateRegisteredResourceInCloud(string resourceGroupName, string storageSyncServiceName, ServerRegistrationData serverRegistrationData)
        {
            var createParameters = new RegisteredServerCreateParameters()
            {
                ServerId = serverRegistrationData.ServerId.ToString(),
                ClusterId = serverRegistrationData.ClusterId.ToString(),
                ClusterName = serverRegistrationData.ClusterName,
                AgentVersion = serverRegistrationData.AgentVersion,
                //ApplicationId = serverRegistrationData.ApplicationId.HasValue ? serverRegistrationData.ApplicationId.Value.ToString() : null,
                ApplicationId = Guid.Empty.ToString(),
                ServerCertificate = serverRegistrationData.ServerCertificate != null ? Convert.ToBase64String(serverRegistrationData.ServerCertificate) : null,
                ServerOSVersion = serverRegistrationData.ServerOSVersion,
                ServerRole = serverRegistrationData.ServerRole.ToString(),
                FriendlyName = SystemUtility.GetMachineName(),
                LastHeartBeat = DateTime.Now.ToString(),
            };

            return StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.Create(
               resourceGroupName,
                storageSyncServiceName,
                serverRegistrationData.ServerId.ToString(),
                createParameters);
        }
    }
}