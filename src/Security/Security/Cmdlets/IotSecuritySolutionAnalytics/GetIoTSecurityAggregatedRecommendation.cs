using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.IotSecuritySolutionAnalytics
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecurityAnalyticsAggregatedRecommendations", DefaultParameterSetName = ParameterSetNames.SolutionScope), OutputType(typeof(PSIoTSecurityAggregatedRecommendation))]
    public class GetIoTSecurityAggregatedRecommendation : SecurityCenterCmdletBase
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
            int numberOfFetchedRecommendations = 0;
            string nextLink = null;

            switch (ParameterSetName)
            {
                case ParameterSetNames.SolutionScope:
                    var recommendations = SecurityCenterClient.IotSecuritySolutionsAnalyticsRecommendation.ListWithHttpMessagesAsync(ResourceGroupName, SolutionName).GetAwaiter().GetResult().Body;
                    var PSTypeRecommendations = recommendations.ConvertToPSType();
                    WriteObject(PSTypeRecommendations, enumerateCollection: true);
                    numberOfFetchedRecommendations += PSTypeRecommendations.Count;
                    nextLink = recommendations?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedRecommendations < MaxAlertsToFetch)
                    {
                        recommendations = SecurityCenterClient.IotSecuritySolutionsAnalyticsRecommendation.ListNextWithHttpMessagesAsync(recommendations.NextPageLink).GetAwaiter().GetResult().Body;
                        PSTypeRecommendations = recommendations.ConvertToPSType();
                        WriteObject(PSTypeRecommendations, enumerateCollection: true);
                        numberOfFetchedRecommendations += PSTypeRecommendations.Count;
                        nextLink = recommendations?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.SolutionLevelResource:
                    var recommendation = SecurityCenterClient.IotSecuritySolutionsAnalyticsRecommendation.GetWithHttpMessagesAsync(ResourceGroupName, SolutionName, Name).GetAwaiter().GetResult().Body;
                    WriteObject(recommendation.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}


