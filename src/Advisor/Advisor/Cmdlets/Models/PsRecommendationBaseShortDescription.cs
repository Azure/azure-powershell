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
    using System.Text;
    using Microsoft.Azure.Management.Advisor.Models;

    /// <summary>
    /// PS object for Advisor SDK ShortDescription
    /// </summary>
    public class PsRecommendationBaseShortDescription
    {
        /// <summary>
        /// Gets or sets the issue or opportunity identified by the recommendation.
        /// </summary>
        public string Problem { get; set; }

        /// <summary>
        /// Gets or sets the remediation action suggested by the recommendation.
        /// </summary>
        public string Solution { get; set; }

        /// <summary>
        /// Parse the ShortDescription into PsObject
        /// </summary>
        /// <param name="shortDescription">ShortDescription to be converted</param>
        /// <returns>PsRecommendationBaseShortDescription generated</returns>
        internal static PsRecommendationBaseShortDescription FromShortDescription(ShortDescription shortDescription)
        {
            if (shortDescription == null)
            {
                return null;
            }

            PsRecommendationBaseShortDescription psRecommendationBaseShortDescription = new PsRecommendationBaseShortDescription();

            if (!string.IsNullOrEmpty(shortDescription.Problem))
            {
                psRecommendationBaseShortDescription.Problem = shortDescription.Problem;
            }

            if (!string.IsNullOrEmpty(shortDescription.Solution))
            {
                psRecommendationBaseShortDescription.Solution = shortDescription.Solution;
            }

            return psRecommendationBaseShortDescription;
        }
    }
}
