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
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.AppConfig;
using Microsoft.Identity.Client.Extensibility;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class DeviceCodeAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters)
        {
            var interactiveParameters = parameters as InteractiveParameters;
            IPublicClientApplication publicClient = null;
            var scopes = new string[] { string.Format(AuthenticationHelpers.UserImpersonationScope, parameters.Environment.ActiveDirectoryServiceEndpointResourceId) };
            TcpListener listener = null;
            var replyUrl = string.Empty;
            var port = 8399;
            try
            {
                while (++port < 9000)
                {
                    try
                    {
                        listener = new TcpListener(IPAddress.Loopback, port);
                        listener.Start();
                        replyUrl = string.Format("http://localhost:{0}/", port);
                        listener.Stop();
                        break;
                    }
                    catch (Exception ex)
                    {
                        interactiveParameters.PromptAction(string.Format("Port {0} is taken with exception '{1}'; trying to connect to the next port.", port, ex.Message));
                        listener?.Stop();
                    }
                }

                if (!string.IsNullOrEmpty(replyUrl))
                {
                    publicClient = PublicClientApplicationBuilder.Create(AuthenticationHelpers.PowerShellClientId)
                        .WithAuthority(AuthenticationHelpers.GetAuthority(parameters.Environment, parameters.TenantId))
                        .WithRedirectUri(replyUrl)
                        .Build();

                    var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".Azure", "TokenCache.dat");
                    publicClient.UserTokenCache.SetAfterAccess(notificationArgs =>
                    {
                        if (notificationArgs.HasStateChanged)
                        {
                            AzureSession.Instance.DataStore.WriteFile(filePath, notificationArgs.TokenCache.SerializeMsalV3());
                        }
                    });
                    publicClient.UserTokenCache.SetBeforeAccess(notificationArgs =>
                    {
                        notificationArgs.TokenCache.DeserializeMsalV3(AzureSession.Instance.DataStore.ReadFileAsBytes(filePath));
                    });
                    var interactiveResponse = publicClient.AcquireTokenInteractive(scopes, null)
                        .WithCustomWebUi(new CustomWebUi(listener, interactiveParameters.PromptAction))
                        .ExecuteAsync();
                    return AuthenticationResultToken.GetAccessTokenAsync(interactiveResponse);
                }
            }
            catch { }

           publicClient = new PublicClientApplication(
                AuthenticationHelpers.PowerShellClientId,
                AuthenticationHelpers.GetAuthority(parameters.Environment, parameters.TenantId),
                parameters.TokenCache.GetUserCache() as TokenCache);
            var response = publicClient.AcquireTokenWithDeviceCodeAsync(scopes, deviceCodeResult =>
            {
                Console.WriteLine(deviceCodeResult?.Message);
                return Task.FromResult(0);
            });
            return AuthenticationResultToken.GetAccessTokenAsync(response);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is InteractiveParameters;
        }
    }
}
