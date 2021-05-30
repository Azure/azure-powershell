using Microsoft.Azure.Commands.OperationalInsights.Client;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights.DataExports
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsDataExport"), OutputType(typeof(bool))]
    public class RemoveAzureOperationalInsightsDataExportCommand : OperationalInsightsBaseCmdlet
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

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data export name.")]
        [ValidateNotNullOrEmpty]
        public string DataExportName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.DataExportName, string.Format("Delete data export: {0} for workspace: {1}", this.DataExportName, this.WorkspaceName)))
            {
                HttpStatusCode response = this.OperationalInsightsClient.DeleteDataExports(this.ResourceGroupName, this.WorkspaceName, this.DataExportName);
                WriteObject(true);
            }
        }
    }
}
