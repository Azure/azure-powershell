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

using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway
{
    [Cmdlet(VerbsCommon.Reset, "AzureLocalNetworkGateway"), OutputType(typeof(AzureOperationResponse))]
    public class ResetAzureLocalNetworkGateway : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Virtual network gateway Id.")]
        [ValidateGuid]
        [ValidateNotNullOrEmpty]
        public string GatewayId
        {
            get; set;
        }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The local network gateway AddressSpace.")]
        [ValidateNotNullOrEmpty]
        public List<string> AddressSpace
        {
            get; set;
        }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The local network gateway BGP speaker's ASN")]
        public uint Asn
        {
            get; set;
        }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The local network gateway BGP speaker's IP/BGP identifier")]
        public string BgpPeeringAddress
        {
            get; set;
        }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "Weight for routes learned from local network gateway's BGP speaker")]
        public int PeerWeight
        {
            get; set;
        }

        public override void ExecuteCmdlet()
        {
            WriteObject(Client.UpdateLocalNetworkGateway(GatewayId, AddressSpace, Asn, BgpPeeringAddress, PeerWeight));
        }
    }
}
