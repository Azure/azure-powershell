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
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Identity;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Authenticators.Factories;
using Microsoft.Identity.Client;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class ServicePrincipalAuthenticator : DelegatingAuthenticator
    {
        private const string AuthenticationFailedMessage = "No certificate thumbprint or secret provided for the given service principal '{0}'.";

        // MSAL doesn't cache the secret of Service Principal, but it caches access tokens
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var spParameters = parameters as ServicePrincipalParameters;
            var onPremise = spParameters.Environment.OnPremise;
            var tenantId = onPremise ? AdfsTenant :
                (string.Equals(parameters.TenantId, OrganizationsTenant, StringComparison.OrdinalIgnoreCase) ? null : parameters.TenantId);
            var resource = spParameters.Environment.GetEndpoint(spParameters.ResourceId) ?? spParameters.ResourceId;
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var clientId = spParameters.ApplicationId;
            var authority = spParameters.Environment.ActiveDirectoryAuthority;

            var requestContext = new TokenRequestContext(scopes, isCaeEnabled: true);
            // var tokenCachePersistenceOptions = spParameters.TokenCacheProvider.GetTokenCachePersistenceOptions();
            AzureSession.Instance.TryGetComponent(nameof(AzureCredentialFactory), out AzureCredentialFactory azureCredentialFactory);

            var options = new ClientCertificateCredentialOptions()
            {
                // commented due to https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/issues/3218
                // todo: investigate splitting user token cache and app token cache
                // TokenCachePersistenceOptions = tokenCachePersistenceOptions, // allows MSAL to cache access tokens
                AuthorityHost = new Uri(authority),
                SendCertificateChain = spParameters.SendCertificateChain ?? default(bool)
            };

            options.DisableInstanceDiscovery = spParameters.DisableInstanceDiscovery ?? options.DisableInstanceDiscovery;
            TokenCredential tokenCredential = null;
            string parametersLog = null;
            if (!string.IsNullOrEmpty(spParameters.Thumbprint))
            {
                //Service Principal with Certificate thumbprint
                var certCertificate = AzureSession.Instance.DataStore.GetCertificate(spParameters.Thumbprint);
                tokenCredential = azureCredentialFactory.CreateClientCertificateCredential(tenantId, spParameters.ApplicationId, certCertificate, options);
                parametersLog = $"- Thumbprint:'{spParameters.Thumbprint}', ApplicationId:'{spParameters.ApplicationId}', TenantId:'{tenantId}', Scopes:'{string.Join(",", scopes)}', AuthorityHost:'{options.AuthorityHost}'";
            }
            else if (spParameters.Secret != null)
            {
                //Service principal with secret
                var csOptions = new ClientSecretCredentialOptions()
                {
                    // TokenCachePersistenceOptions = tokenCachePersistenceOptions, // allows MSAL to cache access tokens
                    AuthorityHost = new Uri(authority)
                };
                tokenCredential = azureCredentialFactory.CreateClientSecretCredential(tenantId, spParameters.ApplicationId, spParameters.Secret, csOptions);
                parametersLog = $"- ApplicationId:'{spParameters.ApplicationId}', TenantId:'{tenantId}', Scopes:'{string.Join(",", scopes)}', AuthorityHost:'{csOptions.AuthorityHost}'";
            }
            else if (!string.IsNullOrEmpty(spParameters.CertificatePath))
            {
                if (spParameters.CertificateSecret != null)
                {
                    //Service Principal with Certificate file and password
                    var certCertificate = new X509Certificate2(spParameters.CertificatePath, spParameters.CertificateSecret);
                    tokenCredential = azureCredentialFactory.CreateClientCertificateCredential(tenantId, spParameters.ApplicationId, certCertificate, options);
                    parametersLog = $"- CertificatePath(with password):'{spParameters.CertificatePath}', ApplicationId:'{spParameters.ApplicationId}', TenantId:'{tenantId}', Scopes:'{string.Join(",", scopes)}', AuthorityHost:'{options.AuthorityHost}'";
                }
                else
                {
                    //Service Principal with Certificate file without password
                    tokenCredential = azureCredentialFactory.CreateClientCertificateCredential(tenantId, spParameters.ApplicationId, spParameters.CertificatePath, options);
                    parametersLog = $"- CertificatePath:'{spParameters.CertificatePath}', ApplicationId:'{spParameters.ApplicationId}', TenantId:'{tenantId}', Scopes:'{string.Join(",", scopes)}', AuthorityHost:'{options.AuthorityHost}'";
                }
            }
            else
            {
                throw new MsalException(MsalError.AuthenticationFailed, string.Format(AuthenticationFailedMessage, clientId));
            }

            return MsalAccessToken.GetAccessTokenAsync(
                nameof(ServicePrincipalAuthenticator),
                parametersLog,
                tokenCredential,
                requestContext,
                cancellationToken,
                spParameters.TenantId,
                spParameters.ApplicationId);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as ServicePrincipalParameters) != null;
        }
    }
}
