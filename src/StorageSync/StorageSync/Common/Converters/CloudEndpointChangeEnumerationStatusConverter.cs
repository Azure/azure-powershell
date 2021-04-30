namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    using Microsoft.Azure.Commands.StorageSync.Models;
    using System;
    using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

    /// <summary>
    /// Class CloudEndpointConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpoint, Microsoft.Azure.Management.StorageSync.Models.CloudEndpoint}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpoint, Microsoft.Azure.Management.StorageSync.Models.CloudEndpoint}" />
    public class CloudEndpointChangeEnumerationStatusConverter : ConverterBase<PSCloudEndpointChangeEnumerationStatus, StorageSyncModels.CloudEndpointChangeEnumerationStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.CloudEndpoint.</returns>
        protected override StorageSyncModels.CloudEndpointChangeEnumerationStatus Transform(PSCloudEndpointChangeEnumerationStatus source)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSCloudEndpoint.</returns>
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
