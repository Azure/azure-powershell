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
    [Cmdlet("Wait", "AzureBackupJob", DefaultParameterSetName = "IdFiltersSet"), OutputType(typeof(Mgmt.Job))]
    public class WaitAzureBackupJob : AzureBackupVaultCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.Vault, ParameterSetName = "IdFiltersSet")]
        [ValidateNotNull]
        public AzurePSBackupVault Vault { get; set; }

        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.WaitJobFilterJobIdHelpMessage, ValueFromPipeline = true, ParameterSetName = "IdFiltersSet")]
        [ValidateNotNull]
        public object JobID { get; set; }

        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.WaitJobFilterJobHelpMessage, ValueFromPipeline = true, ParameterSetName = "JobFiltersSet")]
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
                WriteDebug("Job is PowershellObject: " + (Job is PSObject));
                WriteDebug("Job type: " + Job.GetType());

                if ((Job is PSObject) && (((PSObject)Job).ImmediateBaseObject is List<AzureBackupJob>))
                {
                    WriteDebug("Type of input paramter is List<AzureBackupJob>");
                    foreach (AzureBackupJob jobToWait in ((Job as PSObject).ImmediateBaseObject as List<AzureBackupJob>))
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
            }

            if(JobID != null)
            {
                WriteDebug("Type of immediate base object: " + ((PSObject)JobID).ImmediateBaseObject.GetType().ToString());
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
            else
            {
                WriteDebug("JobID is null");
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
            });
        }
    }
}