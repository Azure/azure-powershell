using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.WorkspacePurge
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsWorkspace", SupportsShouldProcess = true), OutputType(typeof(PSWorkspacePurgeStatusResponse))]
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
            
            //var tags = new Hashtable();
            //tags.Add(key: "Group", value: "Computer");

            //PSSavedSearchParameters parameters = new PSSavedSearchParameters(
            //    resourceGroupName: ResourceGroupName,
            //    workspaceName: WorkspaceName,
            //    savedSearchId: SavedSearchId,
            //    category: Category,
            //    displayName: DisplayName,
            //    query: Query,
            //    version: Version,
            //    functionAlias: null,
            //    functionParameter: null,
            //    eTag: string.Empty,
            //    tags: tags
            //    );
                
            WriteObject(OperationalInsightsClient.GetPurgeWorksaceStatus(ResourceGroupName, WorkspaceName, PurgeId));
            
        }
    }
}
