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
    /// Class CloudEndpointChangeEnumerationStatusConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpoint, Microsoft.Azure.Management.StorageSync.Models.CloudEndpoint}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpoint, Microsoft.Azure.Management.StorageSync.Models.CloudEndpoint}" />
    public class CloudEndpointChangeEnumerationStatusConverter : ConverterBase<PSCloudEndpointChangeEnumerationStatus, StorageSyncModels.CloudEndpointChangeEnumerationStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.CloudEndpointChangeEnumerationStatus.</returns>
        protected override StorageSyncModels.CloudEndpointChangeEnumerationStatus Transform(PSCloudEndpointChangeEnumerationStatus source)
        {
            // Change enumeration status properties are read-only from the RP
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSCloudEndpointChangeEnumerationStatus.</returns>
        protected override PSCloudEndpointChangeEnumerationStatus Transform(StorageSyncModels.CloudEndpointChangeEnumerationStatus source)
        {
            PSCloudEndpointLastChangeEnumerationStatus lastEnumerationStatus = source.LastEnumerationStatus != null ? new CloudEndpointLastChangeEnumerationStatusConverter().Convert(source.LastEnumerationStatus) : null;
            PSCloudEndpointChangeEnumerationActivity changeEnumerationActivity = source.Activity != null ? new CloudEndpointChangeEnumerationActivityConverter().Convert(source.Activity) : null;

            return new PSCloudEndpointChangeEnumerationStatus()
            {
                LastUpdatedTimestamp = source.LastUpdatedTimestamp,
                LastEnumerationStatus = lastEnumerationStatus,
                Activity = changeEnumerationActivity
            };
        }
    }
}
