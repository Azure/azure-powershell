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
using Microsoft.Azure.Commands.RecoveryServices.Properties;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Used to initiate a vault create operation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmRecoveryServicesVault", SupportsShouldProcess = true),
        OutputType(typeof(ARSVault))]
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
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the location of the vault
        /// </summary>
        [Parameter(Mandatory = true)]
        [LocationCompleter("Microsoft.RecoveryServices/vaults")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Resources.VaultTarget, "new"))
            {
                try
                {
                    Vault vaultCreateArgs = new Vault();
                    vaultCreateArgs.Location = this.Location;
                    vaultCreateArgs.Properties = new VaultProperties();
                    vaultCreateArgs.Sku = new Sku();
                    vaultCreateArgs.Sku.Name = SkuName.Standard;

                    Vault response = RecoveryServicesClient.CreateVault(this.ResourceGroupName, this.Name, vaultCreateArgs);

                    this.WriteObject(new ARSVault(response));
                }
                catch (Exception exception)
                {
                    this.HandleException(exception);
                }
            }
        }
    }
}
