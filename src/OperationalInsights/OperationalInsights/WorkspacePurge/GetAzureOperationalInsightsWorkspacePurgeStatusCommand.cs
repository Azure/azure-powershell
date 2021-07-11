using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.WorkspacePurge
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsPurgeWorkspaceStatus"), OutputType(typeof(PSWorkspacePurgeStatusResponse))]
    public class GetAzureOperationalInsightsWorkspacePurgeStatusCommand : OperationalInsightsBaseCmdlet
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

        [Parameter(Position = 2, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "In a purge status request, this is the Id of the operation the status of which is returned.")]
        [ValidateNotNullOrEmpty]
        public string PurgeId { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(OperationalInsightsClient.GetPurgeWorkspaceStatus(ResourceGroupName, WorkspaceName, PurgeId));
        }
    }
}
