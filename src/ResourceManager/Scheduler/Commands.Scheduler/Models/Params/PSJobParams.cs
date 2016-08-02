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
    using System.Collections;

    public class PSJobParams
    {
        /// <summary>
        /// Gets or sets targeted resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets name of the job collection.
        /// </summary>
        public string JobCollectionName { get; set; }

        /// <summary>
        /// Gets or sets name of the job.
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// Gets or sets state of the job.
        /// </summary>
        public string JobState { get; set; }

        /// <summary>
        /// Gets or sets start time of the job.
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets job action parameters.
        /// </summary>
        public PSJobActionParams JobAction { get; set; }

        /// <summary>
        /// Gets or sets job execution parameters.
        /// </summary>
        public PSJobRecurrenceParams JobRecurrence { get; set; }

        /// <summary>
        /// Gets or sets error job action parameters.
        /// </summary>
        public PSJobActionParams JobErrorAction { get; set; }
    }
}
