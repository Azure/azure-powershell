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
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClientRuntime = Microsoft.Rest;

namespace Microsoft.Azure.Commands.Common.Authentication.Authentication
{
    internal class RenewingAccessTokenProvider : ClientRuntime.ITokenProvider
    {
        private const string _type = "Bearer";
        private readonly Func<string> _accessToken;

        /// <summary>
        /// Create a token provider that returns the given 
        /// access token.
        /// </summary>
        /// <param name="accessToken">The access token to return.</param>
        public RenewingAccessTokenProvider(Func<string> accessToken)
        {
            _accessToken = accessToken;
        }

        /// <summary>
        /// Returns the static access token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for this action.  
        /// <returns>The access token.</returns>
        public Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(System.Threading.CancellationToken cancellationToken)
        {
            return Task.FromResult(new AuthenticationHeaderValue(_type, _accessToken()));
        }
    }
}