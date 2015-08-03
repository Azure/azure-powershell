﻿// ----------------------------------------------------------------------------------
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
using Hyak.Common;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsLifecycle.Start,
        Constants.CommandNames.AzureHDInsightJob),
    OutputType(typeof(AzureHDInsightJob))]
    public class StartAzureHDInsightJobCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the cluster.")]
        public string ClusterName
        {
            get { return _clusterName; }
            set { _clusterName = value; }
        }

        [Parameter(Mandatory = true, 
            Position = 2, 
            HelpMessage = "The jobDetails definition to start on the Azure HDInsight cluster.",
            ValueFromPipeline = true)]
        public AzureHDInsightJobDefinition JobDefinition { get; set; }

        [Parameter(Mandatory = true,
            Position = 3,
            HelpMessage = "The credentials with which to connect to the cluster.")]
        public PSCredential ClusterCredential
        {
            get
            {
                return _credential == null ? null : new PSCredential(_credential.Username, _credential.Password.ConvertToSecureString());
            }
            set
            {
                _credential = new BasicAuthenticationCloudCredentials
                {
                    Username = value.UserName,
                    Password = value.Password.ConvertToString()
                };
            }
        }

        #endregion


        public override void ExecuteCmdlet()
        {
            WriteObject(Execute());
        }

        public AzureHDInsightJob Execute()
        {
            _clusterName = GetClusterConnection(ResourceGroupName, ClusterName);

            var jobCreationResults = SubmitJob();

            var startedJob = HDInsightJobClient.GetJob(jobCreationResults.JobSubmissionJsonResponse.Id);

            var jobDetail = new AzureHDInsightJob(startedJob.JobDetail, HDInsightJobClient.ClusterName);

            return jobDetail;
        }

        public JobSubmissionResponse SubmitJob()
        {
            if (string.IsNullOrEmpty(JobDefinition.StatusFolder))
            {
                JobDefinition.StatusFolder = Guid.NewGuid().ToString();
            }

            JobSubmissionResponse jobCreationResults;

            var azureMapReduceJobDefinition = JobDefinition as AzureHDInsightMapReduceJobDefinition;
            var azureHiveJobDefinition = JobDefinition as AzureHDInsightHiveJobDefinition;
            var azurePigJobDefinition = JobDefinition as AzureHDInsightPigJobDefinition;
            var azureStreamingJobDefinition = JobDefinition as AzureHDInsightStreamingMapReduceJobDefinition;

            if (azureMapReduceJobDefinition != null)
            {
                jobCreationResults = HDInsightJobClient.SubmitMRJob(azureMapReduceJobDefinition);
            }
            else if (azureHiveJobDefinition != null)
            {
                jobCreationResults = HDInsightJobClient.SubmitHiveJob(azureHiveJobDefinition);
            }
            else if (azurePigJobDefinition != null)
            {
                jobCreationResults = HDInsightJobClient.SubmitPigJob(azurePigJobDefinition);
            }
            else if (azureStreamingJobDefinition != null)
            {
                jobCreationResults = HDInsightJobClient.SubmitStreamingJob(azureStreamingJobDefinition);
            }
            else
            {
                throw new NotSupportedException(
                    string.Format(CultureInfo.InvariantCulture, "Cannot start jobDetails of type : {0}.", JobDefinition.GetType()));
            }

            return jobCreationResults;
        }
    }
}
