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

using Microsoft.Azure.Commands.StorageSync.Models;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    /// <summary>
    /// Class ServerEndpointHealthConvertor.
    /// Implements the <see cref="Converters.ConverterBase{PSServerEndpointSyncStatus, StorageSyncModels.ServerEndpointHealth}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSServerEndpointSyncStatus, StorageSyncModels.ServerEndpointHealth}" />
    public class ServerEndpointHealthConverter : ConverterBase<PSServerEndpointHealth, StorageSyncModels.ServerEndpointSyncStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointHealth.</returns>
        protected override StorageSyncModels.ServerEndpointSyncStatus Transform(PSServerEndpointHealth source) => new StorageSyncModels.ServerEndpointSyncStatus(
            source.DownloadHealth,
            source.UploadHealth,
            source.CombinedHealth,
            source.SyncActivity,
            null /*TotalPersistentFilesNotSyncingCount currently not supported in PS*/,
            source.LastUpdatedTimestamp,
            new SyncSessionStatusConvertor().Convert(source.UploadStatus),
            new SyncSessionStatusConvertor().Convert(source.DownloadStatus),
            new SyncActivityStatusConverter().Convert(source.UploadActivity),
            new SyncActivityStatusConverter().Convert(source.DownloadActivity),
            source.OfflineDataTransferStatus);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSServerEndpointHealth.</returns>
        protected override PSServerEndpointHealth Transform(StorageSyncModels.ServerEndpointSyncStatus source)
        {
            return new PSServerEndpointHealth()
            {
                DownloadHealth = source.DownloadHealth,
                UploadHealth = source.UploadHealth,
                CombinedHealth = source.CombinedHealth,
                SyncActivity = source.SyncActivity,
                LastUpdatedTimestamp = source.LastUpdatedTimestamp,
                UploadStatus = new SyncSessionStatusConvertor().Convert(source.UploadStatus),
                DownloadStatus = new SyncSessionStatusConvertor().Convert(source.DownloadStatus),
                UploadActivity = new SyncActivityStatusConverter().Convert(source.UploadActivity),
                DownloadActivity = new SyncActivityStatusConverter().Convert(source.DownloadActivity),
                OfflineDataTransferStatus = source.OfflineDataTransferStatus
            };
        }
    }
}