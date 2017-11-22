namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// An Azure state which is a dictionary of models.
    /// </summary>
    public interface IState
    {
        TModel Get<TModel>(ResourceConfig<TModel> config)
            where TModel : class;

        bool Contains(IEntityConfig config);
    }
}
