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

using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.RecoveryServices;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    public abstract class AzureBackupVaultCmdletBase : AzureBackupCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.Vault, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public AzureRMBackupVault Vault { get; set; }
        //public VaultBase Vault { get; set; }

        //public AzureRMBackupVault Vault1 { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            //if (Vault.GetType() == typeof(ARSVault))
            //{
            //    var arsVault = (ARSVault)Vault;
            //    BackupVault = new AzureRMBackupVault();
            //    BackupVault.Name = arsVault.Name;
            //    BackupVault.Region = arsVault.Location;
            //    BackupVault.ResourceGroupName = arsVault.ResouceGroupName;
            //    BackupVault.ResourceId = arsVault.ID;
            //    BackupVault.Type = VaultType.ARSVault;
            //}
            //else if (Vault.GetType() == typeof(AzureRMBackupVault))
            //{
            //    BackupVault = (AzureRMBackupVault)Vault;
            //    BackupVault.Type = VaultType.BackupVault;
            //}

            Vault.Validate();

            InitializeAzureBackupCmdlet(Vault);
        }
    }
}