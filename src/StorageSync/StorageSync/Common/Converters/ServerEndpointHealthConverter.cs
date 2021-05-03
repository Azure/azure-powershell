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
using System;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    /// <summary>
    /// Class ServerEndpointHealthConvertor.
    /// Implements the <see cref="Converters.ConverterBase{PSServerEndpointSyncStatus, StorageSyncModels.ServerEndpointHealth}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSServerEndpointSyncStatus, StorageSyncModels.ServerEndpointHealth}" />
    public class ServerEndpointHealthConverter : ConverterBase<PSServerEndpointSyncStatus, StorageSyncModels.ServerEndpointSyncStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointSyncStatus.</returns>
        protected override StorageSyncModels.ServerEndpointSyncStatus Transform(PSServerEndpointSyncStatus source)
        {
            // Sync status properties are read-only from the RP
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSServerEndpointSyncStatus.</returns>
        protected override PSServerEndpointSyncStatus Transform(StorageSyncModels.ServerEndpointSyncStatus source)
        {
            PSSyncSessionStatus uploadStatus = source.UploadStatus != null ? new SyncSessionStatusConvertor().Convert(source.UploadStatus) : null;
            PSSyncSessionStatus downloadStatus = source.DownloadStatus != null ? new SyncSessionStatusConvertor().Convert(source.DownloadStatus) : null;
            PSSyncActivityStatus uploadActivity = source.UploadActivity != null ? new SyncActivityStatusConverter().Convert(source.UploadActivity) : null;
            PSSyncActivityStatus downloadActivity = source.DownloadActivity != null ? new SyncActivityStatusConverter().Convert(source.DownloadActivity) : null;
            PSBackgroundDataDownloadActivity backgroundDataDownloadActivity = source.BackgroundDataDownloadActivity != null ? new BackgroundDataDownloadActivityConverter().Convert(source.BackgroundDataDownloadActivity) : null;

            return new PSServerEndpointSyncStatus()
            {
                DownloadHealth = source.DownloadHealth,
                UploadHealth = source.UploadHealth,
                CombinedHealth = source.CombinedHealth,
                SyncActivity = source.SyncActivity,
                TotalPersistentFilesNotSyncingCount = source.TotalPersistentFilesNotSyncingCount,
                LastUpdatedTimestamp = source.LastUpdatedTimestamp,
                UploadStatus = uploadStatus,
                DownloadStatus = downloadStatus,
                UploadActivity = uploadActivity,
                DownloadActivity = downloadActivity,
                OfflineDataTransferStatus = source.OfflineDataTransferStatus,
                BackgroundDataDownloadActivity = backgroundDataDownloadActivity
            };
        }
    }
}