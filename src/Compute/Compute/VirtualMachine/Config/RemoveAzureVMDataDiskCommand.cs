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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMDataDisk",SupportsShouldProcess = true),OutputType(typeof(PSVirtualMachine))]
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
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.VMDataDiskName)]
        [ValidateNotNullOrEmpty]
        public string[] DataDiskNames { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "Sets provided disks' detachOption property to ForceDetach. Only applicable for managed data disks.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ForceDetach { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess("DataDisk", VerbsCommon.Remove))
            {
                var storageProfile = this.VM.StorageProfile;

                if (storageProfile != null && storageProfile.DataDisks != null)
                {
                    var disks = storageProfile.DataDisks.ToList();
                    var comp = StringComparison.OrdinalIgnoreCase;

                    if (this.ForceDetach != true) {
                        if (DataDiskNames == null){
                            disks.Clear();
                        }
                        else{
                            foreach (var diskName in DataDiskNames){
                                disks.RemoveAll(d => string.Equals(d.Name, diskName, comp));
                            }
                        }
                    }
                    else{
                        if (this.DataDiskNames == null){
                            foreach (var disk in disks){
                                disk.DetachOption = "ForceDetach";
                                disk.ToBeDetached = true;
                            }
                        }
                        else
                        {
                            foreach (var disk in disks){
                               if (DataDiskNames.Contains(disk.Name)){
                                    disk.ToBeDetached = true;
                                    disk.DetachOption = "ForceDetach";
                               }
                            }
                        }
                    }
                    
                    storageProfile.DataDisks = disks;
                }
                this.VM.StorageProfile = storageProfile;

                WriteObject(this.VM);
            }
        }
    }
}
