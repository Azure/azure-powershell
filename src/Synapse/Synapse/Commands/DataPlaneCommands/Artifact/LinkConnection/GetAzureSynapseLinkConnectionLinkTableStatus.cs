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

using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.LinkConnectionLinkTableStatus,
        DefaultParameterSetName = GetByName)]
    [OutputType(typeof(PSLinkConnectionQueryTableStatus))]
    public class GetAzureSynapseLinkConnectionLinkTableStatus : SynapseArtifactsCmdletBase
    {
        private const string GetByName = "GetByName";
        private const string GetByObject = "GetByObject";
        private const string GetByInputObject = "GetByInputObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByName,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByObject,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionName)]
        public string LinkConnectionName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.MaxSegmentCount)]
        [ValidateNotNullOrEmpty]
        public int MaxSegmentCount { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByInputObject,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionObject)]
        [ValidateNotNull]
        public PSLinkConnectionResource InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.LinkTableContinuationToken)]
        [ValidateNotNullOrEmpty]
        public object ContinuationToken { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.WorkspaceName = this.InputObject.WorkspaceName;
                this.LinkConnectionName = this.InputObject.Name;
            }

            var queryTableStatusRequest = new QueryTableStatusRequest
            {
                MaxSegmentCount = this.MaxSegmentCount
            };

            if (this.IsParameterBound(c => c.ContinuationToken))
            {
                queryTableStatusRequest.ContinuationToken = this.ContinuationToken;
            }
            
            var linkTablesStatus = new PSLinkConnectionQueryTableStatus(SynapseAnalyticsClient.QueryTableStatus(this.LinkConnectionName, queryTableStatusRequest));

            WriteObject(linkTablesStatus, true);
        }
    }
}
