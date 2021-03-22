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

using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{

    /// <summary>
    /// Class RegisteredServerConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSRegisteredServer, Microsoft.Azure.Management.StorageSync.Models.RegisteredServer}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSRegisteredServer, Microsoft.Azure.Management.StorageSync.Models.RegisteredServer}" />
    public class RegisteredServerConverter : ConverterBase<PSRegisteredServer, StorageSyncModels.RegisteredServer>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisteredServerConverter" /> class.
        /// </summary>
        public RegisteredServerConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.RegisteredServer.</returns>
        protected override StorageSyncModels.RegisteredServer Transform(PSRegisteredServer source)
        {
            return new StorageSyncModels.RegisteredServer(
                source.ResourceId,
                source.ServerName,
                StorageSyncConstants.RegisteredServerType,
                source.ServerCertificate,
                source.AgentVersion,
                source.AgentVersionStatus,
                source.AgentVersionExpirationDate,
                source.ServerOSVersion,
                source.ServerManagementErrorCode,
                null,
                source.ProvisioningState,
                source.ServerRole,
                source.ClusterId,
                source.ClusterName,
                source.ServerId,
                source.StorageSyncServiceUid,
                source.LastWorkflowId,
                source.LastOperationName,
                source.DiscoveryEndpointUri,
                source.ResourceLocation,
                source.ServiceLocation,
                source.FriendlyName,
                source.ManagementEndpointUri,
                source.MonitoringEndpointUri,
                source.MonitoringConfiguration);
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSRegisteredServer.</returns>
        protected override PSRegisteredServer Transform(StorageSyncModels.RegisteredServer source)
        {
            var resourceIdentifier = new ResourceIdentifier(source.Id);
            return new PSRegisteredServer()
            {
                ResourceId = source.Id,
                StorageSyncServiceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 0),
                ServerName = source.Name,
                ResourceGroupName = resourceIdentifier.ResourceGroupName,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.RegisteredServerType,
                AgentVersion = source.AgentVersion,
                ClusterId = source.ClusterId,
                ProvisioningState = source.ProvisioningState,
                ClusterName = source.ClusterName,
                DiscoveryEndpointUri = source.DiscoveryEndpointUri,
                FriendlyName = source.FriendlyName,
                LastHeartBeat = source.LastHeartBeat?.ToString(),
                LastOperationName = source.LastOperationName,
                LastWorkflowId = source.LastWorkflowId,
                ManagementEndpointUri = source.ManagementEndpointUri,
                MonitoringEndpointUri = source.MonitoringEndpointUri,
                ResourceLocation = source.ResourceLocation,
                ServerCertificate = source.ServerCertificate,
                ServerId = source.ServerId,
                ServerManagementErrorCode = source.ServerManagementErrorCode,
                ServerOSVersion = source.ServerOSVersion,
                ServerRole = source.ServerRole,
                ServiceLocation = source.ServiceLocation,
                StorageSyncServiceUid = source.StorageSyncServiceUid,
                MonitoringConfiguration = source.MonitoringConfiguration
            };
        }
    }
}