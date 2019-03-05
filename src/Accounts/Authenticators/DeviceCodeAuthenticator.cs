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
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Identity.Client;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class DeviceCodeAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters)
        {
            var scopes = new string[] { string.Format(AuthenticationHelpers.UserImpersonationScope, parameters.Environment.ActiveDirectoryServiceEndpointResourceId) };
            var publicClient = new PublicClientApplication(
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
            return parameters is DeviceCodeParameters;
        }
    }
}
