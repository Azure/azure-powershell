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

namespace Microsoft.Azure.Commands.PolicyInsights.Models
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Non-compliance summary on a particular summary level.
    /// </summary>
    public class SummaryResults
    {
        /// <summary>
        /// Gets number of non-compliant resources.
        /// </summary>
        public int? NonCompliantResources { get; }

        /// <summary>
        /// Gets number of non-compliant policies.
        /// </summary>
        public int? NonCompliantPolicies { get; }

        /// <summary>
        /// Gets or sets the resources summary at this level.
        /// </summary>
        public IList<ComplianceDetail> ResourceDetails { get; set; }

        /// <summary>
        /// Gets or sets the policy artifact summary at this level. For query
        /// scope level, it represents policy assignment summary. For policy
        /// assignment level, it represents policy definitions summary.
        /// </summary>
        public IList<ComplianceDetail> PolicyDetails { get; set; }

        /// <summary>
        /// Gets or sets the policy definition group summary at this level.
        /// </summary>
        public IList<ComplianceDetail> PolicyGroupDetails { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryResults" /> class.
        /// </summary>
        /// <param name="summaryResults">Summary results.</param>
        public SummaryResults(Management.PolicyInsights.Models.SummaryResults summaryResults)
        {
            if (null == summaryResults)
            {
                return;
            }

            this.NonCompliantPolicies = summaryResults.NonCompliantPolicies;
            this.NonCompliantResources = summaryResults.NonCompliantResources;
            this.ResourceDetails = summaryResults.ResourceDetails.Select(resourceDetail => new ComplianceDetail(resourceDetail)).ToList();
            this.PolicyDetails = summaryResults.PolicyDetails.Select(policyDetail => new ComplianceDetail(policyDetail)).ToList();
            this.PolicyGroupDetails = summaryResults.PolicyGroupDetails.Select(policyGroupDetail => new ComplianceDetail(policyGroupDetail)).ToList();
        }
    }
}
