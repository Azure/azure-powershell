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
    /// Policy evaluation details.
    /// </summary>
    public class PolicyEvaluationDetails
    {
        /// <summary>
        /// Gets the evaluated expressions.
        /// </summary>
        public IList<ExpressionEvaluationDetails> EvaluatedExpressions { get; } = new ExpressionEvaluationDetails[0].ToList();

        /// <summary>
        /// Gets the additional details on IfNotExists policy evaluation.
        /// </summary>
        public IfNotExistsEvaluationDetails IfNotExistsDetails { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyEvaluationDetails" /> class.
        /// </summary>
        /// <param name="details">Policy evaluation details.</param>
        public PolicyEvaluationDetails(Management.PolicyInsights.Models.PolicyEvaluationDetails details)
        {
            if (details == null)
            {
                return;
            }

            if (details.EvaluatedExpressions != null)
            {
                this.EvaluatedExpressions = details.EvaluatedExpressions.Select(expression => new ExpressionEvaluationDetails(expression)).ToList();
            }

            if (details.IfNotExistsDetails != null)
            {
                this.IfNotExistsDetails = new IfNotExistsEvaluationDetails(details.IfNotExistsDetails);
            }
        }
    }
}
