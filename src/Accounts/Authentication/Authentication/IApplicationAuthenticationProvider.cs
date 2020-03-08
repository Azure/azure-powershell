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

using Microsoft.Identity.Client;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Interface to platform-specific methods for securely storing client credentials
    /// </summary>
    public interface IApplicationAuthenticationProvider
    {
        /// <summary>
        /// Retrieve ClientCredentials for an active directory application.
        /// </summary>
        /// <param name="clientId">The active directory client Id of the application.</param>
        /// <param name="audience">The audience to target</param>
        /// <returns>authentication result which can be used for authentication with the given audience.</returns>
        Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience);
    }
}