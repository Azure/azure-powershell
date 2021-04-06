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

using Hyak.Common;

using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class MsalAccessTokenAcquirer
    {
        internal virtual async Task<IAccessToken> GetAccessTokenAsync(
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

        internal virtual async Task<IAccessToken> GetAccessTokenAsync(
            Task<AuthenticationRecord> authTask,
            TokenCredential tokenCredential,
            TokenRequestContext requestContext,
            CancellationToken cancellationToken)
        {
            var record = await authTask.ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
            TracingAdapter.Information($"{DateTime.Now:T} - [MsalAccessTokenAcquirer] Calling {tokenCredential.GetType().Name}.GetTokenAsync - Scopes:'{string.Join(",", requestContext.Scopes)}'");
            var token = await tokenCredential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false);

            return new MsalAccessToken(tokenCredential, requestContext, token.Token, token.ExpiresOn, record.TenantId, record.Username, record.HomeAccountId);
        }

    }
}
