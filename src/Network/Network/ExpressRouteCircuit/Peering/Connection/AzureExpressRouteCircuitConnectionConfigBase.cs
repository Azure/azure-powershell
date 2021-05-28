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

namespace Microsoft.Azure.Commands.Network
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using Microsoft.Azure.Commands.Network.Models;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using System.Linq;

    public class AzureExpressRouteCircuitConnectionConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "The name of the Circuit Connection Resource")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "Private Peering of Circuit being peered")]
        public string PeerExpressRouteCircuitPeering { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = "Private IP Addresses to create VxLAN Tunnels")]
        [ValidateNotNullOrEmpty]
        public string AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Authorization Key to peer to circuit in another subscription")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationKey { get; set; }
    }
}