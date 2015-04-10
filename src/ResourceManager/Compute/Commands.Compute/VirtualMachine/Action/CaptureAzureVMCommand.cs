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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsData.Save, ProfileNouns.VirtualMachine)]
    public class SaveAzureVMCommand : VirtualMachineBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 1,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 2,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The Destination Container Name.")]
        [ValidateNotNullOrEmpty]
        public string DestinationContainerName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 3,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "To Overwrite.")]
        [ValidateNotNullOrEmpty]
        public bool Overwrite { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 4,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The Virtual Hard Disk Name Prefix.")]
        [ValidateNotNullOrEmpty]
        public string VirtualHardDiskNamePrefix { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var parameters = new VirtualMachineCaptureParameters
            {
                DestinationContainerName = DestinationContainerName,
                Overwrite = Overwrite,
                VirtualHardDiskNamePrefix = VirtualHardDiskNamePrefix
            };

            var op = this.VirtualMachineClient.Capture(
                this.ResourceGroupName,
                this.Name,
                parameters);

            WriteObject(op);
        }
    }
}
