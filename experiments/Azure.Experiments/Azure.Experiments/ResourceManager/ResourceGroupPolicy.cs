using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.ResourceManager
{
    public static class ResourceGroupPolicy
    {
        public static ResourcePolicy<string, ResourceGroup> Policy { get; }
            = ResourcePolicy.Create<
                string, ResourceGroup, IResourceManagementClient, IResourceGroupsOperations>(
                client => client.ResourceGroups,
                (operations, name, cancellationToken)
                    => operations.GetAsync(name, cancellationToken),
                (operations, name, config, cancellationToken)
                    => operations.CreateOrUpdateAsync(name, config, cancellationToken),
                config => config.Location,
                (config, location) => config.Location = location);

        public static ResourceConfig<string, ResourceGroup> CreateResourceGroupConfig(string name)
            => Policy.CreateConfig(name);
    }
}
