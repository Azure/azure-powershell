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

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Insights.Models;
using System;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.Commands.Insights.UsageMetrics
{
    /// <summary>
    /// Get the list of usage metrics for a resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmUsage"), OutputType(typeof(PSUsageMetric[]))]
    public class GetAzureRmUsageCommand : InsightsClientCmdletBase
    {
        /// <summary>
        /// Default value of the timerange to search for usage metrics
        /// </summary>
        public static readonly TimeSpan DefaultTimeRange = TimeSpan.FromHours(1);

        /// <summary>
        /// Default API version string for the underlying RP.
        /// The Insights backend gets the data from the RPs, and the RPs don not necessarily use the same API version.
        /// </summary>
        public static readonly string DefaultApiVersion = "2014-04-01";

        /// <summary>
        /// Gets or sets the ResourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the ApiVersion parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The API version string")]
        [ValidateNotNullOrEmpty]
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the starttime parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The start time of the query")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the endtime parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The end time of the query")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the metricnames parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The metric names of the query")]
        [ValidateNotNullOrEmpty]
        public string[] MetricNames { get; set; }

        /// <summary>
        /// Process the general parameters (i.e. defined in this class). The particular parameters are a responsibility of the descendants after adding a method to process more parameters.
        /// </summary>
        /// <returns>The query filter to be used by the cmdlet</returns>
        protected string ProcessParameters()
        {
            var buffer = new StringBuilder();
            if (this.MetricNames != null)
            {
                var metrics = this.MetricNames
                    .Select(n => string.Concat("name.value eq '", n, "'"))
                    .Aggregate((a, b) => string.Concat(a, " or ", b));

                buffer.Append("(");
                buffer.Append(metrics);
                buffer.Append(")");
            }

            // EndTime defaults to Now
            if (this.EndTime == default(DateTime))
            {
                this.EndTime = DateTime.Now;
            }

            // StartTime defaults to EndTime - DefaultTimeRange  (NOTE: EndTime defaults to Now)
            if (this.StartTime == default(DateTime))
            {
                this.StartTime = this.EndTime.Subtract(DefaultTimeRange);
            }

            buffer.Append(" and startTime eq ");
            buffer.Append(this.StartTime.ToString("O"));
            buffer.Append(" and endTime eq ");
            buffer.Append(this.EndTime.ToString("O"));

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
            string queryFilter = this.ProcessParameters();
            string apiVersion = this.ApiVersion ?? DefaultApiVersion;

            // Call the proper API methods to return a list of raw records.
            // If fullDetails is present full details of the records displayed, otherwise only a summary of the values is displayed
            UsageMetricListResponse response = this.InsightsClient.UsageMetricOperations
                .ListAsync(resourceUri: this.ResourceId, filterString: queryFilter, apiVersion: apiVersion, cancellationToken: CancellationToken.None)
                .Result;

            var records = response.UsageMetricCollection.Value
                .Select(e => new PSUsageMetric(e))
                .ToArray();

            WriteObject(sendToPipeline: records);
        }
    }
}
