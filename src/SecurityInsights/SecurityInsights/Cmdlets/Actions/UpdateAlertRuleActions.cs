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
using Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.SecurityInsights;
using System;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Actions
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelAlertRuleAction", DefaultParameterSetName = ParameterSetNames.ActionId, SupportsShouldProcess = true), OutputType(typeof(PSSentinelActionResponse))]
    public class UpdateAlertRuleActions : SecurityInsightsCmdletBase
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

        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = ParameterHelpMessages.LogicAppResourceId)]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.ResourceId, HelpMessage = ParameterHelpMessages.LogicAppResourceId)]
        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.LogicAppResourceId)]
        [ValidateNotNullOrEmpty]
        public string LogicAppResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = ParameterHelpMessages.TriggerUri)]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.ResourceId, HelpMessage = ParameterHelpMessages.TriggerUri)]
        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.TriggerUri)]
        public string TriggerUri { get; set; }



        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNull]
        public PSSentinelActionResponse InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSetNames.ResourceId, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }


        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = AzureIdUtilities.GetResourceGroup(this.InputObject.Id);
                this.WorkspaceName = AzureIdUtilities.GetWorkspaceName(this.InputObject.Id);
                this.AlertRuleId = AzureIdUtilities.GetAlertRuleName(this.InputObject.Id);
                this.ActionId = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = AzureIdUtilities.GetWorkspaceName(this.ResourceId);
                this.AlertRuleId = AzureIdUtilities.GetAlertRuleName(this.ResourceId);
                this.ActionId = resourceIdentifier.ResourceName;
            }

            PSSentinelActionResponse alertRuleAction = null;
            try
            {
                alertRuleAction = this.SecurityInsightsClient.Actions.Get(ResourceGroupName, WorkspaceName, AlertRuleId, ActionId).ConvertToPSType();
            }
            catch
            {
                alertRuleAction = null;
            }

            if (alertRuleAction == null)
            {
                throw new Exception(string.Format("An Alert Rule Action with ActionId '{0}' for Alert Rule '{1}' in resource group '{2}' under workspace '{3}' does not exist. Please use New-AzSentinelAlertRuleAction to create an Alert Rule Action with these properties.", this.ActionId, this.AlertRuleId, this.ResourceGroupName, this.WorkspaceName));
            }

            PSSentinelActionRequest updateAlertRuleAction = new PSSentinelActionRequest
            {
                LogicAppResourceId = this.LogicAppResourceId,
                TriggerUri = this.TriggerUri
            };
            
            if (this.ShouldProcess(this.ActionId, string.Format("Updating Action '{0}' for Alert Rule '{1}' in resource group '{2}' under workspace '{3}'.", this.ActionId, this.AlertRuleId, this.ResourceGroupName, this.WorkspaceName)))
            {
                var result = this.SecurityInsightsClient.Actions.CreateOrUpdate(this.ResourceGroupName, this.WorkspaceName, this.AlertRuleId, this.ActionId, updateAlertRuleAction.CreatePSType()).ConvertToPSType();
                WriteObject(result);
            }
        }
    }
}