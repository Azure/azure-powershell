namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IResourceConfigVisitor<TContext, TResult>
    {
        TResult Visit<TModel>(ResourceConfig<TModel> config, TContext context)
            where TModel : class;
    }
}
