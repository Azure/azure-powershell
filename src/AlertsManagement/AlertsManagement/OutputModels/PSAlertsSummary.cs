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

using Newtonsoft.Json;
using Microsoft.Azure.Management.AlertsManagement.Models;
using System.Text;

namespace Microsoft.Azure.Commands.AlertsManagement.OutputModels
{
    public class PSAlertsSummary
    {
        /// <summary>
        /// Initializes a new instance of the PSAlertsSummary class.
        /// </summary>
        public PSAlertsSummary(AlertsSummary summary)
        {
            GroupBy = summary.Properties.Groupedby;
            TotalAlerts = summary.Properties.Total;
            TotalSmartGroups = summary.Properties.SmartGroupsCount;
            AggregatedCounts = new PSAggregatedCounts(summary.Properties.Values);
        }

        public string GroupBy { get; }

        public int? TotalAlerts { get; }

        public int? TotalSmartGroups { get; }

        public PSAggregatedCounts AggregatedCounts { get; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine();
            output.Append(string.Format("GroupBy           : {0}", GroupBy));
            output.AppendLine();
            output.Append(string.Format("TotalAlerts       : {0}", TotalAlerts));
            output.AppendLine();
            output.Append(string.Format("TotalSmartGroups  : {0}", TotalSmartGroups));
            output.AppendLine();
            output.Append(string.Format("Summarization     : {0}", AggregatedCounts.ToString()));
            output.AppendLine();
            return output.ToString();
        }
    }
}