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

using Microsoft.Azure.Management.SiteRecoveryVault;
using Microsoft.Azure.Management.SiteRecoveryVault.Models;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Method to list Azure Site Recovery Vaults
        /// </summary>
        /// <param name="resouceGroupName">name of the resouce group</param>
        /// <returns>vault list response object.</returns>
        public VaultListResponse GetVaultsInResouceGroup(string resouceGroupName)
        {
            return this.GetRecoveryServicesClient.Vaults.Get(resouceGroupName, this.GetRequestHeaders(false));
        }

        /// <summary>
        /// Method to create Azure Site Recovery Vault
        /// </summary>
        /// <param name="resouceGroupName">name of the resouce group</param>
        /// <param name="vaultName">name of the vault</param>
        /// <param name="vaultCreateInput">vault creation input object</param>
        /// <returns>creation response object.</returns>
        public VaultCreateResponse CreateVault(string resouceGroupName, string vaultName, VaultCreateArgs vaultCreateInput)
        {
            return this.recoveryServicesClient.Vaults.BeginCreating(resouceGroupName, vaultName, vaultCreateInput);
        }

        /// <summary>
        /// Method to delete Azure Site Recovery Vault
        /// </summary>
        /// <param name="resouceGroupName">name of the resouce group</param>
        /// <param name="vaultName">name of the vault</param>
        /// <returns>creation response object.</returns>
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
    }
}
