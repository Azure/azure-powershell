namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IResourceBaseConfigVisitor<Context, Result>
    {
        Result Visit<Model>(ResourceConfig<Model> config, Context context)
            where Model : class;

        Result Visit<Model, ParentModel>(
            NestedResourceConfig<Model, ParentModel> config, Context context)
            where Model : class
            where ParentModel : class;
    }

    public interface IResourceBaseConfigVisitor<Model, Context, Result>
        where Model : class
    {
        Result Visit(ResourceConfig<Model> config, Context context);

        Result Visit<ParentModel>(NestedResourceConfig<Model, ParentModel> config, Context context)
            where ParentModel : class;
    }
}
