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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssLifecycleHook", SupportsShouldProcess = true, DefaultParameterSetName = ByTypeParameterSet)]
    [OutputType(typeof(PSVirtualMachineScaleSet))]
    public class RemoveAzureRmVmssLifecycleHookCommand : ComputeAutomationBaseCmdlet
    {
        private const string ByTypeParameterSet = "ByTypeParameterSet";
        private const string AllParameterSet = "AllParameterSet";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByTypeParameterSet,
            HelpMessage = "The name of the resource group.")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AllParameterSet,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByTypeParameterSet,
            HelpMessage = "The name of the VM scale set.")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AllParameterSet,
            HelpMessage = "The name of the VM scale set.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachineScaleSets", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string VMScaleSetName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByTypeParameterSet,
            HelpMessage = "The lifecycle hook type to remove. Possible values: 'UpgradeAutoOSScheduling', 'UpgradeAutoOSRollingBatchStarting'.")]
        [PSArgumentCompleter("UpgradeAutoOSScheduling", "UpgradeAutoOSRollingBatchStarting")]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AllParameterSet,
            HelpMessage = "When specified, removes all lifecycle hooks from the virtual machine scale set.")]
        public SwitchParameter All { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.VMScaleSetName, "Remove-AzVmssLifecycleHook"))
                {
                    var vmss = VirtualMachineScaleSetsClient.Get(this.ResourceGroupName, this.VMScaleSetName);
                    var psObject = new PSVirtualMachineScaleSet();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<VirtualMachineScaleSet, PSVirtualMachineScaleSet>(vmss, psObject);

                    if (this.ParameterSetName.Equals(AllParameterSet))
                    {
                        psObject.LifecycleHooksProfile = null;
                    }
                    else
                    {
                        // Remove by type
                        if (psObject.LifecycleHooksProfile?.LifecycleHooks != null)
                        {
                            var remaining = psObject.LifecycleHooksProfile.LifecycleHooks
                                .Where(h => !string.Equals(h.Type, this.Type, System.StringComparison.OrdinalIgnoreCase))
                                .ToList();

                            if (remaining.Count == 0)
                            {
                                psObject.LifecycleHooksProfile = null;
                            }
                            else
                            {
                                psObject.LifecycleHooksProfile = new LifecycleHooksProfile { LifecycleHooks = remaining };
                            }
                        }
                    }

                    var parameters = new VirtualMachineScaleSet();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<PSVirtualMachineScaleSet, VirtualMachineScaleSet>(psObject, parameters);

                    var result = VirtualMachineScaleSetsClient.CreateOrUpdate(this.ResourceGroupName, this.VMScaleSetName, parameters);
                    var resultPsObject = new PSVirtualMachineScaleSet();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<VirtualMachineScaleSet, PSVirtualMachineScaleSet>(result, resultPsObject);
                    WriteObject(resultPsObject);
                }
            });
        }
    }
}
