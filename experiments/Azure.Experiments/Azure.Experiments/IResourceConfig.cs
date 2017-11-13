namespace Microsoft.Azure.Experiments
{
    public interface IResourceConfigVisitor<Result>
    {
        Result Visit<Config>(ResourceConfig<Config> config)
            where Config : class;
        Result Visit<Config, ParentConfig>(NestedResourceConfig<Config, ParentConfig> config)
            where Config : class
            where ParentConfig : class;
    }

    public interface IResourceConfig
    {
        Result Apply<Result>(IResourceConfigVisitor<Result> visitor);
    }

    public interface IResourceConfig<Config> : IResourceConfig
        where Config : class
    {
    }
}
