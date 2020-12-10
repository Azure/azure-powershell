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

using System.Management.Automation;
using Microsoft.Azure.Commands.SecurityInsights;
using Microsoft.Azure.Commands.SecurityInsights.Common;
using Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;
using System;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Bookmarks
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelBookmark", DefaultParameterSetName = ParameterSetNames.BookmarkId, SupportsShouldProcess = true), OutputType(typeof(PSSentinelBookmark))]
    public class UpdateBoomarks : SecurityInsightsCmdletBase
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

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNull]
        public PSSentinelBookmark InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.BookmarkDisplayName)]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.IncidentInfo)]
        public PSSentinelBookmarkIncidentInfo IncidentInfo { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Labels)]
        public IList<string> Label { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Notes)]
        public string Note { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.BookmarkQuery)]
        public string Query { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.QueryResult)]
        public string QueryResult { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                this.WorkspaceName = AzureIdUtilities.GetWorkspaceName(InputObject.Id);
                this.BookmarkId = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = AzureIdUtilities.GetWorkspaceName(this.ResourceId);
                this.BookmarkId = resourceIdentifier.ResourceName;
            }

            PSSentinelBookmark bookmark = null;
            try
            {
                bookmark = this.SecurityInsightsClient.Bookmarks.Get(this.ResourceGroupName, this.WorkspaceName, this.BookmarkId).ConvertToPSType();
            }
            catch
            {
                bookmark = null;
            }

            if (bookmark == null)
            {
                throw new Exception(string.Format("A Bookmark with BookmarkId '{0}' in resource group '{1}' under parent workspace '{2}' does not exist. Please use New-AzSentinelBookmark to create a Bookmark with these properties.", this.BookmarkId, this.ResourceGroupName, this.WorkspaceName));
            }

            var updatedbookmark = new PSSentinelBookmark();
            updatedbookmark.Etag = bookmark.Etag;
            updatedbookmark.DisplayName = this.IsParameterBound(c => c.DisplayName) ? this.DisplayName : bookmark.DisplayName;
            //bookmark.IncidentInfo = this.IsParameterBound(c => c.IncidentInfo) ? this.IncidentInfo : bookmark.IncidentInfo;
            updatedbookmark.Labels = this.IsParameterBound(c => c.Label) ? this.Label : bookmark.Labels;
            updatedbookmark.Notes = this.IsParameterBound(c => c.Note) ? this.Note : bookmark.Notes;
            updatedbookmark.Query = this.IsParameterBound(c => c.Query) ? this.Query : bookmark.Query;
            updatedbookmark.QueryResult = this.IsParameterBound(c => c.QueryResult) ? this.QueryResult : bookmark.QueryResult;
            

            if (this.ShouldProcess(this.BookmarkId, string.Format("Updating BookmarkID '{0}' in resource group '{1}' under workspace '{2}'.", this.BookmarkId, this.ResourceGroupName, this.WorkspaceName)))
            {
                var result = this.SecurityInsightsClient.Bookmarks.CreateOrUpdate(this.ResourceGroupName, this.WorkspaceName, this.BookmarkId, updatedbookmark.CreatePSType()).ConvertToPSType();
                WriteObject(result);
            }
        }
    }
}
