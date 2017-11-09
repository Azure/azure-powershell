using System.Collections.Generic;

namespace Microsoft.Azure.Experiments
{
    public interface IResourceConfig
    {
    }

    public interface IResourceConfig<Info>
    {
    }

    public static class ResourceConfig
    {
        public static ResourceConfig<Name, Info> CreateResourceConfig<Name, Info>(
            this ResourcePolicy<Name, Info> policy,
            Name name,
            Info info,
            IEnumerable<IResourceConfig> dependencies = null)
            where Info : class
            => new ResourceConfig<Name, Info>(policy, name, info, dependencies.EmptyIfNull());
    }

    public sealed class ResourceConfig<TName, TInfo> : IResourceConfig
        where TInfo : class
    {
        public ResourcePolicy<TName, TInfo> Policy { get; }

        public TName Name { get; }

        public TInfo Info { get; }

        public IEnumerable<IResourceConfig> Dependencies { get; }

        public ResourceConfig(
            ResourcePolicy<TName, TInfo> policy,
            TName name,
            TInfo info,
            IEnumerable<IResourceConfig> dependencies)
        {
            Policy = policy;
            Name = name;
            Info = info;
            Dependencies = dependencies;
        }
    }
}
