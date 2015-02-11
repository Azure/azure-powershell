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
    [Cmdlet(VerbsCommon.Get, "AzureBatchJob", DefaultParameterSetName = Constants.NameParameterSet),
        OutputType(typeof(PSCloudJob), ParameterSetName = new string[] { Constants.NameParameterSet }),
        OutputType(typeof(IEnumerableAsyncExtended<PSCloudJob>), ParameterSetName = new string[] { Constants.ODataFilterParameterSet, Constants.ParentObjectParameterSet, Constants.ParentCollectionParameterSet })]
    public class GetBatchJobCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the WorkItem containing the Job to query.")]
        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, Mandatory = true, HelpMessage = "The name of the WorkItem containing the Jobs to query.")]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.NameParameterSet, HelpMessage = "The name of the Job to query.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The WorkItem containing the Jobs to query.")]
        [ValidateNotNullOrEmpty]
        public PSCloudWorkItem WorkItem { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.ParentCollectionParameterSet, ValueFromPipeline = true, HelpMessage = "The WorkItems containing the Jobs to query.")]
        [ValidateNotNullOrEmpty]
        public IEnumerableAsyncExtended<PSCloudWorkItem> WorkItemCollection { get; set; }
            
        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, HelpMessage = "OData filter to use when querying for Jobs.")]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        [Parameter(ParameterSetName = Constants.ParentCollectionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(WorkItemName) && !string.IsNullOrEmpty(Name))
            {
                //WriteVerboseWithTimestamp(Resources.GBP_GetByName, Name);
                WriteObject(GetJob(WorkItemName, Name, additionalBehaviors: AdditionalBehaviors));
            }
            else
            {
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(Filter))
                {
                    //WriteVerboseWithTimestamp(Resources.GBP_GetByOData);
                    odata = new ODATADetailLevel(filterClause: Filter);
                }
                else
                {
                    //WriteVerboseWithTimestamp(Resources.GBP_NoFilter);
                }
                if (WorkItem != null)
                {
                    WriteObject(ListJobs(WorkItem, odata, AdditionalBehaviors));
                }
                else if (WorkItemCollection != null)
                {
                    foreach (PSCloudWorkItem workItem in WorkItemCollection)
                    {
                        WriteObject(ListJobs(workItem, odata, AdditionalBehaviors));
                    }
                }
                else
                {
                    WriteObject(ListJobs(WorkItemName, odata, AdditionalBehaviors));
                }
            }
        }

        private PSCloudJob GetJob(string workItemName, string jobName, ODATADetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (IWorkItemManager wiManager = BatchContext.BatchOMClient.OpenWorkItemManager())
            {
                ICloudJob job = wiManager.GetJob(workItemName, jobName, detailLevel, additionalBehaviors);
                return new PSCloudJob(job);
            }
        }

        private PSAsyncEnumerable<PSCloudJob, ICloudJob> ListJobs(string workItemName, ODATADetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (IWorkItemManager wiManager = BatchContext.BatchOMClient.OpenWorkItemManager())
            {
                IEnumerableAsyncExtended<ICloudJob> jobEnumerator = wiManager.ListJobs(workItemName, detailLevel, additionalBehaviors);
                Func<ICloudJob, PSCloudJob> mappingFunction = j => { return new PSCloudJob(j); };
                return new PSAsyncEnumerable<PSCloudJob, ICloudJob>(jobEnumerator, mappingFunction);
            }
        }

        private PSAsyncEnumerable<PSCloudJob, ICloudJob> ListJobs(PSCloudWorkItem workItem, ODATADetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            IEnumerableAsyncExtended<ICloudJob> jobEnumerator = workItem.omObject.ListJobs(detailLevel, additionalBehaviors);
            Func<ICloudJob, PSCloudJob> mappingFunction = j => { return new PSCloudJob(j); };
            return new PSAsyncEnumerable<PSCloudJob, ICloudJob>(jobEnumerator, mappingFunction);
        }
    }
}
