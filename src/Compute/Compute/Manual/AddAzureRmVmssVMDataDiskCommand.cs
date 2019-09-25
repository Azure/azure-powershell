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
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssVMDataDisk")]
    [OutputType(typeof (PSVirtualMachineScaleSetVM))]
    public class AddAzureRmVmssVMDataDiskCommand : ComputeClientBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = HelpMessages.VmssVMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachineScaleSetVM VirtualMachineScaleSetVM { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VmssVMDataDiskLun)]
        [ValidateNotNullOrEmpty]
        public int Lun { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VmssVMDataDiskCreateOption)]
        [PSArgumentCompleter("Attach", "Empty", "FromImage")]
        public string CreateOption { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VmssVMManagedDiskId)]
        [ValidateNotNullOrEmpty]
        public string ManagedDiskId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VmssVMManagedDiskAccountType)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Standard_LRS", "Premium_LRS", "StandardSSD_LRS", "UltraSSD_LRS")]
        public string StorageAccountType { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VmssVMDataDiskCaching)]
        public CachingTypes Caching { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VmssVMDataDiskSizeInGB)]
        public int DiskSizeInGB { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false)]
        public SwitchParameter WriteAccelerator { get; set; }

        public override void ExecuteCmdlet()
        {
            var storageProfile = this.VirtualMachineScaleSetVM.StorageProfile;

            if (storageProfile == null)
            {
                storageProfile = new StorageProfile();
            }

            if (storageProfile.DataDisks == null)
            {
                storageProfile.DataDisks = new List<DataDisk>();
            }

            storageProfile.DataDisks.Add(new DataDisk
            {
                Caching = this.IsParameterBound(c => c.Caching) ? this.Caching : (CachingTypes?)null,
                DiskSizeGB = this.IsParameterBound(c => c.DiskSizeInGB) ? this.DiskSizeInGB: (int?)null,
                Lun = this.Lun,
                CreateOption = this.CreateOption,
                ManagedDisk = SetManagedDisk(this.ManagedDiskId, this.StorageAccountType),
                WriteAcceleratorEnabled = this.WriteAccelerator.IsPresent
            });

            this.VirtualMachineScaleSetVM.StorageProfile = storageProfile;
            WriteObject(this.VirtualMachineScaleSetVM);
        }
    }
}
