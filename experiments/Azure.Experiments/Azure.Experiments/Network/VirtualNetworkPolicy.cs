using System.Threading.Tasks;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class VirtualNetworkPolicy 
        : NetworkPolicy<VirtualNetwork, IVirtualNetworksOperations>
    {
        public override Task<VirtualNetwork> CreateOrUpdateAsync(CreateParams p)
            => p.Operations.CreateOrUpdateAsync(
                p.ResourceGroupName, p.Name, p.Info, p.CancellationToken);

        public override Task<VirtualNetwork> GetAsync(GetParams p)
             => p.Operations.GetAsync(
                 p.ResourceGroupName, p.Name, cancellationToken: p.CancellationToken);

        public override IVirtualNetworksOperations GetOperations(INetworkManagementClient client)
            => client.VirtualNetworks;
    }

    /*
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
    */
}
