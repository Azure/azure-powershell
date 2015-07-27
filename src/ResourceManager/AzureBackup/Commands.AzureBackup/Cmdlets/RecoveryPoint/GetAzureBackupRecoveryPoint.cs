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

using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureBackupRecoveryPoint"), OutputType(typeof(AzureBackupRecoveryPoint), typeof(List<AzureBackupRecoveryPoint>))]
    public class GetAzureBackupRecoveryPoint : AzureBackupDSCmdletBase
    {
        [Parameter(Position = 1, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.RecoveryPointId)]
        [ValidateNotNullOrEmpty]
        public string RecoveryPointId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteDebug("Making client call");

                if (RecoveryPointId != null)
                {
                    CSMRecoveryPointResponse recoveryPointObject = AzureBackupClient.GetRecoveryPoint(Item.ContainerUniqueName, Item.ItemName, RecoveryPointId);
                    if (recoveryPointObject != null)
                    {
                        WriteAzureBackupRecoveryPoint(recoveryPointObject, Item);
                    }
                    else
                    {
                        WriteDebug(string.Format("{0}{1}", "No recovery point exist with Id := ", RecoveryPointId));
                    }
                }
                else
                {
                    IEnumerable<CSMRecoveryPointResponse> recoveryPointListResponse = AzureBackupClient.ListRecoveryPoints(Item.ContainerUniqueName, Item.ItemName);
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
                        WriteDebug("No recovery point found");
                    }
                }
            });
        }

        public void WriteAzureBackupRecoveryPoint(CSMRecoveryPointResponse sourceRecoverPoint, AzureBackupItem azureBackupItem)
        {
            this.WriteObject(new AzureBackupRecoveryPoint(sourceRecoverPoint, azureBackupItem));
        }

        public void WriteAzureBackupRecoveryPoint(IEnumerable<CSMRecoveryPointResponse> sourceRecoverPointList, AzureBackupItem azureBackupItem)
        {
            List<AzureBackupRecoveryPoint> targetList = new List<AzureBackupRecoveryPoint>();

            foreach (var sourceRecoverPoint in sourceRecoverPointList)
            {
                targetList.Add(new AzureBackupRecoveryPoint(sourceRecoverPoint, azureBackupItem));
            }

            this.WriteObject(targetList, true);
        }
    }
}

