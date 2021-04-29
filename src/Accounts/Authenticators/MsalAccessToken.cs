﻿// ----------------------------------------------------------------------------------
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Identity;

using Hyak.Common;

using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class MsalAccessToken : IAccessToken
    {
        public string AccessToken { get; private set; }

        public string UserId { get; }

        public string TenantId { get; }

        public string LoginType => "User";

        public string HomeAccountId { get; }

        public IDictionary<string, string> ExtendedProperties { get; } = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public DateTimeOffset ExpiresOn { get; set; }

        private readonly static TimeSpan ExpirationThreshold = TimeSpan.FromMinutes(5);

        private TokenCredential TokenCredential { get; set; }

        private TokenRequestContext TokenRequestContext { get; set; }

        public MsalAccessToken(TokenCredential tokenCredential, TokenRequestContext tokenRequestContext,
            string token, DateTimeOffset expiresOn, string tenantId, string userId = null, string homeAccountId = null)
        {
            TokenCredential = tokenCredential;
            TokenRequestContext = tokenRequestContext;
            AccessToken = token;
            ExpiresOn = expiresOn;
            UserId = userId;
            TenantId = tenantId;
            HomeAccountId = homeAccountId;
        }

        public void AuthorizeRequest(Action<string, string> authTokenSetter)
        {
            Renew();
            authTokenSetter("Bearer", AccessToken);
        }

        internal static async Task<IAccessToken> GetAccessTokenAsync(
            string callerClassName,
            string parametersLog,
            TokenCredential tokenCredential,
            TokenRequestContext requestContext,
            CancellationToken cancellationToken,
            string tenantId = null,
            string userId = null,
            string homeAccountId = "")
        {
            TracingAdapter.Information($"{DateTime.Now:T} - [{callerClassName}] Calling {tokenCredential.GetType().Name}.GetTokenAsync {parametersLog}");
            var token = await tokenCredential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false);
            return new MsalAccessToken(tokenCredential, requestContext, token.Token, token.ExpiresOn, tenantId, userId, homeAccountId);
        }


        internal static async Task<IAccessToken> GetAccessTokenAsync(
            Task<AuthenticationRecord> authTask,
            TokenCredential tokenCredential,
            TokenRequestContext requestContext,
            CancellationToken cancellationToken)
        {
            var record = await authTask.ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
            TracingAdapter.Information($"{DateTime.Now:T} - [MsalAccessToken] Calling {tokenCredential.GetType().Name}.GetTokenAsync - Scopes:'{string.Join(",", requestContext.Scopes)}'");
            var token = await tokenCredential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false);

            return new MsalAccessToken(tokenCredential, requestContext, token.Token, token.ExpiresOn, record.TenantId, record.Username, record.HomeAccountId);
        }


        private void Renew()
        {
            if(IsNearExpiration())
            {
                var token = TokenCredential.GetToken(TokenRequestContext, default(CancellationToken));
                AccessToken = token.Token;
                ExpiresOn = token.ExpiresOn;
            }
        }

        private bool IsNearExpiration()
        {
#if DEBUG
            if (Environment.GetEnvironmentVariable("FORCE_EXPIRED_ACCESS_TOKEN") != null)
            {
                return true;
            }
#endif
            var timeUntilExpiration = ExpiresOn - DateTimeOffset.UtcNow;
            return timeUntilExpiration < ExpirationThreshold;
        }
    }
}
