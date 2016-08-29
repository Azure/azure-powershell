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

using Microsoft.Azure.Management.HDInsight.Job.Models;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    /// <summary>
    /// Provides the details of an HDInsight jobDetails when creating the jobDetails.
    /// </summary>
    public class AzureHDInsightJob
    {
        /// <summary>
        /// Initializes a new instance of the AzureHDInsightJob class.
        /// </summary>
        /// <param name="jobDetails">The HDInsight jobDetails.</param>
        /// <param name="cluster">The cluster that the jobDetails was created against.</param>
        public AzureHDInsightJob(JobDetailRootJsonObject jobDetails, string cluster)
        {
            var index = cluster.IndexOf('.');
            Cluster = index > -1 ? cluster.Substring(0, index) : cluster;
            HttpEndpoint = cluster;
            State = jobDetails.Status.State;
            JobId = jobDetails.Id;
            ParentId = jobDetails.ParentId;
            PercentComplete = jobDetails.PercentComplete;
            ExitValue = jobDetails.ExitValue;
            User = jobDetails.User;
            Callback = jobDetails.Callback;
            Completed = jobDetails.Completed;
            StatusFolder = jobDetails.Userargs.Statusdir != null ? jobDetails.Userargs.Statusdir.ToString() : string.Empty;
        }

        /// <summary>
        /// Gets or sets the name of the cluster to which the jobDetails was submitted.
        /// </summary>
        public string Cluster { get; set; }

        /// <summary>
        /// Gets or sets the HTTP endpoint for the cluster to which the jobDetails was submitted.
        /// </summary>
        public string HttpEndpoint { get; set; }

        /// <summary>
        /// Gets the object containing the job status information.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets the JobId returned by the request.
        /// </summary>
        public string JobId { get; private set; }

        /// <summary>
        /// Gets or sets the parent job ID.
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets the percentage completion of the jobDetails.
        /// </summary>
        public string PercentComplete { get; private set; }

        /// <summary>
        /// Gets the exit code for the jobDetails.
        /// </summary>
        public int? ExitValue { get; private set; }

        /// <summary>
        /// Gets the user name of the job creator.
        /// </summary>
        public string User { get; private set; }

        /// <summary>
        /// Gets the callback URL, if any.
        /// </summary>
        public object Callback { get; set; }

        /// <summary>
        /// Gets a string representing completed status, for example "done".
        /// </summary>
        public string Completed { get; set; }

        /// <summary>
        /// Gets the status folder for the jobDetails.
        /// </summary>
        public string StatusFolder { get; set; }
    }
}
