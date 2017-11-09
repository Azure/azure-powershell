using Microsoft.Azure.Experiments.ResourceManager;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public static class NetworkInterfacePolicy
    {
        public static ResourcePolicy<ResourceName, NetworkInterface> Policy { get; }
            = NetworkPolicy.Create(
                client => client.NetworkInterfaces,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<ResourceName, NetworkInterface> CreateNetworkInterfaceConfig(
            this ResourceConfig<string, ResourceGroup> resourceGroup,
            string name,
            ResourceConfig<ResourceName, VirtualNetwork> virtualNetwork,
            ResourceConfig<ResourceName, NetworkSecurityGroup> networkSecurityGroup,
            ResourceConfig<ResourceName, PublicIPAddress> publicIPAddress)
            => resourceGroup.CreateResourceConfig(
                Policy,
                name,
                _ => new NetworkInterface(),
                new IResourceConfig[] { virtualNetwork, networkSecurityGroup, publicIPAddress });
    }
}
