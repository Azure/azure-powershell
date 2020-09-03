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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [CmdletOutputBreakingChange(typeof(PSKeyVaultSecret), "3.0.0", DeprecatedOutputProperties = new String[] { "SecretValueText" })]
    [Cmdlet("Undo", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultSecretRemoval",SupportsShouldProcess = true,DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSKeyVaultSecret))]
    public class UndoAzureKeyVaultSecretRemoval : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string DefaultParameterSet = "Default";
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

        /// <summary>
        /// Secret name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.SecretName)]
        public string Name { get; set; }

        /// <summary>
        /// Deleted secret object
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = InputObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "Deleted secret object")]
        [ValidateNotNullOrEmpty]
        public PSDeletedKeyVaultSecretIdentityItem InputObject { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                Name = InputObject.Name;
            }

            if (ShouldProcess(Name, Properties.Resources.RecoverSecret))
            {
                PSKeyVaultSecret secret = DataServiceClient.RecoverSecret(VaultName, Name);

                WriteObject(secret);
            }
        }
    }
}
