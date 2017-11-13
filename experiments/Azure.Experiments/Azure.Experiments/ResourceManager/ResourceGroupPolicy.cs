using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.ResourceManager
{
    public static class ResourceGroupPolicy
    {
        public static ResourcePolicy<ResourceGroup> Policy { get; }
            = ResourcePolicy.Create<ResourceGroup, IResourceManagementClient, IResourceGroupsOperations>(
                client => client.ResourceGroups,
                p => p.Operations.GetAsync(p.Name, p.CancellationToken),
                p => p.Operations.CreateOrUpdateAsync(p.Name, p.Config, p.CancellationToken),
                config => config.Location,
                (config, location) => config.Location = location);

        public static ResourceConfig<ResourceGroup> CreateResourceGroupConfig(string name)
            => Policy.CreateConfig(name, name);
    }
}
