using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments.Network
{
    public static class NetworkResourceConfig
    {
        public static ResourceConfig<I> Create<I>(
            ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            IEnumerable<IResourceConfig> dependencies,
            Func<INetworkManagementClient, Task<I>> getAsync)
            where I : Management.Network.Models.Resource
            => ManagedResourceConfig.Create(
                resourceGroup,
                name,
                dependencies,
                context => getAsync(context.CreateNetworkManagementClient()),
                i => i.Location);
    }
}
