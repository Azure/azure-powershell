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
using Microsoft.Azure.Management.Insights.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the ServiceDiagnosticSettings
    /// </summary>
    public class PSRetentionPolicy : RetentionPolicy
    {
        /// <summary>
        /// Initializes a new instance of the PSRetentionPolicy class.
        /// </summary>
        /// <param name="retentionPolicy">The input retention policy</param>
        public PSRetentionPolicy(RetentionPolicy retentionPolicy)
        {
            this.Enabled = retentionPolicy.Enabled;
            this.Days = retentionPolicy.Days;
        }

        /// <summary>
        /// A string representation of the PSRetentionPolicy
        /// </summary>
        /// <returns>A string representation of the PSRetentionPolicy</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine("Enabled : " + this.Enabled);
            output.Append("Days    : " + this.Days);
            return output.ToString();
        }
    }
}
