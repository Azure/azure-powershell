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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Undo", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultRemoval",SupportsShouldProcess = true,DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSKeyVault))]
    public class UndoAzureKeyVaultRemoval : KeyVaultManagementCmdletBase
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
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Vault object
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = InputObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "Deleted vault object")]
        [ValidateNotNullOrEmpty]
        public PSDeletedKeyVault InputObject { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Specifies the name of the deleted vault resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 2,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Specifies the deleted vault original Azure region.")]
        [LocationCompleter("Microsoft.KeyVault/vaults")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                Location = InputObject.Location;
                var resourceIdentifier = new ResourceIdentifier(InputObject.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (ShouldProcess(VaultName, Properties.Resources.RecoverVault))
            {
                var newVault = KeyVaultManagementClient.CreateNewVault(new VaultCreationOrUpdateParameters()
                {
                    Name = this.VaultName,
                    ResourceGroupName = this.ResourceGroupName,
                    Location = this.Location,
                    Tags = this.Tag,
                    CreateMode = CreateMode.Recover
                });

                this.WriteObject(newVault);
            }
        }
    }
}
