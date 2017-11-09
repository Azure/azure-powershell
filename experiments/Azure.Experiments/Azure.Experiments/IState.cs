namespace Microsoft.Azure.Experiments
{
    public interface IState
    {
        T GetInfo<T>(IResourceConfig<T> resourceConfig);
    }
}
