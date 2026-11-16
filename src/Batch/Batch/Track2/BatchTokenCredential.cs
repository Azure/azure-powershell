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

using Azure.Core;
using Microsoft.Azure.Commands.Batch.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Batch.Track2
{
    /// <summary>
    /// Track 2 credential for Microsoft Entra ID sign-in. Azure.Compute.Batch always asks for the public-cloud scope
    /// (https://batch.core.windows.net//.default), so this credential ignores the requested scope and returns the token
    /// that Az.Accounts issues for the Batch resource of the current cloud (BatchEndpointResourceId), the same way
    /// KeyVault, Storage and CosmosDB wrap their tokens.
    /// </summary>
    internal sealed class BatchTokenCredential : TokenCredential
    {
        private readonly BatchAadTokenProvider tokenProvider;

        public BatchTokenCredential(BatchAadTokenProvider tokenProvider)
        {
            this.tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            string token = this.tokenProvider.GetAccessToken();
            return new AccessToken(token, GetExpiresOn(token));
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }

        /// <summary>
        /// Reads the "exp" claim of a JWT access token, like Get-AzAccessToken does. If the token can't be read, returns
        /// the current time, so Azure.Core asks for a new token on the next request (what the other modules' wrappers do).
        /// </summary>
        internal static DateTimeOffset GetExpiresOn(string token)
        {
            try
            {
                string[] parts = token?.Split('.');
                if (parts != null && parts.Length >= 2)
                {
                    string payload = parts[1].Replace('-', '+').Replace('_', '/');
                    payload = payload.PadRight(payload.Length + ((4 - payload.Length % 4) % 4), '=');
                    JToken exp = JObject.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(payload)))["exp"];
                    if (exp != null && exp.Type == JTokenType.Integer)
                    {
                        return DateTimeOffset.FromUnixTimeSeconds(exp.Value<long>());
                    }
                }
            }
            catch (Exception ex) when (ex is FormatException || ex is Newtonsoft.Json.JsonException || ex is ArgumentException)
            {
            }

            return DateTimeOffset.UtcNow;
        }
    }
}
