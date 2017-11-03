using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments
{
    public static class ResourceGroupConfig
    {
        public static ResourceConfig<ResourceGroup> Create(string name)
            => ResourceConfig.Create(
                name,
                new IResourceConfig[] { },
                c => c.CreateResourceManagementClient().ResourceGroups.GetAsync(name),
                i => new Location(false, i.Location),
                (map, config) => map.Get(config));
    }
}
