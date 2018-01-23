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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.SiteRecoveryVault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Vault.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryVault")]
    [OutputType(typeof(List<ASRVault>))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Get-AzureRmRecoveryServicesVault cmdlet from the AzureRm.RecoveryServices module instead.",
        false)]
    public class GetAzureSiteRecoveryVaults : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Resource Group name.
        /// </summary>
        [Parameter]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Resource Name.
        /// </summary>
        [Parameter]
        public string Name { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.GetVaultsUnderAllResourceGroups();
            }
            else
            {
                this.GetVaultsUnderResourceGroup();
            }
        }

        /// <summary>
        /// Get vaults under a resouce group.
        /// </summary>
        private void GetVaultsUnderResourceGroup()
        {
            VaultListResponse vaultListResponse =
                RecoveryServicesClient.GetVaultsInResouceGroup(this.ResourceGroupName);

            this.WriteVaults(vaultListResponse.Vaults);
        }

        /// <summary>
        /// Get vaults under all resouce group.
        /// </summary>
        private void GetVaultsUnderAllResourceGroups()
        {
            foreach (var resourceGroup in RecoveryServicesClient.GetResouceGroups().ResourceGroups)
            {
                VaultListResponse vaultListResponse =
                    RecoveryServicesClient.GetVaultsInResouceGroup(resourceGroup.Name);

                this.WriteVaults(vaultListResponse.Vaults);
            }
        }

        /// <summary>
        /// Write Vaults.
        /// </summary>
        /// <param name="vaults">List of Vaults</param>
        private void WriteVaults(IList<Vault> vaults)
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                this.WriteObject(vaults.Select(v => new ASRVault(v)), true);
            }
            else
            {
                foreach (Vault vault in vaults)
                {
                    if (0 == string.Compare(this.Name, vault.Name, true))
                    {
                        this.WriteObject(new ASRVault(vault));
                    }
                }
            }
        }
    }
}
