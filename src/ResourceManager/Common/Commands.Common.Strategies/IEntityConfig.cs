using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IEntityConfig
    {
        IEntityStrategy Strategy { get; }

        string Name { get; }

        Result Accept<Context, Result>(
            IEntityConfigVisitor<Context, Result> visitor, Context context);

        IEnumerable<string> GetId(string subscription);

        IResourceConfig Resource { get; }
    }

    public interface IResourceBaseConfig<Model> : IEntityConfig
        where Model : class
    {
        Result Accept<Context, Result>(
            IEntityConfigVisitor<Model, Context, Result> visitor, Context context);
    }
}
