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
using Hyak.Common;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsLifecycle.Wait,
        Constants.CommandNames.AzureHDInsightJob),
    OutputType(typeof(AzureHDInsightJob))]
    public class WaitAzureHDInsightJobCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the cluster.")]
        public string ClusterName
        {
            get { return _clusterName; }
            set { _clusterName = value; }
        }

        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The JobID of the jobDetails to stop.",
            ValueFromPipeline = true)]
        public string JobId { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            HelpMessage = "The credentials with which to connect to the cluster.")]
        [Alias("ClusterCredential")]
        public PSCredential HttpCredential
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

        [Parameter(HelpMessage = "The name of the resource group.")]
        public string ResourceGroupName { get; set; }

        [Parameter(HelpMessage = "The total time to wait for job completion, in seconds.")]
        public int TimeoutInSeconds { get; set; }

        [Parameter(HelpMessage = "The time to wait between job status checks, in seconds.")]
        public int WaitIntervalInSeconds { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            var jobDetails = WaitJob();

            WriteObject(jobDetails);
        }

        public AzureHDInsightJob WaitJob()
        {
            _clusterName = GetClusterConnection(ResourceGroupName, ClusterName);

            TimeSpan? duration = null;

            if (TimeoutInSeconds > 0)
            {
                duration = TimeSpan.FromSeconds(TimeoutInSeconds);
            }

            TimeSpan? waitInterval = null;

            if (WaitIntervalInSeconds > 0)
            {
                waitInterval = TimeSpan.FromSeconds(WaitIntervalInSeconds);
            }

            JobDetailRootJsonObject jobDetail = null;

            try
            {
                jobDetail = HDInsightJobClient.WaitForJobCompletion(JobId, duration, waitInterval).JobDetail;
            }
            catch (TimeoutException)
            {
                var exceptionMessage = string.Format(CultureInfo.InvariantCulture, "HDInsight job with ID {0} has not completed in {1} seconds. Increase the value of -TimeoutInSeconds or check the job runtime.", JobId, TimeoutInSeconds);
                throw new CloudException(exceptionMessage);
            }

            var jobDetails = new AzureHDInsightJob(jobDetail, HDInsightJobClient.ClusterName);
            return jobDetails;
        }
    }
}
