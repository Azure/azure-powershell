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
        /// <returns>StorageSyncModels.CloudEndpoint.</returns>
        protected override StorageSyncModels.CloudEndpointChangeEnumerationActivity Transform(PSCloudEndpointChangeEnumerationActivity source)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSCloudEndpoint.</returns>
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
