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
using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Security.Cmdlets.AlertsSuppressionRules
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertsSuppressionRule", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSAlertsSuppressionRule))]
    public class GetAlertsSuppressionRule : SecurityCenterCmdletBase
    {
        private const int MaxItemsToFetch = 10000;
        
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionScope:
                    int fetchedItems = 0;
                    string nextLink = null;

                    var rules = SecurityCenterClient.AlertsSuppressionRules.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                    var psSuppressionRule = rules.ConvertToPSType();
                    WriteObject(psSuppressionRule, enumerateCollection: true);

                    fetchedItems += psSuppressionRule.Count;
                    nextLink = rules?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && fetchedItems < MaxItemsToFetch)
                    {
                        rules = SecurityCenterClient.AlertsSuppressionRules.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                        psSuppressionRule = rules.ConvertToPSType();
                        WriteObject(psSuppressionRule, enumerateCollection: true);
                        
                        fetchedItems += psSuppressionRule.Count;
                        nextLink = rules?.NextPageLink;
                    }

                    break;
                case ParameterSetNames.SubscriptionLevelResource:
                    var rule = SecurityCenterClient.AlertsSuppressionRules.GetWithHttpMessagesAsync(Name).GetAwaiter().GetResult().Body;
                    WriteObject(rule.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    rule = SecurityCenterClient.AlertsSuppressionRules.GetWithHttpMessagesAsync(AzureIdUtilities.GetResourceName(ResourceId)).GetAwaiter().GetResult().Body;
                    WriteObject(rule.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
