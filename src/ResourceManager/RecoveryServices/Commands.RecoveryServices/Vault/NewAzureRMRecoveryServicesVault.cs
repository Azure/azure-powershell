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
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Used to initiate a vault create operation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmRecoveryServicesVault")]
    public class NewAzureRmRecoveryServicesVault : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the vault name
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the location of the vault
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets BackupStorageRedundancy type
        /// </summary>
        [Parameter(Mandatory = false)]
        public string BackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets BackupStorageDeduplication type
        /// </summary>
        [Parameter(Mandatory = false)]
        public string BackupStorageDeduplication { get; set; }


        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                VaultCreateArgs vaultCreateArgs = new VaultCreateArgs();
                vaultCreateArgs.Location = this.Location;
                vaultCreateArgs.Properties = new VaultProperties();
                vaultCreateArgs.Sku = new VaultSku();
                vaultCreateArgs.Sku.Name = "standard";

                VaultCreateResponse response = RecoveryServicesClient.CreateVault(this.ResourceGroupName, this.Name, vaultCreateArgs);

                if (!(string.IsNullOrEmpty(this.BackupStorageRedundancy) && string.IsNullOrEmpty(this.BackupStorageDeduplication)))
                {
                    UpdateVaultStorageTypeRequest vaultStorageRequest = new UpdateVaultStorageTypeRequest();
                    vaultStorageRequest.Properties = new StorageTypeProperties();
                    vaultStorageRequest.Properties.StorageModelType = this.BackupStorageRedundancy;
                    vaultStorageRequest.Properties.DedupState = this.BackupStorageDeduplication;
                    AzureOperationResponse storageResponse = RecoveryServicesClient.UpdateVaultStorageType(this.ResourceGroupName, this.Name, vaultStorageRequest);
                }

                VaultListResponse vaultList = RecoveryServicesClient.GetVaultsInResouceGroup(this.ResourceGroupName);
                foreach (Vault vault in vaultList.Vaults)
                {
                    if (vault.Name.Equals(this.Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        ARSVault rsVault = new ARSVault(vault);
                        GetResourceStorageConfigResponse getStorageResponse = RecoveryServicesClient.GetVaultStorageType(this.ResourceGroupName, this.Name);
                        rsVault.Properties.BackupStorageRedundancy = getStorageResponse.Properties.StorageType;
                        rsVault.Properties.BackupStorageDeduplication = getStorageResponse.Properties.DedupState;
                        this.WriteObject(rsVault);
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
