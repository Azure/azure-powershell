using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSDataLakeStorageAccountDetails
    {
        public string DefaultDataLakeStorageAccountUrl { get; set; }

        public string DefaultDataLakeStorageFilesystem { get; set; }


        public PSDataLakeStorageAccountDetails(DataLakeStorageAccountDetails defaultDataLakeStorage)
        {
            this.DefaultDataLakeStorageAccountUrl = defaultDataLakeStorage?.AccountUrl;
            this.DefaultDataLakeStorageFilesystem = defaultDataLakeStorage?.Filesystem;
        }
    }
}
