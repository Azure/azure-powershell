using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Interop.Enums
{
    public enum ServerType
    {
        Unknown = 0,    // Not Azure VM and not Arc-enabled Server
        Hybrid = 1,     // Arc-enabled Server
        Azure = 2       // Azure VM
    }
}
