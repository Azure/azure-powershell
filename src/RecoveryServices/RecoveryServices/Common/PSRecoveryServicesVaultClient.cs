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
using Microsoft.Azure.Commands.RecoveryServices.Properties;
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
                resouceGroupName, vaultName, vault, default(string), GetRequestHeaders()).Result.Body;
        }

        /// <summary>
        /// Method to create or update Recovery Services Vault.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resouce group</param>
        /// <param name="vaultName">Name of the vault</param>
        /// <param name="vault">patch vault object to patch the recovery services Vault</param>
        /// <param name="auxiliaryAccessToken">cross tenant access token for MUA</param>
        /// <param name="isMUAProtected">whether operation is MUA protected</param>
        /// <returns>Azure Recovery Services Vault.</returns>
        public Vault UpdateRSVault(string resourceGroupName, string vaultName, PatchVault vault, string auxiliaryAccessToken = null, bool isMUAProtected = false)
        {
            Dictionary<string, List<string>> customHeaders = new Dictionary<string, List<string>>();
            if (isMUAProtected)
            {
                List<ResourceGuardProxyBaseResource> resourceGuardMapping = ListResourceGuardMapping(vaultName, resourceGroupName);
                string operationRequest = null;

                if (resourceGuardMapping != null && resourceGuardMapping.Count != 0)
                {
                    string criticalOp = "Microsoft.RecoveryServices/vaults/write#reduceImmutabilityState";
                    
                    foreach (ResourceGuardOperationDetail operationDetail in resourceGuardMapping[0].Properties.ResourceGuardOperationDetails)
                    {
                        if (operationDetail.VaultCriticalOperation == criticalOp)
                        {
                            operationRequest = operationDetail.DefaultResourceRequest;
                        }
                    }

                    if (operationRequest != null)
                    {
                        vault.Properties.ResourceGuardOperationRequests = new List<string>();
                        vault.Properties.ResourceGuardOperationRequests.Add(operationRequest);
                    }
                }

                if (auxiliaryAccessToken != null && auxiliaryAccessToken != "")
                {
                    if (operationRequest != null)
                    {
                        customHeaders.Add("x-ms-authorization-auxiliary", new List<string> { "Bearer " + auxiliaryAccessToken });
                    }
                    else
                    {
                        // resx
                        throw new ArgumentException(String.Format(Resources.UnexpectedParameterToken, "Reducing immutability state for recovery services vault"));
                    }
                }
            }

            var response = GetRecoveryServicesClient.Vaults.UpdateWithHttpMessagesAsync(resourceGroupName, vaultName, vault, default(string), customHeaders).Result;
            return response.Body;
        }

        /// <summary>
        /// Method to delete Azure Recovery Services Vault
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <param name="vaultName">Name of the vault</param>
        public Rest.Azure.AzureOperationHeaderResponse<VaultsDeleteHeaders> DeleteVault(string resouceGroupName, string vaultName)
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
            GetRecoveryServicesBackupClient.BackupResourceStorageConfigsNonCrr.UpdateWithHttpMessagesAsync(
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
            GetRecoveryServicesBackupClient.BackupResourceStorageConfigsNonCrr.PatchWithHttpMessagesAsync(
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
            return GetRecoveryServicesBackupClient.BackupResourceStorageConfigsNonCrr.GetWithHttpMessagesAsync(
                vaultName, resouceGroupName, GetRequestHeaders()).Result.Body;
        }

        /// <summary>
        /// Method to fetch resource guard proxy list.
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public List<ResourceGuardProxyBaseResource> ListResourceGuardMapping(string vaultName, string resourceGroupName)
        {
            Func<IPage<ResourceGuardProxyBaseResource>> proxyPagedList = () => GetRecoveryServicesBackupClient.ResourceGuardProxies.GetWithHttpMessagesAsync(vaultName, resourceGroupName).Result.Body;

            Func<string, IPage<ResourceGuardProxyBaseResource>> proxyPagedListNext = nextLink => GetRecoveryServicesBackupClient.ResourceGuardProxies.GetNextWithHttpMessagesAsync(
                    nextLink).Result.Body;

            var proxyList = Utilities.GetPagedList(proxyPagedList, proxyPagedListNext);

            return proxyList;
        }
    }
}
