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
using Microsoft.Identity.Client;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    /// <summary>
    /// Authenticator for user interactive authentication
    /// </summary>
    public class InteractiveUserAuthenticator : DelegatingAuthenticator
    {
        public async override Task<IAccessToken> Authenticate(AuthenticationParameters parameters)
        {
            var interactiveParameters = parameters as InteractiveParameters;
            var scopes = new string[] { string.Format(AuthenticationHelpers.UserImpersonationScope, interactiveParameters.Environment.ActiveDirectoryServiceEndpointResourceId) };
            var publicClient = new PublicClientApplication(
                AuthenticationHelpers.PowerShellClientId,
                AuthenticationHelpers.GetAuthority(interactiveParameters.Environment, interactiveParameters.TenantId),
                interactiveParameters.TokenCache.GetUserCache() as TokenCache);
            var response = await publicClient.AcquireTokenAsync(
                scopes,
                string.Empty,
                AuthenticationHelpers.GetPromptBehavior(ShowDialog.Always),
                AuthenticationHelpers.EnableEbdMagicCookie,
                null); // new UIParent(new ConsoleParentWindow()));
            return AuthenticationResultToken.GetAccessToken(response);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is InteractiveParameters;
        }
    }
}
