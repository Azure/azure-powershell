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

using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AzureBackup.ClientAdapter
{
    public partial class AzureBackupClientAdapter
    {
        public const int defaultTop = 100;
        private const string defaultSKU = "standard";

        /// <summary>
        /// Creates or updates the vault identified by client
        /// </summary>
        /// <param name="location"></param>
        /// <param name="skuParam"></param>
        /// <returns></returns>
        public AzureBackupVault CreateOrUpdateAzureBackupVault(string resourceGroupName, string vaultName, string location)
        {
            var createResourceParameters = new AzureBackupVaultCreateOrUpdateParameters()
            {
                Location = location,
                Properties = new AzureBackupVaultProperties()
                {
                    Sku = new SkuProperties()
                    {
                        Name = defaultSKU,
                    },
                },
            };

            var response = AzureBackupVaultClient.Vault.CreateOrUpdateAsync(resourceGroupName, vaultName, createResourceParameters, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return response.Vault;
        }

        /// <summary>
        /// Updates storage type of the vault identified by client
        /// </summary>
        /// <param name="storageType"></param>
        public void UpdateStorageType(string resourceGroupName, string resourceName, string storageType)
        {
            UpdateVaultStorageTypeRequest updateVaultStorageTypeRequest = new UpdateVaultStorageTypeRequest()
            {
                StorageTypeProperties = new StorageTypeProperties()
                {
                    StorageModelType = storageType,
                },
            };

            AzureBackupVaultClient.Vault.UpdateStorageTypeAsync(resourceGroupName, resourceName, updateVaultStorageTypeRequest, GetCustomRequestHeaders(), CmdletCancellationToken).Wait();
        }

        /// <summary>
        /// Gets storage type details of the specified resource
        /// </summary>
        /// <returns></returns>
        public string GetStorageTypeDetails(string resourceGroupName, string vaultName)
        {
            string storageType = String.Empty;
            try
            {
                var response = AzureBackupVaultClient.Vault.GetResourceStorageConfigAsync(resourceGroupName, vaultName, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                storageType = (response != null) ? response.StorageDetails.StorageType : null;
            }
            catch (Exception) { }

            return storageType;
        }

        /// <summary>
        /// Gets the vault identified by the client
        /// </summary>
        /// <returns></returns>
        public AzureBackupVault GetVault(string resourceGroupName, string vaultName)
        {
            var getResponse = AzureBackupVaultClient.Vault.GetAsync(resourceGroupName, vaultName, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return (getResponse != null) ? getResponse.Vault : null;
        }

        /// <summary>
        /// Gets backup vaults in current subscription
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AzureBackupVault> GetVaults()
        {
            var listResponse = AzureBackupVaultClient.Vault.ListAsync(defaultTop, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return (listResponse != null) ? listResponse.Vaults : null;
        }

        /// <summary>
        /// Gets backup vaults in given resource group
        /// </summary>
        /// <param name="resourceGroup"></param>
        /// <returns></returns>
        public IEnumerable<AzureBackupVault> GetVaultsInResourceGroup(string resourceGroupName)
        {
            var listResponse = AzureBackupVaultClient.Vault.ListByResourceGroupAsync(resourceGroupName, defaultTop, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return (listResponse != null) ? listResponse.Vaults : null;
        }

        /// <summary>
        /// Deletes the specified backup vault
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="vaultName"></param>
        public bool DeleteVault(string resourceGroupName, string vaultName)
        {
            AzureBackupVaultGetResponse response = AzureBackupVaultClient.Vault.DeleteAsync(resourceGroupName, vaultName, GetCustomRequestHeaders(), CmdletCancellationToken).Result;

            // OneSDK will return only either OK or NoContent
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public VaultCredUploadCertResponse UploadCertificate(string resourceGroupName, string resourceName, string certName, VaultCredUploadCertRequest request)
        {
            return AzureBackupVaultClient.Vault.UploadCertificateAsync(resourceGroupName, resourceName, certName, request, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
        }
    }
}