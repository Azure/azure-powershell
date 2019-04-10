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

using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Identity.Client;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class ServicePrincipalAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters)
        {
            var spParameters = parameters as ServicePrincipalParameters;
            var scopes = new string[] { string.Format(AuthenticationHelpers.DefaultScope, spParameters.Environment.ActiveDirectoryServiceEndpointResourceId) };
            var clientId = spParameters.ApplicationId;
            var authority = AuthenticationHelpers.GetAuthority(spParameters.Environment, spParameters.TenantId);
            var redirectUri = spParameters.Environment.ActiveDirectoryServiceEndpointResourceId;
            IConfidentialClientApplication confidentialClient = null;
            if (spParameters.Secret == null)
            {
                var certificate = AzureSession.Instance.DataStore.GetCertificate(spParameters.Thumbprint);
                confidentialClient = SharedTokenCacheClientFactory.CreateConfidentialClient(clientId: clientId, authority: authority, redirectUri: redirectUri, certificate: certificate);
            }
            else
            {
                confidentialClient = SharedTokenCacheClientFactory.CreateConfidentialClient(clientId: clientId, authority: authority, redirectUri: redirectUri, clientSecret: spParameters.Secret);
            }

            var response = confidentialClient.AcquireTokenForClient(scopes).ExecuteAsync();
            return AuthenticationResultToken.GetAccessTokenAsync(response);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is ServicePrincipalParameters;
        }
    }
}
