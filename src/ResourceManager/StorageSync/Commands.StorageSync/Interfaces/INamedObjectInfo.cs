namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    public interface INamedObjectInfo
    {
        string Name { get; }

        string FullName { get; }
    }
}
