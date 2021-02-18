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

<<<<<<< HEAD
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Security;
=======
using System.Threading;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
        /// Determine if this authenticator can apply to the given authentication parameters
        /// </summary>
        /// <param name="account">The account to authenticate</param>
        /// <param name="environment">The environment to authenticate in</param>
        /// <param name="tenant">The tenant</param>
        /// <param name="password">The secure credentials for the given account</param>
        /// <param name="promptBehavior">The desired prompting behavior during authentication</param>
        /// <param name="promptAction">Action to take if the user need to be prompted</param>
        /// <param name="tokenCache">The token cache to use in this authentication</param>
        /// <param name="resourceId">The resource that will need proof of authentication</param>
        /// <returns>true if this authenticator can be applied to the given parameters, otherwise false</returns>
        bool CanAuthenticate(IAzureAccount account, IAzureEnvironment environment, string tenant, SecureString password, string promptBehavior, Task<Action<string>> promptAction, IAzureTokenCache tokenCache, string resourceId);
=======
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information (e.g., tenant, token cache, etc.)</param>
        /// <returns></returns>
        bool CanAuthenticate(AuthenticationParameters parameters);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        /// <summary>
        /// Apply this authenticator to the given authentication parameters
        /// </summary>
<<<<<<< HEAD
        /// <param name="account">The account to authenticate</param>
        /// <param name="environment">The environment to authenticate in</param>
        /// <param name="tenant">The tenant</param>
        /// <param name="password">The secure credentials for the given account</param>
        /// <param name="promptBehavior">The desired prompting behavior during authentication</param>
        /// <param name="promptAction">Action to take if the user need to be prompted</param>
        /// <param name="tokenCache">The token cache to use in this authentication</param>
        /// <param name="resourceId">The resource that will need proof of authentication</param>
        /// <returns>The token based authntication information</returns>
        Task<IAccessToken> Authenticate(IAzureAccount account, IAzureEnvironment environment, string tenant, SecureString password, string promptBehavior, Task<Action<string>> promptAction, IAzureTokenCache tokenCache, string resourceId);

        /// <summary>
        /// Determine if this request can be authenticated using the given authenticaotr, and authenticate if it can 
        /// </summary>
        /// <param name="account">The account to authenticate</param>
        /// <param name="environment">The environment to authenticate in</param>
        /// <param name="tenant">The tenant</param>
        /// <param name="password">The secure credentials for the given account</param>
        /// <param name="promptBehavior">The desired prompting behavior during authentication</param>
        /// <param name="promptAction">Action to take if the user need to be prompted</param>
        /// <param name="tokenCache">The token cache to use in this authentication</param>
        /// <param name="resourceId">The resource that will need proof of authentication</param>
        /// <param name="token">The token based authntication information</param>
        /// <returns>true if the request was authenticated, otherwise false</returns>
        bool TryAuthenticate(IAzureAccount account, IAzureEnvironment environment, string tenant, SecureString password, string promptBehavior, Task<Action<string>> promptAction, IAzureTokenCache tokenCache, string resourceId, out Task<IAccessToken> token);
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
