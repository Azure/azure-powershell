using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public static class VirtualNetworkConfig
    {
        public static ResourceConfig<VirtualNetwork> Create(
            ResourceConfig<ResourceGroup> resourceGroup, string name)
            => NetworkResourceConfig.Create(
                resourceGroup,
                name,                
                new IResourceConfig[] { },
                c => c.VirtualNetworks.GetAsync(resourceGroup.Name, name));
    }
}
