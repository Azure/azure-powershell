using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IResourceBaseConfig
    {
        IResourceBaseStrategy Strategy { get; }

        string Name { get; }

        Result Accept<Context, Result>(
            IResourceBaseConfigVisitor<Context, Result> visitor, Context context);

        IEnumerable<string> GetId(string subscription);
    }

    public interface IResourceBaseConfig<Model> : IResourceBaseConfig
        where Model : class
    {
        Result Accept<Context, Result>(
            IResourceBaseConfigVisitor<Model, Context, Result> visitor, Context context);
    }
}
