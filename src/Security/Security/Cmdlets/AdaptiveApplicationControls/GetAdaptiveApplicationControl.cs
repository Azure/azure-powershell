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
using Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveApplicationControls;

namespace Microsoft.Azure.Commands.Security.Cmdlets.AdaptiveApplicationControls
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAdaptiveApplicationControl", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecurityAdaptiveApplicationControls))]
    public class GetAdaptiveApplicationControl : SecurityCenterCmdletBase
    {

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.SubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.IncludePathRecommendation)]
        [ValidateNotNullOrEmpty]
        public bool IncludePathRecommendation { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Summary)]
        [ValidateNotNullOrEmpty]
        public bool Summary { get; set; }


        public override void ExecuteCmdlet()
        {
            if (IncludePathRecommendation == true)
            {
                SecurityCenterClient.SubscriptionId = SubscriptionId ?? SecurityCenterClient.SubscriptionId;

                var adaptiveApplicationControls = SecurityCenterClient.AdaptiveApplicationControls
                    .ListWithHttpMessagesAsync(IncludePathRecommendation)
                    .GetAwaiter()
                    .GetResult()
                    .Body
                    .Value;

                WriteObject(adaptiveApplicationControls.ConvertToPSType(), enumerateCollection: true);
            }
            else if (Summary == true)
            {
                SecurityCenterClient.SubscriptionId = SubscriptionId ?? SecurityCenterClient.SubscriptionId;

                var adaptiveApplicationControls = SecurityCenterClient.AdaptiveApplicationControls
                    .ListWithHttpMessagesAsync(Summary)
                    .GetAwaiter()
                    .GetResult()
                    .Body
                    .Value;

                WriteObject(adaptiveApplicationControls.ConvertToPSType(), enumerateCollection: true);
            }
            else
            {
                SecurityCenterClient.SubscriptionId = SubscriptionId ?? SecurityCenterClient.SubscriptionId;

                var adaptiveApplicationControlss = SecurityCenterClient.AdaptiveApplicationControls
                    .ListWithHttpMessagesAsync(IncludePathRecommendation, Summary)
                    .GetAwaiter()
                    .GetResult()
                    .Body
                    .Value;

                WriteObject(adaptiveApplicationControlss.ConvertToPSType(), enumerateCollection: true);

            }
        }
    }
}
