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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Security;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// The parameters for application client. See https://aka.ms/msal-net-client-assertion
    /// </summary>
    public class ClientAssertionParameters : AuthenticationParameters
    {
        /// <summary>
        /// Client ID (also known as App ID) of the application as registered in the application registration portal
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The client assertion used to prove the identity of the application to Azure AD. This is a Base-64 encoded JWT.
        /// </summary>
        public SecureString ClientAssertion { get; set; }

        public ClientAssertionParameters(
            PowerShellTokenCacheProvider tokenCacheProvider,
            IAzureEnvironment environment,
            IAzureTokenCache tokenCache,
            string tenantId,
            string resourceId,
            string clientId,
            SecureString clientAssertion) : base(tokenCacheProvider, environment, tokenCache, tenantId, resourceId)
        {
            this.ClientId = clientId;
            this.ClientAssertion = clientAssertion;
        }
    }
}
