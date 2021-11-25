// ----------------------------------------------------------------------------------
//
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
using Microsoft.Azure.Management.OperationalInsights.Models;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.OperationalInsights.WorkspacePurge
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsPurgeWorkspace", DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSWorkspacePurgeResponse))]
    public class NewAzureOperationalInsightsPurgeWorkspaceCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = CreateByNameParameterSet, Mandatory = true, HelpMessage = "The resource group name.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateByObjectParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = CreateByNameParameterSet, Mandatory = true, HelpMessage = "The name of the workspace to purge.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateByObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateByNameParameterSet,
            HelpMessage = "The column of the table over which the given query should run")]
        [ValidateNotNull]
        public string Column { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateByNameParameterSet, 
            HelpMessage = "A query operator to evaluate over the provided column and value(s). Supported operators are ==, =~, in, in~, >, >=, <, <=, between, and have the same behavior as they would in a KQL query.")]
        [ValidateNotNull]
        public string OperatorProperty { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByNameParameterSet, 
            HelpMessage = "the value for the operator to function over. This can be a number (e.g., > 100), a string (timestamp >= '2017-09-01') or array of values.")]
        [ValidateNotNull]
        public object Value { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByNameParameterSet, 
            HelpMessage = "When filtering over custom dimensions, this key will be used as the name of the custom dimension.")]
        [ValidateNotNull]
        public string Key { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = "Table name from which to purge data.")]
        [ValidateNotNull]
        public string Table { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateByObjectParameterSet)]
        [ValidateNotNull]
        public PSWorkspacePurgeBody PurgeBody { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            PSWorkspacePurgeBody parameters;

            if (this.IsParameterBound(c => c.PurgeBody))
            {
                parameters = PurgeBody;
            }
            else
            {
                var filters = new List<WorkspacePurgeBodyFilters>{ new WorkspacePurgeBodyFilters(Column, OperatorProperty, Value, Key) };
                parameters = new PSWorkspacePurgeBody(filters,Table);
            }

            if (ShouldProcess(WorkspaceName, $"Purges data in a LogAnalytics workspace: {WorkspaceName}, resource group: {ResourceGroupName}"))
            {
                WriteObject(OperationalInsightsClient.PurgeWorkspace(ResourceGroupName, WorkspaceName, parameters));
            }
        }
    }
}
