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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecuritySecureScore", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecuritySecureScore))]
    public class GetSecureScore : SecurityCenterCmdletBase
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
                    var secureScores = SecurityCenterClient.SecureScores.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                    var psAssessments = secureScores.ConvertToPSType();
                    WriteObject(psAssessments, enumerateCollection: true);
                    fetchedItems += psAssessments.Count;
                    string nextLink = secureScores?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink))
                    {
                        secureScores = SecurityCenterClient.SecureScores.ListNextWithHttpMessagesAsync(nextLink).GetAwaiter().GetResult().Body;
                        psAssessments = secureScores.ConvertToPSType();
                        WriteObject(psAssessments, enumerateCollection: true);
                        fetchedItems += psAssessments.Count;
                        nextLink = secureScores?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.SubscriptionLevelResource:
                    var secureScore = SecurityCenterClient.SecureScores.GetWithHttpMessagesAsync(Name).GetAwaiter().GetResult().Body;
                    WriteObject(secureScore.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
