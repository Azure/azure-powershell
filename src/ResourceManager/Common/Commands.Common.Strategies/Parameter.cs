namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class Parameter<T>
    {
        public string Name { get; }

        public T Value { get; }

        public Parameter(string name, T value)
        {
            Name = name;
            Value = value;
        }
    }

    public static class Parameter
    {
        public static Parameter<T> Create<T>(string name, T value)
            => new Parameter<T>(name, value);
    }
}
