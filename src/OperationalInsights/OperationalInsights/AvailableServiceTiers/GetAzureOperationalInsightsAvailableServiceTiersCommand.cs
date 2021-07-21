using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights.AvailableServiceTiers
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsAvailableServiceTiers"), OutputType(typeof(PSAvailableServiceTiers))]
    public class GetAzureOperationalInsightsAvailableServiceTiersCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the workspace that contains the table.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(OperationalInsightsClient.ListPSAvailableServiceTiers(ResourceGroupName, WorkspaceName));
        }
    }
}
