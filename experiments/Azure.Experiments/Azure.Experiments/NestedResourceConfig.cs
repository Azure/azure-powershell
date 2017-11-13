namespace Microsoft.Azure.Experiments
{
    public sealed class NestedResourceConfig<Config, ParentConfig> : IResourceConfig<Config>
        where Config : class
        where ParentConfig : class
    {
        public NestedResourcePolicy<Config, ParentConfig> Policy { get; }

        public IResourceConfig<ParentConfig> Parent { get; }

        public NestedResourceConfig(
            NestedResourcePolicy<Config, ParentConfig> policy, IResourceConfig<ParentConfig> parent)
        {
            Policy = policy;
            Parent = parent;
        }

        public Result Apply<Result>(IResourceConfigVisitor<Result> visitor)
            => visitor.Visit(this);
    }
}
