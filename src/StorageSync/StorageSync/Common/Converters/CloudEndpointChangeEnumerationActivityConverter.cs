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
    /// Class CloudEndpointChangeEnumerationActivityConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpointChangeEnumerationActivity, Microsoft.Azure.Management.StorageSync.Models.CloudEndpointChangeEnumerationActivity}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpointChangeEnumerationActivity, Microsoft.Azure.Management.StorageSync.Models.CloudEndpointChangeEnumerationActivity}" />
    public class CloudEndpointChangeEnumerationActivityConverter : ConverterBase<PSCloudEndpointChangeEnumerationActivity, StorageSyncModels.CloudEndpointChangeEnumerationActivity>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.CloudEndpointChangeEnumerationActivity.</returns>
        protected override StorageSyncModels.CloudEndpointChangeEnumerationActivity Transform(PSCloudEndpointChangeEnumerationActivity source)
        {
            // Change enumeration properties are read-only
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSCloudEndpointChangeEnumerationActivity.</returns>
        protected override PSCloudEndpointChangeEnumerationActivity Transform(StorageSyncModels.CloudEndpointChangeEnumerationActivity source)
        {
            return new PSCloudEndpointChangeEnumerationActivity
            {
                LastUpdatedTimestamp = source.LastUpdatedTimestamp,
                StartedTimestamp = source.StartedTimestamp,
                StatusCode = source.StatusCode,
                OperationState = source.OperationState,
                ProcessedFilesCount = source.ProcessedFilesCount,
                ProcessedDirectoriesCount = source.ProcessedDirectoriesCount,
                TotalCountsState = source.TotalCountsState,
                TotalFilesCount = source.TotalFilesCount,
                TotalDirectoriesCount = source.TotalDirectoriesCount,
                TotalSizeBytes = source.TotalSizeBytes,
                ProgressPercent = source.ProgressPercent,
                MinutesRemaining = source.MinutesRemaining,
                DeletesProgressPercent = source.DeletesProgressPercent
            };
        }
    }
}
