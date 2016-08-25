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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Gets the list of jobs associated with this recovery services vault 
    /// according to the filters passed via the cmdlet parameters.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesBackupJob"), 
    OutputType(typeof(JobBase), typeof(IList<JobBase>))]
    public class GetAzureRmRecoveryServicesBackupJob : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// Filter value for status of job.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Job.StatusFilter, Position = 1)]
        [ValidateNotNullOrEmpty]
        public JobStatus? Status { get; set; }

        /// <summary>
        /// Filter value for type of job.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Job.OperationFilter, Position = 2)]
        [ValidateNotNullOrEmpty]
        public JobOperation? Operation { get; set; }

        /// <summary>
        /// Beginning value of time range for which jobs have to be fetched.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Job.FromFilter, Position = 3)]
        [ValidateNotNull]
        public DateTime? From { get; set; }

        /// <summary>
        /// Ending value of time range for which jobs have to be fetched.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Job.ToFilter, Position = 4)]
        [ValidateNotNull]
        public DateTime? To { get; set; }

        /// <summary>
        /// Filter value for ID of job.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Job.JobIdFilter, Position = 5)]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        /// <summary>
        /// Job whose latest object has to be fetched.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Job.JobFilter, Position = 6)]
        [ValidateNotNull]
        public JobBase Job { get; set; }

        /// <summary>
        /// Filter value for backup management type of job.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Job.BackupManagementTypeFilter)]
        [ValidateNotNullOrEmpty]
        public BackupManagementType? BackupManagementType { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                // initialize values to default
                DateTime rangeStart = DateTime.UtcNow.AddDays(-1);
                DateTime rangeEnd = DateTime.UtcNow;

                if (From.HasValue)
                {
                    rangeStart = From.Value;
                }

                if (!From.HasValue && To.HasValue)
                {
                    throw new Exception(Resources.JobFromNotProvided);
                }

                if (To.HasValue)
                {
                    rangeEnd = To.Value;
                }

                if (rangeStart.Kind != DateTimeKind.Utc || rangeEnd.Kind != DateTimeKind.Utc)
                {
                    throw new Exception(Resources.JobTimeFiltersShouldBeSpecifiedInUtc);
                }

                // validate filters
                if (rangeEnd <= rangeStart)
                {
                    throw new Exception(Resources.JobToShouldBeGreaterThanFrom);
                }
                else if (rangeEnd.Subtract(rangeStart) > TimeSpan.FromDays(30))
                {
                    throw new Exception(Resources.JobAllowedDateTimeRangeExceeded);
                }

                // validate JobId and Job objects
                if (!string.IsNullOrEmpty(JobId))
                {
                    // if JobId and Job are provided together and they don't match then throw exception
                    if (Job != null && JobId != Job.JobId)
                    {
                        throw new Exception(Resources.JobJobIdAndJobMismatch);
                    }
                }
                else if (Job != null)
                {
                    JobId = Job.JobId;
                }

                List<JobBase> result = new List<JobBase>();

                WriteDebug(string.Format("Filters provided are: StartTime - {0} " + 
                    "EndTime - {1} Status - {2} Operation - {3} Type - {4}",
                    From,
                    To,
                    Status,
                    Operation,
                    BackupManagementType));

                int resultCount = 0;
                var adapterResponse = ServiceClientAdapter.GetJobs(JobId,
                    Status.HasValue ? Status.ToString() : null,
                    Operation.HasValue ? Operation.ToString() : null,
                    rangeStart,
                    rangeEnd,
                    BackupManagementType.HasValue ? 
                    Helpers.JobConversions.GetJobTypeForService(BackupManagementType.Value) : null);
                JobConversions.AddServiceClientJobsToPSList(adapterResponse, result, ref resultCount);

                while (!string.IsNullOrEmpty(adapterResponse.ItemList.NextLink))
                {
                    if (resultCount >= JobConstants.MaximumJobsToFetch)
                    {
                        // trace a warning that there are more jobs and user has to refine filters.
                        WriteWarning(Resources.JobRefineFilters);
                        break;
                    }

                    string skipToken;
                    ServiceClientHelpers.GetSkipTokenFromNextLink(
                        adapterResponse.ItemList.NextLink, out skipToken);
                    if (skipToken != null)
                    {
                        adapterResponse = ServiceClientAdapter.GetJobs(JobId,
                            Status.HasValue ? Status.ToString() : null,
                            Operation.HasValue ? Operation.ToString() : null,
                            rangeStart,
                            rangeEnd,
                            BackupManagementType.HasValue ? 
                            Helpers.JobConversions.GetJobTypeForService(BackupManagementType.Value) : null,
                            null,
                            skipToken);
                        JobConversions.AddServiceClientJobsToPSList(adapterResponse, result, ref resultCount);
                    }
                    else
                    {
                        break;
                    }
                }

                WriteDebug("Number of jobs fetched: " + result.Count);
                WriteObject(result, enumerateCollection: true);
            });
        }
    }
}
