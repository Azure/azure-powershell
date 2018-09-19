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
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.CloudService
{
    [Cmdlet(VerbsCommon.Remove, "WAPackVMRole", DefaultParameterSetName = WAPackCmdletParameterSets.FromVMRoleObject, SupportsShouldProcess = true)]
    public class RemoveWAPackVMRole : IaaSCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromVMRoleObject, ValueFromPipeline = true, HelpMessage = "Existing VMRole Object.")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromCloudService, ValueFromPipeline = true, HelpMessage = "Existing VMRole Object.")]
        [ValidateNotNullOrEmpty]
        public VMRole VMRole
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromCloudService, HelpMessage = "VMRole CloudServiceName.")]
        [ValidateNotNullOrEmpty]
        public string CloudServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Position = 2, HelpMessage = "Confirm the removal of the VMRole.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
            Force.IsPresent,
            string.Format(Resources.RemoveVMRoleConfirmationMessage, VMRole.Name),
            string.Format(Resources.RemoveVMRoleMessage),
            VMRole.Name,
            () =>
            {
                JobInfo jobInfo = null;
                Guid? vmRoleJobId = null;
                Guid? cloudJobId = null;
                var vmRoleOperations = new VMRoleOperations(this.WebClientFactory);
                
                if (this.ParameterSetName == WAPackCmdletParameterSets.FromVMRoleObject)
                {
                    vmRoleOperations.Delete(VMRole.Name, VMRole.Name, out vmRoleJobId);
                    jobInfo = WaitForJobCompletion(vmRoleJobId);

                    // If no CloudService name is given, we assume the VMRole was created using WAP
                    // in which case the CloudService name is the same as the VMRole name
                    var cloudServiceOperations = new CloudServiceOperations(this.WebClientFactory);
                    cloudServiceOperations.Delete(VMRole.Name, out cloudJobId);
                    WaitForJobCompletion(vmRoleJobId);
                }
                else if (this.ParameterSetName == WAPackCmdletParameterSets.FromCloudService)
                {
                    vmRoleOperations.Delete(this.CloudServiceName, VMRole.Name, out vmRoleJobId);
                    jobInfo = WaitForJobCompletion(vmRoleJobId);
                }

                if (this.PassThru)
                {
                    WriteObject(jobInfo.jobStatus != JobStatusEnum.Failed);
                }
            });
        }
    }
}
