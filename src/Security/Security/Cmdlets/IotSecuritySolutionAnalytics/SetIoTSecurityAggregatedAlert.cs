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
using Microsoft.Azure.Management.Security;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.IotSecuritySolutionAnalytics
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecurityAnalyticsAggregatedAlerts", DefaultParameterSetName = ParameterSetNames.SolutionLevelResource), OutputType(typeof(bool))]
    public class SetIoTSecurityAggregatedAlert : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SolutionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SolutionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.SolutionName)]
        [ValidateNotNullOrEmpty]
        public string SolutionName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SolutionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.SolutionLevelResource:
                    if (ShouldProcess(Name, VerbsCommon.Set))
                    {
                        SecurityCenterClient.IotSecuritySolutionsAnalyticsAggregatedAlert.DismissWithHttpMessagesAsync(ResourceGroupName, SolutionName, Name).GetAwaiter().GetResult();
                    }
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
