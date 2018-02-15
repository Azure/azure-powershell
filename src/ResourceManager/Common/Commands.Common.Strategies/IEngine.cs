namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IEngine
    {
        string GetId<TModel>(IEntityConfig<TModel> config)
            where TModel : class;
    }
}
