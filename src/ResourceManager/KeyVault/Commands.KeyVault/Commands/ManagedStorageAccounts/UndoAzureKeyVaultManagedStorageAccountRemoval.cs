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

using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.Undo, "AzureKeyVaultManagedStorageAccountRemoval",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSKeyVaultManagedStorageAccount))]
    public class UndoAzureKeyVaultManagedStorageAccountRemoval : KeyVaultCmdletBase
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
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Secret name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Name of the KeyVault managed storage account. Cmdlet constructs the FQDN of the target from vault name, currently selected environment and the name of the managed storage account.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.StorageAccountName)]
        public string Name { get; set; }

        /// <summary>
        /// Managed storage account object
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = InputObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "Deleted Managed Storage Account object")]
        [ValidateNotNullOrEmpty]
        public PSDeletedKeyVaultManagedStorageAccountIdentityItem InputObject { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                Name = InputObject.Name;
            }

            if (ShouldProcess(Name, Properties.Resources.RecoverManagedStorageAccount))
            {
                var recoveredStorageAccount = DataServiceClient.RecoverManagedStorageAccount(VaultName, Name);

                WriteObject(recoveredStorageAccount);
            }
        }
    }
}
