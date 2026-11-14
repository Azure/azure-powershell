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
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Reset", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchComputeNode", DefaultParameterSetName = Constants.IdParameterSet), OutputType(typeof(void))]
    public class ResetBatchComputeNodeCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The id of the pool that contains the compute node.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The id of the compute node to reimage.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSComputeNode ComputeNode { get; set; }

        [CmdletParameterBreakingChangeWithVersion("ReimageOption", "18.0.0", "5.0.0", ChangeDescription = "The Batch API has deprecated the RetainedData value, and a newer API version removes it, so RetainedData is being removed from this parameter (Requeue, Terminate and TaskCompletion stay). Use TaskCompletion instead, and upload task data to Azure Storage in your task.")]
        [Parameter]
        [ValidateNotNullOrEmpty]
        public ComputeNodeReimageOption? ReimageOption { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            ReimageComputeNodeParameters parameters = new ReimageComputeNodeParameters(this.BatchContext, this.PoolId,
                this.Id, this.ComputeNode, this.AdditionalBehaviors)
            {
                ReimageOption = this.ReimageOption
            };
            BatchClient.ReimageComputeNode(parameters);
        }
    }
}
