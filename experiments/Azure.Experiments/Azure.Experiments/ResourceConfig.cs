using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments
{
    public interface IResourceConfig
    {
    }

    public interface IResourceConfig<Info> : IResourceConfig
    {
    }

    public static class ResourceConfig
    {
        public static ResourceConfig<Info> CreateConfig<Info>(
            this ResourcePolicy<Info> policy,
            ResourceName name,
            Func<IState, Info> info,
            IEnumerable<IResourceConfig> resources = null,
            IEnumerable<IChildResourceConfig> childResources = null)
            where Info : class
            => new ResourceConfig<Info>(
                policy,
                name,
                info,
                resources.EmptyIfNull(),
                childResources.EmptyIfNull());
    }

    public sealed class ResourceConfig<Info> : IResourceConfig<Info>
        where Info : class
    {
        public ResourcePolicy<Info> Policy { get; }

        public ResourceName Name { get; }

        public Func<IState, Info> CreateInfo { get; }

        public IEnumerable<IResourceConfig> Resources { get; }

        public IEnumerable<IChildResourceConfig> ChildResources { get; }

        public ResourceConfig(
            ResourcePolicy<Info> policy,
            ResourceName name,
            Func<IState, Info> createInfo,
            IEnumerable<IResourceConfig> resources,
            IEnumerable<IChildResourceConfig> childResources)
        {
            Policy = policy;
            Name = name;
            CreateInfo = createInfo;
            Resources = resources;
            ChildResources = childResources;
        }
    }
}
