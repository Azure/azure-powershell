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


using System.Management.Automation;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsLifecycle.Restart, ProfileNouns.VirtualMachine, DefaultParameterSetName = "ByName"), OutputType(typeof(ManagementOperationContext))]
    public class RestartAzureVMCommand : IaaSDeploymentManagementCmdletBase
    {
        private const string RestartInputParameterSet = "RestartInput";
        private const string RestartByNameParameterSet = "RestartByName";
        private const string RedployInputParameterSet = "RedeployInput";
        private const string RedployByNameParameterSet = "RedeployByName";

        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Virtual Machine to restart.",
            ParameterSetName = RestartByNameParameterSet)]
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Virtual Machine to redeploy.",
            ParameterSetName = RedployByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Virtual Machine to restart.",
            ParameterSetName = RestartInputParameterSet)]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Virtual Machine to redeploy.",
            ParameterSetName = RedployInputParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("InputObject")]
        public PersistentVM VM
        {
            get;
            set;
        }

        [Parameter(Mandatory = true,
            HelpMessage = "Redeploy the Virtual Machine",
            ParameterSetName = RedployInputParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Redeploy the Virtual Machine",
            ParameterSetName = RedployByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Redeploy
        {
            get;
            set;
        }

        protected override void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();
            base.ExecuteCommand();
            if (CurrentDeploymentNewSM == null)
            {
                return;
            }

            string roleName = (this.ParameterSetName.Contains("ByName")) ? this.Name : this.VM.RoleName;

            if (this.Redeploy.IsPresent)
            { // Redeploy VM
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.VirtualMachines.Redeploy(this.ServiceName, CurrentDeploymentNewSM.Name, roleName),
                (s, response) => ContextFactory<OperationStatusResponse, ManagementOperationContext>(response, s));
            }
            else
            { // Restart VM
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.VirtualMachines.Restart(this.ServiceName, CurrentDeploymentNewSM.Name, roleName),
                (s, response) => ContextFactory<OperationStatusResponse, ManagementOperationContext>(response, s));
            }
        }
    }
}
