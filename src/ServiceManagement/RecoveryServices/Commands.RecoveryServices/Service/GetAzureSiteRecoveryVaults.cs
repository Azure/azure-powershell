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
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.RecoveryServices.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure Site Recovery Vault.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoveryVault", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(List<ASRVault>))]
    public class GetAzureSiteRecoveryVaults : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets name of the Vault.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByName:
                        this.GetByName();
                        break;
                    case ASRParameterSets.Default:
                        this.GetByDefault();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        private void GetByDefault()
        {
            IEnumerable<CloudService> cloudServiceList = RecoveryServicesClient.GetCloudServices();

            List<ASRVault> vaultList = new List<ASRVault>();
            foreach (var cloudService in cloudServiceList)
            {
                foreach (var vault in cloudService.Resources)
                {
                    if (vault.Type.Equals(Constants.ASRVaultType, StringComparison.InvariantCultureIgnoreCase))
                    {
                        vaultList.Add(new ASRVault(cloudService, vault));
                    }
                }
            }

            this.WriteVaults(vaultList);
        }

        private void GetByName()
        {
            bool vaultFound = false;

            IEnumerable<CloudService> cloudServiceList = RecoveryServicesClient.GetCloudServices();

            List<ASRVault> vaultList = new List<ASRVault>();
            foreach (var cloudService in cloudServiceList)
            {
                foreach (var vault in cloudService.Resources)
                {
                    if (vault.Type.Equals(Constants.ASRVaultType, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (string.Compare(this.Name, vault.Name, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            vaultFound = true;
                            this.WriteVault(new ASRVault(cloudService, vault));
                        }
                    }
                }
            }

            if (!vaultFound)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.VaultNotFound,
                    this.Name));
            }
        }

        /// <summary>
        /// Writes Vaults
        /// </summary>
        /// <param name="vaultList">List of Vaults</param>
        private void WriteVaults(IList<ASRVault> vaultList)
        {
            this.WriteObject(vaultList, true);
        }

        /// <summary>
        /// Writes Vaults
        /// </summary>
        /// <param name="vault">Vault object</param>
        private void WriteVault(ASRVault vault)
        {
            this.WriteObject(vault);
        }
    }
}
