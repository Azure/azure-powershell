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

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSparkServicePluginInformation
    {
        public PSSparkServicePluginInformation(SparkServicePlugin pluginInfo)
        {
            this.PreparationStartedAt = pluginInfo?.PreparationStartedAt;
            this.ResourceAcquisitionStartedAt = pluginInfo?.ResourceAcquisitionStartedAt;
            this.SubmissionStartedAt = pluginInfo?.SubmissionStartedAt;
            this.MonitoringStartedAt = pluginInfo?.MonitoringStartedAt;
            this.CleanupStartedAt = pluginInfo?.CleanupStartedAt;
            this.CurrentState = pluginInfo?.CurrentState;
        }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? PreparationStartedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? ResourceAcquisitionStartedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? SubmissionStartedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? MonitoringStartedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? CleanupStartedAt { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Preparation',
        /// 'ResourceAcquisition', 'Queued', 'Submission', 'Monitoring',
        /// 'Cleanup', 'Ended'
        /// </summary>
        public PluginCurrentState? CurrentState { get; set; }
    }
}