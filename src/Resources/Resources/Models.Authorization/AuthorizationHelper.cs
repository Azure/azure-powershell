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

using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    public class AuthorizationHelper
    {
        private static Regex subscriptionRegex = new Regex("/subscriptions/([^/]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string ConstructFullyQualifiedRoleDefinitionIdFromScopeAndIdAsGuid(string scope, string Id)
        {
            if (string.IsNullOrEmpty(scope) || string.IsNullOrEmpty(Id))
            {
                return null;
            }

            return string.Concat(scope.TrimEnd('/'), "/providers/Microsoft.Authorization/roleDefinitions/", Id);
        }

        public static string ConstructFullyQualifiedRoleDefinitionIdFromSubscriptionAndIdAsGuid(string subscriptionId, string roleId)
        {
            if (string.IsNullOrEmpty(subscriptionId) || string.IsNullOrEmpty(roleId))
            {
                return null;
            }

            return string.Concat(GetSubscriptionScope(subscriptionId).TrimEnd('/'), "/providers/Microsoft.Authorization/roleDefinitions/", roleId);
        }

        public static string GetSubscriptionScope(string subscriptionId)
        {
            if (string.IsNullOrEmpty(subscriptionId))
            {
                return null;
            }

            return string.Concat("/subscriptions/", subscriptionId);
        }

        public static string GetResourceSubscription(string id)
        {
            var match = subscriptionRegex.Match(id);

            if (match.Success != true)
            {
                return null;
            }

            return match.Groups[1].Value;
        }
    }
}
