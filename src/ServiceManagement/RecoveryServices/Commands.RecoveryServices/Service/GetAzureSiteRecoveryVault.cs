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
                this.WriteWarningWithTimestamp(
                    string.Format(
                        Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name));

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

        /// <summary>
        /// Queries all, by default.
        /// </summary>
        private void GetByDefault()
        {
            List<ASRVault> vaultList = this.GetVaults();
            this.WriteVaults(vaultList);
        }

        /// <summary>
        /// Queries by name.
        /// </summary>
        private void GetByName()
        {
            List<ASRVault> vaultList = this.GetVaults();
            List<ASRVault> vaultListByName = new List<ASRVault>();

            foreach (var vault in vaultList)
            {
                if (string.Compare(this.Name, vault.Name, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    vaultListByName.Add(vault);
                }
            }

            if (vaultListByName.Count == 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.VaultNotFound,
                    this.Name));
            }

            this.WriteVaults(vaultListByName);
        }

        /// <summary>
        /// Gets the vaults in the cloud service.
        /// </summary>
        /// <returns>List of ASR Vaults</returns>
        private List<ASRVault> GetVaults()
        {
            IEnumerable<CloudService> cloudServiceList = RecoveryServicesClient.GetCloudServices();

            List<ASRVault> vaultList = new List<ASRVault>();
            foreach (var cloudService in cloudServiceList)
            {
                foreach (var vault in cloudService.Resources)
                {
                    if (vault.Type.Equals(Constants.ASRVaultType, StringComparison.InvariantCultureIgnoreCase))
                    {
                        vaultList.Add(new ASRVault(cloudService, vault, this.Profile.Context.Subscription.ToString()));
                    }
                }
            }

            return vaultList;
        }

        /// <summary>
        /// Writes Vaults
        /// </summary>
        /// <param name="vaultList">List of Vaults</param>
        private void WriteVaults(IList<ASRVault> vaultList)
        {
            this.WriteObject(vaultList, true);
        }
    }
}
