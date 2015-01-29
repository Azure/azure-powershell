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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, "AzureBatchWorkItem", DefaultParameterSetName = Constants.NameParameterSet),
        OutputType(typeof(PSCloudWorkItem), ParameterSetName = new string[] { Constants.NameParameterSet }),
        OutputType(typeof(IEnumerableAsyncExtended<PSCloudWorkItem>), ParameterSetName = new string[] { Constants.ODataFilterParameterSet })]
    public class GetBatchWorkItemCommand : BatchOMCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, Mandatory = false, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the WorkItem to query.")]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = Constants.ODataFilterParameterSet, HelpMessage = "OData filter to use when querying for WorkItems.")]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        protected override void ServiceRequest()
        {
            if (!string.IsNullOrEmpty(WorkItemName))
            {
                WriteVerboseWithTimestamp(Resources.GBWI_GetByName, WorkItemName);
                PSCloudWorkItem workItem = GetWorkItem(WorkItemName, additionalBehaviors: AdditionalBehaviors);
                WriteObject(workItem);
            }
            else
            {
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(Filter))
                {
                    WriteVerboseWithTimestamp(Resources.GBWI_GetByOData);
                    odata = new ODATADetailLevel(filterClause: Filter);
                }
                else
                {
                    WriteVerboseWithTimestamp(Resources.GBWI_NoFilter);
                }
                PSAsyncEnumerable<PSCloudWorkItem, ICloudWorkItem> workItemEnumerator = ListWorkItems(odata, AdditionalBehaviors);
                WriteObject(workItemEnumerator);
            }
        }

        private PSCloudWorkItem GetWorkItem(string workItemName, ODATADetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (IWorkItemManager wiManager = BatchContext.BatchOMClient.OpenWorkItemManager())
            {
                ICloudWorkItem workItem = wiManager.GetWorkItem(workItemName, detailLevel, additionalBehaviors);
                return new PSCloudWorkItem(workItem);
            }
        }

        private PSAsyncEnumerable<PSCloudWorkItem, ICloudWorkItem> ListWorkItems(ODATADetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (IWorkItemManager wiManager = BatchContext.BatchOMClient.OpenWorkItemManager())
            {
                IEnumerableAsyncExtended<ICloudWorkItem> workItemEnumerator = wiManager.ListWorkItems(detailLevel, additionalBehaviors);
                Func<ICloudWorkItem, PSCloudWorkItem> mappingFunction = w => { return new PSCloudWorkItem(w); };
                return new PSAsyncEnumerable<PSCloudWorkItem, ICloudWorkItem>(workItemEnumerator, mappingFunction);
            }
        }
    }
}
