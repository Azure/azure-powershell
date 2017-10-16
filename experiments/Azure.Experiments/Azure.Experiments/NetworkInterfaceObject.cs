using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    class NetworkInterfaceObject
        : ResourceObject<NetworkInterface, INetworkInterfacesOperations>
    {
        protected NetworkInterfaceObject(
            string name,
            ResourceGroupObject rg, 
            VirtualNetworkObject vn,
            PublicIpAddressObject pia,
            NetworkSecurityGroupObject nsg) 
            : base(name, rg, new AzureObject[] { vn, pia, nsg })
        {
        }

        protected override Task<NetworkInterface> CreateAsync(
            INetworkInterfacesOperations c)
            => c.CreateOrUpdateAsync(
                ResourceGroupName, Name, new NetworkInterface());

        protected override INetworkInterfacesOperations CreateClient(Context c)
            => c.CreateNetwork().NetworkInterfaces;

        protected override Task DeleteAsync(INetworkInterfacesOperations c)
            => c.DeleteAsync(ResourceGroupName, Name);

        protected override Task<NetworkInterface> GetOrThrowAsync(
            INetworkInterfacesOperations c)
            => c.GetAsync(ResourceGroupName, Name);
    }
}
