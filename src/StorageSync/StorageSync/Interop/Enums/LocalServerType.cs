using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Interop.Enums
{
    public enum LocalServerType
    {
        HybridServer = 0,    // Not Azure VM and not Arc-enabled Server
        ArcEnabledHybridServer = 1,     // Arc-enabled Server
        AzureVirtualMachineServer = 2       // Azure VM
    }
}
