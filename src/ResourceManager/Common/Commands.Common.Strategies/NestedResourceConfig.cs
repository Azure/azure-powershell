using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class NestedResourceConfig<TModel, TParenModel> : IEntityConfig<TModel>
        where TModel : class
        where TParenModel : class
    {
        public NestedResourceStrategy<TModel, TParenModel> Strategy { get; }

        public string Name { get; }

        public IEntityConfig<TParenModel> Parent { get; }

        public Func<TModel> CreateModel { get; }

        public IResourceConfig Resource => Parent.Resource;

        IEntityStrategy IEntityConfig.Strategy => Strategy;

        public NestedResourceConfig(
            NestedResourceStrategy<TModel, TParenModel> strategy,            
            IEntityConfig<TParenModel> parent,
            string name,
            Func<TModel> createModel)
        {
            Strategy = strategy;
            Name = name;
            Parent = parent;
            CreateModel = createModel;
        }

        public IEnumerable<string> GetId(string subscription)
            => Parent.GetId(subscription).Concat(Strategy.GetId(Name));

        TResult IEntityConfig.Accept<TContext, TResult>(
            IEntityConfigVisitor<TContext, TResult> visitor, TContext context)
            => visitor.Visit(this, context);

        TResult IEntityConfig<TModel>.Accept<TContext, TResult>(
            IEntityConfigVisitor<TModel, TContext, TResult> visitor, TContext context)
            => visitor.Visit(this, context);
    }
}
