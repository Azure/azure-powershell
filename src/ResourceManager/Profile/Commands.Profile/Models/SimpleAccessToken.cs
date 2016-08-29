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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using System;

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
        /// <param name="account">The account, containing user id, access token information</param>
        /// <param name="tenantId">The tenant id for the given access token</param>
        /// <param name="tokenType">The token type for the given token.</param>
        public SimpleAccessToken(AzureAccount account, string tenantId, string tokenType = _defaultTokenType)
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
            this._tokenType = tokenType;
            this.AccessToken = account.GetProperty(AzureAccount.Property.AccessToken);
            this.TenantId = tenantId;
        }


        /// <summary>
        /// The access token to be applied to a request message
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Authorize a request using an authorization setter function.
        /// </summary>
        /// <param name="authTokenSetter">The authorization token setter function.</param>
        public void AuthorizeRequest(System.Action<string, string> authTokenSetter)
        {
            authTokenSetter(_tokenType, AccessToken);
        }

        /// <summary>
        /// The login type for this token
        /// </summary>
        public LoginType LoginType
        {
            get { return LoginType.OrgId; }
        }

        /// <summary>
        /// The tenant Id for this token.
        /// </summary>
        public string TenantId { get; private set; }

        /// <summary>
        /// The User Id associated with this token.
        /// </summary>
        public string UserId { get; private set; }
    }
}
