namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IEntityConfigVisitor<TContext, TResult>
    {
        TResult Visit<TModel>(ResourceConfig<TModel> config, TContext context)
            where TModel : class;

        TResult Visit<TModel, TParentModel>(
            NestedResourceConfig<TModel, TParentModel> config, TContext context)
            where TModel : class
            where TParentModel : class;
    }

    public interface IEntityConfigVisitor<TModel, TContext, TResult>
        where TModel : class
    {
        TResult Visit(ResourceConfig<TModel> config, TContext context);

        TResult Visit<TParentModel>(NestedResourceConfig<TModel, TParentModel> config, TContext context)
            where TParentModel : class;
    }
}
