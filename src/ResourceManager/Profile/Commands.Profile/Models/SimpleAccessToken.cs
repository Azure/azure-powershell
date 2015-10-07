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
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// Provides access token information for a bearer token
    /// </summary>
    public class SimpleAccessToken : IAccessToken
    {
        public const string _defaultTokenType = "Bearer";
        private string _tokenType;

        /// <summary>
        /// Create a new access token from the given account and tenant id
        /// </summary>
        /// <param name="account">The account, containign user id, access token information</param>
        /// <param name="tenantId">The tenant id for the given access token</param>
        public SimpleAccessToken(AzureAccount account, string tenantId)
        {
            if (account == null)
            {
                throw new ArgumentNullException("account");
            }
            if (string.IsNullOrWhiteSpace(account.Id))
            {
                throw new ArgumentOutOfRangeException("account", Resources.AccessTokenRequiresAccount);
            }
            if (account.Type != AzureAccount.AccountType.AccessToken ||
                !account.IsPropertySet(AzureAccount.Property.AccessToken))
            {
                throw new ArgumentException(Resources.TypeNotAccessToken);
            }
            this.UserId = account.Id;
            this._tokenType = _defaultTokenType;
            this.AccessToken = account.GetProperty(AzureAccount.Property.AccessToken);
            this.TenantId = tenantId;
        }
        public string AccessToken { get; private set; }

        public void AuthorizeRequest(System.Action<string, string> authTokenSetter)
        {
            authTokenSetter(_tokenType, AccessToken);
        }

        public LoginType LoginType
        {
            get { return LoginType.OrgId; }
        }

        public string TenantId
        {
            get; 
            private set;
        }

        public string UserId { get; private set; }
    }
}
