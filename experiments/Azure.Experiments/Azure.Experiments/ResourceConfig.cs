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
        public static ResourceConfig<Name, Info> CreateResourceConfig<Name, Info>(
            this ResourcePolicy<Name, Info> policy,
            Name name,
            Func<IState, Info> info,
            IEnumerable<IResourceConfig> dependencies = null)
            where Info : class
            => new ResourceConfig<Name, Info>(policy, name, info, dependencies.EmptyIfNull());
    }

    public sealed class ResourceConfig<TName, Info> : IResourceConfig<Info>
        where Info : class
    {
        public ResourcePolicy<TName, Info> Policy { get; }

        public TName Name { get; }

        public Func<IState, Info> CreateInfo { get; }

        public IEnumerable<IResourceConfig> Dependencies { get; }

        public ResourceConfig(
            ResourcePolicy<TName, Info> policy,
            TName name,
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
