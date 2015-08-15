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
using System.Web;
using Microsoft.Azure.Management.BackupServices;
using Mgmt = Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of jobs pertaining to the filters specified. Gets list of all jobs created in the last 24 hours if no filters are specified.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRMBackupJob", DefaultParameterSetName = "FiltersSet"), OutputType(typeof(List<AzureRMBackupJob>), typeof(AzureRMBackupJob))]
    public class GetAzureRMBackupJob : AzureBackupCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.Vault, ParameterSetName = "FiltersSet", ValueFromPipeline = true)]
        [ValidateNotNull]
        public AzureRMBackupVault Vault { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.JobFilterJobIdHelpMessage, ParameterSetName = "FiltersSet")]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.JobFilterJobHelpMessage, ParameterSetName = "JobsListFilter")]
        [ValidateNotNull]
        public AzureRMBackupJob Job { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.JobFilterStartTimeHelpMessage, ParameterSetName = "FiltersSet")]
        [ValidateNotNull]
        public DateTime? From { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.JobFilterEndTimeHelpMessage, ParameterSetName = "FiltersSet")]
        [ValidateNotNull]
        public DateTime? To { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.JobFilterStatusHelpMessage, ParameterSetName = "FiltersSet")]
        [ValidateSet("Cancelled", "Cancelling", "Completed", "CompletedWithWarnings", "Failed", "InProgress")]
        public string Status { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.JobFilterTypeHelpMessage, ParameterSetName = "FiltersSet")]
        [ValidateSet("IaasVM")]
        public string Type { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.JobFilterOperationHelpMessage, ParameterSetName = "FiltersSet")]
        [ValidateSet("Backup", "ConfigureBackup", "DeleteBackupData", "Register", "Restore", "UnProtect", "Unregister")]
        public string Operation { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (Job != null)
                {
                    Vault = new AzureRMBackupVault(Job.ResourceGroupName, Job.ResourceName, Job.Location);
                }

                InitializeAzureBackupCmdlet(Vault);

                if (Job != null)
                {
                    JobId = Job.InstanceId;
                }

                // validations
                if (!From.HasValue)
                {
                    if (To.HasValue)
                    {
                        throw new Exception("Please specify both From and To.");
                    }
                    WriteDebug("Setting StartTime to min value.");
                    From = new DateTime();
                    From = AzureBackupJobHelper.MinimumAllowedDate;
                }

                if (To.HasValue && To.Value > From.Value)
                {
                    // everything is good. don't do anything
                }
                else if (To.HasValue && To.Value <= From.Value)
                {
                    throw new Exception("From should be lesser than To.");
                }
                else
                {
                    if (From != AzureBackupJobHelper.MinimumAllowedDate)
                    {
                        WriteDebug("End time not set. Setting it to current time.");
                        To = DateTime.Now;
                    }
                    else
                    {
                        WriteDebug("Setting EndTime to min value.");
                        To = new DateTime();
                        To = AzureBackupJobHelper.MinimumAllowedDate;
                    }
                }

                From = TimeZoneInfo.ConvertTimeToUtc(From.Value);
                To = TimeZoneInfo.ConvertTimeToUtc(To.Value);

                // if user hasn't specified any filters, then default filter fetches
                // all jobs that were created in last 24 hours.
                if (From == AzureBackupJobHelper.MinimumAllowedDate && To == AzureBackupJobHelper.MinimumAllowedDate &&
                    string.IsNullOrEmpty(Operation) && string.IsNullOrEmpty(Status) &&
                    string.IsNullOrEmpty(Type) && string.IsNullOrEmpty(JobId))
                {
                    From = DateTime.UtcNow.AddDays(-1);
                    To = DateTime.UtcNow;
                }

                WriteDebug("StartTime filter is: " + System.Uri.EscapeDataString(From.Value.ToString("yyyy-MM-dd hh:mm:ss tt")));
                WriteDebug("EndTime filter is: " + System.Uri.EscapeDataString(To.Value.ToString("yyyy-MM-dd hh:mm:ss tt")));
                WriteDebug("Operation filter is: " + Operation);
                WriteDebug("Status filter is: " + Status);
                WriteDebug("Type filter is: " + Type);
                WriteDebug("JobID filter is: " + JobId);

                Mgmt.CSMJobQueryObject queryParams = new Mgmt.CSMJobQueryObject()
                {
                    StartTime = From.Value.ToString("yyyy-MM-dd hh:mm:ss tt"),
                    EndTime = To.Value.ToString("yyyy-MM-dd hh:mm:ss tt"),
                    Operation = Operation,
                    Status = Status,
                    WorkloadType = Type,
                    Name = JobId
                };

                var jobsList = AzureBackupClient.ListJobs(queryParams);
                List<AzureRMBackupJob> retrievedJobs = new List<AzureRMBackupJob>();

                foreach (Mgmt.CSMJobResponse serviceJob in jobsList)
                {
                    // TODO: Initialize vault from Job object when vault is made optional
                    retrievedJobs.Add(new AzureRMBackupJob(Vault, serviceJob.Properties, serviceJob.Name));
                }

                WriteDebug("Successfully retrieved all jobs. Number of jobs retrieved: " + retrievedJobs.Count());

                if (retrievedJobs.Count == 1)
                {
                    WriteObject(retrievedJobs.First());
                }
                else
                {
                    WriteObject(retrievedJobs);
                }
            });
        }
    }
}

