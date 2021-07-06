using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.OperationalInsights.Models.WorkspacePurge;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.WorkspacePurge
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsPurgeWorkspace", SupportsShouldProcess = true), OutputType(typeof(PSWorkspacePurgeResponse))]
    public class NewAzureOperationalInsightsWorkspacePurgeCommand : OperationalInsightsBaseCmdlet
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

        public string Column { get; set; } // must have
        public string OperatorProperty { get; set; } // must have
        public object Value { get; set; }
        public string Key { get; set; }
        public string Table { get; set; }
        public IList<PSWorkspacePurgeBodyFilters> Filters { get; set; }//TODO set so that it couldbe passed ia psh as object

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            IList<WorkspacePurgeBodyFilters> filters = new List<WorkspacePurgeBodyFilters>();
            filters.Add(new WorkspacePurgeBodyFilters(Column, OperatorProperty, Value, Key));
            //(string column = null, string operatorProperty = null, object value = null, string key = null);
            var parameters = new PSWorkspacePurgeBody(filters, Table);

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

            if (ShouldProcess(WorkspaceName, $"Purges data in an Log Analytics workspace: {WorkspaceName}, resource group: {ResourceGroupName}"))
            {
                WriteObject(OperationalInsightsClient.PurgeWorksace(ResourceGroupName, WorkspaceName, parameters, ConfirmAction, force: Force));
            }
        }
    }
}
