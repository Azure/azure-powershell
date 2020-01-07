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
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class SilentAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var silentParameters = parameters as SilentParameters;
            var onPremise = silentParameters.Environment.OnPremise;
            var authenticationClientFactory = silentParameters.AuthenticationClientFactory;
            var resource = silentParameters.Environment.GetEndpoint(silentParameters.ResourceId);
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var clientId = AuthenticationHelpers.PowerShellClientId;
            var authority = onPremise ?
                                silentParameters.Environment.ActiveDirectoryAuthority :
                                AuthenticationHelpers.GetAuthority(silentParameters.Environment, silentParameters.TenantId);
            TracingAdapter.Information(string.Format("[SilentAuthenticator] Creating IPublicClientApplication - ClientId: '{0}', Authority: '{1}', UseAdfs: '{2}'", clientId, authority, onPremise));
            var publicClient = authenticationClientFactory.CreatePublicClient(clientId: clientId, authority: authority, useAdfs: onPremise);
            TracingAdapter.Information(string.Format("[SilentAuthenticator] Calling GetAccountsAsync"));
            var accounts = publicClient.GetAccountsAsync()
                .ConfigureAwait(false).GetAwaiter().GetResult();
            TracingAdapter.Information(string.Format("[SilentAuthenticator] Calling AcquireTokenSilent - Scopes: '{0}', UserId: '{1}', Number of accounts: '{2}'", string.Join(",", scopes), silentParameters.UserId, accounts.Count()));
            var response = publicClient.AcquireTokenSilent(scopes, accounts.FirstOrDefault(a => a.Username == silentParameters.UserId)).ExecuteAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            return AuthenticationResultToken.GetAccessTokenAsync(response);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as SilentParameters) != null;
        }
    }
}
