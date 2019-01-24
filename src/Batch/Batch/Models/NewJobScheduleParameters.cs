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

using Microsoft.Azure.Batch;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class NewJobScheduleParameters : BatchClientParametersBase
    {
        public NewJobScheduleParameters(BatchAccountContext context, string jobScheduleId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(jobScheduleId))
            {
                throw new ArgumentNullException("jobScheduleId");
            }

            this.JobScheduleId = jobScheduleId;
        }

        /// <summary>
        /// The id of the job schedule to create.
        /// </summary>
        public string JobScheduleId { get; private set; }

        /// <summary>
        /// The display name of the job schedule to create.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The Schedule to use when creating a new job schedule.
        /// </summary>
        public PSSchedule Schedule { get; set; }

        /// <summary>
        /// The job specification to use when creating a new job schedule.
        /// </summary>
        public PSJobSpecification JobSpecification { get; set; }

        /// <summary>
        /// Metadata to add to the new job schedule.
        /// </summary>
        public IDictionary Metadata { get; set; }
    }
}
