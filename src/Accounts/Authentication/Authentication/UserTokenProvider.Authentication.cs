// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Common.Authentication
{
    using Microsoft.Identity.Client;
    using Microsoft.Rest;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides tokens for Azure Active Directory Microsoft Id and Organization Id users.
    /// </summary>
    public partial class UserTokenAuthenticationProvider : Microsoft.Rest.ITokenProvider
    {
        /// <summary>
        /// Uri parameters used in the credential prompt.  Allows recalling previous
        /// logins in the login dialog.
        /// </summary>
        private string _tokenAudience;
        private IPublicClientApplication _authenticationContext;
        private string _clientId;

        /// <summary>
        /// The id of the active directory common tenant.
        /// </summary>
        public const string CommonTenantId = "common";


        /// <summary>
        /// Create a token provider which can provide user tokens in the given context.  The user must have previously authenticated in the given context.
        /// Tokens are retrieved from the token cache.
        /// </summary>
        /// <param name="context">The active directory authentication context to use for retrieving tokens.</param>
        /// <param name="clientId">The active directory client Id to match when retrieving tokens.</param>
        /// <param name="tokenAudience">The audience to match when retrieving tokens.</param>
        /// <param name="userId">The user id to match when retrieving tokens.</param>
        public UserTokenAuthenticationProvider(IPublicClientApplication context, string clientId, Uri tokenAudience)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentNullException("clientId");
            }
            if (tokenAudience == null)
            {
                throw new ArgumentNullException("tokenAudience");
            }

            this._authenticationContext = context;
            this._clientId = clientId;
            this._tokenAudience = tokenAudience.OriginalString;
        }

        /// <summary>
        /// Create service client credentials using information cached from a previous login. Parameters are used to match existing tokens.
        /// </summary>
        /// <param name="clientId">The clientId to match when retrieving authentication tokens.</param>
        /// <param name="domain">The active directory domain or tenant id to match when retrieving authentication tokens.</param>
        /// <param name="username">The account username to match when retrieving authentication tokens.</param>
        /// <param name="serviceSettings">The active directory service settings, including token authority and audience to match when retrieving tokens.</param>
        /// <param name="cache">The token cache to target when retrieving tokens.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the retrieved credentials. If no
        /// credentials can be retrieved, an authentication exception is thrown.</returns>
        public static async Task<ServiceClientCredentials> CreateCredentialsFromCache(string clientId, string domain, string username,
            ActiveDirectoryServiceSettings serviceSettings, TokenCache cache)
        {
            var authenticationContext = GetAuthenticationContext(clientId, domain, serviceSettings, cache);
            var scopes = new string[] { serviceSettings.TokenAudience + "/user_impersonation" };
            var accounts = authenticationContext.GetAccountsAsync()
                            .ConfigureAwait(false).GetAwaiter().GetResult();
            try
            {
                var authResult = await authenticationContext.AcquireTokenSilentAsync(scopes, accounts.FirstOrDefault()).ConfigureAwait(false);
                return
                    new TokenCredentials(
                        new UserTokenAuthenticationProvider(authenticationContext, clientId, serviceSettings.TokenAudience),
                        authResult.TenantId,
                        authResult.Account == null ? null : authResult.Account.Username);
            }
            catch (MsalException ex)
            {
                throw new RestException("Authentication error while acquiring token.", ex);
            }
        }

        private static IPublicClientApplication GetAuthenticationContext(string clientId, string domain, ActiveDirectoryServiceSettings serviceSettings, TokenCache cache)
        {
            var context = (cache == null
                ? new PublicClientApplication(clientId, serviceSettings.AuthenticationEndpoint + domain)
                : new PublicClientApplication(clientId, serviceSettings.AuthenticationEndpoint + domain, cache));
            return context;
        }

        public virtual async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var scopes = new string[] { _tokenAudience + "/user_impersonation" };
            var accounts = _authenticationContext.GetAccountsAsync()
                             .ConfigureAwait(false).GetAwaiter().GetResult();
            try
            {
                AuthenticationResult result = await _authenticationContext.AcquireTokenSilentAsync(scopes, accounts.FirstOrDefault()).ConfigureAwait(false);
                return new AuthenticationHeaderValue("Bearer", result.AccessToken);
            }
            catch (MsalException authenticationException)
            {
                throw new MsalException(authenticationException.ErrorCode, "Authentication error while renewing token.", authenticationException);
            }
        }
    }
}