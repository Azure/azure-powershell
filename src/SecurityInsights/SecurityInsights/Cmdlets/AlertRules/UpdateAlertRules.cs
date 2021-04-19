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
// ------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Commands.SecurityInsights;
using Microsoft.Azure.Commands.SecurityInsights.Common;
using Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.SecurityInsights;
using System;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Actions
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelAlertRule", DefaultParameterSetName = ParameterSetNames.AlertRuleId, SupportsShouldProcess = true), OutputType(typeof(PSSentinelAlertRule))]
    public class UpdateAlertRules : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleId, Mandatory = true, HelpMessage = ParameterHelpMessages.AlertRuleId)]
        [ValidateNotNullOrEmpty]
        public string AlertRuleId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.AlertRuleTemplateName)]
        [ValidateNotNullOrEmpty]
        public string AlertRuleTemplateName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Enabled)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Enabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Disabled)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Disabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.DisplayName)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.ProductFilter)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Azure Active Directory Identity Protection", "Azure Advanced Threat Protection", "Azure Security Center", "Azure Security Center for IoT", "Microsoft Cloud App Security", "Microsoft Defender Advanced Threat Protection", "Office 365 Advanced Threat Protection")]
        public string ProductFilter { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Description)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.DisplayNamesExcludeFilter)]
        [ValidateNotNullOrEmpty]
        public IList<string> DisplayNamesExcludeFilter { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.DisplayNamesFilter)]
        [ValidateNotNullOrEmpty]
        public IList<string> DisplayNamesFilter { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.SeveritiesFilter)]
        [ValidateNotNullOrEmpty]
        public IList<string> SeveritiesFilter { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.SuppressionDuration)]
        [ValidateNotNullOrEmpty]
        public TimeSpan SuppressionDuration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.SuppressionEnabled)] 
        public SwitchParameter SuppressionEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.SuppressionDisabled)]
        public SwitchParameter SuppressionDisabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Query)]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.QueryFrequency)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? QueryFrequency { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.QueryPeriod)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? QueryPeriod { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Severity)]
        [ValidateNotNullOrEmpty]
        public string Severity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Tactics)]
        [ValidateNotNullOrEmpty]
        public IList<string> Tactic { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.TriggerOperator)]
        [ValidateNotNullOrEmpty]
        public TriggerOperator TriggerOperator { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.TriggerThreshold)]
        [ValidateNotNullOrEmpty]
        public int? TriggerThreshold { get; set; }


        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNull]
        public PSSentinelAlertRule InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSetNames.ResourceId, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }


        public override void ExecuteCmdlet()
        {

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = AzureIdUtilities.GetResourceGroup(this.InputObject.Id);
                this.WorkspaceName = AzureIdUtilities.GetWorkspaceName(this.InputObject.Id);
                this.AlertRuleId = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = AzureIdUtilities.GetWorkspaceName(this.ResourceId);
                this.AlertRuleId = resourceIdentifier.ResourceName;
            }

            PSSentinelAlertRule alertRule = null;
            try
            {
                alertRule = this.SecurityInsightsClient.AlertRules.Get(ResourceGroupName, WorkspaceName, AlertRuleId).ConvertToPSType();
            }
            catch
            {
                alertRule = null;
            }

            if (alertRule == null)
            {
                throw new Exception(string.Format("An Alert Rule with AlertRuleId '{0}' in resource group '{1}' under workspace '{2}' does not exist. Please use New-AzSentinelAlertRule to create an Alert Rule Action with these properties.", this.AlertRuleId, this.ResourceGroupName, this.WorkspaceName));
            }

            if(alertRule.Kind == "Fusion") 
            {
                var convertedFusionAlertRule = alertRule as PSSentinelFusionAlertRule;

                convertedFusionAlertRule.Etag = convertedFusionAlertRule.Etag;
                convertedFusionAlertRule.AlertRuleTemplateName = this.IsParameterBound(c => c.AlertRuleTemplateName) ? this.AlertRuleTemplateName : convertedFusionAlertRule.AlertRuleTemplateName;
                if (this.IsParameterBound(c => c.Enabled))
                {
                    convertedFusionAlertRule.Enabled = true;
                }
                else if (this.IsParameterBound(c => c.Disabled))
                {
                    convertedFusionAlertRule.Enabled = false;
                }
                else
                {
                    convertedFusionAlertRule.Enabled = convertedFusionAlertRule.Enabled;
                }

                var alertule = convertedFusionAlertRule;
            };
            if(alertRule.Kind == "MicrosoftSecurityIncidentCreation") 
            {
                var convertedMicrosoftSecurityIncidentCreationAlertRule = alertRule as PSSentinelMicrosoftSecurityIncidentCreationRule;

                convertedMicrosoftSecurityIncidentCreationAlertRule.Etag = convertedMicrosoftSecurityIncidentCreationAlertRule.Etag;
                convertedMicrosoftSecurityIncidentCreationAlertRule.DisplayName = this.IsParameterBound(c => c.DisplayName) ? this.DisplayName : convertedMicrosoftSecurityIncidentCreationAlertRule.DisplayName;
                if (this.IsParameterBound(c => c.Enabled))
                {
                    convertedMicrosoftSecurityIncidentCreationAlertRule.Enabled = true;
                }
                else if (this.IsParameterBound(c => c.Disabled))
                {
                    convertedMicrosoftSecurityIncidentCreationAlertRule.Enabled = false;
                }
                else
                {
                    convertedMicrosoftSecurityIncidentCreationAlertRule.Enabled = convertedMicrosoftSecurityIncidentCreationAlertRule.Enabled;
                }
                convertedMicrosoftSecurityIncidentCreationAlertRule.Description = this.IsParameterBound(c => c.Description) ? this.Description : convertedMicrosoftSecurityIncidentCreationAlertRule.Description;
                convertedMicrosoftSecurityIncidentCreationAlertRule.AlertRuleTemplateName = this.IsParameterBound(c => c.AlertRuleTemplateName) ? this.AlertRuleTemplateName : convertedMicrosoftSecurityIncidentCreationAlertRule.AlertRuleTemplateName;
                convertedMicrosoftSecurityIncidentCreationAlertRule.ProductFilter = this.IsParameterBound(c => c.ProductFilter) ? this.ProductFilter : convertedMicrosoftSecurityIncidentCreationAlertRule.ProductFilter;
                convertedMicrosoftSecurityIncidentCreationAlertRule.DisplayNamesExcludeFilter = this.IsParameterBound(c => c.DisplayNamesExcludeFilter) ? this.DisplayNamesExcludeFilter : convertedMicrosoftSecurityIncidentCreationAlertRule.DisplayNamesExcludeFilter;
                convertedMicrosoftSecurityIncidentCreationAlertRule.DisplayNamesFilter = this.IsParameterBound(c => c.DisplayNamesFilter) ? this.DisplayNamesFilter : convertedMicrosoftSecurityIncidentCreationAlertRule.DisplayNamesFilter;
                convertedMicrosoftSecurityIncidentCreationAlertRule.SeveritiesFilter = this.IsParameterBound(c => c.SeveritiesFilter) ? this.SeveritiesFilter : convertedMicrosoftSecurityIncidentCreationAlertRule.SeveritiesFilter;

                var alertule = convertedMicrosoftSecurityIncidentCreationAlertRule;
            };
            if (alertRule.Kind == "Scheduled") 
            {
                var convertedScheduledAlertRule = alertRule as PSSentinelScheduledAlertRule;

                convertedScheduledAlertRule.Etag = convertedScheduledAlertRule.Etag;
                convertedScheduledAlertRule.DisplayName = this.IsParameterBound(c => c.DisplayName) ? this.DisplayName : convertedScheduledAlertRule.DisplayName;
                if (this.IsParameterBound(c => c.Enabled))
                {
                    convertedScheduledAlertRule.Enabled = true;
                }
                else if (this.IsParameterBound(c => c.Disabled))
                {
                    convertedScheduledAlertRule.Enabled = false;
                }
                else
                {
                    convertedScheduledAlertRule.Enabled = convertedScheduledAlertRule.Enabled;
                }
                convertedScheduledAlertRule.SuppressionDuration = this.IsParameterBound(c => c.SuppressionDuration) ? this.SuppressionDuration : convertedScheduledAlertRule.SuppressionDuration;
                if (this.IsParameterBound(c => c.SuppressionEnabled))
                {
                    convertedScheduledAlertRule.SuppressionEnabled = true;
                }
                else if (this.IsParameterBound(c => c.SuppressionDisabled))
                {
                    convertedScheduledAlertRule.SuppressionEnabled = false;
                }
                else
                {
                    convertedScheduledAlertRule.SuppressionEnabled = convertedScheduledAlertRule.SuppressionEnabled;
                }
                convertedScheduledAlertRule.AlertRuleTemplateName = this.IsParameterBound(c => c.AlertRuleTemplateName) ? this.AlertRuleTemplateName : convertedScheduledAlertRule.AlertRuleTemplateName;
                convertedScheduledAlertRule.Description = this.IsParameterBound(c => c.Description) ? this.Description : convertedScheduledAlertRule.Description;
                convertedScheduledAlertRule.Query = this.IsParameterBound(c => c.Query) ? this.Query : convertedScheduledAlertRule.Query;
                convertedScheduledAlertRule.QueryFrequency = this.IsParameterBound(c => c.QueryFrequency) ? this.QueryFrequency : convertedScheduledAlertRule.QueryFrequency;
                convertedScheduledAlertRule.QueryPeriod = this.IsParameterBound(c => c.QueryPeriod) ? this.QueryPeriod : convertedScheduledAlertRule.QueryPeriod;
                convertedScheduledAlertRule.Severity = this.IsParameterBound(c => c.Severity) ? this.Severity : convertedScheduledAlertRule.Severity;
                convertedScheduledAlertRule.Tactics = this.IsParameterBound(c => c.Tactic) ? this.Tactic : convertedScheduledAlertRule.Tactics;
                convertedScheduledAlertRule.TriggerOperator = this.IsParameterBound(c => c.TriggerOperator) ? this.TriggerOperator : convertedScheduledAlertRule.TriggerOperator;
                convertedScheduledAlertRule.TriggerThreshold = this.IsParameterBound(c => c.TriggerThreshold) ? this.TriggerThreshold : convertedScheduledAlertRule.TriggerThreshold;

                var alertule = convertedScheduledAlertRule;
            };

            if (this.ShouldProcess(this.AlertRuleId, string.Format("Updating Alert Rule '{0}' in resource group '{1}' under workspace '{2}'.", this.AlertRuleId, this.ResourceGroupName, this.WorkspaceName)))
            {
                var result = this.SecurityInsightsClient.AlertRules.CreateOrUpdate(this.ResourceGroupName, this.WorkspaceName, this.AlertRuleId, alertRule.CreatePSStype()).ConvertToPSType();
                WriteObject(result);
            }
        }
    }
}