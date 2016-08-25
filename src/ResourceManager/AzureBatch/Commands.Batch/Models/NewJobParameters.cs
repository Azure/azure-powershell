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
    public class NewJobParameters : BatchClientParametersBase
    {
        public NewJobParameters(BatchAccountContext context, string jobId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(jobId))
            {
                throw new ArgumentNullException("jobId");
            }

            this.JobId = jobId;
        }

        /// <summary>
        /// The id of the job to create.
        /// </summary>
        public string JobId { get; private set; }

        /// <summary>
        /// The common environment settings that are automatically added to all tasks.
        /// </summary>
        public IDictionary CommonEnvironmentSettings { get; set; }

        /// <summary>
        /// The display name of the job to create.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The job constraints.
        /// </summary>
        public PSJobConstraints Constraints { get; set; }

        /// <summary>
        /// The details of the Job Manager task that will be launched whenever a job is started.
        /// </summary>
        public PSJobManagerTask JobManagerTask { get; set; }

        /// <summary>
        /// The details of the Job Preparation task for the job.
        /// </summary>
        public PSJobPreparationTask JobPreparationTask { get; set; }

        /// <summary>
        /// The details of the Job Release task for the job.
        /// </summary>
        public PSJobReleaseTask JobReleaseTask { get; set; }

        /// <summary>
        /// Metadata to add to the new job.
        /// </summary>
        public IDictionary Metadata { get; set; }

        /// <summary>
        /// The pool information for the job.
        /// </summary>
        public PSPoolInformation PoolInformation { get; set; }

        /// <summary>
        /// The job priority.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Whether tasks in the job can define dependencies on each other.
        /// </summary>
        public bool? UsesTaskDependencies { get; set; }
    }
}
