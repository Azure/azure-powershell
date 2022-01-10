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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsSavedSearch"), OutputType(typeof(PSSavedSearchValue))]
    public class SetAzureOperationalInsightsSavedSearchCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The workspace name.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The saved search id.")]
        [ValidateNotNullOrEmpty]
        public string SavedSearchId { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The saved search display name.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The saved search category.")]
        [ValidateNotNullOrEmpty]
        public string Category { get; set; }

        [Parameter(Position = 5, Mandatory = true, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The saved search query.")]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }

        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The saved search tags.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The saved search version.")]
        [PSDefaultValue(Help = "1", Value = 1)]
        [ValidateNotNullOrEmpty]
        public long Version { get; set; } = 1;

        [Parameter(Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ETag of the saved search.")]
        [ValidateNotNullOrEmpty]
        public string ETag { get; set; }

        [Parameter(Position = 9, Mandatory = false,
            HelpMessage = "The function alias if query serves as a function.")]
        [ValidateNotNullOrEmpty]
        public string FunctionAlias { get; set; }

        [Parameter(Position = 10, Mandatory = false,
            HelpMessage = "The optional function parameters if query serves as a function. Value should be in the following format: 'param-name1:type1 = default_value1, param-name2:type2 = default_value2'. For more examples and proper syntax please refer to https://docs.microsoft.com/en-us/azure/kusto/query/functions/user-defined-functions.")]
        [ValidateNotNull]
        [Alias("FunctionParameters")]
        public string FunctionParameter { get; set; }

        protected override void ProcessRecord()
        {
            PSSavedSearchParameters parameters = new PSSavedSearchParameters(
                resourceGroupName: ResourceGroupName,
                workspaceName: WorkspaceName,
                savedSearchId: SavedSearchId,
                category: Category,
                displayName: DisplayName,
                query: Query,
                version: Version,
                functionAlias: FunctionAlias,
                functionParameter: FunctionParameter,
                eTag: string.IsNullOrEmpty(ETag) ? PSSavedSearchParameters.EtagWildCard : ETag,
                tags: Tag);

            if (ShouldProcess(DisplayName, $"Update new saved search: {DisplayName}, in workspace: {WorkspaceName}, resource group: {ResourceGroupName}"))
            {
                WriteObject(OperationalInsightsClient.UpdateSavedSearch(parameters));
            }
        }
    }
}
