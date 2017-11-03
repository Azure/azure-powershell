namespace Microsoft.Azure.Experiments
{
    public interface IStateMap
    {
        I Get<I>(ResourceConfig<I> config)
            where I : class;
    }
}
