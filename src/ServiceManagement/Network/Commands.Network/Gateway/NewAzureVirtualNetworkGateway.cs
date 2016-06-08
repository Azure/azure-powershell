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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway
{
    [Cmdlet(VerbsCommon.New, "AzureVirtualNetworkGateway"), OutputType(typeof(ManagementOperationContext))]
    public class NewAzureVirtualNetworkGatewayCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Virtual network name.")]
        public string VNetName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The virtual network gateway name.")]
        public string GatewayName { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The type of routing that the gateway will use:StaticRouting/DynamicRouting. This will default to StaticRouting if no value is provided.")]
        public string GatewayType { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The Gateway SKU for the new gateway:Default/HighPerformance/Standard. This will default to 'Default' SKU if no value is provided.")]
        public string GatewaySKU { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "Location for the virtual network gateway.")]
        public string Location { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "The virtual network Id.")]
        [ValidateGuid]
        [ValidateNotNullOrEmpty]
        public string VnetId { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = "Virtual network gateway BGP speaker's ASN")]
        public uint Asn { get; set; }

        [Parameter(Position = 7, Mandatory = false, HelpMessage = "Weight for routes learned from this BGP speaker")]
        public int PeerWeight { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(Client.CreateVirtualNetworkGateway(VNetName, GatewayName, GatewayType, GatewaySKU, Location, VnetId, Asn, PeerWeight));
        }
    }
}
