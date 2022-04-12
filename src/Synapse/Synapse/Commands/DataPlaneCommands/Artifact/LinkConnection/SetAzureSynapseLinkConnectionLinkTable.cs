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
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.LinkConnectionLinkTable,
        DefaultParameterSetName = SetByName, SupportsShouldProcess = true)]
    [OutputType(typeof(void))]
    public class SetAzureSynapseLinkConnectionLinkTable : SynapseArtifactsCmdletBase
    {
        private const string SetByName = "SetByName";
        private const string SetByObject = "SetByObject";
        private const string SetByInputObject = "SetByInputObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.EditTablesRequestFile)]
        [ValidateNotNullOrEmpty]
        [Alias("File")]
        public string EditTablesRequestFile { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByName,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByObject,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionName)]
        public string LinkConnectionName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByInputObject,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionObject)]
        [ValidateNotNull]
        public PSLinkConnectionResource InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

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

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.EditingLinkConnectionLinkTables, this.LinkConnectionName, this.WorkspaceName)))
            {
                var rawJsonContent = SynapseAnalyticsClient.ReadJsonFileContent(this.TryResolvePath(EditTablesRequestFile));
                SynapseAnalyticsClient.EditTables(this.LinkConnectionName, rawJsonContent);
            }
        }
    }
}
