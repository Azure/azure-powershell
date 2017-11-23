using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IResourceConfig : IEntityConfig
    {
        string ResourceGroupName { get; }

        IEnumerable<IEntityConfig> Dependencies { get; }

        TResult Accept<TContext, TResult>(
            IResourceConfigVisitor<TContext, TResult> visitor, TContext context);
    }
}
