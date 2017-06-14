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

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsLifecycle.Restart, Constants.AzureBatchComputeNode, DefaultParameterSetName = Constants.IdParameterSet)]
    public class RestartBatchComputeNodeCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The id of the pool that contains the compute node.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.IdParameterSet, Mandatory = true,
            HelpMessage = "The id of the compute node to reboot.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSComputeNode ComputeNode { get; set; }

        [Parameter(Position = 2)]
        [ValidateNotNullOrEmpty]
        public ComputeNodeRebootOption? RebootOption { get; set; }

        public override void ExecuteCmdlet()
        {
            RebootComputeNodeParameters parameters = new RebootComputeNodeParameters(this.BatchContext, this.PoolId,
                this.Id, this.ComputeNode, this.AdditionalBehaviors)
            {
                RebootOption = this.RebootOption
            };
            BatchClient.RebootComputeNode(parameters);
        }
    }
}
