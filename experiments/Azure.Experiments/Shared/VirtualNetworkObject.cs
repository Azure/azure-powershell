using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    public sealed class VirtualNetworkObject : 
        ResourceObject<VirtualNetwork>
    {
        public VirtualNetworkObject(
            INetworkManagementClient client,
            string name,
            ResourceGroupObject rg,
            string addressPrefix) 
            : base(name, rg, NoDependencies)
        {
            Client = client.VirtualNetworks;
            AddressPrefix = addressPrefix;
        }

        protected override Task<VirtualNetwork> CreateAsync()
            => Client.CreateOrUpdateAsync(
                ResourceGroupName,
                Name,
                new VirtualNetwork
                {
                    Location = "eastus",
                    AddressSpace = new AddressSpace
                    {
                        AddressPrefixes = new[] { AddressPrefix }
                    }
                });

        protected override Task<VirtualNetwork> GetOrThrowAsync()
            => Client.GetAsync(ResourceGroupName, Name);

        private string AddressPrefix { get; }

        public IVirtualNetworksOperations Client { get; }
    }
}
