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
using System.Collections.Generic;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies.Network
{
    static class FrontendIPConfigurationStrategy
    {
        public static NestedResourceStrategy<FrontendIPConfiguration, LoadBalancer> Strategy { get; }
            = NestedResourceStrategy.Create<FrontendIPConfiguration, LoadBalancer>(
                provider: "frontendIPConfigurations",
                getList: parentModel => parentModel.FrontendIPConfigurations,
                setList: (parentModel, list) => parentModel.FrontendIPConfigurations = list,
                getName: model => model.Name,
                setName: (model, name) => model.Name = name);

        public static NestedResourceConfig<FrontendIPConfiguration, LoadBalancer> CreateFrontendIPConfiguration(
            this ResourceConfig<LoadBalancer> loadBalancer,
            string name,
            IList<string> zones,
            ResourceConfig<PublicIPAddress> publicIPAddress,
            NestedResourceConfig<Subnet, VirtualNetwork> subnet)
                => loadBalancer.CreateNested(
                    strategy: Strategy,
                    name: name,
                    createModel: engine => CreateFrontendIpConfig(
                        froontendPoolName: name,
                        engine: engine,
                        subnet: subnet,
                        publicIpAddress: publicIPAddress,
                        privateIpAddress: null,
                        zones: zones));

        internal static FrontendIPConfiguration CreateFrontendIpConfig(
            string froontendPoolName,
            IEngine engine,
            NestedResourceConfig<Subnet, VirtualNetwork> subnet,
            ResourceConfig<PublicIPAddress> publicIpAddress,
            string privateIpAddress,
            IList<string> zones)
        {
            var frontendIpConfig = new FrontendIPConfiguration
            {
                Zones = zones
            };

            if (subnet != null)
            {
                frontendIpConfig.Subnet = new Subnet { Id = engine.GetId(subnet) };

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
            else if (publicIpAddress != null)
            {
                frontendIpConfig.PublicIPAddress = new PublicIPAddress
                {
                    Id = engine.GetId(publicIpAddress)
                };
            }

            return frontendIpConfig;
        }
    }
}
