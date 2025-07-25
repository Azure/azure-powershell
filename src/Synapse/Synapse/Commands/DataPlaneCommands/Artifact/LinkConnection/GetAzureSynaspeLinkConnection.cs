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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get,ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.LinkConnection, DefaultParameterSetName = GetByName)]
    [OutputType(typeof(PSLinkConnectionResource))]
    public class GetAzureSynaspeLinkConnection: SynapseArtifactsCmdletBase
    {
        private const string GetByName = "GetByName";
        private const string GetByObject = "GetByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.LinkConnectionName)]
        [ValidateNotNullOrEmpty]
        [Alias("LinkConnectionName")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if(this.IsParameterBound(c => c.Name))
            {
                WriteObject(new PSLinkConnectionResource(SynapseAnalyticsClient.GetLinkConnection(this.Name), this.WorkspaceName));
            }
            else
            {
                var linkConnections = SynapseAnalyticsClient.GetLinkConnectionByWorkspace()
                    .Select(element => new PSLinkConnectionResource(element,this.WorkspaceName));
                WriteObject(linkConnections, true);
            }
        }

    }
}
