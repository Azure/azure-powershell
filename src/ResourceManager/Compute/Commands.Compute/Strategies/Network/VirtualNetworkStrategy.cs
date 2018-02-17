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
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies.Network
{
    static class VirtualNetworkStrategy
    {
        public static ResourceStrategy<VirtualNetwork> Strategy { get; }
            = NetworkStrategy.Create(
                type: "virtual network",
                provider: "virtualNetworks",
                getOperations: client => client.VirtualNetworks,
                getAsync: (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                createTime: _ => 15);

        public static ResourceConfig<VirtualNetwork> CreateVirtualNetworkConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            string addressPrefix)
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: _ => new VirtualNetwork
                {
                    AddressSpace = new AddressSpace
                    {
                        AddressPrefixes = new[] { addressPrefix }
                    }
                });
    }
}
