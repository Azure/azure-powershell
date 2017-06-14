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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Remove, ProfileNouns.VirtualMachine, SupportsShouldProcess = true), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureVMCommand : IaaSDeploymentManagementCmdletBase
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the role to remove.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Specify to remove the VM and the underlying disk blob(s).")]
        public SwitchParameter DeleteVHD
        {
            get;
            set;
        }

        protected override void ExecuteCommand()
        {
            if (this.ShouldProcess(String.Format("Service: {0},  VM: {1}", this.ServiceName, this.Name), Resources.RemoveAzureVMShouldProcessAction))
            {
                ServiceManagementProfile.Initialize();

                base.ExecuteCommand();
                if (CurrentDeploymentNewSM == null)
                {
                    return;
                }

                DeploymentGetResponse deploymentGetResponse = this.ComputeClient.Deployments.GetBySlot(this.ServiceName, DeploymentSlot.Production);
                if (deploymentGetResponse.Roles.FirstOrDefault(r => r.RoleName.Equals(Name, StringComparison.InvariantCultureIgnoreCase)) == null)
                {
                    throw new ArgumentOutOfRangeException(String.Format(Resources.RoleInstanceCanNotBeFoundWithName, Name));
                }

                if (deploymentGetResponse.RoleInstances.Count > 1)
                {
                    ExecuteClientActionNewSM(
                        null,
                        CommandRuntime.ToString(),
                        () => this.ComputeClient.VirtualMachines.Delete(this.ServiceName, CurrentDeploymentNewSM.Name, Name, DeleteVHD.IsPresent));
                }
                else
                {
                    if (deploymentGetResponse != null && !string.IsNullOrEmpty(deploymentGetResponse.ReservedIPName))
                    {
                        WriteVerboseWithTimestamp(string.Format(Resources.ReservedIPNameNoLongerInUseByDeletingLastVMButStillBeingReserved, deploymentGetResponse.ReservedIPName));
                    }

                    ExecuteClientActionNewSM<AzureOperationResponse>(
                        null,
                        CommandRuntime.ToString(),
                        () => this.ComputeClient.Deployments.DeleteByName(this.ServiceName, CurrentDeploymentNewSM.Name, DeleteVHD.IsPresent));
                }
            }
        }
    }
}