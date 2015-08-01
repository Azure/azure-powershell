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

using System.Collections;
using System.Linq;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Lists the tasks matching the specified filter options.
        /// </summary>
        /// <param name="options">The options to use when querying for tasks.</param>
        /// <returns>The tasks matching the specified filter options.</returns>
        public IEnumerable<PSCloudTask> ListTasks(ListTaskOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            // Get the single task matching the specified id
            if (!string.IsNullOrEmpty(options.TaskId))
            {
                WriteVerbose(string.Format(Resources.GBT_GetById, options.TaskId, options.JobId));
                JobOperations jobOperations = options.Context.BatchOMClient.JobOperations;
                CloudTask task = jobOperations.GetTask(options.JobId, options.TaskId, additionalBehaviors: options.AdditionalBehaviors);
                PSCloudTask psTask = new PSCloudTask(task);
                return new PSCloudTask[] { psTask };
            }
            // List tasks using the specified filter
            else
            {
                string jobId = options.Job == null ? options.JobId : options.Job.Id;
                ODATADetailLevel odata = null;
                string verboseLogString = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = string.Format(Resources.GBT_GetByOData, jobId);
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    verboseLogString = string.Format(Resources.GBT_GetNoFilter, jobId);
                }
                WriteVerbose(verboseLogString);

                IPagedEnumerable<CloudTask> tasks = null;
                if (options.Job != null)
                {
                    tasks = options.Job.omObject.ListTasks(odata, options.AdditionalBehaviors);
                }
                else
                {
                    JobOperations jobOperations = options.Context.BatchOMClient.JobOperations;
                    tasks = jobOperations.ListTasks(options.JobId, odata, options.AdditionalBehaviors);
                }
                Func<CloudTask, PSCloudTask> mappingFunction = t => { return new PSCloudTask(t); };
                return PSPagedEnumerable<PSCloudTask, CloudTask>.CreateWithMaxCount(
                    tasks, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
            }
        }

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="parameters">The parameters to use when creating the task.</param>
        public void CreateTask(NewTaskParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            CloudTask task = new CloudTask(parameters.TaskId, parameters.CommandLine);
            task.DisplayName = parameters.DisplayName;
            task.RunElevated = parameters.RunElevated;

            if (parameters.EnvironmentSettings != null)
            {
                task.EnvironmentSettings = new List<EnvironmentSetting>();
                foreach (DictionaryEntry d in parameters.EnvironmentSettings)
                {
                    EnvironmentSetting setting = new EnvironmentSetting(d.Key.ToString(), d.Value.ToString());
                    task.EnvironmentSettings.Add(setting);
                }
            }

            if (parameters.ResourceFiles != null)
            {
                task.ResourceFiles = new List<ResourceFile>();
                foreach (DictionaryEntry d in parameters.ResourceFiles)
                {
                    ResourceFile file = new ResourceFile(d.Value.ToString(), d.Key.ToString());
                    task.ResourceFiles.Add(file);
                }
            }

            if (parameters.AffinityInformation != null)
            {
                task.AffinityInformation = parameters.AffinityInformation.omObject;
            }

            if (parameters.Constraints != null)
            {
                task.Constraints = parameters.Constraints.omObject;
            }

            WriteVerbose(string.Format(Resources.NBT_CreatingTask, parameters.TaskId));
            if (parameters.Job != null)
            {
                parameters.Job.omObject.AddTask(task, parameters.AdditionalBehaviors);
            }
            else
            {
                JobOperations jobOperations = parameters.Context.BatchOMClient.JobOperations;
                jobOperations.AddTask(parameters.JobId, task, parameters.AdditionalBehaviors);
            }
        }

        /// <summary>
        /// Deletes the specified task.
        /// </summary>
        /// <param name="parameters">The parameters indicating which task to delete.</param>
        public void DeleteTask(TaskOperationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            if (parameters.Task != null)
            {
                parameters.Task.omObject.Delete(parameters.AdditionalBehaviors);
            }
            else
            {
                JobOperations jobOperations = parameters.Context.BatchOMClient.JobOperations;
                jobOperations.DeleteTask(parameters.JobId, parameters.TaskId, parameters.AdditionalBehaviors);
            }
        }
    }
}
