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
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchComputeNode", DefaultParameterSetName = Constants.IdParameterSet, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveBatchComputeNodeCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The id of the pool that contains the compute nodes.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The ids of the compute nodes to remove from the pool.")]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public string[] Ids { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSComputeNode ComputeNode { get; set; }

        [CmdletParameterBreakingChangeWithVersion("DeallocationOption", "18.0.0", "5.0.0", ChangeDescription = "The Batch API has deprecated the RetainedData value, and a newer API version removes it, so RetainedData is being removed from this parameter (Requeue, Terminate and TaskCompletion stay). Use TaskCompletion instead, and upload task data to Azure Storage in your task.")]
        [Parameter]
        public ComputeNodeDeallocationOption? DeallocationOption { get; set; }

        [Parameter]
        public TimeSpan? ResizeTimeout { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            string computeNodeIds = ComputeNode == null ? string.Join(",", this.Ids) : ComputeNode.Id;
            RemoveComputeNodeParameters parameters = new RemoveComputeNodeParameters(this.BatchContext, this.PoolId,
                this.Ids, this.ComputeNode, this.AdditionalBehaviors)
            {
                DeallocationOption = this.DeallocationOption,
                ResizeTimeout = this.ResizeTimeout
            };

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveComputeNodeConfirm, computeNodeIds),
                Resources.RemoveComputeNode,
                computeNodeIds,
                () => BatchClient.RemoveComputeNodesFromPool(parameters));
        }
    }
}
