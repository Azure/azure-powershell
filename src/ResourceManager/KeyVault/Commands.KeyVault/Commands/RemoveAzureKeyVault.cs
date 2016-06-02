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
using System.Globalization;
using System.Management.Automation;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmKeyVault",
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High,
        HelpUri = Constants.KeyVaultHelpUri)]
    public class RemoveAzureKeyVault : KeyVaultManagementCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of the key vault to remove.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Resource group to which the vault belongs.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of resource group for Azure key vault to remove.")]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "Indicates that the cmdlet does not prompt you for confirmation. By default, this cmdlet prompts you to confirm that you want to delete the key vault.")]
        public SwitchParameter Force { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            ResourceGroupName = string.IsNullOrWhiteSpace(ResourceGroupName) ? GetResourceGroupName(VaultName) : ResourceGroupName;
            if (string.IsNullOrWhiteSpace(ResourceGroupName))
                throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.VaultNotFound, VaultName, ResourceGroupName));

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    PSKeyVaultProperties.Resources.RemoveVaultWarning,
                    VaultName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    PSKeyVaultProperties.Resources.RemoveVaultWhatIfMessage,
                    VaultName),
                VaultName,
                () =>
                {
                    KeyVaultManagementClient.DeletVault(
                vaultName: VaultName,
                resourceGroupName: this.ResourceGroupName);
                });
        }

    }
}