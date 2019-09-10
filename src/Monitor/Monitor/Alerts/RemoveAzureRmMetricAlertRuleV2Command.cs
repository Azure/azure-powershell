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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Remove GenV2 metric alert rule
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MetricAlertRuleV2", SupportsShouldProcess = true, DefaultParameterSetName =ByMetricRuleResourceName), OutputType(typeof(bool))]
    public class RemoveAzureRmMetricAlertRuleV2Command : ManagementCmdletBase
    {
        const string ByMetricRuleResourceName = "ByMetricRuleResourceName";
        const string ByMetricRuleResourceId = "ByMetricRuleResourceId";
        const string ByRuleObject = "ByRuleObject";

        /// <summary>
        /// Gets or sets Name  parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ByMetricRuleResourceName, Mandatory = true, HelpMessage = "The name of metric alert rule")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.insights/metricalerts", nameof(ResourceGroupName))]
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets ResourceGroupName  parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ByMetricRuleResourceName, Mandatory = true, HelpMessage = "The ResourceGroupName")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceGroup")]
        public String ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets RuleResourceId  parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ByMetricRuleResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The RuleResourceId")]
        [ValidateNotNullOrEmpty]
        [Alias("RuleResourceId")]
        public String ResourceId { get; set; }

        /// <summary>
        /// Gets or sets InputObject parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ByRuleObject,Mandatory = true,ValueFromPipeline =true,HelpMessage ="The Metric rule object")]
        public PSMetricAlertRuleV2 InputObject { get; set; }

        /// <summary>
        /// Gets or sets the PassThru switch parameter to force return an object when removing the alert rule.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return true upon successful deletion.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        protected override void ProcessRecordInternal()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroup;
                this.Name = this.InputObject.Name;
            }
            if(this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }
            
            if (ShouldProcess(
                target: string.Format("Remove an alert rule: {0} from resource group: {1}", Name, ResourceGroupName),
                action: "Remove an alert rule"))
            {
                var result = this.MonitorManagementClient.MetricAlerts.DeleteWithHttpMessagesAsync(resourceGroupName: ResourceGroupName, ruleName: Name).Result;
                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
