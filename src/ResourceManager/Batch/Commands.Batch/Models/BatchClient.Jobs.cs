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
        /// Lists the Jobs matching the specified filter options
        /// </summary>
        /// <param name="options">The options to use when querying for Jobs</param>
        /// <returns>The Jobs matching the specified filter options</returns>
        public IEnumerable<PSCloudJob> ListJobs(ListJobOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if (string.IsNullOrEmpty(options.WorkItemName) && options.WorkItem == null)
            {
                throw new ArgumentNullException(Resources.GBJ_NoWorkItem);    
            }
            string wiName = options.WorkItem == null ? options.WorkItemName : options.WorkItem.Name;

            // Get the single Job matching the specified name
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
            // List Jobs using the specified filter
            else
            {
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    WriteVerbose(string.Format(Resources.GBJ_GetByOData, wiName));
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    WriteVerbose(string.Format(Resources.GBJ_GetNoFilter, wiName));
                }

                using (IWorkItemManager wiManager = options.Context.BatchOMClient.OpenWorkItemManager())
                {
                    IEnumerableAsyncExtended<ICloudJob> jobs = wiManager.ListJobs(wiName, odata, options.AdditionalBehaviors);
                    Func<ICloudJob, PSCloudJob> mappingFunction = j => { return new PSCloudJob(j); };
                    if (options.MaxCount <= 0)
                    {
                        return new PSAsyncEnumerable<PSCloudJob, ICloudJob>(jobs, mappingFunction);           
                    }
                    else
                    {
                        WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount));
                        return new PSAsyncEnumerable<PSCloudJob, ICloudJob>(jobs, mappingFunction).Take(options.MaxCount);              
                    }
                }             
            }
        }
    }
}
