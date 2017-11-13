using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Experiments
{
    public sealed class ResourceConfig<Config> : IResourceConfig<Config>
        where Config : class
    {
        public ResourcePolicy<Config> Policy { get; }

        public string ResourceGroupName { get; }

        public string Name { get; }

        public Func<IState, Config> CreateConfig { get; }

        public IEnumerable<IResourceConfig> Dependencies { get; }

        public ResourceConfig(
            ResourcePolicy<Config> policy,
            string resourceGroupName,
            string name,
            Func<IState, Config> createConfig,
            IEnumerable<IResourceConfig> dependencies)
        {
            Policy = policy;
            ResourceGroupName = resourceGroupName;
            Name = name;
            CreateConfig = createConfig;
            Dependencies = dependencies;
        }

        public Result Apply<Result>(IResourceConfigVisitor<Result> visitor)
            => visitor.Visit(this);
    }

    public static class ResourceConfig
    {
        public static ResourceConfig<Config> CreateConfig<Config>(
            this ResourcePolicy<Config> policy,
            string resourceGroupName,
            string name,
            Func<IState, Config> createConfig = null,
            IEnumerable<IResourceConfig> dependencies = null)
            where Config : class, new()
            => new ResourceConfig<Config>(
                policy,
                resourceGroupName,
                name,
                createConfig ?? (_ => new Config()),
                dependencies.EmptyIfNull());

        public static ResourceConfig<Config> CreateConfig<Config>(
            this ResourcePolicy<Config> policy,
            ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            Func<IState, Config> createConfig = null,
            IEnumerable<IResourceConfig> dependencies = null)
            where Config : class, new()
            => policy.CreateConfig(
                resourceGroup.Name, 
                name,
                createConfig,
                dependencies.EmptyIfNull().Concat(new[] { resourceGroup }));
    }
}
