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
using Microsoft.Azure.Management.Monitor.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    /// <summary>
    /// Create a ScheduledQueryRule Source object
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRule", SupportsShouldProcess = true), OutputType(typeof(PSScheduledQueryRuleResource))]
    public class NewScheduledQueryRuleCommand : ManagementCmdletBase
    {

        #region Cmdlet parameters

        //
        // Summary:
        //     Gets or sets source (Query, DataSourceId, etc.) for rule.
        [Parameter(Mandatory = true, HelpMessage = "The scheduled query rule source")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleSource Source { get; set; }

        //
        // Summary:
        //     Gets or sets schedule (Frequnecy, Time Window) for rule.
        [Parameter(Mandatory = true, HelpMessage = "The scheduled query rule schedule")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleSchedule Schedule { get; set; }

        //
        // Summary:
        //     Gets or sets action needs to be taken on rule execution.
        [Parameter(Mandatory = true, HelpMessage = "The scheduled query rule Alerting Action")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleAlertingAction Action { get; set; }

        //
        // Summary:
        //     Region where alert is to be created
        [Parameter(Mandatory = true, HelpMessage = "The location for this alert")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Batch/operations")]
        public string Location { get; set; }

        //
        // Summary:
        //     Alert description
        [Parameter(Mandatory = false, HelpMessage = "The description for this alert")]
        public string Description { get; set; }

        //
        // Summary:
        //     Alert name
        [Parameter(Mandatory = true, HelpMessage = "The alert name")]
        [ResourceNameCompleter("Microsoft.insights/scheduledqueryrules", nameof(ResourceGroupName))]
        public string Name { get; set; }

        //
        // Summary:
        //     Resource tags
        [Parameter(Mandatory = false, HelpMessage = "Resource tags")]
        public Hashtable Tag;

        //
        // Summary:
        //     Alert status - enabled or not
        [Parameter(Mandatory = true, HelpMessage = "The azure alert state - valid values - true, false")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the ResourceGroupName parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
        #endregion
        protected override void ProcessRecordInternal()
        {
            try
            {
                // Convert Tag parameter from Hashtable to Dictionary<string, string>
                Dictionary<string, string> tags = TagsConversionHelper.CreateTagDictionary(Tag, true);

                var alertingAction = new AlertingAction(severity: Action.Severity, aznsAction: Action.AznsAction, trigger: Action.Trigger, throttlingInMin: Action.ThrottlingInMin);

                var parameters = new LogSearchRuleResource(location: Location, source: Source, schedule: Schedule,
                    action:alertingAction, tags: tags, description: Description, enabled: Enabled? "true" : "false");

                parameters.Validate();
                if (this.ShouldProcess(this.Name,
                    string.Format("Creating Log Alert Rule '{0}' in resource group {0}", this.Name,
                    this.ResourceGroupName)))
                {

                    var result = this.MonitorManagementClient.ScheduledQueryRules
                    .CreateOrUpdateWithHttpMessagesAsync(resourceGroupName: ResourceGroupName, ruleName: Name,
                        parameters: parameters).Result;

                    WriteObject(new PSScheduledQueryRuleResource(result.Body));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while creating Log Alert rule", ex);
            }    
        }
    }
}
