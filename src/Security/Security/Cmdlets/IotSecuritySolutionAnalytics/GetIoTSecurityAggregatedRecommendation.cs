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
using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.IotSecuritySolutionAnalytics
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecurityAnalyticsAggregatedRecommendation", DefaultParameterSetName = ParameterSetNames.SolutionScope), OutputType(typeof(PSIoTSecurityAggregatedRecommendation))]
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
                    var PSTypeRecommendations = recommendations?.ConvertToPSType();
                    WriteObject(PSTypeRecommendations, enumerateCollection: true);
                    numberOfFetchedRecommendations += PSTypeRecommendations.Count;
                    nextLink = recommendations?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedRecommendations < MaxAlertsToFetch)
                    {
                        recommendations = SecurityCenterClient.IotSecuritySolutionsAnalyticsRecommendation.ListNextWithHttpMessagesAsync(recommendations.NextPageLink).GetAwaiter().GetResult().Body;
                        PSTypeRecommendations = recommendations?.ConvertToPSType();
                        WriteObject(PSTypeRecommendations, enumerateCollection: true);
                        numberOfFetchedRecommendations += PSTypeRecommendations.Count;
                        nextLink = recommendations?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.SolutionLevelResource:
                    var recommendation = SecurityCenterClient.IotSecuritySolutionsAnalyticsRecommendation.GetWithHttpMessagesAsync(ResourceGroupName, SolutionName, Name).GetAwaiter().GetResult().Body;
                    WriteObject(recommendation?.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}


