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

using Microsoft.Azure.Management.Internal.Resources.Models;
using System.Linq;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using System;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Commands.Compute.Strategies.ComputeRp;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Strategies.Network
{
    static class NetworkSecurityGroupStrategy
    {
        public static ResourceStrategy<NetworkSecurityGroup> Strategy { get; }
            = NetworkStrategy.Create(
                provider: "networkSecurityGroups",
                getOperations: client => client.NetworkSecurityGroups,
                getAsync: (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                createTime: _ => 15);

        public static ResourceConfig<NetworkSecurityGroup> CreateNetworkSecurityGroupConfig(
            this ResourceConfig<ResourceGroup> resourceGroup, string name, IList<int> openPorts)
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: _ => new NetworkSecurityGroup
                {
                    SecurityRules = openPorts
                        ?.Select((port, index) => new SecurityRule
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
