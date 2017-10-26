namespace Azure.Experiments
{
    public interface IInfoPolicy<T>
    {
        string GetLocation(T value);
    }
}
