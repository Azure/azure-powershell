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

using System;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;
using System.Xml;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.Insights.Metrics
{
    /// <summary>
    /// Get the list of metric definition for a resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmMetric"), OutputType(typeof(PSMetric[]))]
    public class GetAzureRmMetricCommand : MonitorClientCmdletBase
    {
        internal const string GetAzureRmAMetricParamGroup = "GetWithDefaultParameters";
        internal const string GetAzureRmAMetricFullParamGroup = "GetWithFullParameters";

        /// <summary>
        /// Default value of the timerange to search for metrics
        /// </summary>
        public static readonly TimeSpan DefaultTimeRange = TimeSpan.FromHours(1);

        /// <summary>
        /// Gets or sets the ResourceId parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricParamGroup, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id")]
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the timegrain parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The time grain of the query.")]
        [ValidateNotNullOrEmpty]
        public TimeSpan TimeGrain { get; set; }

        /// <summary>
        /// Gets or sets the aggregation type parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The aggregation type of the query")]
        [ValidateNotNullOrEmpty]
        public AggregationType? AggregationType { get; set; }

        /// <summary>
        /// Gets or sets the starttime parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The start time of the query")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the endtime parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The end time of the query")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the metricnames parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricParamGroup, Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric names of the query")]
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric names of the query")]
        [ValidateNotNullOrEmpty]
        [Alias("MetricNames")]
        public string[] MetricName { get; set; }

        /// <summary>
        /// Gets or sets the detailedoutput parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "Return object with all the details of the records (the default is to return only some attributes, i.e. no detail)")]
        public SwitchParameter DetailedOutput { get; set; }

        /// <summary>
        /// Process the general parameters (i.e. defined in this class). The particular parameters are a responsibility of the descendants after adding a method to process more parameters.
        /// </summary>
        /// <returns>The query filter to be used by the cmdlet</returns>
        protected string ProcessParameters()
        {
            var buffer = new StringBuilder();
            if (this.MetricName != null)
            {
                var metrics = this.MetricName.Select(n => string.Concat("name.value eq '", n, "'")).Aggregate((a, b) => string.Concat(a, " or ", b));

                buffer.Append("(");
                buffer.Append(metrics);
                buffer.Append(")");

                if (this.TimeGrain != default(TimeSpan))
                {
                    buffer.Append(" and timeGrain eq duration'");
                    buffer.Append(XmlConvert.ToString(this.TimeGrain));
                    buffer.Append("'");
                }

                // EndTime defaults to Now
                if (this.EndTime == default(DateTime))
                {
                    this.EndTime = DateTime.UtcNow;
                }

                // StartTime defaults to EndTime - DefaultTimeRange  (NOTE: EndTime defaults to Now)
                if (this.StartTime == default(DateTime))
                {
                    this.StartTime = this.EndTime.Subtract(DefaultTimeRange);
                }

                buffer.Append(" and startTime eq ");
                buffer.Append(this.StartTime.ToUniversalTime().ToString("O"));
                buffer.Append(" and endTime eq ");
                buffer.Append(this.EndTime.ToUniversalTime().ToString("O"));

                if (this.AggregationType != null)
                {
                    buffer.Append(" and aggregationType eq '");
                    buffer.Append(this.AggregationType);
                    buffer.Append("'");
                }
            }

            string queryFilter = buffer.ToString();
            if (queryFilter.StartsWith(" and "))
            {
                queryFilter = queryFilter.Substring(4);
            }

            return queryFilter.Trim();
        }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            this.WriteIdentifiedWarning(
                cmdletName: "Get-AzureRmMetric",
                topic: "Parameter deprecation", 
                message: "The DetailedOutput parameter will be deprecated in a future breaking change release.");
            string queryFilter = this.ProcessParameters();
            bool fullDetails = this.DetailedOutput.IsPresent;

            // If fullDetails is present full details of the records are displayed, otherwise only a summary of the records is displayed
            var records = this.MonitorClient.Metrics.List(resourceUri: this.ResourceId, odataQuery: new ODataQuery<Metric>(queryFilter))
                .Select(e => fullDetails ? new PSMetric(e) : new PSMetricNoDetails(e)).ToArray();
            WriteObject(sendToPipeline: records, enumerateCollection: true);
        }
    }
}
