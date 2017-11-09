using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public static class VirtualNetworkPolicy
    {
        public static ResourcePolicy<VirtualNetwork> Policy { get; }
            = NetworkPolicy.Create(
                client => client.VirtualNetworks,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<VirtualNetwork> CreateVirtualNetworkConfig(
            this ResourceName name)
            => Policy.CreateConfig(name, _ => new VirtualNetwork());
    }
}
