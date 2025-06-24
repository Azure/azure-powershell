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

using Azure.Core;
using Azure.Identity;

using Hyak.Common;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            var clientId = Constants.PowerShellClientId;
            var authority = parameters.Environment.ActiveDirectoryAuthority;

            var requestContext = new TokenRequestContext(scopes, isCaeEnabled: true);
            DeviceCodeCredentialOptions options = new DeviceCodeCredentialOptions()
            {
                DeviceCodeCallback = DeviceCodeFunc,
                AuthorityHost = new Uri(authority),
                ClientId = clientId,
                TenantId = tenantId,
                TokenCachePersistenceOptions = tokenCacheProvider.GetTokenCachePersistenceOptions(),
            };
            options.DisableInstanceDiscovery = deviceCodeParameters.DisableInstanceDiscovery ?? options.DisableInstanceDiscovery;
            var codeCredential = new DeviceCodeCredential(options);

            CheckTokenCachePersistanceEnabled = () =>
            {
                return options.TokenCachePersistenceOptions != null && !(options.TokenCachePersistenceOptions is UnsafeTokenCacheOptions);
            };
            CollectTelemetry(codeCredential, options);

            TracingAdapter.Information($"{DateTime.Now:T} - [DeviceCodeAuthenticator] Calling DeviceCodeCredential.AuthenticateAsync - TenantId:'{options.TenantId}', Scopes:'{string.Join(",", scopes)}', AuthorityHost:'{options.AuthorityHost}'");
            var authTask = codeCredential.AuthenticateAsync(requestContext, cancellationToken);
            return MsalAccessToken.GetAccessTokenAsync(
                authTask,
                codeCredential,
                requestContext,
                cancellationToken);
        }

        private Task DeviceCodeFunc(DeviceCodeInfo info, CancellationToken cancellation)
        {
            WriteInfomartion(info.Message, info.UserCode);
            return Task.CompletedTask;
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as DeviceCodeParameters) != null;
        }


        private void WriteInfomartion(string message, string userCode)
        {

            var loginInfo = new StringBuilder();
            string LoginToAzurePhrase = $"{PSStyle.Bold}{PSStyle.BackgroundColor.Blue}[Login to Azure]{PSStyle.Reset} ";
            loginInfo.Append(LoginToAzurePhrase);

            if (!string.IsNullOrEmpty(userCode))
            {
                var formattedUserCode = $"{PSStyle.Underline}{userCode}{PSStyle.Reset}";
                var formattedMessage = message.Replace(userCode, formattedUserCode);
                loginInfo.Append(formattedMessage);
            }
            else
            {
                loginInfo.Append(message);
            }

            EventHandler<StreamEventArgs> writeInforamtionEvent;
            if (AzureSession.Instance.TryGetComponent(AzureRMCmdlet.WriteInformationKey, out writeInforamtionEvent))
            {
                writeInforamtionEvent(this, new StreamEventArgs() { Message = loginInfo.ToString() });
            }
        }
    }
}