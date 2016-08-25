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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Mgmt = Microsoft.Azure.Management.BackupServices.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    [Cmdlet("Wait", "AzureRmBackupJob"), OutputType(typeof(List<AzureRMBackupJob>), typeof(AzureRMBackupJob))]
    public class WaitAzureRMBackupJob : AzureBackupCmdletBase
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
            AzureRMBackupVault Vault = null;

            if (Job != null)
            {
                if ((Job is PSObject) && (((PSObject)Job).ImmediateBaseObject is List<AzureRMBackupJob>))
                {
                    foreach (AzureRMBackupJob jobToWait in (((PSObject)Job).ImmediateBaseObject as List<AzureRMBackupJob>))
                    {
                        Vault = new AzureRMBackupVault(jobToWait.ResourceGroupName, jobToWait.ResourceName, jobToWait.Location);
                        specifiedJobs.Add(jobToWait.InstanceId);
                    }
                }
                else if (Job is List<AzureRMBackupJob>)
                {
                    WriteDebug(Resources.AzureBackupJobInputType);
                    foreach (AzureRMBackupJob jobToWait in (Job as List<AzureRMBackupJob>))
                    {
                        Vault = new AzureRMBackupVault(jobToWait.ResourceGroupName, jobToWait.ResourceName, jobToWait.Location);
                        specifiedJobs.Add(jobToWait.InstanceId);
                    }
                }
                else if ((Job is PSObject) && (((PSObject)Job).ImmediateBaseObject is AzureRMBackupJob))
                {
                    AzureRMBackupJob azureJob = ((Job as PSObject).ImmediateBaseObject as AzureRMBackupJob);
                    Vault = new AzureRMBackupVault(azureJob.ResourceGroupName, azureJob.ResourceName, azureJob.Location);
                    specifiedJobs.Add(azureJob.InstanceId);
                }
                else if (Job is AzureRMBackupJob)
                {
                    Vault = new AzureRMBackupVault((Job as AzureRMBackupJob).ResourceGroupName, (Job as AzureRMBackupJob).ResourceName, (Job as AzureRMBackupJob).Location);
                    specifiedJobs.Add((Job as AzureRMBackupJob).InstanceId);
                }
                else if ((Job is PSObject) && (((PSObject)Job).ImmediateBaseObject is AzureRMBackupJobDetails))
                {
                    AzureRMBackupJob azureJob = ((Job as PSObject).ImmediateBaseObject as AzureRMBackupJobDetails);
                    Vault = new AzureRMBackupVault(azureJob.ResourceGroupName, azureJob.ResourceName, azureJob.Location);
                    specifiedJobs.Add(azureJob.InstanceId);
                }
                else if (Job is AzureRMBackupJobDetails)
                {
                    Vault = new AzureRMBackupVault((Job as AzureRMBackupJobDetails).ResourceGroupName, (Job as AzureRMBackupJobDetails).ResourceName, (Job as AzureRMBackupJobDetails).Location);
                    specifiedJobs.Add((Job as AzureRMBackupJobDetails).InstanceId);
                }
            }

            WriteDebug(String.Format(Resources.NumberOfJobsForWaiting, specifiedJobs.Count));

            if (specifiedJobs.Count == 0)
            {
                WriteDebug(Resources.QuittingWaitJob);
                return;
            }

            InitializeAzureBackupCmdlet(Vault);

            ExecutionBlock(() =>
            {
                if (!TimeOut.HasValue)
                {
                    TimeOut = Int64.MaxValue;
                }

                List<string> pendingJobs = new List<string>(specifiedJobs);
                DateTime waitingStartTime = DateTime.UtcNow;

                while (true)
                {
                    WriteDebug(Resources.QueryingJobs);

                    if (DateTime.UtcNow.Subtract(waitingStartTime).TotalSeconds >= TimeOut)
                    {
                        WriteDebug(Resources.TimeOutWaitInJob);
                        break;
                    }

                    bool areJobsRunning = false;

                    for (int i = 0; i < pendingJobs.Count; i++)
                    {
                        Mgmt.CSMJobDetailsResponse retrievedJob = AzureBackupClient.GetJobDetails(Vault.ResourceGroupName, Vault.Name, pendingJobs[i]);
                        if (AzureBackupJobHelper.IsJobRunning(retrievedJob.JobDetailedProperties.Status))
                            areJobsRunning = true;
                        else
                        {
                            pendingJobs.RemoveAt(i);
                            i--;
                        }
                    }

                    if (!areJobsRunning)
                    {
                        WriteDebug(Resources.AllJobsCompleted);
                        break;
                    }

                    TestMockSupport.Delay(30 * 1000);
                }

                IList<AzureRMBackupJob> finalJobs = new List<AzureRMBackupJob>();
                foreach (string jobId in specifiedJobs)
                {
                    Mgmt.CSMJobDetailsResponse retrievedJob = AzureBackupClient.GetJobDetails(Vault.ResourceGroupName, Vault.Name, jobId);
                    finalJobs.Add(new AzureRMBackupJob(Vault, retrievedJob.JobDetailedProperties, retrievedJob.Name));
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