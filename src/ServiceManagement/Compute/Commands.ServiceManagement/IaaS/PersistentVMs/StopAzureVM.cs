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

using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsLifecycle.Stop, ProfileNouns.VirtualMachine, DefaultParameterSetName = "ByName"), OutputType(typeof(ManagementOperationContext))]
    public class StopAzureVMCommand : IaaSDeploymentManagementCmdletBase
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Virtual Machine to stop.", ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string[] Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Virtual Machine to restart.", ParameterSetName = "Input")]
        [ValidateNotNullOrEmpty]
        [Alias("InputObject")]
        public Model.IPersistentVM[] VM { get; set; }

        [Parameter(Position = 2, HelpMessage = "Keeps the VM provisioned")]
        public SwitchParameter StayProvisioned { get; set; }

        [Parameter(Position = 3, HelpMessage = "Allows the deallocation of last VM in a deployment")]
        public SwitchParameter Force { get; set; }

        protected override void ExecuteCommand()
        {
            base.ExecuteCommand();
            ServiceManagementProfile.Initialize();

            if (this.CurrentDeploymentNewSM == null)
            {
                return;
            }

            string[] inputRoleNames = (this.ParameterSetName == "ByName") ? this.Name : this.VM.Select(vm => vm.GetInstance().RoleName).ToArray();

            // Generate a list of role names matching regular expressions or
            // the exact name specified in the -Name parameter.
            var roleNames = PersistentVMHelper.GetRoleNames(this.CurrentDeploymentNewSM.RoleInstances, inputRoleNames);

            // Insure at least one of the role name instances can be found.
            if ((roleNames == null) || (!roleNames.Any()))
            {
                throw new ArgumentOutOfRangeException(String.Format(Resources.RoleInstanceCanNotBeFoundWithName, this.Name));
            }

            // Insure the Force switch is specified for wildcard operations when StayProvisioned is not specified.
            if (roleNames.Any(r => WildcardPattern.ContainsWildcardCharacters(r)) && (!this.StayProvisioned.IsPresent) && (!this.Force.IsPresent))
            {
                throw new ArgumentException(Resources.MustSpecifyForceParameterWhenUsingWildcards);
            }

            if (roleNames.Count == 1)
            {
                if (this.StayProvisioned.IsPresent)
                {
                    ProcessStaticIPAddressWarningInfo(roleNames[0]);

                    this.ExecuteClientActionNewSM(
                        null,
                        this.CommandRuntime.ToString(),
                        () => this.ComputeClient.VirtualMachines.Shutdown(
                            this.ServiceName,
                            this.CurrentDeploymentNewSM.Name,
                            roleNames[0],
                            new VirtualMachineShutdownParameters { PostShutdownAction = PostShutdownAction.Stopped }),
                        (s, response) => this.ContextFactory<OperationStatusResponse, ManagementOperationContext>(response, s));
                }
                else
                {
                    if (!this.Force.IsPresent && this.IsLastVmInDeployment(roleNames.Count))
                    {
                        this.ConfirmAction(false,
                            Resources.DeploymentVIPLossWarning,
                            string.Format(Resources.DeprovisioningVM, string.Join(", ", roleNames)),
                            String.Empty,
                            () => this.ExecuteClientActionNewSM(
                                null,
                                this.CommandRuntime.ToString(),
                                () => this.ComputeClient.VirtualMachines.Shutdown(
                                    this.ServiceName,
                                    this.CurrentDeploymentNewSM.Name,
                                    roleNames[0],
                                    new VirtualMachineShutdownParameters { PostShutdownAction = PostShutdownAction.StoppedDeallocated }),
                                (s, response) => ContextFactory<OperationStatusResponse, ManagementOperationContext>(response, s)));
                    }
                    else
                    {
                        this.ExecuteClientActionNewSM(
                                null,
                                this.CommandRuntime.ToString(),
                                () => this.ComputeClient.VirtualMachines.Shutdown(
                                    this.ServiceName,
                                    this.CurrentDeploymentNewSM.Name,
                                    roleNames[0], 
                                    new VirtualMachineShutdownParameters { PostShutdownAction = PostShutdownAction.StoppedDeallocated }),
                                (s, response) => this.ContextFactory<OperationStatusResponse, ManagementOperationContext>(response, s));
                    }
                }
            }
            else
            {
                if (this.StayProvisioned.IsPresent)
                {
                    var parameter = new VirtualMachineShutdownRolesParameters();
                    foreach (var role in roleNames)
                    {
                        ProcessStaticIPAddressWarningInfo(role);
                        parameter.Roles.Add(role);
                    }
                    parameter.PostShutdownAction = PostShutdownAction.Stopped;

                    this.ExecuteClientActionNewSM(
                        null,
                        this.CommandRuntime.ToString(),
                        () => this.ComputeClient.VirtualMachines.ShutdownRoles(this.ServiceName, this.CurrentDeploymentNewSM.Name, parameter));
                }
                else
                {
                    var parameter = new VirtualMachineShutdownRolesParameters();
                    foreach (var role in roleNames)
                    {
                        parameter.Roles.Add(role);
                    }
                    parameter.PostShutdownAction = PostShutdownAction.StoppedDeallocated;

                    if (!this.Force.IsPresent && this.IsLastVmInDeployment(roleNames.Count))
                    {
                        this.ConfirmAction(false,
                            Resources.DeploymentVIPLossWarning,
                            string.Format(Resources.DeprovisioningVM, string.Join(", ", roleNames)),
                            String.Empty,
                            () => this.ExecuteClientActionNewSM(
                                null,
                                this.CommandRuntime.ToString(),
                                () => this.ComputeClient.VirtualMachines.ShutdownRoles(this.ServiceName, this.CurrentDeploymentNewSM.Name, parameter)));
                    }
                    else
                    {
                        this.ExecuteClientActionNewSM(
                            null,
                            this.CommandRuntime.ToString(),
                            () => this.ComputeClient.VirtualMachines.ShutdownRoles(this.ServiceName, this.CurrentDeploymentNewSM.Name, parameter));
                    }
                }
            }
        }

        private bool IsLastVmInDeployment(int vmCount)
        {
            Func<RoleInstance, bool> roleNotStoppedDeallocated =
                r => String.Compare(
                    r.InstanceStatus,
                    PostShutdownAction.StoppedDeallocated.ToString(),
                    true,
                    CultureInfo.InvariantCulture) != 0;
            bool result = this.CurrentDeploymentNewSM.RoleInstances.Count(roleNotStoppedDeallocated) <= vmCount;

            if (result && !this.StayProvisioned.IsPresent)
            {
                if (this.CurrentDeploymentNewSM != null && !string.IsNullOrEmpty(this.CurrentDeploymentNewSM.ReservedIPName))
                {
                    WriteWarning(string.Format(Resources.ReservedIPNameNoLongerInUseByStoppingLastVMButStillBeingReserved, this.CurrentDeploymentNewSM.ReservedIPName));
                }
            }

            return result;
        }

        private void ProcessStaticIPAddressWarningInfo(string vmRoleName)
        {
            var vmRole = this.CurrentDeploymentNewSM.Roles.FirstOrDefault(r => r.RoleName == vmRoleName);
            if (vmRole.ConfigurationSets != null)
            {
                var configSet = vmRole.ConfigurationSets.FirstOrDefault(c => !string.IsNullOrEmpty(c.StaticVirtualNetworkIPAddress));
                if (configSet != null)
                {
                    WriteWarning(string.Format(
                        Resources.StaticIPAddressNoLongerInUseButStillBeingReserved,
                        vmRoleName,
                        configSet.StaticVirtualNetworkIPAddress));
                }
            }
        }
    }
}
