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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Get list of jobs
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmBackupJob"), OutputType(typeof(List<AzureRmRecoveryServicesJobBase>), typeof(AzureRmRecoveryServicesJobBase))]
    public class GetAzureRmRecoveryServicesJob : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Job.FromFilter)]
        [ValidateNotNull]
        public DateTime? From { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Job.ToFilter)]
        [ValidateNotNull]
        public DateTime? To { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Job.JobIdFilter)]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Job.JobFilter)]
        [ValidateNotNull]
        public AzureRmRecoveryServicesJobBase Job { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Job.BackupManagementTypeFilter)]
        [ValidateNotNullOrEmpty]
        public BackupManagementType? BackupManagementType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Job.OperationFilter)]
        [ValidateNotNullOrEmpty]
        public JobOperation? Operation { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Job.StatusFilter)]
        [ValidateNotNullOrEmpty]
        public JobStatus? Status { get; set; }

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
                    WriteDebug("Entered From filter: " + From.Value);
                    rangeStart = From.Value;
                }

                if (To.HasValue)
                {
                    WriteDebug("Entered To filter; " + To.Value);
                    rangeEnd = To.Value;
                }

                // validate filters
                if (rangeEnd <= rangeStart)
                {
                    throw new Exception(CmdletWarningAndErrorMessages.Job.ToShouldBeGreaterThanFrom);
                }
                else if (rangeEnd.Subtract(rangeStart) > TimeSpan.FromDays(30))
                {
                    throw new Exception(CmdletWarningAndErrorMessages.Job.AllowedDateTimeRangeExceeded);
                }

                // validate JobId and Job objects
                if (!string.IsNullOrEmpty(JobId))
                {
                    // if JobId and Job are provided together and they don't match then throw exception
                    if (Job != null && JobId != Job.InstanceId)
                    {
                        throw new Exception(CmdletWarningAndErrorMessages.Job.JobIdAndJobMismatch);
                    }
                }
                else if (Job != null)
                {
                    JobId = Job.InstanceId;
                }

                List<AzureRmRecoveryServicesJobBase> result = new List<AzureRmRecoveryServicesJobBase>();
                int resultCount = 0;
                var adapterResponse = HydraAdapter.GetJobs(JobId,
                    Status.HasValue ? Status.ToString() : null,
                    Operation.HasValue ? Operation.ToString() : null,
                    rangeStart,
                    rangeEnd,
                    BackupManagementType.HasValue ? Helpers.JobConversions.GetJobTypeForService(BackupManagementType.Value) : null);
                JobConversions.AddHydraJobsToPSList(adapterResponse, result, ref resultCount);

                while (!string.IsNullOrEmpty(adapterResponse.ItemList.NextLink))
                {
                    if (resultCount >= JobConstants.MaximumJobsToFetch)
                    {
                        // trace a warning that there are more jobs and user has to refine filters.
                        WriteWarning(CmdletWarningAndErrorMessages.Job.RefineFilters);
                        break;
                    }

                    string skipToken;
                    HydraHelpers.GetSkipTokenFromNextLink(adapterResponse.ItemList.NextLink, out skipToken);
                    if (skipToken != null)
                    {
                        adapterResponse = HydraAdapter.GetJobs(JobId,
                            Status.HasValue ? Status.ToString() : null,
                            Operation.HasValue ? Operation.ToString() : null,
                            rangeStart,
                            rangeEnd,
                            BackupManagementType.HasValue ? Helpers.JobConversions.GetJobTypeForService(BackupManagementType.Value) : null,
                            null,
                            skipToken);
                        JobConversions.AddHydraJobsToPSList(adapterResponse, result, ref resultCount);
                    }
                    else
                    {
                        break;
                    }
                }

                if (resultCount != 1)
                {
                    WriteObject(result);
                }
                else
                {
                    WriteObject(result[0]);
                }
            });
        }
    }
}
