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
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common
{
    /// <summary>
    /// Defines the implementation of the <see cref="DataServiceAccess"/> utility class.
    /// </summary>
    public static class DataServiceAccess
    {
        private const string LogOnServiceHeader = "sqlauthorization";
        private const string HeaderFormatter = "Basic {0}";

        /// <summary>
        /// Retrieves and returns the Management Service access token for the specified user credentials.
        /// </summary>
        /// <param name="accessUri">The <see cref="Uri"/> to the Management Service <c>GetAccessToken</c> operation.</param>
        /// <param name="credentials">The credentials to be used to authenticate the user.</param>
        /// <returns>An instance of <see cref="AccessTokenResult"/> with the retrieved access token and cookie.</returns>
        public static AccessTokenResult GetAccessToken(Uri accessUri, SqlAuthenticationCredentials credentials)
        {
            if (accessUri == null)
            {
                throw new ArgumentNullException("accessUri");
            }

            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }

            HttpWebRequest request = CreateGetAccessTokenRequest(accessUri, credentials);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            AccessTokenResult result = RetrieveAccessTokenFromResponse(response);

            return result;
        }

        /// <summary>
        /// Retrieves and returns the access token from the specified response or returns <c>null</c>
        /// if was not retrieved.
        /// </summary>
        /// <param name="response">The <see cref="HttpWebResponse"/> to the Management Service <c>GetAccessToken</c> operation.</param>
        /// <returns>An instance of <see cref="AccessTokenResult"/> with the retrieved access token and cookie.</returns>
        private static AccessTokenResult RetrieveAccessTokenFromResponse(HttpWebResponse response)
        {
            AccessTokenResult result = null;

            // Read the response into a stream
            Stream dataStream = response.GetResponseStream();
            if (dataStream != null)
            {
                string tokenXml;
                using (StreamReader streamReader = new StreamReader(dataStream, Encoding.UTF8))
                {
                    tokenXml = streamReader.ReadToEnd();
                }

                // Must have both a token and cookie for success
                string accessToken = XElement.Parse(tokenXml).Value;
                Cookie accessCookie = response.Cookies[DataServiceConstants.AccessCookie];

                result = new AccessTokenResult(accessToken, accessCookie);
            }

            return result;
        }

        /// <summary>
        /// Utility method that creates and returns an instance of <see cref="HttpWebRequest"/> that
        /// connects to <c>GetAccessToken</c> WCF operation with the specified user name and password.
        /// </summary>
        /// <param name="accessUri">The <see cref="Uri"/> to the Management Service <c>GetAccessToken</c> operation.</param>
        /// <param name="userName">The user name to retrieve the access token for.</param>
        /// <param name="password">The user password.</param>
        /// <returns>An instance of <see cref="HttpWebRequest"/> object.</returns>
        private static HttpWebRequest CreateGetAccessTokenRequest(Uri accessUri, SqlAuthenticationCredentials credentials)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(accessUri);

            request.Method = "GET";

            string escapedUserName = EscapeConnectionCredentials(credentials.UserName);
            string escapedPassword = EscapeConnectionCredentials(credentials.Password);

            string escapedCredentials = string.Format(
                CultureInfo.InvariantCulture,
                "{0}:{1}",
                escapedUserName,
                escapedPassword);

            string encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(escapedCredentials));

            request.Headers[LogOnServiceHeader] = string.Format(CultureInfo.InvariantCulture, HeaderFormatter, encodedCredentials);
            request.UserAgent = ApiConstants.UserAgentHeaderValue;

            request.CookieContainer = new CookieContainer();

            return request;
        }

        /// <summary>
        /// Returns the string value with escaped the \ and : characters
        /// </summary>
        /// <param name="value">The string to escape.</param>
        /// <returns>The escaped string.</returns>
        private static string EscapeConnectionCredentials(string value)
        {
            return value.Replace("\\", "\\\\").Replace(":", "\\:");
        }
    }
}
