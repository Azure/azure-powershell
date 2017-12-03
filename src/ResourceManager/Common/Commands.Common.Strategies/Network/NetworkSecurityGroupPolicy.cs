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

using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.Network
{
    public static class NetworkSecurityGroupStrategy
    {
        public static ResourceStrategy<NetworkSecurityGroup> Strategy { get; }
            = NetworkStrategy.Create(
                "network security group",
                "networkSecurityGroups",
                client => client.NetworkSecurityGroups,
                (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                _ => 15);

        public static ResourceConfig<NetworkSecurityGroup> CreateNetworkSecurityGroupConfig(
            this ResourceConfig<ResourceGroup> resourceGroup, string name, int[] openPorts)
            => Strategy.CreateConfig(
                resourceGroup,
                name,
                _ => new NetworkSecurityGroup
                {
                    SecurityRules = openPorts
                        .Select((port, index) => new SecurityRule
                        {
                            Name = name + port,
                            Protocol = "Tcp",
                            Priority = index + 1000,
                            Access = "Allow",
                            Direction = "Inbound",
                            SourcePortRange = "*",
                            SourceAddressPrefix = "*",
                            DestinationPortRange = port.ToString(),
                            DestinationAddressPrefix = "*"
                        })
                        .ToList()
                });
    }
}
