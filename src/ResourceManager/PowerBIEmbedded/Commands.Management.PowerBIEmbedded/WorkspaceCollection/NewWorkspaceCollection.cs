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

using System.Management.Automation;
using Microsoft.Azure.Commands.Management.PowerBIEmbedded.Models;
using Microsoft.Azure.Commands.Management.PowerBIEmbedded.Properties;
using Microsoft.Azure.Management.PowerBIEmbedded;
using Microsoft.Azure.Management.PowerBIEmbedded.Models;

namespace Microsoft.Azure.Commands.Management.PowerBIEmbedded.WorkspaceCollection
{
    [Cmdlet(VerbsCommon.New, Nouns.WorkspaceCollection, SupportsShouldProcess = true), OutputType(typeof(PSWorkspaceCollection))]
    public class NewWorkspaceCollection : WorkspaceCollectionBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Workspace Collection Name.")]
        [Alias("Name", "ResourceName")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceCollectionName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            var description = string.Format(Resources.NewWorkspaceCollectionDescription, this.WorkspaceCollectionName);
            var warning = string.Format(Resources.NewWorkspaceCollectionWarning, this.WorkspaceCollectionName);

            if (!ShouldProcess(description, warning, Resources.ShouldProcessCaption))
            {
                return;
            }

            // TODO: This will need to be udpated to params once we support multiple locations / skus
            var createWorkspaceRequest = new CreateWorkspaceCollectionRequest
            {
                Location = this.Location
            };

            var workspace = this.PowerBIClient.WorkspaceCollections.Create(
                this.ResourceGroupName,
                this.WorkspaceCollectionName,
                createWorkspaceRequest);

            this.WriteWorkspaceCollection(workspace);
        }
    }
}
