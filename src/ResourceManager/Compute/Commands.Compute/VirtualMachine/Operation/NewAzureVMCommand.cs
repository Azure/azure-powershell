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
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.New, ProfileNouns.VirtualMachine)]
    public class NewAzureVMCommand : VirtualMachineBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Alias("VMProfile")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Hashtable[] Tags { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                var parameters = new VirtualMachine
                {
                    HardwareProfile          = this.VM.HardwareProfile,
                    StorageProfile           = this.VM.StorageProfile,
                    NetworkProfile           = this.VM.NetworkProfile,
                    OSProfile                = this.VM.OSProfile,
                    Plan                     = this.VM.Plan,
                    AvailabilitySetReference = this.VM.AvailabilitySetReference,
                    Location                 = !string.IsNullOrEmpty(this.Location) ? this.Location : this.VM.Location,
                    Name                     = this.VM.Name,
                    Tags                     = this.Tags != null ? this.Tags.ToDictionary() : this.VM.Tags
                };

                var op = this.VirtualMachineClient.CreateOrUpdate(this.ResourceGroupName, parameters);
                WriteObject(op);
            });
        }
    }
}
