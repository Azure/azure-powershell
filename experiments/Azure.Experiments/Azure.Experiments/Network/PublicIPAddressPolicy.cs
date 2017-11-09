using Microsoft.Azure.Experiments.ResourceManager;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public static class PublicIPAddressPolicy
    {
        public static ResourcePolicy<ResourceName, PublicIPAddress> Policy { get; }
            = NetworkPolicy.Create(
                client => client.PublicIPAddresses,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<ResourceName, PublicIPAddress> CreatePublicIPAddressConfig(
            this ResourceConfig<string, ResourceGroup> resourceGroup,
            string name)
            => resourceGroup.CreateResourceConfig(Policy, name, new PublicIPAddress());
    }
}
