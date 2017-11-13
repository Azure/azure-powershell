namespace Microsoft.Azure.Experiments
{
    public interface IState
    {
        Config Get<Config>(IResourceConfig<Config> config)
            where Config : class;
    }
}
