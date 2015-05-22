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
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Job.Models;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsLifecycle.Start,
        Constants.CommandNames.AzureHDInsightJob),
    OutputType(typeof(AzureHDInsightJob))]
    public class StartAzureHDInsightJobCommand : HDInsightCmdletBase
    {
        [Parameter(Mandatory = true, 
            Position = 0, 
            HelpMessage = "The jobDetails definition to start on the Azure HDInsight cluster.",
            ValueFromPipeline = true)]
        public AzureHDInsightJobDefinition JobDefinition { get; set; }

        public override async void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(JobDefinition.StatusFolder))
            {
                JobDefinition.StatusFolder = Guid.NewGuid().ToString();
            }

            JobSubmissionResponse jobCreationResults = null;

            var azureMapReduceJobDefinition = JobDefinition as AzureHDInsightMapReduceJobDefinition;
            var azureHiveJobDefinition = JobDefinition as AzureHDInsightHiveJobDefinition;
            var azurePigJobDefinition = JobDefinition as AzureHDInsightPigJobDefinition;
            var azureStreamingJobDefinition = JobDefinition as AzureHDInsightStreamingMapReduceJobDefinition;
            var azureSqoopJobDefinition = JobDefinition as AzureHDInsightSqoopJobDefinition;

            if (azureMapReduceJobDefinition != null)
            {
                jobCreationResults = await HDInsightJobClient.SubmitMRJob(azureMapReduceJobDefinition);
            }
            else if (azureHiveJobDefinition != null)
            {
                jobCreationResults = await HDInsightJobClient.SubmitHiveJob(azureHiveJobDefinition);
            }
            else if (azurePigJobDefinition != null)
            {
                jobCreationResults = await HDInsightJobClient.SubmitPigJob(azurePigJobDefinition);
            }
            else if (azureSqoopJobDefinition != null)
            {
                jobCreationResults = await HDInsightJobClient.SubmitSqoopJob(azureSqoopJobDefinition);
            }
            else if (azureStreamingJobDefinition != null)
            {
                jobCreationResults = await HDInsightJobClient.SubmitStreamingJob(azureStreamingJobDefinition);
            }
            else
            {
                throw new NotSupportedException(
                    string.Format(CultureInfo.InvariantCulture, "Cannot start jobDetails of type : {0}.", JobDefinition.GetType()));
            }

            var startedJob = await HDInsightJobClient.GetJob(jobCreationResults.JobSubmissionJsonResponse.Id);

            var jobDetail = new AzureHDInsightJob(startedJob.JobDetail, HDInsightJobClient.ClusterName);

            WriteObject(jobDetail);
        }
    }
}
