using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.IotSecuritySolutionAnalytics
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecurityAnalyticsAggregatedAlerts", DefaultParameterSetName = ParameterSetNames.SolutionScope), OutputType(typeof(PSIoTSecurityAggregatedAlert))]
    public class GetIoTSecurityAggregatedAlert : SecurityCenterCmdletBase
    {
        private const int MaxAlertsToFetch = 1500;

        [Parameter(ParameterSetName = ParameterSetNames.SolutionScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.SolutionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SolutionScope, Mandatory = true, HelpMessage = ParameterHelpMessages.SolutionName)]
        [Parameter(ParameterSetName = ParameterSetNames.SolutionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.SolutionName)]
        [ValidateNotNullOrEmpty]
        public string SolutionName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SolutionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            int numberOfFetchedAlerts = 0;
            string nextLink = null;

            switch (ParameterSetName)
            {
                case ParameterSetNames.SolutionScope:
                    var alerts = SecurityCenterClient.IotSecuritySolutionsAnalyticsAggregatedAlert.ListWithHttpMessagesAsync(ResourceGroupName, SolutionName).GetAwaiter().GetResult().Body;
                    var PSTypeAlerts = alerts.ConvertToPSType();
                    WriteObject(PSTypeAlerts, enumerateCollection: true);
                    numberOfFetchedAlerts += PSTypeAlerts.Count;
                    nextLink = alerts?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedAlerts < MaxAlertsToFetch)
                    {
                        alerts = SecurityCenterClient.IotSecuritySolutionsAnalyticsAggregatedAlert.ListNextWithHttpMessagesAsync(alerts.NextPageLink).GetAwaiter().GetResult().Body;
                        PSTypeAlerts = alerts.ConvertToPSType();
                        WriteObject(PSTypeAlerts, enumerateCollection: true);
                        numberOfFetchedAlerts += PSTypeAlerts.Count;
                        nextLink = alerts?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.SolutionLevelResource:
                    var alert = SecurityCenterClient.IotSecuritySolutionsAnalyticsAggregatedAlert.GetWithHttpMessagesAsync(ResourceGroupName, SolutionName, Name).GetAwaiter().GetResult().Body;
                    WriteObject(alert.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}

