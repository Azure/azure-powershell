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

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet( VerbsCommon.Get, CmdletNoun.AzureKeyVaultManagedStorageAccount,
        DefaultParameterSetName = ByVaultNameParameterSet,
        HelpUri = Constants.KeyVaultHelpUri )]
    [OutputType( typeof( List<ManagedStorageAccount> ), typeof( ManagedStorageAccount ) )]
    public class GetAzureKeyVaultManagedStorageAccount : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByAccountNameParameterSet = "ByAccountName";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter( Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByAccountNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [Parameter( Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter( Mandatory = true,
            Position = 1,
            ParameterSetName = ByAccountNameParameterSet,
            ValueFromPipelineByPropertyName = true,
                        HelpMessage = "Key Vault managed storage account name. Cmdlet constructs the FQDN of a managed storage account name from vault name, currently " +
                          "selected environment and manged storage account name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.StorageAccountName, Constants.Name )]
        public string AccountName { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            switch( ParameterSetName )
            {
                case ByAccountNameParameterSet:
                    var storageAccount = DataServiceClient.GetManagedStorageAccount( VaultName, AccountName );
                    WriteObject( storageAccount );
                    break;
                case ByVaultNameParameterSet:
                    GetAndWriteManagedStorageAccount( VaultName );
                    break;

                default:
                    throw new ArgumentException( KeyVaultProperties.Resources.BadParameterSetName );
            }
        }

        private void GetAndWriteManagedStorageAccount( string vaultName )
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
    }
}
