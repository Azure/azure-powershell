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
//

using Microsoft.Azure.PowerShell.Authenticators.Identity.Core;

using System;
using System.Text.Json;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal static class TokenHelper
    {
        public static (string ClientId, string TenantId, string Upn, string ObjectId) ParseAccountInfoFromToken(string token)
        {
            Argument.AssertNotNullOrEmpty(token, nameof(token));
            var parts = token.Split('.');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid token", nameof(token));
            }

            (string ClientId, string TenantId, string Upn, string ObjectId) result = default;

            try
            {
                string convertedToken = parts[1].Replace('_', '/').Replace('-', '+');
                switch (parts[1].Length % 4)
                {
                    case 2:
                        convertedToken += "==";
                        break;
                    case 3:
                        convertedToken += "=";
                        break;
                }
                Utf8JsonReader reader = new Utf8JsonReader(Convert.FromBase64String(convertedToken));
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        switch (reader.GetString())
                        {
                            case "appid":
                                reader.Read();
                                result.ClientId = reader.GetString();
                                break;

                            case "tid":
                                reader.Read();
                                result.TenantId = reader.GetString();
                                break;

                            case "upn":
                                reader.Read();
                                result.Upn = reader.GetString();
                                break;

                            case "oid":
                                reader.Read();
                                result.ObjectId = reader.GetString();
                                break;
                            default:
                                reader.Read();
                                break;
                        }
                    }
                }
            }
            catch
            {
                AzureIdentityEventSource.Singleton.UnableToParseAccountDetailsFromToken();
            }

            return result;
        }
    }
}
