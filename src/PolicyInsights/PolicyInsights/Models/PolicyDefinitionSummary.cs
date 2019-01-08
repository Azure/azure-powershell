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
    /// <summary>
    /// Policy definition summary.
    /// </summary>
    public class PolicyDefinitionSummary
    {
        /// <summary>
        /// Gets policy definition ID.
        /// </summary>
        public string PolicyDefinitionId { get; }

        /// <summary>
        /// Gets policy definition reference ID.
        /// </summary>
        public string PolicyDefinitionReferenceId { get; set; }

        /// <summary>
        /// Gets policy effect, i.e. policy definition action.
        /// </summary>
        public string Effect { get; }

        /// <summary>
        /// Gets non-compliance summary for the policy definition.
        /// </summary>
        public SummaryResults Results { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyDefinitionSummary" /> class.
        /// </summary>
        /// <param name="policyDefinitionSummary">Policy definition summary.</param>
        public PolicyDefinitionSummary(Management.PolicyInsights.Models.PolicyDefinitionSummary policyDefinitionSummary)
        {
            if (null == policyDefinitionSummary)
            {
                return;
            }

            this.PolicyDefinitionId = policyDefinitionSummary.PolicyDefinitionId;
            this.PolicyDefinitionReferenceId = policyDefinitionSummary.PolicyDefinitionReferenceId;
            this.Effect = policyDefinitionSummary.Effect;
            this.Results = new SummaryResults(policyDefinitionSummary.Results);
        }
    }
}
