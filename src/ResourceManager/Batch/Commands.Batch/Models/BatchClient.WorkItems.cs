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
using Microsoft.Azure.Commands.Batch.Utils;
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
            if (!string.IsNullOrWhiteSpace(options.WorkItemName))
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
                string verboseLogString = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = Resources.GBWI_GetByOData;
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    verboseLogString = Resources.GBWI_NoFilter;
                }
                WriteVerbose(verboseLogString);

                using (IWorkItemManager wiManager = options.Context.BatchOMClient.OpenWorkItemManager())
                {
                    IEnumerableAsyncExtended<ICloudWorkItem> workItems = wiManager.ListWorkItems(odata, options.AdditionalBehaviors);
                    Func<ICloudWorkItem, PSCloudWorkItem> mappingFunction = w => { return new PSCloudWorkItem(w); };
                    return PSAsyncEnumerable<PSCloudWorkItem, ICloudWorkItem>.CreateWithMaxCount(
                        workItems, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
                }
            }
        }

        /// <summary>
        /// Creates a new WorkItem
        /// </summary>
        /// <param name="parameters">The parameters to use when creating the WorkItem</param>
        public void CreateWorkItem(NewWorkItemParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (string.IsNullOrWhiteSpace(parameters.WorkItemName))
            {
                throw new ArgumentNullException("WorkItemName");
            }

            using (IWorkItemManager wiManager = parameters.Context.BatchOMClient.OpenWorkItemManager())
            {
                ICloudWorkItem workItem = wiManager.CreateWorkItem(parameters.WorkItemName);

                if (parameters.Schedule != null)
                {
                    workItem.Schedule = parameters.Schedule.omObject;
                }

                if (parameters.JobSpecification != null)
                {
                    Utils.Utils.JobSpecificationSyncCollections(parameters.JobSpecification);
                    workItem.JobSpecification = parameters.JobSpecification.omObject;
                }

                if (parameters.JobExecutionEnvironment != null)
                {
                    Utils.Utils.JobExecutionEnvironmentSyncCollections(parameters.JobExecutionEnvironment);
                    workItem.JobExecutionEnvironment = parameters.JobExecutionEnvironment.omObject;
                }

                if (parameters.Metadata != null)
                {
                    workItem.Metadata = new List<IMetadataItem>();
                    foreach (DictionaryEntry d in parameters.Metadata)
                    {
                        MetadataItem metadata = new MetadataItem(d.Key.ToString(), d.Value.ToString());
                        workItem.Metadata.Add(metadata);
                    }
                }
                WriteVerbose(string.Format(Resources.NBWI_CreatingWorkItem, parameters.WorkItemName));
                workItem.Commit(parameters.AdditionalBehaviors);
            }
        }

        /// <summary>
        /// Deletes the specified WorkItem
        /// </summary>
        /// <param name="context">The account to use</param>
        /// <param name="workItemName">The name of the WorkItem to delete</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform</param>
        public void DeleteWorkItem(BatchAccountContext context, string workItemName, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (string.IsNullOrWhiteSpace(workItemName))
            {
                throw new ArgumentNullException("workItemName");
            }

            using (IWorkItemManager wiManager = context.BatchOMClient.OpenWorkItemManager())
            {
                wiManager.DeleteWorkItem(workItemName, additionBehaviors);
            }
        }
    }
}
