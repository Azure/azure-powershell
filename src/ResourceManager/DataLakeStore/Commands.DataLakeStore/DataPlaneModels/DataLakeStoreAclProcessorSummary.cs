
using Microsoft.Azure.DataLake.Store.AclTools;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// Powershell side data structure containing files and directory processed
    /// </summary>
    public class DataLakeStoreAclProcessorSummary
    {
        /// <summary>Number of files processed</summary>
        public int FilesProcessed { get; internal set; }
        /// <summary>Number of directories processed</summary>
        public int DirectoryProcessed { get; internal set; }

        public DataLakeStoreAclProcessorSummary(AclProcessorStats stats)
        {
            FilesProcessed = stats.FilesProcessed;
            DirectoryProcessed = stats.DirectoryProcessed;
        }
    }
}
