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

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Canonical representation of a renewable access token
    /// </summary>
    public interface IAccessToken
    {
        /// <summary>
        /// Authorize the given request, using the given function for setting the token
        /// </summary>
        /// <param name="authTokenSetter">A method that quthorizes a request given the access token type and token value as strings</param>
        void AuthorizeRequest(Action<string, string> authTokenSetter);

        /// <summary>
        /// The current access token
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        /// The displayable user id
        /// </summary>
        string UserId { get; }

        /// <summary>
        /// The Active Directory tenant for this token
        /// </summary>
        string TenantId { get; }

        /// <summary>
        /// If this token was obtained with user credentials, the type of user credentials used
        /// </summary>
        string LoginType { get; }
    }
}
