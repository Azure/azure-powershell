using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.SignalR.Strategies.ResourceManager
{
    static class ResourceGroupStrategy
    {
        public static ResourceStrategy<ResourceGroup> Strategy { get; }
            = ResourceStrategy.Create(
                type: ResourceType.ResourceGroup,
                getOperations: (ResourceManagementClient client) => client.ResourceGroups,
                getAsync: (o, p) => o.GetAsync(p.Name, p.CancellationToken),
                createOrUpdateAsync: (o, p)
                    => o.CreateOrUpdateAsync(p.Name, p.Model, p.CancellationToken),
                getLocation: model => model.Location,
                setLocation: (model, location) => model.Location = location,
                createTime: _ => 3,
                compulsoryLocation: false);

        public static ResourceConfig<ResourceGroup> CreateResourceGroupConfig(string name)
            => Strategy.CreateResourceConfig(null, name);
    }
}
