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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Undo", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyRemoval", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSKeyVaultKey))]
    public class UndoAzureKeyVaultKeyRemoval : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string DefaultParameterSet = "Default";
        private const string HsmInteractiveParameterSet = "HsmInteractive";
        private const string InputObjectParameterSet = "InputObject";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = HsmInteractiveParameterSet,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        /// <summary>
        /// Key name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = HsmInteractiveParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// Key object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Deleted key object")]
        [ValidateNotNullOrEmpty]
        public PSDeletedKeyVaultKeyIdentityItem InputObject { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            if (ShouldProcess(Name, Properties.Resources.RecoverKey))
            {
                PSKeyVaultKey recoveredKey;
                if (string.IsNullOrEmpty(HsmName))
                {
                    recoveredKey = DataServiceClient.RecoverKey(VaultName, Name);
                }
                else
                {
                    recoveredKey = this.Track2DataClient.RecoverManagedHsmKey(HsmName, Name);
                }

                WriteObject(recoveredKey);
            }
        }

        private void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                if (InputObject.IsHsm)
                {
                    HsmName = InputObject.VaultName;
                }
                else
                {
                    VaultName = InputObject.VaultName;
                }
                Name = InputObject.Name;
            }
        }
    }
}
