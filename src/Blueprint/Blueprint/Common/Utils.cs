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
