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
    [Cmdlet(VerbsLifecycle.Invoke, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMInstallPatch", SupportsShouldProcess = true, DefaultParameterSetName = WindowsDefaultParameterSet)]
    [OutputType(typeof(PSVirtualMachineInstallPatchesResult))]
    public partial class InvokeAzureVMInstallPatch : ComputeAutomationBaseCmdlet
    {
        private const string WindowsDefaultParameterSet = "WindowsDefaultParameterSet";
        private const string WindowsInputObjectParameterSet = "WindowsInputObjectParameterSet";
        private const string WindowsResourceIDParameterSet = "WindowsResourceIDParameterSet";
        
        private const string LinuxDefaultParameterSet = "LinuxDefaultParameterSet";
        private const string LinuxInputObjectParameterSet = "LinuxInputObjectParameterSet";
        private const string LinuxResourceIDParameterSet = "LinuxResourceIDParameterSet";

        [Parameter(
           Mandatory = true,
           ParameterSetName = WindowsDefaultParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [Parameter(
           Mandatory = true,
           ParameterSetName = LinuxDefaultParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = WindowsDefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = LinuxDefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine name")]
        [Alias("Name")]
        [ResourceNameCompleter("Microsoft.Compute/VirtualMachines", "ResourceGroupName")]
        public string VMName { get; set; }

        [Parameter(
           Mandatory = true,
           ParameterSetName = WindowsResourceIDParameterSet,
           ValueFromPipeline = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource ID for your virtual machine.")]
        [Parameter(
           Mandatory = true,
           ParameterSetName = LinuxResourceIDParameterSet,
           ValueFromPipeline = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource ID for your virtual machine.")]
        [ResourceIdCompleter("Microsoft.Compute/virtualMachines")]
        public string ResourceId { get; set; }

        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = WindowsInputObjectParameterSet,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PowerShell Virtual Machine Object")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = LinuxInputObjectParameterSet,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PowerShell Virtual Machine Object")]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = WindowsDefaultParameterSet)]
        [Parameter(
            Mandatory = true,
            ParameterSetName = WindowsInputObjectParameterSet)]
        [Parameter(
            Mandatory = true,
            ParameterSetName = WindowsResourceIDParameterSet)]
        public SwitchParameter Windows { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = LinuxDefaultParameterSet)]
        [Parameter(
            Mandatory = true,
            ParameterSetName = LinuxInputObjectParameterSet)]
        [Parameter(
            Mandatory = true,
            ParameterSetName = LinuxResourceIDParameterSet)]
        public SwitchParameter Linux { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Defines when it is acceptable to reboot a VM during a software update operation.")]
        [PSArgumentCompleter("IfRequired", "Never", "Always")]
        public string RebootSetting { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the maximum amount of time that the operation will run. It must be an ISO 8601-compliant duration string such as PT2H (2 hours).")]
        public string MaximumDuration { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsDefaultParameterSet,
            HelpMessage = "KBs to include in the patch operation. This parameter is only available for Windows VM.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsInputObjectParameterSet,
            HelpMessage = "KBs to include in the patch operation. This parameter is only available for Windows VM.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsResourceIDParameterSet,
            HelpMessage = "KBs to include in the patch operation. This parameter is only available for Windows VM.")]
        public string[] KBNumberToInclude { get; set; }
        
        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsDefaultParameterSet,
            HelpMessage = "KBs to exclude in the patch operation. This parameter is only available for Windows VM.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsInputObjectParameterSet,
            HelpMessage = "KBs to exclude in the patch operation. This parameter is only available for Windows VM.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsResourceIDParameterSet,
            HelpMessage = "KBs to exclude in the patch operation. This parameter is only available for Windows VM.")]
        public string[] KBNumberToExclude { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsDefaultParameterSet,
            HelpMessage = "Filters out KBs that don't have a reboot behavior of 'NeverReboots' when this is set. This parameter is only available for Windows VM.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsInputObjectParameterSet,
            HelpMessage = "Filters out KBs that don't have a reboot behavior of 'NeverReboots' when this is set. This parameter is only available for Windows VM.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsResourceIDParameterSet,
            HelpMessage = "Filters out KBs that don't have a reboot behavior of 'NeverReboots' when this is set. This parameter is only available for Windows VM.")]
        public SwitchParameter ExcludeKBsRequiringReboot { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = LinuxDefaultParameterSet,
            HelpMessage = "Packages to include in the patch operation. Format: packageName_packageVersion. This parameter is only available for Linux VM.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = LinuxInputObjectParameterSet,
            HelpMessage = "Packages to include in the patch operation. Format: packageName_packageVersion. This parameter is only available for Linux VM.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = LinuxResourceIDParameterSet,
            HelpMessage = "Packages to include in the patch operation. Format: packageName_packageVersion. This parameter is only available for Linux VM.")]
        public string[] PackageNameMaskToInclude { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = LinuxDefaultParameterSet,
            HelpMessage = "Packages to exclude in the patch operation. Format: packageName_packageVersion. This parameter is only available for Linux VM.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = LinuxInputObjectParameterSet,
            HelpMessage = "Packages to exclude in the patch operation. Format: packageName_packageVersion. This parameter is only available for Linux VM.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = LinuxResourceIDParameterSet,
            HelpMessage = "Packages to exclude in the patch operation. Format: packageName_packageVersion. This parameter is only available for Linux VM.")]
        public string[] PackageNameMaskToExclude { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsDefaultParameterSet,
            HelpMessage = "The update classifications to select when installing patches. Possible values differ for Windows and Linux.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsInputObjectParameterSet,
            HelpMessage = "The update classifications to select when installing patches. Possible values differ for Windows and Linux.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = WindowsResourceIDParameterSet,
            HelpMessage = "The update classifications to select when installing patches. Possible values differ for Windows and Linux.")]
        [PSArgumentCompleter("Critical", "Security", "UpdateRollUp", "FeaturePack", "ServicePack", "Definition", "Tools", "Updates")]
        public string[] ClassificationToIncludeForWindows { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = LinuxDefaultParameterSet,
            HelpMessage = "The update classifications to select when installing patches. Possible values differ for Windows and Linux.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = LinuxInputObjectParameterSet,
            HelpMessage = "The update classifications to select when installing patches. Possible values differ for Windows and Linux.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = LinuxResourceIDParameterSet,
            HelpMessage = "The update classifications to select when installing patches. Possible values differ for Windows and Linux.")]
        [PSArgumentCompleter("Critical", "Security", "Other")]
        public string[] ClassificationToIncludeForLinux { get; set; }


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
                    
                    // map ResourceGroupName and vmName
                    if (this.ParameterSetName == WindowsResourceIDParameterSet || this.ParameterSetName == LinuxResourceIDParameterSet)
                    {
                        resourceGroupName = GetResourceGroupName(this.ResourceId);
                        vmName = GetResourceName(this.ResourceId, "Microsoft.Compute/virtualmachines");

                        if (resourceGroupName == null || vmName == null)
                        {
                            WriteError(new ErrorRecord(new Exception("Virtual Machine with provided Resource ID: '" + this.ResourceId + "' was not found."), "Error", ErrorCategory.NotSpecified, null));
                        }
                    }
                    else if(this.ParameterSetName == WindowsInputObjectParameterSet || this.ParameterSetName == LinuxInputObjectParameterSet)
                    {
                        resourceGroupName = GetResourceGroupName(this.VM.Id);
                        vmName = GetResourceName(this.VM.Id, "Microsoft.Compute/virtualmachines");
                        if (resourceGroupName == null || vmName == null)
                        {
                            WriteError(new ErrorRecord(new Exception("Invalid PSVirtualMachine object was provided for '-VM' parameter."), "Error", ErrorCategory.NotSpecified, null));
                        }
                    }
                    else
                    {
                        resourceGroupName = this.ResourceGroupName;
                        vmName = this.VMName;
                    }

                    VirtualMachineInstallPatchesParameters vmInstallPatchesParameters = new VirtualMachineInstallPatchesParameters();
                    vmInstallPatchesParameters.MaximumDuration = this.MaximumDuration;
                    vmInstallPatchesParameters.RebootSetting = this.RebootSetting;

                    // divde linux and windows 
                    if (this.Windows.IsPresent)
                    {
                        vmInstallPatchesParameters.WindowsParameters = new WindowsParameters();
                        if (this.IsParameterBound(c => c.ClassificationToIncludeForWindows))
                        {
                            vmInstallPatchesParameters.WindowsParameters.ClassificationsToInclude = this.ClassificationToIncludeForWindows;
                        }

                        if (this.IsParameterBound(c => c.KBNumberToInclude))
                        {
                            vmInstallPatchesParameters.WindowsParameters.KbNumbersToInclude = this.KBNumberToInclude;
                        }

                        if (this.IsParameterBound(c => c.KBNumberToExclude))
                        {
                            vmInstallPatchesParameters.WindowsParameters.KbNumbersToExclude = this.KBNumberToExclude;
                        }

                        if (this.ExcludeKBsRequiringReboot.IsPresent)
                        {
                            vmInstallPatchesParameters.WindowsParameters.ExcludeKbsRequiringReboot = true;
                        }
                    }
                    else if (this.Linux.IsPresent)
                    {
                        vmInstallPatchesParameters.LinuxParameters = new LinuxParameters();
                        if (this.IsParameterBound(c => c.ClassificationToIncludeForLinux))
                        {
                            vmInstallPatchesParameters.LinuxParameters.ClassificationsToInclude = this.ClassificationToIncludeForLinux;
                        }

                        if (this.IsParameterBound(c => c.PackageNameMaskToInclude))
                        {
                            vmInstallPatchesParameters.LinuxParameters.PackageNameMasksToInclude = this.PackageNameMaskToInclude;
                        }

                        if (this.IsParameterBound(c => c.PackageNameMaskToExclude))
                        {
                            vmInstallPatchesParameters.LinuxParameters.PackageNameMasksToExclude = this.PackageNameMaskToExclude;
                        }
                    }

                    var result = VirtualMachinesClient.InstallPatchesAsync(resourceGroupName, vmName, vmInstallPatchesParameters).GetAwaiter().GetResult();
                    var psObject = new PSVirtualMachineInstallPatchesResult();
                    
                    // return 
                    ComputeAutomationAutoMapperProfile.Mapper.Map<VirtualMachineInstallPatchesResult, PSVirtualMachineInstallPatchesResult>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }
    }
}
