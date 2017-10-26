using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Threading.Tasks;

namespace Azure.Experiments.Network
{
    public sealed class NetworkInterfaceObject
        : NetworkObject<NetworkInterface>
    {
        public NetworkInterfaceObject(
            INetworkManagementClient client,
            string name,
            ResourceGroupObject rg, 
            SubnetObject subnet,
            PublicIpAddressObject pia,
            NetworkSecurityGroupObject nsg) 
            : base(rg, new AzureObject[] { subnet, pia, nsg })
        {
            Name = name;
            Client = client.NetworkInterfaces;
            Pia = pia;
            Subnet = subnet;
        }

        protected override async Task<NetworkInterface> CreateAsync(string location)
        {
            var subnet = await Subnet.GetOrNullAsync();
            var pia = await Pia.GetOrNullAsync();
            return await Client.CreateOrUpdateAsync(
                ResourceGroupName,
                Name,
                new NetworkInterface
                {
                    Location = location,
                    IpConfigurations = new[]
                    {
                        new NetworkInterfaceIPConfiguration
                        {
                            Name = Name,
                            Subnet = subnet,
                            PublicIPAddress = pia,
                        }
                    }
                });
        }

        protected override Task<NetworkInterface> GetOrThrowAsync()
            => Client.GetAsync(ResourceGroupName, Name);

        private PublicIpAddressObject Pia { get; }

        private SubnetObject Subnet { get; }

        private INetworkInterfacesOperations Client { get; }

        public override string Name { get; }
    }
}
