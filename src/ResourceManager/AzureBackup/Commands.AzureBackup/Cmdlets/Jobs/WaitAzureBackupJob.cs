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
using Mgmt = Microsoft.Azure.Management.BackupServices.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    [Cmdlet("Wait", "AzureBackupJob"), OutputType(typeof(Mgmt.Job))]
    public class WaitAzureBackupJob : AzureBackupVaultCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.WaitJobFilterJobIdHelpMessage, ValueFromPipeline = true)]
        [ValidateNotNull]
        public List<string> JobID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.WaitJobFilterJobHelpMessage, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public List<AzureBackupJob> Job { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.WaitJobFilterTimeoutHelpMessage)]
        [ValidateRange(1, Int64.MaxValue)]
        public long? TimeOut { get; set; }

        public override void ExecuteCmdlet()
        {
            // ValidateNotNullNotEmpty makes sure that there exists at least one element
            this.ResourceGroupName = Job[0].ResourceGroupName;
            this.ResourceName = Job[0].ResourceName;

            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                List<string> specifiedJobs = new List<string>();

                if (!TimeOut.HasValue)
                {
                    TimeOut = new long();
                    TimeOut = Int64.MaxValue;
                }

                //if (JobID != null && Job != null)
                //{
                //    foreach(string job in JobID)
                //    {
                //        WriteDebug("JobID: " + job);
                //    }
                //    foreach (AzureBackupJob job in Job)
                //    {
                //        WriteDebug("Job: " + job.InstanceId);
                //    }
                //    throw new Exception("Please use either JobID filter or Job filter but not both.");
                //}

                if(Job != null)
                {
                    foreach(AzureBackupJob inpJob in Job)
                    {
                        specifiedJobs.Add(inpJob.InstanceId);
                    }
                }
                else
                {
                    foreach(string jobID in JobID)
                    {
                        specifiedJobs.Add(jobID);
                    }
                }

                DateTime waitingStartTime = DateTime.UtcNow;

                while (true)
                {
                    if (DateTime.UtcNow.Subtract(waitingStartTime).TotalSeconds >= TimeOut)
                    {
                        WriteDebug("Exiting due to timeout.");
                        break;
                    }

                    bool areJobsRunning = false;

                    foreach (string jobId in specifiedJobs)
                    {
                        Mgmt.Job retrievedJob = AzureBackupClient.Job.GetAsync(jobId, GetCustomRequestHeaders(), CmdletCancellationToken).Result.Job;
                        if (AzureBackupJobHelper.IsJobRunning(retrievedJob.Status))
                            areJobsRunning = true;
                    }

                    if (!areJobsRunning)
                    {
                        WriteDebug("Exiting because all jobs have finished running.");
                        break;
                    }

                    System.Threading.Thread.Sleep(30 * 1000);
                }
            });
        }
    }
}