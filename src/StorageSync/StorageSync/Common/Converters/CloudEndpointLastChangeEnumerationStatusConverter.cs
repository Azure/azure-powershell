namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    using Microsoft.Azure.Commands.StorageSync.Models;
    using System;
    using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

    /// <summary>
    /// Class CloudEndpointLastChangeEnumerationStatusConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpointLastChangeEnumerationStatus, Microsoft.Azure.Management.StorageSync.Models.CloudEndpointLastChangeEnumerationStatus}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpointLastChangeEnumerationStatus, Microsoft.Azure.Management.StorageSync.Models.CloudEndpointLastChangeEnumerationStatus}" />
    public class CloudEndpointLastChangeEnumerationStatusConverter : ConverterBase<PSCloudEndpointLastChangeEnumerationStatus, StorageSyncModels.CloudEndpointLastChangeEnumerationStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.CloudEndpoint.</returns>
        protected override StorageSyncModels.CloudEndpointLastChangeEnumerationStatus Transform(PSCloudEndpointLastChangeEnumerationStatus source)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSCloudEndpoint.</returns>
        protected override PSCloudEndpointLastChangeEnumerationStatus Transform(StorageSyncModels.CloudEndpointLastChangeEnumerationStatus source)
        {
            return new PSCloudEndpointLastChangeEnumerationStatus
            {
                StartedTimestamp = source.StartedTimestamp,
                CompletedTimestamp = source.CompletedTimestamp,
                NamespaceFilesCount = source.NamespaceFilesCount,
                NamespaceDirectoriesCount = source.NamespaceDirectoriesCount,
                NamespaceSizeBytes = source.NamespaceSizeBytes,
                NextRunTimestamp = source.NextRunTimestamp
            };
        }
    }
}
