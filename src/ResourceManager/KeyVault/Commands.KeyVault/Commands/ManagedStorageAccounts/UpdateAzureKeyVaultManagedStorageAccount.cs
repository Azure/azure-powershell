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
    [Cmdlet( VerbsData.Update, CmdletNoun.AzureKeyVaultManagedStorageAccount,
        SupportsShouldProcess = true)]
    [OutputType( typeof( PSKeyVaultManagedStorageAccount ) )]
    public class UpdateAzureKeyVaultManagedStorageAccount : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        [Parameter( Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
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

        [Parameter( Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Active key name. If not specified, the existing value of managed storage account's active key name remains unchanged" )]
        [ValidateNotNullOrEmpty]
        public string ActiveKeyName { get; set; }

        [Parameter( Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Auto regenerate key. If not specified, the existing value of auto regenerate key of managed storage account remains unchanged" )]
        [ValidateNotNull]
        public bool? AutoRegenerateKey { get; set; }

        [Parameter( Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Regeneration period. If auto regenerate key is enabled, this value specifies the timespan after which managed storage account's inactive key" +
                          "gets auto regenerated and becomes the active key. If not specified, the existing value of regeneration period of keys of managed storage " +
                          "account remains unchanged" )]
        [ValidateNotNull]
        public TimeSpan? RegenerationPeriod { get; set; }

        [Parameter( Mandatory = false,
            HelpMessage = "If present, enables a use of a managed storage account key for sas token generation if value is true. Disables use of a managed " +
                          "storage account key for sas token generation if value is false. If not specified, the existing value of the storage account's " +
                          "enabled/disabled state remains unchanged." )]
        [ValidateNotNull]
        public bool? Enable { get; set; }

        [Parameter( Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable representing tags of managed storage account. If not specified, the existing tags of the managed storage account remain " +
                          "unchanged. Remove tags by specifying an empty Hashtable." )]
        [Alias( Constants.TagsAlias )]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter( Mandatory = false,
           HelpMessage = "Cmdlet does not return object by default. If this switch is specified, return managed storage account object." )]
        public SwitchParameter PassThru { get; set; }

        #endregion
        public override void ExecuteCmdlet()
        {
            if( ShouldProcess( AccountName, Properties.Resources.SetManagedStorageAccountKeysAttribute ) )
            {
                var managedStorageAccount = DataServiceClient.UpdateManagedStorageAccount(
                    VaultName,
                    AccountName,
                    ActiveKeyName,
                    AutoRegenerateKey,
                    RegenerationPeriod,
                    new PSKeyVaultManagedStorageAccountAttributes( Enable ),
                    Tag);

                if( PassThru )
                {
                    WriteObject( managedStorageAccount );
                }
            }
        }
    }
}
