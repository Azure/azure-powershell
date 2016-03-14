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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.HydraAdapter;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// To set RecoveryServicesVaultContext
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmRecoveryServicesVaultContext")]
    public class SetAzureRmRecoveryServicesVaultContext : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault Vault { get; set; }        

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                // Validate required parameters taken from the Vault.
                if (string.IsNullOrEmpty(Vault.Name))
                {
                    throw new ArgumentException(
                        Properties.Resources.ResourceNameNullOrEmpty,
                        Vault.Name);
                }

                if (string.IsNullOrEmpty(Vault.ResouceGroupName))
                {
                    throw new ArgumentException(
                        Properties.Resources.CloudServiceNameNullOrEmpty,
                        Vault.ResouceGroupName);
                }

                AzureRmRecoveryServicesVaultCreds vaultCreds = new AzureRmRecoveryServicesVaultCreds(Vault.Name,
                                                               Vault.ResouceGroupName, Vault.Location);

                ClientProxyBase.UpdateCurrentVaultContext(vaultCreds);

                //Add validation to check vault exist or not (see if we can resuse existing ASR code).

                this.WriteObject(vaultCreds);
            });
           
        }
    }
}
