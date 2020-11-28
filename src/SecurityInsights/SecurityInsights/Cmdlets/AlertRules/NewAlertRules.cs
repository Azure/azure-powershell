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
using System;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.AlertRules
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelAlertRule", DefaultParameterSetName = ParameterSetNames.ScheduledAlertRule), OutputType(typeof(PSSentinelAlertRule))]
    public class NewAlertRules : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.FusionAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty] 
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.FusionAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty] 
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.Kind)]
        public SwitchParameter Scheduled { get; set; }
        
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = true, HelpMessage = ParameterHelpMessages.Kind)]
        public SwitchParameter MicrosoftSecurityIncidentCreation { get; set; }
        
        [Parameter(ParameterSetName = ParameterSetNames.FusionAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.Kind)]
        public SwitchParameter Fusion { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.FusionAlertRule, Mandatory = false, HelpMessage = ParameterHelpMessages.AlertRuleId)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = false, HelpMessage = ParameterHelpMessages.AlertRuleId)]
        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = false, HelpMessage = ParameterHelpMessages.AlertRuleId)]
        public string AlertRuleId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.FusionAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.AlertRuleTemplateName)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = false, HelpMessage = ParameterHelpMessages.AlertRuleTemplateName)]
        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = false, HelpMessage = ParameterHelpMessages.AlertRuleTemplateName)]
        [ValidateNotNullOrEmpty]
        public string AlertRuleTemplateName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.FusionAlertRule, Mandatory = false, HelpMessage = ParameterHelpMessages.Enabled)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = false, HelpMessage = ParameterHelpMessages.Enabled)]
        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = false, HelpMessage = ParameterHelpMessages.Enabled)]
        public SwitchParameter Enabled { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = true, HelpMessage = ParameterHelpMessages.DisplayName)]
        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.DisplayName)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = true, HelpMessage = ParameterHelpMessages.ProductFilter)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Azure Active Directory Identity Protection", "Azure Advanced Threat Protection", "Azure Security Center", "Azure Security Center for IoT", "Microsoft Cloud App Security", "Microsoft Defender Advanced Threat Protection", "Office 365 Advanced Threat Protection")]
        public string ProductFilter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = false, HelpMessage = ParameterHelpMessages.Description)]
        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = false, HelpMessage = ParameterHelpMessages.Description)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = false, HelpMessage = ParameterHelpMessages.DisplayNamesExcludeFilter)]
        [ValidateNotNullOrEmpty]
        public IList<string> DisplayNamesExcludeFilter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = false, HelpMessage = ParameterHelpMessages.DisplayNamesFilter)]
        [ValidateNotNullOrEmpty]
        public IList<string> DisplayNamesFilter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftSecurityIncidentCreationRule, Mandatory = false, HelpMessage = ParameterHelpMessages.SeveritiesFilter)]
        [ValidateNotNullOrEmpty]
        public IList<string> SeveritiesFilter { get; set; }

       [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = false, HelpMessage = ParameterHelpMessages.SuppressionDuration)]
        [ValidateNotNullOrEmpty]
        public TimeSpan SuppressionDuration { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = false, HelpMessage = ParameterHelpMessages.SuppressionEnabled)]
        public SwitchParameter SuppressionEnabled { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.Query)]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.QueryFrequency)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? QueryFrequency { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.QueryPeriod)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? QueryPeriod { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.Severity)]
        [ValidateSet("High", "Informational", "Low", "Medium")]
        [ValidateNotNullOrEmpty]
        public string Severity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = false, HelpMessage = ParameterHelpMessages.Tactics)]
        [ValidateNotNullOrEmpty]
        public IList<string> Tactics { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = false, HelpMessage = ParameterHelpMessages.TriggerOperator)]
        [ValidateSet("Equal", "GreaterThan", "LessThan", "NotEqual")]
        [ValidateNotNullOrEmpty]
        public TriggerOperator TriggerOperator { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ScheduledAlertRule, Mandatory = true, HelpMessage = ParameterHelpMessages.TriggerThreshold)]
        [ValidateNotNullOrEmpty]
        public int? TriggerThreshold { get; set; }


        public override void ExecuteCmdlet()
        {

            if(AlertRuleId == null)
            {
                AlertRuleId = Guid.NewGuid().ToString();
            }
            if(SuppressionEnabled == false)
            {
                SuppressionDuration = new TimeSpan(1, 00, 00);
            }
            if(AlertRuleTemplateName == null)
            {
                AlertRuleTemplateName = "";
            }

            var name = AlertRuleId;
            if (ShouldProcess(name, VerbsCommon.New))
            {
                
                switch(ParameterSetName)
                {
                    case ParameterSetNames.FusionAlertRule:
                        FusionAlertRule fusionalertrule = new FusionAlertRule
                        {
                            AlertRuleTemplateName = AlertRuleTemplateName,
                            Enabled = Enabled
                        };
                        var outputfusionalertrule = SecurityInsightsClient.AlertRules.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, fusionalertrule);
                        WriteObject(outputfusionalertrule.ConvertToPSType(), enumerateCollection: false);
                        break;
                    case ParameterSetNames.MicrosoftSecurityIncidentCreationRule:
                        MicrosoftSecurityIncidentCreationAlertRule msicalertrule = new MicrosoftSecurityIncidentCreationAlertRule
                        {
                            DisplayName = DisplayName,
                            Enabled = Enabled,
                            ProductFilter = ProductFilter,
                            AlertRuleTemplateName = AlertRuleTemplateName,
                            Description = Description,
                            DisplayNamesExcludeFilter = DisplayNamesExcludeFilter,
                            DisplayNamesFilter = DisplayNamesFilter,
                            SeveritiesFilter = SeveritiesFilter
                        };
                        var outputmsicalertrule = SecurityInsightsClient.AlertRules.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, msicalertrule);
                        WriteObject(outputmsicalertrule.ConvertToPSType(), enumerateCollection: false);
                        break;
                    case ParameterSetNames.ScheduledAlertRule:
                        ScheduledAlertRule scheduledalertrule = new ScheduledAlertRule
                        {
                            DisplayName = DisplayName,
                            Enabled = Enabled,
                            SuppressionDuration = SuppressionDuration,
                            SuppressionEnabled = SuppressionEnabled,
                            AlertRuleTemplateName = AlertRuleTemplateName,
                            Description = Description,
                            Query = Query,
                            QueryFrequency = QueryFrequency,
                            QueryPeriod = QueryPeriod,
                            Severity = Severity,
                            Tactics = Tactics,
                            TriggerOperator = TriggerOperator,
                            TriggerThreshold = TriggerThreshold
                        };
                        var outputscheduledalertrule = SecurityInsightsClient.AlertRules.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, scheduledalertrule);
                        WriteObject(outputscheduledalertrule.ConvertToPSType(), enumerateCollection: false);
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }
            }
        }
    }
}
