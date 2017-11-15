namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IState
    {
        Model GetOrNull<Model>(IResourceConfig<Model> config)
            where Model : class;
    }
}
