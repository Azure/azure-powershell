namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    using System.Collections.Generic;

    public interface IConfiguration
    {
        IEnumerable<string> ValidOsVersions();
        IEnumerable<uint> ValidOsSKU();
        IEnumerable<string> ValidFilesystems();
        IEnumerable<Configuration.CodePointRange> WhitelistOfCodePointRanges();
        IEnumerable<int> BlacklistOfCodePoints();
        IEnumerable<string> InvalidFileNames();
        int MaximumFilenameLength();
        long MaximumFileSizeInBytes();
        int MaximumPathLength();
        int MaximumTreeDepth();
        long MaximumDatasetSizeInBytes();
    }
}