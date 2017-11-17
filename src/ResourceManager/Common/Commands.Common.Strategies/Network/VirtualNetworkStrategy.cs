using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.Common.Strategies.Network
{
    public static class VirtualNetworkStrategy
    {
        public static ResourceStrategy<VirtualNetwork> Strategy { get; }
            = NetworkStrategy.Create(
                "virtualNetworks",
                client => client.VirtualNetworks,
                (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken));

        public static ResourceConfig<VirtualNetwork> CreateVirtualNetworkConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            string addressPrefix)
            => Strategy.CreateConfig(
                resourceGroup,
                name,
                _ => new VirtualNetwork
                {
                    AddressSpace = new AddressSpace
                    {
                        AddressPrefixes = new[] { addressPrefix }
                    }
                });
    }
}
