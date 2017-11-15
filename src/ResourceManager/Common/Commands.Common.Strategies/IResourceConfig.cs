using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IResourceConfig
    {
        Result Apply<Result>(IResourceConfigVisitor<Result> visitor);

        IEnumerable<string> GetId(string subscription);
    }

    public interface IResourceConfig<Model> : IResourceConfig
        where Model : class
    {
    }
}
