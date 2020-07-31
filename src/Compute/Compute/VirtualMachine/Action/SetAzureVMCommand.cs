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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM", DefaultParameterSetName = GeneralizeResourceGroupNameParameterSet)]
    [OutputType(typeof(PSComputeLongRunningOperation), typeof(PSAzureOperationResponse))]
    public class SetAzureVMCommand : VirtualMachineBaseCmdlet
    {
        protected const string GeneralizeResourceGroupNameParameterSet = "GeneralizeResourceGroupNameParameterSetName";
        protected const string RedeployResourceGroupNameParameterSet = "RedeployResourceGroupNameParameterSetName";
        protected const string ReapplyResourceGroupNameParameterSet = "ReapplyResourceGroupNameParameterSetName";
        protected const string SimulateEvictionResourceGroupNameParameterSet = "SimulateEvictionResourceGroupNameParameterSetName";
        protected const string GeneralizeIdParameterSet = "GeneralizeIdParameterSetName";
        protected const string RedeployIdParameterSet = "RedeployIdParameterSetName";
        protected const string ReapplyIdParameterSet = "ReapplyIdParameterSetName";
        protected const string SimulateEvictionIdParameterSet = "SimulateEvictionIdParameterSetName";

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = GeneralizeResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
         HelpMessage = "The resource group name.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = RedeployResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
          HelpMessage = "The resource group name.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ReapplyResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
          HelpMessage = "The resource group name.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = SimulateEvictionResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
          HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = GeneralizeIdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource ID.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = RedeployIdParameterSet,
           ValueFromPipelineByPropertyName = true,
          HelpMessage = "The resource ID.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ReapplyIdParameterSet,
           ValueFromPipelineByPropertyName = true,
          HelpMessage = "The resource ID.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = SimulateEvictionIdParameterSet,
           ValueFromPipelineByPropertyName = true,
          HelpMessage = "The resource ID.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Compute/virtualMachines")]
        public string Id { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 1,
           ParameterSetName = GeneralizeResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [Parameter(
           Mandatory = true,
           Position = 1,
           ParameterSetName = RedeployResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [Parameter(
           Mandatory = true,
           Position = 1,
           ParameterSetName = ReapplyResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [Parameter(
           Mandatory = true,
           Position = 1,
           ParameterSetName = SimulateEvictionResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GeneralizeResourceGroupNameParameterSet,
            HelpMessage = "To generalize virtual machine.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = GeneralizeIdParameterSet,
            HelpMessage = "To generalize virtual machine.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Generalized { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = RedeployResourceGroupNameParameterSet,
            HelpMessage = "To redeploy virtual machine.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = RedeployIdParameterSet,
            HelpMessage = "To redeploy virtual machine.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Redeploy { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ReapplyResourceGroupNameParameterSet,
            HelpMessage = "To reapply virtual machine.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ReapplyIdParameterSet,
            HelpMessage = "To reapply virtual machine.")]
        public SwitchParameter Reapply { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = SimulateEvictionResourceGroupNameParameterSet,
            HelpMessage = "To simulate eviction of virtual machine.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = SimulateEvictionIdParameterSet,
            HelpMessage = "To simulate eviction of virtual machine.")]
        public SwitchParameter SimulateEviction { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            ParameterSetName = RedeployIdParameterSet,
            Mandatory = false,
            HelpMessage = "Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.")]
        [Parameter(
            ParameterSetName = RedeployResourceGroupNameParameterSet,
            Mandatory = false,
            HelpMessage = "Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.")]
        [Parameter(
            ParameterSetName = ReapplyIdParameterSet,
            Mandatory = false,
            HelpMessage = "Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.")]
        [Parameter(
            ParameterSetName = ReapplyResourceGroupNameParameterSet,
            Mandatory = false,
            HelpMessage = "Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.")]
        public SwitchParameter NoWait { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(Name))
            {
                ResourceIdentifier parsedId = new ResourceIdentifier(Id);
                this.Name = parsedId.ResourceName;
            }

            if (this.ParameterSetName.Equals(GeneralizeIdParameterSet) || this.ParameterSetName.Equals(RedeployIdParameterSet) || this.ParameterSetName.Equals(ReapplyIdParameterSet))
            {
                this.ResourceGroupName = GetResourceGroupNameFromId(this.Id);
            }

            if (this.Generalized.IsPresent)
            {
                ExecuteClientAction(() =>
                {
                    var op = this.VirtualMachineClient.GeneralizeWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.Name).GetAwaiter().GetResult();
                    var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                    result.StartTime = this.StartTime;
                    result.EndTime = DateTime.Now;
                    WriteObject(result);
                });
            }
            else if (this.SimulateEviction.IsPresent)
            {
                ExecuteClientAction(() =>
                {
                    var op = this.VirtualMachineClient.SimulateEvictionWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.Name).GetAwaiter().GetResult();
                    var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                    result.StartTime = this.StartTime;
                    result.EndTime = DateTime.Now;
                    WriteObject(result);
                });
            }
            else if (this.Redeploy.IsPresent)
            {
                ExecuteClientAction(() =>
                {
                    if (NoWait.IsPresent)
                    {
                        var op = this.VirtualMachineClient.BeginRedeployWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                        WriteObject(result);
                    }
                    else
                    {
                        var op = this.VirtualMachineClient.RedeployWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                        result.StartTime = this.StartTime;
                        result.EndTime = DateTime.Now;
                        WriteObject(result);
                    }
                });
            }
            else if (this.Reapply.IsPresent)
            {
                ExecuteClientAction(() =>
                {
                    if (NoWait.IsPresent)
                    {
                        var op = this.VirtualMachineClient.BeginReapplyWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                        WriteObject(result);
                    }
                    else
                    {
                        var op = this.VirtualMachineClient.ReapplyWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                        result.StartTime = this.StartTime;
                        result.EndTime = DateTime.Now;
                        WriteObject(result);
                    }
                });
            }
        }
    }
}
