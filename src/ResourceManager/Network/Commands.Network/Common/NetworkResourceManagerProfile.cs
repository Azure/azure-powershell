﻿// ----------------------------------------------------------------------------------
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

    public static class NetworkManagementMapperExtension
    {
        public static IMappingExpression<TSource, TDestination> ForItems<TSource, TDestination, T>(
                 this IMappingExpression<TSource, TDestination> mapper)
            where TSource : IEnumerable
            where TDestination : ICollection<T>
        {
            mapper.AfterMap((c, s) =>
            {
                if (c != null && s != null)
                {
                    foreach (var t in c)
                    {
                        s.Add(Mapper.Map<T>(t));
                    }
                }
            });

            return mapper;
        }
    }

    public class NetworkResourceManagerProfile : Profile
    {
        private static readonly Lazy<bool> initialize;

        static NetworkResourceManagerProfile()
        {
            initialize = new Lazy<bool>(() =>
            {
                Mapper.AddProfile<NetworkResourceManagerProfile>();
                return true;
            });
        }

        public override string ProfileName
        {
            get { return "NetworkResourceManagerProfile"; }
        }

        public static bool Initialize()
        {
            return initialize.Value;
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CNM.PSResourceId, MNM.SubResource>();
            Mapper.CreateMap<MNM.SubResource, CNM.PSResourceId>();

            // Route Filter 
            Mapper.CreateMap<CNM.PSRouteFilter, MNM.RouteFilter>();
            Mapper.CreateMap<MNM.RouteFilter, CNM.PSRouteFilter>();
            Mapper.CreateMap<CNM.PSRouteFilterRule, MNM.RouteFilterRule>();
            Mapper.CreateMap<MNM.RouteFilterRule, CNM.PSRouteFilterRule>();

            // Bgp Service Community
            Mapper.CreateMap<CNM.PSBgpServiceCommunity, MNM.BgpServiceCommunity>();
            Mapper.CreateMap<CNM.PSBgpCommunity, MNM.BGPCommunity>();
            Mapper.CreateMap<MNM.BgpServiceCommunity, CNM.PSBgpServiceCommunity>();
            Mapper.CreateMap<MNM.BGPCommunity, CNM.PSBgpCommunity>();

            // Subnet
            // CNM to MNM
            Mapper.CreateMap<CNM.PSDhcpOptions, MNM.DhcpOptions>();
            Mapper.CreateMap<CNM.PSSubnet, MNM.Subnet>();
            Mapper.CreateMap<CNM.PSIPConfiguration, MNM.IPConfiguration>();
            Mapper.CreateMap<CNM.PSResourceNavigationLink, MNM.ResourceNavigationLink>();

            // MNM to CNM
            Mapper.CreateMap<MNM.DhcpOptions, CNM.PSDhcpOptions>();
            Mapper.CreateMap<MNM.Subnet, CNM.PSSubnet>();
            Mapper.CreateMap<MNM.IPConfiguration, CNM.PSIPConfiguration>();
            Mapper.CreateMap<MNM.ResourceNavigationLink, CNM.PSResourceNavigationLink>();

            // TestPrivateIpAddressAvailability
            // CNM to MNM
            Mapper.CreateMap<CNM.PSIPAddressAvailabilityResult, MNM.IPAddressAvailabilityResult>();

            // MNM to CNM
            Mapper.CreateMap<MNM.IPAddressAvailabilityResult, CNM.PSIPAddressAvailabilityResult>();

            // VirtualNetwork Peering
            Mapper.CreateMap<CNM.PSVirtualNetworkPeering, MNM.VirtualNetworkPeering>();

            Mapper.CreateMap<MNM.VirtualNetworkPeering, CNM.PSVirtualNetworkPeering>();

            // VirtualNetwork
            // CNM to MNM
            Mapper.CreateMap<CNM.PSAddressSpace, MNM.AddressSpace>();
            Mapper.CreateMap<CNM.PSVirtualNetwork, MNM.VirtualNetwork>();

            // MNM to CNM
            Mapper.CreateMap<MNM.AddressSpace, CNM.PSAddressSpace>();
            Mapper.CreateMap<MNM.VirtualNetwork, CNM.PSVirtualNetwork>();

            // PublicIpAddress
            // CNM to MNM
            Mapper.CreateMap<CNM.PSPublicIpAddress, MNM.PublicIPAddress>();
            Mapper.CreateMap<CNM.PSPublicIpAddressDnsSettings, MNM.PublicIPAddressDnsSettings>();

            // MNM to CNM
            Mapper.CreateMap<MNM.PublicIPAddress, CNM.PSPublicIpAddress>();
            Mapper.CreateMap<MNM.PublicIPAddressDnsSettings, CNM.PSPublicIpAddressDnsSettings>();

            // NetworkInterface
            // CNM to MNM
            Mapper.CreateMap<CNM.PSNetworkInterface, MNM.NetworkInterface>();
            Mapper.CreateMap<CNM.PSNetworkInterfaceDnsSettings, MNM.NetworkInterfaceDnsSettings>();
            Mapper.CreateMap<CNM.PSNetworkInterfaceIPConfiguration, MNM.NetworkInterfaceIPConfiguration>();

            // MNM to CNM
            Mapper.CreateMap<MNM.NetworkInterface, CNM.PSNetworkInterface>();
            Mapper.CreateMap<MNM.NetworkInterfaceDnsSettings, CNM.PSNetworkInterfaceDnsSettings>();
            Mapper.CreateMap<MNM.NetworkInterfaceIPConfiguration, CNM.PSNetworkInterfaceIPConfiguration>();

            // NetworkWatcher
            // CNM to MNM
            Mapper.CreateMap<CNM.PSNetworkWatcher, MNM.NetworkWatcher>();

            // MNM to CNM
            Mapper.CreateMap<MNM.NetworkWatcher, CNM.PSNetworkWatcher>();

            // PacketCapture
            // CNM to MNM
            Mapper.CreateMap<CNM.PSPacketCapture, MNM.PacketCaptureParameters>();
            Mapper.CreateMap<CNM.PSPacketCaptureResult, MNM.PacketCaptureResult>();
            Mapper.CreateMap<CNM.PSStorageLocation, MNM.PacketCaptureStorageLocation>();
            Mapper.CreateMap<CNM.PSPacketCaptureFilter, MNM.PacketCaptureFilter>();
            Mapper.CreateMap<CNM.PSPacketCaptureStatus, MNM.PacketCaptureQueryStatusResult>();

            // MNM to CNM
            Mapper.CreateMap<MNM.PacketCaptureParameters, CNM.PSPacketCapture>();
            Mapper.CreateMap<MNM.PacketCaptureResult, CNM.PSPacketCaptureResult>();
            Mapper.CreateMap<MNM.PacketCaptureStorageLocation, CNM.PSStorageLocation>();
            Mapper.CreateMap<MNM.PacketCaptureFilter, CNM.PSPacketCaptureFilter>();
            Mapper.CreateMap<MNM.PacketCaptureQueryStatusResult, CNM.PSPacketCaptureStatus>();

            // Topology
            // CNM to MNM
            Mapper.CreateMap<CNM.PSTopology, MNM.Topology>();
            Mapper.CreateMap<CNM.PSTopologyResource, MNM.TopologyResource>();
            Mapper.CreateMap<CNM.PSTopologyAssociation, MNM.TopologyAssociation>();

            // MNM to CNM
            Mapper.CreateMap<MNM.Topology, CNM.PSTopology>();
            Mapper.CreateMap<MNM.TopologyResource, CNM.PSTopologyResource>();
            Mapper.CreateMap<MNM.TopologyAssociation, CNM.PSTopologyAssociation>();

            // ViewNsgRules
            // CNM to MNM
            Mapper.CreateMap<CNM.PSSecurityGroupNetworkInterface, MNM.SecurityGroupNetworkInterface>();
            Mapper.CreateMap<CNM.PSSecurityRuleAssociations, MNM.SecurityRuleAssociations>();
            Mapper.CreateMap<CNM.PSNetworkInterfaceAssociation, MNM.NetworkInterfaceAssociation>();
            Mapper.CreateMap<CNM.PSSubnetAssociation, MNM.SubnetAssociation>();

            // MNM to CNM
            Mapper.CreateMap<MNM.SecurityGroupNetworkInterface, CNM.PSSecurityGroupNetworkInterface>();
            Mapper.CreateMap<MNM.SecurityRuleAssociations, CNM.PSSecurityRuleAssociations>();
            Mapper.CreateMap<MNM.NetworkInterfaceAssociation, CNM.PSNetworkInterfaceAssociation>();
            Mapper.CreateMap<MNM.SubnetAssociation, CNM.PSSubnetAssociation>();

            // IpFlowVerify
            // CNM to MNM
            Mapper.CreateMap<CNM.PSIPFlowVerifyResult, MNM.VerificationIPFlowResult>();

            // MNM to CNM
            Mapper.CreateMap<MNM.VerificationIPFlowResult, CNM.PSIPFlowVerifyResult>();

            // NextHop
            // CNM to MNM
            Mapper.CreateMap<CNM.PSNextHopResult, MNM.NextHopResult>();

            // MNM to CNM
            Mapper.CreateMap<MNM.NextHopResult, CNM.PSNextHopResult>();

            // Troubleshoot
            // CNM to MNM
            Mapper.CreateMap<CNM.PSTroubleshootResult, MNM.TroubleshootingResult>();
            Mapper.CreateMap<CNM.PSTroubleshootDetails, MNM.TroubleshootingDetails>();
            Mapper.CreateMap<CNM.PSTroubleshootRecommendedActions, MNM.TroubleshootingRecommendedActions>();

            // MNM to CNM
            Mapper.CreateMap<MNM.TroubleshootingResult, CNM.PSTroubleshootResult>();
            Mapper.CreateMap<MNM.TroubleshootingDetails, CNM.PSTroubleshootDetails>();
            Mapper.CreateMap<MNM.TroubleshootingRecommendedActions, CNM.PSTroubleshootRecommendedActions>();

            // FlowLog
            // CNM to MNM
            Mapper.CreateMap<CNM.PSFlowLog, MNM.FlowLogInformation>();
            Mapper.CreateMap<CNM.PSRetentionPolicyParameters, MNM.RetentionPolicyParameters>();

            // MNM to CNM
            Mapper.CreateMap<MNM.FlowLogInformation, CNM.PSFlowLog>();
            Mapper.CreateMap<MNM.RetentionPolicyParameters, CNM.PSRetentionPolicyParameters>();

            // CheckConnectivity
            // CNM to MNM
            Mapper.CreateMap<CNM.PSConnectivityInformation, MNM.ConnectivityInformation>();
            Mapper.CreateMap<CNM.PSConnectivityHop, MNM.ConnectivityHop>();
            Mapper.CreateMap<CNM.PSConnectivityIssue, MNM.ConnectivityIssue>();

            // MNM to CNM
            Mapper.CreateMap<MNM.ConnectivityInformation, CNM.PSConnectivityInformation>();
            Mapper.CreateMap<MNM.ConnectivityHop, CNM.PSConnectivityHop>();
            Mapper.CreateMap<MNM.ConnectivityIssue, CNM.PSConnectivityIssue>();

            // LoadBalancer
            // CNM to MNM
            Mapper.CreateMap<CNM.PSLoadBalancer, MNM.LoadBalancer>();

            // MNM to CNM
            Mapper.CreateMap<MNM.LoadBalancer, CNM.PSLoadBalancer>();

            // FrontendIpConfiguration
            // CNM to MNM
            Mapper.CreateMap<CNM.PSFrontendIPConfiguration, MNM.FrontendIPConfiguration>();

            // MNM to CNM
            Mapper.CreateMap<MNM.FrontendIPConfiguration, CNM.PSFrontendIPConfiguration>();

            // BackendAddressPool
            // CNM to MNM
            Mapper.CreateMap<CNM.PSBackendAddressPool, MNM.BackendAddressPool>();

            // MNM to CNM
            Mapper.CreateMap<MNM.BackendAddressPool, CNM.PSBackendAddressPool>();

            // LoadBalancingRule
            // CNM to MNM
            Mapper.CreateMap<CNM.PSLoadBalancingRule, MNM.LoadBalancingRule>();

            // MNM to CNM
            Mapper.CreateMap<MNM.LoadBalancingRule, CNM.PSLoadBalancingRule>();

            // Probes
            // CNM to MNM
            Mapper.CreateMap<CNM.PSProbe, MNM.Probe>();

            // MNM to CNM
            Mapper.CreateMap<MNM.Probe, CNM.PSProbe>();

            // InboundNatRules
            // CNM to MNM
            Mapper.CreateMap<CNM.PSInboundNatRule, MNM.InboundNatRule>();

            // MNM to CNM
            Mapper.CreateMap<MNM.InboundNatRule, CNM.PSInboundNatRule>();

            // InboundNatPools
            // CNM to MNM
            Mapper.CreateMap<CNM.PSInboundNatPool, MNM.InboundNatPool>();

            // MNM to CNM
            Mapper.CreateMap<MNM.InboundNatPool, CNM.PSInboundNatPool>();

            // NetworkSecurityGroups
            // CNM to MNM
            Mapper.CreateMap<CNM.PSNetworkSecurityGroup, MNM.NetworkSecurityGroup>();

            // MNM to CNM
            Mapper.CreateMap<MNM.NetworkSecurityGroup, CNM.PSNetworkSecurityGroup>();

            // NetworkSecrityRule
            // CNM to MNM
            Mapper.CreateMap<CNM.PSSecurityRule, MNM.SecurityRule>();

            // MNM to CNM
            Mapper.CreateMap<MNM.SecurityRule, CNM.PSSecurityRule>();

            // RouteTable
            // CNM to MNM
            Mapper.CreateMap<CNM.PSRouteTable, MNM.RouteTable>();

            // MNM to CNM
            Mapper.CreateMap<MNM.RouteTable, CNM.PSRouteTable>();

            // Route
            // CNM to MNM
            Mapper.CreateMap<CNM.PSRoute, MNM.Route>();

            // MNM to CNM
            Mapper.CreateMap<MNM.Route, CNM.PSRoute>();

            // EffectiveRouteTable
            // CNM to MNM
            Mapper.CreateMap<CNM.PSEffectiveRoute, MNM.EffectiveRoute>();

            // MNM to CNM
            Mapper.CreateMap<MNM.EffectiveRoute, CNM.PSEffectiveRoute>();

            // EffectiveNetworkSecurityGroup
            // CNM to MNM
            Mapper.CreateMap<CNM.PSEffectiveNetworkSecurityGroup, MNM.EffectiveNetworkSecurityGroup>();
            Mapper.CreateMap<CNM.PSEffectiveNetworkSecurityGroupAssociation, MNM.EffectiveNetworkSecurityGroupAssociation>();
            Mapper.CreateMap<CNM.PSEffectiveSecurityRule, MNM.EffectiveNetworkSecurityRule>();

            // MNM to CNM
            Mapper.CreateMap<MNM.EffectiveNetworkSecurityGroup, CNM.PSEffectiveNetworkSecurityGroup>();
            Mapper.CreateMap<MNM.EffectiveNetworkSecurityGroupAssociation, CNM.PSEffectiveNetworkSecurityGroupAssociation>();
            Mapper.CreateMap<MNM.EffectiveNetworkSecurityRule, CNM.PSEffectiveSecurityRule>();

            // ExpressRouteCircuit
            // CNM to MNM
            Mapper.CreateMap<CNM.PSExpressRouteCircuit, MNM.ExpressRouteCircuit>();
            Mapper.CreateMap<CNM.PSServiceProviderProperties, MNM.ExpressRouteCircuitServiceProviderProperties>();
            Mapper.CreateMap<CNM.PSExpressRouteCircuitSku, MNM.ExpressRouteCircuitSku>();
            Mapper.CreateMap<CNM.PSPeering, MNM.ExpressRouteCircuitPeering>();
            Mapper.CreateMap<CNM.PSExpressRouteCircuitAuthorization, MNM.ExpressRouteCircuitAuthorization>();

            // MNM to CNM
            Mapper.CreateMap<MNM.ExpressRouteCircuit, CNM.PSExpressRouteCircuit>();
            Mapper.CreateMap<MNM.ExpressRouteCircuitServiceProviderProperties, CNM.PSServiceProviderProperties>();
            Mapper.CreateMap<MNM.ExpressRouteCircuitSku, CNM.PSExpressRouteCircuitSku>();
            Mapper.CreateMap<MNM.ExpressRouteCircuitPeering, CNM.PSPeering>();
            Mapper.CreateMap<MNM.ExpressRouteCircuitAuthorization, CNM.PSExpressRouteCircuitAuthorization>();
            Mapper.CreateMap<CNM.PSExpressRouteCircuitStats, MNM.ExpressRouteCircuitStats>();
            Mapper.CreateMap<CNM.PSExpressRouteCircuitArpTable, MNM.ExpressRouteCircuitArpTable>();
            Mapper.CreateMap<CNM.PSExpressRouteCircuitRoutesTable, MNM.ExpressRouteCircuitRoutesTable>();
            Mapper.CreateMap<CNM.PSExpressRouteCircuitRoutesTableSummary, MNM.ExpressRouteCircuitRoutesTableSummary>();

            // ExpressRouteCircuitPeering
            // CNM to MNM
            Mapper.CreateMap<CNM.PSPeering, MNM.ExpressRouteCircuitPeering>();
            Mapper.CreateMap<CNM.PSPeeringConfig, MNM.ExpressRouteCircuitPeeringConfig>();

            // MNM to CNM
            Mapper.CreateMap<MNM.ExpressRouteCircuitPeering, CNM.PSPeering>();
            Mapper.CreateMap<MNM.ExpressRouteCircuitPeeringConfig, CNM.PSPeeringConfig>();

            // ExpressRouteServiceProvider
            // CNM to MNM
            Mapper.CreateMap<CNM.PSExpressRouteServiceProvider, MNM.ExpressRouteServiceProvider>();
            Mapper.CreateMap<CNM.PSExpressRouteServiceProviderBandwidthsOffered, MNM.ExpressRouteServiceProviderBandwidthsOffered>();

            // MNM to CNM
            Mapper.CreateMap<MNM.ExpressRouteServiceProvider, CNM.PSExpressRouteServiceProvider>();
            Mapper.CreateMap<MNM.ExpressRouteServiceProviderBandwidthsOffered, CNM.PSExpressRouteServiceProviderBandwidthsOffered>();
            Mapper.CreateMap<MNM.ExpressRouteCircuitStats, CNM.PSExpressRouteCircuitStats>();
            Mapper.CreateMap<MNM.ExpressRouteCircuitArpTable, CNM.PSExpressRouteCircuitArpTable>();
            Mapper.CreateMap<MNM.ExpressRouteCircuitRoutesTable, CNM.PSExpressRouteCircuitRoutesTable>();
            Mapper.CreateMap<MNM.ExpressRouteCircuitRoutesTableSummary, CNM.PSExpressRouteCircuitRoutesTableSummary>();

            // ExoressRouteCircuitAuthorization
            // CNM to MNM
            Mapper.CreateMap<CNM.PSExpressRouteCircuitAuthorization, MNM.ExpressRouteCircuitAuthorization>();

            // MNM to CNM
            Mapper.CreateMap<MNM.ExpressRouteCircuitAuthorization, CNM.PSExpressRouteCircuitAuthorization>();


            // Gateways
            // CNM to MNM
            Mapper.CreateMap<CNM.PSVirtualNetworkGateway, MNM.VirtualNetworkGateway>();
            Mapper.CreateMap<CNM.PSConnectionResetSharedKey, MNM.ConnectionResetSharedKey>();
            Mapper.CreateMap<CNM.PSConnectionSharedKey, MNM.ConnectionSharedKey>();
            Mapper.CreateMap<CNM.PSLocalNetworkGateway, MNM.LocalNetworkGateway>();
            Mapper.CreateMap<CNM.PSVirtualNetworkGatewayConnection, MNM.VirtualNetworkGatewayConnection>();
            Mapper.CreateMap<CNM.PSIpsecPolicy, MNM.IpsecPolicy>();
            Mapper.CreateMap<CNM.PSVirtualNetworkGatewayIpConfiguration, MNM.VirtualNetworkGatewayIPConfiguration>();
            Mapper.CreateMap<CNM.PSTunnelConnectionHealth, MNM.TunnelConnectionHealth>();
            Mapper.CreateMap<CNM.PSVirtualNetworkGatewaySku, MNM.VirtualNetworkGatewaySku>();
            Mapper.CreateMap<CNM.PSVpnClientConfiguration, MNM.VpnClientConfiguration>();
            Mapper.CreateMap<CNM.PSVpnClientParameters, MNM.VpnClientParameters>();
            Mapper.CreateMap<CNM.PSVpnClientRevokedCertificate, MNM.VpnClientRevokedCertificate>();
            Mapper.CreateMap<CNM.PSVpnClientRootCertificate, MNM.VpnClientRootCertificate>();
            Mapper.CreateMap<CNM.PSBgpSettings, MNM.BgpSettings>();
            Mapper.CreateMap<CNM.PSBGPPeerStatus, MNM.BgpPeerStatus>();
            Mapper.CreateMap<CNM.PSGatewayRoute, MNM.GatewayRoute>();

            // MNM to CNM
            Mapper.CreateMap<MNM.VirtualNetworkGateway, CNM.PSVirtualNetworkGateway>();
            Mapper.CreateMap<MNM.ConnectionResetSharedKey, CNM.PSConnectionResetSharedKey>();
            Mapper.CreateMap<MNM.ConnectionSharedKey, CNM.PSConnectionSharedKey>();
            Mapper.CreateMap<MNM.LocalNetworkGateway, CNM.PSLocalNetworkGateway>();
            Mapper.CreateMap<MNM.VirtualNetworkGatewayConnection, CNM.PSVirtualNetworkGatewayConnection>();
            Mapper.CreateMap<MNM.IpsecPolicy, CNM.PSIpsecPolicy>();
            Mapper.CreateMap<MNM.VirtualNetworkGatewayIPConfiguration, CNM.PSVirtualNetworkGatewayIpConfiguration>();
            Mapper.CreateMap<MNM.TunnelConnectionHealth, CNM.PSTunnelConnectionHealth>();
            Mapper.CreateMap<MNM.VirtualNetworkGatewaySku, CNM.PSVirtualNetworkGatewaySku>();
            Mapper.CreateMap<MNM.VpnClientConfiguration, CNM.PSVpnClientConfiguration>();
            Mapper.CreateMap<MNM.VpnClientParameters, CNM.PSVpnClientParameters>();
            Mapper.CreateMap<MNM.VpnClientRevokedCertificate, CNM.PSVpnClientRevokedCertificate>();
            Mapper.CreateMap<MNM.VpnClientRootCertificate, CNM.PSVpnClientRootCertificate>();
            Mapper.CreateMap<MNM.BgpSettings, CNM.PSBgpSettings>();
            Mapper.CreateMap<MNM.BgpPeerStatus, CNM.PSBGPPeerStatus>();
            Mapper.CreateMap<MNM.GatewayRoute, CNM.PSGatewayRoute>();

            // Application Gateways
            // CNM to MNM
            Mapper.CreateMap<CNM.PSApplicationGateway, MNM.ApplicationGateway>();
            Mapper.CreateMap<CNM.PSApplicationGatewaySku, MNM.ApplicationGatewaySku>();
            Mapper.CreateMap<CNM.PSApplicationGatewaySslPolicy, MNM.ApplicationGatewaySslPolicy>();
            Mapper.CreateMap<CNM.PSApplicationGatewayPathRule, MNM.ApplicationGatewayPathRule>();
            Mapper.CreateMap<CNM.PSApplicationGatewayUrlPathMap, MNM.ApplicationGatewayUrlPathMap>();
            Mapper.CreateMap<CNM.PSApplicationGatewayProbe, MNM.ApplicationGatewayProbe>();
            Mapper.CreateMap<CNM.PSApplicationGatewayBackendAddress, MNM.ApplicationGatewayBackendAddress>();
            Mapper.CreateMap<CNM.PSApplicationGatewayBackendAddressPool, MNM.ApplicationGatewayBackendAddressPool>();
            Mapper.CreateMap<CNM.PSApplicationGatewayBackendHttpSettings, MNM.ApplicationGatewayBackendHttpSettings>();
            Mapper.CreateMap<CNM.PSApplicationGatewayFrontendIPConfiguration, MNM.ApplicationGatewayFrontendIPConfiguration>();
            Mapper.CreateMap<CNM.PSApplicationGatewayFrontendPort, MNM.ApplicationGatewayFrontendPort>();
            Mapper.CreateMap<CNM.PSApplicationGatewayHttpListener, MNM.ApplicationGatewayHttpListener>();
            Mapper.CreateMap<CNM.PSApplicationGatewayIPConfiguration, MNM.ApplicationGatewayIPConfiguration>();
            Mapper.CreateMap<CNM.PSApplicationGatewayRequestRoutingRule, MNM.ApplicationGatewayRequestRoutingRule>();
            Mapper.CreateMap<CNM.PSApplicationGatewaySslCertificate, MNM.ApplicationGatewaySslCertificate>();
            Mapper.CreateMap<CNM.PSApplicationGatewayAuthenticationCertificate, MNM.ApplicationGatewayAuthenticationCertificate>();
            Mapper.CreateMap<CNM.PSBackendAddressPool, MNM.BackendAddressPool>();
            Mapper.CreateMap<CNM.PSApplicationGatewayBackendHealth, MNM.ApplicationGatewayBackendHealth>();
            Mapper.CreateMap<CNM.PSApplicationGatewayBackendHealthPool, MNM.ApplicationGatewayBackendHealthPool>();
            Mapper.CreateMap<CNM.PSApplicationGatewayBackendHealthHttpSettings, MNM.ApplicationGatewayBackendHealthHttpSettings>();
            Mapper.CreateMap<CNM.PSApplicationGatewayBackendHealthServer, MNM.ApplicationGatewayBackendHealthServer>();
            Mapper.CreateMap<CNM.PSApplicationGatewayWebApplicationFirewallConfiguration, MNM.ApplicationGatewayWebApplicationFirewallConfiguration>();
            Mapper.CreateMap<CNM.PSApplicationGatewayConnectionDraining, MNM.ApplicationGatewayConnectionDraining>();
            Mapper.CreateMap<CNM.PSApplicationGatewayFirewallDisabledRuleGroup, MNM.ApplicationGatewayFirewallDisabledRuleGroup>()
                .AfterMap((src, dest) => dest.Rules = (src.Rules == null) ? null : dest.Rules);
            Mapper.CreateMap<CNM.PSApplicationGatewayAvailableWafRuleSetsResult, MNM.ApplicationGatewayAvailableWafRuleSetsResult>();
            Mapper.CreateMap<CNM.PSApplicationGatewayFirewallRule, MNM.ApplicationGatewayFirewallRule>();
            Mapper.CreateMap<CNM.PSApplicationGatewayFirewallRuleGroup, MNM.ApplicationGatewayFirewallRuleGroup>();
            Mapper.CreateMap<CNM.PSApplicationGatewayFirewallRuleSet, MNM.ApplicationGatewayFirewallRuleSet>();

            // MNM to CNM
            Mapper.CreateMap<MNM.ApplicationGateway, CNM.PSApplicationGateway>();
            Mapper.CreateMap<MNM.ApplicationGatewaySku, CNM.PSApplicationGatewaySku>();
            Mapper.CreateMap<MNM.ApplicationGatewaySslPolicy, CNM.PSApplicationGatewaySslPolicy>();
            Mapper.CreateMap<MNM.ApplicationGatewayPathRule, CNM.PSApplicationGatewayPathRule>();
            Mapper.CreateMap<MNM.ApplicationGatewayUrlPathMap, CNM.PSApplicationGatewayUrlPathMap>();
            Mapper.CreateMap<MNM.ApplicationGatewayProbe, CNM.PSApplicationGatewayProbe>();
            Mapper.CreateMap<MNM.ApplicationGatewayBackendAddress, CNM.PSApplicationGatewayBackendAddress>();
            Mapper.CreateMap<MNM.ApplicationGatewayBackendAddressPool, CNM.PSApplicationGatewayBackendAddressPool>();
            Mapper.CreateMap<MNM.ApplicationGatewayBackendHttpSettings, CNM.PSApplicationGatewayBackendHttpSettings>();
            Mapper.CreateMap<MNM.ApplicationGatewayFrontendIPConfiguration, CNM.PSApplicationGatewayFrontendIPConfiguration>();
            Mapper.CreateMap<MNM.ApplicationGatewayFrontendPort, CNM.PSApplicationGatewayFrontendPort>();
            Mapper.CreateMap<MNM.ApplicationGatewayHttpListener, CNM.PSApplicationGatewayHttpListener>();
            Mapper.CreateMap<MNM.ApplicationGatewayIPConfiguration, CNM.PSApplicationGatewayIPConfiguration>();
            Mapper.CreateMap<MNM.ApplicationGatewayRequestRoutingRule, CNM.PSApplicationGatewayRequestRoutingRule>();
            Mapper.CreateMap<MNM.ApplicationGatewaySslCertificate, CNM.PSApplicationGatewaySslCertificate>();
            Mapper.CreateMap<MNM.ApplicationGatewayAuthenticationCertificate, CNM.PSApplicationGatewayAuthenticationCertificate>();
            Mapper.CreateMap<MNM.BackendAddressPool, CNM.PSBackendAddressPool>();
            Mapper.CreateMap<MNM.ApplicationGatewayBackendHealth, CNM.PSApplicationGatewayBackendHealth>();
            Mapper.CreateMap<MNM.ApplicationGatewayBackendHealthPool, CNM.PSApplicationGatewayBackendHealthPool>();
            Mapper.CreateMap<MNM.ApplicationGatewayBackendHealthHttpSettings, CNM.PSApplicationGatewayBackendHealthHttpSettings>();
            Mapper.CreateMap<MNM.ApplicationGatewayBackendHealthServer, CNM.PSApplicationGatewayBackendHealthServer>();
            Mapper.CreateMap<MNM.ApplicationGatewayWebApplicationFirewallConfiguration, CNM.PSApplicationGatewayWebApplicationFirewallConfiguration>();
            Mapper.CreateMap<MNM.ApplicationGatewayConnectionDraining, CNM.PSApplicationGatewayConnectionDraining>();
            Mapper.CreateMap<MNM.ApplicationGatewayFirewallDisabledRuleGroup, CNM.PSApplicationGatewayFirewallDisabledRuleGroup>()
                .AfterMap((src, dest) => dest.Rules = (src.Rules == null) ? null : dest.Rules);
            Mapper.CreateMap<MNM.ApplicationGatewayAvailableWafRuleSetsResult, CNM.PSApplicationGatewayAvailableWafRuleSetsResult>();
            Mapper.CreateMap<MNM.ApplicationGatewayFirewallRule, CNM.PSApplicationGatewayFirewallRule>();
            Mapper.CreateMap<MNM.ApplicationGatewayFirewallRuleGroup, CNM.PSApplicationGatewayFirewallRuleGroup>();
            Mapper.CreateMap<MNM.ApplicationGatewayFirewallRuleSet, CNM.PSApplicationGatewayFirewallRuleSet>();
        }
}
}