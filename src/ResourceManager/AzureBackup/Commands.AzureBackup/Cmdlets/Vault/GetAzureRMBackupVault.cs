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
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Command to get azure backup vaults in a subscription
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmBackupVault"), OutputType(typeof(AzureRMBackupVault), typeof(List<AzureRMBackupVault>))]
    public class GetAzureRMBackupVault : AzureBackupCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();
                InitializeAzureBackupCmdlet(String.Empty, String.Empty);

                if (ResourceGroupName != null && Name != null)
                {
                    var backupVault = AzureBackupClient.GetVault(ResourceGroupName, Name);
                    WriteObject(VaultHelpers.GetCmdletVault(backupVault, AzureBackupClient.GetStorageTypeDetails(VaultHelpers.GetResourceGroup(backupVault.Id), backupVault.Name)));
                }
                else if (ResourceGroupName != null)
                {
                    var backupVaults = AzureBackupClient.GetVaultsInResourceGroup(ResourceGroupName);
                    WriteObject(GetCmdletVaults(backupVaults), true);
                }
                else
                {
                    var backupVaults = AzureBackupClient.GetVaults();

                    if (Name != null)
                    {
                        backupVaults = backupVaults.Where(x => x.Name.Equals(Name, StringComparison.InvariantCultureIgnoreCase));
                    }
                    WriteObject(GetCmdletVaults(backupVaults), true);
                }
            });
        }

        private IEnumerable<AzureRMBackupVault> GetCmdletVaults(IEnumerable<AzureBackupVault> backupVaults)
        {
            List<AzureRMBackupVault> resultList = new List<AzureRMBackupVault>();
            if (backupVaults != null)
            {
                foreach (var backupVault in backupVaults)
                {
                    resultList.Add(VaultHelpers.GetCmdletVault(backupVault, AzureBackupClient.GetStorageTypeDetails(VaultHelpers.GetResourceGroup(backupVault.Id), backupVault.Name)));
                }
            }

            return resultList;
        }
    }
}