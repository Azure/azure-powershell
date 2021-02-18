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
using Microsoft.Azure.Management.Security.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.IotSecuritySolutions
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecuritySolution", DefaultParameterSetName = ParameterSetNames.ResourceGroupLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSIotSecuritySolution))]
    public class UpdateIotSecuritySolution : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSIotSecuritySolution InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.Tags)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.Tags)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Tags)]
        public System.Collections.Hashtable Tag { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.UserDefinedResources)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.UserDefinedResources)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.UserDefinedResources)]
        public PSUserDefinedResources UserDefinedResource { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.RecommendationsConfiguration)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.RecommendationsConfiguration)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.RecommendationsConfiguration)]
        public PSRecommendationConfiguration[] RecommendationsConfiguration { get; set; }

        public override void ExecuteCmdlet()
        {
            var name = Name;
            var resourceGroupName = ResourceGroupName;

            switch (ParameterSetName)
            {
                case ParameterSetNames.ResourceGroupLevelResource:
                    break;
                case ParameterSetNames.ResourceId:
                    Name = AzureIdUtilities.GetResourceName(ResourceId);
                    ResourceGroupName = AzureIdUtilities.GetResourceGroup(ResourceId);
                    break;
                case ParameterSetNames.InputObject:
                    Name = AzureIdUtilities.GetResourceName(InputObject.Id);
                    ResourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    RecommendationsConfiguration = RecommendationsConfiguration ?? ((List<PSRecommendationConfiguration>)InputObject.RecommendationsConfiguration).ToArray();
                    Tag = Tag ?? new Hashtable((IDictionary)(InputObject.Tags));
                    UserDefinedResource = UserDefinedResource ?? GetValidUserDefinedResources(InputObject.UserDefinedResources);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            UpdateIotSecuritySolutionData solutionData = new UpdateIotSecuritySolutionData(Tag?.Cast<DictionaryEntry>().ToDictionary(t => (string)t.Key, t => (string)t.Value), 
                UserDefinedResource?.CreatePSType(), 
                RecommendationsConfiguration?.CreatePSType());

            if (ShouldProcess(Name, "Update"))
            {
                var outputSolution = SecurityCenterClient.IotSecuritySolution.UpdateWithHttpMessagesAsync(ResourceGroupName, Name, solutionData).GetAwaiter().GetResult().Body;
                WriteObject(outputSolution?.ConvertToPSType(), enumerateCollection: false);
            }
        }

        private PSUserDefinedResources GetValidUserDefinedResources(PSUserDefinedResources userDefinedResources)
        {
            if (userDefinedResources != null && userDefinedResources.Validate())
            {
                return userDefinedResources;
            }
            return null;
        }
    }
}
