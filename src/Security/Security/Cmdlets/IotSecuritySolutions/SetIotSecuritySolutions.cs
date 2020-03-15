using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Azure.Management.Security.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.IotSecuritySolutions
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecuritySolutions", DefaultParameterSetName = ParameterSetNames.ResourceGroupLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSIotSecuritySolution))]
    public class SetIotSecuritySolutions : SecurityCenterCmdletBase
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
        public IDictionary<string, string> Tags { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Location)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.Location)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceId)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceId)]
        [ValidateNotNullOrEmpty]
        public string Workspace { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.DisplayName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.DisplayName)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.Status)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.Status)]
        public string Status { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.Export)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.Export)]
        public List<string> Export { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.DisabledDataSources)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.DisabledDataSources)]
        public List<string> DisabledDataSources { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.IotHubs)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.IotHubs)]
        [ValidateNotNullOrEmpty]
        public List<string> IotHubs { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.UserDefinedResources)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.UserDefinedResources)]
        public PSUserDefinedResources UserDefinedResources { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.RecommendationsConfiguration)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.RecommendationsConfiguration)]
        public List<PSRecommendationConfiguration> RecommendationsConfiguration { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.UnmaskedIpLoggingStatus)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.UnmaskedIpLoggingStatus)]
        public string UnmaskedIpLoggingStatus { get; set; }

        public override void ExecuteCmdlet()
        {
            var name = Name;
            var resourceGroupName = ResourceGroupName;

            switch (ParameterSetName)
            {
                case ParameterSetNames.ResourceGroupLevelResource:
                    break;
                case ParameterSetNames.ResourceId:
                    name = AzureIdUtilities.GetResourceName(ResourceId);
                    resourceGroupName = AzureIdUtilities.GetResourceGroup(ResourceId);
                    break;
                case ParameterSetNames.InputObject:
                    name = InputObject.Name;
                    resourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            IoTSecuritySolutionModel solutionModel = new IoTSecuritySolutionModel();
            if (ParameterSetName == ParameterSetNames.InputObject)
            {
                solutionModel = InputObject.CreatePSType();
            }
            else
            {
                solutionModel.Location = Location;
                solutionModel.DisabledDataSources = DisabledDataSources;
                solutionModel.DisplayName = DisplayName;
                solutionModel.Export = Export;
                solutionModel.IotHubs = IotHubs;
                solutionModel.RecommendationsConfiguration = RecommendationsConfiguration?.CreatePSType();
                solutionModel.Status = Status;
                solutionModel.Tags = Tags;
                solutionModel.UnmaskedIpLoggingStatus = UnmaskedIpLoggingStatus;
                solutionModel.UserDefinedResources = UserDefinedResources?.CreatePSType();
                solutionModel.Workspace = Workspace;
            }

            if (ShouldProcess(Name, VerbsCommon.Set))
            {
                var outputSolution = SecurityCenterClient.IotSecuritySolution.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, name, solutionModel).GetAwaiter().GetResult().Body;
                WriteObject(outputSolution.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}
