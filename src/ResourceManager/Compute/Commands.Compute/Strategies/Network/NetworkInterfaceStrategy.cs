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

using Microsoft.Azure.Commands.Common.Strategies.Rm.Config;
using Microsoft.Azure.Commands.Common.Strategies.Rm.Meta;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies.Network
{
    static class NetworkInterfaceStrategy
    {
        public static IResourceStrategy<NetworkInterface> Strategy { get; }
            = NetworkStrategy.Create(
                provider: "networkInterfaces",
                getOperations: client => client.NetworkInterfaces,
                getAsync: (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                createTime: _ => 5);

        public static IResourceConfig<NetworkInterface> CreateNetworkInterfaceConfig(
            this IResourceConfig<ResourceGroup> resourceGroup,
            string name,
            INestedResourceConfig<Subnet, VirtualNetwork> subnet,
            IResourceConfig<PublicIPAddress> publicIPAddress,
            IResourceConfig<NetworkSecurityGroup> networkSecurityGroup = null)
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: engine => new NetworkInterface
                {
                    IpConfigurations = new []
                    {
                        new NetworkInterfaceIPConfiguration
                        {
                            Name = name,
                            Subnet = engine.GetReference(subnet) ,
                            PublicIPAddress = engine.GetReference(publicIPAddress)
                        }
                    },
                    NetworkSecurityGroup = networkSecurityGroup == null 
                        ? null 
                        : engine.GetReference(networkSecurityGroup)
                });
    }
}
