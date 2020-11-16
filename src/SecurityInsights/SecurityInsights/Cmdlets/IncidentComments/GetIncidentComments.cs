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
using Microsoft.Azure.Commands.SecurityInsights.Models.IncidentComments;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.IncidentsComments
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelIncidentComment", DefaultParameterSetName = ParameterSetNames.IncidentId), OutputType(typeof(PSSentinelIncidentComment))]
    public class GetIncidentComments : SecurityInsightsCmdletBase
    {
        private const int MaxIncidentCommentsToFetch = 1500;
        
        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.IncidentCommentId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = ParameterSetNames.IncidentCommentId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.IncidentId)]
        [Parameter(ParameterSetName = ParameterSetNames.IncidentCommentId, Mandatory = true, HelpMessage = ParameterHelpMessages.IncidentId)]
        [ValidateNotNullOrEmpty]
        public string IncidentId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentCommentId, Mandatory = true, HelpMessage = ParameterHelpMessages.IncidentCommentId)]
        [ValidateNotNullOrEmpty]
        public string IncidentCommentId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            int numberOfFetchedIncidentComments = 0;
            string nextLink = null;
            switch (ParameterSetName)
            {
                case ParameterSetNames.IncidentId:
                    var incidentComments = SecurityInsightsClient.IncidentComments.ListByIncidentWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, IncidentId).GetAwaiter().GetResult().Body;
                    int incidentCommentsCount = incidentComments.Count();
                    WriteObject(incidentComments, enumerateCollection: true);
                    numberOfFetchedIncidentComments += incidentCommentsCount;
                    nextLink = incidentComments?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedIncidentComments < MaxIncidentCommentsToFetch)
                    {
                        incidentComments = SecurityInsightsClient.IncidentComments.ListByIncidentNextWithHttpMessagesAsync(incidentComments.NextPageLink).GetAwaiter().GetResult().Body;
                        incidentCommentsCount = incidentComments.Count();
                        WriteObject(incidentComments, enumerateCollection: true);
                        numberOfFetchedIncidentComments += incidentCommentsCount;
                        nextLink = incidentComments?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.IncidentCommentId:
                    var incidentComment = SecurityInsightsClient.IncidentComments.GetWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, IncidentId, IncidentCommentId).GetAwaiter().GetResult().Body;
                    WriteObject(incidentComment, enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    incidentComment = SecurityInsightsClient.IncidentComments.GetWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, AzureIdUtilities.GetIncidentName(ResourceId), AzureIdUtilities.GetIncidentCommentName(ResourceId)).GetAwaiter().GetResult().Body;
                    WriteObject(incidentComment, enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
