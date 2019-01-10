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

using Commands.StorageSync.Interop;
using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{

    [Cmdlet(VerbsLifecycle.Register, StorageSyncNouns.NounAzureRmStorageSyncServer, DefaultParameterSetName = StorageSyncParameterSets.ObjectParameterSet), OutputType(typeof(PSRegisteredServer))]
    public class RegisterServerCommand : StorageSyncClientCmdletBase
    {
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Position = 1,
           ParameterSetName =StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [StorageSyncServiceCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.ParentNameAlias)]
        public string StorageSyncServiceName { get; set; }

        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ObjectParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.StorageSyncServiceObjectParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.StorageSyncServiceAlias)]
        public PSStorageSyncService ParentObject { get; set; }

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


        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJobParameter)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                var parentResourceIdentifier = default(ResourceIdentifier);

                if (!string.IsNullOrEmpty(ParentResourceId))
                {
                    parentResourceIdentifier = new ResourceIdentifier(ParentResourceId);

                    if (!string.Equals(StorageSyncConstants.StorageSyncServiceType, parentResourceIdentifier.ResourceType, System.StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException($"Invalid Argument {nameof(ParentResourceId)}", nameof(ParentResourceId));
                    }
                }

                var resourceGroupName = ResourceGroupName ?? ParentObject?.ResourceGroupName ?? parentResourceIdentifier?.ResourceGroupName;

                if(string.IsNullOrEmpty(resourceGroupName))
                {
                    throw new PSArgumentException($"Invalid Argument {nameof(ResourceGroupName)}", nameof(ResourceGroupName));
                }

                var parentResourceName = StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? parentResourceIdentifier?.ResourceName;

                if (string.IsNullOrEmpty(parentResourceName))
                {
                    throw new PSArgumentException($"Invalid Argument {nameof(StorageSyncServiceName)}", nameof(StorageSyncServiceName));
                }

                if (!SubscriptionId.HasValue)
                {
                    throw new PSArgumentException("No subscription found", nameof(SubscriptionId));
                }

                RegisteredServer resource = PerformServerRegistration(resourceGroupName, SubscriptionId.Value, parentResourceName);

                WriteObject(resource);
            });
        }
        private RegisteredServer PerformServerRegistration(string resourceGroupName, Guid subscriptionId, string storageSyncServiceName)
        {
            if (subscriptionId == null)
            {
                throw new PSArgumentException("No subscription found");
            }

            using (ISyncServerRegistration syncServerRegistrationClient = InteropClientFactory.CreateSyncServerRegistrationClient(InteropClientFactory.CreateEcsManagement(IsRunningInTest)))
            {
                if(string.IsNullOrEmpty(StorageSyncClientWrapper.AfsAgentInstallerPath))
                {
                    throw new PSArgumentException("No Afs Agent Installer path found.");
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
                    (pResourceGroupName, pStorageSyncCerviceName, pServerRegistrationData) => CreateRegisteredResourceInCloud(pResourceGroupName, pStorageSyncCerviceName, pServerRegistrationData));
            }
        }

        private RegisteredServer CreateRegisteredResourceInCloud(string resourceGroupName, string storageSyncServiceName,ServerRegistrationData serverRegistrationData)
        {
            var createParameters = new RegisteredServerCreateParameters()
            {
                ServerId = "\"" + serverRegistrationData.ServerId.ToString() + "\"",
                ClusterId = "\"" + serverRegistrationData.ClusterId.ToString() + "\"",
                ClusterName = serverRegistrationData.ClusterName,
                AgentVersion = serverRegistrationData.AgentVersion,
                ServerCertificate = "\"" + System.Convert.ToBase64String(serverRegistrationData.ServerCertificate)+ "\"",
                ServerOSVersion = serverRegistrationData.ServerOSVersion,
                ServerRole = serverRegistrationData.ServerRole.ToString(),
                FriendlyName = SystemUtility.GetMachineName(),
                LastHeartBeat = "\"" + DateTime.Now.ToString() + "\"",
            };

            return RemoveDoubleQuotes(StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.Create(
                resourceGroupName,
                storageSyncServiceName,
                serverRegistrationData.ServerId.ToString(),
                createParameters));
        }

        private RegisteredServer RemoveDoubleQuotes(RegisteredServer registeredServer)
        {
            registeredServer.ClusterId = registeredServer.ClusterId.Trim(new char[] { '\"' });
            registeredServer.StorageSyncServiceUid = registeredServer.StorageSyncServiceUid.Trim(new char[] { '\"' });
            registeredServer.ServerId = registeredServer.ServerId.Trim(new char[] { '\"' });
            registeredServer.DiscoveryEndpointUri = registeredServer.DiscoveryEndpointUri.Trim(new char[] { '\"' });
            registeredServer.ManagementEndpointUri = registeredServer.ManagementEndpointUri.Trim(new char[] { '\"' });
            registeredServer.LastHeartBeat = registeredServer.LastHeartBeat.Trim(new char[] { '\"' });

            return registeredServer;
        }
    }
}
