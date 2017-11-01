namespace Microsoft.Azure.Experiments
{
    public interface ICreateParameters
    {
        T Get<T>(ResourceParameters<T> parameters)
            where T : class;
    }
}
