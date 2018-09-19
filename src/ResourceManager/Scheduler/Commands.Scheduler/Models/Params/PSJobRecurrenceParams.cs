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

    public class PSJobRecurrenceParams
    {
        /// <summary>
        /// Gets or sets interval between jobs execution.
        /// </summary>
        public int? Interval { get; set; }

        /// <summary>
        /// Gets or sets frequncy of job execution.
        /// </summary>
        public string Frequency { get; set; }

        /// <summary>
        /// Gets or sets end time for job execution.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets number of time to execute job.
        /// </summary>
        public int? ExecutionCount { get; set; }
    }
}
