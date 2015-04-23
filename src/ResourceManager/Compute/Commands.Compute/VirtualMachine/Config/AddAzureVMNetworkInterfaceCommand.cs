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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Setup the network interface.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Add,
        ProfileNouns.NetworkInterface),
    OutputType(
        typeof(PSVirtualMachine))]
    public class AddAzureVMNetworkInterfaceCommand : AzurePSCmdlet
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

        [Alias("NicId", "NetworkInterfaceId")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMNetworkInterfaceID)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Primary { get; set; }

        public override void ExecuteCmdlet()
        {
            var networkProfile = this.VM.NetworkProfile;

            if (networkProfile == null)
            {
                networkProfile = new NetworkProfile
                {
                    NetworkInterfaces = new List<NetworkInterfaceReference>()
                };
            }

            if (networkProfile.NetworkInterfaces == null)
            {
                networkProfile.NetworkInterfaces = new List<NetworkInterfaceReference>();
            }

            if (!this.Primary.IsPresent)
            {

                networkProfile.NetworkInterfaces.Add(new NetworkInterfaceReference
                    {
                        ReferenceUri = this.Id,
                    });

                if (networkProfile.NetworkInterfaces.Count > 1)
                {
                    // run through the entire list of networkInterfaces and if Primary is not set, set them to false
                    foreach (var nic in networkProfile.NetworkInterfaces)
                    {
                        nic.Primary = nic.Primary ?? false;
                    }
                }
            }
            else
            {
                foreach (var networkInterfaceReference in networkProfile.NetworkInterfaces)
                {
                    networkInterfaceReference.Primary = false;
                }

                networkProfile.NetworkInterfaces.Add(
                    new NetworkInterfaceReference
                    {
                        ReferenceUri = this.Id,
                        Primary = true
                    });
            }

            this.VM.NetworkProfile = networkProfile;

            WriteObject(this.VM);
        }
    }
}
