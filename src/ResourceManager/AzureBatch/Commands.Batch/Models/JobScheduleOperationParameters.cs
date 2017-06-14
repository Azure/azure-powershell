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
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class JobScheduleOperationParameters : BatchClientParametersBase
    {
        public JobScheduleOperationParameters(BatchAccountContext context, string jobScheduleId, PSCloudJobSchedule jobSchedule,
        IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(jobScheduleId) && jobSchedule == null)
            {
                throw new ArgumentNullException(Resources.NoJobSchedule);
            }

            this.JobScheduleId = jobScheduleId;
            this.JobSchedule = jobSchedule;
        }

        /// <summary>
        /// The id of the job schedule.
        /// </summary>
        public string JobScheduleId { get; private set; }

        /// <summary>
        /// The PSCloudJobSchedule object representing the target job schedule.
        /// </summary>
        public PSCloudJobSchedule JobSchedule { get; private set; }
    }
}
