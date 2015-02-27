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

            if ((string.IsNullOrEmpty(options.WorkItemName) || string.IsNullOrEmpty(options.JobName)) && options.Job == null)
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
                if (options.MaxCount <= 0)
                {
                    options.MaxCount = Int32.MaxValue;
                }
                string jName = options.Job == null ? options.JobName : options.Job.Name;
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    WriteVerbose(string.Format(Resources.GBT_GetByOData, jName, options.MaxCount));
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    WriteVerbose(string.Format(Resources.GBT_GetNoFilter, jName, options.MaxCount));
                }

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
                return new PSAsyncEnumerable<PSCloudTask, ICloudTask>(tasks, mappingFunction).Take(options.MaxCount);
            }
        }
    }
}
