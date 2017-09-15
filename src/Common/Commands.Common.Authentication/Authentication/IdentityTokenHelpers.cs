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
using System.Linq;
using System.Text;
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    internal static class IdentityTokenHelpers
    {
        internal const string IssuerKey = "iss";

        /// <summary>
        /// Get the issuer text from an identity token
        /// </summary>
        /// <param name="token">The token to decode and retrieve the issuer from.</param>
        /// <param name="issuer">The issuer claim from the token, if any</param>
        /// <returns>true if the issuer claim exists in the token, otherwise false</returns>
        internal static bool TryGetIssuer(string token, out string issuer)
        {
            bool result = false;
            issuer = null;
            if (!string.IsNullOrWhiteSpace(token))
            {
                try
                {
                    var tokenParts = token.Split('.');
                    if (tokenParts.Length > 1)
                    {
                        token = tokenParts[1];
                    }

                    switch (token.Length % 4)
                    {
                        case 2:
                            token += "==";
                            break;
                        case 3:
                            token += "=";
                            break;
                    }

                    var tokenJson = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                    var parsedToken = JToken.Parse(tokenJson);
                    issuer = parsedToken.Value<string>(IssuerKey);
                    result = true;
                    TracingAdapter.Information(Resources.TokenIssuerTrace, token, tokenJson, issuer);
                }
                catch (JsonException)
                {
                    // ignore Json exceptions
                }
            }

            return result;
        }

        internal static bool TryGetTenantFromIssuer(string issuer, out string tenantId)
        {
            tenantId = null;
            var result = false;
            if (!string.IsNullOrWhiteSpace(issuer) && issuer.Contains("/"))
            {
                var paths = issuer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (paths.Length > 2)
                {
                    Guid tenantGuid;
                    if (Guid.TryParse(paths.Last(), out tenantGuid))
                    {
                        result = true;
                        tenantId = tenantGuid.ToString();
                    }
                }
            }

            return result;
        }
    }
}