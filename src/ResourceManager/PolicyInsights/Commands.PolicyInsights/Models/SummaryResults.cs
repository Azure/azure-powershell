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
        }
    }
}
