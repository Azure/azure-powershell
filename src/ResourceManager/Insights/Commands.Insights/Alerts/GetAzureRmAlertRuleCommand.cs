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
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Get an Alert rule
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAlertRule"), OutputType(typeof(List<PSAlertRule>))]
    public class GetAzureRmAlertRuleCommand : ManagementCmdletBase
    {
        internal const string GetAzureRmAlertRuleParamGroup = "GetByResourceGroup";
        internal const string GetAzureRmAlertRuleWithNameParamGroup = "GetByName";
        internal const string GetAzureRmAlertRuleWithUriParamGroup = "GetByResourceUri";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the ResourceGroupName parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAlertRuleParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [Parameter(ParameterSetName = GetAzureRmAlertRuleWithNameParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [Parameter(ParameterSetName = GetAzureRmAlertRuleWithUriParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the rule name parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAlertRuleWithNameParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The alert rule name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the TargetResourceId parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAlertRuleWithUriParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The alert rule target resource id")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Gets or sets the detailedoutput parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAlertRuleParamGroup, ValueFromPipelineByPropertyName = true, HelpMessage = "Return object with all the details of the records (the default is to return only some attributes, i.e. no detail)")]
        [Parameter(ParameterSetName = GetAzureRmAlertRuleWithNameParamGroup, ValueFromPipelineByPropertyName = true, HelpMessage = "Return object with all the details of the records (the default is to return only some attributes, i.e. no detail)")]
        [Parameter(ParameterSetName = GetAzureRmAlertRuleWithUriParamGroup, ValueFromPipelineByPropertyName = true, HelpMessage = "Return object with all the details of the records (the default is to return only some attributes, i.e. no detail)")]
        public SwitchParameter DetailedOutput { get; set; }

        #endregion

        private static string ExtractTargetResourceId(RuleDataSource alertRuleSource)
        {
            var source = alertRuleSource as RuleMetricDataSource;
            if (source != null)
            {
                return source.ResourceUri;
            }

            var source1 = alertRuleSource as RuleManagementEventDataSource;

            // The types above are the only ones supported. The string.Empty is just a prevention
            return source1 != null ? source1.ResourceUri : string.Empty;
        }

        private static string ExtractTargetResourceId(AlertRuleResource alertRuleResource)
        {
            var cond = alertRuleResource.Condition as LocationThresholdRuleCondition;
            if (cond != null)
            {
                return ExtractTargetResourceId(cond.DataSource);
            }

            var cond1 = alertRuleResource.Condition as ManagementEventRuleCondition;
            if (cond1 != null)
            {
                return ExtractTargetResourceId(cond1.DataSource);
            }

            var cond2 = alertRuleResource.Condition as ThresholdRuleCondition;

            // The types above are the only supported types. The string.Empty is a prevention only
            return cond2 != null ? ExtractTargetResourceId(cond2.DataSource) : string.Empty;
        }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            this.WriteIdentifiedWarning(
                cmdletName: "Get-AzureRmAlertRule",
                topic: "Parameter deprecation", 
                message: "The DetailedOutput parameter will be deprecated in a future breaking change release.");
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                // Retrieve all the AlertRules for a ResourceGroup
                IEnumerable<AlertRuleResource> result = this.MonitorManagementClient.AlertRules.ListByResourceGroupAsync(resourceGroupName: this.ResourceGroupName).Result;

                // The filter on targetResourceId is not supported by the servers, not specified in in Swagger, nor supported by the SDK.
                // This is added to maintain support in PowerShell
                if (!string.IsNullOrWhiteSpace(this.TargetResourceId))
                {
                    result = result.Where(a => string.Equals(this.TargetResourceId, ExtractTargetResourceId(a), StringComparison.OrdinalIgnoreCase));
                }

                var records = result.Select(e => this.DetailedOutput.IsPresent ? new PSAlertRule(e) : new PSAlertRuleNoDetails(e));
                WriteObject(sendToPipeline: records.ToList(), enumerateCollection: true);
            }
            else
            {
                // Retrieve a single AlertRule determined by the ResourceGroup and the rule name
                AlertRuleResource result = this.MonitorManagementClient.AlertRules.GetAsync(resourceGroupName: this.ResourceGroupName, ruleName: this.Name).Result;

                var finalResult = new List<PSAlertRule> { this.DetailedOutput.IsPresent ? new PSAlertRule(result) : new PSAlertRuleNoDetails(result) };
                WriteObject(sendToPipeline: finalResult, enumerateCollection: true);
            }
        }
    }
}
