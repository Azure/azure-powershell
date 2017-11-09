using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.ResourceManager
{
    public static class ResourceManagerPolicy
    {
        public static ResourcePolicy<IResourceManagementClient, string, ResourceGroup> ResourceGroup
        { get; }
            = OperationsPolicy
                .Create<IResourceGroupsOperations, string, ResourceGroup>(
                    (operations, name) => operations.GetAsync(name),
                    (operations, name, info) => operations.CreateOrUpdateAsync(name, info))
                .Transform<IResourceManagementClient>(r => r.ResourceGroups)
                .CreateResourcePolicy(i => i.Location, (i, location) => i.Location = location);
    }
}
