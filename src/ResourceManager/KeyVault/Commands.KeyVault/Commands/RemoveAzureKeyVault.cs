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
        #region Parameter Set Names

        private const string RemoveVaultParameterSet = "ByAvailableVault";
        private const string RemoveDeletedVaultParameterSet = "ByDeletedVault";

        #endregion

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
            ParameterSetName = RemoveVaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of resource group for Azure key vault to remove.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false,
            Position = 2,
            ParameterSetName = RemoveVaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location of the deleted vault.")]
        [Parameter(Mandatory = true,
            Position = 2,
            ParameterSetName = RemoveDeletedVaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location of the deleted vault.")]
        [LocationCompleter("Microsoft.KeyVault/vaults")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "Indicates that the cmdlet does not prompt you for confirmation. By default, this cmdlet prompts you to confirm that you want to delete the key vault.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// If present, operate on the deleted vault entity.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = RemoveDeletedVaultParameterSet,
            HelpMessage = "Remove the previously deleted vault permanently.")]
        public SwitchParameter InRemovedState { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case RemoveVaultParameterSet:
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
                            KeyVaultManagementClient.DeleteVault(
                        vaultName: VaultName,
                        resourceGroupName: this.ResourceGroupName);
                        });
                    break;
                case RemoveDeletedVaultParameterSet:
                    ConfirmAction(
                        Force.IsPresent,
                        string.Format(
                            CultureInfo.InvariantCulture,
                            PSKeyVaultProperties.Resources.PurgeVaultWarning,
                            VaultName),
                        string.Format(
                            CultureInfo.InvariantCulture,
                            PSKeyVaultProperties.Resources.PurgeVaultWhatIfMessage,
                            VaultName),
                        VaultName,
                        () =>
                        {
                            KeyVaultManagementClient.PurgeVault(
                                vaultName: VaultName,
                                location: Location);
                        });
                    break;
                default:
                    throw new ArgumentException(PSKeyVaultProperties.Resources.BadParameterSetName);
            }
        }
    }
}