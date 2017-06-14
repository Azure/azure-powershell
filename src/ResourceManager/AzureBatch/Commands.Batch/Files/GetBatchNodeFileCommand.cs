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
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, Constants.AzureBatchNodeFile, DefaultParameterSetName = ComputeNodeAndIdParameterSet),
        OutputType(typeof(PSNodeFile))]
    public class GetBatchNodeFileCommand : BatchObjectModelCmdletBase
    {
        internal const string TaskAndIdParameterSet = "Task_Id";
        internal const string TaskAndODataParameterSet = "Task_ODataFilter";
        internal const string ParentTaskObjectParameterSet = "ParentTask";
        internal const string ComputeNodeAndIdParameterSet = "ComputeNode_Id";
        internal const string ComputeNodeAndODataParameterSet = "ComputeNode_ODataFilter";
        internal const string ParentComputeNodeObjectParameterSet = "ParentComputeNode";

        private int maxCount = Constants.DefaultMaxCount;

        [Parameter(ParameterSetName = TaskAndIdParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the job containing the specified target task.")]
        [Parameter(ParameterSetName = TaskAndODataParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(ParameterSetName = TaskAndIdParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the task.")]
        [Parameter(ParameterSetName = TaskAndODataParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string TaskId { get; set; }

        [Parameter(Position = 0, ParameterSetName = ParentTaskObjectParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSCloudTask Task { get; set; }

        [Parameter(Position = 0, ParameterSetName = ComputeNodeAndIdParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the pool which contains the specified target compute node.")]
        [Parameter(Position = 0, ParameterSetName = ComputeNodeAndODataParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, ParameterSetName = ComputeNodeAndIdParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the compute node.")]
        [Parameter(Position = 1, ParameterSetName = ComputeNodeAndODataParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ComputeNodeId { get; set; }

        [Parameter(Position = 0, ParameterSetName = ParentComputeNodeObjectParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSComputeNode ComputeNode { get; set; }

        [Parameter(Position = 2, ParameterSetName = ComputeNodeAndIdParameterSet)]
        [Parameter(ParameterSetName = TaskAndIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = TaskAndODataParameterSet)]
        [Parameter(ParameterSetName = ParentTaskObjectParameterSet)]
        [Parameter(ParameterSetName = ComputeNodeAndODataParameterSet)]
        [Parameter(ParameterSetName = ParentComputeNodeObjectParameterSet)]
        public string Filter { get; set; }

        [Parameter(ParameterSetName = TaskAndODataParameterSet)]
        [Parameter(ParameterSetName = ParentTaskObjectParameterSet)]
        [Parameter(ParameterSetName = ComputeNodeAndODataParameterSet)]
        [Parameter(ParameterSetName = ParentComputeNodeObjectParameterSet)]
        public int MaxCount
        {
            get { return this.maxCount; }
            set { this.maxCount = value; }
        }

        [Parameter(ParameterSetName = TaskAndODataParameterSet)]
        [Parameter(ParameterSetName = ParentTaskObjectParameterSet)]
        [Parameter(ParameterSetName = ComputeNodeAndODataParameterSet)]
        [Parameter(ParameterSetName = ParentComputeNodeObjectParameterSet)]
        public SwitchParameter Recursive { get; set; }

        public override void ExecuteCmdlet()
        {
            ListNodeFileOptions options = new ListNodeFileOptions(this.BatchContext, this.JobId, this.TaskId, this.Task, this.PoolId,
                this.ComputeNodeId, this.ComputeNode, this.AdditionalBehaviors)
            {
                NodeFileName = this.Name,
                Filter = this.Filter,
                MaxCount = this.MaxCount,
                Recursive = this.Recursive.IsPresent
            };

            // The enumerator will internally query the service in chunks. Using WriteObject with the enumerate flag will enumerate
            // the entire collection first and then write the items out one by one in a single group.  Using foreach, we can take 
            // advantage of the enumerator's behavior and write output to the pipeline in bursts.
            foreach (PSNodeFile nodeFile in BatchClient.ListNodeFiles(options))
            {
                WriteObject(nodeFile);
            }
        }
    }
}
