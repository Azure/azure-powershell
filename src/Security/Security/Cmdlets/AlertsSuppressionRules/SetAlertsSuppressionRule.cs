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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Security.Cmdlets.AlertsSuppressionRules
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertsSuppressionRule", DefaultParameterSetName = ParameterSetNames.RuleNameWithParameters, SupportsShouldProcess = true), OutputType(typeof(PSAlertsSuppressionRule))]
    public class SetAlertsSuppressionRule : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        public PSAlertsSuppressionRule InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.RuleNameWithParameters, HelpMessage = "Alert suppression rule name, needs to be unique per subscription.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = "Alert suppression rule name, needs to be unique per subscription.")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.RuleNameWithParameters, HelpMessage = "Alert type to suppress.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = "Alert type to suppress.")]
        public string AlertType { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.RuleNameWithParameters, HelpMessage = "Set an expiration data for the rule, expected to be in a UTC format.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = "Set an expiration data for the rule, expected to be in a UTC format.")]
        public DateTime? ExpirationDateUtc { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.RuleNameWithParameters, HelpMessage = "The reason for creating the suppression rule.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = "The reason creating the suppression rule.")]
        public string Reason { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.RuleNameWithParameters, HelpMessage = "State of the rule, Enabled/Disabled")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = "State of the rule, Enabled/Disabled")]
        public PSRuleState State { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.RuleNameWithParameters, HelpMessage = "Comment.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = "Comment.")]
        public string Comment { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.RuleNameWithParameters, HelpMessage = "Scope the suppression rule using specific entities.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = "Scope the suppression rule using specific entities.")]
        public PSSuppressionAlertsScope SuppressionAlertsScope { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.RuleNameWithParameters, HelpMessage = "Scope the suppression rule using specific entities.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = "Scope the suppression rule using specific entities.")]
        public PSIScopeElement[] AllOf { get; set; }

        public override void ExecuteCmdlet()
        {
            var name = Name ?? InputObject?.Name;
            if (ShouldProcess(name, VerbsCommon.Set))
            {
                AlertsSuppressionRule alertsSuppressionRuleInput;

                if (this.IsParameterBound(c => c.InputObject))
                {

                    if (this.IsParameterBound(c => c.Name))
                    {
                        InputObject.Name = Name;
                    }

                    if (this.IsParameterBound(c => c.AlertType))
                    {
                        InputObject.AlertType = AlertType;
                    }

                    if (this.IsParameterBound(c => c.Comment))
                    {
                        InputObject.Comment = Comment;
                    }

                    if (this.IsParameterBound(c => c.ExpirationDateUtc))
                    {
                        InputObject.ExpirationDateUtc = ExpirationDateUtc;
                    }

                    if (this.IsParameterBound(c => c.Reason))
                    {
                        InputObject.Reason = Reason;
                    }

                    if (this.IsParameterBound(c => c.State))
                    {
                        InputObject.State = State;
                    }

                    if (this.IsParameterBound(c => c.SuppressionAlertsScope))
                    {
                        InputObject.SuppressionAlertsScope = SuppressionAlertsScope;
                    }

                    alertsSuppressionRuleInput = InputObject.ConvertToNetType();
                }
                else
                {
                    SuppressionAlertsScope alertsScope = null;
                    if (this.IsParameterBound(c => c.SuppressionAlertsScope))
                    {
                        alertsScope = SuppressionAlertsScope.ConvertToNetType();
                    }
                    else if (this.IsParameterBound(c => c.AllOf))
                    {
                        alertsScope = new SuppressionAlertsScope(AllOf?.Select(sc => sc.ConvertToNetType()).ToList());
                    }

                    // Setting scope to null if there are no items in the array
                    alertsScope = alertsScope?.AllOf?.Count > 0 ? alertsScope : null;

                    alertsSuppressionRuleInput = new AlertsSuppressionRule(AlertType, Reason, State.ConvertToNetType(), name: Name, expirationDateUtc: ExpirationDateUtc, comment: Comment, suppressionAlertsScope: alertsScope);
                }

                var alertsSuppressionRule = SecurityCenterClient.AlertsSuppressionRules.UpdateWithHttpMessagesAsync(name, alertsSuppressionRuleInput).GetAwaiter().GetResult().Body;
                WriteObject(alertsSuppressionRule.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}