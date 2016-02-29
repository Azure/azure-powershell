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

using Microsoft.Azure.Commands.AzureBackup.Helpers;
using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System;
using System.Management.Automation;
using CmdletModel = Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Command to update an azure backup vault in a subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmBackupVault"), OutputType(typeof(CmdletModel.AzureRMBackupVault))]
    public class SetAzureRMBackupVault : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 1, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.StorageType)]
        public AzureBackupVaultStorageType Storage { get; set; }

        // TODO: Add support for tags
        //[Alias("Tags")]
        //[Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ResourceTags)]
        //public Hashtable[] Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                if (Storage != 0)
                {
                    WriteDebug(String.Format(Resources.SettingStorageType, Storage));

                    AzureBackupClient.UpdateStorageType(Vault.ResourceGroupName, Vault.Name, Storage.ToString());
                }

                var backupVault = AzureBackupClient.GetVault(Vault.ResourceGroupName, Vault.Name);
                WriteObject(VaultHelpers.GetCmdletVault(backupVault, AzureBackupClient.GetStorageTypeDetails(Vault.ResourceGroupName, Vault.Name)));
            });
        }
    }
}
