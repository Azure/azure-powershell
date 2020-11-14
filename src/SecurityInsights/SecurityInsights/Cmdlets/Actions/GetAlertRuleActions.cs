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
using System.Management.Automation;
using Microsoft.Azure.Commands.SecurityInsights;
using Microsoft.Azure.Commands.SecurityInsights.Common;
using Microsoft.Azure.Commands.SecurityInsights.Models.Actions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Actions
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelAlertRuleAction", DefaultParameterSetName = ParameterSetNames.AlertRuleId), OutputType(typeof(PSSentinelAction))]
    public class GetAlertRuleActions : SecurityInsightsCmdletBase    
    {
        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.ActionId)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.ActionId)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleId, Mandatory = true, HelpMessage = ParameterHelpMessages.IncidentId)]
        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.ActionId)]
        [ValidateNotNullOrEmpty]
        public string AlertRuleId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.ActionId)]
        [ValidateNotNullOrEmpty]
        public string ActionId { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.AlertRuleId:
                    var actions = SecurityInsightsClient.Actions.ListByAlertRuleWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, AlertRuleId).GetAwaiter().GetResult().Body;
                    WriteObject(actions, enumerateCollection: false);
                    break;
                case ParameterSetNames.ActionId:
                    var action = SecurityInsightsClient.AlertRules.GetActionWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, AlertRuleId, ActionId);
                    WriteObject(action, enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
