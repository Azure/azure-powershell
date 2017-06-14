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

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets.DataSource
{
    /// <summary>
    /// Disable Azure Backup protection
    /// </summary>
    [Cmdlet(VerbsLifecycle.Disable, "AzureRmBackupProtection", SupportsShouldProcess = true), OutputType(typeof(AzureRMBackupJob))]
    public class DisableAzureRMBackupProtection : AzureRMBackupDSCmdletBase
    {
        [Parameter(Position = 1, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.RemoveProtectionOption)]
        public SwitchParameter RemoveRecoveryPoints
        {
            get { return DeleteBackupData; }
            set { DeleteBackupData = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        private bool DeleteBackupData;

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.DisableProtectionWarning, Item.Name),
                Resources.DisableProtectionMessage,
                Item.Name, () =>
                {
                    ExecutionBlock(() =>
                    {
                        base.ExecuteCmdlet();
                        Guid operationId = Guid.Empty;
                        WriteDebug(Resources.MakingClientCall);

                        if (!this.DeleteBackupData)
                        {
                            //Calling update protection with policy Id as empty.
                            CSMUpdateProtectionRequest input = new CSMUpdateProtectionRequest()
                            {
                                Properties = new CSMUpdateProtectionRequestProperties(string.Empty)
                            };

                            operationId = AzureBackupClient.UpdateProtection(Item.ResourceGroupName, Item.ResourceName, Item.ContainerUniqueName, Item.ItemName, input);
                        }

                        else
                        {
                            //Calling disable protection
                            operationId = AzureBackupClient.DisableProtection(Item.ResourceGroupName, Item.ResourceName, Item.ContainerUniqueName, Item.ItemName);
                        }


                        WriteDebug(Resources.DisableAzureBackupProtection);
                        var operationStatus = TrackOperation(Item.ResourceGroupName, Item.ResourceName, operationId);
                        this.WriteObject(GetCreatedJobs(Item.ResourceGroupName,
                            Item.ResourceName,
                            new Models.AzureRMBackupVault(Item.ResourceGroupName, Item.ResourceName, Item.Location),
                            operationStatus.JobList).FirstOrDefault());
                    });
                });
        }
    }
}