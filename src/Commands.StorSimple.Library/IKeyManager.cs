using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library
{
    /// <summary>
    /// interface to be used for persisting and retrieving keys
    /// Currently we will be using DPAPI
    /// in future this can extend to KeyVault service too
    /// </summary>
    public interface IKeyManager
    {
        KeyStoreOperationStatus PersistKey(String keyValue, String fileName);
        KeyStoreOperationStatus RetrieveKey(out String keyValue, String fileName);
    }
}
