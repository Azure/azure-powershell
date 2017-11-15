namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class TargetState
    {
        public static IState GetTargetState<Model>(
            this IResourceConfig<Model> config,
            string subscription, 
            string location)
            where Model : class
        {
            var visitor = new Visitor(subscription, location);
            visitor.Get(config);
            return visitor.Result;
        }

        sealed class Visitor : IResourceConfigVisitor<object>
        {
            public Visitor(string subscription, string location)
            {
                Subscription = subscription;
                Location = location;
            }

            public object GetUntyped(IResourceConfig config)
                => Result.GetOrAddUntyped(config, () => config.Apply(this));

            public Model Get<Model>(IResourceConfig<Model> config)
                where Model : class
                => GetUntyped(config) as Model;

            public object Visit<Model>(ResourceConfig<Model> config) 
                where Model : class
            {
                foreach (var d in config.Dependencies)
                {
                    GetUntyped(d);
                }
                var model = config.CreateModel(Subscription);
                config.Policy.SetLocation(model, Location);
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

            public State Result { get; } = new State();
        }
    }
}
