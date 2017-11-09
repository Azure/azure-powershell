namespace Microsoft.Azure.Experiments
{
    public interface IChildResourceConfig
    {
    }

    public interface IChildResourceConfig<Info> : IChildResourceConfig
    {
    }

    public static class ChildResourceConfig
    {
        public static ChildResourceConfig<Info, ParentInfo> CreateConfig<Info, ParentInfo>(
            this ChildResourcePolicy<Info, ParentInfo> policy,
            ResourceConfig<ParentInfo> parent,
            string name)
            where Info : class
            where ParentInfo : class
            => new ChildResourceConfig<Info, ParentInfo>(policy, parent, name);
    }

    public sealed class ChildResourceConfig<Info, ParentInfo> : IChildResourceConfig<Info>
        where Info : class
        where ParentInfo : class
    {
        public ChildResourcePolicy<Info, ParentInfo> Policy { get; }

        public ResourceConfig<ParentInfo> Parent { get; }

        public string Name { get; }

        public ChildResourceConfig(
            ChildResourcePolicy<Info, ParentInfo> policy,
            ResourceConfig<ParentInfo> parent,
            string name)
        {
            Policy = policy;
            Parent = parent;
            Name = name;
        }
    }
}
