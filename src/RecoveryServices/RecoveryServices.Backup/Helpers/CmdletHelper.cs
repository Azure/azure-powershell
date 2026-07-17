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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using SystemNet = System.Net;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{    
    public class CmdletHelper
    {

        // Helper method to determine if container unregistration is required for the workload type
        public static bool IsContainerUnregistrationRequired(CmdletModel.ContainerType containerType, CmdletModel.BackupManagementType backupManagementType)
        {
            return (containerType == CmdletModel.ContainerType.Windows && backupManagementType == CmdletModel.BackupManagementType.MAB) ||
                   (containerType == CmdletModel.ContainerType.AzureStorage && backupManagementType == CmdletModel.BackupManagementType.AzureStorage) ||
                   (containerType == CmdletModel.ContainerType.AzureVMAppContainer && backupManagementType == CmdletModel.BackupManagementType.AzureWorkload);
        }

        public static string GetContainerNameFromItem(ItemBase item)
        {
            // container name format for SQL and AFS
            // StorageContainer;Storage;rgname;afsname
            // VMAppContainer;Compute;RGName;vmanme
            return item.ContainerName;
        }

        public static JobBase UnregisterContainer(ItemBase item, string vaultName, string resourceGroupName, ServiceClientAdapter serviceClientAdapter, RSBackupVaultCmdletBase rsBackupVaultCmdletBase)
        {
            string containerName = GetContainerNameFromItem(item);
            
            Logger.Instance.WriteDebug("Unregistering Azure Storage container: " + containerName);
            try
            {
                if (item.ContainerType == CmdletModel.ContainerType.AzureVMAppContainer ||
                    item.ContainerType == CmdletModel.ContainerType.AzureStorage)
                {
                    var unRegisterResponse = serviceClientAdapter.UnregisterWorkloadContainers(
                        containerName,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);

                    JobBase jobObj = rsBackupVaultCmdletBase.HandleCreatedJob(
                            unRegisterResponse,
                            Resources.UnregisterContainer,
                            vaultName: vaultName,
                            resourceGroupName: resourceGroupName,
                            returnJobObject: true);

                    return jobObj;
                }

                return null;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteDebug($"Container unregistration failed: {ex.Message}");
                throw new InvalidOperationException($"Failed to unregister container '{containerName}': {ex.Message}", ex);
            }
        }

        public static JobBase WaitForJobCompletion(JobBase job, string vaultName, string resourceGroupName, RSBackupVaultCmdletBase rsBackupVaultCmdletBase)
        {
            JobBase currentJob = job;
            while (currentJob != null && BackupUtils.IsJobInProgress(currentJob))
            {
                // Sleep for 30 seconds between status checks
                string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
                if (string.Compare(testMode, "Record", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    System.Threading.Thread.Sleep(30000);
                }
                else
                {
                    TestMockSupport.Delay(30 * 1000);
                }

                // Refresh job status
                currentJob = rsBackupVaultCmdletBase.GetJobObject(currentJob.JobId, vaultName, resourceGroupName);
            }
            return currentJob;
        }

        public static JobBase EnsureJobCompletedOrThrow(JobBase job, string vaultName, string resourceGroupName, string operationContext, RSBackupVaultCmdletBase rsBackupVaultCmdletBase)
        {
            if (job != null)
            {
                var completedJob = WaitForJobCompletion(job, vaultName, resourceGroupName, rsBackupVaultCmdletBase);
                if (!string.Equals(completedJob.Status, "Completed", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(completedJob.Status, "Succeeded", StringComparison.OrdinalIgnoreCase))
                {
                    string message = "Cannot proceed with reconfiguring protection because the {0} job with ID: {1} did not complete successfully. Current job status: {2}.";
                    throw new InvalidOperationException(string.Format(message, operationContext, completedJob.JobId, completedJob.Status));
                }
                return completedJob;
            }
            return job;
        }

        /// <summary>
        /// Gets the protectable item that matches the original protected item
        /// </summary>
        public static ProtectableItemBase GetMatchingProtectableItem(ItemBase item, string targetVaultName, string targetResourceGroupName, ServiceClientAdapter serviceClientAdapter)
        {
            try
            {
                // Use the same pattern as GetAzureRMRecoveryServicesBackupProtectableItem
                string containerName = GetContainerNameFromItem(item);
                string workloadType = item.WorkloadType.ToString();

                string backupManagementType = item.BackupManagementType.ToString();
                workloadType = ConversionUtils.GetServiceClientWorkloadType(workloadType);

                ODataQuery<ServiceClientModel.BmspoQueryObject> queryParam = new ODataQuery<ServiceClientModel.BmspoQueryObject>(
                    q => q.BackupManagementType
                     == backupManagementType &&
                     q.WorkloadType == workloadType);

                Logger.Instance.WriteDebug("going to query service to get list of protectable items");
                List<ServiceClientModel.WorkloadProtectableItemResource> protectableItems =
                    serviceClientAdapter.ListProtectableItem(
                        queryParam,
                        vaultName: targetVaultName,
                        resourceGroupName: targetResourceGroupName);
                Logger.Instance.WriteDebug("Successfully got response from service");

                List<ProtectableItemBase> itemModels = ConversionHelpers.GetProtectableItemModelList(protectableItems);
                
                Logger.Instance.WriteDebug("itemName: " + item.Name + ", itemContainerName: " + item.ContainerName);

                if (!string.IsNullOrEmpty(item.Name))
                {
                    itemModels = itemModels.Where(itemModel =>
                    {
                        Logger.Instance.WriteDebug("proItemName: " + ((AzureWorkloadProtectableItem)itemModel).Name +
                            ", proItemContainerName: " + ((AzureWorkloadProtectableItem)itemModel).ContainerName);

                        return (string.Compare(((AzureWorkloadProtectableItem)itemModel).Name, item.Name, true) == 0
                        && string.Compare(((AzureWorkloadProtectableItem)itemModel).ContainerName, item.ContainerName, true) == 0);
                    }).ToList();
                }
                else
                {
                    Logger.Instance.WriteWarning("Failed to get protectable item since item Name is null");
                    return null;
                }

                if(itemModels != null && itemModels.Count > 0)
                {
                    return itemModels[0];
                }
                else
                {
                    Logger.Instance.WriteWarning($"Could not find matching protectable item for {item.Name}");
                    return null;
                }                    
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteWarning($"Failed to get protectable item: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Triggers inquiry and gets protectable item for SQL workloads
        /// </summary>
        public static ProtectableItemBase TriggerInquiryAndGetProtectableItem(ItemBase item, string targetVaultName, string targetResourceGroupName, ServiceClientAdapter serviceClientAdapter)
        {
            try
            {
                string containerName = CmdletHelper.GetContainerNameFromItem(item);
                string workloadType = ConversionUtils.GetServiceClientWorkloadType(item.WorkloadType.ToString());
                string backupManagementType = item.BackupManagementType.ToString();
                ODataQuery<ServiceClientModel.BMSContainersInquiryQueryObject> queryParams = new ODataQuery<ServiceClientModel.BMSContainersInquiryQueryObject>(
                    q => q.WorkloadType == workloadType && q.BackupManagementType == backupManagementType);
                string errorMessage = string.Empty;
                var inquiryResponse = serviceClientAdapter.InquireContainer(
                containerName,
                queryParams,
                targetVaultName,
                targetResourceGroupName);

                var operationStatus = TrackingHelpers.GetOperationResult(
               inquiryResponse,
               operationId =>
                   serviceClientAdapter.GetRegisterContainerOperationResult(
                       operationId,
                       item.ContainerName,
                       vaultName: targetVaultName,
                       resourceGroupName: targetResourceGroupName));

                if (inquiryResponse.Response.StatusCode
                       == SystemNet.HttpStatusCode.OK)
                {
                    Logger.Instance.WriteDebug(errorMessage);
                }

                //Now wait for the operation to Complete
                if (inquiryResponse.Response.StatusCode
                        != SystemNet.HttpStatusCode.NoContent)
                {
                    errorMessage = string.Format(Resources.TriggerEnquiryFailureErrorCode,
                        inquiryResponse.Response.StatusCode);
                    Logger.Instance.WriteDebug(errorMessage);
                }

                // Now get the protectable item that matches our original item
                return CmdletHelper.GetMatchingProtectableItem(item, targetVaultName, targetResourceGroupName, serviceClientAdapter);
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteDebug($"Inquiry operation failed: {ex.Message}");
                Logger.Instance.WriteWarning($"Failed to trigger inquiry for workload discovery: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Registers container in target vault using provider pattern (following RegisterAzureRmRecoveryServicesBackupContainer)
        /// </summary>
        public static void RegisterContainerInTargetVault(ItemBase item, string targetVaultName, string targetResourceGroupName, ServiceClientAdapter serviceClientAdapter)
        {
            try
            {
                Logger.Instance.WriteVerbose($"Registering container for item: {item.Name} in target vault: {targetVaultName}");

                string containerName = CmdletHelper.GetContainerNameFromItem(item);
                string vmResourceGroupParsed = targetResourceGroupName;
                if (!string.IsNullOrEmpty(item.SourceResourceId))
                {
                    Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.SourceResourceId);
                    vmResourceGroupParsed = HelperUtils.GetResourceGroupNameFromId(keyValueDict, item.SourceResourceId);
                }
                string storageAccountName = BackupUtils.GetStorageAccountNameFromContainerName(item.ContainerName);

                PsBackupProviderManager registerProviderManager =
                        new PsBackupProviderManager(new Dictionary<Enum, object>()
                        {
                            { VaultParams.VaultName, targetVaultName },
                            { VaultParams.ResourceGroupName, targetResourceGroupName },
                            { ContainerParams.Name, containerName },
                            { ContainerParams.ContainerType, ServiceClientHelpers.GetServiceClientWorkloadType(item.WorkloadType).ToString() },
                            { ContainerParams.BackupManagementType, item.BackupManagementType.ToString() },
                            { ContainerParams.Container, null },
                            { ContainerParams.ResourceGroupName, vmResourceGroupParsed },
                        }, serviceClientAdapter);

                IPsBackupProvider registerPsBackupProvider = registerProviderManager.GetProviderInstance(item.WorkloadType, item.BackupManagementType);
                registerPsBackupProvider.RegisterContainer();

                Logger.Instance.WriteVerbose($"Successfully registered container {containerName} in target vault");
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteDebug($"Container registration failed: {ex.Message}");
                throw new InvalidOperationException($"Failed to register container for '{item.Name}' in target vault: {ex.Message}", ex);
            }
        }
    }
}

