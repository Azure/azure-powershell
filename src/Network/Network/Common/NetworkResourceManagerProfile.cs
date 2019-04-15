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
    using System.Collections.Generic;
    using System.Linq;
    using WindowsAzure.Commands.Common;
    using CNM = Microsoft.Azure.Commands.Network.Models;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    public class NetworkResourceManagerProfile : Profile
    {
        private static IMapper _mapper = null;

        private static readonly object _lock = new object();

        public static IMapper Mapper
        {
            get
            {
                lock(_lock)
                {
                    if (_mapper == null)
                    {
                        Initialize();
                    }

                    return _mapper;
                }
            }
        }

        public override string ProfileName
        {
            get { return "NetworkResourceManagerProfile"; }
        }

        private static void Initialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<NetworkResourceManagerProfile>();
                cfg.CreateMap<CNM.PSResourceId, MNM.SubResource>();
                cfg.CreateMap<MNM.SubResource, CNM.PSResourceId>();

                // Managed Service Identity
                cfg.CreateMap<CNM.PSManagedServiceIdentity, MNM.ManagedServiceIdentity>();
                cfg.CreateMap<MNM.ManagedServiceIdentity, CNM.PSManagedServiceIdentity>();
                cfg.CreateMap<CNM.PSManagedServiceIdentityUserAssignedIdentitiesValue, MNM.ManagedServiceIdentityUserAssignedIdentitiesValue>();
                cfg.CreateMap<MNM.ManagedServiceIdentityUserAssignedIdentitiesValue, CNM.PSManagedServiceIdentityUserAssignedIdentitiesValue>();

                // Route Filter 
                cfg.CreateMap<CNM.PSRouteFilter, MNM.RouteFilter>();
                cfg.CreateMap<MNM.RouteFilter, CNM.PSRouteFilter>();
                cfg.CreateMap<CNM.PSRouteFilterRule, MNM.RouteFilterRule>();
                cfg.CreateMap<MNM.RouteFilterRule, CNM.PSRouteFilterRule>();

                // Nat Gateway 
                cfg.CreateMap<CNM.PSNatGateway, MNM.NatGateway>();
                cfg.CreateMap<MNM.NatGateway, CNM.PSNatGateway>();
                cfg.CreateMap<CNM.PSNatGatewaySku, MNM.NatGatewaySku>();
                cfg.CreateMap<MNM.NatGatewaySku, CNM.PSNatGatewaySku>();

                // Bgp Service Community
                cfg.CreateMap<CNM.PSBgpServiceCommunity, MNM.BgpServiceCommunity>();
                cfg.CreateMap<CNM.PSBgpCommunity, MNM.BGPCommunity>();
                cfg.CreateMap<MNM.BgpServiceCommunity, CNM.PSBgpServiceCommunity>();
                cfg.CreateMap<MNM.BGPCommunity, CNM.PSBgpCommunity>();

                // Subnet
                // CNM to MNM
                cfg.CreateMap<CNM.PSDhcpOptions, MNM.DhcpOptions>();
                cfg.CreateMap<CNM.PSSubnet, MNM.Subnet>()
                    .ForMember(dest => dest.AddressPrefix, opt => opt.Ignore())
                    .ForMember(dest=> dest.AddressPrefixes, opt => opt.Ignore())
                    .AfterMap((src, dest) =>
                    {
                        if (GeneralUtilities.HasMoreThanOneElement(src.AddressPrefix))
                        {
                            dest.AddressPrefixes = src.AddressPrefix;
                        }
                        else
                        {
                            dest.AddressPrefix = src.AddressPrefix?.FirstOrDefault();
                        }
                    });
                cfg.CreateMap<CNM.PSIPConfiguration, MNM.IPConfiguration>();
                cfg.CreateMap<CNM.PSServiceAssocationLink, MNM.ServiceAssociationLink>();
                cfg.CreateMap<CNM.PSResourceNavigationLink, MNM.ResourceNavigationLink>();
                cfg.CreateMap<CNM.PSServiceEndpoint, MNM.ServiceEndpointPropertiesFormat>();
                cfg.CreateMap<CNM.PSDelegation, MNM.Delegation>();

                // MNM to CNM
                cfg.CreateMap<MNM.DhcpOptions, CNM.PSDhcpOptions>();
                cfg.CreateMap<MNM.Subnet, CNM.PSSubnet>()
                    .ForMember(dest => dest.AddressPrefix, opt => opt.Ignore())
                    .AfterMap((src, dest) =>
                    {
                        if (src.AddressPrefixes != null && src.AddressPrefixes.Any())
                        {
                            dest.AddressPrefix = src.AddressPrefixes?.ToList();
                        }
                        else if(!string.IsNullOrEmpty(src.AddressPrefix))
                        {
                            dest.AddressPrefix = new List<string> {src.AddressPrefix};
                        }
                    });
                cfg.CreateMap<MNM.IPConfiguration, CNM.PSIPConfiguration>();
                cfg.CreateMap<MNM.ServiceAssociationLink, CNM.PSServiceAssocationLink>();
                cfg.CreateMap<MNM.ResourceNavigationLink, CNM.PSResourceNavigationLink>();
                cfg.CreateMap<MNM.ServiceEndpointPropertiesFormat, CNM.PSServiceEndpoint>();
                cfg.CreateMap<MNM.Delegation, CNM.PSDelegation>();

                // TestPrivateIpAddressAvailability
                // CNM to MNM
                cfg.CreateMap<CNM.PSIPAddressAvailabilityResult, MNM.IPAddressAvailabilityResult>();

                // MNM to CNM
                cfg.CreateMap<MNM.IPAddressAvailabilityResult, CNM.PSIPAddressAvailabilityResult>();
                
                // Avaliable endpoint services
                // CNM to MNM
                cfg.CreateMap<CNM.PSEndpointServiceResult, MNM.EndpointServiceResult>();

                // MNM to CNM
                cfg.CreateMap<MNM.EndpointServiceResult, CNM.PSEndpointServiceResult>();

                // Available subnet delegations
                // CNM to MNM
                cfg.CreateMap<CNM.PSAvailableDelegation, MNM.AvailableDelegation>();

                // MNM to CNM
                cfg.CreateMap<MNM.AvailableDelegation, CNM.PSAvailableDelegation>();

                // VirtualNetwork Peering
                // CNM to MNM
                cfg.CreateMap<CNM.PSVirtualNetworkPeering, MNM.VirtualNetworkPeering>()
                    .ForMember(
                        dest => dest.RemoteAddressSpace,
                        opt => opt.MapFrom(src => src.RemoteVirtualNetworkAddressSpace)
                    );

                // MNM to CNM
                cfg.CreateMap<MNM.VirtualNetworkPeering, CNM.PSVirtualNetworkPeering>()
                    .ForMember(
                        dest => dest.RemoteVirtualNetworkAddressSpace,
                        opt => opt.MapFrom(src => src.RemoteAddressSpace)
                    );

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
                cfg.CreateMap<CNM.PSPublicIpTag, MNM.IpTag>();
                cfg.CreateMap<CNM.PSPublicIpAddressSku, MNM.PublicIPAddressSku>();
                cfg.CreateMap<CNM.PSPublicIpAddressDnsSettings, MNM.PublicIPAddressDnsSettings>();

                // MNM to CNM
                cfg.CreateMap<MNM.PublicIPAddress, CNM.PSPublicIpAddress>();
                cfg.CreateMap<MNM.IpTag, CNM.PSPublicIpTag>();
                cfg.CreateMap<MNM.PublicIPAddressSku, CNM.PSPublicIpAddressSku>();
                cfg.CreateMap<MNM.PublicIPAddressDnsSettings, CNM.PSPublicIpAddressDnsSettings>();

                // PublicIpPrefix
                // CNM to MNM
                cfg.CreateMap<CNM.PSPublicIpPrefix, MNM.PublicIPPrefix>();
                cfg.CreateMap<CNM.PSPublicIpPrefixSku, MNM.PublicIPPrefixSku>();
                cfg.CreateMap<CNM.PSPublicIpPrefixTag, MNM.IpTag>();
                cfg.CreateMap<CNM.PSPublicIpAddress, MNM.ReferencedPublicIpAddress>();

                // MNM to CNM
                cfg.CreateMap<MNM.PublicIPPrefix, CNM.PSPublicIpPrefix>();
                cfg.CreateMap<MNM.PublicIPPrefixSku, CNM.PSPublicIpPrefixSku>();
                cfg.CreateMap<MNM.IpTag, CNM.PSPublicIpPrefixTag>();
                cfg.CreateMap<MNM.ReferencedPublicIpAddress, CNM.PSPublicIpAddress>();

                // NetworkInterface
                // CNM to MNM
                cfg.CreateMap<CNM.PSNetworkInterface, MNM.NetworkInterface>();
                cfg.CreateMap<CNM.PSNetworkInterfaceDnsSettings, MNM.NetworkInterfaceDnsSettings>();
                cfg.CreateMap<CNM.PSNetworkInterfaceIPConfiguration, MNM.NetworkInterfaceIPConfiguration>();
                cfg.CreateMap<CNM.PSNetworkInterfaceTapConfiguration, MNM.NetworkInterfaceTapConfiguration>();

                // MNM to CNM
                cfg.CreateMap<MNM.NetworkInterface, CNM.PSNetworkInterface>();
                cfg.CreateMap<MNM.NetworkInterfaceDnsSettings, CNM.PSNetworkInterfaceDnsSettings>();
                cfg.CreateMap<MNM.NetworkInterfaceIPConfiguration, CNM.PSNetworkInterfaceIPConfiguration>();
                cfg.CreateMap<MNM.NetworkInterfaceTapConfiguration, CNM.PSNetworkInterfaceTapConfiguration>();

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
                cfg.CreateMap<CNM.PSTroubleshootingResult, MNM.TroubleshootingResult>();
                cfg.CreateMap<CNM.PSTroubleshootingDetails, MNM.TroubleshootingDetails>();
                cfg.CreateMap<CNM.PSTroubleshootingRecommendedActions, MNM.TroubleshootingRecommendedActions>();

                // MNM to CNM
                cfg.CreateMap<MNM.TroubleshootingResult, CNM.PSTroubleshootingResult>();
                cfg.CreateMap<MNM.TroubleshootingDetails, CNM.PSTroubleshootingDetails>();
                cfg.CreateMap<MNM.TroubleshootingRecommendedActions, CNM.PSTroubleshootingRecommendedActions>();

                // FlowLog
                // CNM to MNM
                cfg.CreateMap<CNM.PSFlowLog, MNM.FlowLogInformation>();
                cfg.CreateMap<CNM.PSRetentionPolicyParameters, MNM.RetentionPolicyParameters>();
                cfg.CreateMap<CNM.PSFlowLogFormatParameters, MNM.FlowLogFormatParameters>();
                cfg.CreateMap<CNM.PSTrafficAnalyticsProperties, MNM.TrafficAnalyticsProperties>();
                cfg.CreateMap<CNM.PSTrafficAnalyticsConfigurationProperties, MNM.TrafficAnalyticsConfigurationProperties>();

                // MNM to CNM
                cfg.CreateMap<MNM.FlowLogInformation, CNM.PSFlowLog>();
                cfg.CreateMap<MNM.RetentionPolicyParameters, CNM.PSRetentionPolicyParameters>();
                cfg.CreateMap<MNM.FlowLogFormatParameters, CNM.PSFlowLogFormatParameters>();
                cfg.CreateMap<MNM.TrafficAnalyticsProperties, CNM.PSTrafficAnalyticsProperties>();
                cfg.CreateMap<MNM.TrafficAnalyticsConfigurationProperties, CNM.PSTrafficAnalyticsConfigurationProperties>();

                // CheckConnectivity
                // CNM to MNM
                cfg.CreateMap<CNM.PSConnectivityInformation, MNM.ConnectivityInformation>();
                cfg.CreateMap<CNM.PSConnectivityHop, MNM.ConnectivityHop>();
                cfg.CreateMap<CNM.PSConnectivityIssue, MNM.ConnectivityIssue>();

                // MNM to CNM
                cfg.CreateMap<MNM.ConnectivityInformation, CNM.PSConnectivityInformation>();
                cfg.CreateMap<MNM.ConnectivityHop, CNM.PSConnectivityHop>();
                cfg.CreateMap<MNM.ConnectivityIssue, CNM.PSConnectivityIssue>();
                
                // AvailableProvidersList
                // CNM to MNM
                cfg.CreateMap<CNM.PSAvailableProvidersList, MNM.AvailableProvidersList>();
                cfg.CreateMap<CNM.PSAvailableProvidersListCountry, MNM.AvailableProvidersListCountry>();
                cfg.CreateMap<CNM.PSAvailableProvidersListState, MNM.AvailableProvidersListState>();
                cfg.CreateMap<CNM.PSAvailableProvidersListCity, MNM.AvailableProvidersListCity>();

                // MNM to CNM
                cfg.CreateMap<MNM.AvailableProvidersList, CNM.PSAvailableProvidersList>();
                cfg.CreateMap<MNM.AvailableProvidersListCountry, CNM.PSAvailableProvidersListCountry>();
                cfg.CreateMap<MNM.AvailableProvidersListState, CNM.PSAvailableProvidersListState>();
                cfg.CreateMap<MNM.AvailableProvidersListCity, CNM.PSAvailableProvidersListCity>();

                // AzureReachabilityReport
                // CNM to MNM
                cfg.CreateMap<CNM.PSAzureReachabilityReport, MNM.AzureReachabilityReport>();
                cfg.CreateMap<CNM.PSAzureReachabilityReportLocation, MNM.AzureReachabilityReportLocation>();
                cfg.CreateMap<CNM.PSAzureReachabilityReportItem, MNM.AzureReachabilityReportItem>();
                cfg.CreateMap<CNM.PSAzureReachabilityReportLatencyInfo, MNM.AzureReachabilityReportLatencyInfo>();

                // MNM to CNM
                cfg.CreateMap<MNM.AzureReachabilityReport, CNM.PSAzureReachabilityReport>();
                cfg.CreateMap<MNM.AzureReachabilityReportLocation, CNM.PSAzureReachabilityReportLocation>();
                cfg.CreateMap<MNM.AzureReachabilityReportItem, CNM.PSAzureReachabilityReportItem>();
                cfg.CreateMap<MNM.AzureReachabilityReportLatencyInfo, CNM.PSAzureReachabilityReportLatencyInfo>();

                // ConnectionMonitor
                // CNM to MNM
                cfg.CreateMap<CNM.PSConnectionMonitor, MNM.ConnectionMonitor>();
                cfg.CreateMap<CNM.PSConnectionMonitorSource, MNM.ConnectionMonitorSource>();
                cfg.CreateMap<CNM.PSConnectionMonitorDestination, MNM.ConnectionMonitorDestination>();
                cfg.CreateMap<CNM.PSConnectionMonitorParameters, MNM.ConnectionMonitorParameters>();
                cfg.CreateMap<CNM.PSConnectionMonitorResult, MNM.ConnectionMonitorResult>();
                cfg.CreateMap<CNM.PSConnectionMonitorQueryResult, MNM.ConnectionMonitorQueryResult>();
                cfg.CreateMap<CNM.PSConnectionStateSnapshot, MNM.ConnectionStateSnapshot>();

                // MNM to CNM
                cfg.CreateMap<MNM.ConnectionMonitor, CNM.PSConnectionMonitor>();
                cfg.CreateMap<MNM.ConnectionMonitorSource, CNM.PSConnectionMonitorSource>();
                cfg.CreateMap<MNM.ConnectionMonitorDestination, CNM.PSConnectionMonitorDestination>();
                cfg.CreateMap<MNM.ConnectionMonitorParameters, CNM.PSConnectionMonitorParameters>();
                cfg.CreateMap<MNM.ConnectionMonitorResult, CNM.PSConnectionMonitorResult>();
                cfg.CreateMap<MNM.ConnectionMonitorQueryResult, CNM.PSConnectionMonitorQueryResult>();
                cfg.CreateMap<MNM.ConnectionStateSnapshot, CNM.PSConnectionStateSnapshot>();

                // NetworkConfigurationDiagnostic
                // CNM to MNM
                cfg.CreateMap<CNM.PSEvaluatedNetworkSecurityGroup, MNM.EvaluatedNetworkSecurityGroup>();
                cfg.CreateMap<CNM.PSMatchedRule, MNM.MatchedRule>();
                cfg.CreateMap<CNM.PSNetworkConfigurationDiagnosticProfile, MNM.NetworkConfigurationDiagnosticProfile>();
                cfg.CreateMap<CNM.PSNetworkConfigurationDiagnosticResponse, MNM.NetworkConfigurationDiagnosticResponse>();
                cfg.CreateMap<CNM.PSNetworkConfigurationDiagnosticResult, MNM.NetworkConfigurationDiagnosticResult>();
                cfg.CreateMap<CNM.PSNetworkSecurityGroupResult, MNM.NetworkSecurityGroupResult>();
                cfg.CreateMap<CNM.PSNetworkSecurityRulesEvaluationResult, MNM.NetworkSecurityRulesEvaluationResult>();

                // MNM to CNM
                cfg.CreateMap<MNM.EvaluatedNetworkSecurityGroup, CNM.PSEvaluatedNetworkSecurityGroup>();
                cfg.CreateMap<MNM.MatchedRule, CNM.PSMatchedRule>();
                cfg.CreateMap<MNM.NetworkConfigurationDiagnosticProfile, CNM.PSNetworkConfigurationDiagnosticProfile>();
                cfg.CreateMap<MNM.NetworkConfigurationDiagnosticResponse, CNM.PSNetworkConfigurationDiagnosticResponse>();
                cfg.CreateMap<MNM.NetworkConfigurationDiagnosticResult, CNM.PSNetworkConfigurationDiagnosticResult>();
                cfg.CreateMap<MNM.NetworkSecurityGroupResult, CNM.PSNetworkSecurityGroupResult>();
                cfg.CreateMap<MNM.NetworkSecurityRulesEvaluationResult, CNM.PSNetworkSecurityRulesEvaluationResult>();

                // LoadBalancer
                // CNM to MNM
                cfg.CreateMap<CNM.PSLoadBalancer, MNM.LoadBalancer>();
                cfg.CreateMap<CNM.PSLoadBalancerSku, MNM.LoadBalancerSku>();

                // MNM to CNM
                cfg.CreateMap<MNM.LoadBalancer, CNM.PSLoadBalancer>();
                cfg.CreateMap<MNM.LoadBalancerSku, CNM.PSLoadBalancerSku>();

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

                // OutboundRules
                // CNM to MNM
                cfg.CreateMap<CNM.PSOutboundRule, MNM.OutboundRule>();

                // MNM to CNM
                cfg.CreateMap<MNM.OutboundRule, CNM.PSOutboundRule>();

                // NetworkSecurityGroups
                // CNM to MNM
                cfg.CreateMap<CNM.PSNetworkSecurityGroup, MNM.NetworkSecurityGroup>();

                // MNM to CNM
                cfg.CreateMap<MNM.NetworkSecurityGroup, CNM.PSNetworkSecurityGroup>();

                // NetworkSecrityRule
                // CNM to MNM
                cfg.CreateMap<CNM.PSSecurityRule, MNM.SecurityRule>()
                    .AfterMap((src, dest) =>
                    {
                        if (GeneralUtilities.HasSingleElement(src.SourcePortRange))
                        {
                            dest.SourcePortRange = src.SourcePortRange[0];
                        }
                        else
                        {
                            dest.SourcePortRanges = src.SourcePortRange;
                            dest.SourcePortRange = null;
                        }

                        if (GeneralUtilities.HasSingleElement(src.DestinationPortRange))
                        {
                            dest.DestinationPortRange = src.DestinationPortRange[0];
                        }
                        else
                        {
                            dest.DestinationPortRanges = src.DestinationPortRange;
                            dest.DestinationPortRange = null;
                        }

                        if (GeneralUtilities.HasSingleElement(src.SourceAddressPrefix))
                        {
                            dest.SourceAddressPrefix = src.SourceAddressPrefix[0];
                        }
                        else
                        {
                            dest.SourceAddressPrefixes = src.SourceAddressPrefix;
                            dest.SourceAddressPrefix = null;
                        }

                        if (GeneralUtilities.HasSingleElement(src.DestinationAddressPrefix))
                        {
                            dest.DestinationAddressPrefix = src.DestinationAddressPrefix[0];
                        }
                        else
                        {
                            dest.DestinationAddressPrefixes = src.DestinationAddressPrefix;
                            dest.DestinationAddressPrefix = null;
                        }
                    });

                cfg.CreateMap<MNM.SecurityRule, CNM.PSSecurityRule>()
                    .AfterMap((src, dest) =>
                    {
                        dest.SourcePortRange = GeneralUtilities.HasMoreThanOneElement(src.SourcePortRanges) ? src.SourcePortRanges : (!string.IsNullOrWhiteSpace(src.SourcePortRange) ? new List<string> { src.SourcePortRange } : new List<string>());
                        dest.DestinationPortRange = GeneralUtilities.HasMoreThanOneElement(src.DestinationPortRanges) ? src.DestinationPortRanges : (!string.IsNullOrWhiteSpace(src.DestinationPortRange) ? new List <string> { src.DestinationPortRange } : new List<string>());
                        dest.SourceAddressPrefix = GeneralUtilities.HasMoreThanOneElement(src.SourceAddressPrefixes) ? src.SourceAddressPrefixes : (!string.IsNullOrWhiteSpace(src.SourceAddressPrefix)? new List<string> { src.SourceAddressPrefix } : new List<string>());
                        dest.DestinationAddressPrefix = GeneralUtilities.HasMoreThanOneElement(src.DestinationAddressPrefixes) ? src.DestinationAddressPrefixes : (!string.IsNullOrWhiteSpace(src.DestinationAddressPrefix) ? new List<string> { src.DestinationAddressPrefix } : new List<string>());
                    });

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
                cfg.CreateMap<CNM.PSEffectiveSecurityRule, MNM.EffectiveNetworkSecurityRule>()
                    .AfterMap((src, dest) =>
                     {
                         if (GeneralUtilities.HasSingleElement(src.SourcePortRange))
                         {
                             dest.SourcePortRange = src.SourcePortRange[0];
                         }
                         else
                         {
                             dest.SourcePortRanges = src.SourcePortRange;
                             dest.SourcePortRange = null;
                         }

                         if (GeneralUtilities.HasSingleElement(src.DestinationPortRange))
                         {
                             dest.DestinationPortRange = src.DestinationPortRange[0];
                         }
                         else
                         {
                             dest.DestinationPortRanges = src.DestinationPortRange;
                             dest.DestinationPortRange = null;
                         }

                         if (GeneralUtilities.HasSingleElement(src.SourceAddressPrefix))
                         {
                             dest.SourceAddressPrefix = src.SourceAddressPrefix[0];
                         }
                         else
                         {
                             dest.SourceAddressPrefixes = src.SourceAddressPrefix;
                             dest.SourceAddressPrefix = null;
                         }

                         if (GeneralUtilities.HasSingleElement(src.DestinationAddressPrefix))
                         {
                             dest.DestinationAddressPrefix = src.DestinationAddressPrefix[0];
                         }
                         else
                         {
                             dest.DestinationAddressPrefixes = src.DestinationAddressPrefix;
                             dest.DestinationAddressPrefix = null;
                         }
                     });
                
                // MNM to CNM
                cfg.CreateMap<MNM.EffectiveNetworkSecurityGroup, CNM.PSEffectiveNetworkSecurityGroup>();
                cfg.CreateMap<MNM.EffectiveNetworkSecurityGroupAssociation, CNM.PSEffectiveNetworkSecurityGroupAssociation>();
                cfg.CreateMap<MNM.EffectiveNetworkSecurityRule, CNM.PSEffectiveSecurityRule>()
                    .AfterMap((src, dest) =>
                    {
                        dest.SourcePortRange = GeneralUtilities.HasMoreThanOneElement(src.SourcePortRanges) ? src.SourcePortRanges : (!string.IsNullOrWhiteSpace(src.SourcePortRange) ? new List<string> { src.SourcePortRange } : new List<string>());
                        dest.DestinationPortRange = GeneralUtilities.HasMoreThanOneElement(src.DestinationPortRanges) ? src.DestinationPortRanges : (!string.IsNullOrWhiteSpace(src.DestinationPortRange) ? new List<string> { src.DestinationPortRange } : new List<string>());
                        dest.SourceAddressPrefix = GeneralUtilities.HasMoreThanOneElement(src.SourceAddressPrefixes) ? src.SourceAddressPrefixes : (!string.IsNullOrWhiteSpace(src.SourceAddressPrefix) ? new List<string> { src.SourceAddressPrefix } : new List<string>());
                        dest.DestinationAddressPrefix = GeneralUtilities.HasMoreThanOneElement(src.DestinationAddressPrefixes) ? src.DestinationAddressPrefixes : (!string.IsNullOrWhiteSpace(src.DestinationAddressPrefix) ? new List<string> { src.DestinationAddressPrefix } : new List<string>());
                    });

                // ExpressRoutePortsLocation
                // CNM to MNM
                cfg.CreateMap<CNM.PSExpressRoutePortsLocation, MNM.ExpressRoutePortsLocation>();                
                cfg.CreateMap<CNM.PSExpressRoutePortsLocationBandwidths, MNM.ExpressRoutePortsLocationBandwidths>();

                // MNM to CNM
                cfg.CreateMap<MNM.ExpressRoutePortsLocation, CNM.PSExpressRoutePortsLocation>();
                cfg.CreateMap<MNM.ExpressRoutePortsLocationBandwidths, CNM.PSExpressRoutePortsLocationBandwidths>();

                // ExpressRoutePort
                // CNM to MNM
                cfg.CreateMap<CNM.PSExpressRoutePort, MNM.ExpressRoutePort>();
                cfg.CreateMap<CNM.PSExpressRouteLink, MNM.ExpressRouteLink>();

                // MNM to CNM
                cfg.CreateMap<MNM.ExpressRoutePort, CNM.PSExpressRoutePort>();
                cfg.CreateMap<MNM.ExpressRouteLink, CNM.PSExpressRouteLink>();

                // ExpressRouteCircuit
                // CNM to MNM
                cfg.CreateMap<CNM.PSExpressRouteCircuit, MNM.ExpressRouteCircuit>();
                cfg.CreateMap<CNM.PSServiceProviderProperties, MNM.ExpressRouteCircuitServiceProviderProperties>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitSku, MNM.ExpressRouteCircuitSku>();
                cfg.CreateMap<CNM.PSPeering, MNM.ExpressRouteCircuitPeering>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitAuthorization, MNM.ExpressRouteCircuitAuthorization>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitConnection, MNM.ExpressRouteCircuitConnection>();

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
                cfg.CreateMap<MNM.ExpressRouteCircuitConnection, CNM.PSExpressRouteCircuitConnection>();

                // ExpressRouteCircuitPeering
                // CNM to MNM
                cfg.CreateMap<CNM.PSPeering, MNM.ExpressRouteCircuitPeering>();
                cfg.CreateMap<CNM.PSPeeringConfig, MNM.ExpressRouteCircuitPeeringConfig>();
                cfg.CreateMap<CNM.PSIpv6PeeringConfig, MNM.Ipv6ExpressRouteCircuitPeeringConfig>();

                // MNM to CNM
                cfg.CreateMap<MNM.ExpressRouteCircuitPeering, CNM.PSPeering>();
                cfg.CreateMap<MNM.ExpressRouteCircuitPeeringConfig, CNM.PSPeeringConfig>();
                cfg.CreateMap<MNM.Ipv6ExpressRouteCircuitPeeringConfig, CNM.PSIpv6PeeringConfig>();

                // Express Route Circuit Connection 
                // CNM to MNM
                cfg.CreateMap<CNM.PSExpressRouteCircuitConnection, MNM.ExpressRouteCircuitConnection>();

                // MNM to CNM 
                cfg.CreateMap<MNM.ExpressRouteCircuitConnection, CNM.PSExpressRouteCircuitConnection>();

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

                // ExpressRouteCrossConnection
                // CNM to MNM
                cfg.CreateMap<CNM.PSExpressRouteCrossConnection, MNM.ExpressRouteCrossConnection>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitReference, MNM.ExpressRouteCircuitReference>();
                cfg.CreateMap<CNM.PSExpressRouteCrossConnectionPeering, MNM.ExpressRouteCrossConnectionPeering>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitArpTable, MNM.ExpressRouteCircuitArpTable>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitRoutesTable, MNM.ExpressRouteCircuitRoutesTable>();
                cfg.CreateMap<CNM.PSExpressRouteCrossConnectionRoutesTableSummary, MNM.ExpressRouteCrossConnectionRoutesTableSummary>();

                // MNM to CNM
                cfg.CreateMap<MNM.ExpressRouteCrossConnection, CNM.PSExpressRouteCrossConnection>();
                cfg.CreateMap<MNM.ExpressRouteCircuitReference, CNM.PSExpressRouteCircuitReference>();
                cfg.CreateMap<MNM.ExpressRouteCrossConnectionPeering, CNM.PSExpressRouteCrossConnectionPeering>();

                // ExpressRouteCrossConnectionPeering
                // CNM to MNM
                cfg.CreateMap<CNM.PSExpressRouteCrossConnectionPeering, MNM.ExpressRouteCrossConnectionPeering>();
                cfg.CreateMap<CNM.PSPeeringConfig, MNM.ExpressRouteCircuitPeeringConfig>();
                cfg.CreateMap<CNM.PSIpv6PeeringConfig, MNM.Ipv6ExpressRouteCircuitPeeringConfig>();

                // MNM to CNM
                cfg.CreateMap<MNM.ExpressRouteCrossConnectionPeering, CNM.PSExpressRouteCrossConnectionPeering>();
                cfg.CreateMap<MNM.ExpressRouteCircuitPeeringConfig, CNM.PSPeeringConfig>();
                cfg.CreateMap<MNM.Ipv6ExpressRouteCircuitPeeringConfig, CNM.PSIpv6PeeringConfig>();
                cfg.CreateMap<MNM.ExpressRouteCircuitArpTable, CNM.PSExpressRouteCircuitArpTable>();
                cfg.CreateMap<MNM.ExpressRouteCircuitRoutesTable, CNM.PSExpressRouteCircuitRoutesTable>();
                cfg.CreateMap<MNM.ExpressRouteCrossConnectionRoutesTableSummary, CNM.PSExpressRouteCrossConnectionRoutesTableSummary>();

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
                cfg.CreateMap<CNM.PSVpnClientIPsecParameters, MNM.VpnClientIPsecParameters>();
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
                cfg.CreateMap<MNM.VpnClientIPsecParameters, CNM.PSVpnClientIPsecParameters>();
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
                cfg.CreateMap<CNM.PSApplicationGatewayProbeHealthResponseMatch, MNM.ApplicationGatewayProbeHealthResponseMatch>()
                    .AfterMap((src, dest) => dest.StatusCodes = (src.StatusCodes == null) ? null : dest.StatusCodes);
                cfg.CreateMap<CNM.PSApplicationGatewayProbe, MNM.ApplicationGatewayProbe>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendAddress, MNM.ApplicationGatewayBackendAddress>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendAddressPool, MNM.ApplicationGatewayBackendAddressPool>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendHttpSettings, MNM.ApplicationGatewayBackendHttpSettings>();
                cfg.CreateMap<CNM.PSApplicationGatewayFrontendIPConfiguration, MNM.ApplicationGatewayFrontendIPConfiguration>();
                cfg.CreateMap<CNM.PSApplicationGatewayFrontendPort, MNM.ApplicationGatewayFrontendPort>();
                cfg.CreateMap<CNM.PSApplicationGatewaySslCertificate, MNM.ApplicationGatewaySslCertificate>().ForMember(
                    dest => dest.Password,
                    opt => opt.ResolveUsing(src => src.Password?.ConvertToString()));
                cfg.CreateMap<CNM.PSApplicationGatewayHttpListener, MNM.ApplicationGatewayHttpListener>();
                cfg.CreateMap<CNM.PSApplicationGatewayIPConfiguration, MNM.ApplicationGatewayIPConfiguration>();
                cfg.CreateMap<CNM.PSApplicationGatewayRequestRoutingRule, MNM.ApplicationGatewayRequestRoutingRule>();
                cfg.CreateMap<CNM.PSApplicationGatewayRedirectConfiguration, MNM.ApplicationGatewayRedirectConfiguration>();
                cfg.CreateMap<CNM.PSApplicationGatewayRewriteRuleSet, MNM.ApplicationGatewayRewriteRuleSet>();
                cfg.CreateMap<CNM.PSApplicationGatewayRewriteRule, MNM.ApplicationGatewayRewriteRule>();
                cfg.CreateMap<CNM.PSApplicationGatewayRewriteRuleActionSet, MNM.ApplicationGatewayRewriteRuleActionSet>();
                cfg.CreateMap<CNM.PSApplicationGatewayHeaderConfiguration, MNM.ApplicationGatewayHeaderConfiguration>();
                cfg.CreateMap<CNM.PSApplicationGatewayRewriteRuleCondition, MNM.ApplicationGatewayRewriteRuleCondition>();
                cfg.CreateMap<CNM.PSApplicationGatewayAuthenticationCertificate, MNM.ApplicationGatewayAuthenticationCertificate>();
                cfg.CreateMap<CNM.PSApplicationGatewayTrustedRootCertificate, MNM.ApplicationGatewayTrustedRootCertificate>();
                cfg.CreateMap<CNM.PSBackendAddressPool, MNM.BackendAddressPool>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendHealth, MNM.ApplicationGatewayBackendHealth>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendHealthPool, MNM.ApplicationGatewayBackendHealthPool>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendHealthHttpSettings, MNM.ApplicationGatewayBackendHealthHttpSettings>();
                cfg.CreateMap<CNM.PSApplicationGatewayBackendHealthServer, MNM.ApplicationGatewayBackendHealthServer>();
                cfg.CreateMap<CNM.PSApplicationGatewayWebApplicationFirewallConfiguration, MNM.ApplicationGatewayWebApplicationFirewallConfiguration>();
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallCondition, MNM.MatchCondition>();
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallCustomRule, MNM.WebApplicationFirewallCustomRule>();
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallMatchVariable, MNM.MatchVariable>();
                cfg.CreateMap<CNM.PSApplicationGatewayWebApplicationFirewallPolicy, MNM.WebApplicationFirewallPolicy>();
                cfg.CreateMap<CNM.PSApplicationGatewayConnectionDraining, MNM.ApplicationGatewayConnectionDraining>();
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallDisabledRuleGroup, MNM.ApplicationGatewayFirewallDisabledRuleGroup>()
                    .AfterMap((src, dest) => dest.Rules = (src.Rules == null) ? null : dest.Rules);
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallExclusion, MNM.ApplicationGatewayFirewallExclusion>();
                cfg.CreateMap<CNM.PSApplicationGatewayAvailableWafRuleSetsResult, MNM.ApplicationGatewayAvailableWafRuleSetsResult>();
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallRule, MNM.ApplicationGatewayFirewallRule>();
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallRuleGroup, MNM.ApplicationGatewayFirewallRuleGroup>();
                cfg.CreateMap<CNM.PSApplicationGatewayFirewallRuleSet, MNM.ApplicationGatewayFirewallRuleSet>();
                cfg.CreateMap<CNM.PSApplicationGatewayAvailableSslOptions, MNM.ApplicationGatewayAvailableSslOptions>();
                cfg.CreateMap<CNM.PSApplicationGatewaySslPredefinedPolicy, MNM.ApplicationGatewaySslPredefinedPolicy>();
                cfg.CreateMap<CNM.PSApplicationGatewayAutoscaleConfiguration, MNM.ApplicationGatewayAutoscaleConfiguration>();
                cfg.CreateMap<CNM.PSApplicationGatewayCustomError, MNM.ApplicationGatewayCustomError>();

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
                cfg.CreateMap<MNM.ApplicationGatewayProbeHealthResponseMatch, CNM.PSApplicationGatewayProbeHealthResponseMatch>()
                    .AfterMap((src, dest) => dest.StatusCodes = (src.StatusCodes == null) ? null : dest.StatusCodes);
                cfg.CreateMap<MNM.ApplicationGatewayProbe, CNM.PSApplicationGatewayProbe>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendAddress, CNM.PSApplicationGatewayBackendAddress>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendAddressPool, CNM.PSApplicationGatewayBackendAddressPool>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendHttpSettings, CNM.PSApplicationGatewayBackendHttpSettings>();
                cfg.CreateMap<MNM.ApplicationGatewayFrontendIPConfiguration, CNM.PSApplicationGatewayFrontendIPConfiguration>();
                cfg.CreateMap<MNM.ApplicationGatewaySslCertificate, CNM.PSApplicationGatewaySslCertificate>().ForMember(
                    dest => dest.Password,
                    opt => opt.ResolveUsing(src => src.Password?.ConvertToSecureString()));
                cfg.CreateMap<MNM.ApplicationGatewayFrontendPort, CNM.PSApplicationGatewayFrontendPort>();
                cfg.CreateMap<MNM.ApplicationGatewayHttpListener, CNM.PSApplicationGatewayHttpListener>();
                cfg.CreateMap<MNM.ApplicationGatewayIPConfiguration, CNM.PSApplicationGatewayIPConfiguration>();
                cfg.CreateMap<MNM.ApplicationGatewayRequestRoutingRule, CNM.PSApplicationGatewayRequestRoutingRule>();
                cfg.CreateMap<MNM.ApplicationGatewayRedirectConfiguration, CNM.PSApplicationGatewayRedirectConfiguration>();
                cfg.CreateMap<MNM.ApplicationGatewayRewriteRuleSet, CNM.PSApplicationGatewayRewriteRuleSet>();
                cfg.CreateMap<MNM.ApplicationGatewayRewriteRule, CNM.PSApplicationGatewayRewriteRule>();
                cfg.CreateMap<MNM.ApplicationGatewayRewriteRuleActionSet, CNM.PSApplicationGatewayRewriteRuleActionSet>();
                cfg.CreateMap<MNM.ApplicationGatewayHeaderConfiguration, CNM.PSApplicationGatewayHeaderConfiguration>();
                cfg.CreateMap<MNM.ApplicationGatewayRewriteRuleCondition, CNM.PSApplicationGatewayRewriteRuleCondition>();
                cfg.CreateMap<MNM.ApplicationGatewayAuthenticationCertificate, CNM.PSApplicationGatewayAuthenticationCertificate>();
                cfg.CreateMap<MNM.ApplicationGatewayTrustedRootCertificate, CNM.PSApplicationGatewayTrustedRootCertificate>();
                cfg.CreateMap<MNM.BackendAddressPool, CNM.PSBackendAddressPool>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendHealth, CNM.PSApplicationGatewayBackendHealth>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendHealthPool, CNM.PSApplicationGatewayBackendHealthPool>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendHealthHttpSettings, CNM.PSApplicationGatewayBackendHealthHttpSettings>();
                cfg.CreateMap<MNM.ApplicationGatewayBackendHealthServer, CNM.PSApplicationGatewayBackendHealthServer>();
                cfg.CreateMap<MNM.ApplicationGatewayWebApplicationFirewallConfiguration, CNM.PSApplicationGatewayWebApplicationFirewallConfiguration>();
                cfg.CreateMap<MNM.MatchCondition, CNM.PSApplicationGatewayFirewallCondition>();
                cfg.CreateMap<MNM.WebApplicationFirewallCustomRule, CNM.PSApplicationGatewayFirewallCustomRule>();
                cfg.CreateMap<MNM.MatchVariable, CNM.PSApplicationGatewayFirewallMatchVariable>();
                cfg.CreateMap<MNM.WebApplicationFirewallPolicy, CNM.PSApplicationGatewayWebApplicationFirewallPolicy>();
                cfg.CreateMap<MNM.ApplicationGatewayConnectionDraining, CNM.PSApplicationGatewayConnectionDraining>();
                cfg.CreateMap<MNM.ApplicationGatewayFirewallDisabledRuleGroup, CNM.PSApplicationGatewayFirewallDisabledRuleGroup>()
                    .AfterMap((src, dest) => dest.Rules = (src.Rules == null) ? null : dest.Rules);
                cfg.CreateMap<MNM.ApplicationGatewayFirewallExclusion, CNM.PSApplicationGatewayFirewallExclusion>();
                cfg.CreateMap<MNM.ApplicationGatewayAvailableWafRuleSetsResult, CNM.PSApplicationGatewayAvailableWafRuleSetsResult>();
                cfg.CreateMap<MNM.ApplicationGatewayFirewallRule, CNM.PSApplicationGatewayFirewallRule>();
                cfg.CreateMap<MNM.ApplicationGatewayFirewallRuleGroup, CNM.PSApplicationGatewayFirewallRuleGroup>();
                cfg.CreateMap<MNM.ApplicationGatewayFirewallRuleSet, CNM.PSApplicationGatewayFirewallRuleSet>();
                cfg.CreateMap<MNM.ApplicationGatewayAvailableSslOptions, CNM.PSApplicationGatewayAvailableSslOptions>();
                cfg.CreateMap<MNM.ApplicationGatewaySslPredefinedPolicy, CNM.PSApplicationGatewaySslPredefinedPolicy>();
                cfg.CreateMap<MNM.ApplicationGatewayAutoscaleConfiguration, CNM.PSApplicationGatewayAutoscaleConfiguration>();
                cfg.CreateMap<MNM.ApplicationGatewayCustomError, CNM.PSApplicationGatewayCustomError>();

                // Application Security Groups
                // CNM to MNM
                cfg.CreateMap<CNM.PSApplicationSecurityGroup, MNM.ApplicationSecurityGroup>();

                // MNM to CNM
                cfg.CreateMap<MNM.ApplicationSecurityGroup, CNM.PSApplicationSecurityGroup>();

                //// DDoS protection plan

                // CNM to MNM
                cfg.CreateMap<CNM.PSDdosProtectionPlan, MNM.DdosProtectionPlan>();

                // MNM to CNM
                cfg.CreateMap<MNM.DdosProtectionPlan, CNM.PSDdosProtectionPlan>();

                // Service Endpoint Policy
                // CNM to MNM
                cfg.CreateMap<CNM.PSServiceEndpointPolicy, MNM.ServiceEndpointPolicy>();

                // MNM to CNM
                cfg.CreateMap<MNM.ServiceEndpointPolicy, CNM.PSServiceEndpointPolicy>();

                // Service Endpoint Policy Definition
                // CNM to MNM
                cfg.CreateMap<CNM.PSServiceEndpointPolicyDefinition, MNM.ServiceEndpointPolicyDefinition>();

                // MNM to CNM
                cfg.CreateMap<MNM.ServiceEndpointPolicyDefinition, CNM.PSServiceEndpointPolicyDefinition>();

                // Network Profile
                // MNM to CNM
                cfg.CreateMap<MNM.ContainerNetworkInterfaceIpConfiguration, CNM.PSContainerNetworkInterfaceIPConfiguration>();
                cfg.CreateMap<MNM.NetworkProfile, CNM.PSNetworkProfile>();
                cfg.CreateMap<MNM.ContainerNetworkInterface, CNM.PSContainerNetworkInterface>();
                cfg.CreateMap<MNM.Container, CNM.PSContainer>();
                cfg.CreateMap<MNM.ContainerNetworkInterfaceConfiguration, CNM.PSContainerNetworkInterfaceConfiguration>();
                cfg.CreateMap<MNM.IPConfigurationProfile, CNM.PSIPConfigurationProfile>();

                // CNM to MNM
                cfg.CreateMap<CNM.PSNetworkProfile, MNM.NetworkProfile>();
                cfg.CreateMap<CNM.PSContainerNetworkInterface, MNM.ContainerNetworkInterface>();
                cfg.CreateMap<CNM.PSContainerNetworkInterfaceIPConfiguration, MNM.ContainerNetworkInterfaceIpConfiguration>();
                cfg.CreateMap<CNM.PSContainer, MNM.Container>();
                cfg.CreateMap<CNM.PSContainerNetworkInterfaceConfiguration, MNM.ContainerNetworkInterfaceConfiguration>();
                cfg.CreateMap<CNM.PSIPConfigurationProfile, MNM.IPConfigurationProfile>();

                //// SDWAN
                cfg.CreateMap<CNM.PSVirtualHub, MNM.VirtualHub>();
                cfg.CreateMap<CNM.PSVirtualHubId, MNM.VirtualHubId>();
                cfg.CreateMap<CNM.PSVirtualWan, MNM.VirtualWAN>();
                cfg.CreateMap<CNM.PSHubVirtualNetworkConnection, MNM.HubVirtualNetworkConnection>();
                cfg.CreateMap<CNM.PSVirtualHubRouteTable, MNM.VirtualHubRouteTable>();
                cfg.CreateMap<CNM.PSVirtualHubRoute, MNM.VirtualHubRoute>();
                cfg.CreateMap<CNM.PSVpnGateway, MNM.VpnGateway>();
                cfg.CreateMap<CNM.PSVpnConnection, MNM.VpnConnection>();
                cfg.CreateMap<CNM.PSVpnSite, MNM.VpnSite>().AfterMap((src, dest) =>
                {
                    if (src.BgpSettings != null)
                    {
                        dest.BgpProperties = new MNM.BgpSettings(src.BgpSettings.Asn, src.BgpSettings.BgpPeeringAddress, src.BgpSettings.PeerWeight);
                    }
                });

                cfg.CreateMap<CNM.PSVpnSiteDeviceProperties, MNM.DeviceProperties>();
                cfg.CreateMap<CNM.PSExpressRouteGateway, MNM.ExpressRouteGateway>();
                cfg.CreateMap<CNM.PSExpressRouteConnection, MNM.ExpressRouteConnection>();
                cfg.CreateMap<CNM.PSExpressRouteGatewayAutoscaleConfiguration, MNM.ExpressRouteGatewayPropertiesAutoScaleConfiguration>();
                cfg.CreateMap<CNM.PSExpressRouteGatewayPropertiesAutoScaleConfigurationBounds, MNM.ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds>();
                cfg.CreateMap<CNM.PSExpressRouteCircuitPeeringId, MNM.ExpressRouteCircuitPeeringId>();

                cfg.CreateMap<MNM.VirtualWAN, CNM.PSVirtualWan>();
                cfg.CreateMap<MNM.VirtualHub, CNM.PSVirtualHub>();
                cfg.CreateMap<MNM.VirtualHubId, CNM.PSVirtualHubId>();
                cfg.CreateMap<MNM.HubVirtualNetworkConnection, CNM.PSHubVirtualNetworkConnection>();
                cfg.CreateMap<MNM.VirtualHubRouteTable, CNM.PSVirtualHubRouteTable>();
                cfg.CreateMap<MNM.VirtualHubRoute, CNM.PSVirtualHubRoute>();
                cfg.CreateMap<MNM.VpnGateway, CNM.PSVpnGateway>();
                cfg.CreateMap<MNM.VpnConnection, CNM.PSVpnConnection>();
                cfg.CreateMap<MNM.VpnSite, CNM.PSVpnSite>().AfterMap((src, dest) =>
                {
                    if (src.BgpProperties != null)
                    {
                        dest.BgpSettings = new CNM.PSBgpSettings()
                        {
                            Asn = src.BgpProperties.Asn,
                            BgpPeeringAddress = src.BgpProperties.BgpPeeringAddress,
                            PeerWeight = src.BgpProperties.PeerWeight
                        };
                    }
                });

                cfg.CreateMap<MNM.DeviceProperties, CNM.PSVpnSiteDeviceProperties>();
                cfg.CreateMap<MNM.ExpressRouteGateway, CNM.PSExpressRouteGateway>();
                cfg.CreateMap<MNM.ExpressRouteConnection, CNM.PSExpressRouteConnection>();
                cfg.CreateMap<MNM.ExpressRouteGatewayPropertiesAutoScaleConfiguration, CNM.PSExpressRouteGatewayAutoscaleConfiguration>();
                cfg.CreateMap<MNM.ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds, CNM.PSExpressRouteGatewayPropertiesAutoScaleConfigurationBounds>();
                cfg.CreateMap<MNM.ExpressRouteCircuitPeeringId, CNM.PSExpressRouteCircuitPeeringId>();

                // Azure Firewalls
                // CNM to MNM
                cfg.CreateMap<CNM.PSAzureFirewall, MNM.AzureFirewall>();
                cfg.CreateMap<CNM.PSAzureFirewallIpConfiguration, MNM.AzureFirewallIPConfiguration>();
                cfg.CreateMap<CNM.PSAzureFirewallApplicationRuleCollection, MNM.AzureFirewallApplicationRuleCollection>();
                cfg.CreateMap<CNM.PSAzureFirewallNatRuleCollection, MNM.AzureFirewallNatRuleCollection>();
                cfg.CreateMap<CNM.PSAzureFirewallNetworkRuleCollection, MNM.AzureFirewallNetworkRuleCollection>();
                cfg.CreateMap<CNM.PSAzureFirewallApplicationRule, MNM.AzureFirewallApplicationRule>();
                cfg.CreateMap<CNM.PSAzureFirewallNatRule, MNM.AzureFirewallNatRule>();
                cfg.CreateMap<CNM.PSAzureFirewallNetworkRule, MNM.AzureFirewallNetworkRule>();
                cfg.CreateMap<CNM.PSAzureFirewallNatRCAction, MNM.AzureFirewallNatRCAction>();
                cfg.CreateMap<CNM.PSAzureFirewallRCAction, MNM.AzureFirewallRCAction>();
                cfg.CreateMap<CNM.PSAzureFirewallApplicationRuleProtocol, MNM.AzureFirewallApplicationRuleProtocol>();

                // MNM to CNM
                cfg.CreateMap<MNM.AzureFirewall, CNM.PSAzureFirewall>();
                cfg.CreateMap<MNM.AzureFirewallIPConfiguration, CNM.PSAzureFirewallIpConfiguration>();
                cfg.CreateMap<MNM.AzureFirewallApplicationRuleCollection, CNM.PSAzureFirewallApplicationRuleCollection>();
                cfg.CreateMap<MNM.AzureFirewallNatRuleCollection, CNM.PSAzureFirewallNatRuleCollection>();
                cfg.CreateMap<MNM.AzureFirewallNetworkRuleCollection, CNM.PSAzureFirewallNetworkRuleCollection>();
                cfg.CreateMap<MNM.AzureFirewallApplicationRule, CNM.PSAzureFirewallApplicationRule>();
                cfg.CreateMap<MNM.AzureFirewallNatRule, CNM.PSAzureFirewallNatRule>();
                cfg.CreateMap<MNM.AzureFirewallNetworkRule, CNM.PSAzureFirewallNetworkRule>();
                cfg.CreateMap<MNM.AzureFirewallNatRCAction, CNM.PSAzureFirewallNatRCAction>();
                cfg.CreateMap<MNM.AzureFirewallRCAction, CNM.PSAzureFirewallRCAction>();
                cfg.CreateMap<MNM.AzureFirewallApplicationRuleProtocol, CNM.PSAzureFirewallApplicationRuleProtocol>();

                // Azure Firewall FQDN Tags
                // CNM to MNM
                cfg.CreateMap<CNM.PSAzureFirewallFqdnTag, MNM.AzureFirewallFqdnTag>();

                // MNM to CNM
                cfg.CreateMap<MNM.AzureFirewallFqdnTag, CNM.PSAzureFirewallFqdnTag>();

                // Interface endpoint
                // CNM to MNM
                cfg.CreateMap<CNM.PSInterfaceEndpoint, MNM.InterfaceEndpoint>();

                // MNM to CNM
                cfg.CreateMap<MNM.InterfaceEndpoint, CNM.PSInterfaceEndpoint>();

                // CNM to MNM
                cfg.CreateMap<CNM.PSEndpointService, MNM.EndpointService>();

                // MNM to CNM
                cfg.CreateMap<MNM.EndpointService, CNM.PSEndpointService>();

                // Virtual Network Tap
                // CNM to MNM
                cfg.CreateMap<CNM.PSVirtualNetworkTap, MNM.VirtualNetworkTap>();

                // MNM to CNM
                cfg.CreateMap<MNM.VirtualNetworkTap, CNM.PSVirtualNetworkTap>();
            });

            _mapper = config.CreateMapper();
        }
    }
}