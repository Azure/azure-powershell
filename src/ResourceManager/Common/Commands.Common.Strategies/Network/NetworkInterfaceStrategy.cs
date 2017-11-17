using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.Common.Strategies.Network
{
    public static class NetworkInterfaceStrategy
    {
        public static ResourceStrategy<NetworkInterface> Strategy { get; }
            = NetworkStrategy.Create(
                "networkInterfaces",
                client => client.NetworkInterfaces,
                (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken));

        public static ResourceConfig<NetworkInterface> CreateNetworkInterfaceConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            NestedResourceConfig<Subnet, VirtualNetwork> subnet,
            ResourceConfig<PublicIPAddress> publicIPAddress,
            ResourceConfig<NetworkSecurityGroup> networkSecurityGroup)
            => Strategy.CreateConfig(
                resourceGroup,
                name,
                subscription => new NetworkInterface
                {
                    IpConfigurations = new []
                    {
                        new NetworkInterfaceIPConfiguration
                        {
                            Name = name,
                            Subnet = new Subnet { Id = subnet.GetId(subscription).IdToString() },
                            PublicIPAddress = new PublicIPAddress
                            {
                                Id = publicIPAddress.GetId(subscription).IdToString()
                            }
                        }
                    },
                    NetworkSecurityGroup = new NetworkSecurityGroup
                    {
                        Id = networkSecurityGroup.GetId(subscription).IdToString()
                    }
                },
                new IResourceConfig[] { subnet, publicIPAddress, networkSecurityGroup });
    }
}
