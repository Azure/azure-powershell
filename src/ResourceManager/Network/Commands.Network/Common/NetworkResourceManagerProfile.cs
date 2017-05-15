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
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using CNM = Microsoft.Azure.Commands.Network.Models;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class NetworkResourceManagerProfile : Profile
    {
        public static NetworkResourceManagerProfile Instance = new NetworkResourceManagerProfile();

        private readonly Lazy<bool> initialize;

        public NetworkResourceManagerProfile()
        {
            initialize = new Lazy<bool>(() =>
            {
                CreateMap<CNM.PSResourceId, MNM.SubResource>();
                CreateMap<MNM.SubResource, CNM.PSResourceId>();

                // Route Filter 
                CreateMap<CNM.PSRouteFilter, MNM.RouteFilter>();
                CreateMap<MNM.RouteFilter, CNM.PSRouteFilter>();
                CreateMap<CNM.PSRouteFilterRule, MNM.RouteFilterRule>();
                CreateMap<MNM.RouteFilterRule, CNM.PSRouteFilterRule>();

                // Bgp Service Community
                CreateMap<CNM.PSBgpServiceCommunity, MNM.BgpServiceCommunity>();
                CreateMap<CNM.PSBgpCommunity, MNM.BGPCommunity>();
                CreateMap<MNM.BgpServiceCommunity, CNM.PSBgpServiceCommunity>();
                CreateMap<MNM.BGPCommunity, CNM.PSBgpCommunity>();

                // Subnet
                // CNM to MNM
                CreateMap<CNM.PSDhcpOptions, MNM.DhcpOptions>();
                CreateMap<CNM.PSSubnet, MNM.Subnet>();
                CreateMap<CNM.PSIPConfiguration, MNM.IPConfiguration>();
                CreateMap<CNM.PSResourceNavigationLink, MNM.ResourceNavigationLink>();

                // MNM to CNM
                CreateMap<MNM.DhcpOptions, CNM.PSDhcpOptions>();
                CreateMap<MNM.Subnet, CNM.PSSubnet>();
                CreateMap<MNM.IPConfiguration, CNM.PSIPConfiguration>();
                CreateMap<MNM.ResourceNavigationLink, CNM.PSResourceNavigationLink>();

                // TestPrivateIpAddressAvailability
                // CNM to MNM
                CreateMap<CNM.PSIPAddressAvailabilityResult, MNM.IPAddressAvailabilityResult>();

                // MNM to CNM
                CreateMap<MNM.IPAddressAvailabilityResult, CNM.PSIPAddressAvailabilityResult>();

                // VirtualNetwork Peering
                CreateMap<CNM.PSVirtualNetworkPeering, MNM.VirtualNetworkPeering>();

                CreateMap<MNM.VirtualNetworkPeering, CNM.PSVirtualNetworkPeering>();

                // VirtualNetwork
                // CNM to MNM
                CreateMap<CNM.PSAddressSpace, MNM.AddressSpace>();
                CreateMap<CNM.PSVirtualNetwork, MNM.VirtualNetwork>();

                // MNM to CNM
                CreateMap<MNM.AddressSpace, CNM.PSAddressSpace>();
                CreateMap<MNM.VirtualNetwork, CNM.PSVirtualNetwork>();

                // PublicIpAddress
                // CNM to MNM
                CreateMap<CNM.PSPublicIpAddress, MNM.PublicIPAddress>();
                CreateMap<CNM.PSPublicIpAddressDnsSettings, MNM.PublicIPAddressDnsSettings>();

                // MNM to CNM
                CreateMap<MNM.PublicIPAddress, CNM.PSPublicIpAddress>();
                CreateMap<MNM.PublicIPAddressDnsSettings, CNM.PSPublicIpAddressDnsSettings>();

                // NetworkInterface
                // CNM to MNM
                CreateMap<CNM.PSNetworkInterface, MNM.NetworkInterface>();
                CreateMap<CNM.PSNetworkInterfaceDnsSettings, MNM.NetworkInterfaceDnsSettings>();
                CreateMap<CNM.PSNetworkInterfaceIPConfiguration, MNM.NetworkInterfaceIPConfiguration>();

                // MNM to CNM
                CreateMap<MNM.NetworkInterface, CNM.PSNetworkInterface>();
                CreateMap<MNM.NetworkInterfaceDnsSettings, CNM.PSNetworkInterfaceDnsSettings>();
                CreateMap<MNM.NetworkInterfaceIPConfiguration, CNM.PSNetworkInterfaceIPConfiguration>();

                // NetworkWatcher
                // CNM to MNM
                CreateMap<CNM.PSNetworkWatcher, MNM.NetworkWatcher>();

                // MNM to CNM
                CreateMap<MNM.NetworkWatcher, CNM.PSNetworkWatcher>();

                // PacketCapture
                // CNM to MNM
                CreateMap<CNM.PSPacketCapture, MNM.PacketCaptureParameters>();
                CreateMap<CNM.PSPacketCaptureResult, MNM.PacketCaptureResult>();
                CreateMap<CNM.PSStorageLocation, MNM.PacketCaptureStorageLocation>();
                CreateMap<CNM.PSPacketCaptureFilter, MNM.PacketCaptureFilter>();
                CreateMap<CNM.PSPacketCaptureStatus, MNM.PacketCaptureQueryStatusResult>();

                // MNM to CNM
                CreateMap<MNM.PacketCaptureParameters, CNM.PSPacketCapture>();
                CreateMap<MNM.PacketCaptureResult, CNM.PSPacketCaptureResult>();
                CreateMap<MNM.PacketCaptureStorageLocation, CNM.PSStorageLocation>();
                CreateMap<MNM.PacketCaptureFilter, CNM.PSPacketCaptureFilter>();
                CreateMap<MNM.PacketCaptureQueryStatusResult, CNM.PSPacketCaptureStatus>();

                // Topology
                // CNM to MNM
                CreateMap<CNM.PSTopology, MNM.Topology>();
                CreateMap<CNM.PSTopologyResource, MNM.TopologyResource>();
                CreateMap<CNM.PSTopologyAssociation, MNM.TopologyAssociation>();

                // MNM to CNM
                CreateMap<MNM.Topology, CNM.PSTopology>();
                CreateMap<MNM.TopologyResource, CNM.PSTopologyResource>();
                CreateMap<MNM.TopologyAssociation, CNM.PSTopologyAssociation>();

                // ViewNsgRules
                // CNM to MNM
                CreateMap<CNM.PSSecurityGroupNetworkInterface, MNM.SecurityGroupNetworkInterface>();
                CreateMap<CNM.PSSecurityRuleAssociations, MNM.SecurityRuleAssociations>();
                CreateMap<CNM.PSNetworkInterfaceAssociation, MNM.NetworkInterfaceAssociation>();
                CreateMap<CNM.PSSubnetAssociation, MNM.SubnetAssociation>();

                // MNM to CNM
                CreateMap<MNM.SecurityGroupNetworkInterface, CNM.PSSecurityGroupNetworkInterface>();
                CreateMap<MNM.SecurityRuleAssociations, CNM.PSSecurityRuleAssociations>();
                CreateMap<MNM.NetworkInterfaceAssociation, CNM.PSNetworkInterfaceAssociation>();
                CreateMap<MNM.SubnetAssociation, CNM.PSSubnetAssociation>();

                // IpFlowVerify
                // CNM to MNM
                CreateMap<CNM.PSIPFlowVerifyResult, MNM.VerificationIPFlowResult>();

                // MNM to CNM
                CreateMap<MNM.VerificationIPFlowResult, CNM.PSIPFlowVerifyResult>();

                // NextHop
                // CNM to MNM
                CreateMap<CNM.PSNextHopResult, MNM.NextHopResult>();

                // MNM to CNM
                CreateMap<MNM.NextHopResult, CNM.PSNextHopResult>();

                // Troubleshoot
                // CNM to MNM
                CreateMap<CNM.PSTroubleshootResult, MNM.TroubleshootingResult>();
                CreateMap<CNM.PSTroubleshootDetails, MNM.TroubleshootingDetails>();
                CreateMap<CNM.PSTroubleshootRecommendedActions, MNM.TroubleshootingRecommendedActions>();

                // MNM to CNM
                CreateMap<MNM.TroubleshootingResult, CNM.PSTroubleshootResult>();
                CreateMap<MNM.TroubleshootingDetails, CNM.PSTroubleshootDetails>();
                CreateMap<MNM.TroubleshootingRecommendedActions, CNM.PSTroubleshootRecommendedActions>();

                // FlowLog
                // CNM to MNM
                CreateMap<CNM.PSFlowLog, MNM.FlowLogInformation>();
                CreateMap<CNM.PSRetentionPolicyParameters, MNM.RetentionPolicyParameters>();

                // MNM to CNM
                CreateMap<MNM.FlowLogInformation, CNM.PSFlowLog>();
                CreateMap<MNM.RetentionPolicyParameters, CNM.PSRetentionPolicyParameters>();

                // LoadBalancer
                // CNM to MNM
                CreateMap<CNM.PSLoadBalancer, MNM.LoadBalancer>();

                // MNM to CNM
                CreateMap<MNM.LoadBalancer, CNM.PSLoadBalancer>();

                // FrontendIpConfiguration
                // CNM to MNM
                CreateMap<CNM.PSFrontendIPConfiguration, MNM.FrontendIPConfiguration>();

                // MNM to CNM
                CreateMap<MNM.FrontendIPConfiguration, CNM.PSFrontendIPConfiguration>();

                // BackendAddressPool
                // CNM to MNM
                CreateMap<CNM.PSBackendAddressPool, MNM.BackendAddressPool>();

                // MNM to CNM
                CreateMap<MNM.BackendAddressPool, CNM.PSBackendAddressPool>();

                // LoadBalancingRule
                // CNM to MNM
                CreateMap<CNM.PSLoadBalancingRule, MNM.LoadBalancingRule>();

                // MNM to CNM
                CreateMap<MNM.LoadBalancingRule, CNM.PSLoadBalancingRule>();

                // Probes
                // CNM to MNM
                CreateMap<CNM.PSProbe, MNM.Probe>();

                // MNM to CNM
                CreateMap<MNM.Probe, CNM.PSProbe>();

                // InboundNatRules
                // CNM to MNM
                CreateMap<CNM.PSInboundNatRule, MNM.InboundNatRule>();

                // MNM to CNM
                CreateMap<MNM.InboundNatRule, CNM.PSInboundNatRule>();

                // InboundNatPools
                // CNM to MNM
                CreateMap<CNM.PSInboundNatPool, MNM.InboundNatPool>();

                // MNM to CNM
                CreateMap<MNM.InboundNatPool, CNM.PSInboundNatPool>();

                // NetworkSecurityGroups
                // CNM to MNM
                CreateMap<CNM.PSNetworkSecurityGroup, MNM.NetworkSecurityGroup>();

                // MNM to CNM
                CreateMap<MNM.NetworkSecurityGroup, CNM.PSNetworkSecurityGroup>();

                // NetworkSecrityRule
                // CNM to MNM
                CreateMap<CNM.PSSecurityRule, MNM.SecurityRule>();

                // MNM to CNM
                CreateMap<MNM.SecurityRule, CNM.PSSecurityRule>();

                // RouteTable
                // CNM to MNM
                CreateMap<CNM.PSRouteTable, MNM.RouteTable>();

                // MNM to CNM
                CreateMap<MNM.RouteTable, CNM.PSRouteTable>();

                // Route
                // CNM to MNM
                CreateMap<CNM.PSRoute, MNM.Route>();

                // MNM to CNM
                CreateMap<MNM.Route, CNM.PSRoute>();

                // EffectiveRouteTable
                // CNM to MNM
                CreateMap<CNM.PSEffectiveRoute, MNM.EffectiveRoute>();

                // MNM to CNM
                CreateMap<MNM.EffectiveRoute, CNM.PSEffectiveRoute>();

                // EffectiveNetworkSecurityGroup
                // CNM to MNM
                CreateMap<CNM.PSEffectiveNetworkSecurityGroup, MNM.EffectiveNetworkSecurityGroup>();
                CreateMap<CNM.PSEffectiveNetworkSecurityGroupAssociation, MNM.EffectiveNetworkSecurityGroupAssociation>();
                CreateMap<CNM.PSEffectiveSecurityRule, MNM.EffectiveNetworkSecurityRule>();

                // MNM to CNM
                CreateMap<MNM.EffectiveNetworkSecurityGroup, CNM.PSEffectiveNetworkSecurityGroup>();
                CreateMap<MNM.EffectiveNetworkSecurityGroupAssociation, CNM.PSEffectiveNetworkSecurityGroupAssociation>();
                CreateMap<MNM.EffectiveNetworkSecurityRule, CNM.PSEffectiveSecurityRule>();

                // ExpressRouteCircuit
                // CNM to MNM
                CreateMap<CNM.PSExpressRouteCircuit, MNM.ExpressRouteCircuit>();
                CreateMap<CNM.PSServiceProviderProperties, MNM.ExpressRouteCircuitServiceProviderProperties>();
                CreateMap<CNM.PSExpressRouteCircuitSku, MNM.ExpressRouteCircuitSku>();
                CreateMap<CNM.PSPeering, MNM.ExpressRouteCircuitPeering>();
                CreateMap<CNM.PSExpressRouteCircuitAuthorization, MNM.ExpressRouteCircuitAuthorization>();

                // MNM to CNM
                CreateMap<MNM.ExpressRouteCircuit, CNM.PSExpressRouteCircuit>();
                CreateMap<MNM.ExpressRouteCircuitServiceProviderProperties, CNM.PSServiceProviderProperties>();
                CreateMap<MNM.ExpressRouteCircuitSku, CNM.PSExpressRouteCircuitSku>();
                CreateMap<MNM.ExpressRouteCircuitPeering, CNM.PSPeering>();
                CreateMap<MNM.ExpressRouteCircuitAuthorization, CNM.PSExpressRouteCircuitAuthorization>();
                CreateMap<CNM.PSExpressRouteCircuitStats, MNM.ExpressRouteCircuitStats>();
                CreateMap<CNM.PSExpressRouteCircuitArpTable, MNM.ExpressRouteCircuitArpTable>();
                CreateMap<CNM.PSExpressRouteCircuitRoutesTable, MNM.ExpressRouteCircuitRoutesTable>();
                CreateMap<CNM.PSExpressRouteCircuitRoutesTableSummary, MNM.ExpressRouteCircuitRoutesTableSummary>();

                // ExpressRouteCircuitPeering
                // CNM to MNM
                CreateMap<CNM.PSPeering, MNM.ExpressRouteCircuitPeering>();
                CreateMap<CNM.PSPeeringConfig, MNM.ExpressRouteCircuitPeeringConfig>();

                // MNM to CNM
                CreateMap<MNM.ExpressRouteCircuitPeering, CNM.PSPeering>();
                CreateMap<MNM.ExpressRouteCircuitPeeringConfig, CNM.PSPeeringConfig>();

                // ExpressRouteServiceProvider
                // CNM to MNM
                CreateMap<CNM.PSExpressRouteServiceProvider, MNM.ExpressRouteServiceProvider>();
                CreateMap<CNM.PSExpressRouteServiceProviderBandwidthsOffered, MNM.ExpressRouteServiceProviderBandwidthsOffered>();

                // MNM to CNM
                CreateMap<MNM.ExpressRouteServiceProvider, CNM.PSExpressRouteServiceProvider>();
                CreateMap<MNM.ExpressRouteServiceProviderBandwidthsOffered, CNM.PSExpressRouteServiceProviderBandwidthsOffered>();
                CreateMap<MNM.ExpressRouteCircuitStats, CNM.PSExpressRouteCircuitStats>();
                CreateMap<MNM.ExpressRouteCircuitArpTable, CNM.PSExpressRouteCircuitArpTable>();
                CreateMap<MNM.ExpressRouteCircuitRoutesTable, CNM.PSExpressRouteCircuitRoutesTable>();
                CreateMap<MNM.ExpressRouteCircuitRoutesTableSummary, CNM.PSExpressRouteCircuitRoutesTableSummary>();

                // ExoressRouteCircuitAuthorization
                // CNM to MNM
                CreateMap<CNM.PSExpressRouteCircuitAuthorization, MNM.ExpressRouteCircuitAuthorization>();

                // MNM to CNM
                CreateMap<MNM.ExpressRouteCircuitAuthorization, CNM.PSExpressRouteCircuitAuthorization>();


                // Gateways
                // CNM to MNM
                CreateMap<CNM.PSVirtualNetworkGateway, MNM.VirtualNetworkGateway>();
                CreateMap<CNM.PSConnectionResetSharedKey, MNM.ConnectionResetSharedKey>();
                CreateMap<CNM.PSConnectionSharedKey, MNM.ConnectionSharedKey>();
                CreateMap<CNM.PSLocalNetworkGateway, MNM.LocalNetworkGateway>();
                CreateMap<CNM.PSVirtualNetworkGatewayConnection, MNM.VirtualNetworkGatewayConnection>();
                CreateMap<CNM.PSIpsecPolicy, MNM.IpsecPolicy>();
                CreateMap<CNM.PSVirtualNetworkGatewayIpConfiguration, MNM.VirtualNetworkGatewayIPConfiguration>();
                CreateMap<CNM.PSTunnelConnectionHealth, MNM.TunnelConnectionHealth>();
                CreateMap<CNM.PSVirtualNetworkGatewaySku, MNM.VirtualNetworkGatewaySku>();
                CreateMap<CNM.PSVpnClientConfiguration, MNM.VpnClientConfiguration>();
                CreateMap<CNM.PSVpnClientParameters, MNM.VpnClientParameters>();
                CreateMap<CNM.PSVpnClientRevokedCertificate, MNM.VpnClientRevokedCertificate>();
                CreateMap<CNM.PSVpnClientRootCertificate, MNM.VpnClientRootCertificate>();
                CreateMap<CNM.PSBgpSettings, MNM.BgpSettings>();
                CreateMap<CNM.PSBGPPeerStatus, MNM.BgpPeerStatus>();
                CreateMap<CNM.PSGatewayRoute, MNM.GatewayRoute>();

                // MNM to CNM
                CreateMap<MNM.VirtualNetworkGateway, CNM.PSVirtualNetworkGateway>();
                CreateMap<MNM.ConnectionResetSharedKey, CNM.PSConnectionResetSharedKey>();
                CreateMap<MNM.ConnectionSharedKey, CNM.PSConnectionSharedKey>();
                CreateMap<MNM.LocalNetworkGateway, CNM.PSLocalNetworkGateway>();
                CreateMap<MNM.VirtualNetworkGatewayConnection, CNM.PSVirtualNetworkGatewayConnection>();
                CreateMap<MNM.IpsecPolicy, CNM.PSIpsecPolicy>();
                CreateMap<MNM.VirtualNetworkGatewayIPConfiguration, CNM.PSVirtualNetworkGatewayIpConfiguration>();
                CreateMap<MNM.TunnelConnectionHealth, CNM.PSTunnelConnectionHealth>();
                CreateMap<MNM.VirtualNetworkGatewaySku, CNM.PSVirtualNetworkGatewaySku>();
                CreateMap<MNM.VpnClientConfiguration, CNM.PSVpnClientConfiguration>();
                CreateMap<MNM.VpnClientParameters, CNM.PSVpnClientParameters>();
                CreateMap<MNM.VpnClientRevokedCertificate, CNM.PSVpnClientRevokedCertificate>();
                CreateMap<MNM.VpnClientRootCertificate, CNM.PSVpnClientRootCertificate>();
                CreateMap<MNM.BgpSettings, CNM.PSBgpSettings>();
                CreateMap<MNM.BgpPeerStatus, CNM.PSBGPPeerStatus>();
                CreateMap<MNM.GatewayRoute, CNM.PSGatewayRoute>();

                // Application Gateways
                // CNM to MNM
                CreateMap<CNM.PSApplicationGateway, MNM.ApplicationGateway>();
                CreateMap<CNM.PSApplicationGatewaySku, MNM.ApplicationGatewaySku>();
                CreateMap<CNM.PSApplicationGatewaySslPolicy, MNM.ApplicationGatewaySslPolicy>();
                CreateMap<CNM.PSApplicationGatewayPathRule, MNM.ApplicationGatewayPathRule>();
                CreateMap<CNM.PSApplicationGatewayUrlPathMap, MNM.ApplicationGatewayUrlPathMap>();
                CreateMap<CNM.PSApplicationGatewayProbe, MNM.ApplicationGatewayProbe>();
                CreateMap<CNM.PSApplicationGatewayBackendAddress, MNM.ApplicationGatewayBackendAddress>();
                CreateMap<CNM.PSApplicationGatewayBackendAddressPool, MNM.ApplicationGatewayBackendAddressPool>();
                CreateMap<CNM.PSApplicationGatewayBackendHttpSettings, MNM.ApplicationGatewayBackendHttpSettings>();
                CreateMap<CNM.PSApplicationGatewayFrontendIPConfiguration, MNM.ApplicationGatewayFrontendIPConfiguration>();
                CreateMap<CNM.PSApplicationGatewayFrontendPort, MNM.ApplicationGatewayFrontendPort>();
                CreateMap<CNM.PSApplicationGatewayHttpListener, MNM.ApplicationGatewayHttpListener>();
                CreateMap<CNM.PSApplicationGatewayIPConfiguration, MNM.ApplicationGatewayIPConfiguration>();
                CreateMap<CNM.PSApplicationGatewayRequestRoutingRule, MNM.ApplicationGatewayRequestRoutingRule>();
                CreateMap<CNM.PSApplicationGatewaySslCertificate, MNM.ApplicationGatewaySslCertificate>();
                CreateMap<CNM.PSApplicationGatewayAuthenticationCertificate, MNM.ApplicationGatewayAuthenticationCertificate>();
                CreateMap<CNM.PSBackendAddressPool, MNM.BackendAddressPool>();
                CreateMap<CNM.PSApplicationGatewayBackendHealth, MNM.ApplicationGatewayBackendHealth>();
                CreateMap<CNM.PSApplicationGatewayBackendHealthPool, MNM.ApplicationGatewayBackendHealthPool>();
                CreateMap<CNM.PSApplicationGatewayBackendHealthHttpSettings, MNM.ApplicationGatewayBackendHealthHttpSettings>();
                CreateMap<CNM.PSApplicationGatewayBackendHealthServer, MNM.ApplicationGatewayBackendHealthServer>();
                CreateMap<CNM.PSApplicationGatewayWebApplicationFirewallConfiguration, MNM.ApplicationGatewayWebApplicationFirewallConfiguration>();
                CreateMap<CNM.PSApplicationGatewayConnectionDraining, MNM.ApplicationGatewayConnectionDraining>();
                CreateMap<CNM.PSApplicationGatewayFirewallDisabledRuleGroup, MNM.ApplicationGatewayFirewallDisabledRuleGroup>()
                    .AfterMap((src, dest) => dest.Rules = (src.Rules == null) ? null : dest.Rules);
                CreateMap<CNM.PSApplicationGatewayAvailableWafRuleSetsResult, MNM.ApplicationGatewayAvailableWafRuleSetsResult>();
                CreateMap<CNM.PSApplicationGatewayFirewallRule, MNM.ApplicationGatewayFirewallRule>();
                CreateMap<CNM.PSApplicationGatewayFirewallRuleGroup, MNM.ApplicationGatewayFirewallRuleGroup>();
                CreateMap<CNM.PSApplicationGatewayFirewallRuleSet, MNM.ApplicationGatewayFirewallRuleSet>();

                // MNM to CNM
                CreateMap<MNM.ApplicationGateway, CNM.PSApplicationGateway>();
                CreateMap<MNM.ApplicationGatewaySku, CNM.PSApplicationGatewaySku>();
                CreateMap<MNM.ApplicationGatewaySslPolicy, CNM.PSApplicationGatewaySslPolicy>();
                CreateMap<MNM.ApplicationGatewayPathRule, CNM.PSApplicationGatewayPathRule>();
                CreateMap<MNM.ApplicationGatewayUrlPathMap, CNM.PSApplicationGatewayUrlPathMap>();
                CreateMap<MNM.ApplicationGatewayProbe, CNM.PSApplicationGatewayProbe>();
                CreateMap<MNM.ApplicationGatewayBackendAddress, CNM.PSApplicationGatewayBackendAddress>();
                CreateMap<MNM.ApplicationGatewayBackendAddressPool, CNM.PSApplicationGatewayBackendAddressPool>();
                CreateMap<MNM.ApplicationGatewayBackendHttpSettings, CNM.PSApplicationGatewayBackendHttpSettings>();
                CreateMap<MNM.ApplicationGatewayFrontendIPConfiguration, CNM.PSApplicationGatewayFrontendIPConfiguration>();
                CreateMap<MNM.ApplicationGatewayFrontendPort, CNM.PSApplicationGatewayFrontendPort>();
                CreateMap<MNM.ApplicationGatewayHttpListener, CNM.PSApplicationGatewayHttpListener>();
                CreateMap<MNM.ApplicationGatewayIPConfiguration, CNM.PSApplicationGatewayIPConfiguration>();
                CreateMap<MNM.ApplicationGatewayRequestRoutingRule, CNM.PSApplicationGatewayRequestRoutingRule>();
                CreateMap<MNM.ApplicationGatewaySslCertificate, CNM.PSApplicationGatewaySslCertificate>();
                CreateMap<MNM.ApplicationGatewayAuthenticationCertificate, CNM.PSApplicationGatewayAuthenticationCertificate>();
                CreateMap<MNM.BackendAddressPool, CNM.PSBackendAddressPool>();
                CreateMap<MNM.ApplicationGatewayBackendHealth, CNM.PSApplicationGatewayBackendHealth>();
                CreateMap<MNM.ApplicationGatewayBackendHealthPool, CNM.PSApplicationGatewayBackendHealthPool>();
                CreateMap<MNM.ApplicationGatewayBackendHealthHttpSettings, CNM.PSApplicationGatewayBackendHealthHttpSettings>();
                CreateMap<MNM.ApplicationGatewayBackendHealthServer, CNM.PSApplicationGatewayBackendHealthServer>();
                CreateMap<MNM.ApplicationGatewayWebApplicationFirewallConfiguration, CNM.PSApplicationGatewayWebApplicationFirewallConfiguration>();
                CreateMap<MNM.ApplicationGatewayConnectionDraining, CNM.PSApplicationGatewayConnectionDraining>();
                CreateMap<MNM.ApplicationGatewayFirewallDisabledRuleGroup, CNM.PSApplicationGatewayFirewallDisabledRuleGroup>()
                    .AfterMap((src, dest) => dest.Rules = (src.Rules == null) ? null : dest.Rules);
                CreateMap<MNM.ApplicationGatewayAvailableWafRuleSetsResult, CNM.PSApplicationGatewayAvailableWafRuleSetsResult>();
                CreateMap<MNM.ApplicationGatewayFirewallRule, CNM.PSApplicationGatewayFirewallRule>();
                CreateMap<MNM.ApplicationGatewayFirewallRuleGroup, CNM.PSApplicationGatewayFirewallRuleGroup>();
                CreateMap<MNM.ApplicationGatewayFirewallRuleSet, CNM.PSApplicationGatewayFirewallRuleSet>();

                return true;
            });
        }

        public override string ProfileName
        {
            get { return "NetworkResourceManagerProfile"; }
        }

        public bool Initialize()
        {
            return initialize.Value;
        }
}
}