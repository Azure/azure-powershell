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
using System.Management.Automation;
using Microsoft.Azure.Commands.Synapse.Properties;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.LinkConnection,
           DefaultParameterSetName = StopByName, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class StopAzureSynapseLinkConnection : SynapseArtifactsCmdletBase
    {
        private const string StopByName = "StopByName";
        private const string StopByObject = "StopByObject";
        private const string StopByInputObject = "StopByInputObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopByInputObject,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionObject)]
        [ValidateNotNull]
        public PSLinkConnectionResource InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByName,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByObject,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionName)]
        [ValidateNotNullOrEmpty]
        [Alias("LinkConnectionName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

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
                this.Name = this.InputObject.Name;
            }

            if (this.ShouldProcess(this.WorkspaceName, string.Format(Resources.StoppingPipelineRun, this.Name, this.WorkspaceName)))
            {
                SynapseAnalyticsClient.StopLinkConnection(this.Name);
                if (this.PassThru)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
