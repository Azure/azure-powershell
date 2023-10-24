using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Interop.Enums
{
    public enum ManagedIdentityErrorCodes
    {
        ServerManagedIdentityTokenGenerationFailed,
        ServerManagedIdentityTokenChallengeFailed,
        ServerManagedIdentityTokenParsingFailed,
        ServerManagedIdentitySystemIdentityNotFound,
        ServerManagedIdentityWebError

    }
}
