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

namespace Microsoft.Azure.Commands.Advisor.Cmdlets.Utilities
{
    using System;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Models;

    public class SuppressionHelper
    {
        /// <summary>
        /// Position of subscription-id string in resource ID
        /// </summary>
        private const int SUBSCRIPTION_STRING_POSITION = 1;

        /// <summary>
        /// Position of subscription-id value in resource ID
        /// </summary>
        private const int SUBSCRIPTION_VALUE_POSITION = 2;

        /// <summary>
        /// Position of resource-group string in resource ID
        /// </summary>
        private const int RESOURCEGROUP_STRING_POSITION = 3;

        /// <summary>
        /// Parse the subscriptionId from the resourceId. 
        /// This will return subscription-Id only for subscription level configuration, else empty will be returned.
        /// </summary>
        /// <param name="resourceID">ResourceId of recommendation</param>
        /// <returns>SubscriptionId as string</returns>
        public static string GetSubscriptionIdFromSubscriptionLevelConfig(string resourceID)
        {
            string subscriptionID = string.Empty;

            string[] entries = resourceID.Split('/');

            if (entries[SUBSCRIPTION_STRING_POSITION].Equals("subscriptions") && !entries[RESOURCEGROUP_STRING_POSITION].Contains("resourceGroups"))
            {
                subscriptionID = entries[SUBSCRIPTION_VALUE_POSITION];
            }

            return subscriptionID;
        }

        /// <summary>
        /// Checks if the given psConfigData is of resource-group level configuration.
        /// </summary>
        /// <param name="psConfigData">PsAzureAdvisorConfigurationData to be checked.</param>
        /// <returns>True if resource-group level configuration, else false.</returns>
        public static bool IsConfigurationResourceGroupLevel(PsAzureAdvisorConfigurationData psConfigData)
        {
            bool isConfigurationResourceGroupLevel = false;

            string resourceGroupName = RecommendationHelper.GetResourceGroupFromResourceID(psConfigData.Id);
            isConfigurationResourceGroupLevel = string.IsNullOrEmpty(resourceGroupName) ? false : true;

            return isConfigurationResourceGroupLevel;
        }

        /// <summary>
        /// Checks if the given psConfigData is of subscription level configuration.
        /// </summary>
        /// <param name="psConfigData">PsAzureAdvisorConfigurationData to be checked.</param>
        /// <returns> if subscription level configuration, else false.</returns>
        public static bool IsConfigurationSubscriptionLevel(PsAzureAdvisorConfigurationData psConfigData)
        {
            bool isConfigurationSubscriptionLevel = false;

            string subscriptionId = GetSubscriptionIdFromSubscriptionLevelConfig(psConfigData.Id);
            isConfigurationSubscriptionLevel = string.IsNullOrEmpty(subscriptionId) ? false : true;

            return isConfigurationSubscriptionLevel;
        }
    }
}
