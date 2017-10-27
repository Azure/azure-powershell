namespace Microsoft.Azure.Experiments
{
    public interface ICreateParameters
    {
        T Get<T>(Parameters<T> parameters)
            where T : class;
    }
}
