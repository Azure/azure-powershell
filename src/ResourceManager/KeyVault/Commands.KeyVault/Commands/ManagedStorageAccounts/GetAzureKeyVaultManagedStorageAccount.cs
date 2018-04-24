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
using Microsoft.Azure.Commands.KeyVault.Models.ManagedStorageAccounts;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet( VerbsCommon.Get, CmdletNoun.AzureKeyVaultManagedStorageAccount)]
    [OutputType( typeof( List<PSKeyVaultManagedStorageAccount> ), typeof( PSKeyVaultManagedStorageAccount ), typeof(List<PSDeletedKeyVaultManagedStorageAccountIdentityItem>), typeof(PSDeletedKeyVaultManagedStorageAccount) )]
    public class GetAzureKeyVaultManagedStorageAccount : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByAccountNameParameterSet = "ByAccountName";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter( Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter( Mandatory = false,
            Position = 1,
            ParameterSetName = ByAccountNameParameterSet,
            ValueFromPipelineByPropertyName = true,
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
            if (InRemovedState)
            {
                if (String.IsNullOrWhiteSpace(AccountName))
                {
                    GetAndWriteDeletedManagedStorageAccounts(VaultName);
                }
                else
                {
                    var storageAccount = DataServiceClient.GetDeletedManagedStorageAccount(VaultName, AccountName);
                    WriteObject(storageAccount);
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(AccountName))
                {
                    GetAndWriteManagedStorageAccounts(VaultName);
                }
                else
                {
                    var storageAccount = DataServiceClient.GetManagedStorageAccount(VaultName, AccountName);
                    WriteObject(storageAccount);
                }
            }
        }

        private void GetAndWriteManagedStorageAccounts( string vaultName )
        {
            var options = new KeyVaultObjectFilterOptions
            {
                VaultName = vaultName,
                NextLink = null
            };
            do
            {
                WriteObject( DataServiceClient.GetManagedStorageAccounts( options ), true );
            } while( !string.IsNullOrEmpty( options.NextLink ) );
        }

        private void GetAndWriteDeletedManagedStorageAccounts(string vaultName)
        {
            var options = new KeyVaultObjectFilterOptions
            {
                VaultName = vaultName,
                NextLink = null
            };
            do
            {
                WriteObject(DataServiceClient.GetDeletedManagedStorageAccounts(options), true);
            } while (!string.IsNullOrEmpty(options.NextLink));
        }
    }
}
