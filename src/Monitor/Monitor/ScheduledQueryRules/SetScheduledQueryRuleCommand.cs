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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.Azure.Management.Monitor.Models;
using ActivityLogAlertResource = Microsoft.Azure.Management.Monitor.Models.ActivityLogAlertResource;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    /// <summary>
    /// Updates a ScheduledQueryRule object
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRule", SupportsShouldProcess = true, DefaultParameterSetName = ByRuleName), OutputType(typeof(PSScheduledQueryRuleResource))]
    public class SetScheduledQueryRuleCommand : ManagementCmdletBase
    {

        private const string ByInputObject = "ByInputObject";
        private const string ByRuleName = "ByRuleName";
        private const string ByResourceId = "ByResourceId";

        #region Cmdlet parameters

        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Scheduled Query Rule resource")]
        [ValidateNotNull]
        public PSScheduledQueryRuleResource InputObject { get; set; }

        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        //
        // Summary:
        //     Gets or sets source (Query, DataSourceId, etc.) for rule.
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, HelpMessage = "The scheduled query rule source")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, HelpMessage = "The scheduled query rule source")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, HelpMessage = "The scheduled query rule source")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleSource Source { get; set; }

        //
        // Summary:
        //     Gets or sets schedule (Frequnecy, Time Window) for rule.
        [Parameter(ParameterSetName = ByRuleName, Mandatory = false, HelpMessage = "The scheduled query rule schedule")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, HelpMessage = "The scheduled query rule schedule")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, HelpMessage = "The scheduled query rule schedule")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleSchedule Schedule { get; set; }

        //
        // Summary:
        //     Gets or sets action needs to be taken on rule execution.
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, HelpMessage = "The scheduled query rule Alerting Action")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, HelpMessage = "The scheduled query rule Alerting Action")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, HelpMessage = "The scheduled query rule Alerting Action")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleAlertingAction Action { get; set; }

        //
        // Summary:
        //     Region where alert is to be created
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, HelpMessage = "The location for this alert")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, HelpMessage = "The location for this alert")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, HelpMessage = "The location for this alert")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Batch/operations")]
        public string Location { get; set; }

        //
        // Summary:
        //     Alert description
        [Parameter(ParameterSetName = ByRuleName, Mandatory = false, HelpMessage = "The description for this alert")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, HelpMessage = "The description for this alert")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, HelpMessage = "The description for this alert")]
        public string Description { get; set; }

        //
        // Summary:
        //     Alert name
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, HelpMessage = "The alert name")]
        [ResourceNameCompleter("Microsoft.insights/scheduledqueryrules", nameof(ResourceGroupName))]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ResourceGroupName parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        //
        // Summary:
        //     Resource tags
        [Parameter(ParameterSetName = ByRuleName, Mandatory = false, HelpMessage = "Resource tags")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, HelpMessage = "Resource tags")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, HelpMessage = "Resource tags")]
        public Hashtable Tag { get; set; }

        //
        // Summary:
        //     Alert status - enabled or not, supported values - "true", "false"
        [Parameter(ParameterSetName = ByRuleName, Mandatory = false, HelpMessage = "The azure alert state - valid values - true, false")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, HelpMessage = "The azure alert state - valid values - true, false")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, HelpMessage = "The azure alert state - valid values - true, false")]
        [PSArgumentCompleter("true", "false")]
        public bool Enabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
        #endregion

        protected override void ProcessRecordInternal()
        {
            ResourceIdentifier resourceIdentifier = null;
            ScheduledQueryRuleResource requestBody = null;

            // ByInputObject parameter set
            if (this.IsParameterBound(c => c.InputObject) || this.InputObject != null)
            {
                resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.Name = resourceIdentifier.ResourceName;
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;

                requestBody = UpdateScheduledQueryRuleResource(this.InputObject);
            }
            else
            {
                // ByRuleName and ByResourceId parameter sets
                if (this.IsParameterBound(c => c.ResourceId) || !string.IsNullOrWhiteSpace(this.ResourceId))
                {
                    resourceIdentifier = new ResourceIdentifier(ResourceId);
                    this.Name = resourceIdentifier.ResourceName;
                    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                }

                try
                {
                    // Allowing only updates with Set-* command
                    requestBody = new ScheduledQueryRuleResource(
                        this.MonitorManagementClient.ScheduledQueryRules.GetWithHttpMessagesAsync(this.ResourceGroupName, this.Name).Result.Body);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in retrieving Log Alert Rule", ex);
                }

                requestBody = UpdateScheduledQueryRuleResource(requestBody);
            }

            try
            {
                if (ShouldProcess(this.Name, string.Format("Updating Log Alert Rule '{0}' in resource group '{1}'.", this.Name, this.ResourceGroupName)))
                {
                    requestBody.Validate();

                    // Update the Log Alert rule
                    var result = this.MonitorManagementClient.ScheduledQueryRules.CreateOrUpdateWithHttpMessagesAsync(
                            this.ResourceGroupName, this.Name, requestBody).Result;

                    WriteObject(new PSScheduledQueryRuleResource(result.Body));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in updating Log Alert Rule", ex);
            }
        }

        private ScheduledQueryRuleResource UpdateScheduledQueryRuleResource(ScheduledQueryRuleResource requestBody)
        {
            if (this.MyInvocation.BoundParameters.ContainsKey("Location") || this.Location != null)
            {
                requestBody.Location = this.Location;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey("Action") || this.Action != null)
            {
                var alertingAction = new AlertingAction(severity: Action.Severity, aznsAction: Action.AznsAction, trigger: Action.Trigger, throttlingInMin: Action.ThrottlingInMin);
                requestBody.Action = alertingAction;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey("Source") || this.Source != null)
            {
                requestBody.Source = this.Source;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey("Enabled"))
            {
                requestBody.Enabled = this.Enabled? "true" : "false";
            }

            if (this.MyInvocation.BoundParameters.ContainsKey("Description") || this.Description != null)
            {
                requestBody.Description = this.Description;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey("Schedule") || this.Schedule != null)
            {
                requestBody.Schedule = this.Schedule;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey("Tags") || this.Tag != null)
            {
                Dictionary<string, string> tags = TagsConversionHelper.CreateTagDictionary(Tag, true);
                requestBody.Tags = tags;
            }

            return requestBody;
        }
    }
}
