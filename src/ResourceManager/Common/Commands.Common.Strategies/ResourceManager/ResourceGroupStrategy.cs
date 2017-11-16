using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.ResourceManager
{
    public static class ResourceGroupStrategy
    {
        public static ResourceStrategy<ResourceGroup> Strategy { get; }
            = ResourceStrategy.Create<ResourceGroup, ResourceManagementClient, IResourceGroupsOperations>(
                _ => Enumerable.Empty<string>(),
                client => client.ResourceGroups,
                p => p.Operations.GetAsync(p.Name, p.CancellationToken),
                p => p.Operations.CreateOrUpdateAsync(p.Name, p.Model, p.CancellationToken),
                model => model.Location,
                (model, location) => model.Location = location);

        public static ResourceConfig<ResourceGroup> CreateResourceGroupConfig(string name)
            => Strategy.CreateConfig(name, name);
    }
}
