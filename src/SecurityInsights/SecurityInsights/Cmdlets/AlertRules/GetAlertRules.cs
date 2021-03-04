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
using Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;
using Microsoft.Azure.Management.SecurityInsights;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.AlertRules
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelAlertRule", DefaultParameterSetName = ParameterSetNames.WorkspaceScope), OutputType(typeof(PSSentinelAlertRule))]
    public class GetIncidents : SecurityInsightsCmdletBase
    {
        private const int MaxAlertRulesToFetch = 1500;

        [Parameter(ParameterSetName = ParameterSetNames.WorkspaceScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.WorkspaceScope, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.IncidentId)]
        [ValidateNotNullOrEmpty]
        public string AlertRuleId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            int numberOfFetchedAlertRules = 0;
            string nextLink = null;
            switch (ParameterSetName)
            {
                case ParameterSetNames.WorkspaceScope:
                    var alertrules = SecurityInsightsClient.AlertRules.List(ResourceGroupName, WorkspaceName);
                    
                    int alertrulescount = alertrules.Count();
                    WriteObject(alertrules.ConvertToPSType(), enumerateCollection: true);
                    numberOfFetchedAlertRules += alertrulescount;
                    nextLink = alertrules?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedAlertRules < MaxAlertRulesToFetch)
                    {
                        alertrules = SecurityInsightsClient.AlertRules.ListNext(alertrules.NextPageLink);
                        alertrulescount = alertrules.Count();
                        WriteObject(alertrules.ConvertToPSType(), enumerateCollection: true);
                        numberOfFetchedAlertRules += alertrulescount;
                        nextLink = alertrules?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.AlertRuleId:
                    var alertrule = SecurityInsightsClient.AlertRules.Get(ResourceGroupName, WorkspaceName, AlertRuleId);
                    WriteObject(alertrule.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    alertrule = SecurityInsightsClient.AlertRules.Get(ResourceGroupName, WorkspaceName, AzureIdUtilities.GetResourceName(ResourceId));
                    WriteObject(alertrule.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
