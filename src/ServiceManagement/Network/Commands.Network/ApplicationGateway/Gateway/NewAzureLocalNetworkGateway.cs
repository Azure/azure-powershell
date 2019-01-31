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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway
{
    [Cmdlet(VerbsCommon.New, "AzureLocalNetworkGateway"), OutputType(typeof(LocalNetwrokGatewayContext))]
    public class NewAzureLocalNetworkGateway : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The virtual network gateway name.")]
        public string GatewayName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The Ip Address of local network gateway .")]
        public string IpAddress { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The virtual network gateway AddressSpace.")]
        public List<string> AddressSpace { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "On-premise BGP speaker's ASN")]
        public uint Asn { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "On-premise BGP speaker's IP/BGP identifier")]
        public string BgpPeeringAddress { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "Weight for routes learned from this BGP speaker")]
        public int PeerWeight { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(Client.CreateLocalNetworkGateway(GatewayName, IpAddress, AddressSpace, Asn, BgpPeeringAddress, PeerWeight));
        }
    }
}
