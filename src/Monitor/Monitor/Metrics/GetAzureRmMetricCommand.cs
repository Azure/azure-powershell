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
using System.Xml;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure.OData;
using System.Globalization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Exceptions;

namespace Microsoft.Azure.Commands.Insights.Metrics
{
    /// <summary>
    /// Get the list of metric definition for a resource.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Metric", DefaultParameterSetName = GetAzureRmAMetricParamGroup), OutputType(typeof(PSMetric))]
    public class GetAzureRmMetricCommand : ManagementCmdletBase
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
        [Parameter(ParameterSetName = GetAzureRmAMetricParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The time grain of the query.")]
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
        [Parameter(ParameterSetName = GetAzureRmAMetricParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The start time of the query")]
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The start time of the query")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the endtime parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The end time of the query")]
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The end time of the query")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the top parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The maximum number of records to retrieve (default:10), to be specified with $filter")]
        [ValidateRange(1, int.MaxValue)]
        public int? Top { get; set; }

        /// <summary>
        /// Gets or sets the orderby parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The aggregation to use for sorting results and the direction of the sort (Example: sum asc)")]
        public string OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the metricnamespace parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric namespace to query metrics for")]
        public string MetricNamespace { get; set; }

        /// <summary>
        /// Gets or sets the resulttype parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAMetricFullParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The result type to be returned (metadata or data)")]
        public ResultType? ResultType { get; set; }

        /// <summary>
        /// Gets or sets the metricfilter parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric dimension filter to query metrics for")]
        public string MetricFilter { get; set; }

        /// <summary>
        /// Gets or sets the dimension parameter of the cmdlet
        /// </summary>]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric dimensions to query metrics for")]
        public string[] Dimension { get; set; }

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
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            this.WriteIdentifiedWarning(
                cmdletName: "Get-AzMetric",
                topic: "Parameter deprecation", 
                message: "The DetailedOutput parameter will be deprecated in a future breaking change release.");
            bool fullDetails = this.DetailedOutput.IsPresent;

            if (this.IsParameterBound(c => c.Dimension))
            {
                if (this.IsParameterBound(c => c.MetricFilter) && !string.IsNullOrEmpty(this.MetricFilter))
                {
                    throw new AzPSArgumentException("usage: -Dimension and -MetricFilter parameters are mutually exclusive.", "MetricFilter");
                }
                this.MetricFilter = string.Join(" and ", this.Dimension.Select(d => string.Format("{0} eq '*'", d)));
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

            var odataquery = (this.MetricFilter == default(string)) ? null : new ODataQuery<MetadataValue>(this.MetricFilter);
            string timespan = string.Concat(this.StartTime.ToUniversalTime().ToString("O"), "/", this.EndTime.ToUniversalTime().ToString("O"));
            TimeSpan? timegrain = this.TimeGrain;
            if (this.TimeGrain == default(TimeSpan))
            {
                timegrain = null;
            }
            string metricNames = (this.MetricName != null && this.MetricName.Count() > 0) ? string.Join(",", this.MetricName) : null;
            string aggregation = this.AggregationType.HasValue ? this.AggregationType.Value.ToString() : null;
            int? top = (this.Top == default(int?)) ? null : this.Top;
            string orderBy = (this.OrderBy == default(string)) ? null : this.OrderBy;
            ResultType? resultType = (this.ResultType == default(ResultType?)) ? null : this.ResultType;
            string metricnamespace = (this.MetricNamespace == default(string)) ? null : this.MetricNamespace;

            var records = this.MonitorManagementClient.Metrics.List(
                resourceUri: this.ResourceId,
                odataQuery: odataquery,
                timespan: timespan,
                interval: timegrain,
                metricnames: metricNames,
                aggregation: aggregation,
                top: top,
                orderby: orderBy,
                resultType: resultType,
                metricnamespace: metricnamespace);

            // If fullDetails is present full details of the records are displayed, otherwise only a summary of the records is displayed
            var result = (records != null && records.Value != null)? (records.Value.Select(e => fullDetails ? new PSMetric(e) : new PSMetricNoDetails(e)).ToArray()) : null;

            WriteObject(sendToPipeline: result, enumerateCollection: true);
        }
    }
}
