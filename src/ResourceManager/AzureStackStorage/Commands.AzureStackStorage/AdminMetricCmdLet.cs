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
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AdminMetricCmdlet : AdminCmdletDefaultFarm
    {
        /// <summary>
        /// Gets or sets the timegrain parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public TimeGrain TimeGrain { get; set; }

        /// <summary>
        /// Gets or sets the starttime (In UTC) parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public DateTime StartTimeInUtc { get; set; }

        /// <summary>
        /// Gets or sets the endtime (In UTC) parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public DateTime EndTimeInUtc { get; set; }

        /// <summary>
        /// Gets or sets the metricnames parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] MetricNames { get; set; }

        /// <summary>
        /// Gets or sets the detailedoutput parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter DetailedOutput { get; set; }


        /// <summary>
        /// Get Metrics result
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        protected abstract MetricsResult GetMetricsResult(string filter);

        /// <summary>
        /// 
        /// </summary>
        protected override void Execute()
        {
            // Set the default start time and end time to last 24hours
            if (EndTimeInUtc == DateTime.MinValue) 
            {
                EndTimeInUtc = DateTime.UtcNow;
            }

            if (StartTimeInUtc == DateTime.MinValue)
            {
                StartTimeInUtc = EndTimeInUtc.AddDays(-1);
            }

            string filter = Tools.GenerateFilter(MetricNames, StartTimeInUtc, EndTimeInUtc, TimeGrain);
            bool fullDetails = this.DetailedOutput.IsPresent;

            MetricsResult metrics = GetMetricsResult(filter);
            var result = metrics.Metrics.Select(_ => fullDetails ? new PSMetric(_) : new PSMetricNoDetails(_));
            WriteObject(result, true);
        }
    }
}
