using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights.DataExports
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsDataExport", SupportsShouldProcess = true), OutputType(typeof(PSDataExport))]
    public class UpdateAzureOperationalInsightsDataExportCommand : OperationalInsightsBaseCmdlet
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

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "An array of tables to export, for example: [“Heartbeat, SecurityEvent”].")]
        public string[] TableNames { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The destination resource ID. This can be copied from the Properties entry of the destination resource in Azure.")]
        public string ResourceId { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "Optional. Allows to define an Event Hub name. Not applicable when destination is Storage Account.")]
        public string EventHubName { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = "Active when enabled.")]
        public bool? Enable { get; set; }


        public override void ExecuteCmdlet()
        {
            var dataExportParameters = new CreatePSDataExportParameters
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = WorkspaceName,
                DataExportName = DataExportName,
                TableNames = TableNames,
                ResourceId = ResourceId,
                EventHubName = EventHubName,
                Enable = Enable
            };

            if (ShouldProcess(DataExportName, $"Update Data export: {DataExportName}, in workspace: {WorkspaceName}, resource group: {ResourceGroupName}"))
            {
                WriteObject(this.OperationalInsightsClient.UpdateDataExport(ResourceGroupName, dataExportParameters), true);
            }
        }
    }
}
