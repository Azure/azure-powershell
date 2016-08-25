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
using Microsoft.Azure.Management.BackupServices;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Stop a running cancellable job
    /// </summary>
    [Cmdlet("Stop", "AzureRmBackupJob")]
    public class StopAzureRMBackupJob : AzureBackupCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.Vault, ParameterSetName = "IdFiltersSet")]
        [ValidateNotNull]
        public AzureRMBackupVault Vault { get; set; }

        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.StopJobFilterJobIdHelpMessage, ParameterSetName = "IdFiltersSet")]
        [ValidateNotNullOrEmpty]
        public string JobID { get; set; }

        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.StopJobFilterJobHelpMessage, ParameterSetName = "JobFiltersSet", ValueFromPipeline = true)]
        [ValidateNotNull]
        public AzureRMBackupJob Job { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Job != null)
            {
                Vault = new AzureRMBackupVault(Job.ResourceGroupName, Job.ResourceName, Job.Location);
            }

            InitializeAzureBackupCmdlet(Vault);

            ExecutionBlock(() =>
            {
                if (Job != null)
                {
                    JobID = Job.InstanceId;
                }

                WriteDebug(String.Format(Resources.JobId, JobID));
                Guid cancelTaskId = AzureBackupClient.TriggerCancelJob(Vault.ResourceGroupName, Vault.Name, JobID);

                if (cancelTaskId == Guid.Empty)
                {
                    WriteDebug(String.Format(Resources.TriggeredCancellationJob, JobID));
                    return;
                }

                CSMOperationResult opResponse = TrackOperation(Vault.ResourceGroupName, Vault.Name, cancelTaskId);

                if (opResponse.Status == CSMAzureBackupOperationStatus.Succeeded.ToString())
                {
                    WriteDebug(String.Format(Resources.TriggeredCancellationJob, JobID));
                }
                else
                {
                    throw new Exception(String.Format(Resources.StopJobFailed, opResponse.Error.Code));
                }
            });
        }
    }
}