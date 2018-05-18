namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    public interface INamedObjectInfo
    {
        string Name { get; }

        string FullName { get; }
    }
}
