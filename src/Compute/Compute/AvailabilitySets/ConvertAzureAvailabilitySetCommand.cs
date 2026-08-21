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

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Convert", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AvailabilitySet", SupportsShouldProcess = true)]
    [OutputType(typeof(PSComputeLongRunningOperation), typeof(PSAzureOperationResponse))]
    public class ConvertAzureAvailabilitySetCommand : AvailabilitySetBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("AvailabilitySetName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The availability set name.")]
        [ResourceNameCompleter("Microsoft.Compute/availabilitySets", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Virtual Machine Scale Set to create.")]
        [ValidateNotNullOrEmpty]
        public string VirtualMachineScaleSetName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.")]
        public SwitchParameter NoWait { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.ShouldProcess(Name, "Convert Availability Set to Virtual Machine Scale Set"))
            {
                ExecuteClientAction(() =>
                {
                    if (NoWait.IsPresent)
                    {
                        var op = this.AvailabilitySetClient.BeginConvertToVirtualMachineScaleSetWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name,
                            this.VirtualMachineScaleSetName).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                        WriteObject(result);
                    }
                    else
                    {
                        var op = this.AvailabilitySetClient.ConvertToVirtualMachineScaleSetWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name,
                            this.VirtualMachineScaleSetName).GetAwaiter().GetResult();
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
