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
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Expression evaluation details.
    /// </summary>
    public class ExpressionEvaluationDetails
    {
        /// <summary>
        /// Gets the evaluation result.
        /// </summary>
        public string Result { get; }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        public string Expression { get; }

        /// <summary>
        /// Gets the evaluation path.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets the expression value.
        /// </summary>
        public string ExpressionValue { get; }

        /// <summary>
        /// Gets the target value to be compared.
        /// </summary>
        public string TargetValue { get; }

        /// <summary>
        /// Gets the operator used to evaluate the expression.
        /// </summary>
        public string Operator { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionEvaluationDetails" /> class.
        /// </summary>
        /// <param name="details">Expression evaluation details.</param>
        public ExpressionEvaluationDetails(Management.PolicyInsights.Models.ExpressionEvaluationDetails details)
        {
            if (details == null)
            {
                return;
            }

            this.Result = details.Result;
            this.Expression = details.Expression;
            this.Path = details.Path;
            this.ExpressionValue = JToken.FromObject(details.ExpressionValue).ToString();
            this.TargetValue = JToken.FromObject(details.TargetValue).ToString();
            this.Operator = details.OperatorProperty;
        }
    }
}
