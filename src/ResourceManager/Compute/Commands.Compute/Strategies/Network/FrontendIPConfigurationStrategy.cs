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

using Microsoft.Azure.Commands.Common.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;

namespace Microsoft.Azure.Commands.Common.Strategies.Network
{
    static class FrontendIPConfigurationStrategy
    {
        public static NestedResourceStrategy<FrontendIPConfiguration, LoadBalancer> Strategy { get; }
            = NestedResourceStrategy.Create<FrontendIPConfiguration, LoadBalancer>(
        provider: "frontendIPConfigurations",
        get: (lb, name) => lb.FrontendIPConfigurations?.FirstOrDefault(s => s?.Name == name),
        createOrUpdate: (lb, name, frontendIpConfiguration) =>
        {
            frontendIpConfiguration.Name = name;
            if (lb.FrontendIPConfigurations == null)
            {
                lb.FrontendIPConfigurations = new List<FrontendIPConfiguration> { frontendIpConfiguration };
                return;
            }
            var f = lb
                .FrontendIPConfigurations
                .Select((fn, i) => new { fn, i })
                .FirstOrDefault(p => p.fn.Name == name);

            if (f != null)
            {
                lb.FrontendIPConfigurations[f.i] = frontendIpConfiguration;
                return;
            }
            lb.FrontendIPConfigurations.Add(frontendIpConfiguration);
        });

        public static NestedResourceConfig<FrontendIPConfiguration, LoadBalancer> CreateFrontendIPConfiguration(
            this ResourceConfig<LoadBalancer> loadBalancer, 
            string name,
            IList<string> zones,
            ResourceConfig<PublicIPAddress> publicIPAddress,
            NestedResourceConfig<Subnet, VirtualNetwork> subnet)
                => Strategy.CreateConfig(
                    parent: loadBalancer,
                    name: name,
                    createModel: subscriptionId => {

                        var frontEndConfig = CreateFrontendIpConfig(
                                froontendPoolName: name,
                                subscriptionId: subscriptionId,
                                subnetId: subnet.GetId(subscriptionId).IdToString(),
                                publicIpAddressId: publicIPAddress.GetId(subscriptionId).IdToString(),
                                privateIpAddress: null,
                                zones: zones);

                        return frontEndConfig;
                    });

        internal static FrontendIPConfiguration CreateFrontendIpConfig(
            string froontendPoolName,
            string subscriptionId,
            string subnetId,
            string publicIpAddressId,
            string privateIpAddress,
            IList<string> zones)
        {
            var frontendIpConfig = new FrontendIPConfiguration();
            frontendIpConfig.Name = froontendPoolName;
            frontendIpConfig.Zones = zones;

            if (!string.IsNullOrEmpty(subnetId))
            {
                frontendIpConfig.Subnet = new Subnet(subnetId);

                if (!string.IsNullOrEmpty(privateIpAddress))
                {
                    frontendIpConfig.PrivateIPAddress = privateIpAddress;
                    frontendIpConfig.PrivateIPAllocationMethod = LoadBalancerStrategy.Static;
                }
                else
                {
                    frontendIpConfig.PrivateIPAllocationMethod = LoadBalancerStrategy.Dynamic;
                }
            }
            else if (!string.IsNullOrEmpty(publicIpAddressId))
            {
                frontendIpConfig.PublicIPAddress = new PublicIPAddress(publicIpAddressId);
            }

            frontendIpConfig.Id =
                LoadBalancerStrategy.GetResourceNotSetId(
                    subscriptionId,
                    LoadBalancerStrategy.LoadBalancerFrontendIpConfigName,
                    frontendIpConfig.Name);

            return frontendIpConfig;
        }
    }
}
