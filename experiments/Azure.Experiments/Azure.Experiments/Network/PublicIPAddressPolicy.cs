using System.Threading.Tasks;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class PublicIPAddressPolicy
        : NetworkPolicy<PublicIPAddress, IPublicIPAddressesOperations>
    {
        public override Task<PublicIPAddress> CreateOrUpdateAsync(CreateParams p)
            => p.Operations.CreateOrUpdateAsync(
                p.ResourceGroupName, p.Name, p.Info, p.CancellationToken);

        public override Task<PublicIPAddress> GetAsync(GetParams p)
             => p.Operations.GetAsync(
                 p.ResourceGroupName, p.Name, cancellationToken: p.CancellationToken);

        public override IPublicIPAddressesOperations GetOperations(INetworkManagementClient client)
            => client.PublicIPAddresses;
    }

    /*
    public static class PublicIPAddressPolicy
    {
        public static ResourcePolicy<PublicIPAddress> Policy { get; }
            = NetworkPolicy.Create(
                client => client.PublicIPAddresses,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<PublicIPAddress> CreatePublicIPAddressConfig(
            this ResourceName name)
            => Policy.CreateConfig(name, _ => new PublicIPAddress());
    }
    */
}
