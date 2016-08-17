using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Storage.Models
{
    class StorageAccountRegenerateKeyResponse
    {
        public StorageAccountRegenerateKeyResponse(StorageAccountListKeysResult result) 
        {
            if (result.Keys !=null)
            {
                StorageAccountKeys = new StorageAccountKeys(result.Keys);
                Keys = result.Keys;
            }
        }
        public StorageAccountKeys StorageAccountKeys { get; set; }
        public IList<StorageAccountKey> Keys { get; }
    }
}
