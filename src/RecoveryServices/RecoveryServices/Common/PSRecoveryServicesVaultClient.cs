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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Method to list Azure Recovery Services Vaults
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <returns>vault list response object.</returns>
        public List<Vault> GetVaultsInResouceGroup(string resouceGroupName)
        {
            return GetRecoveryServicesClient.Vaults.ListByResourceGroupWithHttpMessagesAsync(
                resouceGroupName, GetRequestHeaders()).Result.Body.ToList();
        }

        /// <summary>
        /// Method to get Azure Recovery Services Vault
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <param name="resourceName">Name of the resource</param>
        /// <returns>vault response object.</returns>
        public Vault GetVault(string resouceGroupName, string resourceName)
        {
            return GetRecoveryServicesClient.Vaults.GetWithHttpMessagesAsync(
                resouceGroupName, resourceName, GetRequestHeaders()).Result.Body;
        }

        /// <summary>
        /// Method to create Azure Recovery Services Vault
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <param name="vaultName">Name of the vault</param>
        /// <param name="vault">Vault creation input object</param>
        /// <returns>Create response object.</returns>
        public Vault CreateVault(string resouceGroupName, string vaultName, Vault vault)
        {
            return GetRecoveryServicesClient.Vaults.CreateOrUpdateWithHttpMessagesAsync(
                resouceGroupName, vaultName, vault, GetRequestHeaders()).Result.Body;
        }

        /// <summary>
        /// Method to create or update Recovery Services Vault.
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <param name="vaultName">Name of the vault</param>
        /// <param name="vault">patch vault object to patch the recovery services Vault</param>
        /// <returns>Azure Recovery Services Vault.</returns>
        public Vault UpdateRSVault(string resouceGroupName, string vaultName, PatchVault vault)
        {
            var response = GetRecoveryServicesClient.Vaults.UpdateWithHttpMessagesAsync(resouceGroupName, vaultName, vault).Result;
            return response.Body;
        }

        /// <summary>
        /// Method to delete Azure Recovery Services Vault
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <param name="vaultName">Name of the vault</param>
        public Rest.Azure.AzureOperationResponse DeleteVault(string resouceGroupName, string vaultName)
        {
            return GetRecoveryServicesClient.Vaults.DeleteWithHttpMessagesAsync(
                resouceGroupName, vaultName, GetRequestHeaders()).Result;
        }

        ///// <summary>
        ///// Method to list Azure resouce groups
        ///// </summary>
        ///// <returns>resource group list response object.</returns>
        public List<Microsoft.Azure.Management.Internal.Resources.Models.ResourceGroup> GetResouceGroups()
        {
            Func<IPage<Microsoft.Azure.Management.Internal.Resources.Models.ResourceGroup>> listAsync =
                () => RmClient.ResourceGroups.ListWithHttpMessagesAsync(
                    customHeaders: GetRequestHeaders()).Result.Body;

            Func<string, IPage<Microsoft.Azure.Management.Internal.Resources.Models.ResourceGroup>> listNextAsync =
                nextLink => RmClient.ResourceGroups.ListNextWithHttpMessagesAsync(
                    nextLink, GetRequestHeaders()).Result.Body;

            return Utilities.GetPagedList(listAsync, listNextAsync);
        }


        /// <summary>
        /// Method to Update Azure Recovery Services Vault Backup Properties
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <param name="vaultName">Name of the vault</param>
        /// <param name="backupStorageConfig">Backup Properties Update</param>
        /// <returns>Azure Operation response object.</returns>
        public void UpdateVaultStorageType(string resouceGroupName, string vaultName,
            BackupResourceConfigResource backupStorageConfig)
        {
            GetRecoveryServicesBackupClient.BackupResourceStorageConfigsNonCRR.UpdateWithHttpMessagesAsync(
                vaultName, resouceGroupName, backupStorageConfig, GetRequestHeaders());
        }

        /// <summary>
        /// Method to Patch Azure Recovery Services Vault Backup Properties
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <param name="vaultName">Name of the vault</param>
        /// <param name="backupStorageConfig">Backup Properties Update</param>
        /// <returns>Azure Operation response object.</returns>
        public void PatchVaultStorageConfigProperties(string resouceGroupName, string vaultName,
            BackupResourceConfigResource backupStorageConfig)
        {
            GetRecoveryServicesBackupClient.BackupResourceStorageConfigsNonCRR.PatchWithHttpMessagesAsync(
                vaultName, resouceGroupName, backupStorageConfig, GetRequestHeaders());
        }

        /// <summary>
        /// Method to Get Azure Recovery Services Vault Backup Properties
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <param name="vaultName">Name of the vault</param>
        /// <returns>Azure Resource Storage response object.</returns>
        public BackupResourceConfigResource GetVaultStorageConfig(string resouceGroupName, string vaultName)
        {
            return GetRecoveryServicesBackupClient.BackupResourceStorageConfigsNonCRR.GetWithHttpMessagesAsync(
                vaultName, resouceGroupName, GetRequestHeaders()).Result.Body;
        }
    }
}
