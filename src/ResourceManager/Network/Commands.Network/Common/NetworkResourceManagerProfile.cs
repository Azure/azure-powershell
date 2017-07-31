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
        public override string ProfileName
        {
            get { return "NetworkResourceManagerProfile"; }
        }

        public static void Initialize()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<NetworkResourceManagerProfile>();
                cfg.CreateMap<CNM.PSResourceId, MNM.SubResource>();
                cfg.CreateMap<MNM.SubResource, CNM.PSResourceId>();

                // Route Filter 
                cfg.CreateMap<CNM.PSRouteFilter, MNM.RouteFilter>();
                cfg.CreateMap<MNM.RouteFilter, CNM.PSRouteFilter>();
                cfg.CreateMap<CNM.PSRouteFilterRule, MNM.RouteFilterRule>();
                cfg.CreateMap<MNM.RouteFilterRule, CNM.PSRouteFilterRule>();

                // Bgp Service Community
                cfg.CreateMap<CNM.PSBgpServiceCommunity, MNM.BgpServiceCommunity>();
                cfg.CreateMap<CNM.PSBgpCommunity, MNM.BGPCommunity>();
                cfg.CreateMap<MNM.BgpServiceCommunity, CNM.PSBgpServiceCommunity>();
                cfg.CreateMap<MNM.BGPCommunity, CNM.PSBgpCommunity>();

                // Subnet
                // CNM to MNM
                cfg.CreateMap<CNM.PSDhcpOptions, MNM.DhcpOptions>();
                cfg.CreateMap<CNM.PSSubnet, MNM.Subnet>();
                cfg.CreateMap<CNM.PSIPConfiguration, MNM.IPConfiguration>();
                cfg.CreateMap<CNM.PSResourceNavigationLink, MNM.ResourceNavigationLink>();
                cfg.CreateMap<CNM.PSPrivateAccessService, MNM.PrivateAccessServicePropertiesFormat>();

                // MNM to CNM
                cfg.CreateMap<MNM.DhcpOptions, CNM.PSDhcpOptions>();
                cfg.CreateMap<MNM.Subnet, CNM.PSSubnet>();
                cfg.CreateMap<MNM.IPConfiguration, CNM.PSIPConfiguration>();
                cfg.CreateMap<MNM.ResourceNavigationLink, CNM.PSResourceNavigationLink>();
                cfg.CreateMap<MNM.PrivateAccessServicePropertiesFormat, CNM.PSPrivateAccessService>();

                // TestPrivateIpAddressAvailability
                // CNM to MNM
                cfg.CreateMap<CNM.PSIPAddressAvailabilityResult, MNM.IPAddressAvailabilityResult>();

                // MNM to CNM
                cfg.CreateMap<MNM.IPAddressAvailabilityResult, CNM.PSIPAddressAvailabilityResult>();

                // Avaliable private access services
                // CNM to MNM
                cfg.CreateMap<CNM.PSPrivateAccessServiceResult, MNM.PrivateAccessServiceResult>();

                // MNM to CNM
                cfg.CreateMap<MNM.PrivateAccessServiceResult, CNM.PSPrivateAccessServiceResult>();

                // VirtualNetwork Peering
                cfg.CreateMap<CNM.PSVirtualNetworkPeering, MNM.VirtualNetworkPeering>();

                cfg.CreateMap<MNM.VirtualNetworkPeering, CNM.PSVirtualNetworkPeering>();

                // VirtualNetwork
                // CNM to MNM
                cfg.CreateMap<CNM.PSAddressSpace, MNM.AddressSpace>();
                cfg.CreateMap<CNM.PSVirtualNetwork, MNM.VirtualNetwork>();
                cfg.CreateMap<CNM.PSVirtualNetworkUsage, MNM.VirtualNetworkUsage>();
                cfg.CreateMap<CNM.PSUsageName, MNM.VirtualNetworkUsageName>();

                // MNM to CNM
                cfg.CreateMap<MNM.AddressSpace, CNM.PSAddressSpace>();
                cfg.CreateMap<MNM.VirtualNetwork, CNM.PSVirtualNetwork>();
                cfg.CreateMap<MNM.VirtualNetworkUsage, CNM.PSVirtualNetworkUsage>();
                cfg.CreateMap<MNM.VirtualNetworkUsageName, CNM.PSUsageName>();

                // PublicIpAddress
                // CNM to MNM
                cfg.CreateMap<CNM.PSPublicIpAddress, MNM.PublicIPAddress>();
                cfg.CreateMap<CNM.PSPublicIpAddressDnsSettings, MNM.PublicIPAddressDnsSettings>();

                // MNM to CNM
                cfg.CreateMap<MNM.PublicIPAddress, CNM.PSPublicIpAddress>();
                cfg.CreateMap<MNM.PublicIPAddressDnsSettings, CNM.PSPublicIpAddressDnsSettings>();

                // NetworkInterface
                // CNM to MNM
                cfg.CreateMap<CNM.PSNetworkInterface, MNM.NetworkInterface>();
                cfg.CreateMap<CNM.PSNetworkInterfaceDnsSettings, MNM.NetworkInterfaceDnsSettings>();
                cfg.CreateMap<CNM.PSNetworkInterfaceIPConfiguration, MNM.NetworkInterfaceIPConfiguration>();

                // MNM to CNM
                cfg.CreateMap<MNM.NetworkInterface, CNM.PSNetworkInterface>();
                cfg.CreateMap<MNM.NetworkInterfaceDnsSettings, CNM.PSNetworkInterfaceDnsSettings>();
                cfg.CreateMap<MNM.NetworkInterfaceIPConfiguration, CNM.PSNetworkInterfaceIPConfiguration>();

                // Usage
                cfg.CreateMap<CNM.PSUsage, MNM.Usage>();
                cfg.CreateMap<MNM.Usage, CNM.PSUsage>();
                cfg.CreateMap<CNM.PSUsageName, MNM.UsageName>();
                cfg.CreateMap<MNM.UsageName, CNM.PSUsageName>();

                // NetworkWatcher
                // CNM to MNM
                cfg.CreateMap<CNM.PSNetworkWatcher, MNM.NetworkWatcher>();

                // MNM to CNM
                cfg.CreateMap<MNM.NetworkWatcher, CNM.PSNetworkWatcher>();

                // PacketCapture
                // CNM to MNM
                cfg.CreateMap<CNM.PSPacketCapture, MNM.PacketCaptureParameters>();
                cfg.CreateMap<CNM.PSPacketCaptureResult, MNM.PacketCaptureResult>();
                cfg.CreateMap<CNM.PSStorageLocation, MNM.PacketCaptureStorageLocation>();
                cfg.CreateMap<CNM.PSPacketCaptureFilter, MNM.PacketCaptureFilter>();
                cfg.CreateMap<CNM.PSPacketCaptureStatus, MNM.PacketCaptureQueryStatusResult>();

                // MNM to CNM
                cfg.CreateMap<MNM.PacketCaptureParameters, CNM.PSPacketCapture>();
                cfg.CreateMap<MNM.PacketCaptureResult, CNM.PSPacketCaptureResult>();
                cfg.CreateMap<MNM.PacketCaptureStorageLocation, CNM.PSStorageLocation>();
                cfg.CreateMap<MNM.PacketCaptureFilter, CNM.PSPacketCaptureFilter>();
                cfg.CreateMap<MNM.PacketCaptureQueryStatusResult, CNM.PSPacketCaptureStatus>();

                // Topology
                // CNM to MNM
                cfg.CreateMap<CNM.PSTopology, MNM.Topology>();
                cfg.CreateMap<CNM.PSTopologyResource, MNM.TopologyResource>();
                cfg.CreateMap<CNM.PSTopologyAssociation, MNM.TopologyAssociation>();

                // MNM to CNM
                cfg.CreateMap<MNM.Topology, CNM.PSTopology>();
                cfg.CreateMap<MNM.TopologyResource, CNM.PSTopologyResource>();
                cfg.CreateMap<MNM.TopologyAssociation, CNM.PSTopologyAssociation>();

                // ViewNsgRules
                // CNM to MNM
                cfg.CreateMap<CNM.PSSecurityGroupNetworkInterface, MNM.SecurityGroupNetworkInterface>();
                cfg.CreateMap<CNM.PSSecurityRuleAssociations, MNM.SecurityRuleAssociations>();
                cfg.CreateMap<CNM.PSNetworkInterfaceAssociation, MNM.NetworkInterfaceAssociation>();
                cfg.CreateMap<CNM.PSSubnetAssociation, MNM.SubnetAssociation>();

                // MNM to CNM
                cfg.CreateMap<MNM.SecurityGroupNetworkInterface, CNM.PSSecurityGroupNetworkInterface>();
                cfg.CreateMap<MNM.SecurityRuleAssociations, CNM.PSSecurityRuleAssociations>();
                cfg.CreateMap<MNM.NetworkInterfaceAssociation, CNM.PSNetworkInterfaceAssociation>();
                cfg.CreateMap<MNM.SubnetAssociation, CNM.PSSubnetAssociation>();

                // IpFlowVerify
                // CNM to MNM
                cfg.CreateMap<CNM.PSIPFlowVerifyResult, MNM.VerificationIPFlowResult>();

                // MNM to CNM
                cfg.CreateMap<MNM.VerificationIPFlowResult, CNM.PSIPFlowVerifyResult>();

                // NextHop
                // CNM to MNM
                cfg.CreateMap<CNM.PSNextHopResult, MNM.NextHopResult>();

                // MNM to CNM
                cfg.CreateMap<MNM.NextHopResult, CNM.PSNextHopResult>();

                // Troubleshoot
                // CNM to MNM
                cfg.CreateMap<CNM.PSTroubleshootResult, MNM.TroubleshootingResult>();
                cfg.CreateMap<CNM.PSTroubleshootDetails, MNM.TroubleshootingDetails>();
                cfg.CreateMap<CNM.PSTroubleshootRecommendedActions, MNM.TroubleshootingRecommendedActions>();

                // MNM to CNM
                cfg.CreateMap<MNM.TroubleshootingResult, CNM.PSTroubleshootResult>();
                cfg.CreateMap<MNM.TroubleshootingDetails, CNM.PSTroubleshootDetails>();
                cfg.CreateMap<MNM.TroubleshootingRecommendedActions, CNM.PSTroubleshootRecommendedActions>();

                // FlowLog
                // CNM to MNM
                cfg.CreateMap<CNM.PSFlowLog, MNM.FlowLogInformation>();
                cfg.CreateMap<CNM.PSRetentionPolicyParameters, MNM.RetentionPolicyParameters>();

                // MNM to CNM
                cfg.CreateMap<MNM.FlowLogInformation, CNM.PSFlowLog>();
                cfg.CreateMap<MNM.RetentionPolicyParameters, CNM.PSRetentionPolicyParameters>();

                // CheckConnectivity
                // CNM to MNM
                cfg.CreateMap<CNM.PSConnectivityInformation, MNM.ConnectivityInformation>();
                cfg.CreateMap<CNM.PSConnectivityHop, MNM.ConnectivityHop>();
                cfg.CreateMap<CNM.PSConnectivityIssue, MNM.ConnectivityIssue>();

                // MNM to CNM
                cfg.CreateMap<MNM.ConnectivityInformation, CNM.PSConnectivityInformation>();
                cfg.CreateMap<MNM.ConnectivityHop, CNM.PSConnectivityHop>();
                cfg.CreateMap<MNM.ConnectivityIssue, CNM.PSConnectivityIssue>();

                // LoadBalancer
                // CNM to MNM
                cfg.CreateMap<CNM.PSLoadBalancer, MNM.LoadBalancer>();

                // MNM to CNM
                cfg.CreateMap<MNM.LoadBalancer, CNM.PSLoadBalancer>();

                // FrontendIpConfiguration
                // CNM to MNM
                cfg.CreateMap<CNM.PSFrontendIPConfiguration, MNM.FrontendIPConfiguration>();

                // MNM to CNM
                cfg.CreateMap<MNM.FrontendIPConfiguration, CNM.PSFrontendIPConfiguration>();

                // BackendAddressPool
                // CNM to MNM
                cfg.CreateMap<CNM.PSBackendAddressPool, MNM.BackendAddressPool>();

                // MNM to CNM
                cfg.CreateMap<MNM.BackendAddressPool, CNM.PSBackendAddressPool>();

                // LoadBalancingRule
                // CNM to MNM
                cfg.CreateMap<CNM.PSLoadBalancingRule, MNM.LoadBalancingRule>();

                // MNM to CNM
                cfg.CreateMap<MNM.LoadBalancingRule, CNM.PSLoadBalancingRule>();

                // Probes
                // CNM to MNM
                cfg.CreateMap<CNM.PSProbe, MNM.Probe>();

                // MNM to CNM
                cfg.CreateMap<MNM.Probe, CNM.PSProbe>();

                // InboundNatRules
                // CNM to MNM
                cfg.CreateMap<CNM.PSInboundNatRule, MNM.InboundNatRule>();

                // MNM to CNM
                cfg.CreateMap<MNM.InboundNatRule, CNM.PSInboundNatRule>();

                // InboundNatPools
                // CNM to MNM
                cfg.CreateMap<CNM.PSInboundNatPool, MNM.InboundNatPool>();

                // MNM to CNM
                cfg.CreateMap<MNM.InboundNatPool, CNM.PSInboundNatPool>();

                // NetworkSecurityGroups
                // CNM to MNM
                cfg.CreateMap<CNM.PSNetworkSecurityGroup, MNM.NetworkSecurityGroup>();

                // MNM to CNM
                cfg.CreateMap<MNM.NetworkSecurityGroup, CNM.PSNetworkSecurityGroup>();

                // NetworkSecrityRule
                // CNM to MNM
                cfg.CreateMap<CNM.PSSecurityRule, MNM.SecurityRule>();

                // MNM to CNM
                cfg.CreateMap<MNM.SecurityRule, CNM.PSSecurityRule>();

                // RouteTable
                // CNM to MNM
                cfg.CreateMap<CNM.PSRouteTable, MNM.RouteTable>();

                // MNM to CNM
                cfg.CreateMap<MNM.RouteTable, CNM.PSRouteTable>();

                // Route
                // CNM to MNM
                cfg.CreateMap<CNM.PSRoute, MNM.Route>();

                // MNM to CNM
                cfg.CreateMap<MNM.Route, CNM.PSRoute>();

                // EffectiveRouteTable
                // CNM to MNM
                cfg.CreateMap<CNM.PSEffectiveRoute, MNM.EffectiveRoute>();

                // MNM to CNM
                cfg.CreateMap<MNM.EffectiveRoute, CNM.PSEffectiveRoute>();

                // EffectiveNetworkSecurityGroup
                // CNM to MNM
                cfg.CreateMap<CNM.PSEffectiveNetworkSecurityGroup, MNM.EffectiveNetworkSecurityGroup>();
                cfg.CreateMap<CNM.PSEffectiveNetworkSecurityGroupAssociation, MNM.EffectiveNetworkSecurityGroupAssociation>();
                cfg.CreateMap<CNM.PSEffectiveSecurityRule, MNM.EffectiveNetworkSecurityRule>();

                // MNM to CNM
                cfg.CreateMap<MNM.EffectiveNetworkSecurityGroup, CNM.PSEffectiveNetworkSecurityGroup>();
                cfg.CreateMap<MNM.EffectiveNetworkSecurityGroupAssociation, CNM.PSEffectiveNetworkSecurityGroupAssociation>();
                cfg.CreateMap<MNM.EffectiveNetworkSecurityRule, CNM.PSEffectiveSecurityRule>();

                // ExpressRouteCircuit
                // CNM to MNM
                cfg.CreateMap<CNM.PSExpressRouteCircuit, MNM.ExpressRouteCircuit>();
                cfg.CreateMap<CNM.PSServiceProviderProperties, MNM.ExpressRouteCircuitServiceProviderProperties>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitSku, MNM.ExpressRouteCircuitSku>();
                cfg.CreateMap<CNM.PSPeering, MNM.ExpressRouteCircuitPeering>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitAuthorization, MNM.ExpressRouteCircuitAuthorization>();

                // MNM to CNM
                cfg.CreateMap<MNM.ExpressRouteCircuit, CNM.PSExpressRouteCircuit>();
                cfg.CreateMap<MNM.ExpressRouteCircuitServiceProviderProperties, CNM.PSServiceProviderProperties>();
                cfg.CreateMap<MNM.ExpressRouteCircuitSku, CNM.PSExpressRouteCircuitSku>();
                cfg.CreateMap<MNM.ExpressRouteCircuitPeering, CNM.PSPeering>();
                cfg.CreateMap<MNM.ExpressRouteCircuitAuthorization, CNM.PSExpressRouteCircuitAuthorization>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitStats, MNM.ExpressRouteCircuitStats>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitArpTable, MNM.ExpressRouteCircuitArpTable>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitRoutesTable, MNM.ExpressRouteCircuitRoutesTable>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitRoutesTableSummary, MNM.ExpressRouteCircuitRoutesTableSummary>();

                // ExpressRouteCircuitPeering
                // CNM to MNM
                cfg.CreateMap<CNM.PSPeering, MNM.ExpressRouteCircuitPeering>();
                cfg.CreateMap<CNM.PSPeeringConfig, MNM.ExpressRouteCircuitPeeringConfig>();
                cfg.CreateMap<CNM.PSIpv6PeeringConfig, MNM.Ipv6ExpressRouteCircuitPeeringConfig>();

                // MNM to CNM
                cfg.CreateMap<MNM.ExpressRouteCircuitPeering, CNM.PSPeering>();
                cfg.CreateMap<MNM.ExpressRouteCircuitPeeringConfig, CNM.PSPeeringConfig>();
                cfg.CreateMap<MNM.Ipv6ExpressRouteCircuitPeeringConfig, CNM.PSIpv6PeeringConfig>();

                // ExpressRouteServiceProvider
                // CNM to MNM
                cfg.CreateMap<CNM.PSExpressRouteServiceProvider, MNM.ExpressRouteServiceProvider>();
                cfg.CreateMap<CNM.PSExpressRouteServiceProviderBandwidthsOffered, MNM.ExpressRouteServiceProviderBandwidthsOffered>();

                // MNM to CNM
                cfg.CreateMap<MNM.ExpressRouteServiceProvider, CNM.PSExpressRouteServiceProvider>();
                cfg.CreateMap<MNM.ExpressRouteServiceProviderBandwidthsOffered, CNM.PSExpressRouteServiceProviderBandwidthsOffered>();
                cfg.CreateMap<MNM.ExpressRouteCircuitStats, CNM.PSExpressRouteCircuitStats>();
                cfg.CreateMap<MNM.ExpressRouteCircuitArpTable, CNM.PSExpressRouteCircuitArpTable>();
                cfg.CreateMap<MNM.ExpressRouteCircuitRoutesTable, CNM.PSExpressRouteCircuitRoutesTable>();
                cfg.CreateMap<MNM.ExpressRouteCircuitRoutesTableSummary, CNM.PSExpressRouteCircuitRoutesTableSummary>();

                // ExoressRouteCircuitAuthorization
                // CNM to MNM
                cfg.CreateMap<CNM.PSExpressRouteCircuitAuthorization, MNM.ExpressRouteCircuitAuthorization>();

                // MNM to CNM
                cfg.CreateMap<MNM.ExpressRouteCircuitAuthorization, CNM.PSExpressRouteCircuitAuthorization>();


                // Gateways
                // CNM to MNM
                cfg.CreateMap<CNM.PSVirtualNetworkGateway, MNM.VirtualNetworkGateway>();
                cfg.CreateMap<CNM.PSConnectionResetSharedKey, MNM.ConnectionResetSharedKey>();
                cfg.CreateMap<CNM.PSConnectionSharedKey, MNM.ConnectionSharedKey>();
                cfg.CreateMap<CNM.PSLocalNetworkGateway, MNM.LocalNetworkGateway>();
                cfg.CreateMap<CNM.PSVirtualNetworkGatewayConnection, MNM.VirtualNetworkGatewayConnection>();
                cfg.CreateMap<CNM.PSIpsecPolicy, MNM.IpsecPolicy>();
                cfg.CreateMap<CNM.PSVirtualNetworkGatewayIpConfiguration, MNM.VirtualNetworkGatewayIPConfiguration>();
                cfg.CreateMap<CNM.PSTunnelConnectionHealth, MNM.TunnelConnectionHealth>();
                cfg.CreateMap<CNM.PSVirtualNetworkGatewaySku, MNM.VirtualNetworkGatewaySku>();
                cfg.CreateMap<CNM.PSVpnClientConfiguration, MNM.VpnClientConfiguration>();
                cfg.CreateMap<CNM.PSVpnClientParameters, MNM.VpnClientParameters>();
                cfg.CreateMap<CNM.PSVpnClientRevokedCertificate, MNM.VpnClientRevokedCertificate>();
                cfg.CreateMap<CNM.PSVpnClientRootCertificate, MNM.VpnClientRootCertificate>();
                cfg.CreateMap<CNM.PSBgpSettings, MNM.BgpSettings>();
                cfg.CreateMap<CNM.PSBGPPeerStatus, MNM.BgpPeerStatus>();
                cfg.CreateMap<CNM.PSGatewayRoute, MNM.GatewayRoute>();

                // MNM to CNM
                cfg.CreateMap<MNM.VirtualNetworkGateway, CNM.PSVirtualNetworkGateway>();
                cfg.CreateMap<MNM.ConnectionResetSharedKey, CNM.PSConnectionResetSharedKey>();
                cfg.CreateMap<MNM.ConnectionSharedKey, CNM.PSConnectionSharedKey>();
                cfg.CreateMap<MNM.LocalNetworkGateway, CNM.PSLocalNetworkGateway>();
                cfg.CreateMap<MNM.VirtualNetworkGatewayConnection, CNM.PSVirtualNetworkGatewayConnection>();
                cfg.CreateMap<MNM.IpsecPolicy, CNM.PSIpsecPolicy>();
                cfg.CreateMap<MNM.VirtualNetworkGatewayIPConfiguration, CNM.PSVirtualNetworkGatewayIpConfiguration>();
                cfg.CreateMap<MNM.TunnelConnectionHealth, CNM.PSTunnelConnectionHealth>();
                cfg.CreateMap<MNM.VirtualNetworkGatewaySku, CNM.PSVirtualNetworkGatewaySku>();
                cfg.CreateMap<MNM.VpnClientConfiguration, CNM.PSVpnClientConfiguration>();
                cfg.CreateMap<MNM.VpnClientParameters, CNM.PSVpnClientParameters>();
                cfg.CreateMap<MNM.VpnClientRevokedCertificate, CNM.PSVpnClientRevokedCertificate>();
                cfg.CreateMap<MNM.VpnClientRootCertificate, CNM.PSVpnClientRootCertificate>();
                cfg.CreateMap<MNM.BgpSettings, CNM.PSBgpSettings>();
                cfg.CreateMap<MNM.BgpPeerStatus, CNM.PSBGPPeerStatus>();
                cfg.CreateMap<MNM.GatewayRoute, CNM.PSGatewayRoute>();

                // Application Gateways
                // CNM to MNM
                cfg.CreateMap<CNM.PSApplicationGateway, MNM.ApplicationGateway>();
                cfg.CreateMap<CNM.PSApplicationGatewaySku, MNM.ApplicationGatewaySku>();
                cfg.CreateMap<CNM.PSApplicationGatewaySslPolicy, MNM.ApplicationGatewaySslPolicy>()
                    .AfterMap((src, dest) =>
                    {
                        dest.CipherSuites = src.CipherSuites == null ? null : dest.CipherSuites;
                        dest.DisabledSslProtocols = src.DisabledSslProtocols == null ? null : dest.DisabledSslProtocols;
                    });
                cfg.CreateMap<CNM.PSApplicationGatewayPathRule, MNM.ApplicationGatewayPathRule>();
                cfg.CreateMap<CNM.PSApplicationGatewayUrlPathMap, MNM.ApplicationGatewayUrlPathMap>();
                cfg.CreateMap<CNM.PSApplicationGatewayProbeHealthResponseMatch, MNM.ApplicationGatewayProbeHealthResponseMatch>();
                cfg.CreateMap<CNM.PSApplicationGatewayProbe, MNM.ApplicationGatewayProbe>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendAddress, MNM.ApplicationGatewayBackendAddress>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendAddressPool, MNM.ApplicationGatewayBackendAddressPool>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendHttpSettings, MNM.ApplicationGatewayBackendHttpSettings>();
                cfg.CreateMap<CNM.PSApplicationGatewayFrontendIPConfiguration, MNM.ApplicationGatewayFrontendIPConfiguration>();
                cfg.CreateMap<CNM.PSApplicationGatewayFrontendPort, MNM.ApplicationGatewayFrontendPort>();
                cfg.CreateMap<CNM.PSApplicationGatewaySslCertificate, MNM.ApplicationGatewaySslCertificate>();
                cfg.CreateMap<CNM.PSApplicationGatewayHttpListener, MNM.ApplicationGatewayHttpListener>();
                cfg.CreateMap<CNM.PSApplicationGatewayIPConfiguration, MNM.ApplicationGatewayIPConfiguration>();
                cfg.CreateMap<CNM.PSApplicationGatewayRequestRoutingRule, MNM.ApplicationGatewayRequestRoutingRule>();
                cfg.CreateMap<CNM.PSApplicationGatewayRedirectConfiguration, MNM.ApplicationGatewayRedirectConfiguration>();
                cfg.CreateMap<CNM.PSApplicationGatewayAuthenticationCertificate, MNM.ApplicationGatewayAuthenticationCertificate>();
                cfg.CreateMap<CNM.PSBackendAddressPool, MNM.BackendAddressPool>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendHealth, MNM.ApplicationGatewayBackendHealth>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendHealthPool, MNM.ApplicationGatewayBackendHealthPool>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendHealthHttpSettings, MNM.ApplicationGatewayBackendHealthHttpSettings>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendHealthServer, MNM.ApplicationGatewayBackendHealthServer>();
                cfg.CreateMap<CNM.PSApplicationGatewayWebApplicationFirewallConfiguration, MNM.ApplicationGatewayWebApplicationFirewallConfiguration>();
                cfg.CreateMap<CNM.PSApplicationGatewayConnectionDraining, MNM.ApplicationGatewayConnectionDraining>();
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallDisabledRuleGroup, MNM.ApplicationGatewayFirewallDisabledRuleGroup>()
                    .AfterMap((src, dest) => dest.Rules = (src.Rules == null) ? null : dest.Rules);
                cfg.CreateMap<CNM.PSApplicationGatewayAvailableWafRuleSetsResult, MNM.ApplicationGatewayAvailableWafRuleSetsResult>();
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallRule, MNM.ApplicationGatewayFirewallRule>();
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallRuleGroup, MNM.ApplicationGatewayFirewallRuleGroup>();
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallRuleSet, MNM.ApplicationGatewayFirewallRuleSet>();
                cfg.CreateMap<CNM.PSApplicationGatewayAvailableSslOptions, MNM.ApplicationGatewayAvailableSslOptions>();
                cfg.CreateMap<CNM.PSApplicationGatewaySslPredefinedPolicy, MNM.ApplicationGatewaySslPredefinedPolicy>();

                // MNM to CNM
                cfg.CreateMap<MNM.ApplicationGateway, CNM.PSApplicationGateway>();
                cfg.CreateMap<MNM.ApplicationGatewaySku, CNM.PSApplicationGatewaySku>();
                cfg.CreateMap<MNM.ApplicationGatewaySslPolicy, CNM.PSApplicationGatewaySslPolicy>()
                    .AfterMap((src, dest) =>
                    {
                        dest.CipherSuites = src.CipherSuites == null ? null : dest.CipherSuites;
                        dest.DisabledSslProtocols = src.DisabledSslProtocols == null ? null : dest.DisabledSslProtocols;
                    });
                cfg.CreateMap<MNM.ApplicationGatewayPathRule, CNM.PSApplicationGatewayPathRule>();
                cfg.CreateMap<MNM.ApplicationGatewayUrlPathMap, CNM.PSApplicationGatewayUrlPathMap>();
                cfg.CreateMap<MNM.ApplicationGatewayProbeHealthResponseMatch, CNM.PSApplicationGatewayProbeHealthResponseMatch>();
                cfg.CreateMap<MNM.ApplicationGatewayProbe, CNM.PSApplicationGatewayProbe>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendAddress, CNM.PSApplicationGatewayBackendAddress>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendAddressPool, CNM.PSApplicationGatewayBackendAddressPool>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendHttpSettings, CNM.PSApplicationGatewayBackendHttpSettings>();
                cfg.CreateMap<MNM.ApplicationGatewayFrontendIPConfiguration, CNM.PSApplicationGatewayFrontendIPConfiguration>();
                cfg.CreateMap<MNM.ApplicationGatewaySslCertificate, CNM.PSApplicationGatewaySslCertificate>();
                cfg.CreateMap<MNM.ApplicationGatewayFrontendPort, CNM.PSApplicationGatewayFrontendPort>();
                cfg.CreateMap<MNM.ApplicationGatewayHttpListener, CNM.PSApplicationGatewayHttpListener>();
                cfg.CreateMap<MNM.ApplicationGatewayIPConfiguration, CNM.PSApplicationGatewayIPConfiguration>();
                cfg.CreateMap<MNM.ApplicationGatewayRequestRoutingRule, CNM.PSApplicationGatewayRequestRoutingRule>();
                cfg.CreateMap<MNM.ApplicationGatewayRedirectConfiguration, CNM.PSApplicationGatewayRedirectConfiguration>();
                cfg.CreateMap<MNM.ApplicationGatewayAuthenticationCertificate, CNM.PSApplicationGatewayAuthenticationCertificate>();
                cfg.CreateMap<MNM.BackendAddressPool, CNM.PSBackendAddressPool>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendHealth, CNM.PSApplicationGatewayBackendHealth>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendHealthPool, CNM.PSApplicationGatewayBackendHealthPool>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendHealthHttpSettings, CNM.PSApplicationGatewayBackendHealthHttpSettings>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendHealthServer, CNM.PSApplicationGatewayBackendHealthServer>();
                cfg.CreateMap<MNM.ApplicationGatewayWebApplicationFirewallConfiguration, CNM.PSApplicationGatewayWebApplicationFirewallConfiguration>();
                cfg.CreateMap<MNM.ApplicationGatewayConnectionDraining, CNM.PSApplicationGatewayConnectionDraining>();
                cfg.CreateMap<MNM.ApplicationGatewayFirewallDisabledRuleGroup, CNM.PSApplicationGatewayFirewallDisabledRuleGroup>()
                    .AfterMap((src, dest) => dest.Rules = (src.Rules == null) ? null : dest.Rules);
                cfg.CreateMap<MNM.ApplicationGatewayAvailableWafRuleSetsResult, CNM.PSApplicationGatewayAvailableWafRuleSetsResult>();
                cfg.CreateMap<MNM.ApplicationGatewayFirewallRule, CNM.PSApplicationGatewayFirewallRule>();
                cfg.CreateMap<MNM.ApplicationGatewayFirewallRuleGroup, CNM.PSApplicationGatewayFirewallRuleGroup>();
                cfg.CreateMap<MNM.ApplicationGatewayFirewallRuleSet, CNM.PSApplicationGatewayFirewallRuleSet>();
                cfg.CreateMap<MNM.ApplicationGatewayAvailableSslOptions, CNM.PSApplicationGatewayAvailableSslOptions>();
                cfg.CreateMap<MNM.ApplicationGatewaySslPredefinedPolicy, CNM.PSApplicationGatewaySslPredefinedPolicy>();
            });
        }
    }
}