using System.Collections.Generic;

namespace AFSEvaluationTool
{
    public interface IConfiguration
    {
        IEnumerable<string> ValidOsVersions();
        IEnumerable<string> ValidFilesystems();
        IEnumerable<Configuration.CodePointRange> BlacklistOfCodePointRanges();
        IEnumerable<int> BlacklistOfCodePoints();
        IEnumerable<string> InvalidFileNames();
        int MaximumFilenameLength();
        long MaximumFileSizeInBytes();
        int MaximumPathLength();
        int MaximumTreeDepth();
        long MaximumDatasetSizeInBytes();
    }
}