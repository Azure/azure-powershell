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
    using Microsoft.Azure.Commands.Advisor.Properties;
    using Microsoft.Azure.Commands.Advisor.Utilities;
    using Microsoft.Azure.Management.Advisor.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Disable-AzAdvisorRecommendation cmdlet
    /// </summary>
    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AdvisorRecommendation", DefaultParameterSetName = IdParameterSet, SupportsShouldProcess = true), OutputType(typeof(PsAzureAdvisorSuppressionContract))]
    public class DisableAzAdvisorRecommendation : ResourceAdvisorBaseCmdlet
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
        public const string DefaultSuppressionName = "HardcodedSuppressionName";

        /// <summary>
        /// Gets or sets the Resource Id.
        /// </summary>
        [Parameter(ParameterSetName = IdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true, HelpMessage = "Id of the recommendation to be suppressed.")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the days to disable the recommendation.
        /// </summary>
        [Parameter(ParameterSetName = IdParameterSet, Mandatory = false, Position = 1, HelpMessage = "Days to disable.")]
        [Parameter(ParameterSetName = NameParameterSet, Mandatory = false, Position = 1, HelpMessage = "Days to disable.")]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = false, Position = 1, HelpMessage = "Days to disable.")]
        [ValidateRange(1, int.MaxValue)]
        public int Days { get; set; }

        /// <summary>
        /// Gets or sets the object passed from the PowerShell piping
        /// </summary>
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The powershell object type PsAzureAdvisorResourceRecommendationBase returned by Get-AzAdvisorRecommendation call.")]
        public PsAzureAdvisorResourceRecommendationBase InputObject { get; set; }

        /// <summary>
        /// Gets or sets the recommendation name.
        /// </summary>
        [Parameter(ParameterSetName = "NameParameterSet", Position = 0, Mandatory = true, HelpMessage = "ResourceName of the recommendation")]
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

            WriteVerbose(Resources.SuppressionCreate);

            // This list contains all the response for the azure-operation
            List<AzureOperationResponse<SuppressionContract>> azureOperationResponseSuppression = new List<AzureOperationResponse<SuppressionContract>>();
            var returnSuppressionContract = new List<PsAzureAdvisorSuppressionContract>();

            // Create the suppression contract           
            suppressionContract = new SuppressionContract(null, DefaultSuppressionName, null, null, this.Days == 0 ? string.Empty : this.Days.ToString());

            switch (this.ParameterSetName)
            {
                case IdParameterSet:
                    // parse out the Subscription-ID, Recommendation-ID form the ResourceId parameter.
                    resourceUri = RecommendationHelper.GetFullResourceUriFromResourceID(this.ResourceId);
                    recommendationId = RecommendationHelper.GetRecommendationIdFromResourceID(this.ResourceId);

                    if (ShouldProcess(recommendationId, string.Format(Resources.DisableRecommendationWarningMessage, recommendationId)))
                    {
                        azureOperationResponseSuppression.Add(this.ResourceAdvisorClient.Suppressions.CreateWithHttpMessagesAsync(resourceUri, recommendationId, DefaultSuppressionName, suppressionContract).Result);
                    }

                    break;

                case NameParameterSet:
                    AzureOperationResponse<ResourceRecommendationBase> recommendation = this.ResourceAdvisorClient.Recommendations.GetWithHttpMessagesAsync("subscriptions/" + this.ResourceAdvisorClient.SubscriptionId, this.RecommendationName).Result;
                    resourceUri = RecommendationHelper.GetFullResourceUriFromResourceID(recommendation.Body.Id);

                    // Make a get recommendation for this Name and get the ID
                    if (ShouldProcess(this.RecommendationName, string.Format(Resources.DisableRecommendationWarningMessage, this.RecommendationName)))
                    {
                        azureOperationResponseSuppression.Add(this.ResourceAdvisorClient.Suppressions.CreateWithHttpMessagesAsync(resourceUri, this.RecommendationName, DefaultSuppressionName, suppressionContract).Result);
                    }
                    break;

                case InputObjectParameterSet:

                    // Parse out the Subscription-ID, Recommendation-ID from the ResourceId parameter.
                    resourceUri = RecommendationHelper.GetFullResourceUriFromResourceID(this.InputObject.ResourceId);
                    recommendationId = RecommendationHelper.GetRecommendationIdFromResourceID(this.InputObject.ResourceId);

                    if (ShouldProcess(recommendationId, string.Format(Resources.DisableRecommendationWarningMessage, recommendationId)))
                    {
                        azureOperationResponseSuppression.Add(this.ResourceAdvisorClient.Suppressions.CreateWithHttpMessagesAsync(resourceUri, recommendationId, DefaultSuppressionName, suppressionContract).Result);
                    }
                    break;
            }

            // Get the supresssion details from the suppression Get API, the response does not have the data for the suppression-name, resourceid.
            if (azureOperationResponseSuppression.Count > 0)
            {
                AzureOperationResponse<IPage<SuppressionContract>> suppressionList = this.ResourceAdvisorClient.Suppressions.ListWithHttpMessagesAsync().Result;
                IEnumerable<PsAzureAdvisorSuppressionContract> psSuppressionContractList = PsAzureAdvisorSuppressionContract.FromSuppressionContractList(suppressionList.Body.AsEnumerable());

                foreach (AzureOperationResponse<SuppressionContract> azureOperationResponse in azureOperationResponseSuppression)
                {
                    foreach (PsAzureAdvisorSuppressionContract contractItem in psSuppressionContractList)
                    {
                        // Match the supression-ID
                        if (azureOperationResponse.Body.SuppressionId == contractItem.SuppressionId)
                        {
                            returnSuppressionContract.Add(contractItem);
                        }
                    }
                }
            }

            this.WriteObject(returnSuppressionContract, true);
        }
    }
}
