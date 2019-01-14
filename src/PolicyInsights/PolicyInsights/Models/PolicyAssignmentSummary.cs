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
    /// Policy assignment summary.
    /// </summary>
    public class PolicyAssignmentSummary
    {
        /// <summary>
        /// Gets policy assignment ID.
        /// </summary>
        public string PolicyAssignmentId { get; }

        /// <summary>
        /// Gets policy set definition ID, if the policy assignment is
        /// for a policy set.
        /// </summary>
        public string PolicySetDefinitionId { get; }

        /// <summary>
        /// Gets non-compliance summary for the policy assignment.
        /// </summary>
        public SummaryResults Results { get; }

        /// <summary>
        /// Gets policy definitions summary.
        /// </summary>
        public IList<PolicyDefinitionSummary> PolicyDefinitions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyAssignmentSummary" /> class.
        /// </summary>
        /// <param name="policyAssignmentSummary">Policy assignment summary.</param>
        public PolicyAssignmentSummary(Management.PolicyInsights.Models.PolicyAssignmentSummary policyAssignmentSummary)
        {
            if (null == policyAssignmentSummary)
            {
                return;
            }

            this.PolicyAssignmentId = policyAssignmentSummary.PolicyAssignmentId;
            this.PolicySetDefinitionId = policyAssignmentSummary.PolicySetDefinitionId;
            this.PolicyDefinitions = policyAssignmentSummary.PolicyDefinitions.Select(policyDefinitionSummary => new PolicyDefinitionSummary(policyDefinitionSummary)).ToList();
            this.Results = new SummaryResults(policyAssignmentSummary.Results);
        }
    }
}
