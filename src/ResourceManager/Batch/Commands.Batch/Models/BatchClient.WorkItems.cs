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
        /// <param name="options">The options to use when querying for WorkItems</param>
        /// <returns>The WorkItems matching the specified filter options</returns>
        public IEnumerable<PSCloudWorkItem> ListWorkItems(ListWorkItemOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            // Get the single WorkItem matching the specified name
            if (!string.IsNullOrEmpty(options.WorkItemName))
            {
                WriteVerbose(string.Format(Resources.GBWI_GetByName, options.WorkItemName));
                using (IWorkItemManager wiManager = options.Context.BatchOMClient.OpenWorkItemManager())
                {
                    ICloudWorkItem workItem = wiManager.GetWorkItem(options.WorkItemName, additionalBehaviors: options.AdditionalBehaviors);
                    PSCloudWorkItem psWorkItem = new PSCloudWorkItem(workItem);
                    return new PSCloudWorkItem[] { psWorkItem };
                }
            }
            // List WorkItems using the specified filter
            else
            {
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    WriteVerbose(Resources.GBWI_GetByOData);
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    WriteVerbose(Resources.GBWI_NoFilter);
                }
                using (IWorkItemManager wiManager = options.Context.BatchOMClient.OpenWorkItemManager())
                {
                    IEnumerableAsyncExtended<ICloudWorkItem> workItems = wiManager.ListWorkItems(odata, options.AdditionalBehaviors);
                    Func<ICloudWorkItem, PSCloudWorkItem> mappingFunction = w => { return new PSCloudWorkItem(w); };
                    if (options.MaxCount <= 0)
                    {
                        return new PSAsyncEnumerable<PSCloudWorkItem, ICloudWorkItem>(workItems, mappingFunction);
                    }
                    else
                    {
                        WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount));
                        return new PSAsyncEnumerable<PSCloudWorkItem, ICloudWorkItem>(workItems, mappingFunction).Take(options.MaxCount);
                    }
                }
            }
        }
    }
}
