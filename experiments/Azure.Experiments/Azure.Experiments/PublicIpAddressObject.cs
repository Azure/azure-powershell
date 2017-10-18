using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    public sealed class PublicIpAddressObject :
        ResourceObject<PublicIPAddress, IPublicIPAddressesOperations>
    {
        public PublicIpAddressObject(
            INetworkManagementClient client,
            string name,
            ResourceGroupObject rg)
            : base(name, rg)
        {
            Client = client.PublicIPAddresses;
        }

        protected override Task<PublicIPAddress> CreateAsync(IPublicIPAddressesOperations c)
            => c.CreateOrUpdateAsync(
                ResourceGroupName,
                Name,
                new PublicIPAddress { Location = "eastus" });

        protected override IPublicIPAddressesOperations CreateClient(Context c)
            => c.CreateNetwork().PublicIPAddresses;

        protected override Task<PublicIPAddress> GetOrThrowAsync(IPublicIPAddressesOperations c)
            => c.GetAsync(ResourceGroupName, Name);

        private IPublicIPAddressesOperations Client { get; }
    }
}
