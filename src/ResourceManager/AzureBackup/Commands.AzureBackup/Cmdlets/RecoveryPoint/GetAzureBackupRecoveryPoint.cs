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
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteVerbose("Making client call");

                RecoveryPointListResponse recoveryPointListResponse = 
                    AzureBackupClient.RecoveryPoint.ListAsync(GetCustomRequestHeaders(),
                    item.ContainerUniqueName,
                    item.Type,
                    item.DataSourceId,
                    CmdletCancellationToken).Result;

                WriteVerbose("Received recovery point response");
                
                IEnumerable<RecoveryPointInfo> recoveryPointObjects = null;
                if (Id != null)
                {
                    RecoveryPointInfo recoveryPointObject = null;
                    recoveryPointObjects = recoveryPointListResponse.RecoveryPoints.Objects.Where(x => x.InstanceId.Equals(Id, System.StringComparison.InvariantCultureIgnoreCase));
                    if (recoveryPointObjects != null && recoveryPointObjects.Any<RecoveryPointInfo>())
                    {
                        WriteVerbose("Converting response");
                        recoveryPointObject = recoveryPointObjects.FirstOrDefault<RecoveryPointInfo>();
                        WriteAzureBackupRecoveryPoint(recoveryPointObject, item);
                    }
                    else
                    {
                        WriteVerbose(string.Format("{0}{1}", "No recovery point exist with Id := ", Id));
                    }
                }
                else
                {
                    WriteVerbose("Converting response");
                    recoveryPointObjects = recoveryPointListResponse.RecoveryPoints.Objects.OrderByDescending(x => x.RecoveryPointTime);
                    WriteAzureBackupRecoveryPoint(recoveryPointObjects, item);
                }                
            });
        }

        public void WriteAzureBackupRecoveryPoint(RecoveryPointInfo sourceRecoverPoint, AzureBackupItem azureBackupItem)
        {
            this.WriteObject(new AzureBackupRecoveryPoint(sourceRecoverPoint, azureBackupItem));
        }

        public void WriteAzureBackupRecoveryPoint(IEnumerable<RecoveryPointInfo> sourceRecoverPointList, AzureBackupItem azureBackupItem)
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

