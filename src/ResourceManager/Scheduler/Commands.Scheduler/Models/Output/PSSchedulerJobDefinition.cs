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


namespace Microsoft.Azure.Commands.Scheduler.Models
{
    using System;

    public class PSSchedulerJobDefinition
    {
        /// <summary>
        /// Gets or sets resource group name.
        /// </summary>
        public string ResourceGroupName { get; internal set; }

        /// <summary>
        /// Gets or sets job collection name.
        /// </summary>
        public string JobCollectionName { get; internal set; }

        /// <summary>
        /// Gets or sets job name.
        /// </summary>
        public string JobName { get; internal set; }

        /// <summary>
        /// Gets or sets last job run.
        /// </summary>
        public DateTime? Lastrun { get; internal set; }

        /// <summary>
        /// Gets or sets next job run.
        /// </summary>
        public DateTime? Nextrun { get; internal set; }

        /// <summary>
        /// Gets or sest job start time.
        /// </summary>
        public DateTime? StartTime { get; internal set; }

        /// <summary>
        /// Gets or sets job status.
        /// </summary>
        public string Status { get; internal set; }

        /// <summary>
        /// Gets or sets job recurrence.
        /// </summary>
        public string Recurrence { get; internal set; }

        /// <summary>
        /// Gets or sets number of job failures.
        /// </summary>
        public int? Failures { get; internal set; }

        /// <summary>
        /// Gets or sets number of job faults.
        /// </summary>
        public int? Faults { get; internal set; }

        /// <summary>
        /// Gets or sets number of job executions.
        /// </summary>
        public int? Executions { get; internal set; }

        /// <summary>
        /// Gets or sets job end schedule.
        /// </summary>
        public string EndSchedule { get; internal set; }

        /// <summary>
        /// Gets or sets job action.
        /// </summary>
        public PSJobActionDetails JobAction { get; internal set; }

        /// <summary>
        /// Gets or sets job error action.
        /// </summary>
        public PSJobActionDetails JobErrorAction { get; internal set; }
    }
}
