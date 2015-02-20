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
        /// <param name="context">The account details</param>
        /// <param name="workItemName">The name of the WorkItem to query for Tasks</param>
        /// <param name="jobName">The name of the Job to query for Tasks</param>
        /// <param name="job">The Job to query for Tasks</param>
        /// <param name="taskName">If specified, the single Task with this name will be returned</param>
        /// <param name="filter">The OData filter to use when querying for Tasks</param>
        /// <param name="maxCount">The maximum number of Tasks to return</param>
        /// <param name="additionalBehaviors">Additional client behaviors to perform</param>
        /// <returns>The Tasks matching the specified filter options</returns>
        public IEnumerable<PSCloudTask> ListTasks(BatchAccountContext context, string workItemName, string jobName, PSCloudJob job, string taskName,
            string filter, int maxCount, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            if ((string.IsNullOrEmpty(workItemName) || string.IsNullOrEmpty(jobName)) && job == null)
            {
                throw new ArgumentNullException(Resources.GBT_NoJob);
            }

            // Get the single Task matching the specified name
            if (!string.IsNullOrEmpty(taskName))
            {
                WriteVerbose(string.Format(Resources.GBT_GetByName, taskName, jobName, workItemName));
                using (IWorkItemManager wiManager = context.BatchOMClient.OpenWorkItemManager())
                {
                    ICloudTask task = wiManager.GetTask(workItemName, jobName, taskName, additionalBehaviors: additionalBehaviors);
                    PSCloudTask psTask = new PSCloudTask(task);
                    return new PSCloudTask[] { psTask };
                }
            }
            // List Tasks using the specified filter
            else
            {
                string jName = job == null ? jobName : job.Name;
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(filter))
                {
                    WriteVerbose(string.Format(Resources.GBT_GetByOData, jName, maxCount));
                    odata = new ODATADetailLevel(filterClause: filter);
                }
                else
                {
                    WriteVerbose(string.Format(Resources.GBT_GetNoFilter, jName, maxCount));
                }

                IEnumerableAsyncExtended<ICloudTask> tasks = null;
                if (job != null)
                {
                    tasks = job.omObject.ListTasks(odata, additionalBehaviors);
                }
                else
                {
                    using (IWorkItemManager wiManager = context.BatchOMClient.OpenWorkItemManager())
                    {
                        tasks = wiManager.ListTasks(workItemName, jobName, odata, additionalBehaviors);
                    }
                }
                Func<ICloudTask, PSCloudTask> mappingFunction = t => { return new PSCloudTask(t); };
                return new PSAsyncEnumerable<PSCloudTask, ICloudTask>(tasks, mappingFunction).Take(maxCount);
            }
        }
    }
}
