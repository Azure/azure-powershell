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

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Interface for authentication with distributed responsibility
    /// </summary>
    public interface IAuthenticator
    {
        /// <summary>
        /// The next authenticator in the chain
        /// </summary>
        IAuthenticator Next { get; set; }

        /// <summary>
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information (e.g., tenant, token cache, etc.)</param>
        /// <returns></returns>
        bool CanAuthenticate(AuthenticationParameters parameters);

        /// <summary>
        /// Apply this authenticator to the given authentication parameters
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information (e.g., tenant, token cache, etc.)</param>
        /// <returns></returns>
        Task<IAccessToken> Authenticate(AuthenticationParameters parameters);

        /// <summary>
        /// Apply this authenticator to the given authentication parameters
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information (e.g., tenant, token cache, etc.)</param>
        /// <param name="cancellationToken">The cancellation token provided from the cmdlet to halt authentication.</param>
        /// <returns></returns>
        Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken);

        /// <summary>
        /// Determine if this request can be authenticated using the given authenticator, and authenticate if it can
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information (e.g., tenant, token cache, etc.)</param>
        /// <param name="token">The token based authentication information</param>
        /// <returns></returns>
        bool TryAuthenticate(AuthenticationParameters parameters, out Task<IAccessToken> token);

        /// <summary>
        /// Determine if this request can be authenticated using the given authenticator, and authenticate if it can
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information (e.g., tenant, token cache, etc.)</param>
        /// <param name="cancellationToken">The cancellation token provided from the cmdlet to halt authentication.</param>
        /// <param name="token">The token based authentication information</param>
        /// <returns></returns>
        bool TryAuthenticate(AuthenticationParameters parameters, CancellationToken cancellationToken, out Task<IAccessToken> token);

        /// <summary>
        /// Get authentication recrod for telemetry
        /// </summary>
        AuthTelemetryRecord GetDataForTelemetry();
    }
}
