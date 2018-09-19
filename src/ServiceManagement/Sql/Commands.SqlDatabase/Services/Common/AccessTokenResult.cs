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
using System.Globalization;
using System.Net;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common
{
    /// <summary>
    /// Represents the result returned by the Management Service when executing <c>GetAccessToken</c>
    /// operation.
    /// </summary>
    public class AccessTokenResult
    {
        private readonly string accessToken;
        private readonly Cookie accessCookie;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenResult"/> class with the specified
        /// access token and cookie.
        /// </summary>
        /// <param name="accessToken">The <see cref="string"/> that represents the result token.</param>
        /// <param name="accessCookie">The result access <see cref="Cookie"/>.</param>
        public AccessTokenResult(string accessToken, Cookie accessCookie)
        {
            if (accessToken == null)
            {
                throw new ArgumentNullException("accessToken");
            }

            if (accessCookie == null)
            {
                throw new ArgumentNullException("accessCookie");
            }

            this.accessToken = accessToken;
            this.accessCookie = accessCookie;
        }

        /// <summary>
        /// Gets a string that represents the result access token.
        /// </summary>
        public string AccessToken
        {
            get { return this.accessToken; }
        }

        /// <summary>
        /// Gets the result access <see cref="Cookie"/>.
        /// </summary>
        public Cookie AccessCookie
        {
            get { return this.accessCookie; }
        }
        
        /// <summary>
        /// Validates the specified <see cref="AccessTokenResult"/> object and throws an exception
        /// in case it is invalid.
        /// </summary>
        /// <param name="serviceRoot">The server root <see cref="Uri"/>.</param>
        /// <param name="accessToken">The <see cref="AccessTokenResult"/> object to be validated.</param>
        internal static void ValidateAccessToken(Uri serviceRoot, AccessTokenResult accessToken)
        {
            if (accessToken == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.InvalidAuthentication,
                        serviceRoot.AbsoluteUri.ToString()));
            }
        }
    }
}
