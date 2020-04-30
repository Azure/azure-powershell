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
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Azure.Management.Security;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.IotSecuritySolutionAnalytics
{
    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecurityAnalyticsAggregatedAlert", DefaultParameterSetName = ParameterSetNames.SolutionLevelResource, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class DisableIoTSecurityAggregatedAlert : SecurityCenterCmdletBase
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

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSIoTSecurityAggregatedAlert InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.SolutionLevelResource:
                    break;
                case ParameterSetNames.ResourceId:
                    ResourceGroupName = AzureIdUtilities.GetResourceGroup(ResourceId);
                    SolutionName = AzureIdUtilities.GetIotSolutionResourceName(ResourceId);
                    var idParts = ResourceId.Split('/');
                    if (idParts.Length > 2)
                    {
                        Name = $"{idParts[idParts.Length - 2]}/{idParts[idParts.Length - 1]}";
                    }
                    else
                    {
                        throw new ArgumentException("Invalid format of the resource identifier.", "ResourceId");
                    }
                    break;
                case ParameterSetNames.InputObject:
                    ResourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    SolutionName = AzureIdUtilities.GetIotSolutionResourceName(InputObject.Id);
                    Name = AzureIdUtilities.GetResourceName(InputObject.Name);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            if (ShouldProcess(Name, VerbsCommon.Set))
            {
                SecurityCenterClient.IotSecuritySolutionsAnalyticsAggregatedAlert.DismissWithHttpMessagesAsync(ResourceGroupName, SolutionName, Name).GetAwaiter().GetResult();
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
