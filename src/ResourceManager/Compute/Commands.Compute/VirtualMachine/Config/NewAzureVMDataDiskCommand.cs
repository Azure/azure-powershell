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
using Microsoft.Azure.Management.Compute.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.New,
        ProfileNouns.DataDisk,
        DefaultParameterSetName = NormalDiskParameterSet),
    OutputType(
        typeof(PSVirtualMachineDataDisk))]
    public class NewAzureVMDataDiskCommand : ComputeClientBaseCmdlet
    {
        private const string NormalDiskParameterSet = "NormalDiskParameterSetName";
        private const string ManagedDiskParameterSet = "ManagedDiskParameterSetName";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskLun)]
        public int Lun { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskCreateOption)]
        public string CreateOption { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskCaching)]
        public CachingTypes Caching { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskSizeInGB)]
        [AllowNull]
        public int? DiskSizeInGB { get; set; }

        [Parameter(
            ParameterSetName = NormalDiskParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskVhdUri)]
        [ValidateNotNullOrEmpty]
        public string VhdUri { get; set; }

        [Alias("SourceImage")]
        [Parameter(
            ParameterSetName = NormalDiskParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMSourceImageUri)]
        [ValidateNotNullOrEmpty]
        public string SourceImageUri { get; set; }

        [Parameter(
            ParameterSetName = ManagedDiskParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMManagedDiskId)]
        [ValidateNotNullOrEmpty]
        public string ManagedDiskId { get; set; }

        [Parameter(
            ParameterSetName = ManagedDiskParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMManagedDiskAccountType)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Standard_LRS", "Premium_LRS")]
        public string StorageAccountType { get; set; }

        [Parameter(
            ParameterSetName = ManagedDiskParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = false)]
        public SwitchParameter WriteAccelerator { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.ManagedDiskId))
            {
                if (!this.Name.Equals(GetDiskNameFromId(this.ManagedDiskId)))
                {
                    ThrowInvalidArgumentError("Disk name, {0}, does not match with given managed disk ID", this.Name);
                }
            }

            var dataDisk = (this.ParameterSetName.Equals(NormalDiskParameterSet))
                ? new PSVirtualMachineDataDisk
                {
                    Name = this.Name,
                    Caching = this.Caching,
                    DiskSizeGB = this.DiskSizeInGB,
                    Lun = this.Lun,
                    Vhd = string.IsNullOrEmpty(this.VhdUri) ? null : new VirtualHardDisk
                    {
                        Uri = this.VhdUri
                    },
                    CreateOption = this.CreateOption,
                    Image = string.IsNullOrEmpty(this.SourceImageUri) ? null : new VirtualHardDisk
                    {
                        Uri = this.SourceImageUri
                    }
                }
                : new PSVirtualMachineDataDisk
                {
                    Name = this.Name,
                    Caching = this.Caching,
                    DiskSizeGB = this.DiskSizeInGB,
                    Lun = this.Lun,
                    CreateOption = this.CreateOption,
                    ManagedDisk = (this.ManagedDiskId == null && this.StorageAccountType == null)
                              ? null
                              : new ManagedDiskParameters
                              {
                                  Id = this.ManagedDiskId,
                                  StorageAccountType = this.StorageAccountType
                              },
                    WriteAcceleratorEnabled = this.WriteAccelerator.IsPresent
                };

            WriteObject(dataDisk);
        }
    }
}
