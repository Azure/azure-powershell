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

    /*
    public static class StateExtension
    {
        public static Model GetNestedOrNull<Model, ParentModel>(
            this IState state, NestedResourceConfig<Model, ParentModel> config)
            where Model : class
            where ParentModel : class
        {
            var parentModel = config.Parent.Apply(new GetOrNullVisitor(state)) as Model;
        }

        sealed class GetOrNullVisitor : IResourceConfigVisitor<object>
        {
            public GetOrNullVisitor(IState state)
            {
                State = state;
            }

            public object Visit<Model>(ResourceConfig<Model> config) where Model : class
                => State.GetOrNull(config);

            public object Visit<Model, ParentModel>(NestedResourceConfig<Model, ParentModel> config)
                where Model : class
                where ParentModel : class
                => State.GetNestedOrNull(config);

            IState State { get; }
        }
    }
    */

    /*
    public interface IState
    {
        Model GetOrNull<Model>(IResourceConfig<Model> config)
            where Model : class;

        object GetOrNullUntyped(IResourceConfig config);
    }
    */
}
