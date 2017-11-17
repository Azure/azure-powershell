using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class TargetState
    {
        public static IState GetTargetState<Model>(
            this IResourceBaseConfig<Model> config,
            IState current,
            string subscription, 
            string location)
            where Model : class
        {
            var visitor = new Visitor(current, subscription, location);
            // create a target model onyl if the resource doesn't exist.
            if (current.GetOrNull(config) == null)
            {
                visitor.Get(config);
            }
            return visitor.Result;
        }

        sealed class Visitor : IResourceBaseConfigVisitor<object>
        {
            public Visitor(IState current, string subscription, string location)
            {
                Current = current;
                Subscription = subscription;
                Location = location;
            }

            public object GetUntyped(IResourceBaseConfig config)
                => Result.GetOrAddUntyped(config, () => config.Apply(this));

            public Model Get<Model>(IResourceBaseConfig<Model> config)
                where Model : class
                => GetUntyped(config) as Model;

            public object Visit<Model>(ResourceConfig<Model> config)
                where Model : class
            {
                // create a dependency target model only if the dependency resource doesn't exist.
                foreach (var d in config
                    .Dependencies
                    .Where(d => Current.GetOrNullUntyped(d) == null))
                {
                    GetUntyped(d);
                }
                var model = config.CreateModel(Subscription);
                config.Strategy.SetLocation(model, Location);
                return model;
            }

            public object Visit<Model, ParentModel>(
                NestedResourceConfig<Model, ParentModel> config)
                where Model : class
                where ParentModel : class
            {
                var model = config.CreateModel();
                config.Policy.Set(Get(config.Parent), config.Name, model);
                return model;
            }

            string Subscription { get; }

            string Location { get; }

            IState Current { get; }

            public State Result { get; } = new State();
        }
    }
}
