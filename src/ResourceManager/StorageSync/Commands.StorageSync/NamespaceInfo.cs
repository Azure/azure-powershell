namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using Interfaces;

    public class NamespaceInfo : INamespaceInfo
    {
        public string Path { get; set; }

        public long NumberOfFiles { get; set; }

        public long NumberOfDirectories { get; set; }

        public long TotalFileSizeInBytes { get; set; }

        public bool IsComplete { get; set; }
    }
}
