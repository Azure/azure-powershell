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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecurityAnalytics", DefaultParameterSetName = ParameterSetNames.SolutionScope), OutputType(typeof(PSIotSecuritySolutionAnalytics))]
    public class GetIoTSecuritySolutionAnalytics : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SolutionScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SolutionScope, Mandatory = true, HelpMessage = ParameterHelpMessages.SolutionName)]
        [ValidateNotNullOrEmpty]
        public string SolutionName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SolutionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.IsDefualt)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Default { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Default.IsPresent)
            {
                var analytic = SecurityCenterClient.IotSecuritySolutionAnalytics.GetWithHttpMessagesAsync(ResourceGroupName, SolutionName).GetAwaiter().GetResult().Body;
                WriteObject(analytic?.ConvertToPSType(), enumerateCollection: false);
            }
            else
            {
                var analytics = SecurityCenterClient.IotSecuritySolutionAnalytics.ListWithHttpMessagesAsync(ResourceGroupName, SolutionName).GetAwaiter().GetResult().Body;
                WriteObject(analytics?.ConvertToPSType(), enumerateCollection: true);
            }
        }
    }
}
