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

namespace Microsoft.Azure.Commands.Advisor.Cmdlets.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Advisor.Models;

    /// <summary>
    /// PS object for Advisor SDK RecommendationBase
    /// </summary>
    public class PsAzureAdvisorResourceRecommendationBase
    {
        /// <summary>
        ///  Gets or sets the Id of the recommendation.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        ///  Gets or sets the category of the recommendation. Possible values include: 'HighAvailability','Security', 'Performance', 'Cost'
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets extended properties
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; set; }

        /// <summary>
        /// Gets or sets the business impact of the recommendation. Possible values include: 'High', 'Medium', 'Low'
        /// </summary>
        public string Impact { get; set; }

        /// <summary>
        /// Gets or sets the resource type identified by Advisor.       
        /// </summary>
        public string ImpactedField { get; set; }

        /// <summary>
        /// Gets or sets the resource identified by Advisor.
        /// </summary>
        public string ImpactedValue { get; set; }

        /// <summary>
        /// Gets or sets the most recent time that Advisor checked the validity of the recommendation.
        /// </summary>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the recommendation metadata.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        ///  Gets or sets the recommendation-type GUID.
        /// </summary>
        public string RecommendationTypeId { get; set; }

        /// <summary>
        /// Gets or sets the potential risk of not implementing the recommendation. Possible values include: 'Error', 'Warning', 'None'
        /// </summary>
        public string Risk { get; set; }

        /// <summary>
        /// Gets or sets a summary of the recommendation.
        /// </summary>
        public PsRecommendationBaseShortDescription ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the list of snoozed and dismissed rules for the recommendation.
        /// </summary>
        public IList<Guid?> SuppressionIds { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Parse ResourceRecommendationBase to equivalent PSObject
        /// </summary>
        /// <param name="recommendationBase">ResourceRecommendationBase to be parsed</param>
        /// <returns>PsAzureAdvisorResourceRecommendationBase generated</returns>
        internal static PsAzureAdvisorResourceRecommendationBase GetFromResourceRecommendationBase(ResourceRecommendationBase recommendationBase)
        {
            if (recommendationBase == null)
            {
                return null;
            }

            return new PsAzureAdvisorResourceRecommendationBase()
            {
                ResourceId = recommendationBase.Id,
                Category = recommendationBase.Category,
                ExtendedProperties = recommendationBase.ExtendedProperties != null ? new Dictionary<string, string>(recommendationBase.ExtendedProperties) : new Dictionary<string, string>(),
                Impact = recommendationBase.Impact,
                ImpactedField = recommendationBase.ImpactedField,
                ImpactedValue = recommendationBase.ImpactedValue,
                LastUpdated = recommendationBase.LastUpdated,
                Metadata = recommendationBase.Metadata != null ? new Dictionary<string, object>(recommendationBase.Metadata) : new Dictionary<string, object>(),
                RecommendationTypeId = recommendationBase.RecommendationTypeId,
                Risk = recommendationBase.Risk,
                ShortDescription = recommendationBase.ShortDescription != null ? PsRecommendationBaseShortDescription.FromShortDescription(recommendationBase.ShortDescription) : null,
                SuppressionIds = recommendationBase.SuppressionIds == null ? new List<Guid?>() : recommendationBase.SuppressionIds,
                Name = recommendationBase.Name,
                Type = recommendationBase.Type,
            };
        }

        /// <summary>
        /// Parse a list of ResourceRecommendationBase to a list of equivalent PSObject
        /// </summary>
        /// <param name="recommendationBase">List of ResourceRecommendationBase to be converted</param>
        /// <returns>List of PsAzureAdvisorResourceRecommendationBase generated</returns>
        internal static List<PsAzureAdvisorResourceRecommendationBase> GetFromResourceRecommendationBase(IEnumerable<ResourceRecommendationBase> recommendationBase)
        {
            List<PsAzureAdvisorResourceRecommendationBase> returnList = new List<PsAzureAdvisorResourceRecommendationBase>();

            foreach (ResourceRecommendationBase recommendationBaseEntry in recommendationBase)
            {
                returnList.Add(GetFromResourceRecommendationBase(recommendationBaseEntry));
            }

            return returnList;
        }
    }
}
