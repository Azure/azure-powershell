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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureRmVirtualNetworkPeering"), OutputType(typeof(PSVirtualNetworkPeering))]
    public class AddAzureVirtualNetworkPeeringCommand : VirtualNetworkPeeringBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the virtual network peering")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Reference to the remote virtual network")]
        public string RemoteVirtualNetworkId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to block the VMs in the linked virtual network space to access all the VMs in local Virtual network space")]
        public SwitchParameter BlockVirtualNetworkAccess { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to allow the forwarded traffic from the VMs in the remote virtual network")]
        public SwitchParameter AllowForwardedTraffic { get; set; }

        [Alias("AllowGatewayTransit")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to allow gatewayLinks be used in remote virtual network's link to this virtual network")]
        public SwitchParameter AlloowGatewayTransit { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to allow remote gateways be used on this virtual network")]
        public SwitchParameter UseRemoteGateways { get; set; }

        public override void Execute()
        {
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");

            if (this.IsVirtualNetworkPeeringPresent(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name, this.Name))
            {
                throw new ArgumentException("Peering with the specified name already exists");
            }
            else
            {
                var virtualNetworkPeering = AddVirtualNetworkPeering();

                WriteObject(virtualNetworkPeering);
            }
        }

        private PSVirtualNetworkPeering AddVirtualNetworkPeering()
        {
            var vnetPeering= new PSVirtualNetworkPeering();
            vnetPeering.Name = this.Name;

            if (!string.IsNullOrEmpty(this.RemoteVirtualNetworkId))
            {
                vnetPeering.RemoteVirtualNetwork = new PSResourceId();
                vnetPeering.RemoteVirtualNetwork.Id = this.RemoteVirtualNetworkId;
            }

            vnetPeering.AllowVirtualNetworkAccess = !this.BlockVirtualNetworkAccess.IsPresent;
            vnetPeering.AllowGatewayTransit = this.AlloowGatewayTransit;
            vnetPeering.AllowForwardedTraffic = this.AllowForwardedTraffic;

            // Map to the sdk object
            var vnetPeeringModel = Mapper.Map<MNM.VirtualNetworkPeering>(vnetPeering);

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkPeeringClient.CreateOrUpdate(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name, this.Name, vnetPeeringModel);

            var getVirtualNetworkPeering = this.GetVirtualNetworkPeering(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name, this.Name);

            return getVirtualNetworkPeering;
        }
    }
}
