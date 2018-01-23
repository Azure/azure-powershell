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
    [Cmdlet(VerbsCommon.Get, "AzureRmDataLakeAnalyticsJobPipeline", DefaultParameterSetName = BaseParameterSetName),
     OutputType(typeof(List<PSJobPipelineInformation>), typeof(PSJobPipelineInformation))]
    [Alias("Get-AdlJobPipeline")]
    public class GetAzureDataLakeAnalyticsJobPipeline : DataLakeAnalyticsCmdletBase
    {
        internal const string BaseParameterSetName = "GetAllInAccount";
        internal const string JobInfoParameterSetName = "GetBySpecificJobPipeline";

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true, Position = 0,
            Mandatory = true,
            HelpMessage =
                "Name of the Data Lake Analytics account name under which want to retrieve the job pipeline.")]
        [Parameter(ParameterSetName = JobInfoParameterSetName, ValueFromPipelineByPropertyName = true, Position = 0,
            Mandatory = true,
            HelpMessage =
                "Name of Data Lake Analytics account name under which want to to retrieve the job pipeline.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ParameterSetName = JobInfoParameterSetName, ValueFromPipelineByPropertyName = true, Position = 1,
            ValueFromPipeline = true, Mandatory = true,
            HelpMessage = "ID of the specific job pipeline to return information for.")]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public Guid PipelineId { get; set; }

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "An optional filter which returns job pipeline(s) only submitted after the specified time.")]
        [Parameter(ParameterSetName = JobInfoParameterSetName, ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "An optional filter which returns job pipeline(s) only submitted after the specified time.")]
        [ValidateNotNull]
        public DateTimeOffset? SubmittedAfter { get; set; }

        [Parameter(ParameterSetName = BaseParameterSetName, ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "An optional filter which returns job pipeline(s) only submitted before the specified time.")]
        [Parameter(ParameterSetName = JobInfoParameterSetName, ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "An optional filter which returns job pipeline(s) only submitted before the specified time.")]
        [ValidateNotNull]
        public DateTimeOffset? SubmittedBefore { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(BaseParameterSetName))
            {
                WriteObject(DataLakeAnalyticsClient.ListJobPipeline(Account, SubmittedAfter, SubmittedBefore), true);
            }
            else
            {
                WriteObject(DataLakeAnalyticsClient.GetJobPipeline(Account, PipelineId, SubmittedAfter, SubmittedBefore));
            }
        }
    }
}
