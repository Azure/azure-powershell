using System.Collections.Generic;

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

        IEnumerable<string> GetId(string subscription);
    }

    public interface IResourceConfig<Config> : IResourceConfig
        where Config : class
    {
    }
}
