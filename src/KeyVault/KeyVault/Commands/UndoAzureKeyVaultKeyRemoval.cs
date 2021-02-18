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
<<<<<<< HEAD
    [Cmdlet("Undo", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyRemoval",SupportsShouldProcess = true,DefaultParameterSetName = DefaultParameterSet)]
=======
    [Cmdlet("Undo", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyRemoval", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    [OutputType(typeof(PSKeyVaultKey))]
    public class UndoAzureKeyVaultKeyRemoval : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string DefaultParameterSet = "Default";
<<<<<<< HEAD
=======
        private const string HsmInteractiveParameterSet = "HsmInteractive";
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
        /// <summary>
        /// Secret name
=======
        [Parameter(Mandatory = true,
            ParameterSetName = HsmInteractiveParameterSet,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        /// <summary>
        /// Key name
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
<<<<<<< HEAD
=======
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = HsmInteractiveParameterSet)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// Key object
        /// </summary>
        [Parameter(Mandatory = true,
<<<<<<< HEAD
                   Position = 0,
                   ParameterSetName = InputObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "Deleted key object")]
=======
            Position = 0,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Deleted key object")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public PSDeletedKeyVaultKeyIdentityItem InputObject { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
<<<<<<< HEAD
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                Name = InputObject.Name;
            }

            if (ShouldProcess(Name, Properties.Resources.RecoverKey))
            {
                PSKeyVaultKey recoveredKey = DataServiceClient.RecoverKey(VaultName, Name);
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

                WriteObject(recoveredKey);
            }
        }
<<<<<<< HEAD
=======

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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
