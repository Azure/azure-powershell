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

using Microsoft.Azure.Commands.Batch.Models;
using System;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Set, Constants.AzureBatchComputeNodeUser)]
    public class SetBatchComputeNodeUserCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "The id of the pool containing the compute node.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "The id of the compute node containing the user account to update.")]
        [ValidateNotNullOrEmpty]
        public string ComputeNodeId { get; set; }

        [Parameter(Position = 2, Mandatory = true,
            HelpMessage = "The name of the user account to update.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The account password.")]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public DateTime ExpiryTime { get; set; }

        public override void ExecuteCmdlet()
        {
            UpdateComputeNodeUserParameters parameters = new UpdateComputeNodeUserParameters(this.BatchContext,
                this.PoolId, this.ComputeNodeId, this.Name, this.AdditionalBehaviors)
            {
                Password = this.Password,
                ExpiryTime = this.ExpiryTime
            };
            this.BatchClient.UpdateComputeNodeUser(parameters);
        }
    }
}
