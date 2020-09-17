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
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Identity;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Authentication.Clients;
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
        private ConcurrentDictionary<string, UsernamePasswordCredential> UserCredentialMap = new ConcurrentDictionary<string, UsernamePasswordCredential>(StringComparer.OrdinalIgnoreCase);

        public UsernamePasswordAuthenticator(bool enablePersistentCache = true)
        {
            EnablePersistenceCache = enablePersistentCache;
        }

        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var upParameters = parameters as UsernamePasswordParameters;
            var onPremise = upParameters.Environment.OnPremise;
            var tenantId = onPremise ? AdfsTenant : upParameters.TenantId; //Is user name + password valid in Adfs env?
            var authenticationClientFactory = upParameters.AuthenticationClientFactory;
            var resource = upParameters.Environment.GetEndpoint(upParameters.ResourceId) ?? upParameters.ResourceId;
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var clientId = AuthenticationHelpers.PowerShellClientId;
            var authority = onPremise ?
                                upParameters.Environment.ActiveDirectoryAuthority :
                                AuthenticationHelpers.GetAuthority(parameters.Environment, parameters.TenantId);

            var requestContext = new TokenRequestContext(scopes);
            UsernamePasswordCredential passwordCredential;
            Action action = EmptyAction;

            AzureSession.Instance.TryGetComponent(
                PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey,
                out PowerShellTokenCacheProvider provider);
            AzureSession.Instance.TryGetComponent(nameof(TokenCache), out TokenCache tokenCache);
            //If have both user name + password, use new Credential
            var credentialOptions = new UsernamePasswordCredentialOptions()
            {
                AuthorityHost = new Uri(authority),
                //CacheProvider = provider
                TokenCache = tokenCache
                //EnablePersistentCache = EnablePersistenceCache,
                //AllowUnencryptedCache = true
            };
            if (upParameters.Password != null)
            {
                passwordCredential = new UsernamePasswordCredential(upParameters.UserId, upParameters.Password.ConvertToString(), tenantId, clientId, credentialOptions);
                var authTask = passwordCredential.AuthenticateAsync(requestContext, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                return MsalAccessToken.GetAccessTokenAsync(
                    authTask,
                    () => passwordCredential.GetTokenAsync(requestContext, cancellationToken),
                    (AuthenticationRecord record) => { UserCredentialMap[record.HomeAccountId] = passwordCredential; });
            }
            else if (UserCredentialMap.TryGetValue(upParameters.HomeAccountId, out passwordCredential))
            {
                var tokenTask = passwordCredential.GetTokenAsync(requestContext, cancellationToken);
                return MsalAccessToken.GetAccessTokenAsync(tokenTask, upParameters.TenantId, upParameters.UserId);
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
