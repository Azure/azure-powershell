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

using System;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Properties;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Remove, Constants.AzureBatchComputeNodeUser, SupportsShouldProcess = true)]
    public class RemoveBatchComputeNodeUserCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The id of the pool that contains the compute node.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The id of the compute node that contains the user.")]
        [ValidateNotNullOrEmpty]
        public string ComputeNodeId { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the compute node user to delete.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            ComputeNodeUserOperationParameters parameters = new ComputeNodeUserOperationParameters(this.BatchContext, this.PoolId, this.ComputeNodeId,
                this.Name, this.AdditionalBehaviors);

            ConfirmAction(
                Resources.RemoveComputeNodeUser,
                this.Name,
                () => BatchClient.DeleteComputeNodeUser(parameters));
        }
    }
}
