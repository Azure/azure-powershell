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
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Remove,
        ProfileNouns.DataDisk),
    OutputType(
        typeof(PSVirtualMachine))]
    public class RemoveAzureVMDataDiskCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMDataDiskName)]
        [ValidateNotNullOrEmpty]
        public string[] DataDiskNames { get; set; }

        public override void ExecuteCmdlet()
        {
            var storageProfile = this.VM.StorageProfile;

            if (storageProfile != null && storageProfile.DataDisks != null)
            {
                var disks = storageProfile.DataDisks.ToList();
                var comp = StringComparison.OrdinalIgnoreCase;
                foreach (var diskName in DataDiskNames)
                {
                    disks.RemoveAll(d => string.Equals(d.Name, diskName, comp));
                }
                storageProfile.DataDisks = disks;
            }

            this.VM.StorageProfile = storageProfile;

            WriteObject(this.VM);
        }
    }
}
