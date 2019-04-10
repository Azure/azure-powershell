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

using Microsoft.Identity.Client;
#if NETSTANDARD
using Microsoft.WindowsAzure.Commands.Common;
#endif
using System.Security;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Interface to the keystore for authentication
    /// </summary>
    internal sealed class KeyStoreApplicationCredentialProvider : IApplicationAuthenticationProvider
    {
        private string _tenantId;
        private IServicePrincipalKeyStore _keyStore;
        private ActiveDirectoryServiceSettings _settings;

        /// <summary>
        /// Create a credential provider
        /// </summary>
        /// <param name="tenant"></param>
        public KeyStoreApplicationCredentialProvider(string tenant)
        {
            this._tenantId = tenant;
        }

        /// <summary>
        /// Create a credential provider
        /// </summary>
        /// <param name="tenant"></param>
        /// <param name="keyStore"></param>
        public KeyStoreApplicationCredentialProvider(string tenant, IServicePrincipalKeyStore keyStore)
        {
            this._tenantId = tenant;
            this._keyStore = keyStore;
        }

        /// <summary>
        /// Create a credential provider
        /// </summary>
        /// <param name="tenant"></param>
        /// <param name="keyStore"></param>
        /// <param name="settings"></param>
        public KeyStoreApplicationCredentialProvider(string tenant, IServicePrincipalKeyStore keyStore, ActiveDirectoryServiceSettings settings)
        {
            this._tenantId = tenant;
            this._keyStore = keyStore;
            this._settings = settings;
        }

        /// <summary>
        /// Authenticate using the secret for the specified client from the key store
        /// </summary>
        /// <param name="clientId">The active directory client id for the application.</param>
        /// <param name="audience">The intended audience for authentication</param>
        /// <returns></returns>
        public async Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience)
        {
            var task = new Task<SecureString>(() =>
            {
                return _keyStore.GetKey(clientId, _tenantId);
            });
            task.Start();
            var key = await task.ConfigureAwait(false);
            var authority = _settings.AuthenticationEndpoint + _tenantId;
            var confidentialClient = SharedTokenCacheClientFactory.CreateConfidentialClient(clientId: clientId, authority: authority, redirectUri: audience, clientSecret: key);
            return await confidentialClient.AcquireTokenForClient(new string[] { audience + "/.default" }).ExecuteAsync();
        }
    }
}
