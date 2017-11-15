using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class NestedResourceConfig
    {
        public static NestedResourceConfig<Model, ParentModel> CreateConfig<Model, ParentModel>(
            this NestedResourcePolicy<Model, ParentModel> policy,
            IResourceConfig<ParentModel> parent,
            string name,
            Func<Model> create)
            where Model : class
            where ParentModel : class
            => new NestedResourceConfig<Model, ParentModel>(policy, parent, name, create);
    }

    public sealed class NestedResourceConfig<Model, ParentModel> : IResourceConfig<Model>
        where Model : class
        where ParentModel : class
    {
        public NestedResourcePolicy<Model, ParentModel> Policy { get; }

        public string Name { get; }

        public IResourceConfig<ParentModel> Parent { get; }

        public Func<Model> CreateModel { get; }

        public NestedResourceConfig(
            NestedResourcePolicy<Model, ParentModel> policy,            
            IResourceConfig<ParentModel> parent,
            string name,
            Func<Model> createModel)
        {
            Policy = policy;
            Name = name;
            Parent = parent;
            CreateModel = createModel;
        }

        public Result Apply<Result>(IResourceConfigVisitor<Result> visitor)
            => visitor.Visit(this);

        public IEnumerable<string> GetId(string subscription)
            => Parent.GetId(subscription).Concat(Policy.GetId(Name));
    }
}
