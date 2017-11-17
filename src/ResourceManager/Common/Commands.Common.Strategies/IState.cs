namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// An Azure state which is a dictionary of models.
    /// </summary>
    public interface IState
    {
        Model GetOrNull<Model>(IResourceConfig<Model> config)
            where Model : class;
    }
}
