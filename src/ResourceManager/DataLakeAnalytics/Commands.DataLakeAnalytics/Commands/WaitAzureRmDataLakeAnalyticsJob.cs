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
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using JobState = Microsoft.Azure.Management.DataLake.Analytics.Models.JobState;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsLifecycle.Wait, "AzureRmDataLakeAnalyticsJob"), OutputType(typeof(JobInformation))]
    [Alias("Wait-AdlJob")]
    public class WaitAzureDataLakeAnalyticsJob : DataLakeAnalyticsCmdletBase
    {
        private int _waitIntervalInSeconds = 5;

        public WaitAzureDataLakeAnalyticsJob()
        {
            TimeoutInSeconds = 0;
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the Data Lake Analytics account name under which want to stop the job.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, ValueFromPipeline = true, Mandatory = true,
            HelpMessage = "Name of the specific job to stop.")]
        [ValidateNotNullOrEmpty]
        public Guid JobId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage = "The polling interval between checks for the job status, in seconds.")]
        public int WaitIntervalInSeconds
        {
            get { return _waitIntervalInSeconds; }
            set { _waitIntervalInSeconds = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "The maximum amount of time to wait before erroring out. Default value is to never timeout.")]
        public int TimeoutInSeconds { get; set; }

        public override void ExecuteCmdlet()
        {
            var jobInfo = DataLakeAnalyticsClient.GetJob(Account, JobId);
            var timeWaitedInSeconds = 0;
            while (jobInfo.State != JobState.Ended)
            {
                if (TimeoutInSeconds > 0 && timeWaitedInSeconds >= TimeoutInSeconds)
                {
                    throw new CloudException(string.Format(Resources.WaitJobTimeoutExceeded, JobId, TimeoutInSeconds));
                }

                WriteVerboseWithTimestamp(string.Format(Resources.WaitJobState, jobInfo.State));
                TestMockSupport.Delay(WaitIntervalInSeconds * 1000);
                timeWaitedInSeconds += WaitIntervalInSeconds;
                jobInfo = DataLakeAnalyticsClient.GetJob(Account, JobId);
            }

            WriteObject(jobInfo);
        }
    }
}