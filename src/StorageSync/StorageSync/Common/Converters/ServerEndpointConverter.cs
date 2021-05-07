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
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    /// <summary>
    /// Class ServerEndpointConverter.
    /// Implements the <see cref="Converters.ConverterBase{PSServerEndpoint, StorageSyncModels.ServerEndpoint}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSServerEndpoint, StorageSyncModels.ServerEndpoint}" />
    public class ServerEndpointConverter : ConverterBase<PSServerEndpoint, StorageSyncModels.ServerEndpoint>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpoint.</returns>
        protected override StorageSyncModels.ServerEndpoint Transform(PSServerEndpoint source)
        {
            return new StorageSyncModels.ServerEndpoint(
                id: source.ResourceId,
                name: source.ServerEndpointName,
                type: source.Type,
                serverLocalPath: source.ServerLocalPath,
                cloudTiering: source.CloudTiering,
                volumeFreeSpacePercent: source.VolumeFreeSpacePercent,
                tierFilesOlderThanDays: source.TierFilesOlderThanDays,
                friendlyName: source.FriendlyName,
                serverResourceId: source.ServerResourceId,
                initialDownloadPolicy: source.InitialDownloadPolicy,
                localCacheMode: source.LocalCacheMode,
                initialUploadPolicy: source.InitialUploadPolicy);
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSServerEndpoint.</returns>
        protected override PSServerEndpoint Transform(StorageSyncModels.ServerEndpoint source)
        {
            PSServerEndpointSyncStatus syncStatus = source.SyncStatus != null ? new ServerEndpointHealthConverter().Convert(source.SyncStatus) : null;
            PSServerEndpointCloudTieringStatus cloudTieringStatus = source.CloudTieringStatus != null ? new ServerEndpointCloudTieringStatusConverter().Convert(source.CloudTieringStatus) : null;
            PSServerEndpointRecallStatus recallStatus = source.RecallStatus != null ? new ServerEndpointRecallStatusConverter().Convert(source.RecallStatus) : null;

            var resourceIdentifier = new ResourceIdentifier(source.Id);
            return new PSServerEndpoint()
            {
                ResourceId = source.Id,
                SyncGroupName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.SyncGroupTypeName, 0),
                StorageSyncServiceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 1),
                ServerEndpointName = source.Name,
                ResourceGroupName = resourceIdentifier.ResourceGroupName,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.ServerEndpointType,
                ServerLocalPath = source.ServerLocalPath,
                ServerResourceId = source.ServerResourceId,
                ProvisioningState = source.ProvisioningState,
                SyncStatus = syncStatus,
                FriendlyName = source.FriendlyName,
                LastOperationName = source.LastOperationName,
                LastWorkflowId = source.LastWorkflowId,
                CloudTiering = source.CloudTiering,
                VolumeFreeSpacePercent = source.VolumeFreeSpacePercent,
                TierFilesOlderThanDays = source.TierFilesOlderThanDays,
                InitialDownloadPolicy = source.InitialDownloadPolicy,
                LocalCacheMode = source.LocalCacheMode,
                InitialUploadPolicy = source.InitialUploadPolicy,
                CloudTieringStatus = cloudTieringStatus,
                RecallStatus = recallStatus,
                ServerName = source.ServerName
            };
        }
    }
}