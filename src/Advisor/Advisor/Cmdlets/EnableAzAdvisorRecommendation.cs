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

namespace Microsoft.Azure.Commands.Advisor.Cmdlets
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Models;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Utilities;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Utilities.Client;
    using Microsoft.Azure.Commands.Advisor.Properties;
    using Microsoft.Azure.Commands.Advisor.Utilities;
    using Microsoft.Azure.Management.Advisor.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Enable-AzAdvisorRecommendation cmdlet
    /// </summary>
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AdvisorRecommendation", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PsAzureAdvisorResourceRecommendationBase))]
    public class EnableAzAdvisorRecommendation : ResourceAdvisorBaseCmdlet
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
        [Parameter(ParameterSetName = IdParameterSet, Position = 0, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Id of the recommendation to be suppressed.")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the object passed from the PowerShell piping
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, ParameterSetName = InputObjectParameterSet, HelpMessage = "The powershell object type PsAzureAdvisorResourceRecommendationBase returned by Get-AzAdvisorRecommendation call.")]
        public PsAzureAdvisorResourceRecommendationBase InputObject { get; set; }

        /// <summary>
        /// Gets or sets the recommendation name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "NameParameterSet", Position = 0, HelpMessage = "ResourceName of the recommendation.")]
        public string RecommendationName { get; set; }

        /// <summary>
        /// Suppression delete utility for a given recommendation resource Id.
        /// </summary>
        /// <param name="resourceUri">ResourceID of the recommendation</param>
        /// <param name="recommendationId">RecommendationId of the recommendation</param>
        /// <returns>List of PsAzureAdvisorResourceRecommendationBase objects</returns>
        public List<PsAzureAdvisorResourceRecommendationBase> SuppressionDelete(string resourceUri, string recommendationId)
        {
            AzureOperationResponse<IPage<SuppressionContract>> suppressionList = null;
            IEnumerable<PsAzureAdvisorSuppressionContract> psSuppressionContractList = null;
            IList<PsAzureAdvisorResourceRecommendationBase> responseRecommendationList = new List<PsAzureAdvisorResourceRecommendationBase>();
            List<PsAzureAdvisorResourceRecommendationBase> responseRecommendation = new List<PsAzureAdvisorResourceRecommendationBase>();
            List<AzureOperationResponse> response = new List<AzureOperationResponse>();
            RecommendationResource recommendationResourceUtil = new RecommendationResource();

            // Get the list of all suppressions
            suppressionList = this.ResourceAdvisorClient.Suppressions.ListWithHttpMessagesAsync().Result;
            psSuppressionContractList = PsAzureAdvisorSuppressionContract.FromSuppressionContractList(suppressionList.Body.AsEnumerable());

            // Get all the suppression for this recommendationId
            foreach (PsAzureAdvisorSuppressionContract contract in psSuppressionContractList)
            {
                // Delete only if the supression belongs to provided RecommendationName
                if (contract.Id.Contains(recommendationId))
                {
                    response.Add(this.ResourceAdvisorClient.Suppressions.DeleteWithHttpMessagesAsync(resourceUri, recommendationId, contract.Name).Result);
                }
            }

            // Get all the recommendation and convert to its corresponding psobject
            responseRecommendationList = recommendationResourceUtil.GetAllRecommendationsFromClient(this.ResourceAdvisorClient);

            // Add the particular recommendation to the response of cmdlet
            responseRecommendation.Add(RecommendationHelper.RecommendationFilterByRecommendation(responseRecommendationList, recommendationId));
            return responseRecommendation;
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string resourceUri = string.Empty;
            string recommendationId = string.Empty;

            WriteVerbose(Resources.SuppressionRemove);

            AzureOperationResponse<IPage<SuppressionContract>> suppressionList = null;

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
                    resourceUri = RecommendationHelper.GetFullResourceUriFromResourceID(this.ResourceId);
                    recommendationId = RecommendationHelper.GetRecommendationIdFromResourceID(this.ResourceId);

                    if (ShouldProcess(recommendationId, string.Format(Resources.EnableRecommendationWarningMessage, this.RecommendationName)))
                    {
                        responseRecommendation.AddRange(this.SuppressionDelete(resourceUri, recommendationId));
                    }
                    break;

                case NameParameterSet:
                    recommendation = this.ResourceAdvisorClient.Recommendations.GetWithHttpMessagesAsync("subscriptions/" + this.ResourceAdvisorClient.SubscriptionId, this.RecommendationName).Result;
                    resourceUri = RecommendationHelper.GetFullResourceUriFromResourceID(recommendation.Body.Id);
                    suppressionList = this.ResourceAdvisorClient.Suppressions.ListWithHttpMessagesAsync().Result;
                    psSuppressionContractList = PsAzureAdvisorSuppressionContract.FromSuppressionContractList(suppressionList.Body.AsEnumerable());

                    if (ShouldProcess(this.RecommendationName, string.Format(Resources.EnableRecommendationWarningMessage, this.RecommendationName)))
                    {
                        responseRecommendation.AddRange(this.SuppressionDelete(resourceUri, this.RecommendationName));
                    }
                    break;

                case InputObjectParameterSet:
                    // Parse out the Subscription-ID, Recommendation-ID from the ResourceId parameter.
                    resourceUri = RecommendationHelper.GetFullResourceUriFromResourceID(this.InputObject.ResourceId);
                    recommendationId = RecommendationHelper.GetRecommendationIdFromResourceID(this.InputObject.ResourceId);
                    if (ShouldProcess(recommendationId, string.Format(Resources.EnableRecommendationWarningMessage, recommendationId)))
                    {
                        responseRecommendation.AddRange(this.SuppressionDelete(resourceUri, recommendationId));
                    }
                    break;
            }

            this.WriteObject(responseRecommendation, true);
        }
    }
}
