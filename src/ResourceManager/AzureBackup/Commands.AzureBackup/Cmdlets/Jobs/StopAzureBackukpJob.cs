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
using Microsoft.Azure.Management.BackupServices;
using System.Threading.Tasks;
using Mgmt = Microsoft.Azure.Management.BackupServices.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Stop a running cancellable job
    /// </summary>
    [Cmdlet("Stop", "AzureBackupJob"), OutputType(typeof(Mgmt.Job))]
    public class StopAzureBackupJob : AzureBackupVaultCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.StopJobFilterJobIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string JobID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.StopJobFilterJobHelpMessage)]
        [ValidateNotNull]
        public AzureBackupJob Job { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.StopJobFilterVaultHelpMessage)]
        [ValidateNotNull]
        public object Vault { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Job != null)
            {
                InitializeAzureBackupCmdlet(Job.ResourceGroupName, Job.ResourceName, Job.Location);
            }

            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                if (Job != null)
                {
                    JobID = Job.InstanceId;
                }

                WriteDebug("JobID is: " + JobID);
                OperationResponse cancelTask = AzureBackupClient.Job.StopAsync(JobID, GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                var opStatus = AzureBackupClient.OperationStatus.GetAsync(cancelTask.OperationId.ToString(), GetCustomRequestHeaders()).Result;
                while (opStatus.OperationStatus != "Completed")
                {
                    WriteDebug("Waiting for the task to complete");
                    opStatus = AzureBackupClient.OperationStatus.GetAsync(cancelTask.OperationId.ToString(), GetCustomRequestHeaders()).Result;
                }
                // TODO:
                if (opStatus.OperationResult == "Failed")
                {
                    var errorRecord = new ErrorRecord(new Exception("Cannot cancel job."), opStatus.Message, ErrorCategory.InvalidOperation, null);
                    WriteError(errorRecord);
                }
                else
                {
                    WriteDebug("Triggered cancellation of job with JobID: " + JobID);
                }
            });
        }
    }
}