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
    [OutputType(typeof(PSComputeLongRunningOperation))]
    public class SetAzureVMCommand : VirtualMachineBaseCmdlet
    {
        protected const string GeneralizeResourceGroupNameParameterSet = "GeneralizeResourceGroupNameParameterSetName";
        protected const string RedeployResourceGroupNameParameterSet = "RedeployResourceGroupNameParameterSetName";
        protected const string GeneralizeIdParameterSet = "GeneralizeIdParameterSetName";
        protected const string RedeployIdParameterSet = "RedeployIdParameterSetName";

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
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = GeneralizeIdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = RedeployIdParameterSet,
           ValueFromPipelineByPropertyName = true,
          HelpMessage = "The resource group name.")]
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

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(Name))
            {
                ResourceIdentifier parsedId = new ResourceIdentifier(Id);
                this.Name = parsedId.ResourceName;
            }

            if (this.ParameterSetName.Equals(GeneralizeIdParameterSet) || this.ParameterSetName.Equals(RedeployIdParameterSet))
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
            else if (this.Redeploy.IsPresent)
            {
                ExecuteClientAction(() =>
                {
                    var op = this.VirtualMachineClient.RedeployWithHttpMessagesAsync(
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
