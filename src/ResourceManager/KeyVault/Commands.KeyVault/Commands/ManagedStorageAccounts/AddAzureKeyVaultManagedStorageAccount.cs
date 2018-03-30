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
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet( VerbsCommon.Add, CmdletNoun.AzureKeyVaultManagedStorageAccount,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSKeyVaultManagedStorageAccount))]
    public class AddAzureKeyVaultManagedStorageAccount : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter( Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key Vault managed storage account name. Cmdlet constructs the FQDN of a managed storage account name from vault name, currently " +
                          "selected environment and manged storage account name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.StorageAccountName, Constants.Name )]
        public string AccountName { get; set; }

        [Parameter( Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure resource id of the storage account." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.StorageAccountResourceId )]
        public string AccountResourceId { get; set; }

        [Parameter( Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the storage account key that must be used for generating sas tokens." )]
        [ValidateNotNullOrEmpty]
        public string ActiveKeyName { get; set; }

        [Parameter( Mandatory = false,
            HelpMessage = "Auto regenerate key. If true, then the managed storage account's inactive key gets auto regenerated and becomes the new active key " +
                          "after the regeneration period. If false, then the keys of managed storage account are not auto regenerated." )]
        public SwitchParameter DisableAutoRegenerateKey { get; set; }

        [Parameter( Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Regeneration period. If auto regenerate key is enabled, this value specifies the timespan after which managed storage account's inactive key" +
                          "gets auto regenerated and becomes the new active key." )]
        [ValidateNotNull]
        public TimeSpan? RegenerationPeriod { get; set; }

        [Parameter( Mandatory = false, 
            HelpMessage = "Disables the use of managed storage account's key for generation of sas tokens." )]
        public SwitchParameter Disable { get; set; }

        [Parameter( Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable representing tags of managed storage account." )]
        [Alias( Constants.TagsAlias )]
        public Hashtable Tag { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if ( ShouldProcess( AccountName, Properties.Resources.AddManagedStorageAccount ) )
            {
                var managedStorageAccount = DataServiceClient.SetManagedStorageAccount(
                    VaultName,
                    AccountName,
                    AccountResourceId,
                    ActiveKeyName,
                    !DisableAutoRegenerateKey.IsPresent,
                    RegenerationPeriod,
                    new PSKeyVaultManagedStorageAccountAttributes( !Disable.IsPresent ),
                    Tag );

                WriteObject( managedStorageAccount );
            }
        }
    }
}
