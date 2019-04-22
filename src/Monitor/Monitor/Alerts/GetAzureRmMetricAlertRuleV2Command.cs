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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;



namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Get a GenV2 Metric Alert rule
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MetricAlertRuleV2", DefaultParameterSetName = ByResourceGroupName), OutputType(typeof(PSMetricAlertRuleV2))]
    public class GetAzureRmMetricAlertRuleV2Command : ManagementCmdletBase
    {
        const string ByResourceGroupName = "ByResourceGroupName";
        const string ByRuleId = "ByRuleId";
        const string ByRuleName = "ByRuleName";

        /// <summary>
        /// Gets or sets ResourceGroupName  parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ByResourceGroupName, Mandatory = false, HelpMessage = "The ResourceGroupName")]
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, HelpMessage = "The ResourceGroupName")]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        public String ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Rule Id  parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ByRuleId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Rule Id of metric alert rule")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }

        /// <summary>
        /// Gets or sets Name  parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, HelpMessage = "The Name of metric alert rule")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.insights/metricalerts",nameof(ResourceGroupName))]
        public String Name { get; set; }

        protected override void ProcessRecordInternal()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                MetricAlertResource result = this.MonitorManagementClient.MetricAlerts.GetAsync(resourceGroupName: this.ResourceGroupName, ruleName: this.Name).Result;
                PSMetricAlertRuleV2 finalResult;
                if (result.Criteria is MetricAlertSingleResourceMultipleMetricCriteria)
                {
                    finalResult = new PSMetricAlertRuleV2SingleResource(result);
                }
                else
                {
                    finalResult = new PSMetricAlertRuleV2(result);
                }
                WriteObject(sendToPipeline: finalResult);
            }
            else if (!string.IsNullOrWhiteSpace(this.ResourceGroupName))
            {
                IEnumerable<MetricAlertResource> result = this.MonitorManagementClient.MetricAlerts.ListByResourceGroupAsync(resourceGroupName: this.ResourceGroupName).Result;
                List<PSMetricAlertRuleV2> finalResult = new List<PSMetricAlertRuleV2>();
                result.ToArray().ForEach((metricAlertResource) =>
                {
                    if (metricAlertResource.Criteria is MetricAlertSingleResourceMultipleMetricCriteria)
                    {
                        finalResult.Add(new PSMetricAlertRuleV2SingleResource(metricAlertResource));
                    }
                    else
                    {
                        finalResult.Add(new PSMetricAlertRuleV2(metricAlertResource));
                    }
                }
                );
                WriteObject(sendToPipeline: finalResult.ToList(), enumerateCollection: true);
            }
            else
            {
                IEnumerable<MetricAlertResource> result = this.MonitorManagementClient.MetricAlerts.ListBySubscriptionAsync().Result;
                List<PSMetricAlertRuleV2> finalResult = new List<PSMetricAlertRuleV2>();
                result.ToArray().ForEach((metricAlertResource) =>
                {
                    if (metricAlertResource.Criteria is MetricAlertSingleResourceMultipleMetricCriteria)
                    {
                        finalResult.Add(new PSMetricAlertRuleV2SingleResource(metricAlertResource));
                    }
                    else
                    {
                        finalResult.Add(new PSMetricAlertRuleV2(metricAlertResource));
                    }
                }
                );
                WriteObject(sendToPipeline: finalResult.ToList(), enumerateCollection: true);
            }
        }
    }
}
