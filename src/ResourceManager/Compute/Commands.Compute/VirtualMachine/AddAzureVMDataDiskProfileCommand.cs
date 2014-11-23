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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Add,
        ProfileNouns.DataDisk),
    OutputType(
        typeof(PSVirtualMachineProfile))]
    public class AddAzureVMDataDiskProfileCommand : AzurePSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachineProfile VMProfile { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskVhdUri)]
        [ValidateNotNullOrEmpty]
        public string VhdUri { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskCaching)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(ValidateSetValues.ReadOnly, ValidateSetValues.ReadWrite)]
        public string Caching { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskSizeInGB)]
        [ValidateNotNullOrEmpty]
        public int? DiskSizeInGB { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskLun)]
        [ValidateNotNullOrEmpty]
        public int? Lun { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.VMProfile.StorageProfile == null)
            {
                this.VMProfile.StorageProfile = new StorageProfile();
            }

            if (this.VMProfile.StorageProfile.DataDisks == null)
            {
                this.VMProfile.StorageProfile.DataDisks = new List<DataDisk>();
            }

            this.VMProfile.StorageProfile.DataDisks.Add(new DataDisk
            {
                Name = this.Name,
                Caching = this.Caching,
                DiskSizeGB = this.DiskSizeInGB,
                Lun = this.Lun == null ? 0 : this.Lun.Value,
                VhdUri = new Uri(this.VhdUri)
            });

            WriteObject(this.VMProfile);
        }
    }
}
