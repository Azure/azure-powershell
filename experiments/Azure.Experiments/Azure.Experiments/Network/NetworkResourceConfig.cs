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
            Func<INetworkManagementClient, Task<I>> getAsync,
            Func<INetworkManagementClient, string, Task<I>> createAsync)
            where I : Management.Network.Models.Resource
            => ManagedResourceConfig.Create(
                resourceGroup,
                name,
                dependencies,
                c => getAsync(c.CreateNetworkManagementClient()),
                i => i.Location,
                (c, location) => createAsync(c.CreateNetworkManagementClient(), location));
    }
}
