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
using Microsoft.Hadoop.Client;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects
{
    /// <summary>
    ///     Represents an Azure HD Insight jobDetails for the PowerShell Cmdlets.
    /// </summary>
    public class AzureHDInsightJob : AzureHDInsightJobBase
    {
        /// <summary>
        ///     Initializes a new instance of the AzureHDInsightJob class.
        /// </summary>
        /// <param name="jobDetails">The HDInsight jobDetails.</param>
        /// <param name="cluster">The cluster that the jobDetails was created against.</param>
        public AzureHDInsightJob(JobDetails jobDetails, string cluster) : base(jobDetails)
        {
            jobDetails.ArgumentNotNull("jobDetails");
            this.ExitCode = jobDetails.ExitCode;
            this.Name = jobDetails.Name;
            this.Query = jobDetails.Query;
            this.State = jobDetails.StatusCode.ToString();

            this.Cluster = cluster;
            this.StatusDirectory = jobDetails.StatusDirectory;
            this.SubmissionTime = jobDetails.SubmissionTime;
            this.PercentComplete = jobDetails.PercentComplete;
        }

        /// <summary>
        ///     Gets or sets the cluster to which the jobDetails was submitted.
        /// </summary>
        public string Cluster { get; set; }

        /// <summary>
        ///     Gets the exit code for the jobDetails.
        /// </summary>
        public int? ExitCode { get; private set; }

        /// <summary>
        ///     Gets the name of the jobDetails.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     Gets or sets the percentage completion of the jobDetails.
        /// </summary>
        public string PercentComplete { get; set; }

        /// <summary>
        ///     Gets the query for the jobDetails (if it was a hive jobDetails).
        /// </summary>
        public string Query { get; private set; }

        /// <summary>
        ///     Gets the status code for the jobDetails.
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        ///     Gets or sets the status directory for the jobDetails.
        /// </summary>
        public string StatusDirectory { get; set; }

        /// <summary>
        ///     Gets the time the jobDetails was submitted.
        /// </summary>
        public DateTime SubmissionTime { get; private set; }
    }
}
