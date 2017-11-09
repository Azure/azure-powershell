namespace Microsoft.Azure.Experiments
{
    public interface IState
    {
        T Get<T>(IResourceConfig<T> resourceConfig);
        T Get<T>(IChildResourceConfig<T> childResourceConfig);
    }
}
