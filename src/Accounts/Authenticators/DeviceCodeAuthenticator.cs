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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Identity.Client;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class DeviceCodeAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var scopes = new string[] { string.Format(AuthenticationHelpers.DefaultScope, parameters.ResourceEndpoint) };
            var clientId = AuthenticationHelpers.PowerShellClientId;
            var authority = AuthenticationHelpers.GetAuthority(parameters.Environment, parameters.TenantId);
            var publicClient = SharedTokenCacheClientFactory.CreatePublicClient(clientId: clientId, authority: authority);
            var response = GetResponseAsync(publicClient, scopes, cancellationTokenSource.Token);
            return AuthenticationResultToken.GetAccessTokenAsync(response);
        }

        public async Task<AuthenticationResult> GetResponseAsync(IPublicClientApplication client, string[] scopes, CancellationToken cancellationToken)
        {
            return await client.AcquireTokenWithDeviceCode(scopes, deviceCodeResult =>
            {
                WriteWarning(deviceCodeResult?.Message);
                return Task.FromResult(0);
            }).ExecuteAsync(cancellationToken);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is DeviceCodeParameters;
        }

        private void WriteWarning(string message)
        {
            if (AzureSession.Instance.TryGetComponent(AzureRMCmdlet.WriteWarningKey, out EventHandler<StreamEventArgs> writeWarningEvent))
            {
                writeWarningEvent(this, new StreamEventArgs() { Message = message });
            }
        }
    }
}
