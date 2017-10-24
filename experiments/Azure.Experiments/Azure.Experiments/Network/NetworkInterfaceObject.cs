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
            : base(name, rg, new AzureObject[] { subnet, pia, nsg })
        {
            Client = client.NetworkInterfaces;
            Pia = pia;
            Subnet = subnet;
        }

        protected override async Task<NetworkInterface> CreateAsync()
            => await Client.CreateOrUpdateAsync(
                ResourceGroupName,
                Name, 
                new NetworkInterface
                {
                    Location = "eastus",                    
                    IpConfigurations = new[] 
                    {
                        new NetworkInterfaceIPConfiguration
                        {
                            Name = Name,
                            Subnet = Subnet.Info,
                            PublicIPAddress = Pia.Info,
                        }
                    }                    
                });

        protected override Task<NetworkInterface> GetOrThrowAsync()
            => Client.GetAsync(ResourceGroupName, Name);

        private PublicIpAddressObject Pia { get; }

        private SubnetObject Subnet { get; }

        private INetworkInterfacesOperations Client { get; }
    }
}
