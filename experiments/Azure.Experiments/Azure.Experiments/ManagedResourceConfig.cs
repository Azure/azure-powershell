using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public static class ManagedResourceConfig
    {
        public static ResourceConfig<I> Create<I>(
            ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            IEnumerable<IResourceConfig> dependencies,
            Func<Context, Task<I>> getAsync,
            Func<I, string> getLocation)
            where I : class
            => ResourceConfig.Create(
                name,
                dependencies.Concat(new[] { resourceGroup }),
                getAsync,
                i => new Location(true, getLocation(i)),
                (map, config) => map.Get(config));
    }
}
