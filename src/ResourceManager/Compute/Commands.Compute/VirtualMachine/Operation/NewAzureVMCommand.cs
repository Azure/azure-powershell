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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Creates a new resource.
    /// </summary>
    [Cmdlet(VerbsCommon.New, ProfileNouns.VirtualMachine)]
    public class NewAzureVMCommand : VirtualMachineBaseCmdlet
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
            HelpMessage = "The Location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The VM Profile.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Alias("ResourceName", "VMName")]
        [Parameter(
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The VM name.")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var parameters = new VirtualMachine
            {
                HardwareProfile = this.VM.HardwareProfile,
                StorageProfile = this.VM.StorageProfile,
                NetworkProfile = this.VM.NetworkProfile,
                OSProfile = this.VM.OSProfile,
                AvailabilitySetReference = this.VM.AvailabilitySetReference,
                Location = !string.IsNullOrEmpty(this.Location) ? this.Location : this.VM.Location,
                Name = !string.IsNullOrEmpty(this.Name) ? this.Name : this.VM.Name
            };

            var op = this.VirtualMachineClient.CreateOrUpdate(this.ResourceGroupName, parameters);
            WriteObject(op);
        }
    }
}
