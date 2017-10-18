using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    public sealed class VirtualNetworkObject : 
        ResourceObject<VirtualNetwork, IVirtualNetworksOperations>
    {
        public VirtualNetworkObject(
            string name,
            ResourceGroupObject rg,
            string addressPrefix) 
            : base(name, rg, NoDependencies)
        {
            AddressPrefix = addressPrefix;
        }

        protected override Task<VirtualNetwork> CreateAsync(IVirtualNetworksOperations c)
            => c.CreateOrUpdateAsync(
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

        protected override IVirtualNetworksOperations CreateClient(Context c)
            => c.CreateNetwork().VirtualNetworks;

        protected override Task<VirtualNetwork> GetOrThrowAsync(
            IVirtualNetworksOperations c)
            => c.GetAsync(ResourceGroupName, Name);

        private string AddressPrefix { get; }
    }
}
