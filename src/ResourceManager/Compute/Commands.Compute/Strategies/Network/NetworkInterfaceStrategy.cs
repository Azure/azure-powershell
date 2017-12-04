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

using Microsoft.Azure.Management.Internal.Network.Version2017_03_01;
using Microsoft.Azure.Management.Internal.Network.Version2017_03_01.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.Common.Strategies.Network
{
    public static class NetworkInterfaceStrategy
    {
        public static ResourceStrategy<NetworkInterface> Strategy { get; }
            = NetworkStrategy.Create(
                "network interface",
                "networkInterfaces",
                client => client.NetworkInterfaces,
                (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                _ => 5);

        public static ResourceConfig<NetworkInterface> CreateNetworkInterfaceConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            NestedResourceConfig<Subnet, VirtualNetwork> subnet,
            ResourceConfig<PublicIPAddress> publicIPAddress,
            ResourceConfig<NetworkSecurityGroup> networkSecurityGroup = null)
            => Strategy.CreateConfig(
                resourceGroup,
                name,
                subscription => new NetworkInterface
                {
                    IpConfigurations = new []
                    {
                        new NetworkInterfaceIPConfiguration
                        {
                            Name = name,
                            Subnet = new Subnet { Id = subnet.GetId(subscription).IdToString() },
                            PublicIPAddress = new PublicIPAddress
                            {
                                Id = publicIPAddress.GetId(subscription).IdToString()
                            }
                        }
                    },
                    NetworkSecurityGroup = networkSecurityGroup == null 
                        ? null 
                        : new NetworkSecurityGroup
                        {
                            Id = networkSecurityGroup.GetId(subscription).IdToString()
                        }
                },
                new IEntityConfig[] { subnet, publicIPAddress, networkSecurityGroup });
    }
}
