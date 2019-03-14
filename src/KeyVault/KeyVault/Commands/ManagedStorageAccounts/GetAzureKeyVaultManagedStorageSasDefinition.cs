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
using System;
using System.Collections.Generic;
using System.Management.Automation;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultManagedStorageSasDefinition", DefaultParameterSetName = ByDefinitionNameParameterSet)]
    [OutputType( typeof(PSKeyVaultManagedStorageSasDefinitionIdentityItem), typeof(PSKeyVaultManagedStorageSasDefinition), typeof(PSDeletedKeyVaultManagedStorageSasDefinition), typeof(PSDeletedKeyVaultManagedStorageSasDefinitionIdentityItem) )]
    public class GetAzureKeyVaultManagedStorageSasDefinition : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByDefinitionNameParameterSet = "ByDefinitionName";
        private const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter( Mandatory = true,
            Position = 0,
            ParameterSetName = ByDefinitionNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter( Mandatory = true,
            Position = 1,
            ParameterSetName = ByDefinitionNameParameterSet,
            HelpMessage = "Key Vault managed storage account name. Cmdlet constructs the FQDN of a managed storage account name from vault name, currently " +
                    "selected environment and manged storage account name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.StorageAccountName )]
        public string AccountName { get; set; }

        /// <summary>
        /// PSKeyVaultManagedStorageAccountIdentityItem object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "ManagedStorageAccount object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultManagedStorageAccountIdentityItem InputObject { get; set; }

        [Parameter( Mandatory = false,
            Position = 2,
            HelpMessage = "Storage sas definition name. Cmdlet constructs the FQDN of a storage sas definition from vault name, currently " +
                          "selected environment, storage account name and sas definition name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.SasDefinitionName )]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Specifies whether to show the previously deleted storage sas definitions in the output.")]
        public SwitchParameter InRemovedState { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                AccountName = InputObject.AccountName;
            }

            if (InRemovedState)
            {
                if (String.IsNullOrWhiteSpace(Name) || WildcardPattern.ContainsWildcardCharacters(Name))
                {
                    GetAndWriteDeletedStorageSasDefinitions(VaultName, AccountName, Name);
                }
                else
                {
                    var sasDefinition = DataServiceClient.GetDeletedManagedStorageSasDefinition(VaultName, AccountName, Name);
                    WriteObject(sasDefinition);
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(Name) || WildcardPattern.ContainsWildcardCharacters(Name))
                {
                    GetAndWriteStorageSasDefinitions(VaultName, AccountName, Name);
                }
                else
                {
                    var sasDefinition = DataServiceClient.GetManagedStorageSasDefinition(VaultName, AccountName, Name);
                    WriteObject(sasDefinition);
                }
            }
        }

        private void GetAndWriteStorageSasDefinitions( string vaultName, string accountName, string name )
        {
            var options = new KeyVaultStorageSasDefinitiontFilterOptions
            {
                VaultName = vaultName,
                AccountName = accountName,
                NextLink = null
            };
            do
            {
                WriteObject(KVSubResourceWildcardFilter(name, DataServiceClient.GetManagedStorageSasDefinitions( options )), true );
            } while ( !string.IsNullOrEmpty( options.NextLink ) );
        }

        private void GetAndWriteDeletedStorageSasDefinitions(string vaultName, string accountName, string name)
        {
            var options = new KeyVaultStorageSasDefinitiontFilterOptions
            {
                VaultName = vaultName,
                AccountName = accountName,
                NextLink = null
            };

            do
            {
                WriteObject(KVSubResourceWildcardFilter(name, DataServiceClient.GetDeletedManagedStorageSasDefinitions(options)), true);
            } while (!string.IsNullOrEmpty(options.NextLink));
        }
    }
}
