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
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Interface to the certificate store for authentication
    /// </summary>
    internal sealed class CertificateApplicationCredentialProvider : IApplicationAuthenticationProvider
    {
        private string _certificateThumbprint;
        private string _tenantId;
        private ActiveDirectoryServiceSettings _settings;

        /// <summary>
        /// Create a certificate provider
        /// </summary>
        /// <param name="certificateThumbprint"></param>
        public CertificateApplicationCredentialProvider(string certificateThumbprint)
        {
            this._certificateThumbprint = certificateThumbprint;
        }

        /// <summary>
        /// Create a certificate provider
        /// </summary>
        /// <param name="certificateThumbprint"></param>
        /// <param name="settings"></param>
        public CertificateApplicationCredentialProvider(string certificateThumbprint, string tenantId, ActiveDirectoryServiceSettings settings)
        {
            this._certificateThumbprint = certificateThumbprint;
            this._tenantId = tenantId;
            this._settings = settings;
        }

        /// <summary>
        /// Authenticate using certificate thumbprint from the datastore
        /// </summary>
        /// <param name="clientId">The active directory client id for the application.</param>
        /// <param name="audience">The intended audience for authentication</param>
        /// <returns></returns>
        public async Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience)
        {
            var task = new Task<X509Certificate2>(() =>
            {
                return AzureSession.Instance.DataStore.GetCertificate(this._certificateThumbprint);
            });
            task.Start();
            var certificate = await task.ConfigureAwait(false);

            var authority = _settings.AuthenticationEndpoint + _tenantId;
            var confidentialClient = SharedTokenCacheClientFactory.CreateConfidentialClient(clientId: clientId, authority: authority, redirectUri: audience, certificate: certificate);
            return await confidentialClient.AcquireTokenForClient(new string[] { audience + "/.default" }).ExecuteAsync();
        }
    }
}
