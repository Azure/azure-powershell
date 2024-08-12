using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Interop.Enums
{
    public enum RegisteredServerAuthType
    {
        Certificate = 0,     // Certificate Auth
        ManagedIdentity = 1, // Managed Identity Auth
    }
}
