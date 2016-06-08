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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of Azure Recovery Points
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmBackupRecoveryPoint"), OutputType(typeof(AzureRMBackupRecoveryPoint), typeof(List<AzureRMBackupRecoveryPoint>))]
    public class GetAzureRMBackupRecoveryPoint : AzureRMBackupDSCmdletBase
    {
        [Parameter(Position = 1, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.RecoveryPointId)]
        [ValidateNotNullOrEmpty]
        public string RecoveryPointId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteDebug(Resources.MakingClientCall);

                if (RecoveryPointId != null)
                {
                    CSMRecoveryPointResponse recoveryPointObject = AzureBackupClient.GetRecoveryPoint(Item.ResourceGroupName, Item.ResourceName, Item.ContainerUniqueName, Item.ItemName, RecoveryPointId);
                    if (recoveryPointObject != null)
                    {
                        WriteAzureBackupRecoveryPoint(recoveryPointObject, Item);
                    }
                    else
                    {
                        WriteDebug(string.Format(Resources.NoRpExist, RecoveryPointId));
                    }
                }
                else
                {
                    IEnumerable<CSMRecoveryPointResponse> recoveryPointListResponse = AzureBackupClient.ListRecoveryPoints(Item.ResourceGroupName, Item.ResourceName, Item.ContainerUniqueName, Item.ItemName);
                    if (recoveryPointListResponse != null &&
                        recoveryPointListResponse.Count<CSMRecoveryPointResponse>() > 0)
                    {
                        IEnumerable<CSMRecoveryPointResponse> recoveryPointObjects = recoveryPointListResponse.OrderByDescending(x => x.Properties.RecoveryPointTime);
                        if (recoveryPointObjects.Count<CSMRecoveryPointResponse>() > 1)
                        {
                            WriteAzureBackupRecoveryPoint(recoveryPointObjects, Item);
                        }
                        else
                        {
                            WriteAzureBackupRecoveryPoint(recoveryPointObjects.FirstOrDefault<CSMRecoveryPointResponse>(), Item);
                        }
                    }
                    else
                    {
                        WriteDebug(Resources.NoRpFound);
                    }
                }
            });
        }

        public void WriteAzureBackupRecoveryPoint(CSMRecoveryPointResponse sourceRecoverPoint, AzureRMBackupItem azureBackupItem)
        {
            this.WriteObject(new AzureRMBackupRecoveryPoint(sourceRecoverPoint, azureBackupItem));
        }

        public void WriteAzureBackupRecoveryPoint(IEnumerable<CSMRecoveryPointResponse> sourceRecoverPointList, AzureRMBackupItem azureBackupItem)
        {
            List<AzureRMBackupRecoveryPoint> targetList = new List<AzureRMBackupRecoveryPoint>();

            foreach (var sourceRecoverPoint in sourceRecoverPointList)
            {
                targetList.Add(new AzureRMBackupRecoveryPoint(sourceRecoverPoint, azureBackupItem));
            }

            this.WriteObject(targetList, true);
        }
    }
}

