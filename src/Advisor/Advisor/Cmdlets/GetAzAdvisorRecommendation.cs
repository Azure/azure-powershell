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
    using Microsoft.Azure.Commands.Advisor.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Advisor.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Get-AzAdvisorRecommendation cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AdvisorRecommendation", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PsAzureAdvisorResourceRecommendationBase))]
    public class GetAzAdvisorRecommendation : ResourceAdvisorBaseCmdlet
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
        [Parameter(ParameterSetName = "IdParameterSet", ValueFromPipelineByPropertyName = true, Mandatory = true, Position = 0, HelpMessage = "ResourceId of the recommendation")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        [Parameter(ParameterSetName = "IdParameterSet", Mandatory = false, HelpMessage = "Category of the recommendation")]
        [Parameter(ParameterSetName = "NameParameterSet", Mandatory = false, HelpMessage = "Category of the recommendation")]
        [ValidateSet("Cost", "HighAvailability", "OperationalExcellence", "Performance", "Security")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the ResourceGroupName.
        /// </summary>
        [Parameter(ParameterSetName = "NameParameterSet", Mandatory = false, HelpMessage = "ResourceGroup name of the recommendation")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            RecommendationResource recommendationResourceUtil = new RecommendationResource();
            List<PsAzureAdvisorResourceRecommendationBase> results = new List<PsAzureAdvisorResourceRecommendationBase>();
            List<ResourceRecommendationBase> entirePageLinkRecommendationData = new List<ResourceRecommendationBase>();

            switch (this.ParameterSetName)
            {
                case IdParameterSet:
                    results = recommendationResourceUtil.GetAllRecommendationsFromClient(this.ResourceAdvisorClient, this.ResourceId);
                    break;

                case NameParameterSet:
                    results = recommendationResourceUtil.GetAllRecommendationsFromClient(this.ResourceAdvisorClient);

                    // Filter out the resourcegroupname recommendations
                    if (!string.IsNullOrEmpty(this.ResourceGroupName))
                    {
                        results = RecommendationHelper.RecommendationFilterByCategoryAndResource(results, string.Empty, this.ResourceGroupName);
                    }
                    break;
            }

            if (!string.IsNullOrEmpty(this.Category))
            {
                results = RecommendationHelper.RecommendationFilterByCategoryAndResource(results, this.Category, string.Empty);
            }

            this.WriteObject(results, true);
        }
    }
}
