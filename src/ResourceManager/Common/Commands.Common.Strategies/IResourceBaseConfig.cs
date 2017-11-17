using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IResourceBaseConfig
    {
        IResourceBaseStrategy Strategy { get; }

        string Name { get; }

        Result Apply<Result>(IResourceBaseConfigVisitor<Result> visitor);

        IEnumerable<string> GetId(string subscription);
    }

    public interface IResourceBaseConfig<Model> : IResourceBaseConfig
        where Model : class
    {
        Result Apply<Result>(IResourceBaseConfigVisitor<Model, Result> visitor);
    }
}
