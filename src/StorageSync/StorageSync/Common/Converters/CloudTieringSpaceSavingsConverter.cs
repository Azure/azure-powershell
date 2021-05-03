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
    /// Class CloudTieringSpaceSavingsConverter.
    /// Implements the <see cref="Converters.ConverterBase{PSCloudTieringSpaceSavings, StorageSyncModels.CloudTieringSpaceSavings}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSCloudTieringSpaceSavings, StorageSyncModels.CloudTieringSpaceSavings}" />
    public class CloudTieringSpaceSavingsConverter : ConverterBase<PSCloudTieringSpaceSavings, StorageSyncModels.CloudTieringSpaceSavings>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.CloudTieringSpaceSavings.</returns>
        protected override StorageSyncModels.CloudTieringSpaceSavings Transform(PSCloudTieringSpaceSavings source)
        {
            // Cloud tiering status properties are readonly from the RP
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSCloudTieringSpaceSavings.</returns>
        protected override PSCloudTieringSpaceSavings Transform(StorageSyncModels.CloudTieringSpaceSavings source)
        {
            return new PSCloudTieringSpaceSavings()
            {
                LastUpdatedTimestamp = source.LastUpdatedTimestamp,
                CachedSizeBytes = source.CachedSizeBytes,
                SpaceSavingsBytes = source.SpaceSavingsBytes,
                SpaceSavingsPercent = source.SpaceSavingsPercent,
                TotalSizeCloudBytes = source.TotalSizeCloudBytes,
                VolumeSizeBytes = source.VolumeSizeBytes
            };
        }
    }
}
