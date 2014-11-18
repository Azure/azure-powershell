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
using System.Threading.Tasks;
using Microsoft.Hadoop.Client;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    internal class WaitAzureHDInsightJobCommand : AzureHDInsightJobExecutorCommand<AzureHDInsightJob>, IWaitAzureHDInsightJobCommand
    {
        internal static bool ReduceWaitTime = false;

        public WaitAzureHDInsightJobCommand()
        {
            this.WaitTimeoutInSeconds = 30 * 60;
        }

        public event EventHandler<WaitJobStatusEventArgs> JobStatusEvent;

        public string Cluster { get; set; }

        public AzureHDInsightJob Job { get; set; }

        public JobDetails JobDetailsStatus { get; private set; }

        public string JobId { get; set; }

        public double WaitTimeoutInSeconds { get; set; }

        public override Task EndProcessing()
        {
            return TaskEx.FromResult(0);
        }

        public async Task ProcessRecord()
        {
            if (string.IsNullOrWhiteSpace(this.JobId) || string.IsNullOrWhiteSpace(this.Cluster))
            {
                this.JobId = this.Job.JobId;
                this.Cluster = this.Job.Cluster;
            }

            IJobSubmissionClient client = this.GetClient(this.Cluster);
            client.JobStatusEvent += this.ClientOnJobStatus;
            JobDetails jobDetail = null;
            if (ReduceWaitTime)
            {
                jobDetail = await client.GetJobAsync(this.JobId);
                while (jobDetail.StatusCode != JobStatusCode.Completed && jobDetail.StatusCode != JobStatusCode.Failed &&
                       jobDetail.StatusCode != JobStatusCode.Canceled)
                {
                    jobDetail = await client.GetJobAsync(this.JobId);
                }
            }
            else
            {
                var job = new JobCreationResults { JobId = this.JobId };
                jobDetail = await client.WaitForJobCompletionAsync(job, TimeSpan.FromSeconds(this.WaitTimeoutInSeconds), this.tokenSource.Token);
            }

            this.Output.Add(new AzureHDInsightJob(jobDetail, this.Cluster));
        }

        private void ClientOnJobStatus(object sender, WaitJobStatusEventArgs waitJobStatusEventArgs)
        {
            this.JobDetailsStatus = waitJobStatusEventArgs.JobDetails;
            EventHandler<WaitJobStatusEventArgs> handler = this.JobStatusEvent;
            if (handler != null)
            {
                handler(sender, waitJobStatusEventArgs);
            }
        }
    }
}
