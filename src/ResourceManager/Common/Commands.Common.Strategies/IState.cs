namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// An Azure state which is a dictionary of models.
    /// </summary>
    public interface IState
    {
        Model Get<Model>(ResourceConfig<Model> config)
            where Model : class;

        bool Contains(IResourceBaseConfig config);
    }

    public static class StateExtensions
    {
        public static Model Get<Model, ParentModel>(
            this IState state, NestedResourceConfig<Model, ParentModel> config)
            where Model : class
            where ParentModel : class
            => config.Strategy.Get(state.GetResourceBase(config.Parent), config.Name);

        public static Model GetResourceBase<Model>(
            this IState state, IResourceBaseConfig<Model> config)
            where Model : class
            => config.Accept(new GetVisitor<Model>(), state);

        sealed class GetVisitor<Model> : IResourceBaseConfigVisitor<Model, IState, Model>
            where Model : class
        {
            public Model Visit(ResourceConfig<Model> config, IState state)
                => state.Get(config);

            public Model Visit<ParentModel>(
                NestedResourceConfig<Model, ParentModel> config, IState state)
                where ParentModel : class
                => state.Get(config);
        }
    }
}
