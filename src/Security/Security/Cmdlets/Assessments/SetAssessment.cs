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

using System.Collections.Generic;
using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.AssessmentMetadata;
using Microsoft.Azure.Commands.Security.Models.Assessments;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Assessments
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAssessment", DefaultParameterSetName = ParameterSetNames.SubscriptionLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSSecurityAssessment))]
    public class SetSecurityAssessment : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.AssessedResourceId)]
        [ValidateNotNullOrEmpty]
        public string AssessedResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.StatusCode)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.StatusCode)]
        [ValidateNotNullOrEmpty]
        public string StatusCode { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.StatusCause)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.StatusCause)]
        [ValidateNotNullOrEmpty]
        public string StatusCause { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.StatusDescription)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.StatusDescription)]
        [ValidateNotNullOrEmpty]
        public string StatusDescription { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.AdditionalData)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.AdditionalData)]
        public Dictionary<string,string> AdditionalData { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, VerbsCommon.Set))
            {
                var status = new AssessmentStatus(StatusCode, StatusCause, StatusDescription);
                var resourceDetails = new AzureResourceDetails();
                var assesssment = new SecurityAssessment(resourceDetails: resourceDetails, status: status, additionalData: AdditionalData);
                var result = SecurityCenterClient.Assessments.CreateOrUpdateWithHttpMessagesAsync(AssessedResourceId ?? $"/subscriptions/{DefaultContext.Subscription.Id}", Name, assesssment).GetAwaiter().GetResult().Body;

                WriteObject(result.ConvertToPSType(), enumerateCollection: true); 
            }
        }
    }
}
