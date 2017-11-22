using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// Base interface for ResourceConfig and NestedResourceConfig.
    /// </summary>
    public interface IEntityConfig
    {
        IEntityStrategy Strategy { get; }

        string Name { get; }

        IResourceConfig Resource { get; }

        TResult Accept<TContext, TResult>(
            IEntityConfigVisitor<TContext, TResult> visitor, TContext context);

        IEnumerable<string> GetId(string subscription);
    }

    public interface IEntityConfig<TModel> : IEntityConfig
        where TModel : class
    {
        TResult Accept<TContext, TResult>(
            IEntityConfigVisitor<TModel, TContext, TResult> visitor, TContext context);
    }
}
