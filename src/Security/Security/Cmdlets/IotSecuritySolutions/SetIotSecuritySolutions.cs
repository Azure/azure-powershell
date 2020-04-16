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
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecuritySolution", DefaultParameterSetName = ParameterSetNames.ResourceGroupLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSIotSecuritySolution))]
    public class SetIotSecuritySolution : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSIotSecuritySolution InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.Tags)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.Tags)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Tags)]
        public Hashtable Tag { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Location)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.Location)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Location)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceId)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceId)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Location)]
        [ValidateNotNullOrEmpty]
        public string Workspace { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.DisplayName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.DisplayName)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.DisplayName)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.Status)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.Status)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Status)]
        public string Status { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.Export)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.Export)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Export)]
        public string[] Export { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.DisabledDataSources)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.DisabledDataSources)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.DisabledDataSources)]
        public string[] DisabledDataSource { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.IotHubs)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.IotHubs)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.IotHubs)]
        [ValidateNotNullOrEmpty]
        public string[] IotHub { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.UserDefinedResources)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.UserDefinedResources)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.UserDefinedResources)]
        public PSUserDefinedResources UserDefinedResource { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.RecommendationsConfiguration)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.RecommendationsConfiguration)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.RecommendationsConfiguration)]
        public PSRecommendationConfiguration[] RecommendationsConfiguration { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.UnmaskedIpLoggingStatus)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.UnmaskedIpLoggingStatus)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.UnmaskedIpLoggingStatus)]
        public string UnmaskedIpLoggingStatus { get; set; }

        public override void ExecuteCmdlet()
        {
           switch (ParameterSetName)
            {
                case ParameterSetNames.ResourceGroupLevelResource:
                    break;
                case ParameterSetNames.ResourceId:
                    Name = AzureIdUtilities.GetResourceName(ResourceId);
                    ResourceGroupName = AzureIdUtilities.GetResourceGroup(ResourceId);
                    break;
                case ParameterSetNames.InputObject:
                    Name = InputObject.Name;
                    ResourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    Location = Location ?? InputObject.Location;
                    DisabledDataSource = DisabledDataSource ?? ((List<string>)InputObject.DisabledDataSources).ToArray();
                    DisplayName = DisplayName ?? InputObject.DisplayName;
                    Export = Export ?? ((List<string>)InputObject.Export).ToArray();
                    IotHub = IotHub ?? ((List<string>)InputObject.IotHubs).ToArray();
                    RecommendationsConfiguration = RecommendationsConfiguration ?? ((List<PSRecommendationConfiguration>)InputObject.RecommendationsConfiguration).ToArray();
                    Status = Status ?? InputObject.Status;
                    Tag = Tag ?? new Hashtable((IDictionary)(InputObject.Tags));
                    UnmaskedIpLoggingStatus = UnmaskedIpLoggingStatus ?? InputObject.UnmaskedIpLoggingStatus;
                    UserDefinedResource = UserDefinedResource ?? InputObject.UserDefinedResources;
                    Workspace = Workspace ?? InputObject.Workspace;
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            IoTSecuritySolutionModel solutionModel = new IoTSecuritySolutionModel
            {
                Location = Location,
                DisabledDataSources = DisabledDataSource,
                DisplayName = DisplayName,
                Export = Export,
                IotHubs = IotHub,
                RecommendationsConfiguration = RecommendationsConfiguration?.CreatePSType(),
                Status = Status,
                Tags = Tag?.Cast<DictionaryEntry>().ToDictionary(t => (string)t.Key, t => (string)t.Value),
                UnmaskedIpLoggingStatus = UnmaskedIpLoggingStatus,
                UserDefinedResources = UserDefinedResource?.CreatePSType(),
                Workspace = Workspace
            };
            
            if (ShouldProcess(Name, VerbsCommon.Set))
            {
                var outputSolution = SecurityCenterClient.IotSecuritySolution.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, Name, solutionModel).GetAwaiter().GetResult().Body;
                WriteObject(outputSolution?.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}
