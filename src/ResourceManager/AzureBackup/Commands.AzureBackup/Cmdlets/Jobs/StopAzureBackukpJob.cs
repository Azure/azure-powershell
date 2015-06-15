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
                this.ResourceGroupName = Job.ResourceGroupName;
                this.ResourceName = Job.ResourceName;
            }

            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                //if (JobID != null && Job != null)
                //{
                //    throw new Exception("Please use either JobID filter or Job filter but not both.");
                //}

                if (Job != null)
                {
                    JobID = Job.InstanceId;
                }

                WriteDebug("JobID is: " + JobID);
                Task<OperationResponse> cancelTask = AzureBackupClient.Job.StopAsync(JobID, GetCustomRequestHeaders(), CmdletCancellationToken);

                if (cancelTask.IsFaulted)
                {
                    WriteObject(cancelTask.Exception);
                }
                else
                {
                    OperationResponse opResponse = cancelTask.Result;
                    // TODO
                    // Call and wait until this  completes.
                    WriteDebug("OpID is : " + opResponse.OperationId);
                }
            });
        }
    }
}