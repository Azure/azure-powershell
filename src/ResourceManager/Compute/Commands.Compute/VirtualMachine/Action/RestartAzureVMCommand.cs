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

using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsLifecycle.Restart, ProfileNouns.VirtualMachine, DefaultParameterSetName = RestartResourceGroupNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSComputeLongRunningOperation))]
    public class RestartAzureVMCommand : VirtualMachineBaseCmdlet
    {
        protected const string RestartResourceGroupNameParameterSet = "RestartResourceGroupNameParameterSetName";
        protected const string PerformMaintenanceResourceGroupNameParameterSet = "PerformMaintenanceResourceGroupNameParameterSetName";
        protected const string RestartIdParameterSet = "RestartIdParameterSetName";
        protected const string PerformMaintenanceIdParameterSet = "PerformMaintenanceIdParameterSetName";


        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = RestartResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = PerformMaintenanceResourceGroupNameParameterSet,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = RestartIdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = PerformMaintenanceIdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }


        [Parameter(
           Mandatory = true,
           Position = 1,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = PerformMaintenanceResourceGroupNameParameterSet,
            HelpMessage = "To perform the maintenance of virtual machine.")]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = PerformMaintenanceIdParameterSet,
            HelpMessage = "To perform the maintenance of virtual machine.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter PerformMaintenance { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(Name, VerbsLifecycle.Restart))
            {
                base.ExecuteCmdlet();

                if (this.PerformMaintenance.IsPresent)
                {
                    ExecuteClientAction(() =>
                    {
                        var op = this.VirtualMachineClient.PerformMaintenanceWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                        WriteObject(result);
                    });
                }
                else
                {
                    ExecuteClientAction(() =>
                    {
                        var op = this.VirtualMachineClient.RestartWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                        WriteObject(result);
                    });
                }
            }
        }
    }
}
