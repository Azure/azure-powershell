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
using Microsoft.Azure.Commands.SecurityInsights.Models.Actions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Actions
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelAlertRuleAction", DefaultParameterSetName = ParameterSetNames.ActionId), OutputType(typeof(PSSentinelActionResponse))]
    public class SetAlertruleActions : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.AlertRuleId)]
        [ValidateNotNullOrEmpty]
        public string AlertRuleId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.ActionId)] 
        public string ActionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.LogicAppResourceId)]
        [ValidateNotNullOrEmpty]
        public string LogicAppResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.TriggerUri)]
        public string TriggerUri { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSSentinelActionResponse InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.ActionId:
                    break;
                case ParameterSetNames.InputObject:
                    ResourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    WorkspaceName = AzureIdUtilities.GetWorkspaceName(InputObject.Id);
                    ActionId = InputObject.Name;
                    AlertRuleId = AzureIdUtilities.GetAlertRuleName(InputObject.Id);
                    WorkspaceName = AzureIdUtilities.GetWorkspaceName(InputObject.Id);
                    ResourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    LogicAppResourceId = InputObject.LogicAppResourceId;
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            var name = ActionId;
            ActionRequest action = new ActionRequest
            {
                LogicAppResourceId = LogicAppResourceId,
                TriggerUri = TriggerUri
            };


            if (ShouldProcess(name, VerbsCommon.Set))
            {
                var outputaction = SecurityInsightsClient.AlertRules.CreateOrUpdateActionWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, AlertRuleId, name, action).GetAwaiter().GetResult().Body;

                WriteObject(outputaction?.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}
