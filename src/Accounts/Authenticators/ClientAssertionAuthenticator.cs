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

using Azure.Core;
using Azure.Identity;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Authenticators.Factories;
using Microsoft.WindowsAzure.Commands.Common;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class ClientAssertionAuthenticator : DelegatingAuthenticator
    {
        //MSAL doesn't cache Service Principal into msal.cache
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var spParameters = parameters as ClientAssertionParameters;
            var onPremise = spParameters.Environment.OnPremise;
            var tenantId = onPremise ? AdfsTenant :
                (string.Equals(parameters.TenantId, OrganizationsTenant, StringComparison.OrdinalIgnoreCase) ? null : parameters.TenantId);
            var resource = spParameters.Environment.GetEndpoint(spParameters.ResourceId) ?? spParameters.ResourceId;
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var authority = spParameters.Environment.ActiveDirectoryAuthority;

            var requestContext = new TokenRequestContext(scopes, isCaeEnabled: true);
            AzureSession.Instance.TryGetComponent(nameof(AzureCredentialFactory), out AzureCredentialFactory azureCredentialFactory);

            var options = new ClientAssertionCredentialOptions()
            {
                AuthorityHost = new Uri(authority),
                TokenCachePersistenceOptions = spParameters.TokenCacheProvider.GetTokenCachePersistenceOptions()
            };

            options.DisableInstanceDiscovery = spParameters.DisableInstanceDiscovery ?? options.DisableInstanceDiscovery;
            options.Diagnostics.IsTelemetryEnabled = false; // disable telemetry to avoid error thrown from Azure.Core that AssemblyInformationalVersion is null
            TokenCredential tokenCredential = new ClientAssertionCredential(tenantId, spParameters.ClientId, () => GetClientAssertion(spParameters), options);

            base.CollectTelemetry(tokenCredential);
            CheckTokenCachePersistanceEnabled = () =>
            {
                return options?.TokenCachePersistenceOptions != null && !(options.TokenCachePersistenceOptions is UnsafeTokenCacheOptions);
            };
            telemetry.SetProperty(AuthTelemetryRecord.TokenCacheEnabled, CheckTokenCachePersistanceEnabled().ToString());

            string parametersLog = $"- ClientId:'{spParameters.ClientId}', TenantId:'{tenantId}', ClientAssertion:'***' Scopes:'{string.Join(",", scopes)}'";
            return MsalAccessToken.GetAccessTokenAsync(
                nameof(ClientAssertionAuthenticator),
                parametersLog,
                tokenCredential,
                requestContext,
                cancellationToken,
                spParameters.TenantId,
                spParameters.ClientId);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as ClientAssertionParameters) != null;
        }

        private string GetClientAssertion(ClientAssertionParameters parameters)
        {
            return parameters.ClientAssertion.ConvertToString();
        }
    }
}
