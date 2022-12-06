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
using Microsoft.Identity.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    public class ClientAssertionCredential : TokenCredential
    {
        internal string TenantId { get; }
        internal string ClientId { get; }
        private MsalConfidentialClient Client { get; }

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected ClientAssertionCredential()
        { }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with an asynchronous callback that provides a signed client assertion to authenticate against Azure Active Directory.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="assertionCallback">An asynchronous callback returning a valid client assertion used to authenticate the service principal.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientAssertionCredential(string tenantId, string clientId, Func<CancellationToken, Task<string>> assertionCallback, ClientAssertionCredentialOptions options = default)
        {
            TenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));
            ClientId = clientId;
            Client = options?.MsalClient ?? new MsalConfidentialClient(options?.Pipeline ?? CredentialPipeline.GetInstance(options), tenantId, clientId, assertionCallback, options);
        }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with a synchronous callback that provides a signed client assertion to authenticate against Azure Active Directory.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="assertionCallback">A synchronous callback returning a valid client assertion used to authenticate the service principal.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientAssertionCredential(string tenantId, string clientId, Func<string> assertionCallback, ClientAssertionCredentialOptions options = default)
        {
            TenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));
            ClientId = clientId;

            Client = options?.MsalClient ?? new MsalConfidentialClient(options?.Pipeline ?? CredentialPipeline.GetInstance(options), tenantId, clientId, assertionCallback, options);
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
                AuthenticationResult result = Client.AcquireTokenForClientAsync(requestContext.Scopes, TenantId, false, cancellationToken).EnsureCompleted();

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
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            try
            {
                AuthenticationResult result = await Client.AcquireTokenForClientAsync(requestContext.Scopes, TenantId, true, cancellationToken).ConfigureAwait(false);

                return new AccessToken(result.AccessToken, result.ExpiresOn);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
