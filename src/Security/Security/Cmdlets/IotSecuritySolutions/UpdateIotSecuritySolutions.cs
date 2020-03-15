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
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecuritySolutions", DefaultParameterSetName = ParameterSetNames.ResourceGroupLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSIotSecuritySolution))]
    public class UpdateIotSecuritySolutions : SecurityCenterCmdletBase
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

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.Tags)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.Tags)]
        public Dictionary<string, string> Tags { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.UserDefinedResources)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.UserDefinedResources)]
        public PSUserDefinedResources UserDefinedResources { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.RecommendationsConfiguration)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.RecommendationsConfiguration)]
        public List<PSRecommendationConfiguration> RecommendationsConfiguration { get; set; }

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
                default:
                    throw new PSInvalidOperationException();
            }

            UpdateIotSecuritySolutionData solutionData = new UpdateIotSecuritySolutionData(Tags, UserDefinedResources?.CreatePSType(), RecommendationsConfiguration?.CreatePSType());

            if (ShouldProcess(Name, "Update"))
            {
                var outputSolution = SecurityCenterClient.IotSecuritySolution.UpdateWithHttpMessagesAsync(resourceGroupName, name, solutionData).GetAwaiter().GetResult().Body;
                WriteObject(outputSolution.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}
