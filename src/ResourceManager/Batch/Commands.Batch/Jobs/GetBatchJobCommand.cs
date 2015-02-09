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
        OutputType(typeof(PSCloudJob), ParameterSetName = new string[] { Constants.NameParameterSet, Constants.ParentObjectWithNameParameterSet }),
        OutputType(typeof(IEnumerableAsyncExtended<PSCloudJob>), ParameterSetName = new string[] { Constants.ODataFilterParameterSet, Constants.ParentObjectWithODataFilterParameterSet, Constants.ParentCollectionWithNameParameterSet, Constants.ParentCollectionWithODataFilterParameterSet })]
    public class GetBatchJobCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the WorkItem containing the Job to query.")]
        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, Mandatory = true, HelpMessage = "The name of the WorkItem containing the Jobs to query.")]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.NameParameterSet, HelpMessage = "The name of the Job to query.")]
        [Parameter(Position = 1, ParameterSetName = Constants.ParentObjectWithNameParameterSet)]
        [Parameter(Position = 1, ParameterSetName = Constants.ParentCollectionWithNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.ParentObjectWithNameParameterSet, ValueFromPipeline = true, HelpMessage = "The WorkItem containing the Jobs to query.")]
        [Parameter(Position = 0, ParameterSetName = Constants.ParentObjectWithODataFilterParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSCloudWorkItem Parent { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.ParentCollectionWithNameParameterSet, ValueFromPipeline = true, HelpMessage = "The WorkItems containing the Jobs to query.")]
        [Parameter(Position = 0, ParameterSetName = Constants.ParentCollectionWithODataFilterParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public IEnumerableAsyncExtended<PSCloudWorkItem> ParentCollection { get; set; }
            
        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, HelpMessage = "OData filter to use when querying for Jobs.")]
        [Parameter(ParameterSetName = Constants.ParentObjectWithODataFilterParameterSet)]
        [Parameter(ParameterSetName = Constants.ParentCollectionWithODataFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteVerboseWithTimestamp(string.Format("WorkItemName: {0}, Name: {1}, Filter: {2}, Parent: {3}, ParentCollection: {4}", WorkItemName, Name, Filter, Parent, ParentCollection));

            if (!string.IsNullOrEmpty(Name))
            {
                //WriteVerboseWithTimestamp(Resources.GBP_GetByName, Name);
                if (Parent != null)
                {
                    WriteObject(GetJob(Parent, Name, additionalBehaviors: AdditionalBehaviors));
                }
                else if (ParentCollection != null)
                {
                    foreach (PSCloudWorkItem workItem in ParentCollection)
                    {
                        WriteObject(GetJob(workItem, Name, additionalBehaviors: AdditionalBehaviors));
                    }
                }
                else
                {
                    WriteObject(GetJob(WorkItemName, Name, additionalBehaviors: AdditionalBehaviors));
                }
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
                if (Parent != null)
                {
                    WriteObject(ListJobs(Parent, odata, AdditionalBehaviors));
                }
                else if (ParentCollection != null)
                {
                    foreach (PSCloudWorkItem workItem in ParentCollection)
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

        private PSCloudJob GetJob(PSCloudWorkItem workItem, string jobName, ODATADetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            ICloudJob job = workItem.omObject.GetJob(jobName, detailLevel, additionalBehaviors);
            return new PSCloudJob(job);
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
