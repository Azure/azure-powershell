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
//

using Azure.Core;
using Azure.Identity;
using Microsoft.Identity.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    public class ClientAssertionCredential : TokenCredential
    {
        private readonly MsalConfidentialClient _client;
        private readonly CredentialPipeline _pipeline;

        /// <summary>
        /// Gets the Azure Active Directory tenant (directory) Id of the service principal
        /// </summary>
        internal string TenantId { get; }

        /// <summary>
        /// Gets the client (application) ID of the service principal
        /// </summary>
        internal string ClientId { get; }

        /// <summary>
        /// Gets the client secret that was generated for the App Registration used to authenticate the client.
        /// </summary>
        internal string ClientSecret { get; }

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected ClientAssertionCredential()
        {
        }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a client secret.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientAssertion">A client assertion used to prove the identity of the application to Azure AD. This is a Base-64 encoded JWT.</param>
        public ClientAssertionCredential(string tenantId, string clientId, string clientAssertion)
            : this(tenantId, clientId, clientAssertion, null, null, null)
        {
        }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a client secret.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientAssertionCredential(string tenantId, string clientId, string clientSecret, ClientAssertionCredentialOptions options)
            : this(tenantId, clientId, clientSecret, options, null, null)
        {
        }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a client secret.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientAssertionCredential(string tenantId, string clientId, string clientSecret, TokenCredentialOptions options)
            : this(tenantId, clientId, clientSecret, options, null, null)
        {
        }

        internal ClientAssertionCredential(string tenantId, string clientId, string clientSecret, TokenCredentialOptions options, CredentialPipeline pipeline, MsalConfidentialClient client)
        {
            TenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));

            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            ClientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));

            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);

            _client = client ?? new MsalConfidentialClient(_pipeline, tenantId, clientId, clientSecret, options as ITokenCacheOptions);
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            try
            {
                AuthenticationResult result = await _client.AcquireTokenForClientAsync(requestContext.Scopes, true, cancellationToken).ConfigureAwait(false);

                return new AccessToken(result.AccessToken, result.ExpiresOn);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            try
            {
                AuthenticationResult result = _client.AcquireTokenForClientAsync(requestContext.Scopes, false, cancellationToken).EnsureCompleted();

                return new AccessToken(result.AccessToken, result.ExpiresOn);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
