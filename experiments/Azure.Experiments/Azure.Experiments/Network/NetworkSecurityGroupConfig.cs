using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public static class NetworkSecurityGroupConfig
    {
        public static ResourceConfig<NetworkSecurityGroup> Create(
            ResourceConfig<ResourceGroup> resourceGroup, string name)
            => NetworkResourceConfig.Create(
                resourceGroup,
                name,                
                new IResourceConfig[] { },
                c => c.NetworkSecurityGroups.GetAsync(resourceGroup.Name, name),
                (c, location) => c.NetworkSecurityGroups.CreateOrUpdateAsync(
                    resourceGroup.Name, name, new NetworkSecurityGroup { Location = location }));
    }
}
