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
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.Get, Constants.SearchResults), OutputType(typeof(PSSearchGetSearchResultsResponse))]
    public class GetAzureOperationalInsightsSearchResultsCommand : OperationalInsightsBaseCmdlet
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
            HelpMessage = "The top search parameter.")]
        [ValidateNotNullOrEmpty]
        public long Top { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The pre highlight search parameter.")]
        [ValidateNotNullOrEmpty]
        public string PreHighlight { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The post highlight search parameter.")]
        [ValidateNotNullOrEmpty]
        public string PostHighlight { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The query search parameter.")]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }

        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The start search parameter.")]
        [ValidateNotNullOrEmpty]
        public DateTime? Start { get; set; }

        [Parameter(Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The end search parameter.")]
        [ValidateNotNullOrEmpty]
        public DateTime? End { get; set; }

        [Parameter(Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true,
        HelpMessage = "If an id is given, the search results for that id are updated.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }


        protected override void ProcessRecord()
        {
            if (Id != null)
            {
                WriteObject(OperationalInsightsClient.GetSearchResultsUpdate(ResourceGroupName, WorkspaceName, Id), true);
            }
            else
            {
                PSHighlight highlight = new PSHighlight()
                {
                    Pre = PreHighlight,
                    Post = PostHighlight
                };
                PSSearchGetSearchResultsParameters parameters = new PSSearchGetSearchResultsParameters()
                {
                    Top = Top,
                    Highlight = highlight,
                    Query = Query,
                    Start = Start,
                    End = End,
                };

                WriteObject(OperationalInsightsClient.GetSearchResults(ResourceGroupName, WorkspaceName, parameters), true);
            }
        }

    }
}
