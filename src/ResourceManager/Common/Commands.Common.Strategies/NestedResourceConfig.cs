using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class NestedResourceConfig
    {
        public static NestedResourceConfig<Model, ParentModel> CreateConfig<Model, ParentModel>(
            this NestedResourceStrategy<Model, ParentModel> strategy,
            IResourceBaseConfig<ParentModel> parent,
            string name,
            Func<Model> create)
            where Model : class
            where ParentModel : class
            => new NestedResourceConfig<Model, ParentModel>(strategy, parent, name, create);
    }

    public sealed class NestedResourceConfig<Model, ParentModel> : IResourceBaseConfig<Model>
        where Model : class
        where ParentModel : class
    {
        public NestedResourceStrategy<Model, ParentModel> Policy { get; }

        public string Name { get; }

        public IResourceBaseConfig<ParentModel> Parent { get; }

        public Func<Model> CreateModel { get; }

        public NestedResourceConfig(
            NestedResourceStrategy<Model, ParentModel> policy,            
            IResourceBaseConfig<ParentModel> parent,
            string name,
            Func<Model> createModel)
        {
            Policy = policy;
            Name = name;
            Parent = parent;
            CreateModel = createModel;
        }

        public Result Apply<Result>(IResourceBaseConfigVisitor<Result> visitor)
            => visitor.Visit(this);

        public Result Apply<Result>(IResourceBaseConfigVisitor<Model, Result> visitor)
            => visitor.Visit(this);

        public IEnumerable<string> GetId(string subscription)
            => Parent.GetId(subscription).Concat(Policy.GetId(Name));
    }
}
