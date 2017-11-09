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
        public static ResourceConfig<Info> CreateResourceConfig<Info>(
            this ResourcePolicy<Info> policy,
            ResourceName name,
            Func<IState, Info> info,
            IEnumerable<IResourceConfig> dependencies = null)
            where Info : class
            => new ResourceConfig<Info>(policy, name, info, dependencies.EmptyIfNull());
    }

    public sealed class ResourceConfig<Info> : IResourceConfig<Info>
        where Info : class
    {
        public ResourcePolicy<Info> Policy { get; }

        public ResourceName Name { get; }

        public Func<IState, Info> CreateInfo { get; }

        public IEnumerable<IResourceConfig> Dependencies { get; }

        public ResourceConfig(
            ResourcePolicy<Info> policy,
            ResourceName name,
            Func<IState, Info> createInfo,
            IEnumerable<IResourceConfig> dependencies)
        {
            Policy = policy;
            Name = name;
            CreateInfo = createInfo;
            Dependencies = dependencies;
        }
    }
}
