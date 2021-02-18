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
using Microsoft.Azure.Commands.SecurityCenter.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Assessments
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAssessment", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecurityAssessment))]
    public class GetSecurityAssessment : SecurityCenterCmdletBase
    {
        private const int MaxItemsToFetch = 20000;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssessedResourceId)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssessedResourceId)]
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

                    var assessments = SecurityCenterClient.Assessments.ListWithHttpMessagesAsync($"/subscriptions/{DefaultContext.Subscription.Id}").GetAwaiter().GetResult().Body;
                    var psAssessments = assessments.ConvertToPSType();
                    WriteObject(psAssessments, enumerateCollection: true);
                    fetchedItems += psAssessments.Count;
                    nextLink = assessments?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && fetchedItems < MaxItemsToFetch)
                    {
                        assessments = SecurityCenterClient.Assessments.ListNextWithHttpMessagesAsync(nextLink).GetAwaiter().GetResult().Body;
                        psAssessments = assessments.ConvertToPSType();
                        WriteObject(psAssessments, enumerateCollection: true);
                        fetchedItems += psAssessments.Count;
                        nextLink = assessments?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.SubscriptionLevelResource:
                case ParameterSetNames.ResourceIdScope:
                    var assessment = SecurityCenterClient.Assessments.GetWithHttpMessagesAsync(AssessedResourceId ?? $"subscriptions/{DefaultContext.Subscription.Id}", Name).GetAwaiter().GetResult().Body;
                    WriteObject(assessment.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    assessment = SecurityCenterClient.Assessments.GetWithHttpMessagesAsync(AzureIdUtilities.GetExtendedResourceId(ResourceId), AzureIdUtilities.GetResourceName(ResourceId)).GetAwaiter().GetResult().Body;
                    WriteObject(assessment.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
