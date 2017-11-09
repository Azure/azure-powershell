using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Experiments.ResourceManager
{
    public static class ResourceGroupPolicy
    {
        public static ResourcePolicy<string, ResourceGroup> Policy { get; }
            = OperationsPolicy
                .Create<IResourceGroupsOperations, string, ResourceGroup>(
                    (operations, name) => operations.GetAsync(name),
                    (operations, name, info) => operations.CreateOrUpdateAsync(name, info))
                .Transform<IResourceManagementClient>(r => r.ResourceGroups)
                .CreateResourcePolicy(i => i.Location, (i, location) => i.Location = location);

        public static ResourceConfig<string, ResourceGroup> CreateResourceGroupConfig(string name)
            => Policy.CreateResourceConfig(name, new ResourceGroup());

        public static ResourceConfig<ResourceName, Info> CreateResourceConfig<Info>(
            this ResourceConfig<string, ResourceGroup> resourceGroup,
            ResourcePolicy<ResourceName, Info> policy,
            string name,
            Info info,
            IEnumerable<IResourceConfig> dependencies = null)
            where Info : class
            => policy.CreateResourceConfig(
                new ResourceName(resourceGroup.Name, name),
                info,
                dependencies.EmptyIfNull().Concat(new[] { resourceGroup }));
    }
}
