﻿// ----------------------------------------------------------------------------------
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
        /// Lists the jobs matching the specified filter options
        /// </summary>
        /// <param name="options">The options to use when querying for jobs</param>
        /// <returns>The jobs matching the specified filter options</returns>
        public IEnumerable<PSCloudJob> ListJobs(ListJobOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            string wiName = options.WorkItem == null ? options.WorkItemName : options.WorkItem.Name;

            // Get the single job matching the specified name
            if (!string.IsNullOrEmpty(options.JobName))
            {
                WriteVerbose(string.Format(Resources.GBJ_GetByName, options.JobName, wiName));
                using (IWorkItemManager wiManager = options.Context.BatchOMClient.OpenWorkItemManager())
                {
                    ICloudJob job = wiManager.GetJob(wiName, options.JobName, additionalBehaviors: options.AdditionalBehaviors);
                    PSCloudJob psJob = new PSCloudJob(job);
                    return new PSCloudJob[] { psJob };
                }
            }
            // List jobs using the specified filter
            else
            {
                ODATADetailLevel odata = null;
                string verboseLogString = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = string.Format(Resources.GBJ_GetByOData, wiName);
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    verboseLogString = string.Format(Resources.GBJ_GetNoFilter, wiName);
                }
                WriteVerbose(verboseLogString);

                using (IWorkItemManager wiManager = options.Context.BatchOMClient.OpenWorkItemManager())
                {
                    IEnumerableAsyncExtended<ICloudJob> jobs = wiManager.ListJobs(wiName, odata, options.AdditionalBehaviors);
                    Func<ICloudJob, PSCloudJob> mappingFunction = j => { return new PSCloudJob(j); };
                    return PSAsyncEnumerable<PSCloudJob, ICloudJob>.CreateWithMaxCount(
                        jobs, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
                }             
            }
        }

        /// <summary>
        /// Deletes the specified job
        /// </summary>
        /// <param name="parameters">The parameters indicating which job to delete</param>
        public void DeleteJob(JobOperationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            if (parameters.Job != null)
            {
                parameters.Job.omObject.Delete(parameters.AdditionalBehaviors);
            }
            else
            {
                using (IWorkItemManager wiManager = parameters.Context.BatchOMClient.OpenWorkItemManager())
                {
                    wiManager.DeleteJob(parameters.WorkItemName, parameters.JobName, parameters.AdditionalBehaviors);
                }
            }
        }
    }
}
