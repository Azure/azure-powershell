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
using System;
using System.Collections;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, "AzureBatchUser")]
    public class NewBatchUserCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, Mandatory = true, HelpMessage = "The name of the pool containing the vm to create the user on.")]
        [ValidateNotNullOrEmpty]
        public string PoolName { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.NameParameterSet, Mandatory = true, HelpMessage = "The name of the vm to create the user on.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The PSVM object representing the vm to create the user on.")]
        [ValidateNotNullOrEmpty]
        public PSVM VM { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the local windows account created.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "The account password.")]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter(HelpMessage = "The expiry time.")]
        [ValidateNotNullOrEmpty]
        public DateTime ExpiryTime { get; set; }

        [Parameter(HelpMessage = "If present, the user is created with administrator privilege.")]
        public SwitchParameter IsAdmin { get; set; }

        public override void ExecuteCmdlet()
        {
            NewUserParameters parameters = new NewUserParameters()
            {
                Context = this.BatchContext,
                PoolName = this.PoolName,
                VMName = this.VMName,
                UserName = this.Name,
                VM = this.VM,
                Password = this.Password,
                ExpiryTime = this.ExpiryTime,
                IsAdmin = this.IsAdmin.IsPresent,
                AdditionalBehaviors = this.AdditionalBehaviors
            };

            BatchClient.CreateUser(parameters);
        }
    }
}
