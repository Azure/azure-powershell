using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
//using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights.Tables
{

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsTable", DefaultParameterSetName = ByWorkspaceName), OutputType(typeof(PSWorkspace))]
    class SetAzureOperationalInsightsTableCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the workspace that will contain the storage insight.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The table name.")]
        [ValidateNotNullOrEmpty]
        public string TableName { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The table data retention in days.between 30 and 730. Setting this property to null will default to the workspace retention")]
        [ValidateNotNullOrEmpty]
        public int? RetentionInDays { get; set; }

        public override void ExecuteCmdlet()
        {
            var tableSetProperties = new UpdatePSTableParameters()
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = WorkspaceName,
                TableName = TableName,
                RetentionInDays = RetentionInDays,
                //IsTroubleshootEnabled = IsTroubleshootEnabled,
            };
            //will return list of tables - with one table if get table is used - many if list is used
            WriteObject(OperationalInsightsClient.UpdatePSTable(tableSetProperties), true);
        }
    }
}
