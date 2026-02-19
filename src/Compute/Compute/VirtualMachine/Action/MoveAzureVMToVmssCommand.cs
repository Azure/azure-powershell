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
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Move", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualMachineToVmss", DefaultParameterSetName = ResourceGroupNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSComputeLongRunningOperation), typeof(PSAzureOperationResponse))]
    public class MoveAzureVMToVmssCommand : VirtualMachineBaseCmdlet
    {
        protected const string ResourceGroupNameParameterSet = "ResourceGroupNameParameterSetName";
        protected const string IdParameterSet = "IdParameterSetName";

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = IdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The ID of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Compute/virtualMachines")]
        public string Id { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = ResourceGroupNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target zone for the virtual machine migration to Flexible Virtual Machine Scale Set.")]
        [ValidateNotNullOrEmpty]
        public string TargetZone { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target compute fault domain for the virtual machine migration to Flexible Virtual Machine Scale Set.")]
        [ValidateNotNullOrEmpty]
        public int? TargetFaultDomain { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target Virtual Machine size for the migration to Flexible Virtual Machine Scale Set.")]
        [ValidateNotNullOrEmpty]
        public string TargetVMSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.")]
        public SwitchParameter NoWait { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ParameterSetName.Equals(IdParameterSet) && !string.IsNullOrEmpty(Id))
            {
                ResourceIdentifier parsedId = new ResourceIdentifier(Id);
                this.ResourceGroupName = parsedId.ResourceGroupName;
                this.Name = parsedId.ResourceName;
            }

            if (this.ShouldProcess(Name, "Migrate Virtual Machine to Virtual Machine Scale Set"))
            {
                ExecuteClientAction(() =>
                {
                    MigrateVMToVirtualMachineScaleSetInput parameters = null;

                    if (!string.IsNullOrEmpty(TargetZone) || TargetFaultDomain.HasValue || !string.IsNullOrEmpty(TargetVMSize))
                    {
                        parameters = new MigrateVMToVirtualMachineScaleSetInput
                        {
                            TargetZone = this.TargetZone,
                            TargetFaultDomain = this.TargetFaultDomain,
                            TargetVMSize = this.TargetVMSize
                        };
                    }

                    if (NoWait.IsPresent)
                    {
                        var op = this.VirtualMachineClient.BeginMigrateToVMScaleSetWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name,
                            parameters).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                        WriteObject(result);
                    }
                    else
                    {
                        var op = this.VirtualMachineClient.MigrateToVMScaleSetWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name,
                            parameters).GetAwaiter().GetResult();
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
