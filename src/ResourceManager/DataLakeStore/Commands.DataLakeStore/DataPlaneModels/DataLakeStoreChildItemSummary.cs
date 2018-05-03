using Microsoft.Azure.DataLake.Store;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// Powershell side data structure containing files and directory count and total size
    /// </summary>
    public class DataLakeStoreChildItemSummary
    {
        /// <summary>Total directory count</summary>
        public long DirectoryCount { get; internal set; }
        /// <summary>Total file count</summary>
        public long FileCount { get; internal set; }
        /// <summary>Total file sizes</summary>
        public long Length { get; internal set; }
        /// <summary>Total space consumed</summary>
        public long SpaceConsumed { get; internal set; }

        /// <summary>Creates instance of DataLakeStoreChildItemSummary</summary>
        public DataLakeStoreChildItemSummary(ContentSummary summary)
        {
            DirectoryCount = summary.DirectoryCount;
            FileCount = summary.FileCount;
            Length = summary.Length;
            SpaceConsumed = summary.SpaceConsumed;
        }
    }
}