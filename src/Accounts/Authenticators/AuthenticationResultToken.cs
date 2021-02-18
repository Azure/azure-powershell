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

<<<<<<< HEAD
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Threading.Tasks;

=======
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Identity.Client;

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
namespace Microsoft.Azure.PowerShell.Authenticators
{
    /// <summary>
    /// Access Token using a single authentication result
    /// </summary>
    public class AuthenticationResultToken : IAccessToken
    {
        AuthenticationResult _result;
<<<<<<< HEAD
        public string AccessToken => _result.AccessToken;

        public string UserId => _result.UserInfo.DisplayableId;

        public string TenantId => _result.TenantId;

        public string LoginType => "User";

        public AuthenticationResultToken(AuthenticationResult result)
        {
            _result = result;
=======
        public string AccessToken { get; }

        public string UserId { get; }

        public string TenantId { get; }

        public string LoginType => "User";

        public string HomeAccountId { get; set; }

        public IDictionary<string, string> ExtendedProperties => throw new NotImplementedException();

        public AuthenticationResultToken(AuthenticationResult result)
        {
            _result = result;
            AccessToken = result.AccessToken;
            UserId = result.Account?.Username;
            TenantId = result.TenantId;
        }

        public AuthenticationResultToken(AuthenticationResult result, string userId = null, string tenantId = null)
        {
            _result = result;
            AccessToken = result.AccessToken;
            UserId = result.Account?.Username ?? userId;
            TenantId = result.TenantId ?? tenantId;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        public void AuthorizeRequest(Action<string, string> authTokenSetter)
        {
            var header = _result.CreateAuthorizationHeader();
<<<<<<< HEAD
            authTokenSetter(_result.AccessTokenType, _result.AccessToken);
=======
            authTokenSetter("Bearer", _result.AccessToken);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        public static async Task<IAccessToken> GetAccessTokenAsync(Task<AuthenticationResult> result)
        {
            return new AuthenticationResultToken(await result);
        }

<<<<<<< HEAD
=======
        public static async Task<IAccessToken> GetAccessTokenAsync(Task<AuthenticationResult> result, string userId = null, string tenantId = null)
        {
            return new AuthenticationResultToken(await result, userId, tenantId);
        }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public static IAccessToken GetAccessToken(AuthenticationResult result)
        {
            return new AuthenticationResultToken(result);
        }

<<<<<<< HEAD
=======
        public static IAccessToken GetAccessToken(AuthenticationResult result, string userId = null, string tenantId = null)
        {
            return new AuthenticationResultToken(result, userId, tenantId);
        }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
