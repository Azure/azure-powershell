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
    public class NewTaskParameters : JobOperationParameters
    {
        public NewTaskParameters(BatchAccountContext context, string jobId, PSCloudJob job, string taskId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, jobId, job, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(taskId))
            {
                throw new ArgumentNullException("taskId");
            }

            this.TaskId = taskId;
        }

        /// <summary>
        /// The id of the task to create.
        /// </summary>
        public string TaskId { get; private set; }

        /// <summary>
        /// The display name of the task to create.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The command the task will execute.
        /// </summary>
        public string CommandLine { get; set; }

        /// <summary>
        /// Resource files to add to the new task.
        /// </summary>
        public IDictionary ResourceFiles { get; set; }

        /// <summary>
        /// Environment settings to add to the new task.
        /// </summary>
        public IDictionary EnvironmentSettings { get; set; }

        /// <summary>
        /// Whether to run the task in elevated mode.
        /// </summary>
        public bool RunElevated { get; set; }

        /// <summary>
        /// The affinity information for the task.
        /// </summary>
        public PSAffinityInformation AffinityInformation { get; set; }

        /// <summary>
        /// The task constraints.
        /// </summary>
        public PSTaskConstraints Constraints { get; set; }

        /// <summary>
        /// Information about how to run the multi-instance task.
        /// </summary>
        public PSMultiInstanceSettings MultiInstanceSettings { get; set; }

        /// <summary>
        /// Tasks that this task depends on. The task will not be scheduled until all depended-on tasks have completed successfully.
        /// </summary>
        public TaskDependencies DependsOn { get; set; }
    }
}
