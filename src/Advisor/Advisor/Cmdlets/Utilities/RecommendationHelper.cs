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
        /// Position of resource-group string in resource ID
        /// </summary>
        private const int RESOURCEGROUP_STRING_POSITION = 3;

        /// <summary>
        /// Position of resource-group value in resource ID
        /// </summary>
        private const int RESOURCEGROUP_VALUE_POSITION = 4;

        /// <summary>
        /// Filter recommendations by given category and resourceGroup name.
        /// </summary>
        /// <param name="recListTobeFiltered">List to be filtered</param>
        /// <param name="category">Category name</param>
        /// <param name="resourceGroup">Resource group name</param>
        /// <returns>Filtered list of recommendations</returns>
        public static List<PsAzureAdvisorResourceRecommendationBase> RecommendationFilterByCategoryAndResource(IEnumerable<PsAzureAdvisorResourceRecommendationBase> recListTobeFiltered, string category, string resourceGroup)
        {
            if (recListTobeFiltered == null || recListTobeFiltered.Count() == 0)
            {
                return null;
            }

            List<PsAzureAdvisorResourceRecommendationBase> filteredList = new List<PsAzureAdvisorResourceRecommendationBase>();

            // Filter by category
            if (!string.IsNullOrEmpty(category))
            {
                // If resourceGroup filtering is as well specified 
                if (!string.IsNullOrEmpty(resourceGroup))
                {
                    foreach (PsAzureAdvisorResourceRecommendationBase entry in recListTobeFiltered)
                    {
                        if (entry.Category.Equals(category) && entry.ResourceId.Contains(resourceGroup))
                        {
                            filteredList.Add(entry);
                        }
                    }
                }
                else
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
                        if (entry.ResourceId.Contains(resourceGroup))
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
        public static PsAzureAdvisorResourceRecommendationBase RecommendationFilterByRecommendation(IEnumerable<PsAzureAdvisorResourceRecommendationBase> recListTobeFiltered, string recommendationName)
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
        /// Filter recommendations by given resourceId.
        /// </summary>
        /// <param name="recListTobeFiltered">List to be filtered</param>
        /// <param name="resourceId">ResourceId of the recommendation.</param>
        /// <returns>Recommendation of PsAzureAdvisorResourceRecommendationBase type</returns>
        public static List<PsAzureAdvisorResourceRecommendationBase> RecommendationFilterByResourceId(IEnumerable<PsAzureAdvisorResourceRecommendationBase> recListTobeFiltered, string resourceId)
        {
            List<PsAzureAdvisorResourceRecommendationBase> returnList = new List<PsAzureAdvisorResourceRecommendationBase>();

            foreach (PsAzureAdvisorResourceRecommendationBase recommendationEntry in recListTobeFiltered)
            {
                if (recommendationEntry.ResourceId.Contains(resourceId))
                {
                    returnList.Add(recommendationEntry);
                }
            }

            return returnList;
        }

        /// <summary>
        /// Filter recommendations by given recommendationNameList.
        /// </summary>
        /// <param name="recListTobeFiltered">List to be filtered</param>
        /// <param name="recommendationNameList">List of recommendation-names, type GUID.</param>
        /// <returns>Recommendation list of PsAzureAdvisorResourceRecommendationBase type</returns>
        public static List<PsAzureAdvisorResourceRecommendationBase> RecommendationFilterByRecommendation(IEnumerable<PsAzureAdvisorResourceRecommendationBase> recListTobeFiltered, List<string> recommendationNameList)
        {
            List<PsAzureAdvisorResourceRecommendationBase> returnList = new List<PsAzureAdvisorResourceRecommendationBase>();
            foreach (string recommendationName in recommendationNameList)
            {
                returnList.Add(RecommendationFilterByRecommendation(recListTobeFiltered, recommendationName));
            }

            return returnList;
        }

        /// <summary>
        /// Parse the subscriptionId from the resourceId.
        /// </summary>
        /// <param name="resourceID">ResourceId of recommendation</param>
        /// <returns>SubscriptionId as string</returns>
        public static string GetResourceGroupFromResourceID(string resourceID)
        {
            string resourceGroup = string.Empty;
            string[] resourceIdSplit = resourceID.Split('/');

            if (resourceIdSplit[RESOURCEGROUP_STRING_POSITION].Equals("resourceGroups"))
            {
                resourceGroup = resourceIdSplit[RESOURCEGROUP_VALUE_POSITION];
            }

            return resourceGroup;
        }

        /// <summary>
        /// Parse the subscriptionId from the resourceId.
        /// </summary>
        /// <param name="resourceID">ResourceId of recommendation</param>
        /// <returns>SubscriptionId as string</returns>
        public static string GetFullResourceUriFromResourceID(string resourceID)
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
        public static string GetRecommendationIdFromResourceID(string resourceID)
        {
            string recommendationId = string.Empty;
            string[] resourceIdSplit = resourceID.Split('/');

            if (resourceIdSplit[resourceIdSplit.Length - 2].Equals("recommendations"))
            {
                recommendationId = resourceIdSplit[resourceIdSplit.Length - 1];
            }

            return recommendationId;
        }
    }
}
