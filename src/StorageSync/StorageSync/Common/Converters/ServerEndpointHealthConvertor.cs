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
    /// Class ServerEndpointHealthConvertor.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSServerEndpointHealth, Microsoft.Azure.Management.StorageSync.Models.ServerEndpointHealth}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSServerEndpointHealth, Microsoft.Azure.Management.StorageSync.Models.ServerEndpointHealth}" />
    public class ServerEndpointHealthConvertor : ConverterBase<PSServerEndpointHealth, StorageSyncModels.ServerEndpointHealth>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointHealth.</returns>
        protected override StorageSyncModels.ServerEndpointHealth Transform(PSServerEndpointHealth source) => new StorageSyncModels.ServerEndpointHealth(
            source.DownloadHealth,
            source.UploadHealth,
            source.CombinedHealth,
            source.LastUpdatedTimestamp,
            new SyncSessionStatusConvertor().Convert(source.UploadStatus),
            new SyncSessionStatusConvertor().Convert(source.DownloadStatus),
            new SyncProgressStatusConvertor().Convert(source.CurrentProgress),
            source.OfflineDataTransferStatus);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSServerEndpointHealth.</returns>
        protected override PSServerEndpointHealth Transform(StorageSyncModels.ServerEndpointHealth source)
        {
            return new PSServerEndpointHealth()
            {
                DownloadHealth = source.DownloadHealth,
                UploadHealth = source.UploadHealth,
                CombinedHealth = source.CombinedHealth,
                LastUpdatedTimestamp = source.LastUpdatedTimestamp,
                UploadStatus = new SyncSessionStatusConvertor().Convert(source.UploadStatus),
                DownloadStatus = new SyncSessionStatusConvertor().Convert(source.DownloadStatus),
                CurrentProgress = new SyncProgressStatusConvertor().Convert(source.CurrentProgress),
                OfflineDataTransferStatus = source.OfflineDataTransferStatus
            };
        }
    }
}