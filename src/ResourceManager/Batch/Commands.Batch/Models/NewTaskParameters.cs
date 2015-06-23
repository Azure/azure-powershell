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

using System;
using System.Collections;
using Microsoft.Azure.Batch;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class NewTaskParameters : JobOperationParameters
    {
        public NewTaskParameters(BatchAccountContext context, string workItemName, string jobName, PSCloudJob job, string taskName,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, workItemName, jobName, job, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(taskName))
            {
                throw new ArgumentNullException("taskName");
            }

            this.TaskName = taskName;
        }

        /// <summary>
        /// The name of the Task to create.
        /// </summary>
        public string TaskName { get; private set; }

        /// <summary>
        /// The command the Task will execute.
        /// </summary>
        public string CommandLine { get; set; }

        /// <summary>
        /// Resource Files to add to the new Task.
        /// </summary>
        public IDictionary ResourceFiles { get; set; }

        /// <summary>
        /// Environment Settings to add to the new Task.
        /// </summary>
        public IDictionary EnvironmentSettings { get; set; }

        /// <summary>
        /// Whether to run the Task in elevated mode.
        /// </summary>
        public bool RunElevated { get; set; }

        /// <summary>
        /// The Affinity Information for the Task.
        /// </summary>
        public PSAffinityInformation AffinityInformation { get; set; }

        /// <summary>
        /// The Task Constraints.
        /// </summary>
        public PSTaskConstraints TaskConstraints { get; set; }
    }
}
