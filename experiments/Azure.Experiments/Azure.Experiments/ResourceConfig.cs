using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Experiments
{
    public class ResourceConfig<TName, Config> : IResourceConfig
    {
        public ResourcePolicy<TName, Config> Policy { get; }

        public TName Name { get; }

        public Func<IState, Config> CreateConfig { get; }

        public IEnumerable<IResourceConfig> Dependencies { get; }

        public ResourceConfig(
            ResourcePolicy<TName, Config> policy,
            TName name,
            Func<IState, Config> createConfig,
            IEnumerable<IResourceConfig> dependencies)
        {
            Policy = policy;
            Name = name;
            CreateConfig = createConfig;
            Dependencies = dependencies;
        }
    }

    public static class ResourceConfig
    {
        public static ResourceConfig<Name, Config> CreateConfig<Name, Config>(
            this ResourcePolicy<Name, Config> policy,
            Name name,
            Func<IState, Config> createConfig = null,
            IEnumerable<IResourceConfig> dependencies = null)
            where Config : new()
            => new ResourceConfig<Name, Config>(
                policy,
                name,
                createConfig ?? (_ => new Config()),
                dependencies.EmptyIfNull());

        public static ResourceConfig<ResourceName, Config> CreateConfig<Config>(
            this ResourcePolicy<ResourceName, Config> policy,
            ResourceConfig<string, ResourceGroup> resourceGroup,
            string name,
            Func<IState, Config> createConfig = null,
            IEnumerable<IResourceConfig> dependencies = null)
            where Config : new()
            => policy.CreateConfig(
                new ResourceName(resourceGroup.Name, name),
                createConfig,
                dependencies.EmptyIfNull().Concat(new[] { resourceGroup }));
    }
}
