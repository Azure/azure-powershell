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

using System.Collections;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.Batch.Properties;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Remove, "AzureBatchUser")]
    public class RemoveBatchUserCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the pool that contains the vm.")]
        [ValidateNotNullOrEmpty]
        public string PoolName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the vm that contains the user.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the user to delete.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            RemoveUserParameters parameters = new RemoveUserParameters()
            {
                Context = this.BatchContext,
                PoolName = this.PoolName,
                VMName = this.VMName,
                UserName = this.Name,
                AdditionalBehaviors = this.AdditionalBehaviors
            };

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RBU_RemoveConfirm, this.Name),
                Resources.RBU_RemoveUser,
                this.Name,
                () => BatchClient.DeleteUser(parameters));
        }
    }
}
