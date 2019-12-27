using System;
using System.Runtime.CompilerServices;

#if !SIGN
    [assembly: InternalsVisibleTo("Authentication.Abstractions.Test")]
#endif
namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    class AssemblyInfo
    {
    }
}
