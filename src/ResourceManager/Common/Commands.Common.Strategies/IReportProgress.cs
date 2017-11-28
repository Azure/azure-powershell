namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IProgressReport
    {
        void Report<TModel>(ResourceConfig<TModel> config, double progress)
                where TModel : class;
    }
}
