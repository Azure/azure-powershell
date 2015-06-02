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
        [Parameter(Position = 2, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName)]
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
                    AzureBackupItem.ContainerName,
                    AzureBackupItem.DataSourceType,
                    AzureBackupItem.DataSourceId,
                    CmdletCancellationToken).Result;

                WriteVerbose("Received policy response");
                WriteVerbose("Received policy response2");
                IEnumerable<RecoveryPointInfo> recoveryPointObjects = null;
                if (Id != null)
                {
                    recoveryPointObjects = recoveryPointListResponse.RecoveryPoints.Objects.Where(x => x.Name.Equals(Id, System.StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    recoveryPointObjects = recoveryPointListResponse.RecoveryPoints.Objects;
                }

                WriteVerbose("Converting response");
                WriteAzureBackupProtectionPolicy(recoveryPointObjects);
            });
        }

        public void WriteAzureBackupProtectionPolicy(RecoveryPointInfo sourceRecoverPoint)
        {
            // this needs to be uncommented once we have proper constructor
            //this.WriteObject(new AzureBackupRecoveryPoint(AzureBackupItem.ResourceGroupName, AzureBackupItem.ResourceName, sourceRecoverPoint));
        }

        public void WriteAzureBackupProtectionPolicy(IEnumerable<RecoveryPointInfo> sourceRecoverPointList)
        {
            List<AzureBackupRecoveryPoint> targetList = new List<AzureBackupRecoveryPoint>();

            foreach (var sourceRecoverPoint in sourceRecoverPointList)
            {
                // this needs to be uncommented once we have proper constructor
                //targetList.Add(new AzureBackupRecoveryPoint(AzureBackupItem.ResourceGroupName, AzureBackupItem.ResourceName, sourceRecoverPoint));
            }

            this.WriteObject(targetList, true);
        }
    }
}

