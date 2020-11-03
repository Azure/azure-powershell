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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class DeviceCodeAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var deviceCodeParameters = parameters as DeviceCodeParameters;
            var tokenCacheProvider = parameters.TokenCacheProvider;
            var onPremise = parameters.Environment.OnPremise;
            //null instead of "organizations" should be passed to Azure.Identity to support MSA account
            var tenantId = onPremise ? AdfsTenant :
                (string.Equals(parameters.TenantId, OrganizationsTenant, StringComparison.OrdinalIgnoreCase) ? null : parameters.TenantId);
            var resource = parameters.Environment.GetEndpoint(parameters.ResourceId) ?? parameters.ResourceId;
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var clientId = AuthenticationHelpers.PowerShellClientId;
            var authority = parameters.Environment.ActiveDirectoryAuthority;

            var requestContext = new TokenRequestContext(scopes);
            AzureSession.Instance.TryGetComponent(nameof(PowerShellTokenCache), out PowerShellTokenCache tokenCache);

            DeviceCodeCredentialOptions options = new DeviceCodeCredentialOptions()
            {
                DeviceCodeCallback = DeviceCodeFunc,
                AuthorityHost = new Uri(authority),
                ClientId = clientId,
                TenantId = onPremise ? tenantId : null,
                TokenCache = tokenCache.TokenCache,
            };
            var codeCredential = new DeviceCodeCredential(options);

            var authTask = codeCredential.AuthenticateAsync(requestContext, cancellationToken);
            return MsalAccessToken.GetAccessTokenAsync(
                authTask,
                codeCredential,
                requestContext,
                cancellationToken);
        }

        private Task DeviceCodeFunc(DeviceCodeInfo info, CancellationToken cancellation)
        {
            WriteWarning(info.Message);
            return Task.CompletedTask;
        }

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
