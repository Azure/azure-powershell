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
using System.Security;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    /// <summary>
    /// Authenticate username + password scenarios
    /// </summary>
    public class UsernamePasswordAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(IAzureAccount account, IAzureEnvironment environment, string tenant, SecureString password, string promptBehavior, Task<Action<string>> promptAction, IAzureTokenCache tokenCache, string resourceId)
        {
            var audience = environment.GetEndpoint(resourceId);
            var context = new AuthenticationContext(
                AuthenticationHelpers.GetAuthority(environment, tenant), 
                environment?.OnPremise ?? true, 
                tokenCache as TokenCache ?? TokenCache.DefaultShared);
            var result = context.AcquireTokenAsync(audience, AuthenticationHelpers.PowerShellClientId, new UserPasswordCredential(account.Id, password));
            return AuthenticationResultToken.GetAccessTokenAsync(result);
        }

        public override bool CanAuthenticate(IAzureAccount account, IAzureEnvironment environment, string tenant, SecureString password, string promptBehavior, Task<Action<string>> promptAction, IAzureTokenCache tokenCache, string resourceId)
        {
            return (account?.Type == AzureAccount.AccountType.User && environment != null && !string.IsNullOrEmpty(environment.GetEndpoint(resourceId)) && !string.IsNullOrWhiteSpace(tenant) && password != null && tokenCache != null);
        }
    }
}
