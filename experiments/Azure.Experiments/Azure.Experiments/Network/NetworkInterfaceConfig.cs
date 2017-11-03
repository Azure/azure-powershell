using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public static class NetworkInterfaceConfig
    {
        public static ResourceConfig<NetworkInterface> Create(
            ResourceConfig<ResourceGroup> resourceGroup,
            string name,            
            ResourceConfig<Subnet> subnet,
            ResourceConfig<PublicIPAddress> publicIpAddress,
            ResourceConfig<NetworkSecurityGroup> networkSecurityGroup)
            => NetworkResourceConfig.Create(
                resourceGroup,
                name,                
                new IResourceConfig[] { subnet, publicIpAddress, networkSecurityGroup },
                c => c.NetworkInterfaces.GetAsync(resourceGroup.Name, name),
                (c, location) => c.NetworkInterfaces.CreateOrUpdateAsync(
                    resourceGroup.Name, name, new NetworkInterface { Location = location }));
    }
}
