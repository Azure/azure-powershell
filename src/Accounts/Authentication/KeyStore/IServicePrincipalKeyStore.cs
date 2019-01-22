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

using System.Security;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// This interface represents objects that can be used
    /// to store and retrieve service principal keys.
    /// </summary>
    public interface IServicePrincipalKeyStore
    {
        /// <summary>
        /// Store the service principal key on the user's machine.
        /// </summary>
        /// <param name="appId">Application id of the service principal.</param>
        /// <param name="tenantId">Id of the tenant that the service principal is found in.</param>
        /// <param name="serviceKey">Key for the provided service principal.</param>
        void SaveKey(
            string appId,
            string tenantId,
            SecureString serviceKey);

        /// <summary>
        /// Retrieves the service principal key from the store.
        /// </summary>
        /// <param name="appId">Application id of the service principal.</param>
        /// <param name="tenantId">Id of the tenant that the service principal is found in.</param>
        /// <returns>Key for the provided service principal.</returns>
        SecureString GetKey(
            string appId,
            string tenantId);

        /// <summary>
        /// Removes a service principal key from the store.
        /// </summary>
        /// <param name="appId">Application id of the service principal.</param>
        /// <param name="tenantId">Id of the tenant that the service principal is found in.</param>
        void DeleteKey(
            string appId,
            string tenantId);
    }
}
