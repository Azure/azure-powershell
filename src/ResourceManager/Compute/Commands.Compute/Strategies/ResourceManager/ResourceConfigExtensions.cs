using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Compute.Strategies.ResourceManager
{
    static class ResourceConfigExtensions
    {
        public static ResourceConfig<TModel> CreateResourceConfig<TModel>(
            this ResourceStrategy<TModel> strategy,
            ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            Func<string, TModel> createModel = null,
            IEnumerable<IEntityConfig> dependencies = null)
            where TModel : class, new()
            => strategy.CreateConfig(
                resourceGroup.Name,
                name,
                createModel,
                dependencies.EmptyIfNull().Where(d => d != null).Concat(new[] { resourceGroup }));
    }
}
