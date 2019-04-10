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
    using System;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Identity.Client;
    using System.Collections.Generic;
    using Microsoft.Rest;
    using System.Security;

    /// <summary>
    /// Provides tokens for Azure Active Directory applications.
    /// </summary>
    public class ApplicationTokenProvider : Microsoft.Rest.ITokenProvider
    {
        #region fields
        private IPublicClientApplication _publicClient;
        private string _tokenAudience;
        private IApplicationAuthenticationProvider _authentications;
        private string _clientId;
        private DateTimeOffset _expiration;
        private string _accessToken;
        private static readonly TimeSpan ExpirationThreshold = TimeSpan.FromMinutes(5);
        #endregion

        #region Constructor
        /// <summary>
        /// Create an application token provider that can retrieve tokens for the given application from the given context, using the given audience
        /// and credential store.
        /// See <see href="https://azure.microsoft.com/en-us/documentation/articles/active-directory-devquickstarts-dotnet/">Active Directory Quickstart for .Net</see>
        /// for detailed instructions on creating an Azure Active Directory application.
        /// </summary>
        /// <param name="context">The authentication context to use when retrieving tokens.</param>
        /// <param name="tokenAudience">The token audience to use when retrieving tokens</param>
        /// <param name="clientId">The client Id for this active directory application</param>
        /// <param name="authenticationStore">The source of authentication information for this application.</param>
        /// <param name="authenticationResult">The authenticationResult of initial authentication with the application credentials.</param>
        public ApplicationTokenProvider(IPublicClientApplication context, string tokenAudience, string clientId,
             IApplicationAuthenticationProvider authenticationStore, AuthenticationResult authenticationResult)
        {
            if (authenticationResult == null)
            {
                throw new ArgumentNullException("authenticationResult");
            }

            Initialize(context, tokenAudience, clientId, authenticationStore, authenticationResult, authenticationResult.ExpiresOn);
        }

        #endregion

        /// <summary>
        /// Creates ServiceClientCredentials for authenticating requests as an active directory application.
        /// See <see href="https://azure.microsoft.com/en-us/documentation/articles/active-directory-devquickstarts-dotnet/">Active Directory Quickstart for .Net</see>
        /// for detailed instructions on creating an Azure Active Directory application.
        /// </summary>
        /// <param name="domain">The active directory domain or tenantId to authenticate with.</param>
        /// <param name="clientId">The active directory clientId for the application.</param>
        /// <param name="authenticationProvider">A source for the secure secret for this application.</param>
        /// <param name="settings">The active directory service side settings, including authority and token audience.</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <returns>A ServiceClientCredentials object that can authenticate http requests as the given application.</returns>
        public static async Task<ServiceClientCredentials> LoginSilentAsync(string domain, string clientId,
            IApplicationAuthenticationProvider authenticationProvider, ActiveDirectoryServiceSettings settings, TokenCache cache)
        {
            var authority = settings.AuthenticationEndpoint + domain;
            var audience = settings.TokenAudience.OriginalString;
            var publicClient = SharedTokenCacheClientFactory.CreatePublicClient(clientId: clientId, authority: authority);
            var authResult = await authenticationProvider.AuthenticateAsync(clientId, audience);
            return new TokenCredentials(
                new ApplicationTokenProvider(publicClient, audience, clientId, authenticationProvider, authResult),
                authResult.TenantId,
                authResult.Account == null ? null : authResult.Account.Username);
        }

        protected virtual bool AccessTokenExpired
        {
            get { return DateTime.UtcNow + ExpirationThreshold >= this._expiration; }
        }

        private void Initialize(IPublicClientApplication publicClient, string tokenAudience, string clientId,
            IApplicationAuthenticationProvider authenticationStore, AuthenticationResult authenticationResult, DateTimeOffset tokenExpiration)
        {
            if (publicClient == null)
            {
                throw new ArgumentNullException("publicClient");
            }

            if (string.IsNullOrWhiteSpace(tokenAudience))
            {
                throw new ArgumentNullException("tokenAudience");
            }

            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentNullException("clientId");
            }

            if (authenticationStore == null)
            {
                throw new ArgumentNullException("authenticationStore");
            }
            if (authenticationResult == null)
            {
                throw new ArgumentNullException("authenticationResult");
            }

            this._authentications = authenticationStore;
            this._clientId = clientId;
            this._publicClient = publicClient;
            this._accessToken = authenticationResult.AccessToken;
            this._tokenAudience = tokenAudience;
            this._expiration = tokenExpiration;
        }

        public virtual async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            try
            {
                AuthenticationResult result;
                if (AccessTokenExpired)
                {
                    result = await this._authentications.AuthenticateAsync(this._clientId, this._tokenAudience).ConfigureAwait(false);
                    this._accessToken = result.AccessToken;
                    this._expiration = result.ExpiresOn;
                }

                return new AuthenticationHeaderValue("Bearer", this._accessToken);
            }
            catch (MsalException authenticationException)
            {
                throw new MsalException(authenticationException.ErrorCode, "Authentication error while acquiring token.", authenticationException);
            }
        }
    }
}
