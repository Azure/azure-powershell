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
        /// Lists the Tasks matching the specified filter options
        /// </summary>
        /// <param name="options">The options to use when querying for Tasks</param>
        /// <returns>The Tasks matching the specified filter options</returns>
        public IEnumerable<PSCloudTask> ListTasks(ListTaskOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if ((string.IsNullOrWhiteSpace(options.WorkItemName) || string.IsNullOrWhiteSpace(options.JobName)) && options.Job == null)
            {
                throw new ArgumentNullException(Resources.GBT_NoJob);
            }

            // Get the single Task matching the specified name
            if (!string.IsNullOrEmpty(options.TaskName))
            {
                WriteVerbose(string.Format(Resources.GBT_GetByName, options.TaskName, options.JobName, options.WorkItemName));
                using (IWorkItemManager wiManager = options.Context.BatchOMClient.OpenWorkItemManager())
                {
                    ICloudTask task = wiManager.GetTask(options.WorkItemName, options.JobName, options.TaskName, additionalBehaviors: options.AdditionalBehaviors);
                    PSCloudTask psTask = new PSCloudTask(task);
                    return new PSCloudTask[] { psTask };
                }
            }
            // List Tasks using the specified filter
            else
            {
                string jName = options.Job == null ? options.JobName : options.Job.Name;
                ODATADetailLevel odata = null;
                string verboseLogString = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = string.Format(Resources.GBT_GetByOData, jName);
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    verboseLogString = string.Format(Resources.GBT_GetNoFilter, jName);
                }
                WriteVerbose(verboseLogString);

                IEnumerableAsyncExtended<ICloudTask> tasks = null;
                if (options.Job != null)
                {
                    tasks = options.Job.omObject.ListTasks(odata, options.AdditionalBehaviors);
                }
                else
                {
                    using (IWorkItemManager wiManager = options.Context.BatchOMClient.OpenWorkItemManager())
                    {
                        tasks = wiManager.ListTasks(options.WorkItemName, options.JobName, odata, options.AdditionalBehaviors);
                    }
                }
                Func<ICloudTask, PSCloudTask> mappingFunction = t => { return new PSCloudTask(t); };
                return PSAsyncEnumerable<PSCloudTask, ICloudTask>.CreateWithMaxCount(
                    tasks, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
            }
        }

        /// <summary>
        /// Creates a new Task
        /// </summary>
        /// <param name="parameters">The parameters to use when creating the Task</param>
        public void CreateTask(NewTaskParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if ((string.IsNullOrWhiteSpace(parameters.WorkItemName) || string.IsNullOrWhiteSpace(parameters.JobName)) && parameters.Job == null)
            {
                throw new ArgumentException(Resources.NBT_NoJobSpecified);
            }
            if (string.IsNullOrWhiteSpace(parameters.TaskName))
            {
                throw new ArgumentNullException("TaskName");
            }

            CloudTask task = new CloudTask(parameters.TaskName, parameters.CommandLine);
            task.RunElevated = parameters.RunElevated;

            if (parameters.EnvironmentSettings != null)
            {
                task.EnvironmentSettings = new List<IEnvironmentSetting>();
                foreach (DictionaryEntry d in parameters.EnvironmentSettings)
                {
                    EnvironmentSetting setting = new EnvironmentSetting(d.Key.ToString(), d.Value.ToString());
                    task.EnvironmentSettings.Add(setting);
                }
            }

            if (parameters.ResourceFiles != null)
            {
                task.ResourceFiles = new List<IResourceFile>();
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

            if (parameters.TaskConstraints != null)
            {
                task.TaskConstraints = parameters.TaskConstraints.omObject;
            }

            WriteVerbose(string.Format(Resources.NBT_CreatingTask, parameters.TaskName));
            if (parameters.Job != null)
            {
                parameters.Job.omObject.AddTask(task, parameters.AdditionalBehaviors);
            }
            else
            {
                using (IWorkItemManager wiManager = parameters.Context.BatchOMClient.OpenWorkItemManager())
                {
                    wiManager.AddTask(parameters.WorkItemName, parameters.JobName, task, parameters.AdditionalBehaviors);
                }
            }
        }

        /// <summary>
        /// Deletes the specified Task
        /// </summary>
        /// <param name="parameters">The parameters indicating which Task to delete</param>
        public void DeleteTask(RemoveTaskParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if ((string.IsNullOrWhiteSpace(parameters.WorkItemName) || string.IsNullOrWhiteSpace(parameters.JobName) || string.IsNullOrWhiteSpace(parameters.TaskName)) && parameters.Task == null)
            {
                throw new ArgumentException(Resources.RBT_NoTaskSpecified);
            }

            if (parameters.Task != null)
            {
                parameters.Task.omObject.Delete(parameters.AdditionalBehaviors);
            }
            else
            {
                using (IWorkItemManager wiManager = parameters.Context.BatchOMClient.OpenWorkItemManager())
                {
                    wiManager.DeleteTask(parameters.WorkItemName, parameters.JobName, parameters.TaskName, parameters.AdditionalBehaviors);
                }
            }
        }
    }
}
