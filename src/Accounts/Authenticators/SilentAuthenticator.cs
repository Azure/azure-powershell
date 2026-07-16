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
using Microsoft.Azure.Commands.Common.Authentication.Utilities;
using Microsoft.Azure.PowerShell.Authenticators.Factories;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class SilentAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var silentParameters = parameters as SilentParameters;
            var onPremise = silentParameters.Environment.OnPremise;
            var tenantId = onPremise ? AdfsTenant :
                (string.Equals(parameters.TenantId, OrganizationsTenant, StringComparison.OrdinalIgnoreCase) ? null : parameters.TenantId);
            var resource = silentParameters.Environment.GetEndpoint(silentParameters.ResourceId) ?? silentParameters.ResourceId;
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var authority = silentParameters.Environment.ActiveDirectoryAuthority;
            var tokenCacheProvider = silentParameters.TokenCacheProvider;

            AzureSession.Instance.TryGetComponent(nameof(AzureCredentialFactory), out AzureCredentialFactory azureCredentialFactory);
            var disableInstanceDiscovery = silentParameters.DisableInstanceDiscovery ?? false;
            var publicClient = tokenCacheProvider.CreatePublicClient(authority, tenantId, disableInstanceDiscovery);

            // Snapshot the agentic session id once per Authenticate() call so the claims
            // challenge, OnBeforeTokenRequest body parameter, and cache-mode decisions all
            // agree — even if COPILOT_AGENT_SESSION_ID changes on another thread while
            // MSAL is in flight.
            var agenticSessionId = AgenticSession.TryGetSessionId();
            var sessionModeChanged = AgenticSession.HasSessionModeChanged(agenticSessionId);

            var credential = azureCredentialFactory.CreateMsalSharedCacheCredential(
                publicClient,
                silentParameters.UserId,
                silentParameters.HomeAccountId,
                tenantId,
                data => ApplyAgenticSessionAsync(data, agenticSessionId),
                agenticSessionId);

            // Attach xms_cli_sid claim on session-marker change: makes ESTS embed it in
            // the token and causes MSAL to bypass its AT cache. Unchanged mode falls
            // through to a normal cache lookup so same-session repeats can reuse the token.
            var agenticClaims = (sessionModeChanged && agenticSessionId != null)
                ? AgenticSession.BuildClaimsChallenge(agenticSessionId)
                : null;
            var requestContext = new TokenRequestContext(scopes, claims: agenticClaims, isCaeEnabled: true);

            CheckTokenCachePersistanceEnabled = () =>
            {
                var cacheOptions = tokenCacheProvider.GetTokenCachePersistenceOptions();
                return cacheOptions != null && !(cacheOptions is UnsafeTokenCacheOptions);
            };
            CollectTelemetry(credential);
            if (agenticSessionId != null)
            {
                telemetry.SetProperty(AgenticSession.TelemetryPropertyName, bool.TrueString);
            }

            var parametersLog = $"- TenantId:'{tenantId}', Scopes:'{string.Join(",", scopes)}', AuthorityHost:'{authority}', UserId:'{silentParameters.UserId}'";
            return MsalAccessToken.GetAccessTokenAsync(
                nameof(SilentAuthenticator),
                parametersLog,
                credential,
                requestContext,
                cancellationToken,
                silentParameters.TenantId,
                silentParameters.UserId,
                silentParameters.HomeAccountId);
        }

        private static Task ApplyAgenticSessionAsync(Microsoft.Identity.Client.Extensibility.OnBeforeTokenRequestData data, string sessionId)
        {
            if (sessionId != null)
            {
                data.BodyParameters[AgenticSession.ClientSessionParamName] = sessionId;
            }
            return Task.CompletedTask;
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as SilentParameters) != null;
        }
    }
}
