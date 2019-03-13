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

namespace Microsoft.Azure.Commands.Blueprint.Common
{
    public class Utils
    {
        /// <summary>
        /// Get definition location. Either a subcscription or a management group.
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static string GetDefinitionLocationId(string scope)
        {
            if (string.IsNullOrEmpty(scope))
                return null;

            string[] tokens = scope.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            string locationId = null;

            if (tokens != null && tokens.Length == 2)
            {
                locationId = string.Equals(tokens[0], "subscriptions", StringComparison.OrdinalIgnoreCase) ? tokens[1] : null;      
            }

            if (tokens != null && tokens.Length == 4)
            {
                locationId = string.Equals(tokens[2], "managementgroups", StringComparison.OrdinalIgnoreCase) ? tokens[3] : null;
            }

            return locationId;
        }

        public static string GetScopeForManagementGroup(string managementGroupId)
        {
            return string.Format(BlueprintConstants.ManagementGroupScope, managementGroupId);
        }

        public static string GetScopeForSubscription(string subscriptionId)
        {
            return string.Format(BlueprintConstants.SubscriptionScope, subscriptionId);
        }
    }
}
