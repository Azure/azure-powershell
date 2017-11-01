namespace Microsoft.Azure.Experiments
{
    public interface ICreateContext
    {
        Context Context { get; }

        string Location { get; }

        Info Get<Info>(ResourceParameters<Info> parameters)
            where Info : class;
    }
}
