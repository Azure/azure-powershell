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
    using System.Collections.Generic;
    using System.Linq;
    using Management.Advisor.Models;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Models;

    /// <summary>
    /// Recommendation helper class
    /// </summary>
    public static class RecommendationHelper
    {
        /// <summary>
        /// Filter recommendations by given category and resourceGroup name.
        /// </summary>
        /// <param name="recListTobeFiltered">List to be filtered</param>
        /// <param name="category">Category name</param>
        /// <param name="resourceGroup">Resource group name</param>
        /// <returns>Filtered list of recommendations</returns>
        public static List<PsAzureAdvisorResourceRecommendationBase> ReccomendationFilterByCategoryAndResource(IEnumerable<PsAzureAdvisorResourceRecommendationBase> recListTobeFiltered, string category, string resourceGroup)
        {
            if (recListTobeFiltered == null || recListTobeFiltered.Count() == 0)
            {
                return null;
            }

            List<PsAzureAdvisorResourceRecommendationBase> filteredList = new List<PsAzureAdvisorResourceRecommendationBase>();

            // Filter by category only if its a valid input
            if (Category.Cost.Equals(category) || Category.HighAvailability.Equals(category) || Category.Performance.Equals(category) || Category.Security.Equals(category))
            {
                if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(resourceGroup))
                {
                    foreach (PsAzureAdvisorResourceRecommendationBase entry in recListTobeFiltered)
                    {
                        if (entry.Category.Equals(category) && entry.Id.Contains(resourceGroup))
                        {
                            filteredList.Add(entry);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(category))
                {
                    foreach (PsAzureAdvisorResourceRecommendationBase entry in recListTobeFiltered)
                    {
                        if (entry.Category.Equals(category))
                        {
                            filteredList.Add(entry);
                        }
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(resourceGroup))
                {
                    foreach (PsAzureAdvisorResourceRecommendationBase entry in recListTobeFiltered)
                    {
                        if (entry.Id.Contains(resourceGroup))
                        {
                            filteredList.Add(entry);
                        }
                    }
                }
            }
            return filteredList;
        }

        /// <summary>
        /// Filter recommendations by given recommendationName.
        /// </summary>
        /// <param name="recListTobeFiltered">List to be filtered</param>
        /// <param name="recommendationName">Name of the recommendation, type GUID.</param>
        /// <returns>Recommendation of PsAzureAdvisorResourceRecommendationBase type</returns>
        public static PsAzureAdvisorResourceRecommendationBase RecomendationFilterByRecommendation(IEnumerable<PsAzureAdvisorResourceRecommendationBase> recListTobeFiltered, string recommendationName)
        {
            foreach (PsAzureAdvisorResourceRecommendationBase recommendationEntry in recListTobeFiltered)
            {
                if (recommendationEntry.Name.Equals(recommendationName))
                {
                    return recommendationEntry;
                }
            }

            return null;
        }

        /// <summary>
        /// Filter recommendations by given recommendationNameList.
        /// </summary>
        /// <param name="recListTobeFiltered">List to be filtered</param>
        /// <param name="recommendationNameList">List of recommendation-names, type GUID.</param>
        /// <returns>Recommendation list of PsAzureAdvisorResourceRecommendationBase type</returns>
        public static List<PsAzureAdvisorResourceRecommendationBase> RecomendationFilterByRecommendation(IEnumerable<PsAzureAdvisorResourceRecommendationBase> recListTobeFiltered, List<string> recommendationNameList)
        {
            List<PsAzureAdvisorResourceRecommendationBase> returnList = new List<PsAzureAdvisorResourceRecommendationBase>();
            foreach (string recommendationName in recommendationNameList)
            {
                returnList.Add(RecomendationFilterByRecommendation(recListTobeFiltered, recommendationName));
            }

            return returnList;
        }

        /// <summary>
        /// Parse the subscriptionId from the resourceId.
        /// </summary>
        /// <param name="resourceID">ResourceId of recommendation</param>
        /// <returns>SubscriptionId as string</returns>
        public static string GetSubscriptionIdfromResoureID(string resourceID)
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
        /// Parse the subscriptionId from the resourceId.
        /// </summary>
        /// <param name="resourceID">ResourceId of recommendation</param>
        /// <returns>SubscriptionId as string</returns>
        public static string GetResourceGroupfromResoureID(string resourceID)
        {
            string resourceGroup = string.Empty;

            if (resourceID.Contains("resourceGroups/"))
            {
                int startIndex = resourceID.IndexOf("resourceGroups/") + 15;
                int endIndex = resourceID.IndexOf("providers/Microsoft.Advisor") - 2;

                int cutLength = endIndex - startIndex + 1;
                resourceGroup = resourceID.Substring(startIndex, cutLength);
            }

            return resourceGroup;
        }

        /// <summary>
        /// Parse the subscriptionId from the resourceId.
        /// </summary>
        /// <param name="resourceID">ResourceId of recommendation</param>
        /// <returns>SubscriptionId as string</returns>
        public static string GetFullResourceUriFromResoureID(string resourceID)
        {
            string subscriptionID = string.Empty;

            if (resourceID.Contains("providers/Microsoft.Advisor"))
            {
                int endIndex = resourceID.IndexOf("providers/Microsoft.Advisor") - 2;
                subscriptionID = resourceID.Substring(1, endIndex);
            }

            return subscriptionID;
        }

        /// <summary>
        /// Parse the RecommendationId from the resourceId.
        /// </summary>
        /// <param name="resourceID">ResourceId of recommendation</param>
        /// <returns>RecommendationId as string</returns>
        public static string GetRecommendationIdfromResoureID(string resourceID)
        {
            string recommendationId = string.Empty;

            if (resourceID.Contains("recommendations/"))
            {
                int startIndex = resourceID.IndexOf("recommendations/", StringComparison.Ordinal) + 16;
                recommendationId = resourceID.Substring(startIndex);
            }

            return recommendationId;
        }
    }
}
