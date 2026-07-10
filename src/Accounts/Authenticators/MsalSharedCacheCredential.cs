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
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    /// <summary>Silent-only MSAL.NET TokenCredential that exposes the OnBeforeTokenRequest
    /// hook so callers can inject custom body parameters into the token request.</summary>
    public class MsalSharedCacheCredential : TokenCredential
    {
        private readonly IPublicClientApplication _app;
        private readonly Func<OnBeforeTokenRequestData, Task> _onBeforeTokenRequest;
        private readonly string _username;
        private readonly string _homeAccountId;
        private readonly string _tenantId;
        private readonly string _agenticSessionId;

        public MsalSharedCacheCredential(
            IPublicClientApplication app,
            string username = null,
            string homeAccountId = null,
            string tenantId = null,
            Func<OnBeforeTokenRequestData, Task> onBeforeTokenRequest = null,
            string agenticSessionId = null)
        {
            _app = app ?? throw new ArgumentNullException(nameof(app));
            _username = username;
            _homeAccountId = homeAccountId;
            _tenantId = tenantId;
            _onBeforeTokenRequest = onBeforeTokenRequest;
            _agenticSessionId = agenticSessionId;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
            => GetTokenImplAsync(requestContext, cancellationToken).GetAwaiter().GetResult();

        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
            => await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false);

        private async Task<AccessToken> GetTokenImplAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            var account = await GetAccountAsync().ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();

            var builder = _app.AcquireTokenSilent(requestContext.Scopes, account);

            if (!string.IsNullOrEmpty(requestContext.Claims)) builder.WithClaims(requestContext.Claims);
            if (!string.IsNullOrEmpty(_tenantId))             builder.WithTenantId(_tenantId);
            if (_onBeforeTokenRequest != null)                builder.OnBeforeTokenRequest(_onBeforeTokenRequest);

            // Bypass MSAL's AT cache on agent<->manual transitions so a cached
            // agent-tagged token can't leak into a subsequent manual call.
            if (AgenticSession.HasSessionModeChanged(_agenticSessionId))
            {
                builder.WithForceRefresh(true);
            }

            var result = await builder.ExecuteAsync(cancellationToken).ConfigureAwait(false);
            AgenticSession.MarkAcquired(_agenticSessionId);
            return new AccessToken(result.AccessToken, result.ExpiresOn);
        }

        private async Task<IAccount> GetAccountAsync()
        {
            var accounts = (await _app.GetAccountsAsync().ConfigureAwait(false)).ToList();

            var match = FindByHomeAccountId(accounts)
                     ?? FindByUsername(accounts)
                     ?? (accounts.Count == 1 ? accounts[0] : null);

            if (match != null)
            {
                return match;
            }

            throw new CredentialUnavailableException(accounts.Count == 0
                ? "No accounts found in the shared MSAL token cache. Run Connect-AzAccount first."
                : "Multiple accounts found in the shared MSAL token cache; specify a username or homeAccountId.");
        }

        private IAccount FindByHomeAccountId(IEnumerable<IAccount> accounts) =>
            string.IsNullOrEmpty(_homeAccountId)
                ? null
                : accounts.FirstOrDefault(a => string.Equals(a.HomeAccountId?.Identifier, _homeAccountId, StringComparison.OrdinalIgnoreCase));

        private IAccount FindByUsername(IEnumerable<IAccount> accounts) =>
            string.IsNullOrEmpty(_username)
                ? null
                : accounts.FirstOrDefault(a => string.Equals(a.Username, _username, StringComparison.OrdinalIgnoreCase));
    }
}
