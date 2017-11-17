namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IResourceBaseConfigVisitor<Result>
    {
        Result Visit<Model>(ResourceConfig<Model> config)
            where Model : class;

        Result Visit<Model, ParentModel>(NestedResourceConfig<Model, ParentModel> config)
            where Model : class
            where ParentModel : class;
    }

    public interface IResourceBaseConfigVisitor<Model, Result>
        where Model : class
    {
        Result Visit(ResourceConfig<Model> config);

        Result Visit<ParentModel>(NestedResourceConfig<Model, ParentModel> config)
            where ParentModel : class;
    }
}
