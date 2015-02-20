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
        /// <param name="context">The account details</param>
        /// <param name="workItemName">The name of the WorkItem to query for Jobs</param>
        /// <param name="workItem">The WorkItem to query for Jobs</param>
        /// <param name="jobName">If specified, the single Job matching the specified name will be returned</param>
        /// <param name="filter">The OData filter to use when querying for Jobs</param>
        /// <param name="maxCount">The maximum number of Jobs to return</param>
        /// <param name="additionalBehaviors">Additional client behaviors to perform</param>
        /// <returns>The Jobs matching the specified filter options</returns>
        public IEnumerable<PSCloudJob> ListJobs(BatchAccountContext context, string workItemName, PSCloudWorkItem workItem, string jobName,
            string filter, int maxCount, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            if (string.IsNullOrEmpty(workItemName) && workItem == null)
            {
                throw new ArgumentNullException(Resources.GBJ_NoWorkItem);    
            }
            string wiName = workItem == null ? workItemName : workItem.Name;

            // Get the single Job matching the specified name
            if (!string.IsNullOrEmpty(jobName))
            {
                WriteVerbose(string.Format(Resources.GBJ_GetByName, jobName, wiName));
                using (IWorkItemManager wiManager = context.BatchOMClient.OpenWorkItemManager())
                {
                    ICloudJob job = wiManager.GetJob(wiName, jobName, additionalBehaviors: additionalBehaviors);
                    PSCloudJob psJob = new PSCloudJob(job);
                    return new PSCloudJob[] { psJob };
                }
            }
            // List Jobs using the specified filter
            else
            {
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(filter))
                {
                    WriteVerbose(string.Format(Resources.GBJ_GetByOData, wiName, maxCount));
                    odata = new ODATADetailLevel(filterClause: filter);
                }
                else
                {
                    WriteVerbose(string.Format(Resources.GBJ_GetNoFilter, wiName, maxCount));
                }

                using (IWorkItemManager wiManager = context.BatchOMClient.OpenWorkItemManager())
                {
                    IEnumerableAsyncExtended<ICloudJob> jobs = wiManager.ListJobs(wiName, odata, additionalBehaviors);
                    Func<ICloudJob, PSCloudJob> mappingFunction = j => { return new PSCloudJob(j); };
                    return new PSAsyncEnumerable<PSCloudJob, ICloudJob>(jobs, mappingFunction).Take(maxCount);           
                }             
            }
        }
    }
}
