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

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    // ToDo:
    // Correct the Commandlet
    // Correct the OperationResponse
    // Get Tracking API from Piyush and Get JobResponse
    // Get JobResponse Object from Aditya

    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsData.Backup, "AzureBackupItem"), OutputType(typeof(Guid))]
    public class TriggerAzureBackup : AzureBackupDSCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteVerbose("Making client call");
                Guid jobId = Guid.Empty;
                MBS.OperationResponse triggerBackUpInfo =
                    AzureBackupClient.BackUp.TriggerBackUpAsync(GetCustomRequestHeaders(),
                    item.ContainerUniqueName,
                    item.Type,
                    item.DataSourceId,
                    CmdletCancellationToken).Result;

                WriteVerbose("Received backup response");
                
                WriteVerbose("Converting response");
                jobId = triggerBackUpInfo.OperationId;
                this.WriteObject(jobId);
            });
        }
    }
}
