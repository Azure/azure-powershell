namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class StateExtensions
    {
        /// <summary>
        /// Get a model of the given nested resource config from the given state.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TParentModel"></typeparam>
        /// <param name="state"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static TModel Get<TModel, TParentModel>(
            this IState state, NestedResourceConfig<TModel, TParentModel> config)
            where TModel : class
            where TParentModel : class
            => config.Strategy.Get(state.GetDispatch(config.Parent), config.Name);

        /// <summary>
        /// Get a model of the given entity model from the given state.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="state"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static TModel GetDispatch<TModel>(
            this IState state, IEntityConfig<TModel> config)
            where TModel : class
            => config.Accept(new GetVisitor<TModel>(), state);

        sealed class GetVisitor<TModel> : IEntityConfigVisitor<TModel, IState, TModel>
            where TModel : class
        {
            public TModel Visit(ResourceConfig<TModel> config, IState state)
                => state.Get(config);

            public TModel Visit<TParentModel>(
                NestedResourceConfig<TModel, TParentModel> config, IState state)
                where TParentModel : class
                => state.Get(config);
        }
    }
}
