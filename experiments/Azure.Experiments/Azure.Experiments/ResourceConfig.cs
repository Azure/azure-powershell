using System.Collections.Generic;

namespace Microsoft.Azure.Experiments
{
    public interface IResourceConfig
    {
    }

    public static class ResourceConfig
    {
        public static ResourceConfig<Client, Name, Info> CreateResourceConfig<Client, Name, Info>(
            this ResourcePolicy<Client, Name, Info> policy,
            Name name,
            Info info,
            IEnumerable<IResourceConfig> dependencies)
            where Info : class
            => new ResourceConfig<Client, Name, Info>(policy, name, info, dependencies);
    }

    public sealed class ResourceConfig<Client, TName, TInfo>
        where TInfo : class
    {
        public ResourcePolicy<Client, TName, TInfo> Policy { get; }

        public TName Name { get; }

        public TInfo Info { get; }

        public IEnumerable<IResourceConfig> Dependencies { get; }

        public ResourceConfig(
            ResourcePolicy<Client, TName, TInfo> policy,
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
