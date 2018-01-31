namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class Mutable<T>
    {
        public T Value { get; set; }
    }

    public static class Mutable
    {
        public static Mutable<T> Create<T>(T value)
            => new Mutable<T> { Value = value };
    }
}
