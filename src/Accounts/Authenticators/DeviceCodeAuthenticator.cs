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

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class DeviceCodeAuthenticator : DelegatingAuthenticator
    {
        private bool EnablePersistenceCache { get; set; }

        private ConcurrentDictionary<string, DeviceCodeCredential> UserCredentialMap = new ConcurrentDictionary<string, DeviceCodeCredential>(StringComparer.OrdinalIgnoreCase);

        public DeviceCodeAuthenticator(bool enablePersistentCache = true)
        {
            EnablePersistenceCache = enablePersistentCache;
        }

        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var deviceCodeParameters = parameters as DeviceCodeParameters;
            var authenticationClientFactory = parameters.AuthenticationClientFactory;
            var onPremise = parameters.Environment.OnPremise;
            var tenantId = onPremise ? AdfsTenant : parameters.TenantId;
            var resource = parameters.Environment.GetEndpoint(parameters.ResourceId) ?? parameters.ResourceId;
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var clientId = AuthenticationHelpers.PowerShellClientId;
            var authority = onPremise ?
                                parameters.Environment.ActiveDirectoryAuthority :
                                AuthenticationHelpers.GetAuthority(parameters.Environment, parameters.TenantId);

            var requestContext = new TokenRequestContext(scopes);
            DeviceCodeCredential codeCredential = null;
            AzureSession.Instance.TryGetComponent(nameof(TokenCache), out TokenCache tokenCache);
            if (!string.IsNullOrEmpty(deviceCodeParameters.UserId))
            {
                var credentialKey = deviceCodeParameters.HomeAccountId;
                if (!UserCredentialMap.TryGetValue(credentialKey, out codeCredential))
                {
                    AzureSession.Instance.TryGetComponent(
                        PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey,
                        out PowerShellTokenCacheProvider tokenCacheProvider);
                    //MsalPublicApplication 
                    DeviceCodeCredentialOptions options = new DeviceCodeCredentialOptions()
                    {
                        AuthorityHost = new Uri(authority),
                        ClientId = clientId,
                        TenantId = tenantId,
                        //CacheProvider = tokenCacheProvider,
                        TokenCache = tokenCache,
                        //EnablePersistentCache = EnablePersistenceCache,
                        //AllowUnencryptedCache = true,
                        AuthenticationRecord = IdentityModelFactory.AuthenticationRecord(
                            deviceCodeParameters.UserId,
                            authority: null,
                            homeAccountId: deviceCodeParameters.HomeAccountId,
                            tenantId: parameters.TenantId,
                            clientId: clientId)
                    };
                    codeCredential = new DeviceCodeCredential(DeviceCodeFunc, options);
                    UserCredentialMap[credentialKey] = codeCredential;
                }
                var tokenTask = codeCredential.GetTokenAsync(requestContext, cancellationToken);
                return MsalAccessToken.GetAccessTokenAsync(tokenTask, parameters.TenantId, deviceCodeParameters.UserId);
            }
            else//first time login
            {
                AzureSession.Instance.TryGetComponent(
                    PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey,
                    out PowerShellTokenCacheProvider tokenCacheProvider);
                DeviceCodeCredentialOptions options = new DeviceCodeCredentialOptions()
                {
                    AuthorityHost = new Uri(authority),
                    ClientId = clientId,
                    TenantId = tenantId,
                    //CacheProvider = tokenCacheProvider,
                    TokenCache = tokenCache,
                    //EnablePersistentCache = EnablePersistenceCache,
                    //AllowUnencryptedCache = true,
                };
                codeCredential = new DeviceCodeCredential(DeviceCodeFunc, options);
                var authTask = codeCredential.AuthenticateAsync(requestContext, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                return MsalAccessToken.GetAccessTokenAsync(
                    authTask,
                    () => codeCredential.GetTokenAsync(requestContext, cancellationToken),
                    (AuthenticationRecord record) => { UserCredentialMap[record.HomeAccountId] = codeCredential; });
            }
        }

        private Task DeviceCodeFunc(DeviceCodeInfo info, CancellationToken cancellation)
        {
            WriteWarning(info.Message);
            return Task.CompletedTask;
        }

        //private static async Task<AuthenticationRecord> GetAuthenticationRecordAsync(Task)
        //{

        //}

        //public async Task<AuthenticationResult> GetResponseAsync(IPublicClientApplication client, string[] scopes, CancellationToken cancellationToken)
        //{
        //    return await client.AcquireTokenWithDeviceCode(scopes, deviceCodeResult =>
        //    {
        //        WriteWarning(deviceCodeResult?.Message);
        //        return Task.FromResult(0);
        //    }).ExecuteAsync(cancellationToken);
        //}

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as DeviceCodeParameters) != null;
        }

        private void WriteWarning(string message)
        {
            EventHandler<StreamEventArgs> writeWarningEvent;
            if (AzureSession.Instance.TryGetComponent("WriteWarning", out writeWarningEvent))
            {
                writeWarningEvent(this, new StreamEventArgs() { Message = message });
            }
        }
    }
}
