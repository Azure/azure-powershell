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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    /// <summary>
    /// Access Token using a single authentication result
    /// </summary>
    public class AuthenticationResultToken : IAccessToken
    {
        AuthenticationResult _result;
        public string AccessToken => _result.AccessToken;

        public string UserId => _result.UserInfo.DisplayableId;

        public string TenantId => _result.TenantId;

        public string LoginType => "User";

        public AuthenticationResultToken(AuthenticationResult result)
        {
            _result = result;
        }

        public void AuthorizeRequest(Action<string, string> authTokenSetter)
        {
            var header = _result.CreateAuthorizationHeader();
            authTokenSetter(_result.AccessTokenType, _result.AccessToken);
        }

        public static async Task<IAccessToken> GetAccessTokenAsync(Task<AuthenticationResult> result)
        {
            return new AuthenticationResultToken(await result);
        }

        public static IAccessToken GetAccessToken(AuthenticationResult result)
        {
            return new AuthenticationResultToken(result);
        }

    }
}
