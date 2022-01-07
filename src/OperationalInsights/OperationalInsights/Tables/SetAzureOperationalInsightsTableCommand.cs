﻿// ----------------------------------------------------------------------------------
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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsTable", SupportsShouldProcess = true, DefaultParameterSetName = ByWorkspaceName), OutputType(typeof(PSWorkspace))]
    public class SetAzureOperationalInsightsTableCommand : OperationalInsightsBaseCmdlet
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

            if (ShouldProcess(TableName, $"Update Table: {TableName}, in workspace: {WorkspaceName}, resource group: {ResourceGroupName}"))
            {
                WriteObject(OperationalInsightsClient.UpdatePSTable(tableSetProperties), true);
            }
        }
    }
}
