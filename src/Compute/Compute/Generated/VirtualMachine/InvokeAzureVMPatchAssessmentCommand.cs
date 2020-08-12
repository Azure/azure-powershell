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


using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Compute;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsLifecycle.Invoke, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMPatchAssessment", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet )]
    [OutputType(typeof(PSVirtualMachinePatchAssessmentResult))]
    [Alias("Invoke-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMPatchAssess", "Invoke-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMAssessPatch")]

    public partial class InvokeAzureVMPatchAssessmentCommand : ComputeAutomationBaseCmdlet
    {
        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";
        private const string ResourceIDParameterSet = "ResourceIDParameterSet";

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = DefaultParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine name")]
        [ResourceNameCompleter("Microsoft.Compute/VirtualMachines", "ResourceGroupName")]
        public string VMName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ResourceIDParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource ID for your virtual machine.")]
        [ResourceIdCompleter("Microsoft.Compute/virtualMachines")]
        public string ResourceId { get; set; }

        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true, 
            Position = 0,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PowerShell Virtual Machine Object")]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.VMName, VerbsLifecycle.Invoke))
                {
                    string resourceGroupName;
                    string vmName;
                    switch (this.ParameterSetName)
                    {
                        case ResourceIDParameterSet:
                            resourceGroupName = GetResourceGroupName(this.ResourceId);
                            vmName = GetResourceName(this.ResourceId, "Microsoft.Compute/virtualmachines");
                            break;
                        case InputObjectParameterSet:
                            resourceGroupName = GetResourceGroupName(this.VM.Id);
                            vmName = GetResourceName(this.VM.Id, "Microsoft.Compute/virtualmachines");
                            break;
                        default:
                            resourceGroupName = this.ResourceGroupName;
                            vmName = this.VMName;
                            break;
                    }


                    var result = VirtualMachinesClient.AssessPatches(resourceGroupName, vmName);
                    var psObject = new PSVirtualMachinePatchAssessmentResult();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<VirtualMachineAssessPatchesResult, PSVirtualMachinePatchAssessmentResult>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }
    }
}
