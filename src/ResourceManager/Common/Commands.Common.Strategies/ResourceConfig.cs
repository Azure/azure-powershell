using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class ResourceConfig<Model> : IResourceConfig<Model>
        where Model : class
    {
        public ResourceStrategy<Model> Strategy { get; }

        public string ResourceGroupName { get; }

        public string Name { get; }

        public Func<string, Model> CreateModel { get; }

        public IEnumerable<IResourceConfig> Dependencies { get; }

        public ResourceConfig(
            ResourceStrategy<Model> strategy,
            string resourceGroupName,
            string name,
            Func<string, Model> createModel,
            IEnumerable<IResourceConfig> dependencies)
        {
            Strategy = strategy;
            ResourceGroupName = resourceGroupName;
            Name = name;
            CreateModel = createModel;
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
                .Concat(Strategy.GetId(Name));
    }

    public static class ResourceConfig
    {
        public static ResourceConfig<Model> CreateConfig<Model>(
            this ResourceStrategy<Model> strategy,
            string resourceGroupName,
            string name,
            Func<string, Model> createModel = null,
            IEnumerable<IResourceConfig> dependencies = null)
            where Model : class, new()
            => new ResourceConfig<Model>(
                strategy,
                resourceGroupName,
                name,
                createModel ?? (_ => new Model()),
                dependencies.EmptyIfNull());

        public static ResourceConfig<Model> CreateConfig<Model>(
            this ResourceStrategy<Model> strategy,
            ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            Func<string, Model> createModel = null,
            IEnumerable<IResourceConfig> dependencies = null)
            where Model : class, new()
            => strategy.CreateConfig(
                resourceGroup.Name, 
                name,
                createModel,
                dependencies.EmptyIfNull().Concat(new[] { resourceGroup }));

        public static string IdToString(this IEnumerable<string> id)
            => "/" + string.Join("/", id);

        public static string DefaultIdStr(this IResourceConfig config)
            => config.GetId(string.Empty).IdToString();
    }
}
