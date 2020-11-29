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
using Microsoft.Azure.Commands.SecurityCenter.Models.SecureScore;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Assessments
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecuritySecureScoreControlDefinition", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecuritySecureScoreControlDefinition))]
    public class GetGetSecureScoreControlDefinition : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionScope:
                    int fetchedItems = 0;
                    var secureScoreControlDefinitions = SecurityCenterClient.SecureScoreControlDefinitions.ListBySubscriptionWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                    var psAssessments = secureScoreControlDefinitions.ConvertToPSType();
                    WriteObject(psAssessments, enumerateCollection: true);
                    fetchedItems += psAssessments.Count;
                    string nextLink = secureScoreControlDefinitions?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink))
                    {
                        secureScoreControlDefinitions = SecurityCenterClient.SecureScoreControlDefinitions.ListBySubscriptionNextWithHttpMessagesAsync(nextLink).GetAwaiter().GetResult().Body;
                        psAssessments = secureScoreControlDefinitions.ConvertToPSType();
                        WriteObject(psAssessments, enumerateCollection: true);
                        fetchedItems += psAssessments.Count;
                        nextLink = secureScoreControlDefinitions?.NextPageLink;
                    }
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
