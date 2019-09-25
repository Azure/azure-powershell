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
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Create Dimension object
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MetricAlertRuleV2DimensionSelection"), OutputType(typeof(PSMetricDimension))]
    public class NewAzureRmMetricAlertRuleV2DimensionSelectionCommand : MonitorCmdletBase
    {
        /// <summary>
        /// Gets or sets Dimension parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Dimension name")]
        public String DimensionName { get; set; }

        /// <summary>
        /// Gets or sets IncludeValues parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IncludeValues")]
        public String[] ValuesToInclude { get; set; }

        /// <summary>
        /// Gets or sets ExcludeValues parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The ExcludeValues")]
        public String[] ValuesToExclude { get; set; }


        protected override void ProcessRecordInternal()
        {
            PSMetricDimension result = new PSMetricDimension(dimensionName: this.DimensionName, valuesToInclude: this.ValuesToInclude, valuesToExclude: this.ValuesToExclude);
            WriteObject(sendToPipeline: result);
        }
    }
}
