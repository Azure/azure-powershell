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
// ------------------------------------

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.SecurityInsights;
using Microsoft.Azure.Commands.SecurityInsights.Common;
using Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;
using Microsoft.Azure.Management.SecurityInsights;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Bookmarks
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelBookmark", DefaultParameterSetName = ParameterSetNames.WorkspaceScope), OutputType(typeof(PSSentinelBookmark))]
    public class GetBookmarks : SecurityInsightsCmdletBase
    {
        private const int MaxBookmarksToFetch = 1500;

        [Parameter(ParameterSetName = ParameterSetNames.WorkspaceScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.WorkspaceScope, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BookmarkId)]
        [ValidateNotNullOrEmpty]
        public string BookmarkId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            int numberOfFetchedBookmarks = 0;
            string nextLink = null;
            switch (ParameterSetName)
            {
                case ParameterSetNames.WorkspaceScope:
                    var bookmarks = SecurityInsightsClient.Bookmarks.List(ResourceGroupName, WorkspaceName);
                    int bookmarkscount = bookmarks.Count();
                    WriteObject(bookmarks.ConvertToPSType(), enumerateCollection: true);
                    numberOfFetchedBookmarks += bookmarkscount;
                    nextLink = bookmarks?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedBookmarks < MaxBookmarksToFetch)
                    {
                        bookmarks = SecurityInsightsClient.Bookmarks.ListNext(bookmarks.NextPageLink);
                        bookmarkscount = bookmarks.Count();
                        WriteObject(bookmarks.ConvertToPSType(), enumerateCollection: true);
                        numberOfFetchedBookmarks += bookmarkscount;
                        nextLink = bookmarks?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.BookmarkId:
                    var bookmark = SecurityInsightsClient.Bookmarks.Get(ResourceGroupName, WorkspaceName, BookmarkId);
                    WriteObject(bookmark.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    bookmark = SecurityInsightsClient.Bookmarks.Get(ResourceGroupName, WorkspaceName, AzureIdUtilities.GetResourceName(ResourceId));
                    WriteObject(bookmark.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
