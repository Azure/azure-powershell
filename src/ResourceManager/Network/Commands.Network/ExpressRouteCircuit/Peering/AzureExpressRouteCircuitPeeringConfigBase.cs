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
    using System.Collections.Generic;

    public class AzureExpressRouteCircuitPeeringConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the Peering")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PeeringType")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
           MNM.ExpressRouteCircuitPeeringType.AzurePrivatePeering,
           MNM.ExpressRouteCircuitPeeringType.AzurePublicPeering,
           MNM.ExpressRouteCircuitPeeringType.MicrosoftPeering,
           IgnoreCase = true)]
        public string PeeringType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PeerAsn")]
        [ValidateNotNullOrEmpty]
        public int PeerASN { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PrimaryPeerAddressPrefix")]
        [ValidateNotNullOrEmpty]
        public string PrimaryPeerAddressPrefix { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The SecondaryPeerAddressPrefix")]
        [ValidateNotNullOrEmpty]
        public string SecondaryPeerAddressPrefix { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The vlanId")]
        [ValidateNotNullOrEmpty]
        public int VlanId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SharedKey")]
        [ValidateNotNullOrEmpty]
        public string SharedKey { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The MircosoftConfigAdvertisedPublicPrefixes",
            ParameterSetName = "MicrosoftPeeringConfig")]
        [ValidateNotNullOrEmpty]
        public List<string> MicrosoftConfigAdvertisedPublicPrefixes { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The customerAsn",
            ParameterSetName = "MicrosoftPeeringConfig")]
        [ValidateNotNullOrEmpty]
        public int MicrosoftConfigCustomerAsn { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The MircosoftConfigRoutingRegistryName",
            ParameterSetName = "MicrosoftPeeringConfig")]
        [ValidateNotNullOrEmpty]
        public string MicrosoftConfigRoutingRegistryName { get; set; }

    }
}
