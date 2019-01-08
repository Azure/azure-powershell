using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightWASBDefaultStorageAccount : AzureHDInsightDefaultStorageAccount
    {
        public AzureHDInsightWASBDefaultStorageAccount(string storageAccountName,
            string storageAccountKey, string storageContainerName)
            : base(storageAccountName)
        {
            StorageAccountKey = storageAccountKey;
            StorageContainerName = storageContainerName;
        }

        public string StorageAccountKey { get; private set; }

        public string StorageContainerName { get; private set; }
    }
}
