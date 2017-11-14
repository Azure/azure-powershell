namespace Microsoft.Azure.Experiments
{
    public interface IState
    {
        Config GetOrNull<Config>(IResourceConfig<Config> config)
            where Config : class;
    }
}
