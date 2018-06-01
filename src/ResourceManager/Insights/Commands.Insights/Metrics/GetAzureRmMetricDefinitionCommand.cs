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

using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.Insights.Metrics
{
    /// <summary>
    /// Get the list of metric definitions for a resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmMetricDefinition"), OutputType(typeof(PSMetricDefinition[]))]
    public class GetAzureRmMetricDefinitionCommand : ManagementCmdletBase
    {
        /// <summary>
        /// Gets or sets the ResourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the metricnames parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The metric names of the query")]
        [ValidateNotNullOrEmpty]
        public string[] MetricName { get; set; }

        /// <summary>
        /// Gets or sets the detailedoutput parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "Return object with all the details of the records (the default is to return only some attributes, i.e. no detail)")]
        public SwitchParameter DetailedOutput { get; set; }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            string cmdletName = "Get-AzureRmMetricDefinition";
            this.WriteIdentifiedWarning(
                cmdletName: cmdletName,
                topic: "Parameter deprecation",
                message: "The DetailedOutput parameter will be deprecated in a future breaking change release.");

            this.WriteIdentifiedWarning(
                cmdletName: cmdletName,
                topic: "Parameter name change", 
                message: "The parameter plural names for the parameters will be deprecated in a future breaking change release in favor of the singular versions of the same names.");

            bool fullDetails = this.DetailedOutput.IsPresent;

            // If fullDetails is present full details of the records are displayed, otherwise only a summary of the records is displayed
            var records = this.MonitorManagementClient.MetricDefinitions.List(resourceUri: this.ResourceId)
                .Where(record => 
                    (this.MetricName == null) ||
                    (this.MetricName.Length == 0) ||
                    this.MetricName.Any(name => string.Equals(record.Name.Value, name, System.StringComparison.OrdinalIgnoreCase)))
                .Select(e => fullDetails ? new PSMetricDefinition(e) : new PSMetricDefinitionNoDetails(e)).ToArray();

            WriteObject(sendToPipeline: records, enumerateCollection: true);
        }
    }
}
