﻿// ----------------------------------------------------------------------------------
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
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    /// <summary>
    /// Class CloudEndpointConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpoint, Microsoft.Azure.Management.StorageSync.Models.CloudEndpoint}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpoint, Microsoft.Azure.Management.StorageSync.Models.CloudEndpoint}" />
    public class CloudEndpointConverter : ConverterBase<PSCloudEndpoint, StorageSyncModels.CloudEndpoint>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudEndpointConverter" /> class.
        /// </summary>
        public CloudEndpointConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.CloudEndpoint.</returns>
        protected override StorageSyncModels.CloudEndpoint Transform(PSCloudEndpoint source) => new StorageSyncModels.CloudEndpoint(source.ResourceId, source.CloudEndpointName, source.Type, source.StorageAccountResourceId, source.AzureFileShareName, source.StorageAccountTenantId, friendlyName: source.FriendlyName);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSCloudEndpoint.</returns>
        protected override PSCloudEndpoint Transform(StorageSyncModels.CloudEndpoint source)
        {
            var resourceIdentifier = new ResourceIdentifier(source.Id);
            return new PSCloudEndpoint()
            {
                ResourceId = source.Id,
                CloudEndpointName = source.Name,
                SyncGroupName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.SyncGroupTypeName, 0),
                StorageSyncServiceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 1),
                ResourceGroupName = resourceIdentifier.ResourceGroupName,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.CloudEndpointType,
                FriendlyName = source.FriendlyName,
                StorageAccountResourceId = source.StorageAccountResourceId,
                AzureFileShareName = source.StorageAccountShareName,
                StorageAccountTenantId = source.StorageAccountTenantId?.Trim('"'),
                BackupEnabled = System.Convert.ToBoolean(source.BackupEnabled),
                LastWorkflowId = source.LastWorkflowId,
                LastOperationName = source.LastOperationName,
                PartnershipId = source.PartnershipId,
                ProvisioningState = source.ProvisioningState,
            };
        }
    }
}