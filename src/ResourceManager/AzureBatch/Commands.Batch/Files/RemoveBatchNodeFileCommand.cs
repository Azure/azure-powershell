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
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Remove, Constants.AzureBatchNodeFile, SupportsShouldProcess = true)]
    public class RemoveBatchNodeFileCommand : BatchObjectModelCmdletBase
    {
        internal const string TaskParameterSet = "Task";
        internal const string ComputeNodeParameterSet = "ComputeNode";

        [Parameter(ParameterSetName = TaskParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the job containing the task.")]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(ParameterSetName = TaskParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the task.")]
        public string TaskId { get; set; }

        [Parameter(Position = 0, ParameterSetName = ComputeNodeParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the pool containing the compute node.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, ParameterSetName = ComputeNodeParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the compute node.")]
        [ValidateNotNullOrEmpty]
        public string ComputeNodeId { get; set; }

        [Parameter(ParameterSetName = TaskParameterSet, Mandatory = true,
            HelpMessage = "The name of the node file to delete.")]
        [Parameter(Position = 2, ParameterSetName = ComputeNodeParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSNodeFile InputObject { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        [Parameter]
        public SwitchParameter Recursive { get; set; }

        public override void ExecuteCmdlet()
        {
            string fileName = this.InputObject == null ? this.Name : this.InputObject.Name;
            NodeFileOperationParameters parameters = new NodeFileOperationParameters(this.BatchContext, this.JobId, this.TaskId, this.PoolId,
                this.ComputeNodeId, this.Name, this.InputObject, this.AdditionalBehaviors);

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveNodeFileConfirm, fileName),
                Resources.RemoveNodeFile,
                fileName,
                () => BatchClient.DeleteNodeFile(Recursive.IsPresent, parameters));
        }
    }
}
