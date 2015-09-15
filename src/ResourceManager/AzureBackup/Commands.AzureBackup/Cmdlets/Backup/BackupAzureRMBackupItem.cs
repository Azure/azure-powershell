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
using MBS = Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Properties;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Backup Azue Backup Item
    /// </summary>
    [Cmdlet(VerbsData.Backup, "AzureRMBackupItem"), OutputType(typeof(AzureRMBackupJob))]
    public class BackupAzureRMBackupItem : AzureRMBackupDSCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                WriteDebug(Resources.MakingClientCall);
                Guid operationId = AzureBackupClient.TriggerBackup(Item.ResourceGroupName, Item.ResourceName, Item.ContainerUniqueName, Item.ItemName);

                WriteDebug(string.Format(Resources.TriggeringBackup, operationId));

                var operationStatus = TrackOperation(Item.ResourceGroupName, Item.ResourceName, operationId);
                WriteObject(GetCreatedJobs(Item.ResourceGroupName, Item.ResourceName, new Models.AzureRMBackupVault(Item.ResourceGroupName, Item.ResourceName, Item.Location), operationStatus.JobList).FirstOrDefault());
            });
        }
    }
}
