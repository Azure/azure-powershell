using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity;

namespace Microsoft.Azure.Commands.StorageSync.Interop.Interfaces
{
    /// <summary>
    /// Provider class to generate the managed identity token from Azure IMDS/HIMDS endpoint
    /// </summary>
    public interface IServerManagedIdentityTokenProvider : IDisposable
    {
        /// <summary>
        /// Returns the MI access token generated from Azure IMDS/HIMDS endpoint
        /// </summary>
        /// <param name="resource"> resource for which token is generated </param>
        /// <returns> Access Token </returns>
        Task<string> GetManagedIdentityAccessToken(string resource);

        /// <summary>
        /// Returns the MI token response generated from Azure IMDS/HIMDS endpoint
        /// </summary>
        /// <param name="resource"> resource for which token is generated </param>
        /// <returns> Token response object </returns>
        Task<ServerManagedIdentityTokenResponse> GetManagedIdentityTokenResponse(string resource);
    }
}
