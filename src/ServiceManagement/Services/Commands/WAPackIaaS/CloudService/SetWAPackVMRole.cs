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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.CloudService
{
    [Cmdlet(VerbsCommon.Set, "WAPackVMRole", DefaultParameterSetName = WAPackCmdletParameterSets.FromVMRoleObject)]
    public class SetWAPackVMRole : IaaSCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromVMRoleObject, ValueFromPipeline = true, HelpMessage = "Existing VMRole Object.")]
        [ValidateNotNullOrEmpty]
        public VMRole VMRole
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromVMRoleObject, HelpMessage = "New VMRole Instance Count.")]
        [ValidateNotNullOrEmpty]
        public int InstanceCount
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            Guid? jobId = null;
            var vmRoleOperations = new VMRoleOperations(this.WebClientFactory);
            vmRoleOperations.SetInstanceCount(this.VMRole.Name, this.VMRole, this.InstanceCount, out jobId);
            var jobInfo = WaitForJobCompletion(jobId);

            if (this.PassThru)
            {
                WriteObject(jobInfo.jobStatus != JobStatusEnum.Failed);
            }
        }
    }
}
