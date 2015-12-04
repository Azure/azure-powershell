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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.Get, Constants.SearchResult), OutputType(typeof(PSSearchGetSearchResultResponse))]
    public class GetAzureOperationalInsightsSearchResultCommand : OperationalInsightsBaseCmdlet
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
        public int Top { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Skip search parameter.")]
        [ValidateNotNullOrEmpty]
        public int Skip { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The pre highlight search parameter.")]
        [ValidateNotNullOrEmpty]
        public string PreHighlight { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The post highlight search parameter.")]
        [ValidateNotNullOrEmpty]
        public string PostHighlight { get; set; }

        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The include archive search parameter.")]
        [ValidateNotNullOrEmpty]
        public bool IncludeArchive { get; set; }

        [Parameter(Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The query search parameter.")]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }

        [Parameter(Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The start search parameter.")]
        [ValidateNotNullOrEmpty]
        public DateTime? Start { get; set; }

        [Parameter(Position = 9, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The end search parameter.")]
        [ValidateNotNullOrEmpty]
        public DateTime? End { get; set; }

        [Parameter(Position = 10, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The facet field search parameter.")]
        [ValidateNotNullOrEmpty]
        public IList<string> FacetField { get; set; }

        [Parameter(Position = 10, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The facet limit search parameter.")]
        [ValidateNotNullOrEmpty]
        public int FacetLimit { get; set; }

        [Parameter(Position = 11, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The facet mincount search parameter.")]
        [ValidateNotNullOrEmpty]
        public int FacetMincount { get; set; }

        [Parameter(Position = 12, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The facet's range field of the search parameters.")]
        [ValidateNotNullOrEmpty]
        public IList<string> FacetRangeField { get; set; }

        [Parameter(Position = 13, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The facet's range start of the search parameters.")]
        [ValidateNotNullOrEmpty]
        public DateTime? FacetRangeStart { get; set; }

        [Parameter(Position = 14, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The facet's range end of the search parameters.")]
        [ValidateNotNullOrEmpty]
        public DateTime? FacetRangeEnd { get; set; }

        [Parameter(Position = 15, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The facet's range gap of the search parameters.")]
        [ValidateNotNullOrEmpty]
        public string FacetRangeGap { get; set; }

        protected override void ProcessRecord()
        {
            PSHighlight highlight = new PSHighlight()
            {
                Pre = PreHighlight,
                Post = PostHighlight
            };
            PSRange range = new PSRange()
            {
                Field = FacetRangeField,
                Start = FacetRangeStart,
                End = FacetRangeEnd,
                Gap = FacetRangeGap
            };
            PSFacet facet = new PSFacet()
            {
                Field = FacetField,
                Limit = FacetLimit,
                Mincount = FacetMincount,
                Range = range
            };
            PSSearchGetSearchResultParameters parameters = new PSSearchGetSearchResultParameters()
            {
                Top = Top,
                Skip = Skip,
                Highlight = highlight,
                IncludeArchive = IncludeArchive,
                Query = Query,
                Start = Start,
                End = End,
                Facet = facet
            };

            WriteObject(OperationalInsightsClient.GetSearchResult(ResourceGroupName, WorkspaceName, parameters), true);
        }

    }
}
