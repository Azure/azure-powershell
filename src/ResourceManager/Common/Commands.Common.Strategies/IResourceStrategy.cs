namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IResourceStrategy : IEntityStrategy
    {
        string Type { get; }
    }
}
