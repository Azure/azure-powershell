using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IResourceConfig : IEntityConfig
    {
        string ResourceGroupName { get; }

        IEnumerable<IEntityConfig> Dependencies { get; }
    }

    public sealed class ResourceConfig<TModel> : IEntityConfig<TModel>, IResourceConfig
        where TModel : class
    {
        public ResourceStrategy<TModel> Strategy { get; }

        public string ResourceGroupName { get; }

        public string Name { get; }

        public Func<string, TModel> CreateModel { get; }

        public IEnumerable<IEntityConfig> Dependencies { get; }

        IEntityStrategy IEntityConfig.Strategy => Strategy;

        IResourceConfig IEntityConfig.Resource => this;

        public ResourceConfig(
            ResourceStrategy<TModel> strategy,
            string resourceGroupName,
            string name,
            Func<string, TModel> createModel,
            IEnumerable<IEntityConfig> dependencies)
        {
            Strategy = strategy;
            ResourceGroupName = resourceGroupName;
            Name = name;
            CreateModel = createModel;
            Dependencies = dependencies;
        }

        public IEnumerable<string> GetId(string subscription)
            => new[]
                {
                    "subscriptions",
                    subscription,
                    "resourceGroups",
                    ResourceGroupName
                }
                .Concat(Strategy.GetId(Name));

        Result IEntityConfig.Accept<Context, Result>(
            IEntityConfigVisitor<Context, Result> visitor, Context context)
            => visitor.Visit(this, context);

        Result IEntityConfig<TModel>.Accept<Context, Result>(
            IEntityConfigVisitor<TModel, Context, Result> visitor, Context context)
            => visitor.Visit(this, context);
    }
}
