using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class ResourceConfigExtensions
    {
        public static ResourceConfig<TModel> CreateConfig<TModel>(
            this ResourceStrategy<TModel> strategy,
            string resourceGroupName,
            string name,
            Func<string, TModel> createModel = null,
            IEnumerable<IEntityConfig> dependencies = null)
            where TModel : class, new()
            => new ResourceConfig<TModel>(
                strategy,
                resourceGroupName,
                name,
                createModel ?? (_ => new TModel()),
                dependencies.EmptyIfNull());

        public static ResourceConfig<TModel> CreateConfig<TModel>(
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
                dependencies.EmptyIfNull().Concat(new[] { resourceGroup }));
    }
}
