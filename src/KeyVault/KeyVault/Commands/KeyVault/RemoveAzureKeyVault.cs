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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVault",SupportsShouldProcess = true,DefaultParameterSetName = RemoveVaultParameterSet)]
    [OutputType(typeof(bool))]
    public class RemoveAzureKeyVault : KeyVaultManagementCmdletBase
    {
        #region Parameter Set Names

        private const string RemoveVaultParameterSet = "ByAvailableVault";
        private const string RemoveDeletedVaultParameterSet = "ByDeletedVault";

        private const string InputObjectRemoveVaultParameterSet = "InputObjectByAvailableVault";
        private const string InputObjectRemoveDeletedVaultParameterSet = "InputObjectByDeletedVault";

        private const string ResourceIdRemoveVaultParameterSet = "ResourceIdByAvailableVault";
        private const string ResourceIdRemoveDeletedVaultParameterSet = "ResourceIdByDeletedVault";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = RemoveVaultParameterSet,
            HelpMessage = "Specifies the name of the key vault to remove.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = RemoveDeletedVaultParameterSet,
            HelpMessage = "Specifies the name of the key vault to remove.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string VaultName { get; set; }

        /// <summary>
        /// Vault object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectRemoveVaultParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Key Vault object to be deleted.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectRemoveDeletedVaultParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Key Vault object to be deleted.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        /// <summary>
        /// Vault Resource Id
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ResourceIdRemoveVaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "KeyVault Resource Id.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ResourceIdRemoveDeletedVaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "KeyVault Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Resource group to which the vault belongs.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = RemoveVaultParameterSet,
            HelpMessage = "Specifies the name of resource group for Azure key vault to remove.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false,
            Position = 2,
            ParameterSetName = RemoveVaultParameterSet,
            HelpMessage = "The location of the deleted vault.")]
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ResourceIdRemoveVaultParameterSet,
            HelpMessage = "The location of the deleted vault.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = RemoveDeletedVaultParameterSet,
            HelpMessage = "The location of the deleted vault.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = ResourceIdRemoveDeletedVaultParameterSet,
            HelpMessage = "The location of the deleted vault.")]
        [LocationCompleter("Microsoft.KeyVault/vaults")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        /// <summary>
        /// If present, operate on the deleted vault entity.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveDeletedVaultParameterSet,
            HelpMessage = "Remove the previously deleted vault permanently.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectRemoveDeletedVaultParameterSet,
            HelpMessage = "Remove the previously deleted vault permanently.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdRemoveDeletedVaultParameterSet,
            HelpMessage = "Remove the previously deleted vault permanently.")]
        public SwitchParameter InRemovedState { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "Indicates that the cmdlet does not prompt you for confirmation. By default, this cmdlet prompts you to confirm that you want to delete the key vault.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false,
           HelpMessage = "This Cmdlet does not return an object by default. If this switch is specified, it returns true if successful.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
      {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                ResourceGroupName = InputObject.ResourceGroupName;
                Location = InputObject.Location;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                VaultName = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (InRemovedState)
            {
                ConfirmAction(
                        Force.IsPresent,
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.PurgeVaultWarning,
                            VaultName),
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.PurgeVaultWhatIfMessage,
                            VaultName),
                        VaultName,
                        () =>
                        {
                            KeyVaultManagementClient.PurgeVault(
                                vaultName: VaultName,
                                location: Location);

                            if (PassThru)
                            {
                                WriteObject(true); 
                            }
                        });
            }
            else
            {
                ResourceGroupName = string.IsNullOrWhiteSpace(ResourceGroupName) ? GetResourceGroupName(VaultName) : ResourceGroupName;
                if (string.IsNullOrWhiteSpace(ResourceGroupName))
                    throw new ArgumentException(string.Format(Resources.VaultNotFound, VaultName, ResourceGroupName));
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.RemoveVaultWarning,
                        VaultName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.RemoveVaultWhatIfMessage,
                        VaultName),
                    VaultName,
                    () =>
                    {
                        KeyVaultManagementClient.DeleteVault(
                    vaultName: VaultName,
                    resourceGroupName: this.ResourceGroupName);

                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
            }
        }
    }
}
