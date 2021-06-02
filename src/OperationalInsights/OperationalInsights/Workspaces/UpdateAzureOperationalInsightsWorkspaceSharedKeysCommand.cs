using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights.Workspaces
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsWorkspaceSharedKey", SupportsShouldProcess = true), OutputType(typeof(PSWorkspaceKeys))]
    public class UpdateAzureOperationalInsightsWorkspaceSharedKeysCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The workspace name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, $"Regerate workspace:{Name} shared keys"))
            {
                WriteObject(OperationalInsightsClient.UpdateWorkspaceKeys(ResourceGroupName, Name), true);
            }
        }
    }
}
