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

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    using Microsoft.Azure.Commands.StorageSync.Models;
    using System;
    using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

    /// <summary>
    /// Class ServerEndpointCloudTieringStatusConverter.
    /// Implements the <see cref="Converters.ConverterBase{PSServerEndpointCloudTieringStatus, StorageSyncModels.ServerEndpointCloudTieringStatus}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSServerEndpointCloudTieringStatus, StorageSyncModels.ServerEndpointHealth}" />
    public class ServerEndpointCloudTieringStatusConverter : ConverterBase<PSServerEndpointCloudTieringStatus, StorageSyncModels.ServerEndpointCloudTieringStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointCloudTieringStatus.</returns>
        protected override StorageSyncModels.ServerEndpointCloudTieringStatus Transform(PSServerEndpointCloudTieringStatus source)
        {
            // Cloud tiering status properties are readonly from the RP
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSServerEndpointCloudTieringStatus.</returns>
        protected override PSServerEndpointCloudTieringStatus Transform(StorageSyncModels.ServerEndpointCloudTieringStatus source)
        {
            PSCloudTieringSpaceSavings spaceSavings = source.SpaceSavings != null ? new CloudTieringSpaceSavingsConverter().Convert(source.SpaceSavings) : null;
            PSCloudTieringCachePerformance cachePerformance = source.CachePerformance != null ? new CloudTieringCachePerformanceConverter().Convert(source.CachePerformance) : null;
            PSCloudTieringFilesNotTiering filesNotTiering = source.FilesNotTiering != null ? new CloudTieringFilesNotTieringConverter().Convert(source.FilesNotTiering) : null;
            PSCloudTieringVolumeFreeSpacePolicyStatus volumeFreeSpacePolicyStatus = source.VolumeFreeSpacePolicyStatus != null ? new CloudTieringVolumeFreeSpacePolicyStatusConverter().Convert(source.VolumeFreeSpacePolicyStatus) : null;

            return new PSServerEndpointCloudTieringStatus()
            {
                LastUpdatedTimestamp = source.LastUpdatedTimestamp,
                Health = source.Health,
                HealthLastUpdatedTimestamp = source.HealthLastUpdatedTimestamp,
                LastCloudTieringResult = source.LastCloudTieringResult,
                LastSuccessTimestamp = source.LastSuccessTimestamp,
                SpaceSavings = spaceSavings,
                CachePerformance = cachePerformance,
                FilesNotTiering = filesNotTiering,
                VolumeFreeSpacePolicyStatus = volumeFreeSpacePolicyStatus
            };
        }
    }
}
