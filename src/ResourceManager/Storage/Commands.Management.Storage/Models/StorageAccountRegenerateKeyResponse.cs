using System.Collections.Generic;

namespace Microsoft.Azure.Management.Storage.Models
{
    class StorageAccountRegenerateKeyResponse
    {
        public StorageAccountRegenerateKeyResponse(StorageAccountListKeysResult result) 
        {
            if (result.Keys != null)
            {
                StorageAccountKeys = new StorageAccountKeys(result.Keys);
                Keys = result.Keys;
            }
        }
        public StorageAccountKeys StorageAccountKeys { get; }
        public IList<StorageAccountKey> Keys { get; }
    }
}
