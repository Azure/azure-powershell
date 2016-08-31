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

using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsDiagnostic.Test, "AzureRmPrivateIpAddressAvailability"), OutputType(typeof(PSPrivateIpAddressAvailabilityResponse))]
    public class TestAzurePrivateIpAddressAvailabilityCmdlet : VirtualNetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Private Ip Address")]
        [ValidateNotNullOrEmpty]
        public string IpAddress { get; set; }

        public override void Execute()
        {
            base.Execute();
            var result = this.NetworkClient.NetworkManagementClient.VirtualNetworks.CheckIPAddressAvailability(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name, this.IpAddress);
            WriteObject(result);
        }
    }
}
