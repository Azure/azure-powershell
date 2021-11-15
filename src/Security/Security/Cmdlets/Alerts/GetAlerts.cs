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
using Commands.Security;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.Alerts;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Azure.Commands.SecurityCenter.Models.Alerts;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Alerts
{
    [CmdletOutputBreakingChange(typeof(PSSecurityAlert), ReplacementCmdletOutputTypeName = "PSSecurityAlertV3")]
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAlert", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecurityAlert))]
    public class GetAlerts : SecurityCenterCmdletBase
    {
        private const int MaxAlertsToFetch = 1500;

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Location)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Location)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Security/alerts")]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            int numberOfFetchedAlerts = 0;
            string nextLink = null;
            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionScope:
                    var alerts = SecurityCenterClient.Alerts.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                    var PSTypeAlerts = alerts.ConvertToPSType();
                    WriteObject(PSTypeAlerts, enumerateCollection: true);
                    numberOfFetchedAlerts += PSTypeAlerts.Count;
                    nextLink = alerts?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedAlerts < MaxAlertsToFetch)
                    {
                        alerts = SecurityCenterClient.Alerts.ListNextWithHttpMessagesAsync(alerts.NextPageLink).GetAwaiter().GetResult().Body;
                        PSTypeAlerts = alerts.ConvertToPSType();
                        WriteObject(PSTypeAlerts, enumerateCollection: true);
                        numberOfFetchedAlerts += PSTypeAlerts.Count;
                        nextLink = alerts?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.ResourceGroupScope:
                    alerts = SecurityCenterClient.Alerts.ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName).GetAwaiter().GetResult().Body;
                    PSTypeAlerts = alerts.ConvertToPSType();
                    WriteObject(PSTypeAlerts, enumerateCollection: true);
                    numberOfFetchedAlerts += PSTypeAlerts.Count;
                    nextLink = alerts?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedAlerts < MaxAlertsToFetch)
                    {
                        alerts = SecurityCenterClient.Alerts.ListNextWithHttpMessagesAsync(alerts.NextPageLink).GetAwaiter().GetResult().Body;
                        PSTypeAlerts = alerts.ConvertToPSType();
                        WriteObject(PSTypeAlerts, enumerateCollection: true);
                        numberOfFetchedAlerts += PSTypeAlerts.Count;
                        nextLink = alerts?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.SubscriptionLevelResource:
                    SecurityCenterClient.AscLocation = Location;
                    var alert = SecurityCenterClient.Alerts.GetSubscriptionLevelWithHttpMessagesAsync(Name).GetAwaiter().GetResult().Body;
                    WriteObject(alert.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceGroupLevelResource:
                    SecurityCenterClient.AscLocation = Location;
                    alert = SecurityCenterClient.Alerts.GetResourceGroupLevelWithHttpMessagesAsync(Name, ResourceGroupName).GetAwaiter().GetResult().Body;
                    WriteObject(alert.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    SecurityCenterClient.AscLocation = AzureIdUtilities.GetResourceLocation(ResourceId);

                    var rg = AzureIdUtilities.GetResourceGroup(ResourceId);

                    if (string.IsNullOrEmpty(rg))
                    {
                        alert = SecurityCenterClient.Alerts.GetSubscriptionLevelWithHttpMessagesAsync(AzureIdUtilities.GetResourceName(ResourceId)).GetAwaiter().GetResult().Body;
                    }
                    else
                    {
                        alert = SecurityCenterClient.Alerts.GetResourceGroupLevelWithHttpMessagesAsync(AzureIdUtilities.GetResourceName(ResourceId), rg).GetAwaiter().GetResult().Body;
                    }

                    WriteObject(alert.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
