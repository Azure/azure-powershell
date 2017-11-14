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

        public Func<string, Config> CreateConfig { get; }

        public IEnumerable<IResourceConfig> Dependencies { get; }

        public ResourceConfig(
            ResourcePolicy<Config> policy,
            string resourceGroupName,
            string name,
            Func<string, Config> createConfig,
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

        public IEnumerable<string> GetId(string subscription)
            => new[]
                {
                    "subscriptions",
                    subscription,
                    "resourceGroups",
                    ResourceGroupName
                }
                .Concat(Policy.GetId(Name));
    }

    public static class ResourceConfig
    {
        public static ResourceConfig<Config> CreateConfig<Config>(
            this ResourcePolicy<Config> policy,
            string resourceGroupName,
            string name,
            Func<string, Config> createConfig = null,
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
            Func<string, Config> createConfig = null,
            IEnumerable<IResourceConfig> dependencies = null)
            where Config : class, new()
            => policy.CreateConfig(
                resourceGroup.Name, 
                name,
                createConfig,
                dependencies.EmptyIfNull().Concat(new[] { resourceGroup }));

        public static string IdToString(this IEnumerable<string> id)
            => "/" + string.Join("/", id);
    }
}
