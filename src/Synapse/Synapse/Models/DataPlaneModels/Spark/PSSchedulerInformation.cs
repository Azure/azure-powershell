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
    public class PSSchedulerInformation
    {
        public PSSchedulerInformation(SparkScheduler schedulerInfo)
        {
            this.SubmittedAt = schedulerInfo?.SubmittedAt;
            this.ScheduledAt = schedulerInfo?.ScheduledAt;
            this.EndedAt = schedulerInfo?.EndedAt;
            this.CancellationRequestedAt = schedulerInfo?.CancellationRequestedAt;
            this.CurrentState = schedulerInfo?.CurrentState;
        }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? SubmittedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? ScheduledAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? EndedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? CancellationRequestedAt { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Queued', 'Scheduled',
        /// 'Ended'
        /// </summary>
        public SchedulerCurrentState? CurrentState { get; set; }
    }
}