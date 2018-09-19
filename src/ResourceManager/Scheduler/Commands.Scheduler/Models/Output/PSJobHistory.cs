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

    public class PSJobHistory
    {
        /// <summary>
        /// Gets or sets name of the job.
        /// </summary>
        public string JobName { get; internal set; }

        /// <summary>
        /// Gets or sets status of the job.
        /// </summary>
        public string Status { get; internal set; }

        /// <summary>
        /// Gets or sets number of retries.
        /// </summary>
        public int? Retry { get; internal set; }

        /// <summary>
        /// Gets or sets number of occurence.
        /// </summary>
        public int? Occurence { get; internal set; }

        /// <summary>
        /// Gets or sets start time of the job.
        /// </summary>
        public DateTime? StartTime { get; internal set; }

        /// <summary>
        /// Gets or sets end time of the job.
        /// </summary>
        public DateTime? EndTime { get; internal set; }

        /// <summary>
        /// Gets or sets action history.
        /// </summary>
        public PSJobActionHistory ActionHistory { get; internal set; }
    }
}
