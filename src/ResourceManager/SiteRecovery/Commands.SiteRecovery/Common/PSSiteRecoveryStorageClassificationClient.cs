using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets all storage classifications associated with a vault.
        /// </summary>
        /// <param name="callback">Callback to execute on the result.</param>
        /// <returns>Task object tracking async operation.</returns>
        public Task EnumerateStorageClassificationsAsync(Action<IEnumerable<StorageClassification>> callback)
        {
            CancellationToken cancellationToken = new CancellationToken();

            Task backgroundTask = new Task(new Action(() =>
                {
                    Task<StorageClassificationListResponse> storageTask =
                        this.GetSiteRecoveryClient().StorageClassification.ListAllAsync(
                        this.GetRequestHeaders(),
                        cancellationToken);

                    Task.WaitAll(storageTask);

                    callback(storageTask.Result.StorageClassifications);

                    while (!string.IsNullOrEmpty(storageTask.Result.NextLink))
                    {
                        storageTask =
                            this.GetSiteRecoveryClient().StorageClassification.ListNextAsync(
                            storageTask.Result.NextLink,
                            this.GetRequestHeaders(),
                            cancellationToken);

                        Task.WaitAll(storageTask);

                        callback(storageTask.Result.StorageClassifications);
                    }
                }));

            backgroundTask.Start();
            return backgroundTask;
        }

        /// <summary>
        /// Gets all storage classifications associated with a vault.
        /// </summary>
        /// <param name="callback">Callback to execute on the result.</param>
        /// <returns>Task object tracking async operation.</returns>
        public Task EnumerateStorageClassificationMappingsAsync(Action<IEnumerable<StorageClassificationMapping>> callback)
        {
            CancellationToken cancellationToken = new CancellationToken();

            Task backgroundTask = new Task(new Action(() =>
            {
                Task<StorageClassificationMappingListResponse> storageTask =
                    this.GetSiteRecoveryClient().StorageClassificationMapping.ListAllAsync(
                    this.GetRequestHeaders(),
                    cancellationToken);

                Task.WaitAll(storageTask);

                callback(storageTask.Result.StorageClassificationMappings);

                while (!string.IsNullOrEmpty(storageTask.Result.NextLink))
                {
                    storageTask =
                        this.GetSiteRecoveryClient().StorageClassificationMapping.ListNextAsync(
                        storageTask.Result.NextLink,
                        this.GetRequestHeaders(),
                        cancellationToken);

                    Task.WaitAll(storageTask);

                    callback(storageTask.Result.StorageClassificationMappings);
                }
            }));

            backgroundTask.Start();
            return backgroundTask;
        }

        /// <summary>
        /// Starts job for unmapping classifications
        /// </summary>
        /// <param name="fabricName">Fabric name name.</param>
        /// <param name="storageClassificationName">Storage classification name.</param>
        /// <param name="mappingName">Classification mapping name.</param>
        /// <returns>Operation result.</returns>
        public LongRunningOperationResponse UnmapStorageClassifications(
            string fabricName,
            string storageClassificationName,
            string mappingName)
        {
            return this.GetSiteRecoveryClient().StorageClassificationMapping
                .BeginUnpairStorageClassification(
                fabricName,
                storageClassificationName,
                mappingName,
                customRequestHeaders: this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts job for mapping storage classification.
        /// </summary>
        /// <param name="primaryClassification">Primary classification.</param>
        /// <param name="input">Mapping input.</param>
        /// <param name="armName">Optional. ARM name of the mapping.</param>
        /// <returns>Operation response.</returns>
        public LongRunningOperationResponse MapStorageClassification(
            ASRStorageClassification primaryClassification,
            StorageClassificationMappingInput input,
            string armName)
        {
            string[] tokens = primaryClassification.Id.UnFormatArmId(
                ARMResourceIdPaths.StorageClassificationResourceIdPath);

            return this.GetSiteRecoveryClient().StorageClassificationMapping
                .BeginPairStorageClassification(
                tokens[0],
                tokens[1],
                armName,
                input,
                this.GetRequestHeaders());
        }
    }

    /// <summary>
    /// Extension methods for Storage classification.
    /// </summary>
    public static class StorageClassificationExtensions
    {
        /// <summary>
        /// Gets primary storage classification ARM Id.
        /// </summary>
        /// <param name="mapping">Storage classification mapping input.</param>
        /// <returns>ARM Id of the primary storage classification.</returns>
        public static string GetPrimaryStorageClassificationId(
            this StorageClassificationMapping mapping)
        {
            string[] tokens = mapping.Id.UnFormatArmId(
                ARMResourceIdPaths.StorageClassificationMappingResourceIdPath);

            string vaultId = mapping.Id.GetVaultArmId();

            return vaultId + "/" + string.Format(
                ARMResourceIdPaths.StorageClassificationResourceIdPath,
                tokens[0],
                tokens[1]);
        }

        /// <summary>
        /// Gets fabric Id from classification ARM Id.
        /// </summary>
        /// <param name="classification">Storage classification.</param>
        /// <returns>ARM Id of the fabric.</returns>
        public static string GetFabricId(
            this StorageClassification classification)
        {
            string[] tokens = classification.Id.UnFormatArmId(
                ARMResourceIdPaths.StorageClassificationResourceIdPath);

            string vaultId = classification.Id.GetVaultArmId();

            return vaultId + "/" + string.Format(
                ARMResourceIdPaths.FabricResourceIdPath,
                tokens[0]);
        }
    }
}
