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
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKey", SupportsShouldProcess = true, DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSDeletedKeyVaultKey))]
    public class RemoveAzureKeyVaultKey : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string HsmByVaultNameParameterSet = "HsmByVaultName";

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

        [Parameter(Mandatory = true,
            ParameterSetName = HsmByVaultNameParameterSet,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        /// <summary>
        /// key name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = HsmByVaultNameParameterSet)]
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
            NormalizeParameterSets();

            if (string.IsNullOrEmpty(HsmName))
            {
                RemoveKeyVaultKey();
            }
            else
            {
                RemoveHsmKey();
            }
        }

        private void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                if (InputObject.IsHsm)
                {
                    HsmName = InputObject.VaultName.ToString();
                }
                else
                {
                    VaultName = InputObject.VaultName.ToString();
                }
                Name = InputObject.Name.ToString();
            }
        }

        private void RemoveKeyVaultKey()
        {
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

        private void RemoveHsmKey()
        {
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
                    () => { this.Track2DataClient.PurgeManagedHsmKey(HsmName, Name); });
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
                () => { deletedKeyBundle = this.Track2DataClient.DeleteManagedHsmKey(HsmName, Name); });

            if (PassThru)
            {
                WriteObject(deletedKeyBundle);
            }
        }
    }
}
