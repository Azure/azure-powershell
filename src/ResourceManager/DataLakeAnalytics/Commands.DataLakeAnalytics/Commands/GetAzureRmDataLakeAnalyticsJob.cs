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

using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using JobState = Microsoft.Azure.Management.DataLake.Analytics.Models.JobState;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Get, "AzureRmDataLakeAnalyticsJob", DefaultParameterSetName = BaseParameterSetName),
     OutputType(typeof(List<PSJobInformationBasic>), typeof(JobInformation))]
    [Alias("Get-AdlJob")]
    public class GetAzureDataLakeAnalyticsJob : DataLakeAnalyticsCmdletBase
    {
        internal const string BaseParameterSetName = "GetAllInResourceGroupAndAccount";
        internal const string JobInfoParameterSetName = "GetBySpecificJobInformation";

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true, Position = 0,
            Mandatory = true,
            HelpMessage =
                "Name of the Data Lake Analytics account name under which want to retrieve the job information.")]
        [Parameter(ParameterSetName = JobInfoParameterSetName, ValueFromPipelineByPropertyName = true, Position = 0,
            Mandatory = true,
            HelpMessage =
                "Name of Data Lake Analytics account name under which want to to retrieve the job information.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ParameterSetName = JobInfoParameterSetName, ValueFromPipelineByPropertyName = true, Position = 1,
            ValueFromPipeline = true, Mandatory = true,
            HelpMessage = "ID of the specific job to return job information for.")]
        [ValidateNotNullOrEmpty]
        public Guid JobId { get; set; }

        [Parameter(ParameterSetName = JobInfoParameterSetName, ValueFromPipelineByPropertyName = true, Position = 2,
            Mandatory = false, HelpMessage = "Optionally indicates additional job data to include in the job details.")]
        [ValidateNotNullOrEmpty]
        public DataLakeAnalyticsEnums.ExtendedJobData Include { get; set; }

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true, Position = 1,
            Mandatory = false,
            HelpMessage = "An optional filter which returns jobs with only the specified friendly name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true, Position = 2,
            Mandatory = false, HelpMessage = "An optional filter which returns jobs only by the specified submitter.")]
        [ValidateNotNullOrEmpty]
        public string Submitter { get; set; }

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true, Position = 3,
            Mandatory = false,
            HelpMessage = "An optional filter which returns jobs only submitted after the specified time.")]
        [ValidateNotNull]
        public DateTimeOffset? SubmittedAfter { get; set; }

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true, Position = 4,
            Mandatory = false,
            HelpMessage = "An optional filter which returns jobs only submitted before the specified time.")]
        [ValidateNotNull]
        public DateTimeOffset? SubmittedBefore { get; set; }

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true, Position = 5,
            Mandatory = false, HelpMessage = "An optional filter which returns jobs with only the specified state.")]
        [ValidateNotNullOrEmpty]
        public JobState[] State { get; set; }

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true, Position = 6,
            Mandatory = false, HelpMessage = "An optional filter which returns jobs with only the specified state.")]
        [ValidateNotNullOrEmpty]
        public JobResult[] Result { get; set; }

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true,
            Mandatory = false, HelpMessage = "An optional value which indicates the number of jobs to return. Default value is 500")]
        [ValidateNotNullOrEmpty]
        public int? Top { get; set; }

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true,
            Mandatory = false, HelpMessage = "An optional ID that indicates only jobs part of the specified pipeline should be returned.")]
        [ValidateNotNullOrEmpty]
        public Guid? PipelineId { get; set; }

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true,
            Mandatory = false, HelpMessage = "An optional ID that indicates only jobs part of the specified recurrence should be returned.")]
        [ValidateNotNullOrEmpty]
        public Guid? RecurrenceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (JobId != null && JobId != Guid.Empty)
            {
                // Get for single job
                var jobDetails = DataLakeAnalyticsClient.GetJob(Account, JobId);

                if (Include != DataLakeAnalyticsEnums.ExtendedJobData.None)
                {
                    if (jobDetails.Type != JobType.USql)
                    {
                        WriteWarningWithTimestamp(string.Format(Resources.AdditionalDataNotSupported, jobDetails.Type));
                    }
                    else
                    {
                        if (Include == DataLakeAnalyticsEnums.ExtendedJobData.All ||
                            Include == DataLakeAnalyticsEnums.ExtendedJobData.DebugInfo)
                        {
                            ((USqlJobProperties)jobDetails.Properties).DebugData =
                                DataLakeAnalyticsClient.GetDebugDataPaths(Account, JobId);
                        }

                        if (Include == DataLakeAnalyticsEnums.ExtendedJobData.All ||
                            Include == DataLakeAnalyticsEnums.ExtendedJobData.Statistics)
                        {
                            ((USqlJobProperties)jobDetails.Properties).Statistics =
                                DataLakeAnalyticsClient.GetJobStatistics(Account, JobId);
                        }
                    }
                }

                WriteObject(jobDetails);
            }
            else
            {
                var filter = new List<string>();
                // always order by most recently submitted.
                if (!string.IsNullOrEmpty(Submitter))
                {
                    // TODO: replace with the wildcard substitution.
                    filter.Add(string.Format("submitter eq '{0}'", Submitter));
                }

                // due to issue: https://github.com/Azure/autorest/issues/975,
                // date time offsets must be explicitly escaped before being passed to the filter
                if (SubmittedAfter.HasValue)
                {
                    filter.Add(string.Format("submitTime ge datetimeoffset'{0}'", Uri.EscapeDataString(SubmittedAfter.Value.ToString("O"))));
                }

                // due to issue: https://github.com/Azure/autorest/issues/975,
                // date time offsets must be explicitly escaped before being passed to the filter
                if (SubmittedBefore.HasValue)
                {
                    filter.Add(string.Format("submitTime lt datetimeoffset'{0}'", Uri.EscapeDataString(SubmittedBefore.Value.ToString("O"))));
                }

                if (!string.IsNullOrEmpty(Name))
                {
                    // TODO: replace with the wildcard substitution.
                    filter.Add(string.Format("name eq '{0}'", Name));
                }

                if (State != null && State.Length > 0)
                {
                    filter.Add("(" +
                               string.Join(" or ",
                                   State.Select(state => string.Format("state eq '{0}'", state)).ToArray()) + ")");
                }

                if (Result != null && Result.Length > 0)
                {
                    filter.Add("(" +
                               string.Join(" or ",
                                   Result.Select(result => string.Format("result eq '{0}'", result)).ToArray()) + ")");
                }

                if (PipelineId.HasValue)
                {
                    filter.Add(string.Format("related/pipelineId eq guid'{0}'", PipelineId.Value));
                }

                if (RecurrenceId.HasValue)
                {
                    filter.Add(string.Format("related/recurrenceId eq guid'{0}'", RecurrenceId.Value));
                }

                var filterString = string.Join(" and ", filter.ToArray());

                // List the jobs with the given filters
                bool warnUser;
                var list = DataLakeAnalyticsClient.ListJobs(Account, 
                    string.IsNullOrEmpty(filterString) ? null : filterString, Top, null, "submitTime desc", out warnUser)
                    .Select(element => new PSJobInformationBasic(element))
                    .ToList();
                if (warnUser)
                {
                    WriteWarning(string.Format(Resources.MoreJobsToGetWarning, Top.HasValue ? Top.Value : 500));
                }

                WriteObject(list, true);
            }
        }
    }
}
