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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using AutoMapper;
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
            Mapper.CreateMap<CNM.PSResourceId, MNM.ResourceId>();
            Mapper.CreateMap<MNM.ResourceId, CNM.PSResourceId>();

            // Subnet
            // CNM to MNM
            Mapper.CreateMap<CNM.PSDhcpOptions, MNM.DhcpOptions>();
            Mapper.CreateMap<CNM.PSSubnet, MNM.Subnet>();

            // MNM to CNM
            Mapper.CreateMap<MNM.DhcpOptions, CNM.PSDhcpOptions>();
            Mapper.CreateMap<MNM.Subnet, CNM.PSSubnet>();

            // VirtualNetwork
            // CNM to MNM
            Mapper.CreateMap<CNM.PSAddressSpace, MNM.AddressSpace>();
            Mapper.CreateMap<CNM.PSVirtualNetwork, MNM.VirtualNetwork>();

            // MNM to CNM
            Mapper.CreateMap<MNM.AddressSpace, CNM.PSAddressSpace>();
            Mapper.CreateMap<MNM.VirtualNetwork, CNM.PSVirtualNetwork>();

            // PublicIpAddress
            // CNM to MNM
            Mapper.CreateMap<CNM.PSPublicIpAddress, MNM.PublicIpAddress>();
            Mapper.CreateMap<CNM.PSPublicIpAddressDnsSettings, MNM.PublicIpAddressDnsSettings>();

            // MNM to CNM
            Mapper.CreateMap<MNM.PublicIpAddress, CNM.PSPublicIpAddress>();
            Mapper.CreateMap<MNM.PublicIpAddressDnsSettings, CNM.PSPublicIpAddressDnsSettings>();

            // NetworkInterface
            // CNM to MNM
            Mapper.CreateMap<CNM.PSNetworkInterface, MNM.NetworkInterface>();
            Mapper.CreateMap<CNM.PSNetworkInterfaceDnsSettings, MNM.NetworkInterfaceDnsSettings>();
            Mapper.CreateMap<CNM.PSNetworkInterfaceIpConfiguration, MNM.NetworkInterfaceIpConfiguration>();

            // MNM to CNM
            Mapper.CreateMap<MNM.NetworkInterface, CNM.PSNetworkInterface>();
            Mapper.CreateMap<MNM.NetworkInterfaceDnsSettings, CNM.PSNetworkInterfaceDnsSettings>();
            Mapper.CreateMap<MNM.NetworkInterfaceIpConfiguration, CNM.PSNetworkInterfaceIpConfiguration>();

            // LoadBalancer
            // CNM to MNM
            Mapper.CreateMap<CNM.PSLoadBalancer, MNM.LoadBalancer>();
            
            // MNM to CNM
            Mapper.CreateMap<MNM.LoadBalancer, CNM.PSLoadBalancer>();
            
            // FrontendIpConfiguration
            // CNM to MNM
            Mapper.CreateMap<CNM.PSFrontendIPConfiguration, MNM.FrontendIpConfiguration>();

            // MNM to CNM
            Mapper.CreateMap<MNM.FrontendIpConfiguration, CNM.PSFrontendIPConfiguration>();

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

            // Gateways
            // CNM to MNM
            Mapper.CreateMap<CNM.PSVirtualNetworkGateway, MNM.VirtualNetworkGateway>();
            Mapper.CreateMap<CNM.PSConnectionResetSharedKey, MNM.ConnectionResetSharedKey>();
            Mapper.CreateMap<CNM.PSConnectionSharedKey, MNM.ConnectionSharedKey>();
            Mapper.CreateMap<CNM.PSLocalNetworkGateway, MNM.LocalNetworkGateway>();
            Mapper.CreateMap<CNM.PSVirtualNetworkGatewayConnection, MNM.VirtualNetworkGatewayConnection>();
            Mapper.CreateMap<CNM.PSVirtualNetworkGatewayIpConfiguration, MNM.VirtualNetworkGatewayIpConfiguration>();

            // MNM to CNM
            Mapper.CreateMap<MNM.VirtualNetworkGateway, CNM.PSVirtualNetworkGateway>();
            Mapper.CreateMap<MNM.ConnectionResetSharedKey, CNM.PSConnectionResetSharedKey>();
            Mapper.CreateMap<MNM.ConnectionSharedKey, CNM.PSConnectionSharedKey>();
            Mapper.CreateMap<MNM.LocalNetworkGateway, CNM.PSLocalNetworkGateway>();
            Mapper.CreateMap<MNM.VirtualNetworkGatewayConnection, CNM.PSVirtualNetworkGatewayConnection>();
            Mapper.CreateMap<MNM.VirtualNetworkGatewayIpConfiguration, CNM.PSVirtualNetworkGatewayIpConfiguration>();

            //Application Gateways
            //CNM to MNM
            Mapper.CreateMap<CNM.PSApplicationGateway, MNM.ApplicationGateway>();
            Mapper.CreateMap<CNM.PSApplicationGatewaySku, MNM.ApplicationGatewaySku>();
            Mapper.CreateMap<CNM.PSApplicationGatewayBackendAddress, MNM.ApplicationGatewayBackendAddress>();
            Mapper.CreateMap<CNM.PSApplicationGatewayBackendAddressPool, MNM.ApplicationGatewayBackendAddressPool>();
            Mapper.CreateMap<CNM.PSApplicationGatewayBackendHttpSettings, MNM.ApplicationGatewayBackendHttpSettings>();
            Mapper.CreateMap<CNM.PSApplicationGatewayFrontendIPConfiguration, MNM.ApplicationGatewayFrontendIPConfiguration>();
            Mapper.CreateMap<CNM.PSApplicationGatewayFrontendPort, MNM.ApplicationGatewayFrontendPort>();
            Mapper.CreateMap<CNM.PSApplicationGatewayHttpListener, MNM.ApplicationGatewayHttpListener>();
            Mapper.CreateMap<CNM.PSApplicationGatewayIPConfiguration, MNM.ApplicationGatewayIPConfiguration>();
            Mapper.CreateMap<CNM.PSApplicationGatewayRequestRoutingRule, MNM.ApplicationGatewayRequestRoutingRule>();
            Mapper.CreateMap<CNM.PSApplicationGatewaySslCertificate, MNM.ApplicationGatewaySslCertificate>();
            Mapper.CreateMap<CNM.PSBackendAddressPool, MNM.BackendAddressPool>();

            //MNM to CNM
            Mapper.CreateMap<MNM.ApplicationGateway, CNM.PSApplicationGateway>();
            Mapper.CreateMap<MNM.ApplicationGatewaySku, CNM.PSApplicationGatewaySku>();
            Mapper.CreateMap<MNM.ApplicationGatewayBackendAddress, CNM.PSApplicationGatewayBackendAddress>();
            Mapper.CreateMap<MNM.ApplicationGatewayBackendAddressPool, CNM.PSApplicationGatewayBackendAddressPool>();
            Mapper.CreateMap<MNM.ApplicationGatewayBackendHttpSettings, CNM.PSApplicationGatewayBackendHttpSettings>();
            Mapper.CreateMap<MNM.ApplicationGatewayFrontendIPConfiguration, CNM.PSApplicationGatewayFrontendIPConfiguration>();
            Mapper.CreateMap<MNM.ApplicationGatewayFrontendPort, CNM.PSApplicationGatewayFrontendPort>();
            Mapper.CreateMap<MNM.ApplicationGatewayHttpListener, CNM.PSApplicationGatewayHttpListener>();
            Mapper.CreateMap<MNM.ApplicationGatewayIPConfiguration, CNM.PSApplicationGatewayIPConfiguration>();
            Mapper.CreateMap<MNM.ApplicationGatewayRequestRoutingRule, CNM.PSApplicationGatewayRequestRoutingRule>();
            Mapper.CreateMap<MNM.ApplicationGatewaySslCertificate, CNM.PSApplicationGatewaySslCertificate>();
            Mapper.CreateMap<MNM.BackendAddressPool, CNM.PSBackendAddressPool>();
        }
    }
}