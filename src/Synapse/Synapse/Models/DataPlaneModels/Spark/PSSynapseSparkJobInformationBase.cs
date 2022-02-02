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

using Azure.Analytics.Synapse.Spark.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public abstract class PSSynapseSparkJobInformationBase
    {
        public PSSynapseSparkJobInformationBase()
        {
        }

        public PSSynapseSparkJobInformationBase(
            string name,
            string workspaceName,
            string sparkPoolName,
            string submitterName,
            string submitterId,
            string artifactId,
            SparkJobType? jobType,
            string result,
            SparkScheduler scheduler,
            SparkServicePlugin plugin,
            IReadOnlyList<SparkServiceError> errors,
            IDictionary<string, string> tags,
            int? id,
            string appId,
            IReadOnlyDictionary<string, string> appInfo,
            string state,
            IReadOnlyList<string> logLines)
        {
            this.Name = name;
            this.WorkspaceName = workspaceName;
            this.SparkPoolName = sparkPoolName;
            this.SubmitterName = submitterName;
            this.SubmitterId = submitterId;
            this.ArtifactId = artifactId;
            this.JobType = jobType;
            this.Result = result;
            this.Scheduler = scheduler != null ? new PSSchedulerInformation(scheduler) : null;
            this.Plugin = plugin != null ?new PSSparkServicePluginInformation(plugin) : null;
            this.Errors = errors;
            this.Tags = TagsConversionHelper.CreateTagHashtable(tags);
            this.Id = id;
            this.AppId = appId;
            this.AppInfo = appInfo;
            this.State = state;
            this.LogLines = logLines;
        }

        /// <summary>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        public string WorkspaceName { get; set; }

        /// <summary>
        /// </summary>
        public string SparkPoolName { get; set; }

        /// <summary>
        /// </summary>
        public string SubmitterName { get; set; }

        /// <summary>
        /// </summary>
        public string SubmitterId { get; set; }

        /// <summary>
        /// </summary>
        public string ArtifactId { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'SparkBatch', 'SparkSession'
        /// </summary>
        public SparkJobType? JobType { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Uncertain', 'Succeeded',
        /// 'Failed', 'Cancelled'
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// </summary>
        public PSSchedulerInformation Scheduler { get; set; }

        /// <summary>
        /// </summary>
        public PSSparkServicePluginInformation Plugin { get; set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<SparkServiceError> Errors { get; set; }

        /// <summary>
        /// </summary>
        public Hashtable Tags { get; set; }

        public string TagsTable => ResourcesExtensions.ConstructTagsTable(Tags);

        /// <summary>
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// </summary>
        public IReadOnlyDictionary<string, string> AppInfo { get; set; }

        /// <summary>
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<string> LogLines { get; set; }
    }
}
