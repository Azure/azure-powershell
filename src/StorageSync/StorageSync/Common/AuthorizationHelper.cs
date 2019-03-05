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

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    /// <summary>
    /// Class AuthorizationHelper.
    /// </summary>
    public class AuthorizationHelper
    {
        /// <summary>
        /// Constructs the fully qualified role definition identifier from subscription and identifier as unique identifier.
        /// </summary>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>System.String.</returns>
        public static string ConstructFullyQualifiedRoleDefinitionIdFromSubscriptionAndIdAsGuid(string subscriptionId, string roleId)
        {
            if (string.IsNullOrEmpty(subscriptionId) || string.IsNullOrEmpty(roleId))
            {
                return null;
            }

            return string.Concat(GetSubscriptionScope(subscriptionId).TrimEnd('/'), "/providers/Microsoft.Authorization/roleDefinitions/", roleId);
        }

        /// <summary>
        /// Gets the subscription scope.
        /// </summary>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <returns>System.String.</returns>
        public static string GetSubscriptionScope(string subscriptionId)
        {
            if (string.IsNullOrEmpty(subscriptionId))
            {
                return null;
            }

            return string.Concat("/subscriptions/", subscriptionId);
        }
    }
}
