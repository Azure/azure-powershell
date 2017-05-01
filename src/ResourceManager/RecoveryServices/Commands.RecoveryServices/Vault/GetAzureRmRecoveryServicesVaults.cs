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

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure Recovery Services Vault.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesVault")]
    [OutputType(typeof(List<ARSVault>))]
    public class GetAzureRmRecoveryServicesVaults : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Resource Group name.
        /// </summary>
        [Parameter]
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
        public override void ExecuteCmdlet()
        {
            try
            {
                if (string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    this.GetVaultsUnderAllResourceGroups();
                }
                else
                {
                    this.GetVaultsUnderResourceGroup();
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
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
                this.WriteObject(vaults.Select(v => new ARSVault(v)), true);
            }
            else
            {
                foreach (Vault vault in vaults)
                {
                    if (0 == string.Compare(this.Name, vault.Name, true))
                    {
                        this.WriteObject(new ARSVault(vault));
                    }
                }
            }
        }
    }
}
