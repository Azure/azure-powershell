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
            ChildResourceConfig<Subnet, VirtualNetwork> subnet,
            ResourceConfig<NetworkSecurityGroup> networkSecurityGroup,
            ResourceConfig<PublicIPAddress> publicIPAddress)
            => Policy.CreateConfig(
                name,
                state => new NetworkInterface
                {
                    IpConfigurations = new[]
                    {
                        new NetworkInterfaceIPConfiguration
                        {
                            Name = name.Name,
                            Subnet = new Subnet
                            {
                                Id = state.Get(subnet).Id
                            },
                            PublicIPAddress = new PublicIPAddress
                            {
                                Id = state.Get(publicIPAddress).Id
                            }
                        }
                    },
                    NetworkSecurityGroup = new NetworkSecurityGroup
                    {
                        Id = state.Get(networkSecurityGroup).Id
                    }
                },
                new IResourceConfig[] { networkSecurityGroup, publicIPAddress },
                new[] { subnet });
    }
}
