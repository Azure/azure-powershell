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

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzurePrefix + "ManagedHsmKey", SupportsShouldProcess = true, DefaultParameterSetName = RemoveByKeyNameParameterSet)]
    [OutputType(typeof(PSDeletedKeyVaultKey))]
    public class RemoveAzureManagedHsmKey : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string RemoveByKeyNameParameterSet = "RemoveByKeyNameParameterSet";
        private const string RemoveByInputObjectParameterSet = "RemoveByInputObjectParameterSet";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// HSM name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = RemoveByKeyNameParameterSet,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        /// <summary>
        /// key name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = RemoveByKeyNameParameterSet,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from managed HSM name, currently selected environment and key name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// Key object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = RemoveByInputObjectParameterSet,
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
                HsmName = InputObject.VaultName;
                Name = InputObject.Name;
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
