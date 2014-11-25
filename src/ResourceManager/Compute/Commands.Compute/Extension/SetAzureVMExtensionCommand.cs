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
    [Cmdlet(VerbsCommon.New, ProfileNouns.VirtualMachineExtension)]
    [OutputType(typeof(object))]
    public class SetAzureVMExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        [Parameter(Position = 3, HelpMessage = "The location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var parameters = new VirtualMachineExtensionCreateOrUpdateParameters
            {
                VirtualMachineExtension = new VirtualMachineExtension
                {
                    Location = this.Location,
                    Name = this.Name,
                    VirtualMachineExtensionProperties = new VirtualMachineExtensionProperties
                    {
                    }
                }
            };

            var op = this.VirtualMachineExtensionClient.CreateOrUpdate(
                this.ResourceGroupName,
                this.VMName,
                parameters);
            WriteObject(op);
        }
    }
}
