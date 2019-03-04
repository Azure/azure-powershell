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
using System.Security;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.AppConfig;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    /// <summary>
    /// Authenticate username + password scenarios
    /// </summary>
    public class UsernamePasswordAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters)
        {
            var upParameters = parameters as UsernamePasswordParameters;
            var scopes = new string[] { string.Format(AuthenticationHelpers.UserImpersonationScope, upParameters.Environment.ActiveDirectoryServiceEndpointResourceId) };
            var publicClient = PublicClientApplicationBuilder.Create(AuthenticationHelpers.PowerShellClientId)
                        .WithAuthority(AuthenticationHelpers.GetAuthority(parameters.Environment, parameters.TenantId))
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

            var response = publicClient.AcquireTokenByUsernamePassword(scopes, upParameters.UserId, upParameters.Password)
                                       .ExecuteAsync();
            return AuthenticationResultToken.GetAccessTokenAsync(response);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is UsernamePasswordParameters;
        }
    }
}
