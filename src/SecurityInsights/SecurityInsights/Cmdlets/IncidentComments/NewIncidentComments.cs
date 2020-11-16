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
using Microsoft.Azure.Commands.SecurityInsights.Models.IncidentComments;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;
using System;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.IncidentsComments
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelIncidentComment", DefaultParameterSetName = ParameterSetNames.IncidentCommentId), OutputType(typeof(PSSentinelIncidentComment))]
    public class NewBookmarks : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.IncidentCommentId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty] 
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentCommentId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty] 
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentCommentId, Mandatory = true, HelpMessage = ParameterHelpMessages.IncidentId)]
        [ValidateNotNullOrEmpty]
        public string IncidentId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentCommentId, Mandatory = false, HelpMessage = ParameterHelpMessages.IncidentCommentId)]
        public string IncidentCommentId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BookmarkId, Mandatory = true, HelpMessage = ParameterHelpMessages.Message)] 
        public string Message { get; set; }
       
        public override void ExecuteCmdlet()
        {
            if (IncidentCommentId == null)
            {
                IncidentCommentId = Guid.NewGuid().ToString();
            }

            var name = IncidentCommentId;

            if (ShouldProcess(name, VerbsCommon.Set))
            {
                var outputIncidentCommnet = SecurityInsightsClient.IncidentComments.CreateCommentWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, IncidentId, name, Message).GetAwaiter().GetResult().Body;

                WriteObject(outputIncidentCommnet, enumerateCollection: false);
            }
        }
    }
}
