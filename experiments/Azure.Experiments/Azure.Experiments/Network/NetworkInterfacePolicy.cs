using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public static class NetworkInterfacePolicy
    {
        public static ResourcePolicy<NetworkInterface> Policy { get; }
            = NetworkPolicy.Create(
                client => client.NetworkInterfaces,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<NetworkInterface> CreateNetworkInterfaceConfig(
            this ResourceName name,
            ResourceConfig<VirtualNetwork> virtualNetwork,
            ResourceConfig<NetworkSecurityGroup> networkSecurityGroup,
            ResourceConfig<PublicIPAddress> publicIPAddress)
            => Policy.CreateResourceConfig(
                name,
                state => new NetworkInterface
                {
                    IpConfigurations = new[]
                    {
                        new NetworkInterfaceIPConfiguration
                        {
                            PublicIPAddress = new PublicIPAddress
                            {
                                Id = state.GetInfo(publicIPAddress).Id
                            }
                        }
                    },
                    NetworkSecurityGroup = new NetworkSecurityGroup
                    {
                        Id = state.GetInfo(networkSecurityGroup).Id
                    }
                },
                new IResourceConfig[] { virtualNetwork, networkSecurityGroup, publicIPAddress });
    }
}
