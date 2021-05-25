using Microsoft.Azure.Commands.OperationalInsights.Client;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.OperationalInsights.DataExports
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsDataExport"), OutputType(typeof(PSDataExport))]
    public class GetAzureOperationalInsightsDataExport : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the workspace that will contain the storage insight.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data export name.")]
        [ValidateNotNullOrEmpty]
        public string DataExportName { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(this.OperationalInsightsClient.FilterPSDataExports(ResourceGroupName, WorkspaceName, DataExportName), true);
        }

    }
}
