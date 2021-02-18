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
using Microsoft.Azure.Commands.Security.Models.AssessmentMetadata;
using Microsoft.Azure.Commands.Security.Models.Assessments;
using Microsoft.Azure.Commands.Security.Models.SubAssessments;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Security.Cmdlets.SubAssessments
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecuritySubAssessment", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecuritySubAssessment))]
    public class GetSecuritySubAssessment : SecurityCenterCmdletBase
    {
        private const int MaxItemsToFetch = 20000;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssessedResourceId)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssessmentsName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssessmentsName)]
        [ValidateNotNullOrEmpty]
        public string AssessmentName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.AssessedResourceId)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.AssessedResourceId)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdScope, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssessedResourceId)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssessedResourceId)]
        [ValidateNotNullOrEmpty]
        public string AssessedResourceId { get; set; }

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

                    var assessments = SecurityCenterClient.SubAssessments.ListAllWithHttpMessagesAsync(AssessedResourceId ?? $"subscriptions/{DefaultContext.Subscription.Id}").GetAwaiter().GetResult().Body;
                    var psAssessments = assessments.ConvertToPSType();
                    WriteObject(psAssessments, enumerateCollection: true);
                    fetchedItems += psAssessments.Count;
                    nextLink = assessments?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && fetchedItems < MaxItemsToFetch)
                    {
                        assessments = SecurityCenterClient.SubAssessments.ListAllNextWithHttpMessagesAsync(nextLink).GetAwaiter().GetResult().Body;
                        psAssessments = assessments.ConvertToPSType();
                        WriteObject(psAssessments, enumerateCollection: true);
                        fetchedItems += psAssessments.Count;
                        nextLink = assessments?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.ResourceIdScope:
                    fetchedItems = 0;
                    nextLink = null;

                    assessments = SecurityCenterClient.SubAssessments.ListWithHttpMessagesAsync(AssessedResourceId ?? $"subscriptions/{DefaultContext.Subscription.Id}", AssessmentName).GetAwaiter().GetResult().Body;
                    psAssessments = assessments.ConvertToPSType();
                    WriteObject(psAssessments, enumerateCollection: true);
                    fetchedItems += psAssessments.Count;
                    nextLink = assessments?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && fetchedItems < MaxItemsToFetch)
                    {
                        assessments = SecurityCenterClient.SubAssessments.ListNextWithHttpMessagesAsync(nextLink).GetAwaiter().GetResult().Body;
                        psAssessments = assessments.ConvertToPSType();
                        WriteObject(psAssessments, enumerateCollection: true);
                        fetchedItems += psAssessments.Count;
                        nextLink = assessments?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.SubscriptionLevelResource:
                case ParameterSetNames.ResourceIdLevelResource:
                    var assessment = SecurityCenterClient.SubAssessments.GetWithHttpMessagesAsync(AssessedResourceId ?? $"subscriptions/{DefaultContext.Subscription.Id}", AssessmentName, Name).GetAwaiter().GetResult().Body;
                    WriteObject(assessment.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    assessment = SecurityCenterClient.SubAssessments.GetWithHttpMessagesAsync(AzureIdUtilities.GetExtendedResourceId(ResourceId), AzureIdUtilities.GetAssessmentResourceName(ResourceId), AzureIdUtilities.GetResourceName(ResourceId)).GetAwaiter().GetResult().Body;
                    WriteObject(assessment.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
