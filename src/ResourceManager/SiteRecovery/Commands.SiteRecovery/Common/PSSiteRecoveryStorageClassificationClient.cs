using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;

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
        /// Starts job for unmapping storage classifications.
        /// </summary>
        /// <param name="mapping">Classification mapping.</param>
        /// <returns>Job object.</returns>
        public ASRJob UnmapStorageClassifications(StorageClassificationMapping mapping)
        {
            string[] tokens = mapping.Id.UnFormatArmId(
                ARMResourceIdPaths.StorageClassificationMappingResourceIdPath);
            LongRunningOperationResponse operationResponse =
                this.GetSiteRecoveryClient().StorageClassificationMapping
                .BeginUnpairStorageClassification(
                tokens[0],
                tokens[1],
                tokens[2],
                this.GetRequestHeaders());

            JobResponse jobResponse =
                this.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(operationResponse.Location));

            return new ASRJob(jobResponse.Job);
        }

        /// <summary>
        /// Starts job for mapping storage classification.
        /// </summary>
        /// <param name="primaryClassification">Primary classification.</param>
        /// <param name="recoveryClassification">Recovery classification.</param>
        /// <param name="armName">Optional. ARM name of the mapping.</param>
        /// <returns>Job object.</returns>
        public ASRJob MapStorageClassification(
            ASRStorageClassification primaryClassification,
            ASRStorageClassification recoveryClassification,
            string armName = null)
        {
            string[] tokens = primaryClassification.StorageClassificationId.UnFormatArmId(
                ARMResourceIdPaths.StorageClassificationResourceIdPath);

            if (string.IsNullOrEmpty(armName))
            {
                armName = string.Format(
                    "StrgMap_{0}_{1}",
                    primaryClassification.StorageClassificationFriendlyName,
                    recoveryClassification.StorageClassificationFriendlyName);
            }

            var props = new StorageClassificationMappingInputProperties()
            {
                TargetStorageClassificationId = recoveryClassification.StorageClassificationId
            };

            var input = new StorageClassificationMappingInput()
            {
                Properties = props
            };

            LongRunningOperationResponse operationResponse =
                this.GetSiteRecoveryClient().StorageClassificationMapping
                .BeginPairStorageClassification(
                tokens[0],
                tokens[1],
                armName,
                input,
                this.GetRequestHeaders());

            JobResponse jobResponse =
                this.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(operationResponse.Location));

            return new ASRJob(jobResponse.Job);
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

        /// <summary>
        /// Gets powershell object from Storage classification object.
        /// </summary>
        /// <param name="classification">Classification to process.</param>
        /// <param name="classificationMap">Dictionary of all possible classifications.</param>
        /// <param name="fabricMap">Dictionary of list of fabrics.</param>
        /// <param name="mappingsDict">Dictionary of mapping objects.</param>
        /// <returns>Powershell representation of storage classification.</returns>
        public static ASRStorageClassification GetPSObject(
            this StorageClassification classification,
            Dictionary<string, StorageClassification> classificationMap,
            Dictionary<string, Fabric> fabricMap,
            Dictionary<string, List<StorageClassificationMapping>> mappingsDict)
        {
            var fabric = fabricMap[classification.GetFabricId()];
            List<StorageClassificationMapping> targetClassifications;

            return new ASRStorageClassification()
            {
                FabricFriendlyName = fabric.Properties.FriendlyName,
                FabricId = fabric.Id,
                StorageClassificationFriendlyName =
                    classification.Properties.FriendlyName,
                StorageClassificationId = classification.Id,
                TargetClassifications = 
                    mappingsDict.TryGetValue(
                        classification.Id, 
                        out targetClassifications) ?
                    targetClassifications.ConvertAll(item => 
                        classificationMap[item.Properties.TargetStorageClassificationId]
                        .GetPSObject(
                        classificationMap,
                        fabricMap,
                        mappingsDict)) :
                    new List<ASRStorageClassification>()
            };
        }
    }
}
