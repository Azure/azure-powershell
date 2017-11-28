namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IShouldProcess
    {
        bool ShouldCreate<TModel>(ResourceConfig<TModel> config, TModel model)
            where TModel : class;
    }
}
