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
        /// Lists the WorkItems matching the specified filter options
        /// </summary>
        /// <param name="context">The account details</param>
        /// <param name="workItemName">If specified, the single WorkItem with this name will be returned</param>
        /// <param name="filter">The OData filter to use when querying for WorkItems</param>
        /// <param name="maxCount">The maximum number of WorkItems to return</param>
        /// <param name="additionalBehaviors">Additional client behaviors to perform</param>
        /// <returns>The WorkItems matching the specified filter options</returns>
        public IEnumerable<PSCloudWorkItem> ListWorkItems(BatchAccountContext context, string workItemName, string filter, int maxCount,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // Get the single WorkItem matching the specified name
            if (!string.IsNullOrEmpty(workItemName))
            {
                WriteVerbose(string.Format(Resources.GBWI_GetByName, workItemName));
                using (IWorkItemManager wiManager = context.BatchOMClient.OpenWorkItemManager())
                {
                    ICloudWorkItem workItem = wiManager.GetWorkItem(workItemName, additionalBehaviors: additionalBehaviors);
                    PSCloudWorkItem psWorkItem = new PSCloudWorkItem(workItem);
                    return new PSCloudWorkItem[] { psWorkItem };
                }
            }
            // List WorkItems using the specified filter
            else
            {
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(filter))
                {
                    WriteVerbose(string.Format(Resources.GBWI_GetByOData, maxCount));
                    odata = new ODATADetailLevel(filterClause: filter);
                }
                else
                {
                    WriteVerbose(string.Format(Resources.GBWI_NoFilter, maxCount));
                }
                using (IWorkItemManager wiManager = context.BatchOMClient.OpenWorkItemManager())
                {
                    IEnumerableAsyncExtended<ICloudWorkItem> workItems = wiManager.ListWorkItems(odata, additionalBehaviors);
                    Func<ICloudWorkItem, PSCloudWorkItem> mappingFunction = w => { return new PSCloudWorkItem(w); };
                    return new PSAsyncEnumerable<PSCloudWorkItem, ICloudWorkItem>(workItems, mappingFunction).Take(maxCount);
                }
            }
        }
    }
}
