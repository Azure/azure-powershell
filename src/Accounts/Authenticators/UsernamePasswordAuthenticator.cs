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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    /// <summary>
    /// Authenticate username + password scenarios
    /// </summary>
    public class UsernamePasswordAuthenticator : DelegatingAuthenticator
    {
        private bool EnablePersistenceCache { get; set; }

        public UsernamePasswordAuthenticator(bool enablePersistentCache = true)
        {
            EnablePersistenceCache = enablePersistentCache;
        }

        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var upParameters = parameters as UsernamePasswordParameters;
            var onPremise = upParameters.Environment.OnPremise;
            var tenantId = onPremise ? AdfsTenant : upParameters.TenantId; //Is user name + password valid in Adfs env?
            var tokenCacheProvider = upParameters.TokenCacheProvider;
            var resource = upParameters.Environment.GetEndpoint(upParameters.ResourceId) ?? upParameters.ResourceId;
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var clientId = Constants.PowerShellClientId;
            var authority = upParameters.Environment.ActiveDirectoryAuthority;

            var requestContext = new TokenRequestContext(scopes, isCaeEnabled: true);
            UsernamePasswordCredential passwordCredential;

            var credentialOptions = new UsernamePasswordCredentialOptions()
            {
                AuthorityHost = new Uri(authority),
                TokenCachePersistenceOptions = tokenCacheProvider.GetTokenCachePersistenceOptions()
            };
            credentialOptions.DisableInstanceDiscovery = upParameters.DisableInstanceDiscovery ?? credentialOptions.DisableInstanceDiscovery;
            if (upParameters.Password != null)
            {
                passwordCredential = new UsernamePasswordCredential(upParameters.UserId, upParameters.Password.ConvertToString(), tenantId, clientId, credentialOptions);
                TracingAdapter.Information($"{DateTime.Now:T} - [UsernamePasswordAuthenticator] Calling UsernamePasswordCredential.AuthenticateAsync - TenantId:'{tenantId}', Scopes:'{string.Join(",", scopes)}', AuthorityHost:'{authority}', UserId:'{upParameters.UserId}'");
                var authTask = passwordCredential.AuthenticateAsync(requestContext, cancellationToken);
                return MsalAccessToken.GetAccessTokenAsync(
                    authTask,
                    passwordCredential,
                    requestContext,
                    cancellationToken);
            }
            else
            {
                throw new InvalidOperationException(Resources.MissingPasswordAndNoCache);
            }
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as UsernamePasswordParameters) != null;
        }
    }
}
