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
using Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.IotSecuritySolutions
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecuritySolution", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSIotSecuritySolution))]
    public class GetIotSecuritySolution : SecurityCenterCmdletBase
    {
        private const int MaxSolutionssToFetch = 1500;

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }
        
        public override void ExecuteCmdlet()
        {
            int numberOfFetchedSolutions = 0;
            string nextLink = null;
            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionScope:
                    var securitySolutions = SecurityCenterClient.IotSecuritySolution.ListBySubscriptionWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                    var PSTypeIotSecuritySolutions = securitySolutions?.ConvertToPSType();
                    WriteObject(PSTypeIotSecuritySolutions, enumerateCollection: true);
                    numberOfFetchedSolutions += PSTypeIotSecuritySolutions.Count;
                    nextLink = securitySolutions?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedSolutions < MaxSolutionssToFetch)
                    {
                        securitySolutions = SecurityCenterClient.IotSecuritySolution.ListBySubscriptionNextWithHttpMessagesAsync(securitySolutions.NextPageLink).GetAwaiter().GetResult().Body;
                        PSTypeIotSecuritySolutions = securitySolutions?.ConvertToPSType();
                        WriteObject(PSTypeIotSecuritySolutions, enumerateCollection: true);
                        numberOfFetchedSolutions += PSTypeIotSecuritySolutions.Count;
                        nextLink = securitySolutions?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.ResourceGroupScope:
                    securitySolutions = SecurityCenterClient.IotSecuritySolution.ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName).GetAwaiter().GetResult().Body;
                    PSTypeIotSecuritySolutions = securitySolutions?.ConvertToPSType();
                    WriteObject(PSTypeIotSecuritySolutions, enumerateCollection: true);
                    numberOfFetchedSolutions += PSTypeIotSecuritySolutions.Count;
                    nextLink = securitySolutions?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedSolutions < MaxSolutionssToFetch)
                    {
                        securitySolutions = SecurityCenterClient.IotSecuritySolution.ListByResourceGroupNextWithHttpMessagesAsync(securitySolutions.NextPageLink).GetAwaiter().GetResult().Body;
                        PSTypeIotSecuritySolutions = securitySolutions?.ConvertToPSType();
                        WriteObject(PSTypeIotSecuritySolutions, enumerateCollection: true);
                        numberOfFetchedSolutions += PSTypeIotSecuritySolutions.Count;
                        nextLink = securitySolutions?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.ResourceGroupLevelResource:
                    var securitySolution = SecurityCenterClient.IotSecuritySolution.GetWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                    WriteObject(securitySolution?.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    securitySolution = SecurityCenterClient.IotSecuritySolution.GetWithHttpMessagesAsync(AzureIdUtilities.GetResourceGroup(ResourceId), AzureIdUtilities.GetResourceName(ResourceId)).GetAwaiter().GetResult().Body;
                    WriteObject(securitySolution?.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
