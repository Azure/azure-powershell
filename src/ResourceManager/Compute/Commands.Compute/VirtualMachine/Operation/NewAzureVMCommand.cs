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
    [Cmdlet(VerbsCommon.New, ProfileNouns.VirtualMachine), OutputType(typeof(VirtualMachine))]
    public class NewAzureVMCommand : VirtualMachineBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The VM Profile.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VMProfile { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Availability Set Id.")]
        [ValidateNotNullOrEmpty]
        public string AvailabilitySetId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            VirtualMachineProperties vmProps = new VirtualMachineProperties
            {
                HardwareProfile = this.VMProfile.HardwareProfile,
                StorageProfile = this.VMProfile.StorageProfile,
                NetworkProfile = this.VMProfile.NetworkProfile,
                OSProfile = this.VMProfile.OSProfile,
                AvailabilitySetReference = string.IsNullOrEmpty(this.AvailabilitySetId) ? null
                                         : new AvailabilitySetReference
                                           {
                                               ReferenceUri = this.AvailabilitySetId
                                           }
            };

            var parameters = new VirtualMachineCreateOrUpdateParameters
            {
                VirtualMachine = new VirtualMachine
                {
                    VirtualMachineProperties = vmProps,
                    Location = this.Location,
                    Name = this.Name
                }
            };

            var op = this.VirtualMachineClient.CreateOrUpdate(this.ResourceGroupName, parameters);
            WriteObject(op);
        }
    }
}
