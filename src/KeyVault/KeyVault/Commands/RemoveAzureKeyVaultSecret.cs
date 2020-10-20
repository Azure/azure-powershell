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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [GenericBreakingChange("If you have soft-delete protection enabled on this key vault, this secret will be moved to the soft deleted state. " +
        "You will not be able to create a secret with the same name within this key vault until the secret has been purged from the soft-deleted state. Please see the following documentation for additional guidance. " +
        "https://docs.microsoft.com/en-us/azure/key-vault/general/soft-delete-overview")]
    [CmdletOutputBreakingChange(typeof(PSDeletedKeyVaultSecret), "3.0.0", DeprecatedOutputProperties = new String[] { "SecretValueText" })]
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultSecret",SupportsShouldProcess = true,DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSDeletedKeyVaultSecret))]
    public class RemoveAzureKeyVaultSecret : KeyVaultCmdletBase
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
        /// Secret name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.SecretName)]
        public string Name { get; set; }

        /// <summary>
        /// Secret Object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Key Vault Secret Object")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultSecretIdentityItem InputObject { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Cmdlet does not return an object by default. If this switch is specified, cmdlet returns the secret that was deleted.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// If present, operate on the deleted secret entity.
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "If present, removes the previously deleted secret permanently.")]
        public SwitchParameter InRemovedState { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                Name = InputObject.Name;
            }

            if(InRemovedState.IsPresent)
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.RemoveDeletedSecretWarning,
                        Name),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.RemoveDeletedSecretWhatIfMessage,
                        Name),
                    Name,
                   () => { DataServiceClient.PurgeSecret(VaultName, Name); });
                return;
            }

            PSDeletedKeyVaultSecret deletedSecret = null;
            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.RemoveSecretWarning,
                    Name),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.RemoveSecretWhatIfMessage,
                    Name),
                Name,
               () => { deletedSecret = DataServiceClient.DeleteSecret(VaultName, Name); });

            if (PassThru)
            {
                WriteObject(deletedSecret);
            }
        }
    }
}
