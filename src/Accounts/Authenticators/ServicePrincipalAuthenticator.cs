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

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class ServicePrincipalAuthenticator : DelegatingAuthenticator
    {
        private const string _authenticationFailedMessage = "No certificate thumbprint or secret provided for the given service principal '{0}'.";

        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var spParameters = parameters as ServicePrincipalParameters;
            var onPremise = spParameters.Environment.OnPremise;
            var authenticationClientFactory = spParameters.AuthenticationClientFactory;
            var resource = spParameters.Environment.GetEndpoint(spParameters.ResourceId);
            var scopes = new string[] { string.Format(AuthenticationHelpers.DefaultScope, resource) };
            var clientId = spParameters.ApplicationId;
            var authority = onPremise ?
                                spParameters.Environment.ActiveDirectoryAuthority :
                                AuthenticationHelpers.GetAuthority(spParameters.Environment, spParameters.TenantId);
            var redirectUri = spParameters.Environment.ActiveDirectoryServiceEndpointResourceId;
            IConfidentialClientApplication confidentialClient = null;
            if (!string.IsNullOrEmpty(spParameters.Thumbprint))
            {
                var certificate = AzureSession.Instance.DataStore.GetCertificate(spParameters.Thumbprint);
                confidentialClient = authenticationClientFactory.CreateConfidentialClient(clientId: clientId, authority: authority, redirectUri: redirectUri, certificate: certificate, useAdfs: onPremise);
            }
            else if (spParameters.Secret != null)
            {
                confidentialClient = authenticationClientFactory.CreateConfidentialClient(clientId: clientId, authority: authority, redirectUri: redirectUri, clientSecret: spParameters.Secret, useAdfs: onPremise);
            }
            else
            {
                throw new MsalException(MsalError.AuthenticationFailed, string.Format(_authenticationFailedMessage, clientId));
            }

            var response = confidentialClient.AcquireTokenForClient(scopes).ExecuteAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            return AuthenticationResultToken.GetAccessTokenAsync(response, userId: clientId, tenantId: spParameters.TenantId);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as ServicePrincipalParameters) != null;
        }
    }
}
