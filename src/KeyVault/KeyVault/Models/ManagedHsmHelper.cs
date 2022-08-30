using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Rest;

using System.Net;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal static class ManagedHsmHelper
    {
        internal static bool IsNotFoundException(this ManagedHsmErrorException err)
        {
            if (err.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return true;
            }
            return false;
        }

        internal static bool IsNoContentException(this ManagedHsmErrorException err)
        {
            if (err.Response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }
    }
}
