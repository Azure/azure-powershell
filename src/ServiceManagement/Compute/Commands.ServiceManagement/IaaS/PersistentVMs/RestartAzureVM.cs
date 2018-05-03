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
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsLifecycle.Restart, ProfileNouns.VirtualMachine, DefaultParameterSetName = "RestartByName"), OutputType(typeof(ManagementOperationContext))]
    public class RestartAzureVMCommand : IaaSDeploymentManagementCmdletBase
    {
        private const string RestartInputParameterSet = "RestartInput";
        private const string RestartByNameParameterSet = "RestartByName";
        private const string RedployInputParameterSet = "RedeployInput";
        private const string RedployByNameParameterSet = "RedeployByName";
        private const string InitiateMaintenanceInputParameterSet = "InitiateMaintenanceInput";
        private const string InitiateMaintenanceByNameParameterSet = "InitiateMaintenanceByName";

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
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Virual Machine to initiate maintenance.",
            ParameterSetName = InitiateMaintenanceByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Virtual Machine to restart.",
            ParameterSetName = RestartInputParameterSet)]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Virtual Machine to redeploy.",
            ParameterSetName = RedployInputParameterSet)]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Virtual Machine to initiate maintenance.",
            ParameterSetName = InitiateMaintenanceInputParameterSet)]
        [ValidateNotNullOrEmpty]
        [ObsoleteAttribute("This parameter will be removed in the upcoming release. Use VM name instead.")]
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

        [Parameter(Mandatory = true,
            HelpMessage = "Initiate maintenance on the Virtual Machine",
            ParameterSetName = InitiateMaintenanceInputParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Initiate Maintenance on the Virtual Machine",
            ParameterSetName = InitiateMaintenanceByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter InitiateMaintenance
        {
            get;
            set;
        }

        protected override void ExecuteCommand()
        {
            WriteWarning("Breaking change notice: In upcoming release, VM parameter will be removed.");

            ServiceManagementProfile.Initialize();
            base.ExecuteCommand();
            if (CurrentDeploymentNewSM == null)
            {
                return;
            }

#pragma warning disable 0618
            string roleName = (this.ParameterSetName.Contains("ByName")) ? this.Name : this.VM.RoleName;
#pragma warning restore 0618

            if (this.Redeploy.IsPresent)
            { // Redeploy VM
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.VirtualMachines.Redeploy(this.ServiceName, CurrentDeploymentNewSM.Name, roleName),
                (s, response) => ContextFactory(response, s,
                                    ServiceManagementProfile.Mapper.Map<OperationStatusResponse, ManagementOperationContext>,
                                    ServiceManagementProfile.Mapper.Map));
            }
            else if (this.InitiateMaintenance.IsPresent)
            { // Initiate Maintenance on VM
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.VirtualMachines.InitiateMaintenance(this.ServiceName, CurrentDeploymentNewSM.Name, roleName),
                (s, response) => ContextFactory(response, s,
                                    ServiceManagementProfile.Mapper.Map<OperationStatusResponse, ManagementOperationContext>,
                                    ServiceManagementProfile.Mapper.Map));
            }
            else
            { // Restart VM
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.VirtualMachines.Restart(this.ServiceName, CurrentDeploymentNewSM.Name, roleName),
                (s, response) => ContextFactory(response, s,
                                    ServiceManagementProfile.Mapper.Map<OperationStatusResponse, ManagementOperationContext>,
                                    ServiceManagementProfile.Mapper.Map));
            }
        }
    }
}
