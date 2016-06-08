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

using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;

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
        public VaultListResponse GetVaultsInResouceGroup(string resouceGroupName)
        {
            return this.GetRecoveryServicesClient.Vaults.List(resouceGroupName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Method to get Azure Recovery Services Vault
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <param name="resourceName">Name of the resource</param>
        /// <returns>vault response object.</returns>
        public VaultResponse GetVault(string resouceGroupName, string resourceName)
        {
            return this.GetRecoveryServicesClient.Vaults.Get(resouceGroupName, resourceName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Method to create Azure Recovery Services Vault
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <param name="vaultName">Name of the vault</param>
        /// <param name="vaultCreateInput">Vault creation input object</param>
        /// <returns>Create response object.</returns>
        public VaultCreateResponse CreateVault(string resouceGroupName, string vaultName, VaultCreateArgs vaultCreateInput)
        {
            return this.recoveryServicesClient.Vaults.BeginCreating(resouceGroupName, vaultName, vaultCreateInput);
        }

        /// <summary>
        /// Method to delete Azure Recovery Services Vault
        /// </summary>
        /// <param name="resouceGroupName">Name of the resouce group</param>
        /// <param name="vaultName">Name of the vault</param>
        /// <returns>Delete response object.</returns>
        public RecoveryServicesOperationStatusResponse DeleteVault(string resouceGroupName, string vaultName)
        {
            return this.recoveryServicesClient.Vaults.BeginDeleting(resouceGroupName, vaultName);
        }

        /// <summary>
        /// Method to list Azure resouce groups
        /// </summary>
        /// <returns>resource group list response object.</returns>
        public ResourceGroupListResponse GetResouceGroups()
        {
            return this.GetRecoveryServicesClient.ResourceGroup.List();
        }


        /// <summary>  
        /// Method to Update Azure Recovery Services Vault Backup Properties  
        /// </summary>  
        /// <param name="resouceGroupName">Name of the resouce group</param>  
        /// <param name="vaultName">Name of the vault</param>  
        /// <param name="vaultStorageUpdateRequest">Backup Properties Update</param>  
        /// <returns>Azure Operation response object.</returns>  
        public AzureOperationResponse UpdateVaultStorageType(string resouceGroupName, string vaultName, 
            UpdateVaultStorageTypeRequest vaultStorageUpdateRequest)
        {
            return this.recoveryServicesClient.Vaults.UpdateStorageType(resouceGroupName, vaultName,
                vaultStorageUpdateRequest, this.GetRequestHeaders());
        }

        /// <summary>  
        /// Method to Get Azure Recovery Services Vault Backup Properties  
        /// </summary>  
        /// <param name="resouceGroupName">Name of the resouce group</param>  
        /// <param name="vaultName">Name of the vault</param>  
        /// <returns>Azure Resource Storage response object.</returns>  
        public GetResourceStorageConfigResponse GetVaultStorageType(string resouceGroupName, string vaultName)
        {
            return this.recoveryServicesClient.Vaults.GetResourceStorageConfig(resouceGroupName, 
                vaultName, this.GetRequestHeaders());
        }
    }
}
