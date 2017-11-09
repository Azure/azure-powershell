using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
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
            => Policy.CreateResourceConfig(name, _ => new PublicIPAddress());
    }
}
