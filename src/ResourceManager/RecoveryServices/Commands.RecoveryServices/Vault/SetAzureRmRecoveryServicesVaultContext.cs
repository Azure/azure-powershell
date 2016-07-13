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
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Used to set RecoveryServices Vault Context
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmRecoveryServicesVaultContext")]
    public class SetAzureRmRecoveryServicesVaultContext : RecoveryServicesCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault Vault { get; set; }        

        public override void ExecuteCmdlet()
        {
            try
            {
                base.ExecuteCmdlet();

                // Validate required parameters taken from the Vault.
                if (string.IsNullOrEmpty(Vault.Name))
                {
                    throw new ArgumentException(
                        Properties.Resources.ResourceNameNullOrEmpty,
                        Vault.Name);
                }

                if (string.IsNullOrEmpty(Vault.ResourceGroupName))
                {
                    throw new ArgumentException(
                        Properties.Resources.ResourceGroupNameNullOrEmpty,
                        Vault.ResourceGroupName);
                }

                var vault = RecoveryServicesClient.GetVault(Vault.ResourceGroupName, Vault.Name);
                if(vault == null)
                {
                    throw new ArgumentException(
                        string.Format(Properties.Resources.VaultNotFound, Vault.Name),
                        Vault.ResourceGroupName);
                }

                Utilities.UpdateCurrentVaultContext(Vault);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }           
           
        }
    }
}
