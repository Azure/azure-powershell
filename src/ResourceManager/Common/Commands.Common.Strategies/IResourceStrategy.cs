namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// Base interface for ResourceStrategy[].
    /// </summary>
    public interface IResourceStrategy : IEntityStrategy
    {
        string Type { get; }
    }
}
