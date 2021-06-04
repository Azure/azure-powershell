﻿// ----------------------------------------------------------------------------------
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
using System;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Commands.SecurityInsights.Models.Actions;
using Microsoft.Azure.Management.SecurityInsights;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Actions
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelAlertRuleAction", DefaultParameterSetName = ParameterSetNames.ActionId, SupportsShouldProcess = true), OutputType(typeof(PSSentinelActionResponse))]
    public class NewAlertRuleActions : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty] 
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty] 
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.AlertRuleId)]
        public string AlertRuleId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = false, HelpMessage = ParameterHelpMessages.ActionId)]
        public string ActionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.LogicAppResourceId)]
        [ValidateNotNullOrEmpty]
        public string LogicAppResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ActionId, Mandatory = true, HelpMessage = ParameterHelpMessages.TriggerUri)] 
        public string TriggerUri { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ActionId == null)
            {
                ActionId = Guid.NewGuid().ToString();
            }
            
            var name = ActionId;

            ActionRequest action = new ActionRequest
            {
                LogicAppResourceId = LogicAppResourceId,
                TriggerUri = TriggerUri
            };

            if (ShouldProcess(name, VerbsCommon.New))
            {
                var outputaction = SecurityInsightsClient.Actions.CreateOrUpdate(ResourceGroupName, WorkspaceName, AlertRuleId, name, action);

                WriteObject(outputaction.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}
