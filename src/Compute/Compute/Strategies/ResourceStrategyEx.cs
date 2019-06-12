using Microsoft.Azure.Commands.Common.Strategies;
using System;
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    static class ResourceStrategyEx
    {
        public static ResourceConfig<T> CreateNoncreatableResourceConfig<T>(
            this ResourceStrategy<T> strategy, ResourceConfig<ResourceGroup> resourceGroup, string name)
            where T: class
            => strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: engine =>
                {
                    throw new InvalidOperationException($"{name} of {strategy.Type} doesn't exist.");
                },
                // we need this line to prevent calling createModel() by dependency engine.
                dependencies: Enumerable.Empty<IEntityConfig>());
    }
}
