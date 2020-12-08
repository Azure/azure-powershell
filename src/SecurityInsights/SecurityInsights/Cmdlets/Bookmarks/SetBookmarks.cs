﻿// ----------------------------------------------------------------------------------
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

using System.Management.Automation;
using Microsoft.Azure.Commands.SecurityInsights;
using Microsoft.Azure.Commands.SecurityInsights.Common;
using Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;
using System;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Commands.SecurityInsights.Models.Actions;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Bookmarks
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelBookmark", DefaultParameterSetName = ParameterSetNames.BookmarkId, SupportsShouldProcess = true), OutputType(typeof(PSSentinelBookmark))]
    public class SetBookmarks : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty] 
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty] 
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = true, HelpMessage = ParameterHelpMessages.BookmarkId)]
        public string BookmarkId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = true, HelpMessage = ParameterHelpMessages.Etag)]
        public string Etag { get; set; }
        
        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = true, HelpMessage = ParameterHelpMessages.BookmarkDisplayName)]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.IncidentInfo)] 
        public PSSentinelBookmarkIncidentInfo IncidentInfo { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = false, HelpMessage = ParameterHelpMessages.Labels)] 
        public IList<string> Label { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = false, HelpMessage = ParameterHelpMessages.Notes)] 
        public string Notes { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = true, HelpMessage = ParameterHelpMessages.BookmarkQuery)]
        public string Query { get; set; }
        
        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = false, HelpMessage = ParameterHelpMessages.QueryResult)]
        public string QueryResult { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSSentinelBookmark InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.BookmarkId:
                    break;
                case ParameterSetNames.InputObject:
                    BookmarkId = InputObject.Name;
                    Etag = InputObject.Etag;
                    WorkspaceName = AzureIdUtilities.GetWorkspaceName(InputObject.Id);
                    ResourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    DisplayName = InputObject.DisplayName;
                    if (InputObject.IncidentInfo.IncidentId != null) { IncidentInfo = InputObject.IncidentInfo; }
                    Label = InputObject.Labels;
                    Notes = InputObject.Notes;
                    Query = InputObject.Query;
                    QueryResult = InputObject.QueryResult;
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            var name = BookmarkId;

            Bookmark bookmark = new Bookmark
            {
                Etag = Etag,
                DisplayName = DisplayName,
                IncidentInfo = IncidentInfo?.CreatePSType(),
                Labels = Label,
                Notes = Notes,
                Query = Query,
                QueryResult = QueryResult
            };
            
            if (ShouldProcess(name, VerbsCommon.Set))
            {
                var outputbookmark = SecurityInsightsClient.Bookmarks.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, bookmark);

                WriteObject(outputbookmark.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}
