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

namespace Microsoft.Azure.Commands.Advisor.Cmdlets.Utilities.Client
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Models;
    using Microsoft.Azure.Management.Advisor;
    using Microsoft.Azure.Management.Advisor.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Recommendation Client utility class.
    /// </summary>
    public class RecommendationResource
    {
        /// <summary>
        /// Gets the list of recommendations associated with the subscription-Id in the scope.
        /// </summary>
        /// <param name="advisorClient">Advisor Client</param>
        /// <returns>List of PsAzureAdvisorResourceRecommendationBase</returns>
        public List<PsAzureAdvisorResourceRecommendationBase> GetAllRecommendationsFromClient(IAdvisorManagementClient advisorClient)
        {
            AzureOperationResponse<IPage<ResourceRecommendationBase>> operationResponseRecommendation = null;
            List<ResourceRecommendationBase> entirePageLinkRecommendationData = new List<ResourceRecommendationBase>();
            string nextPageLink = string.Empty;

            do
            {
                if (string.IsNullOrEmpty(nextPageLink))
                {
                    operationResponseRecommendation = advisorClient.Recommendations.ListWithHttpMessagesAsync().Result;
                }
                else
                {
                    operationResponseRecommendation = advisorClient.Recommendations.ListNextWithHttpMessagesAsync(nextPageLink).Result;
                }
                nextPageLink = operationResponseRecommendation.Body.NextPageLink;

                // Add current page items to the List 
                entirePageLinkRecommendationData.AddRange(operationResponseRecommendation.Body.ToList());
            }
            while (!string.IsNullOrEmpty(nextPageLink));

            // Convert to PsAzureAdvisorResourceRecommendationBase list and return 
            return PsAzureAdvisorResourceRecommendationBase.GetFromResourceRecommendationBase(entirePageLinkRecommendationData);
        }

        /// <summary>
        /// Gets the list of recommendations associated with the given resourceId. Default subscriptionId will be used to gather recommendation(s).
        /// </summary>
        /// <param name="advisorClient">Advisor Client</param>
        /// <param name="resourceId">ResourceId of recommendations</param>
        /// <returns>List of PsAzureAdvisorResourceRecommendationBase</returns>
        public List<PsAzureAdvisorResourceRecommendationBase> GetAllRecommendationsFromClient(IAdvisorManagementClient advisorClient, string resourceId)
        {
            AzureOperationResponse<IPage<ResourceRecommendationBase>> operationResponseRecommendation = null;
            List<ResourceRecommendationBase> entirePageLinkRecommendationData = new List<ResourceRecommendationBase>();
            string nextPageLink = string.Empty;

            do
            {
                if (string.IsNullOrEmpty(nextPageLink))
                {
                    operationResponseRecommendation = advisorClient.Recommendations.ListWithHttpMessagesAsync().Result;
                }
                else
                {
                    operationResponseRecommendation = advisorClient.Recommendations.ListNextWithHttpMessagesAsync(nextPageLink).Result;
                }
                nextPageLink = operationResponseRecommendation.Body.NextPageLink;

                // Add current page items to the List 
                entirePageLinkRecommendationData.AddRange(operationResponseRecommendation.Body.ToList());
            }
            while (!string.IsNullOrEmpty(nextPageLink));

            // Convert to PsAzureAdvisorResourceRecommendationBase list and return 
            return RecommendationHelper.RecommendationFilterByResourceId(
                PsAzureAdvisorResourceRecommendationBase.GetFromResourceRecommendationBase(entirePageLinkRecommendationData),
                resourceId);
        }
    }
}
