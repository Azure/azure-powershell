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
        public object JobID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.WaitJobFilterJobHelpMessage, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public object Job { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.WaitJobFilterTimeoutHelpMessage)]
        [ValidateRange(1, Int64.MaxValue)]
        public long? TimeOut { get; set; }

        public override void ExecuteCmdlet()
        {
            List<string> specifiedJobs = new List<string>();

            if (Job != null)
            {
                WriteDebug("Job is Powershell: " + (Job is PSObject));
                WriteDebug("Job type: " + Job.GetType());

                if ((Job is PSObject) && (((PSObject)Job).ImmediateBaseObject is List<AzureBackupJob>))
                {
                    WriteDebug("Type of input paramter is List<AzureBackupJob>");
                    foreach (AzureBackupJob jobToWait in ((Job as PSObject).ImmediateBaseObject as List<AzureBackupJob>))
                    {
                        this.ResourceGroupName = jobToWait.ResourceGroupName;
                        this.ResourceName = jobToWait.ResourceName;
                        this.Location = jobToWait.Location;

                        specifiedJobs.Add(jobToWait.InstanceId);
                    }
                }
                else if (Job is List<AzureBackupJob>)
                {
                    WriteDebug("Type of input paramter is List<AzureBackupJob> second case");
                    foreach (AzureBackupJob jobToWait in (Job as List<AzureBackupJob>))
                    {
                        this.ResourceGroupName = jobToWait.ResourceGroupName;
                        this.ResourceName = jobToWait.ResourceName;
                        this.Location = jobToWait.Location;

                        specifiedJobs.Add(jobToWait.InstanceId);
                    }
                }
                else if ((Job is PSObject) && (((PSObject)Job).ImmediateBaseObject is AzureBackupJob))
                {
                    AzureBackupJob azureJob = ((Job as PSObject).ImmediateBaseObject as AzureBackupJob);
                    this.ResourceGroupName = azureJob.ResourceGroupName;
                    this.ResourceName = azureJob.ResourceName;
                    this.Location = azureJob.Location;

                    specifiedJobs.Add(azureJob.InstanceId);
                }
                else if (Job is AzureBackupJob)
                {
                    this.ResourceName = (Job as AzureBackupJob).ResourceName;
                    this.ResourceGroupName = (Job as AzureBackupJob).ResourceGroupName;
                    this.Location = (Job as AzureBackupJob).Location;

                    specifiedJobs.Add((Job as AzureBackupJob).InstanceId);
                }
            }
            else
            {
                if ((JobID is PSObject) && (((PSObject)JobID).ImmediateBaseObject is List<string>))
                {
                    foreach (string idOfJobToWait in ((JobID as PSObject).ImmediateBaseObject as List<string>))
                    {
                        WriteDebug("Type of JobID filter is List<string>.");
                        specifiedJobs.Add(idOfJobToWait);
                    }
                }
                else if (JobID is List<string>)
                {
                    foreach (string idOfJobToWait in (JobID as List<string>))
                    {
                        WriteDebug("Type of JobID filter is List<string>.");
                        specifiedJobs.Add(idOfJobToWait);
                    }
                }
                else if ((JobID is PSObject) && (((PSObject)JobID).ImmediateBaseObject is string))
                {
                    WriteDebug("Type of JobID filter is string.");
                    specifiedJobs.Add((JobID as PSObject).ImmediateBaseObject as string);
                }
                else if (JobID is string)
                {
                    WriteDebug("Type of JobID filter is string.");
                    specifiedJobs.Add(JobID as string);
                }
            }

            WriteDebug("Number of jobs to wait on: " + specifiedJobs.Count);

            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                if (!TimeOut.HasValue)
                {
                    TimeOut = new long();
                    TimeOut = Int64.MaxValue;
                }

                List<string> pendingJobs = new List<string>(specifiedJobs);
                DateTime waitingStartTime = DateTime.UtcNow;

                while (true)
                {
                    if (DateTime.UtcNow.Subtract(waitingStartTime).TotalSeconds >= TimeOut)
                    {
                        WriteDebug("Exiting due to timeout.");
                        break;
                    }

                    bool areJobsRunning = false;

                    for (int i = 0; i < pendingJobs.Count; i++)
                    {
                        Mgmt.Job retrievedJob = AzureBackupClient.Job.GetAsync(pendingJobs[i], GetCustomRequestHeaders(), CmdletCancellationToken).Result.Job;
                        if (AzureBackupJobHelper.IsJobRunning(retrievedJob.Status))
                            areJobsRunning = true;
                        else
                        {
                            pendingJobs.RemoveAt(i);
                            i--;
                        }
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