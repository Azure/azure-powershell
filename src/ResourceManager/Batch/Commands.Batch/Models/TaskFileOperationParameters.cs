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
using Microsoft.Azure.Batch;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Batch.Properties;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class TaskFileOperationParameters : BatchClientParametersBase
    {
        public TaskFileOperationParameters(BatchAccountContext context, string workItemName, string jobName, string taskName, string taskFileName,
            PSTaskFile taskFile, IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, additionalBehaviors)
        {
            if ((string.IsNullOrWhiteSpace(workItemName) || string.IsNullOrWhiteSpace(jobName) || string.IsNullOrWhiteSpace(taskName) || 
                string.IsNullOrWhiteSpace(taskFileName)) && taskFile == null)
            {
                throw new ArgumentNullException(Resources.NoTaskFile);
            }

            this.WorkItemName = workItemName;
            this.JobName = jobName;
            this.TaskName = taskName;
            this.TaskFileName = taskFileName;
            this.TaskFile = taskFile;
        }

        /// <summary>
        /// The name of the workitem containing the task
        /// </summary>
        public string WorkItemName { get; private set; }

        /// <summary>
        /// The name of the job containing the task
        /// </summary>
        public string JobName { get; private set; }

        /// <summary>
        /// The name of the task
        /// </summary>
        public string TaskName { get; private set; }

        /// <summary>
        /// The name of the task file
        /// </summary>
        public string TaskFileName { get; private set; }

        /// <summary>
        /// The PSTaskFile object representing the target task file
        /// </summary>
        public PSTaskFile TaskFile { get; private set; }
    }
}
