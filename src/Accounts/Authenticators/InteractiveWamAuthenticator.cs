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
using Azure.Identity.Broker;

using Hyak.Common;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    /// <summary>
    /// Authenticator for user interactive authentication using WAM (web account manager).
    /// </summary>
    public class InteractiveWamAuthenticator : InteractiveUserAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var interactiveParameters = parameters as InteractiveWamParameters;
            var onPremise = interactiveParameters.Environment.OnPremise;
            //null instead of "organizations" should be passed to Azure.Identity to support MSA account
            var tenantId = onPremise ? AdfsTenant :
                (string.Equals(parameters.TenantId, OrganizationsTenant, StringComparison.OrdinalIgnoreCase) ? null : parameters.TenantId);
            var tokenCacheProvider = interactiveParameters.TokenCacheProvider;
            var resource = interactiveParameters.Environment.GetEndpoint(interactiveParameters.ResourceId) ?? interactiveParameters.ResourceId;
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var clientId = Constants.PowerShellClientId;

            var requestContext = new TokenRequestContext(scopes, isCaeEnabled: true);
            var authority = interactiveParameters.Environment.ActiveDirectoryAuthority;

            var options = new InteractiveBrowserCredentialBrokerOptions(WindowHandleUtilities.GetConsoleOrTerminalWindow())
            {
                IsLegacyMsaPassthroughEnabled = true, // to support MSA account
                ClientId = clientId,
                TenantId = tenantId,
                TokenCachePersistenceOptions = tokenCacheProvider.GetTokenCachePersistenceOptions(),
                AuthorityHost = new Uri(authority),
                // MSAL doesn't rely on redirect URI from user input,
                // it always calculate it as "ms-appx-web://microsoft.aad.brokerplugin/{clientId}",
                // so the below RedirectUri is not for WAM, but for browser fallback.
                RedirectUri = GetReplyUrl(onPremise, interactiveParameters.PromptAction),
                LoginHint = interactiveParameters.UserId
            };
            options.DisableInstanceDiscovery = interactiveParameters.DisableInstanceDiscovery ?? options.DisableInstanceDiscovery;
            var browserCredential = new InteractiveBrowserCredential(options);

            CheckTokenCachePersistanceEnabled = () =>
            {
                return options?.TokenCachePersistenceOptions != null && !(options.TokenCachePersistenceOptions is UnsafeTokenCacheOptions);
            };
            CollectTelemetry(browserCredential, options);

            TracingAdapter.Information($"{DateTime.Now:T} - [InteractiveWamAuthenticator] Calling InteractiveBrowserCredential.AuthenticateAsync with TenantId:'{options.TenantId}', Scopes:'{string.Join(",", scopes)}', AuthorityHost:'{options.AuthorityHost}', RedirectUri:'{options.RedirectUri}'");
            var authTask = browserCredential.AuthenticateAsync(requestContext, cancellationToken);

            return MsalAccessToken.GetAccessTokenAsync(
                authTask,
                browserCredential,
                requestContext,
                cancellationToken);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is InteractiveWamParameters;
        }
    }
}
