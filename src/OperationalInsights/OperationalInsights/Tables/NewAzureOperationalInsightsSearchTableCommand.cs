// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights.Tables
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsSearchTable", SupportsShouldProcess = true), OutputType(typeof(PSTable))]
    public class NewAzureOperationalInsightsSearchTableCommand : OperationalInsightsBaseCmdlet
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

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The table name. For Search table the name should end with '_SRCH'")]
        [ValidateNotNullOrEmpty]
        public string TableName { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The table retention in days, between 4 and 730. Setting this property to -1 will default to the workspace retention")]
        [ValidateNotNullOrEmpty]
        public int? RetentionInDays { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The table total retention in days, between 4 and 2555. Setting this property to -1 will default to table retention.")]
        [ValidateNotNullOrEmpty]
        public int? TotalRetentionInDays { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Search job query.")]
        [ValidateNotNullOrEmpty]
        public string SearchQuery { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The timestamp to start the search from (UTC).")]
        [ValidateNotNullOrEmpty]
        public string StartSearchTime { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The timestamp to end the search by (UTC).")]
        [ValidateNotNullOrEmpty]
        public string EndSearchTime { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Limit the search job to return up to specified number of rows.")]
        [ValidateNotNullOrEmpty]
        public int? Limit { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            var tableSetProperties = new PSSearchTable(
                resourceGroupName: ResourceGroupName,
                workspaceName: WorkspaceName,
                tableName: TableName,
                query: SearchQuery,
                startSearchTime: StartSearchTime,
                endSearchTime: EndSearchTime,
                limit: Limit);

            if (ShouldProcess(TableName, $"Update Table: {TableName}, in workspace: {WorkspaceName}, resource group: {ResourceGroupName}"))
            {
                WriteObject(OperationalInsightsClient.CreateSearchTable(tableSetProperties), true);
            }
        }
    }
}
