namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// An Azure state which is a dictionary of models.
    /// </summary>
    public interface IState
    {
        Model GetOrNull<Model>(IResourceBaseConfig<Model> config)
            where Model : class;

        object GetOrNullUntyped(IResourceBaseConfig config);
    }

    public static class StateExtension
    {
        public static Model GetNestedOrNull<Model, ParentModel>(
            this IState state, NestedResourceConfig<Model, ParentModel> config)
            where Model : class
            where ParentModel : class
        {
            var parentModel = config.Parent.Apply(new GetOrNullVisitor<ParentModel>(state));
            return config.Strategy.Get(parentModel, config.Name);
        }

        sealed class GetOrNullVisitor<Model> : IResourceBaseConfigVisitor<Model, Model>
            where Model : class
        {
            public GetOrNullVisitor(IState state)
            {
                State = state;
            }

            public Model Visit(ResourceConfig<Model> config)
                => State.GetOrNull(config);

            public Model Visit<ParentModel>(NestedResourceConfig<Model, ParentModel> config)
                where ParentModel : class
                => State.GetNestedOrNull(config);

            IState State { get; }
        }
    }
}
