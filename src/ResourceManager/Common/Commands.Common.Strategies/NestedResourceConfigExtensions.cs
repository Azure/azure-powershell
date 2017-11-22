using System;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class NestedResourceConfig
    {
        public static NestedResourceConfig<TModel, TParenModel> CreateConfig<TModel, TParenModel>(
            this NestedResourceStrategy<TModel, TParenModel> strategy,
            IEntityConfig<TParenModel> parent,
            string name,
            Func<TModel> createModel)
            where TModel : class
            where TParenModel : class
            => new NestedResourceConfig<TModel, TParenModel>(strategy, parent, name, createModel);
    }
}
