using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class NestedResourceStrategy<Model, ParentModel> : IResourceStrategy
    {
        public Func<string, IEnumerable<string>> GetId { get; }

        public Func<ParentModel, string, Model> Get { get; }

        public Action<ParentModel, string, Model> Set { get; }

        public NestedResourceStrategy(
            Func<string, IEnumerable<string>> getId,
            Func<ParentModel, string, Model> get,
            Action<ParentModel, string, Model> set)
        {
            GetId = getId;
            Get = get;
            Set = set;
        }
    }

    public static class NestedResourceStrategy
    {
        public static NestedResourceStrategy<Model, ParentModel> Create<Model, ParentModel>(
            string header,
            Func<ParentModel, string, Model> get,
            Action<ParentModel, string, Model> set)
            where Model : class
            where ParentModel : class
            => new NestedResourceStrategy<Model, ParentModel>(
                name => new[] { header, name},
                get,
                set);
    }
}
