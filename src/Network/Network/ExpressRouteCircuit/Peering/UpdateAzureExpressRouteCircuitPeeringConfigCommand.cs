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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCircuitPeeringConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSExpressRouteCircuit))]
    public class UpdateAzureExpressRouteCircuitPeeringConfigCommand : AzureExpressRouteCircuitPeeringConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Peering")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRouteCircuit")]
        public PSExpressRouteCircuit ExpressRouteCircuit { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The PeeringType")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
           MNM.ExpressRoutePeeringType.AzurePrivatePeering,
           MNM.ExpressRoutePeeringType.AzurePublicPeering,
           MNM.ExpressRoutePeeringType.MicrosoftPeering,
           IgnoreCase = true)]
        public override string PeeringType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The PeerAsn")]
        [ValidateNotNullOrEmpty]
        public override uint PeerASN { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The PrimaryPeerAddressPrefix")]
        [ValidateNotNullOrEmpty]
        public override string PrimaryPeerAddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SecondaryPeerAddressPrefix")]
        [ValidateNotNullOrEmpty]
        public override string SecondaryPeerAddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The vlanId")]
        [ValidateNotNullOrEmpty]
        public override int VlanId { get; set; }

        public override void Execute()
        {
            base.Execute();
            // Verify if the subnet exists in the VirtualNetwork
            var peering = this.ExpressRouteCircuit.Peerings.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));

            if (peering == null)
            {
                throw new ArgumentException("Peering with the specified name does not exist");
            }

            if (string.Equals(ParameterSetName, ParamSetByRouteFilter))
            {
                if (this.RouteFilter != null)
                {
                    this.RouteFilterId = this.RouteFilter.Id;
                }
            }

            if (this.PeeringType != null)
            {
                peering.PeeringType = this.PeeringType;
            }

            if (MyInvocation.BoundParameters.ContainsKey("PeerASN"))
            {
                peering.PeerASN = this.PeerASN;
            }

            if (MyInvocation.BoundParameters.ContainsKey("VlanId"))
            {
                peering.VlanId = this.VlanId;
            }

            if (!string.IsNullOrEmpty(this.SharedKey))
            {
                peering.SharedKey = this.SharedKey;
            }

            if (PeerAddressType == IPv6)
            {
                this.UpdateIpv6PeeringParameters(peering);
            }
            else
            {
                // Set IPv4 config even if no PeerAddresType has been specified for backward compatibility
                this.UpdateIpv4PeeringParameters(peering);
            }

            if(this.MicrosoftConfigAdvertisedPublicPrefixes != null ||
                MyInvocation.BoundParameters.ContainsKey("MicrosoftConfigCustomerAsn") ||
                this.MicrosoftConfigRoutingRegistryName != null)
            this.UpdateMicrosoftConfig(peering);

            WriteObject(this.ExpressRouteCircuit);
        }
    }
}
