namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IResourceConfigVisitor<Result>
    {
        Result Visit<Model>(ResourceConfig<Model> config)
            where Model : class;

        Result Visit<Model, ParentModel>(NestedResourceConfig<Model, ParentModel> config)
            where Model : class
            where ParentModel : class;
    }
}
