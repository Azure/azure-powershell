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

using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Insights.Metrics
{
    /// <summary>
    /// Create a metric dimension filter
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MetricFilter"), OutputType(typeof(string))]
    public class NewAzureRmMetricFilterCommand : MonitorCmdletBase
    {
        /// <summary>
        /// Gets or sets the Dimension
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The dimension name")]
        [ValidateNotNullOrEmpty]
        public string Dimension { get; set; }

        /// <summary>
        /// Gets or sets the Operator
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The operator")]
        [ValidateNotNullOrEmpty]
        public string Operator { get; set; }

        /// <summary>
        /// Gets or sets the values list of the dimension. A comma-separated list of values for the dimension.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of values for the dimension")]
        [ValidateNotNullOrEmpty]
        public string[] Value { get; set; }

        /// <summary>
        /// Process the general parameters (i.e. defined in this class) and the particular parameters (i.e. the parameters added by the descendants of this class).
        /// </summary>
        /// <returns>The final metric filter</returns>
        protected string ProcessParameters()
        {
            var buffer = new StringBuilder();
            var metricFilter = this.Value
                .Select(n => string.Concat(this.Dimension, " ", this.Operator, " '", n, "'"))
                .Aggregate((a, b) => string.Concat(a, " or ", b));
            buffer.Append(metricFilter);

            return buffer.ToString().Trim();
        }

        /// <summary>
        /// Executes the Cmdlet. This is a callback function to simplify the exception handling
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            WriteObject(this.ProcessParameters());
        }
    }
}
