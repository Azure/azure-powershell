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
using Microsoft.Azure.Commands.Security.Models.AssessmentMetadata;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Cmdlets.AssessmentMetadata
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAssessmentMetadata", DefaultParameterSetName = ParameterSetNames.SubscriptionLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSSecurityAssessmentMetadata))]
    public class SetSecurityAssessmentMetadata : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.DisplayName)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Description)]
        public string Description { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.RemediationDescription)]
        public string RemediationDescription { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Severity)]
        public string Severity { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, VerbsCommon.Set))
            {
                var metadata = new SecurityAssessmentMetadata(displayName: DisplayName, severity: Severity, assessmentType: "CustomerManaged", description: Description, remediationDescription: RemediationDescription);
                var result = SecurityCenterClient.AssessmentsMetadata.CreateInSubscriptionWithHttpMessagesAsync(Name, metadata).GetAwaiter().GetResult().Body;

                WriteObject(result.ConvertToPSType(), enumerateCollection: true); 
            }
        }
    }
}
