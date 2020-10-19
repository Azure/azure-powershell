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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Identity;

using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class MsalAccessToken : IAccessToken
    {
        public string AccessToken { get; }

        public string UserId { get; }

        public string TenantId { get; }

        public string LoginType => "User";

        public string HomeAccountId { get; }

        public IDictionary<string, string> ExtendedProperties { get; } = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public MsalAccessToken(string token, string tenantId, string userId = null, string homeAccountId = null)
        {
            AccessToken = token;
            UserId = userId;
            TenantId = tenantId;
            HomeAccountId = homeAccountId;
        }

        public void AuthorizeRequest(Action<string, string> authTokenSetter)
        {
            authTokenSetter("Bearer", AccessToken);
        }

        public static async Task<IAccessToken> GetAccessTokenAsync(
            ValueTask<AccessToken> result,
            string tenantId = null,
            string userId = null,
            string homeAccountId = "")
        {
            var token = await result;
            return new MsalAccessToken(token.Token, tenantId, userId, homeAccountId);
        }

        public static async Task<IAccessToken> GetAccessTokenAsync(
            ValueTask<AccessToken> result,
            Action action,
            string tenantId = null,
            string userId = null)
        {
            var token = await result;
            action();
            return new MsalAccessToken(token.Token, tenantId, userId);
        }

        public static async Task<IAccessToken> GetAccessTokenAsync(
            Task<AuthenticationRecord> authTask,
            Func<ValueTask<AccessToken>> getTokenAction,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var record = await authTask;
            cancellationToken.ThrowIfCancellationRequested();
            var token = await getTokenAction();

            return new MsalAccessToken(token.Token, record.TenantId, record.Username, record.HomeAccountId);
        }
    }
}
