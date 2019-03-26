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
using System;
using System.Collections.Generic;
using System.Management.Automation;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultManagedStorageAccount", DefaultParameterSetName = ByAccountNameParameterSet)]
    [OutputType( typeof(PSKeyVaultManagedStorageAccountIdentityItem), typeof(PSKeyVaultManagedStorageAccount), typeof(PSDeletedKeyVaultManagedStorageAccountIdentityItem), typeof(PSDeletedKeyVaultManagedStorageAccount) )]
    public class GetAzureKeyVaultManagedStorageAccount : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByAccountNameParameterSet = "ByAccountName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter( Mandatory = true,
            Position = 0,
            ParameterSetName = ByAccountNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Vault object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Vault object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        /// <summary>
        /// Vault ResourceId
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter( Mandatory = false,
            Position = 1,
            ParameterSetName = ByAccountNameParameterSet,
            HelpMessage = "Key Vault managed storage account name. Cmdlet constructs the FQDN of a managed storage account name from vault name, currently " +
                "selected environment and manged storage account name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.StorageAccountName, Constants.Name )]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Specifies whether to show the previously deleted storage accounts in the output.")]
        public SwitchParameter InRemovedState { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                VaultName = resourceIdentifier.ResourceName;
            }

            if (InRemovedState)
            {
                if (String.IsNullOrWhiteSpace(AccountName) || WildcardPattern.ContainsWildcardCharacters(AccountName))
                {
                    GetAndWriteDeletedManagedStorageAccounts(VaultName, AccountName);
                }
                else
                {
                    var storageAccount = DataServiceClient.GetDeletedManagedStorageAccount(VaultName, AccountName);
                    WriteObject(storageAccount);
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(AccountName) || WildcardPattern.ContainsWildcardCharacters(AccountName))
                {
                    GetAndWriteManagedStorageAccounts(VaultName, AccountName);
                }
                else
                {
                    var storageAccount = DataServiceClient.GetManagedStorageAccount(VaultName, AccountName);
                    WriteObject(storageAccount);
                }
            }
        }

        private void GetAndWriteManagedStorageAccounts( string vaultName, string name )
        {
            var options = new KeyVaultObjectFilterOptions
            {
                VaultName = vaultName,
                NextLink = null
            };
            do
            {
                WriteObject(KVSubResourceWildcardFilter(name, DataServiceClient.GetManagedStorageAccounts( options )), true );
            } while( !string.IsNullOrEmpty( options.NextLink ) );
        }

        private void GetAndWriteDeletedManagedStorageAccounts(string vaultName, string name)
        {
            var options = new KeyVaultObjectFilterOptions
            {
                VaultName = vaultName,
                NextLink = null
            };
            do
            {
                WriteObject(KVSubResourceWildcardFilter(name, DataServiceClient.GetDeletedManagedStorageAccounts(options)), true);
            } while (!string.IsNullOrEmpty(options.NextLink));
        }
    }
}
