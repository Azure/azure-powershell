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
//
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    internal sealed class AppServiceTokenCredential : TokenCredential
    {
        private const string ClaimsChallengeParameterName = "claimsChallenge";
        private const string ResourceIdParameterName = "resourceId";

        private IAccessToken accessToken;
        private readonly Func<string, IAccessToken>
            claimsChallengeAuthenticator;

        internal AppServiceTokenCredential(IAzureContext context, string audience)
        {
            if (context?.Account == null)
            {
                throw new InvalidOperationException("An active Azure context is required.");
            }

            string tenant = null;
            if (context.Subscription != null)
            {
                tenant = context.Subscription
                    .GetPropertyAsArray(AzureSubscription.Property.Tenants)
                    .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                    .FirstOrDefault();
            }

            if (tenant == null &&
                context.Tenant != null &&
                Guid.TryParse(context.Tenant.Id, out Guid tenantId) &&
                tenantId != Guid.Empty)
            {
                tenant = context.Tenant.Id;
            }

            accessToken = Authenticate(context, tenant, audience);
            claimsChallengeAuthenticator = claimsChallenge =>
                Authenticate(
                    context,
                    tenant,
                    audience,
                    claimsChallenge);
        }

        internal AppServiceTokenCredential(
            IAccessToken accessToken,
            Func<string, IAccessToken> claimsChallengeAuthenticator)
        {
            this.accessToken = accessToken ??
                throw new ArgumentNullException(nameof(accessToken));
            this.claimsChallengeAuthenticator =
                claimsChallengeAuthenticator;
        }

        public override AccessToken GetToken(
            TokenRequestContext requestContext,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (!string.IsNullOrEmpty(requestContext.Claims))
            {
                using (var request = new HttpRequestMessage())
                {
                    bool handled = ProcessClaimsChallengeAsync(
                            request,
                            requestContext.Claims,
                            cancellationToken)
                        .GetAwaiter()
                        .GetResult();
                    if (!handled)
                    {
                        throw new InvalidOperationException(
                            "The current Azure account cannot process the claims challenge.");
                    }
                }
            }

            return GetCurrentToken();
        }

        public override async ValueTask<AccessToken> GetTokenAsync(
            TokenRequestContext requestContext,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (!string.IsNullOrEmpty(requestContext.Claims))
            {
                using (var request = new HttpRequestMessage())
                {
                    bool handled = await ProcessClaimsChallengeAsync(
                            request,
                            requestContext.Claims,
                            cancellationToken)
                        .ConfigureAwait(false);
                    if (!handled)
                    {
                        throw new InvalidOperationException(
                            "The current Azure account cannot process the claims challenge.");
                    }
                }
            }

            return GetCurrentToken();
        }

        internal ValueTask<bool> ProcessClaimsChallengeAsync(
            HttpRequestMessage request,
            string claimsChallenge,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (claimsChallengeAuthenticator == null)
            {
                return new ValueTask<bool>(false);
            }

            IAccessToken challengedToken =
                claimsChallengeAuthenticator(claimsChallenge) ??
                throw new InvalidOperationException(
                    "Azure authentication did not return an access token.");
            accessToken = challengedToken;
            challengedToken.AuthorizeRequest(
                (tokenType, tokenValue) =>
                    request.Headers.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue(
                            tokenType,
                            tokenValue));
            return new ValueTask<bool>(true);
        }

        private AccessToken GetCurrentToken()
        {
            string token = null;
            accessToken.AuthorizeRequest((tokenType, tokenValue) => token = tokenValue);
            return new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(5));
        }

        private static IAccessToken Authenticate(
            IAzureContext context,
            string tenant,
            string audience,
            string claimsChallenge = null)
        {
            if (string.IsNullOrEmpty(claimsChallenge))
            {
                return AzureSession.Instance.AuthenticationFactory.Authenticate(
                    context.Account,
                    context.Environment,
                    tenant,
                    null,
                    ShowDialog.Never,
                    null,
                    audience);
            }

            return AzureSession.Instance.AuthenticationFactory.Authenticate(
                context.Account,
                context.Environment,
                tenant,
                null,
                ShowDialog.Never,
                null,
                new Dictionary<string, object>
                {
                    [ClaimsChallengeParameterName] = claimsChallenge,
                    [ResourceIdParameterName] = audience
                });
        }
    }

    internal sealed class AppServiceClaimsChallengeHandler : DelegatingHandler
    {
        private static readonly Regex ClaimsParameterRegex = new Regex(
            @"(?:^|,\s*)claims=""([^""]+)""",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        private readonly AppServiceTokenCredential tokenCredential;

        internal AppServiceClaimsChallengeHandler(
            AppServiceTokenCredential tokenCredential)
        {
            this.tokenCredential = tokenCredential ??
                throw new ArgumentNullException(nameof(tokenCredential));
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(false);
            if (!TryGetClaimsChallenge(response, out string claimsChallenge) ||
                !await tokenCredential
                    .ProcessClaimsChallengeAsync(
                        request,
                        claimsChallenge,
                        cancellationToken)
                    .ConfigureAwait(false))
            {
                return response;
            }

            response.Dispose();
            return await base
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(false);
        }

        private static bool TryGetClaimsChallenge(
            HttpResponseMessage response,
            out string claimsChallenge)
        {
            claimsChallenge = null;
            if (response.StatusCode != HttpStatusCode.Unauthorized)
            {
                return false;
            }

            foreach (var header in response.Headers.WwwAuthenticate)
            {
                if (!string.Equals(
                        header.Scheme,
                        "Bearer",
                        StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                Match match = ClaimsParameterRegex.Match(
                    header.Parameter ?? string.Empty);
                if (match.Success)
                {
                    claimsChallenge = DecodeBase64Url(
                        match.Groups[1].Value);
                    return true;
                }
            }

            return false;
        }

        private static string DecodeBase64Url(string value)
        {
            string encoded = value
                .Replace('-', '+')
                .Replace('_', '/');
            switch (encoded.Length % 4)
            {
                case 2:
                    encoded += "==";
                    break;
                case 3:
                    encoded += "=";
                    break;
            }

            return Encoding.UTF8.GetString(
                Convert.FromBase64String(encoded));
        }
    }
}
