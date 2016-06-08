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
using Microsoft.Azure.Commands.AzureBackup.Properties;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Enable Azure Backup protection
    /// </summary>
    [Cmdlet(VerbsLifecycle.Enable, "AzureRmBackupProtection"), OutputType(typeof(AzureRMBackupJob))]
    public class EnableAzureRMBackupProtection : AzureRMBackupItemCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.PolicyObject)]
        [ValidateNotNullOrEmpty]
        public AzureRMBackupProtectionPolicy Policy { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                WriteDebug(Resources.MakingClientCall);
                string itemName = string.Empty;

                CSMSetProtectionRequest input = new CSMSetProtectionRequest();
                input.Properties = new CSMSetProtectionRequestProperties();
                input.Properties.PolicyId = Policy.PolicyId;

                if (Item.GetType() == typeof(AzureRMBackupItem))
                {
                    itemName = (Item as AzureRMBackupItem).ItemName;
                }

                else if (Item.GetType() == typeof(AzureRMBackupContainer))
                {
                    WriteDebug(String.Format(Resources.ContainerTypeInput, Item.GetType()));

                    if ((Item as AzureRMBackupContainer).ContainerType == AzureBackupContainerType.AzureVM.ToString())
                    {
                        itemName = (Item as AzureRMBackupContainer).ContainerUniqueName;
                    }
                    else
                    {
                        throw new Exception(Resources.UnknownItemType);
                    }
                }

                else
                {
                    throw new Exception(Resources.UnknownItemType);
                }

                var operationId = AzureBackupClient.EnableProtection(Item.ResourceGroupName, Item.ResourceName, Item.ContainerUniqueName, itemName, input);
                WriteDebug(Resources.EnableAzureBackupProtection);

                var operationStatus = TrackOperation(Item.ResourceGroupName, Item.ResourceName, operationId);
                this.WriteObject(GetCreatedJobs(Item.ResourceGroupName,
                    Item.ResourceName,
                    new Models.AzureRMBackupVault(Item.ResourceGroupName, Item.ResourceName, Item.Location),
                    operationStatus.JobList).FirstOrDefault());
            });
        }
    }
}