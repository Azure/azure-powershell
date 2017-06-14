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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.Get, Constants.SavedSearch), OutputType(typeof(PSSearchListSavedSearchResponse), typeof(PSSearchGetSavedSearchResponse))]
    public class GetAzureOperationalInsightsSavedSearchCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The workspace name.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The saved search id.")]
        [ValidateNotNullOrEmpty]
        public string SavedSearchId { get; set; }

        protected override void ProcessRecord()
        {
            if (SavedSearchId != null)
            {
                WriteObject(OperationalInsightsClient.GetSavedSearch(ResourceGroupName, WorkspaceName, SavedSearchId), true);
            }
            else
            {
                WriteObject(OperationalInsightsClient.GetSavedSearches(ResourceGroupName, WorkspaceName), true);
            }
        }

    }
}
