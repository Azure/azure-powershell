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
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Restart", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM", DefaultParameterSetName = RestartResourceGroupNameParameterSet, SupportsShouldProcess = true)]
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
        [ResourceGroupCompleter]
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
        [ResourceIdCompleter("Microsoft.Compute/virtualMachines")]
        public string Id { get; set; }


        [Parameter(
           Mandatory = true,
           Position = 1,
           ParameterSetName = RestartResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [Parameter(
           Mandatory = true,
           Position = 1,
           ParameterSetName = PerformMaintenanceResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
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

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(Name, VerbsLifecycle.Restart))
            {
                base.ExecuteCmdlet();

                if (!string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(Name))
                {
                    ResourceIdentifier parsedId = new ResourceIdentifier(Id);
                    this.Name = parsedId.ResourceName;
                }

                if (this.ParameterSetName.Equals(RestartIdParameterSet) || this.ParameterSetName.Equals(PerformMaintenanceIdParameterSet))
                {
                    this.ResourceGroupName = GetResourceGroupNameFromId(this.Id);
                }

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
                        result.StartTime = this.StartTime;
                        result.EndTime = DateTime.Now;
                        WriteObject(result);
                    });
                }
            }
        }
    }
}
