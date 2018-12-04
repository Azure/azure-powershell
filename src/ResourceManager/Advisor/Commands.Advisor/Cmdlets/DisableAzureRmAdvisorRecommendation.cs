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
    using Management.Advisor.Models;
    using Rest.Azure;

    /// <summary>
    /// Disable-AzureRmAdvisorRecommendation cmdlet
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.ResourceGraph.Utilities.ResourceGraphBaseCmdlet" />
    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AdvisorRecommendation", DefaultParameterSetName = IdParameterSet), OutputType(typeof(List<PsAzureAdvisorSuppressionContract>))]
    public class DisableAzureRmAdvisorRecommendation : ResourceAdvisorBaseCmdlet
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
        /// Default suppression name for the suppression API
        /// </summary>
        public const string DefaultSuppressionName = "DefaultSuppressionName";

        /// <summary>
        /// Gets or sets the Resource Id.
        /// </summary>
        [Parameter(ParameterSetName = "IdParameterSet", Mandatory = true, HelpMessage = "ResourceID of the recommendation to be suppressed (space delimitited).")]
        [Alias("Id")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the Resource Id.
        /// </summary>
        [Parameter(ParameterSetName = IdParameterSet, Mandatory = false, HelpMessage = "Name of suppression")]
        [Parameter(ParameterSetName = NameParameterSet, Mandatory = false, HelpMessage = "Name of suppression")]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = false, HelpMessage = "Name of suppression")]
        [Alias("SName")]
        public string SupressionName { get; set; }

        /// <summary>
        /// Gets or sets the days to disable the recommendation.
        /// </summary>
        [Parameter(ParameterSetName = IdParameterSet, Mandatory = false, HelpMessage = "Days to disable")]
        [Parameter(ParameterSetName = NameParameterSet, Mandatory = false, HelpMessage = "Days to disable")]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = false, HelpMessage = "Days to disable")]
        [AllowEmptyString]
        public string Days { get; set; }

        /// <summary>
        /// Gets or sets the object passed from the PowerShell piping
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = InputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<PsAzureAdvisorResourceRecommendationBase> InputObject { get; set; }

        /// <summary>
        /// Gets or sets the recommendation name.
        /// </summary>
        [Parameter(ParameterSetName = "NameParameterSet", Mandatory = true, HelpMessage = "ResourceName of the recommendation")]
        [Alias("Name")]
        public string RecommendationName
        {
            get;
            set;
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string resourceUri = string.Empty;
            string recommendationId = string.Empty;
            SuppressionContract suppressionContract = null;

            // This list contains all the response for the auzreoperation
            List<AzureOperationResponse<SuppressionContract>> azureOperationResponseSupression = new List<AzureOperationResponse<SuppressionContract>>();
            var returnSuppressionContract = new List<PsAzureAdvisorSuppressionContract>();

            // Assign the default value
            if (string.IsNullOrEmpty(this.SupressionName))
            {
                this.SupressionName = DefaultSuppressionName;
            }

            // If the days is less than -1, we update it as empty. ASs our API only accepts -1 and positive values.
            try
            {
                if (int.Parse(Days) < -1)
                {
                    Days = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Exception e = new Exception("User provided input for -Days is not a integer.", ex);
                throw e;
            }
            

            // Create the suppression contract
            suppressionContract = new SuppressionContract(null, this.SupressionName, null, null, string.IsNullOrEmpty(this.Days) ? string.Empty : this.Days);

            switch (this.ParameterSetName)
            {
                case IdParameterSet:
                    // parse out the Subscription-ID, Recommendation-ID form the ResourceId parameter.
                    resourceUri = RecommendationHelper.GetFullResourceUrifromResoureID(this.ResourceId);
                    recommendationId = RecommendationHelper.GetRecommendationIdfromResoureID(this.ResourceId);

                    azureOperationResponseSupression.Add(this.ResourcAdvisorclient.Suppressions.CreateWithHttpMessagesAsync(resourceUri, recommendationId, this.SupressionName, suppressionContract).Result);
                    break;

                case NameParameterSet:
                    AzureOperationResponse<ResourceRecommendationBase> recommendation = this.ResourcAdvisorclient.Recommendations.GetWithHttpMessagesAsync("subscriptions/" + this.ResourcAdvisorclient.SubscriptionId, this.RecommendationName).Result;
                    resourceUri = RecommendationHelper.GetFullResourceUrifromResoureID(recommendation.Body.Id);

                    // Make a get recommendation for this Name and get the ID
                    azureOperationResponseSupression.Add(this.ResourcAdvisorclient.Suppressions.CreateWithHttpMessagesAsync(resourceUri, this.RecommendationName, this.SupressionName, suppressionContract).Result);
                    break;

                case InputObjectParameterSet:
                    foreach (PsAzureAdvisorResourceRecommendationBase recommendationBase in this.InputObject)
                    {
                        // Parse out the Subscription-ID, Recommendation-ID from the ResourceId parameter.
                        resourceUri = RecommendationHelper.GetFullResourceUrifromResoureID(recommendationBase.Id);
                        recommendationId = RecommendationHelper.GetRecommendationIdfromResoureID(recommendationBase.Id);

                        azureOperationResponseSupression.Add(this.ResourcAdvisorclient.Suppressions.CreateWithHttpMessagesAsync(resourceUri, recommendationId, this.SupressionName, suppressionContract).Result);
                    }

                    break;
            }

            // Get the supresssion details from the suppression Get API, the response does not have the data for the suppression-name, resourceid.
            if (azureOperationResponseSupression.Count > 0)
            {
                AzureOperationResponse<IPage<SuppressionContract>> suppresionList = this.ResourcAdvisorclient.Suppressions.ListWithHttpMessagesAsync().Result;
                IEnumerable<PsAzureAdvisorSuppressionContract> psSuppressionContractList = PsAzureAdvisorSuppressionContract.FromSuppressionContractList(suppresionList.Body.AsEnumerable());

                foreach (AzureOperationResponse<SuppressionContract> azureOperationResponse in azureOperationResponseSupression)
                {
                    foreach (PsAzureAdvisorSuppressionContract contractItem in psSuppressionContractList)
                    {
                        // Matcht the supression-ID
                        if (azureOperationResponse.Body.SuppressionId == contractItem.SuppressionId)
                        {
                            returnSuppressionContract.Add(contractItem);
                        }
                    }
                }
            }

            this.WriteObject(returnSuppressionContract);
        }
    }
}
