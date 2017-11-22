using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class NestedResourceStrategy<TModel, TParentModel> : IEntityStrategy
    {
        public Func<string, IEnumerable<string>> GetId { get; }

        public Func<TParentModel, string, TModel> Get { get; }

        public Action<TParentModel, string, TModel> CreateOrUpdate { get; }

        public NestedResourceStrategy(
            Func<string, IEnumerable<string>> getId,
            Func<TParentModel, string, TModel> get,
            Action<TParentModel, string, TModel> createOrUpdate)
        {
            GetId = getId;
            Get = get;
            CreateOrUpdate = createOrUpdate;
        }
    }

    public static class NestedResourceStrategy
    {
        public static NestedResourceStrategy<TModel, TParentModel> Create<TModel, TParentModel>(
            string header,
            Func<TParentModel, string, TModel> get,
            Action<TParentModel, string, TModel> createOrUpdate)
            where TModel : class
            where TParentModel : class
            => new NestedResourceStrategy<TModel, TParentModel>(
                name => new[] { header, name},
                get,
                createOrUpdate);
    }
}
