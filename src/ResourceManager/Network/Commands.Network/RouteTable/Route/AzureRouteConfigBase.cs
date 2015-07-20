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
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureRouteConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the route")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination CIDR to which the route applies")]
        [ValidateNotNullOrEmpty]
        public string AddressPrefix { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The type of Azure hop the packet should be sent to.")]
        [ValidateSet(
            MNM.RouteNextHopType.Internet,
            MNM.RouteNextHopType.None,
            MNM.RouteNextHopType.VirtualAppliance,
            MNM.RouteNextHopType.VirtualNetworkGateway,
            MNM.RouteNextHopType.VnetLocal,
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string NextHopType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP address packets should be forwarded to. "
                            + "Next hop values are only allowed in routes where the "
                            + "next hop type is VirtualAppliance.")]
        public string NextHopIpAddress { get; set; }
    }
}
