namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class TargetState
    {
        public static IState GetTargetState<Model>(
            this ResourceConfig<Model> config, IState current, string subscription, string location)
            where Model : class
        {
            var context = new Context(current, subscription, location);
            context.AddIfRequired(config);
            return context.Target;
        }

        sealed class Context
        {
            public State Target { get; } = new State();

            public IState Current { get; }

            public string Subscription { get; }

            public string Location { get; }

            public Context(IState current, string subscription, string location)
            {
                Current = current;
                Subscription = subscription;
                Location = location;
            }

            public void AddIfRequired<Model>(ResourceConfig<Model> config)
                where Model : class
            {
                if (Current.Get(config) == null)
                {
                    GetOrAdd(config);
                }
            }

            public Model GetOrAdd<Model>(ResourceConfig<Model> config)
                where Model : class
                => Target.GetOrAdd(
                    config,
                    () =>
                    {
                        foreach (var dependency in config.Dependencies)
                        {
                            dependency.Accept(new AddIfRequiredVisitor(), this);
                        }
                        var model = config.CreateModel(Subscription);
                        config.Strategy.SetLocation(model, Location);
                        return model;
                    });

            public Model GetOrAdd<Model, ParentModel>(
                NestedResourceConfig<Model, ParentModel> config)
                where Model : class
                where ParentModel : class
                => config.Strategy.Get(
                    config.Parent.Accept(new GetOrAddVisitor<ParentModel>(), this),
                    config.Name);
        }

        sealed class AddIfRequiredVisitor : IResourceBaseConfigVisitor<Context, Void>
        {
            public Void Visit<Model>(ResourceConfig<Model> config, Context context)
                where Model : class
            {
                context.AddIfRequired(config);
                return new Void();
            }

            public Void Visit<Model, ParentModel>(
                NestedResourceConfig<Model, ParentModel> config, Context context)
                where Model : class
                where ParentModel : class
            {
                if (context.Current.Get(config) == null)
                {
                    context.GetOrAdd(config);
                }
                return new Void();
            }
        }

        sealed class GetOrAddVisitor<Model> : IResourceBaseConfigVisitor<Model, Context, Model>
            where Model : class
        {
            public Model Visit(ResourceConfig<Model> config, Context context)
                => context.GetOrAdd(config);

            public Model Visit<ParentModel>(
                NestedResourceConfig<Model, ParentModel> config, Context context)
                where ParentModel : class
                => context.GetOrAdd(config);
        }
    }
}
