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
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class SilentAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters)
        {
            var silentParameters = parameters as SilentParameters;
            var scopes = new string[] { string.Format(AuthenticationHelpers.DefaultScope, silentParameters.ResourceEndpoint) };
            var clientId = AuthenticationHelpers.PowerShellClientId;
            var authority = AuthenticationHelpers.GetAuthority(silentParameters.Environment, silentParameters.TenantId);
            var publicClient = SharedTokenCacheClientFactory.CreatePublicClient(clientId: clientId, authority: authority);
            var accounts = publicClient.GetAccountsAsync()
                .ConfigureAwait(false).GetAwaiter().GetResult();
            var response = publicClient.AcquireTokenSilent(scopes, accounts.FirstOrDefault(a => a.Username == silentParameters.UserId)).ExecuteAsync();
            return AuthenticationResultToken.GetAccessTokenAsync(response);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is SilentParameters;
        }
    }
}
