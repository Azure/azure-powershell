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

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using AutoMapper;
    using CNM = Microsoft.Azure.Commands.NetworkResourceProvider.Models;
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
            Mapper.CreateMap<CNM.PSSubnetProperties, MNM.SubnetProperties>();
            Mapper.CreateMap<CNM.PSSubnet, MNM.Subnet>();

            // MNM to CNM
            Mapper.CreateMap<MNM.DhcpOptions, CNM.PSDhcpOptions>();
            Mapper.CreateMap<MNM.SubnetProperties, CNM.PSSubnetProperties>();
            Mapper.CreateMap<MNM.Subnet, CNM.PSSubnet>();

            // VirtualNetwork
            // CNM to MNM
            Mapper.CreateMap<CNM.PSAddressSpace, MNM.AddressSpace>();
            Mapper.CreateMap<CNM.PSVirtualNetworkProperties, MNM.VirtualNetworkProperties>();
            Mapper.CreateMap<CNM.PSVirtualNetwork, MNM.VirtualNetworkCreateOrUpdateParameters>();

            // MNM to CNM
            Mapper.CreateMap<MNM.AddressSpace, CNM.PSAddressSpace>();
            Mapper.CreateMap<MNM.VirtualNetworkProperties, CNM.PSVirtualNetworkProperties>();
            Mapper.CreateMap<MNM.VirtualNetwork, CNM.PSVirtualNetwork>();

            // PublicIpAddress
            // CNM to MNM
            Mapper.CreateMap<CNM.PSPublicIpAddress, MNM.PublicIpAddressCreateOrUpdateParameters>();
            Mapper.CreateMap<CNM.PSPublicIpAddressProperties, MNM.PublicIpAddressProperties>();
            Mapper.CreateMap<CNM.PSPublicIpAddressDnsSettings, MNM.PublicIpAddressDnsSettings>();

            // MNM to CNM
            Mapper.CreateMap<MNM.PublicIpAddress, CNM.PSPublicIpAddress>();
            Mapper.CreateMap<MNM.PublicIpAddressProperties, CNM.PSPublicIpAddressProperties>();
            Mapper.CreateMap<MNM.PublicIpAddressDnsSettings, CNM.PSPublicIpAddressDnsSettings>();

            // NetworkInterface
            // CNM to MNM
            Mapper.CreateMap<CNM.PSNetworkInterface, MNM.NetworkInterfaceCreateOrUpdateParameters>();
            Mapper.CreateMap<CNM.PSNetworkInterfaceProperties, MNM.NetworkInterfaceProperties>();
            Mapper.CreateMap<CNM.PSDnsSettings, MNM.DnsSettings>();
            Mapper.CreateMap<CNM.PSNetworkInterfaceIpConfiguration, MNM.NetworkInterfaceIpConfiguration>();
            Mapper.CreateMap<CNM.PSNetworkInterfaceIpConfigurationProperties, MNM.NetworkInterfaceIpConfigurationProperties>();

            // MNM to CNM
            Mapper.CreateMap<MNM.NetworkInterface, CNM.PSNetworkInterface>();
            Mapper.CreateMap<MNM.NetworkInterfaceProperties, CNM.PSNetworkInterfaceProperties>();
            Mapper.CreateMap<MNM.DnsSettings, CNM.PSDnsSettings>();
            Mapper.CreateMap<MNM.NetworkInterfaceIpConfiguration, CNM.PSNetworkInterfaceIpConfiguration>();
            Mapper.CreateMap<MNM.NetworkInterfaceIpConfigurationProperties, CNM.PSNetworkInterfaceIpConfigurationProperties>();

            // LoadBalancer
            // CNM to MNM
            Mapper.CreateMap<CNM.PSLoadBalancer, MNM.LoadBalancerCreateOrUpdateParameters>();
            Mapper.CreateMap<CNM.PSLoadBalancerProperties, MNM.LoadBalancerProperties>();
            
            // MNM to CNM
            Mapper.CreateMap<MNM.LoadBalancer, CNM.PSLoadBalancer>();
            Mapper.CreateMap<MNM.LoadBalancerProperties, CNM.PSLoadBalancerProperties>();
            
            // FrontendIpConfiguration
            // CNM to MNM
            Mapper.CreateMap<CNM.PSFrontendIpConfiguration, MNM.FrontendIpConfiguration>();
            Mapper.CreateMap<CNM.PSFrontendIpConfigurationProperties, MNM.FrontendIpConfigurationProperties>();

            // MNM to CNM
            Mapper.CreateMap<MNM.FrontendIpConfiguration, CNM.PSFrontendIpConfiguration>();
            Mapper.CreateMap<MNM.FrontendIpConfigurationProperties, CNM.PSFrontendIpConfigurationProperties>();

            // BackendAddressPool
            // CNM to MNM
            Mapper.CreateMap<CNM.PSBackendAddressPool, MNM.BackendAddressPool>();
            Mapper.CreateMap<CNM.PSBackendAddressPoolProperties, MNM.BackendAddressPoolProperties>();

            // MNM to CNM
            Mapper.CreateMap<MNM.BackendAddressPool, CNM.PSBackendAddressPool>();
            Mapper.CreateMap<MNM.BackendAddressPoolProperties, CNM.PSBackendAddressPoolProperties>();

            // LoadBalancingRule
            // CNM to MNM
            Mapper.CreateMap<CNM.PSLoadBalancingRule, MNM.LoadBalancingRule>();
            Mapper.CreateMap<CNM.PSLoadBalancingRuleProperties, MNM.LoadBalancingRuleProperties>();

            // MNM to CNM
            Mapper.CreateMap<MNM.LoadBalancingRule, CNM.PSLoadBalancingRule>();
            Mapper.CreateMap<MNM.LoadBalancingRuleProperties, CNM.PSLoadBalancingRuleProperties>();

            // Probes
            // CNM to MNM
            Mapper.CreateMap<CNM.PSProbe, MNM.Probe>();
            Mapper.CreateMap<CNM.PSProbeProperties, MNM.ProbeProperties>();

            // MNM to CNM
            Mapper.CreateMap<MNM.Probe, CNM.PSProbe>();
            Mapper.CreateMap<MNM.ProbeProperties, CNM.PSProbeProperties>();

            // InboundNatRules
            // CNM to MNM
            Mapper.CreateMap<CNM.PSInboundNatRule, MNM.InboundNatRule>();
            Mapper.CreateMap<CNM.PSInboundNatRuleProperties, MNM.InboundNatRuleProperties>();

            // MNM to CNM
            Mapper.CreateMap<MNM.InboundNatRule, CNM.PSInboundNatRule>();
            Mapper.CreateMap<MNM.InboundNatRuleProperties, CNM.PSInboundNatRuleProperties>();

            // NetworkSecurityGroups
            // CNM to MNM
            Mapper.CreateMap<CNM.PSNetworkSecurityGroup, MNM.NetworkSecurityGroupCreateOrUpdateParameters>();
            Mapper.CreateMap<CNM.PSNetworkSecurityGroupProperties, MNM.NetworkSecurityGroupProperties>();

            // MNM to CNM
            Mapper.CreateMap<MNM.NetworkSecurityGroup, CNM.PSNetworkSecurityGroup>();
            Mapper.CreateMap<MNM.NetworkSecurityGroupProperties, CNM.PSNetworkSecurityGroupProperties>();

            // NetworkSecrityRule
            // CNM to MNM
            Mapper.CreateMap<CNM.PSSecurityRule, MNM.SecurityRule>();
            Mapper.CreateMap<CNM.PSSecurityRuleProperties, MNM.SecurityRuleProperties>();

            // MNM to CNM
            Mapper.CreateMap<MNM.SecurityRule, CNM.PSSecurityRule>();
            Mapper.CreateMap<MNM.SecurityRuleProperties, CNM.PSSecurityRuleProperties>();
        }
    }
}