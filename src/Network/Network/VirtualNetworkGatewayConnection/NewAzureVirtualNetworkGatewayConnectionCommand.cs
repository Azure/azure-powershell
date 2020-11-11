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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayConnection", SupportsShouldProcess = true,DefaultParameterSetName = "SetByResource"),OutputType(typeof(PSVirtualNetworkGatewayConnection))]
    public class NewAzureVirtualNetworkGatewayConnectionCommand : VirtualNetworkGatewayConnectionBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "location.")]
        [LocationCompleter("Microsoft.Network/connections")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
         Mandatory = false,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "AuthorizationKey.")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationKey { get; set; }

        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "First virtual network gateway.")]
        public PSVirtualNetworkGateway VirtualNetworkGateway1 { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Second virtual network gateway.")]
        public PSVirtualNetworkGateway VirtualNetworkGateway2 { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "local network gateway.")]
        public PSLocalNetworkGateway LocalNetworkGateway2 { get; set; }

        [Parameter(
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gateway connection type:IPsec/Vnet2Vnet/ExpressRoute/VPNClient")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.VirtualNetworkGatewayConnectionType.IPsec,
            MNM.VirtualNetworkGatewayConnectionType.Vnet2Vnet,
            MNM.VirtualNetworkGatewayConnectionType.ExpressRoute,
            MNM.VirtualNetworkGatewayConnectionType.VPNClient,
            IgnoreCase = true)]
        public string ConnectionType { get; set; }

        [Parameter(
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "RoutingWeight.")]
        public int RoutingWeight { get; set; }
        
        [Parameter(
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Dead Peer Detection Timeout of the connection in seconds.")]
        public int DpdTimeoutInSeconds { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "Virtual Network Gateway Connection Mode.")]
        [PSArgumentCompleter("Default", "ResponderOnly", "InitiatorOnly")]
        public string ConnectionMode { get; set; }

        [Parameter(
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The Ipsec share key.")]
        public string SharedKey { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "PeerId")]
        public string PeerId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "Peer")]
        public PSPeering Peer { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to establish a BGP session over a S2S VPN tunnel")]
        public bool EnableBgp { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to use PrivateIP for this S2S VPN tunnel")]
        public SwitchParameter UseLocalAzureIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }
        
        [Parameter(
            Mandatory = false,
            HelpMessage = "Whether to use policy-based traffic selectors for a S2S connection")]
        public bool UsePolicyBasedTrafficSelectors { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "A list of IPSec policies.")]
        public PSIpsecPolicy[] IpsecPolicies { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "A list of traffic selector policies.")]
        public PSTrafficSelectorPolicy[] TrafficSelectorPolicy { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "Gateway connection protocol:IKEv1/IKEv2")]
        [ValidateSet(
            MNM.VirtualNetworkGatewayConnectionProtocol.IKEv1,
            MNM.VirtualNetworkGatewayConnectionProtocol.IKEv2,
            IgnoreCase = true)]
        public string ConnectionProtocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to use accelerated virtual network access by bypassing gateway")]
        public SwitchParameter ExpressRouteGatewayBypass { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsVirtualNetworkGatewayConnectionPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResource, Name),
                Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResourceMessage,
                Name,
                () =>
                {
                    var virtualNetworkGatewayConnection = CreateVirtualNetworkGatewayConnection();
                    WriteObject(virtualNetworkGatewayConnection);
                },
                () => present);
        }

        private PSVirtualNetworkGatewayConnection CreateVirtualNetworkGatewayConnection()
        {
            var vnetGatewayConnection = new PSVirtualNetworkGatewayConnection();
            vnetGatewayConnection.Name = this.Name;
            vnetGatewayConnection.ResourceGroupName = this.ResourceGroupName;
            vnetGatewayConnection.Location = this.Location;
            vnetGatewayConnection.VirtualNetworkGateway1 = this.VirtualNetworkGateway1;
            vnetGatewayConnection.VirtualNetworkGateway2 = this.VirtualNetworkGateway2;
            vnetGatewayConnection.LocalNetworkGateway2 = this.LocalNetworkGateway2;
            vnetGatewayConnection.ConnectionType = this.ConnectionType;
            vnetGatewayConnection.RoutingWeight = this.RoutingWeight;
            vnetGatewayConnection.DpdTimeoutSeconds = this.DpdTimeoutInSeconds;
            vnetGatewayConnection.ConnectionMode = this.ConnectionMode;
            vnetGatewayConnection.SharedKey = this.SharedKey;
            vnetGatewayConnection.EnableBgp = this.EnableBgp;
            vnetGatewayConnection.UseLocalAzureIpAddress = this.UseLocalAzureIpAddress.IsPresent;
            vnetGatewayConnection.UsePolicyBasedTrafficSelectors = this.UsePolicyBasedTrafficSelectors;
            vnetGatewayConnection.ExpressRouteGatewayBypass = this.ExpressRouteGatewayBypass.IsPresent;

            if (!string.IsNullOrWhiteSpace(this.ConnectionProtocol))
            {
                vnetGatewayConnection.ConnectionProtocol = this.ConnectionProtocol;
            }
            
            if (!string.IsNullOrEmpty(this.AuthorizationKey))
            {
                vnetGatewayConnection.AuthorizationKey = this.AuthorizationKey;
            }
            
            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.Peer != null)
                {
                    this.PeerId = this.Peer.Id;
                }
            }

            if (!string.IsNullOrEmpty(this.PeerId))
            {
                vnetGatewayConnection.Peer = new PSResourceId();
                vnetGatewayConnection.Peer.Id = this.PeerId;
            }

            if (this.IpsecPolicies != null)
            {
                vnetGatewayConnection.IpsecPolicies = this.IpsecPolicies?.ToList();
            }

            if (this.TrafficSelectorPolicy != null)
            {
                vnetGatewayConnection.TrafficSelectorPolicies = this.TrafficSelectorPolicy?.ToList();
            }

            // Map to the sdk object
            var vnetGatewayConnectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkGatewayConnection>(vnetGatewayConnection);
            vnetGatewayConnectionModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create VirtualNetworkConnection call
            this.VirtualNetworkGatewayConnectionClient.CreateOrUpdate(this.ResourceGroupName, this.Name, vnetGatewayConnectionModel);

            var getVirtualNetworkGatewayConnection = this.GetVirtualNetworkGatewayConnection(this.ResourceGroupName, this.Name);

            return getVirtualNetworkGatewayConnection;
        }
    }
}
