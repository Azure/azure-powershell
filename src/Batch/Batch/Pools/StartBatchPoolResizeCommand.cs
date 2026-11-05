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
using System;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchPoolResize"), OutputType(typeof(void))]
    public class StartBatchPoolResizeCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true,
            Mandatory = true, HelpMessage = "The id of the pool to resize.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The number of target dedicated compute nodes.")]
        [ValidateNotNullOrEmpty]
        [Alias("TargetDedicated")]
        public int? TargetDedicatedComputeNodes { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The number of target low-priority compute nodes.")]
        [ValidateNotNullOrEmpty]
        public int? TargetLowPriorityComputeNodes { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public TimeSpan? ResizeTimeout { get; set; }

        [CmdletParameterBreakingChangeWithVersion("ComputeNodeDeallocationOption", "18.0.0", "5.0.0", ChangeDescription = "The Batch API has deprecated the RetainedData value, and a newer API version removes it, so RetainedData is being removed from this parameter (Requeue, Terminate and TaskCompletion stay). Use TaskCompletion instead, and upload task data to Azure Storage in your task.")]
        [Parameter]
        [ValidateNotNullOrEmpty]
        public ComputeNodeDeallocationOption? ComputeNodeDeallocationOption { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            PoolResizeParameters parameters = new PoolResizeParameters(this.BatchContext, this.Id, null, this.AdditionalBehaviors)
            {
                TargetDedicatedComputeNodes = this.TargetDedicatedComputeNodes,
                TargetLowPriorityComputeNodes = this.TargetLowPriorityComputeNodes,
                ResizeTimeout = this.ResizeTimeout,
                ComputeNodeDeallocationOption = this.ComputeNodeDeallocationOption
            };

            BatchClient.ResizePool(parameters);
        }
    }
}
