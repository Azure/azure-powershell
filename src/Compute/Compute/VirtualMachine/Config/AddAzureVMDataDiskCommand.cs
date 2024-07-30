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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.Compute.Common;
using CM = Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMDataDisk",DefaultParameterSetName = VmNormalDiskParameterSet),OutputType(typeof(CM.PSVirtualMachine), typeof (PSVirtualMachineScaleSetVM))]
    public class AddAzureVMDataDiskCommand : ComputeClientBaseCmdlet
    {
        protected const string VmNormalDiskParameterSet = "VmNormalDiskParameterSetName";
        protected const string VmManagedDiskParameterSet = "VmManagedDiskParameterSetName";

        [Alias("VMProfile")]
        [Parameter(
            ParameterSetName = VmNormalDiskParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [Parameter(
            ParameterSetName = VmManagedDiskParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public CM.PSVirtualMachine VM { get; set; }

        [Parameter(
            ParameterSetName = VmNormalDiskParameterSet,
            Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskName)]
        [Parameter(
            ParameterSetName = VmManagedDiskParameterSet,
            Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ParameterSetName = VmNormalDiskParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskVhdUri)]
        [ValidateNotNullOrEmpty]
        public string VhdUri { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskCaching)]
        public CachingTypes Caching { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskSizeInGB)]
        [AllowNull]
        public int? DiskSizeInGB { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskLun)]
        [ValidateNotNullOrEmpty]
        public int? Lun { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskCreateOption)]
        [PSArgumentCompleter("Attach", "Empty", "FromImage", "Copy", "Restore")]
        public string CreateOption { get; set; }

        [Alias("SourceImage")]
        [Parameter(
            Position = 7,
            ParameterSetName = VmNormalDiskParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMSourceImageUri)]
        [ValidateNotNullOrEmpty]
        public string SourceImageUri { get; set; }

        [Parameter(
            Position = 8,
            ParameterSetName = VmManagedDiskParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMManagedDiskId)]
        [ValidateNotNullOrEmpty]
        public string ManagedDiskId { get; set; }

        [Parameter(
            Position = 9,
            ParameterSetName = VmManagedDiskParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMManagedDiskAccountType)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Standard_LRS", "Premium_LRS", "StandardSSD_LRS", "UltraSSD_LRS")]
        public string StorageAccountType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.VMDiskEncryptionSetId)]
        [ValidateNotNullOrEmpty]
        public string DiskEncryptionSetId { get; set; }

        [Parameter(
            ParameterSetName = VmManagedDiskParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = false)]
        public SwitchParameter WriteAccelerator { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Detach", "Delete")]
        public string DeleteOption { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ARM ID of snapshot or disk restore point from which to create a disk.")]
        [ValidateNotNullOrEmpty]
        public string SourceResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(VmNormalDiskParameterSet))
            {
                var storageProfile = this.VM.StorageProfile;

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
                    Name = this.Name,
                    Caching = this.Caching,
                    DiskSizeGB = this.DiskSizeInGB,
                    Lun = this.Lun.GetValueOrDefault(),
                    Vhd = string.IsNullOrEmpty(this.VhdUri) ? null : new VirtualHardDisk
                    {
                        Uri = this.VhdUri
                    },
                    CreateOption = this.CreateOption,
                    Image = string.IsNullOrEmpty(this.SourceImageUri) ? null : new VirtualHardDisk
                    {
                        Uri = this.SourceImageUri
                    },
                    DeleteOption = this.DeleteOption,
                    SourceResource = string.IsNullOrEmpty(this.SourceResourceId) ? null : new ApiEntityReference 
                    { 
                        Id = this.SourceResourceId 
                    }
                });

                this.VM.StorageProfile = storageProfile;

                WriteObject(this.VM);
            }
            else
            {
                if (!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.ManagedDiskId))
                {
                    if (!this.Name.Equals(GetDiskNameFromId(this.ManagedDiskId)))
                    {
                        ThrowInvalidArgumentError("Disk name, {0}, does not match with given managed disk ID", this.Name);
                    }
                }

                var storageProfile = this.VM.StorageProfile;

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
                    Name = this.Name,
                    Caching = this.Caching,
                    DiskSizeGB = this.DiskSizeInGB,
                    Lun = this.Lun.GetValueOrDefault(),
                    CreateOption = this.CreateOption,
                    ManagedDisk = SetManagedDisk(this.ManagedDiskId, this.DiskEncryptionSetId, this.StorageAccountType),
                    WriteAcceleratorEnabled = this.WriteAccelerator.IsPresent,
                    DeleteOption = this.DeleteOption,
                    SourceResource = string.IsNullOrEmpty(this.SourceResourceId) ? null : new ApiEntityReference
                    {
                        Id = this.SourceResourceId
                    }
                });

                this.VM.StorageProfile = storageProfile;

                WriteObject(this.VM);
            }
        }
    }
}