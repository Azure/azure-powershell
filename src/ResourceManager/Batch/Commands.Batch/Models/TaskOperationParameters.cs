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
    public class TaskOperationParameters : BatchClientParametersBase
    {
        public TaskOperationParameters(BatchAccountContext context, string jobId, string taskId, PSCloudTask task,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, additionalBehaviors)
        {
            if ((string.IsNullOrWhiteSpace(jobId) || string.IsNullOrWhiteSpace(taskId)) && task == null)
            {
                throw new ArgumentNullException(Resources.NoTask);
            }

            this.JobId = jobId;
            this.TaskId = taskId;
            this.Task = task;
        }

        /// <summary>
        /// The id of the job containing the task.
        /// </summary>
        public string JobId { get; private set; }

        /// <summary>
        /// The id of the task.
        /// </summary>
        public string TaskId { get; private set; }

        /// <summary>
        /// The PSCloudTask object representing the target task.
        /// </summary>
        public PSCloudTask Task { get; private set; }
    }
}
