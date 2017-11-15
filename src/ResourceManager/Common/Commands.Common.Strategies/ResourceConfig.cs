using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class ResourceConfig<Model> : IResourceConfig<Model>
        where Model : class
    {
        public ResourcePolicy<Model> Policy { get; }

        public string ResourceGroupName { get; }

        public string Name { get; }

        public Func<string, Model> CreateModel { get; }

        public IEnumerable<IResourceConfig> Dependencies { get; }

        public ResourceConfig(
            ResourcePolicy<Model> policy,
            string resourceGroupName,
            string name,
            Func<string, Model> createModel,
            IEnumerable<IResourceConfig> dependencies)
        {
            Policy = policy;
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
                .Concat(Policy.GetId(Name));
    }

    public static class ResourceConfig
    {
        public static ResourceConfig<Model> CreateConfig<Model>(
            this ResourcePolicy<Model> policy,
            string resourceGroupName,
            string name,
            Func<string, Model> createModel = null,
            IEnumerable<IResourceConfig> dependencies = null)
            where Model : class, new()
            => new ResourceConfig<Model>(
                policy,
                resourceGroupName,
                name,
                createModel ?? (_ => new Model()),
                dependencies.EmptyIfNull());

        public static ResourceConfig<Model> CreateConfig<Model>(
            this ResourcePolicy<Model> policy,
            ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            Func<string, Model> createModel = null,
            IEnumerable<IResourceConfig> dependencies = null)
            where Model : class, new()
            => policy.CreateConfig(
                resourceGroup.Name, 
                name,
                createModel,
                dependencies.EmptyIfNull().Concat(new[] { resourceGroup }));

        public static string IdToString(this IEnumerable<string> id)
            => "/" + string.Join("/", id);
    }
}
