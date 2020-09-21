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

using System;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Identity;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class ServicePrincipalAuthenticator : DelegatingAuthenticator
    {
        private const string AuthenticationFailedMessage = "No certificate thumbprint or secret provided for the given service principal '{0}'.";

        //MSAL doesn't cache Service Principal into msal.cache
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var spParameters = parameters as ServicePrincipalParameters;
            var onPremise = spParameters.Environment.OnPremise;
            var tenantId = onPremise ? AdfsTenant : spParameters.TenantId;
            var resource = spParameters.Environment.GetEndpoint(spParameters.ResourceId) ?? spParameters.ResourceId;
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var clientId = spParameters.ApplicationId;
            var authority = onPremise ?
                                spParameters.Environment.ActiveDirectoryAuthority :
                                AuthenticationHelpers.GetAuthority(spParameters.Environment, spParameters.TenantId);

            var requestContext = new TokenRequestContext(scopes);

            var options = new ClientCertificateCredentialOptions()
            {
                AuthorityHost = new Uri(authority)
            };

            if (spParameters.Secret != null)
            {
                var secretCredential = new ClientSecretCredential(tenantId, spParameters.ApplicationId, spParameters.Secret.ConvertToString(), options);
                var tokenTask = secretCredential.GetTokenAsync(requestContext, cancellationToken);
                return MsalAccessToken.GetAccessTokenAsync(
                    tokenTask,
                    spParameters.TenantId,
                    spParameters.ApplicationId);
            }
            else
            {
                throw new MsalException(MsalError.AuthenticationFailed, string.Format(AuthenticationFailedMessage, clientId));
            }
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as ServicePrincipalParameters) != null;
        }
    }
}
