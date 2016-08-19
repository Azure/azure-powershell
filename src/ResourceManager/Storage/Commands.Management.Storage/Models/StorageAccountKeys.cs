using System.Collections.Generic;

namespace Microsoft.Azure.Management.Storage.Models
{

    public class StorageAccountKeys : List<StorageAccountKey>
    {
        public StorageAccountKeys(IList<StorageAccountKey> storageKeys) : base()
        {
            this.AddRange(storageKeys);
            this.Key1 = storageKeys[0].Value;
            this.Key2 = storageKeys[1].Value;
        }

        public string Key1 { get; set; }
        public string Key2 { get; set; }
    }
}