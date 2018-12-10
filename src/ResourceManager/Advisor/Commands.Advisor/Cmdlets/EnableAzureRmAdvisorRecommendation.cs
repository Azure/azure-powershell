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
    /// Enable-AzureRmAdvisorRecommendation cmdlet
    /// </summary>
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AdvisorRecommendation", DefaultParameterSetName = NameParameterSet), OutputType(typeof(List<PsAzureAdvisorResourceRecommendationBase>))]
    public class EnableAzureRmAdvisorRecommendation : ResourceAdvisorBaseCmdlet
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
        /// Constant for InputObjectParameterSet
        /// </summary>
        public const string InputObjectParameterSet = "InputObjectParameterSet";

        /// <summary>
        /// Default suppressionName for the suppression API
        /// </summary>
        public const string DefaultSupressionName = "HardcodedSuppressionName";

        /// <summary>
        /// Gets or sets the Resource Id.
        /// </summary>
        [Parameter(ParameterSetName = "IdParameterSet", Position = 0, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Resource Id of the recommendation to be suppressed.")]
        [Alias("Id")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the object passed from the PowerShell piping
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, ParameterSetName = InputObjectParameterSet, HelpMessage = "The powershell object type PsAzureAdvisorResourceRecommendationBase returned by Get-AzureRmAdvisorRecommendation call.")]
        [ValidateNotNullOrEmpty]
        public PsAzureAdvisorResourceRecommendationBase InputObject { get; set; }

        /// <summary>
        /// Gets or sets the recommendation name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "NameParameterSet", Position = 0,  HelpMessage = "ResourceName of the recommendation.")]
        [Alias("Name")]
        public string RecommendationName { get; set; }

        /// <summary>
        /// Suppression delete utility for a given recommendation resource Id.
        /// </summary>
        /// <param name="resourceUri">ResourceID of the recommendation</param>
        /// <param name="recommendationId">RecommendationId of the recommendation</param>
        /// <returns>List of PsAzureAdvisorResourceRecommendationBase objects</returns>
        public List<PsAzureAdvisorResourceRecommendationBase> SuppressionDelete(string resourceUri, string recommendationId)
        {
            AzureOperationResponse<IPage<SuppressionContract>> suppresionList = null;
            AzureOperationResponse<IPage<ResourceRecommendationBase>> recommendationList = null;
            IEnumerable<PsAzureAdvisorSuppressionContract> psSuppressionContractList = null;

            IList<PsAzureAdvisorResourceRecommendationBase> responseRecommendationList = new List<PsAzureAdvisorResourceRecommendationBase>();
            List<PsAzureAdvisorResourceRecommendationBase> responseRecommendation = new List<PsAzureAdvisorResourceRecommendationBase>();
            List<AzureOperationResponse> response = new List<AzureOperationResponse>();

            // Get the list of all suppressions
            suppresionList = this.ResourcAdvisorClient.Suppressions.ListWithHttpMessagesAsync().Result;
            psSuppressionContractList = PsAzureAdvisorSuppressionContract.FromSuppressionContractList(suppresionList.Body.AsEnumerable());

            // Get all the suppression for this recommendationId
            foreach (PsAzureAdvisorSuppressionContract contract in psSuppressionContractList)
            {
                // Delete only if the supression belongs to provided RecommendationName
                if (contract.Id.Contains(recommendationId))
                {
                    response.Add(this.ResourcAdvisorClient.Suppressions.DeleteWithHttpMessagesAsync(resourceUri, recommendationId, contract.Name).Result);
                }
            }

            // Get all the recommendation and convert to its corresponding psobject
            recommendationList = this.ResourcAdvisorClient.Recommendations.ListWithHttpMessagesAsync().Result;
            responseRecommendationList = PsAzureAdvisorResourceRecommendationBase.GetFromResourceRecommendationBase(recommendationList.Body);

            // Add the particular recommendation to the response of cmdlet
            responseRecommendation.Add(RecommendationHelper.RecomendationFilterByRecommendation(responseRecommendationList, recommendationId));
            return responseRecommendation;
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string resourceUri = string.Empty;
            string recommendationId = string.Empty;

            AzureOperationResponse<IPage<SuppressionContract>> suppresionList = null;

            // This i used for the recommendation call, to collect supression ID data associated.
            // AzureOperationResponse<IPage<ResourceRecommendationBase>> recommendationList = null;
            IList<PsAzureAdvisorResourceRecommendationBase> responseRecommendationList = new List<PsAzureAdvisorResourceRecommendationBase>();

            List<PsAzureAdvisorResourceRecommendationBase> responseRecommendation = new List<PsAzureAdvisorResourceRecommendationBase>();
            AzureOperationResponse<ResourceRecommendationBase> recommendation = null;

            IEnumerable<PsAzureAdvisorSuppressionContract> psSuppressionContractList = null;
            var response = new List<AzureOperationResponse>();

            switch (this.ParameterSetName)
            {
                case IdParameterSet:
                    resourceUri = RecommendationHelper.GetFullResourceUriFromResoureID(this.ResourceId);
                    recommendationId = RecommendationHelper.GetRecommendationIdFromResoureID(this.ResourceId);

                    responseRecommendation.AddRange(this.SuppressionDelete(resourceUri, recommendationId));
                    break;

                case NameParameterSet:
                    recommendation = this.ResourcAdvisorClient.Recommendations.GetWithHttpMessagesAsync("subscriptions/" + this.ResourcAdvisorClient.SubscriptionId, this.RecommendationName).Result;
                    resourceUri = RecommendationHelper.GetFullResourceUriFromResoureID(recommendation.Body.Id);
                    suppresionList = this.ResourcAdvisorClient.Suppressions.ListWithHttpMessagesAsync().Result;
                    psSuppressionContractList = PsAzureAdvisorSuppressionContract.FromSuppressionContractList(suppresionList.Body.AsEnumerable());

                    responseRecommendation.AddRange(this.SuppressionDelete(resourceUri, this.RecommendationName));
                    break;

                case InputObjectParameterSet:
                    // Parse out the Subscription-ID, Recommendation-ID from the ResourceId parameter.
                    resourceUri = RecommendationHelper.GetFullResourceUriFromResoureID(this.InputObject.Id);
                    recommendationId = RecommendationHelper.GetRecommendationIdFromResoureID(this.InputObject.Id);

                    responseRecommendation.AddRange(this.SuppressionDelete(resourceUri, recommendationId));
                    break;
            }

            this.WriteObject(responseRecommendation, true);
        }
    }
}
