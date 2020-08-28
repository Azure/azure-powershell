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
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.KeyVault
{
    [GenericBreakingChange("If you have soft - delete protection enabled on this key vault, this key will be moved to the soft deleted state. " +
        "You will not be able to create a key with the same name within this key vault until the key has been purged from the soft-deleted state. " +
        "Please see the following documentation for additional guidance.https://docs.microsoft.com/en-us/azure/key-vault/general/soft-delete-overview")]
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKey",SupportsShouldProcess = true,DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSDeletedKeyVaultKey))]
    public class RemoveAzureKeyVaultKey : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// key name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// KeyBundle object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = ByInputObjectParameterSet,
            HelpMessage = "Key Object")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultKeyIdentityItem InputObject { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Cmdlet does not return an object by default. If this switch is specified, the cmdlet returns the key object that was deleted.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// If present, operate on the deleted key entity.
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "Remove the previously deleted key permanently.")]
        public SwitchParameter InRemovedState { get; set; }

        #endregion
        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName.ToString();
                Name = InputObject.Name.ToString();
            }

            if (InRemovedState.IsPresent)
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.RemoveDeletedKeyWarning,
                        Name),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.RemoveDeletedKeyWhatIfMessage,
                        Name),
                    Name,
                    () => { DataServiceClient.PurgeKey(VaultName, Name); });
                return;
            }

            PSDeletedKeyVaultKey deletedKeyBundle = null;
            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.RemoveKeyWarning,
                    Name),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.RemoveKeyWhatIfMessage,
                    Name),
                Name,
                () => { deletedKeyBundle = DataServiceClient.DeleteKey(VaultName, Name); });

            if (PassThru)
            {
                WriteObject(deletedKeyBundle);
            }
        }
    }
}
