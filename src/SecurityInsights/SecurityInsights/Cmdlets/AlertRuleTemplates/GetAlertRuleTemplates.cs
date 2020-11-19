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
using Microsoft.Azure.Commands.SecurityInsights.Models.AlertRuleTemplates;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;
using Microsoft.Azure.Management.SecurityInsights;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.AlertRulesTemplates
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelAlertRuleTemplate", DefaultParameterSetName = ParameterSetNames.WorkspaceScope), OutputType(typeof(PSSentinelAlertRuleTemplate))]
    public class GetAlertRuleTemplate : SecurityInsightsCmdletBase
    {
        private const int MaxAlertRulesToFetch = 1500;

        [Parameter(ParameterSetName = ParameterSetNames.WorkspaceScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleTemplateId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.WorkspaceScope, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleTemplateId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleTemplateId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AlertRuleTemplateId)]
        [ValidateNotNullOrEmpty]
        public string AlertRuleTemplateId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            int numberOfFetchedAlertRuleTemplates = 0;
            string nextLink = null;
            switch (ParameterSetName)
            {
                case ParameterSetNames.WorkspaceScope:
                    var alertruletemplate = SecurityInsightsClient.AlertRuleTemplates.List(ResourceGroupName, WorkspaceName);
                    
                    int alertruletemplatecount = alertruletemplate.Count();
                    WriteObject(alertruletemplate.ConvertToPSType(), enumerateCollection: true);
                    numberOfFetchedAlertRuleTemplates += alertruletemplatecount;
                    nextLink = alertruletemplate?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedAlertRuleTemplates < MaxAlertRulesToFetch)
                    {
                        alertruletemplate = SecurityInsightsClient.AlertRuleTemplates.ListNext(alertruletemplate.NextPageLink);
                        alertruletemplatecount = alertruletemplate.Count();
                        WriteObject(alertruletemplate.ConvertToPSType(), enumerateCollection: true);
                        numberOfFetchedAlertRuleTemplates += alertruletemplatecount;
                        nextLink = alertruletemplate?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.AlertRuleTemplateId:
                    var alertruletemplate2 = SecurityInsightsClient.AlertRuleTemplates.Get(ResourceGroupName, WorkspaceName, AlertRuleTemplateId);
                    WriteObject(alertruletemplate2.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    alertruletemplate2 = SecurityInsightsClient.AlertRuleTemplates.Get(ResourceGroupName, WorkspaceName, AzureIdUtilities.GetResourceName(ResourceId));
                    WriteObject(alertruletemplate2.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
