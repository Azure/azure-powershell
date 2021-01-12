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
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Rest.Azure;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Assessments
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecuritySecureScoreControl", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecuritySecureScore))]
    public class GetSecureScoreControl : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            IPage<SecureScoreControlDetails> secureScoreControls;
            int fetchedItems = 0;
            string nextLink;
            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionScope:
                    secureScoreControls = SecurityCenterClient.SecureScoreControls.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                    var psSecureScoreControls = secureScoreControls.ConvertToPSType();
                    WriteObject(psSecureScoreControls, enumerateCollection: true);
                    fetchedItems += psSecureScoreControls.Count;
                    nextLink = secureScoreControls?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink))
                    {
                        secureScoreControls = SecurityCenterClient.SecureScoreControls.ListNextWithHttpMessagesAsync(nextLink).GetAwaiter().GetResult().Body;
                        psSecureScoreControls = secureScoreControls.ConvertToPSType();
                        WriteObject(psSecureScoreControls, enumerateCollection: true);
                        fetchedItems += psSecureScoreControls.Count;
                        nextLink = secureScoreControls?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.SubscriptionLevelResource:
                    secureScoreControls = SecurityCenterClient.SecureScoreControls.ListBySecureScoreWithHttpMessagesAsync(Name).GetAwaiter().GetResult().Body;
                    psSecureScoreControls = secureScoreControls.ConvertToPSType();
                    WriteObject(psSecureScoreControls, enumerateCollection: true);
                    fetchedItems += psSecureScoreControls.Count;
                    nextLink = secureScoreControls?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink))
                    {
                        secureScoreControls = SecurityCenterClient.SecureScoreControls.ListBySecureScoreNextWithHttpMessagesAsync(nextLink).GetAwaiter().GetResult().Body;
                        psSecureScoreControls = secureScoreControls.ConvertToPSType();
                        WriteObject(psSecureScoreControls, enumerateCollection: true);
                        fetchedItems += psSecureScoreControls.Count;
                        nextLink = secureScoreControls?.NextPageLink;
                    }
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
