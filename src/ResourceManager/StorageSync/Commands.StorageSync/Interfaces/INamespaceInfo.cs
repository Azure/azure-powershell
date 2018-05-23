namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    public interface INamespaceInfo
    {
        string Path { get; }

        long NumberOfFiles { get; }

        long NumberOfDirectories { get; }

        long TotalFileSizeInBytes { get; }

        bool IsComplete { get; }
    }
}
