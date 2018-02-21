namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface INestedResourceConfigVisitor<TParentModel, TContext, TResult>
        where TParentModel : class
    {
        TResult Visit<TModel>(NestedResourceConfig<TModel, TParentModel> config, TContext context)
            where TModel : class;
    }
}
