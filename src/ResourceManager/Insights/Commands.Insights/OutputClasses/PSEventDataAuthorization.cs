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

using System.Text;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the EventDataAuthorization to provide a better output format for the PS command lets.
    /// </summary>
    public class PSEventDataAuthorization
    {
        /// <summary>
        /// Gets or sets the scope
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the action
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the condition
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// A string representation of the PSEventDataAuthorization
        /// </summary>
        /// <returns>A string representation of the PSEventDataAuthorization</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine("Scope     : " + Scope);
            output.AppendLine("Action    : " + Action);
            output.AppendLine("Role      : " + Role);
            output.Append("Condition : " + Condition);
            return output.ToString();
        }
    }
}
