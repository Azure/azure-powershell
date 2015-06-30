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
using Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    [Cmdlet("Wait", "AzureBackupJob"), OutputType(typeof(Mgmt.Job))]
    public class WaitAzureBackupJob : AzureBackupCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.WaitJobFilterJobHelpMessage, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public object Job { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.WaitJobFilterTimeoutHelpMessage)]
        [ValidateRange(1, Int64.MaxValue)]
        public long? TimeOut { get; set; }

        public override void ExecuteCmdlet()
        {
            List<string> specifiedJobs = new List<string>();
            AzurePSBackupVault Vault = null;

            if (Job != null)
            {
                if ((Job is PSObject) && (((PSObject)Job).ImmediateBaseObject is List<AzureBackupJob>))
                {
                    foreach (AzureBackupJob jobToWait in (((PSObject)Job).ImmediateBaseObject as List<AzureBackupJob>))
                    {
                        Vault = new AzurePSBackupVault(jobToWait.ResourceGroupName, jobToWait.ResourceName, jobToWait.Location);
                        specifiedJobs.Add(jobToWait.InstanceId);
                    }
                }
                else if (Job is List<AzureBackupJob>)
                {
                    WriteDebug("Type of input paramter is List<AzureBackupJob> second case");
                    foreach (AzureBackupJob jobToWait in (Job as List<AzureBackupJob>))
                    {
                        Vault = new AzurePSBackupVault(jobToWait.ResourceGroupName, jobToWait.ResourceName, jobToWait.Location);
                        specifiedJobs.Add(jobToWait.InstanceId);
                    }
                }
                else if ((Job is PSObject) && (((PSObject)Job).ImmediateBaseObject is AzureBackupJob))
                {
                    AzureBackupJob azureJob = ((Job as PSObject).ImmediateBaseObject as AzureBackupJob);
                    Vault = new AzurePSBackupVault(azureJob.ResourceGroupName, azureJob.ResourceName, azureJob.Location);
                    specifiedJobs.Add(azureJob.InstanceId);
                }
                else if (Job is AzureBackupJob)
                {
                    Vault = new AzurePSBackupVault((Job as AzureBackupJob).ResourceGroupName, (Job as AzureBackupJob).ResourceName, (Job as AzureBackupJob).Location);
                    specifiedJobs.Add((Job as AzureBackupJob).InstanceId);
                }
                else if ((Job is PSObject) && (((PSObject)Job).ImmediateBaseObject is AzureBackupJobDetails))
                {
                    AzureBackupJob azureJob = ((Job as PSObject).ImmediateBaseObject as AzureBackupJobDetails);
                    Vault = new AzurePSBackupVault(azureJob.ResourceGroupName, azureJob.ResourceName, azureJob.Location);
                    specifiedJobs.Add(azureJob.InstanceId);
                }
                else if (Job is AzureBackupJobDetails)
                {
                    Vault = new AzurePSBackupVault((Job as AzureBackupJobDetails).ResourceGroupName, (Job as AzureBackupJobDetails).ResourceName, (Job as AzureBackupJobDetails).Location);
                    specifiedJobs.Add((Job as AzureBackupJobDetails).InstanceId);
                }
            }

            WriteDebug("Number of jobs to wait on: " + specifiedJobs.Count);

            if (specifiedJobs.Count == 0)
            {
                WriteDebug("No jobs to wait on. Quitting.");
                return;
            }

            InitializeAzureBackupCmdlet(Vault);

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
                    WriteDebug("In loop querying jobs");

                    if (DateTime.UtcNow.Subtract(waitingStartTime).TotalSeconds >= TimeOut)
                    {
                        WriteDebug("Exiting due to timeout.");
                        break;
                    }

                    bool areJobsRunning = false;

                    for (int i = 0; i < pendingJobs.Count; i++)
                    {
                        Mgmt.Job retrievedJob = AzureBackupClient.GetJobDetails(pendingJobs[i]).Job;
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

                IList<AzureBackupJob> finalJobs = new List<AzureBackupJob>();
                foreach(string jobId in specifiedJobs)
                {
                    finalJobs.Add(new AzureBackupJob(Vault, AzureBackupClient.GetJobDetails(jobId).Job));
                }

                if (finalJobs.Count == 1)
                {
                    WriteObject(finalJobs.First());
                }
                else
                {
                    WriteObject(finalJobs);
                }
            });
        }
    }
}