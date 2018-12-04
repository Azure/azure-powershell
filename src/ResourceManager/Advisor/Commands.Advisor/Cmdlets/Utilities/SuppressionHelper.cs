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
        /// Parse the subscriptionId from the resourceId.
        /// </summary>
        /// <param name="resourceID">ResourceId of recommendation</param>
        /// <returns>SubscriptionId as string</returns>
        public static string GetSubscriptionIdfromResourceID(string resourceID)
        {
            string subscriptionID = string.Empty;

            if (resourceID.Contains("subscriptions/") && !resourceID.Contains("resourceGroups/"))
            {
                int startIndex = resourceID.IndexOf("configurations/") + 16;

                subscriptionID = resourceID.Substring(startIndex);
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

            string resourceGroupName = RecommendationHelper.GetResourceGroupfromResoureID(psConfigData.Id);
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

            string subscriptionId = GetSubscriptionIdfromResourceID(psConfigData.Id);
            isConfigurationSubscriptionLevel = string.IsNullOrEmpty(subscriptionId) ? false : true;

            return isConfigurationSubscriptionLevel;
        }
    }
}
