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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Rest.Azure.OData;
using Newtonsoft.Json;
using RestAzureNS = Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        public List<string> ListVaults()
        {
            var response = RSAdapter.Client.Vaults.ListBySubscriptionIdWithHttpMessagesAsync(
                cancellationToken: RSAdapter.CmdletCancellationToken).Result;
            return response.Body.Select(vault => vault.Id).ToList();
        }

        public BackupResourceVaultConfigResource SetVaultProperty(string vaultName, string resourceGroupName,
            BackupResourceVaultConfigResource param)
        {
            return BmsAdapter.Client.BackupResourceVaultConfigs.UpdateWithHttpMessagesAsync(
                vaultName, resourceGroupName, param).Result.Body;
        }

        public BackupResourceVaultConfigResource GetVaultProperty(string vaultName, string resourceGroupName)
        {
            return BmsAdapter.Client.BackupResourceVaultConfigs.GetWithHttpMessagesAsync(
                vaultName, resourceGroupName).Result.Body;
        }

        /// <summary>  
        /// Method to Get Azure Recovery Services Vault Backup Properties  
        /// </summary>  
        /// <param name="resouceGroupName">Name of the resouce group</param>  
        /// <param name="vaultName">Name of the vault</param>  
        /// <returns>Azure Resource Storage response object.</returns>  
        public BackupResourceConfigResource GetVaultStorageType(string resouceGroupName, string vaultName)
        {
            return BmsAdapter.Client.BackupResourceStorageConfigsNonCRR.GetWithHttpMessagesAsync(
                vaultName, resouceGroupName).Result.Body;
        }

        /// <summary>  
        /// Method to Get Azure Recovery Services Vault Encryption Properties  
        /// </summary>  
        /// <param name="resouceGroupName">Name of the resouce group</param>  
        /// <param name="vaultName">Name of the vault</param>  
        /// <returns>Azure Resource Encryption response object.</returns>  
        public BackupResourceEncryptionConfigExtendedResource GetVaultEncryptionConfig(string resouceGroupName, string vaultName)
        {
            return BmsAdapter.Client.BackupResourceEncryptionConfigs.GetWithHttpMessagesAsync(
                vaultName, resouceGroupName).Result.Body;
        }

        /// <summary>  
        /// Method to Update Azure Recovery Services Vault Encryption Properties  
        /// </summary>  
        /// <param name="resouceGroupName">Name of the resouce group</param>  
        /// <param name="vaultName">Name of the vault</param>  
        /// <param name="encryptionConfigResource">update encryption config</param>  
        /// <returns>Azure Resource Encryption response object.</returns>  
        public RestAzureNS.AzureOperationResponse UpdateVaultEncryptionConfig(string resouceGroupName, string vaultName,
            BackupResourceEncryptionConfigResource encryptionConfigResource)
        {
            return BmsAdapter.Client.BackupResourceEncryptionConfigs.UpdateWithHttpMessagesAsync(
                vaultName, resouceGroupName, encryptionConfigResource).Result;
        }

        /// <summary>  
        /// Method to Update Azure Recovery Services Vault Encryption Properties  
        /// </summary>  
        /// <param name="resouceGroupName">Name of the resouce group</param>  
        /// <param name="vaultName">Name of the vault</param>  
        /// <param name="encryptionConfigResource">update encryption config</param>  
        /// <returns>Azure Resource Encryption response object.</returns>  
        public RestAzureNS.AzureOperationResponse UpdateVaultEncryption(string resouceGroupName, string vaultName,
            BackupResourceEncryptionConfigResource encryptionConfigResource)
        {
            return BmsAdapter.Client.BackupResourceEncryptionConfigs.UpdateWithHttpMessagesAsync(
                vaultName, resouceGroupName, encryptionConfigResource).Result;
        }

        /// <summary>  
        /// Method to get Recovery Services Vault.
        /// </summary>  
        /// <param name="resouceGroupName">Name of the resouce group</param>  
        /// <param name="vaultName">Name of the vault</param>  
        /// <returns>Azure Recovery Services Vault</returns> 
        public ARSVault GetVault(string resouceGroupName, string vaultName)
        {
            Vault response =  RSAdapter.Client.Vaults.GetWithHttpMessagesAsync(resouceGroupName, vaultName,
                cancellationToken: RSAdapter.CmdletCancellationToken).Result.Body;

            ARSVault vault = new ARSVault(response);
            return vault;
        }

        /// <summary>  
        /// Method to create or update Recovery Services Vault.
        /// </summary>  
        /// <param name="resouceGroupName">Name of the resouce group</param>  
        /// <param name="vaultName">Name of the vault</param>  
        /// <param name="patchVault">patch vault object to patch the recovery services Vault</param>
        /// <returns>Azure Recovery Services Vault.</returns> 
        public Vault UpdateRSVault(string resouceGroupName, string vaultName, PatchVault patchVault)
        {
            var response = RSAdapter.Client.Vaults.UpdateWithHttpMessagesAsync(resouceGroupName, vaultName, patchVault).Result;
            return response.Body;
        }

        /// <summary>
        /// Method to get secondary region AAD properties
        /// </summary>
        /// <param name="azureRegion">Azure region to fetch AAD properties</param>
        /// <returns>vault response object.</returns>
        public CrrModel.AADPropertiesResource GetAADProperties(string azureRegion, string backupManagementType = null)
        {
            ODataQuery<CrrModel.BMSAADPropertiesQueryObject> queryParams = null;

            if(backupManagementType == BackupManagementType.AzureWorkload)
            {
                queryParams = new ODataQuery<CrrModel.BMSAADPropertiesQueryObject>(q => q.BackupManagementType == BackupManagementType.AzureWorkload);
            }

            CrrModel.AADPropertiesResource aadProperties =  CrrAdapter.Client.AadProperties.GetWithHttpMessagesAsync(azureRegion, queryParams).Result.Body;
            return aadProperties;
        }

        /// <summary>
        /// This method prepares the source vault for Data Move operation.
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="prepareMoveRequest"></param>
        public string PrepareDataMove(string vaultName, string resourceGroupName, PrepareDataMoveRequest prepareMoveRequest)
        {
            // prepare move
            var prepareMoveOperationResponse = BmsAdapter.Client.BeginBMSPrepareDataMoveWithHttpMessagesAsync(
                           vaultName, resourceGroupName, prepareMoveRequest).Result;

            // track prepare-move operation to success
            var operationStatus = TrackingHelpers.GetOperationStatusDataMove(
                prepareMoveOperationResponse,
                operationId => GetDataMoveOperationStatus(operationId, vaultName, resourceGroupName));

            Logger.Instance.WriteDebug("Prepare move operation: " + operationStatus.Body.Status);

            // get the correlation Id and return it for trigger data move
            var operationResult = TrackingHelpers.GetCorrelationId(
                prepareMoveOperationResponse,
                operationId => GetPrepareDataMoveOperationResult(operationId, vaultName, resourceGroupName));

            Logger.Instance.WriteDebug("Prepare move - correlationId:" + operationResult.CorrelationId);

            return operationResult.CorrelationId;
        }

        /// <summary>
        /// This method triggers the Data Move operation on Target vault.
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="triggerMoveRequest"></param>
        public void TriggerDataMove(string vaultName, string resourceGroupName, TriggerDataMoveRequest triggerMoveRequest)
        {
            //trigger move 
            var triggerMoveOperationResponse = BmsAdapter.Client.BeginBMSTriggerDataMoveWithHttpMessagesAsync(
                           vaultName, resourceGroupName, triggerMoveRequest).Result;

            // track trigger-move operation to success
            var operationStatus = TrackingHelpers.GetOperationStatusDataMove(
                triggerMoveOperationResponse,
                operationId => GetDataMoveOperationStatus(operationId, vaultName, resourceGroupName));

            Logger.Instance.WriteDebug("Trigger move operation: " + operationStatus.Body.Status);

        }
    }
}
