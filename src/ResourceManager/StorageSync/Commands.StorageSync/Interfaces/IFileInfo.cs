namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    public interface IFileInfo : INamedObjectInfo
    {
        long Length { get; }
    }
}
