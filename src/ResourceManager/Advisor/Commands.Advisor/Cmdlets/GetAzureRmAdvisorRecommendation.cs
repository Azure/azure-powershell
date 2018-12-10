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

namespace Microsoft.Azure.Commands.ResourceGraph.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Advisor.Cmdlets.Models;
    using Advisor.Cmdlets.Utilities;
    using Advisor.Utilities;
    using Microsoft.Azure.Management.Advisor.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Search-AzureRmGraph cmdlet
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.ResourceGraph.Utilities.ResourceGraphBaseCmdlet" />
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AdvisorRecommendation"), OutputType(typeof(PsAzureAdvisorResourceRecommendationBase))]
    public class GetAzureRmAdvisorRecommendation : ResourceAdvisorBaseCmdlet
    {
        /// <summary>
        /// Constant for IdParameterSet
        /// </summary>
        public const string IdParameterSet = "IdParameterSet";

        /// <summary>
        /// Constant for NameParameterSet
        /// </summary>
        public const string NameParameterSet = "NameParameterSet";

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>s
        [Parameter(ParameterSetName = "IdParameterSet", Mandatory = true, Position = 0, HelpMessage = "One or more recommendation-Id (space delimited)")]
        [Alias("Id")]
        public string ResourceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        [Parameter(ParameterSetName = "IdParameterSet", Mandatory = false, HelpMessage = "Category of the recommendation")]
        [Parameter(ParameterSetName = "NameParameterSet", Mandatory = false, HelpMessage = "Category of the recommendation")]
        public string Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ResourceGroupName.
        /// </summary>
        [Parameter(ParameterSetName = "NameParameterSet", Mandatory = false, HelpMessage = "ResourceGroup name of the recommendation")]
        [Alias("Name")]
        public string ResourceGroupName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Refresh.
        /// </summary>
        [Parameter(ParameterSetName = "IdParameterSet", Mandatory = false, HelpMessage = "Regenerates the recommendations.")]
        [Parameter(ParameterSetName = "NameParameterSet", Mandatory = false, HelpMessage = "Regenerates the recommendations.")]
        public SwitchParameter Refresh
        {
            get;
            set;
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            List<PsAzureAdvisorResourceRecommendationBase> results = new List<PsAzureAdvisorResourceRecommendationBase>();

            AzureOperationResponse<IPage<ResourceRecommendationBase>> operationResponseRecommendation = null;
            List<ResourceRecommendationBase> entirePageLinkRecommendationData = new List<ResourceRecommendationBase>();
            AzureOperationResponse<ResourceRecommendationBase> recommendation = null;

            switch (this.ParameterSetName)
            {
                case IdParameterSet:
                    List<string> resourceIDList = new List<string>();
                    resourceIDList = this.ResourceId.Split(' ').ToList();

                    foreach (string resourceId in resourceIDList)
                    {
                        string recommendationId = RecommendationHelper.GetRecommendationIdfromResoureID(resourceId);

                        recommendation = this.ResourcAdvisorClient.Recommendations.GetWithHttpMessagesAsync("subscriptions/" + this.ResourcAdvisorClient.SubscriptionId, recommendationId).Result;
                        results.Add(PsAzureAdvisorResourceRecommendationBase.GetFromResourceRecommendationBase(recommendation.Body));
                    }

                    break;

                case NameParameterSet:
                    string nextPagelink = string.Empty;

                    // Iterate the page-link if exists, if the first iteration retreives the data.
                    do
                    {
                        if (string.IsNullOrEmpty(nextPagelink))
                        {
                            operationResponseRecommendation = this.ResourcAdvisorClient.Recommendations.ListWithHttpMessagesAsync().Result;
                        }
                        else
                        {
                            operationResponseRecommendation = this.ResourcAdvisorClient.Recommendations.ListWithHttpMessagesAsync(nextPagelink).Result;
                        }
                        nextPagelink = operationResponseRecommendation.Body.NextPageLink;
                        // Add current page items to the List 
                        entirePageLinkRecommendationData.AddRange(operationResponseRecommendation.Body.ToList());
                    }
                    while (!string.IsNullOrEmpty(nextPagelink));

                    // Convert to PsAzureAdvisorResourceRecommendationBase list
                    results = PsAzureAdvisorResourceRecommendationBase.GetFromResourceRecommendationBase(entirePageLinkRecommendationData);

                    // Filter out the resourcegroupname recommendations
                    if (!string.IsNullOrEmpty(this.ResourceGroupName))
                    {
                        results = RecommendationHelper.ReccomendationFilterByCategoryAndResource(results, string.Empty, this.ResourceGroupName);
                    }

                    break;
            }

            if (!string.IsNullOrEmpty(this.Category))
            {
                results = RecommendationHelper.ReccomendationFilterByCategoryAndResource(results, this.Category, string.Empty);
            }

            if (Refresh)
            {
                AzureOperationHeaderResponse<RecommendationsGenerateHeaders> generateionResponse = this.ResourcAdvisorClient.Recommendations.GenerateWithHttpMessagesAsync().Result;
            }

            this.WriteObject(results, true);
        }
    }
}