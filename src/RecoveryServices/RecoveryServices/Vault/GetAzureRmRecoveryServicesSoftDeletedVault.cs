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
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure Recovery Services Soft Deleted Vaults.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesSoftDeletedVault")]
    [OutputType(typeof(ARSSoftDeletedVault))]
    public class GetAzureRmRecoveryServicesSoftDeletedVault : RecoveryServicesCmdletBase
    {
        #region Parameters
        
        /// <summary>
        /// Gets or sets Resource Group name.
        /// </summary>
        [Parameter(Position = 1)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Resource Name (Vault Name).
        /// </summary>
        [Parameter(Position = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Location.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true)]
        [LocationCompleter]
        public string Location { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    this.GetSoftDeletedVaultsByLocation();
                }
                else
                {
                    this.GetSoftDeletedVaultByName();
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Get soft deleted vaults by location.
        /// </summary>
        private void GetSoftDeletedVaultsByLocation()
        {
            List<DeletedVault> deletedVaults = RecoveryServicesClient.GetSoftDeletedVaultsByLocation(this.Location);
            
            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                var filteredVaults = FilterVaultsByResourceGroup(deletedVaults, this.ResourceGroupName);
                this.WriteSoftDeletedVaults(filteredVaults);
            }
            else
            {
                this.WriteSoftDeletedVaults(deletedVaults);
            }
        }

        /// <summary>
        /// Get soft deleted vault by name.
        /// </summary>
        private void GetSoftDeletedVaultByName()
        {
            DeletedVault deletedVault = RecoveryServicesClient.GetSoftDeletedVault(this.Location, this.Name);
            
            if (!string.IsNullOrEmpty(this.ResourceGroupName) && deletedVault != null)
            {
                // Verify resource group matches if specified using the common filter function
                var filteredVaults = FilterVaultsByResourceGroup(new List<DeletedVault> { deletedVault }, this.ResourceGroupName);
                if (filteredVaults.Count == 0)
                {
                    WriteDebug($"The soft deleted vault '{this.Name}' was found but does not belong to resource group '{this.ResourceGroupName}'.");
                    return;
                }
                deletedVault = filteredVaults.First();
            }
            
            this.WriteObject(new ARSSoftDeletedVault(deletedVault));
        }

        /// <summary>
        /// Filters deleted vaults by resource group name.
        /// </summary>
        /// <param name="deletedVaults">List of deleted vaults to filter</param>
        /// <param name="resourceGroupName">Resource group name to filter by</param>
        /// <returns>Filtered list of deleted vaults</returns>
        private List<DeletedVault> FilterVaultsByResourceGroup(List<DeletedVault> deletedVaults, string resourceGroupName)
        {
            return deletedVaults.Where(v =>
            {
                if (v.Properties?.VaultId != null)
                {
                    var vaultResourceGroup = PSRecoveryServicesClient.GetResourceGroup(v.Properties.VaultId);
                    return string.Equals(vaultResourceGroup, resourceGroupName, StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }).ToList();
        }

        /// <summary>
        /// Write Soft Deleted Vaults.
        /// </summary>
        /// <param name="deletedVaults">List of Deleted Vaults</param>
        private void WriteSoftDeletedVaults(IList<DeletedVault> deletedVaults)
        {
            this.WriteObject(deletedVaults.Select(v => new ARSSoftDeletedVault(v)), true);
        }
    }
}