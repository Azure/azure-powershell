using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Experiments
{
    public static class NestedResourceConfig
    {
        public static NestedResourceConfig<Config, ParentConfig> CreateConfig<Config, ParentConfig>(
            this NestedResourcePolicy<Config, ParentConfig> policy,
            IResourceConfig<ParentConfig> parent,
            string name,
            Func<Config> create)
            where Config : class
            where ParentConfig : class
            => new NestedResourceConfig<Config, ParentConfig>(policy, parent, name, create);
    }

    public sealed class NestedResourceConfig<Config, ParentConfig> : IResourceConfig<Config>
        where Config : class
        where ParentConfig : class
    {
        public NestedResourcePolicy<Config, ParentConfig> Policy { get; }

        public string Name { get; }

        public IResourceConfig<ParentConfig> Parent { get; }

        public Func<Config> Create { get; }

        public NestedResourceConfig(
            NestedResourcePolicy<Config, ParentConfig> policy,            
            IResourceConfig<ParentConfig> parent,
            string name,
            Func<Config> create)
        {
            Policy = policy;
            Name = name;
            Parent = parent;
            Create = create;
        }

        public Result Apply<Result>(IResourceConfigVisitor<Result> visitor)
            => visitor.Visit(this);

        public IEnumerable<string> GetId(string subscription)
            => Parent.GetId(subscription).Concat(Policy.GetId(Name));
    }
}
