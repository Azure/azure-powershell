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

using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Exceptions;
using Commands.StorageSync.Interop.Interfaces;
using Commands.StorageSync.Interop.Enums;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Commands.StorageSync.Properties;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;
using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{
    [Cmdlet(VerbsCommunications.Connect, StorageSyncNouns.NounStorageSyncServer, SupportsShouldProcess = true)]
    [OutputType(typeof(PSRegisteredServer))]
    public class ConnectServerCommand : StorageSyncClientCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string StorageSyncServiceName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessages.RegisteredServerNameParameter)]
        [ValidateNotNullOrEmpty]
        public Guid ServerId { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The application ID of the server system-assigned managed identity.")]
        [ValidateNotNullOrEmpty]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The Storage Sync Service UID returned by Azure.")]
        [ValidateNotNullOrEmpty]
        public Guid StorageSyncServiceUid { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The management endpoint URI returned by Azure.")]
        [ValidateNotNullOrEmpty]
        public Uri ManagementEndpointUri { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The discovery endpoint URI returned by Azure.")]
        [ValidateNotNullOrEmpty]
        public Uri DiscoveryEndpointUri { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The service location returned by Azure.")]
        [ValidateNotNullOrEmpty]
        public string ServiceLocation { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The resource location returned by Azure.")]
        [ValidateNotNullOrEmpty]
        public string ResourceLocation { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The monitoring endpoint URI returned by Azure.")]
        public Uri MonitoringEndpointUri { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The monitoring configuration returned by Azure.")]
        public string MonitoringConfiguration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJobParameter)]
        public SwitchParameter AsJob { get; set; }

        protected override string Target => string.Join("/", ResourceGroupName, StorageSyncServiceName, ServerId);

        protected override string ActionMessage => $"Connect the local server to {Target}";

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (string.IsNullOrEmpty(StorageSyncClientWrapper.AfsAgentInstallerPath))
                {
                    throw new PSArgumentException(StorageSyncResources.MissingAfsAgentInstallerPathErrorMessage);
                }

                if (string.IsNullOrEmpty(AzureContext?.Tenant?.Id))
                {
                    throw new PSArgumentException(StorageSyncResources.MissingAzureContextTenantId);
                }

                if (ShouldProcess(Target, ActionMessage))
                {
                    try
                    {
                        using (ISyncServerRegistration registrationClient =
                            StorageSyncClientWrapper.StorageSyncResourceManager.CreateSyncServerManagement())
                        {
                            var registeredServer = new StorageSyncModels.RegisteredServer(
                                serverId: ServerId.ToString(),
                                storageSyncServiceUid: StorageSyncServiceUid.ToString(),
                                discoveryEndpointUri: DiscoveryEndpointUri.AbsoluteUri,
                                resourceLocation: ResourceLocation,
                                serviceLocation: ServiceLocation,
                                managementEndpointUri: ManagementEndpointUri.AbsoluteUri,
                                monitoringEndpointUri: MonitoringEndpointUri?.AbsoluteUri,
                                monitoringConfiguration: MonitoringConfiguration,
                                applicationId: ApplicationId.ToString(),
                                identity: true);

                            StorageSyncModels.RegisteredServer resource = registrationClient.Connect(
                                AzureContext.Tenant.Id,
                                ManagementEndpointUri,
                                SubscriptionId,
                                StorageSyncServiceName,
                                ResourceGroupName,
                                ManagementInteropConstants.CertificateProviderName,
                                ManagementInteropConstants.CertificateHashAlgorithm,
                                ManagementInteropConstants.CertificateKeyLength,
                                Path.Combine(StorageSyncClientWrapper.AfsAgentInstallerPath, StorageSyncConstants.MonitoringAgentDirectoryName),
                                StorageSyncClientWrapper.AfsAgentVersion,
                                Environment.MachineName,
                                registeredServer);

                            WriteObject(resource);
                        }
                    }
                    catch (ServerRegistrationException ex)
                    {
                        StorageSyncClientWrapper.VerboseLogger.Invoke(
                            $"Connection failed with Category: {ex.Category}, ErrorCode: {ex.ExternalErrorCode}");
                        StorageSyncClientWrapper.VerboseLogger.Invoke($"Exception details: {ex}");
                        throw;
                    }
                }
            });
        }
    }
}
