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
using Azure.Analytics.Synapse.Artifacts.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.Synapse.Properties;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.DataFlowDebugSession,
           DefaultParameterSetName = StopByName, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class StopAzureSynapseDataFlowDebugSession : SynapseArtifactsCmdletBase
    {
        private const string StopByName = "StopByName";
        private const string StopByObject = "StoptByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByName,
             Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false,
            Mandatory = true, HelpMessage = HelpMessages.DataFlowDebugSessionId)]
        [ValidateNotNullOrEmpty]
        public string SessionId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.Force)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.StopSynapseDataFlowDebugSession, SessionId, WorkspaceName),
                string.Format(Resources.StopingSynapseDataFlowDebugSession, this.SessionId, this.WorkspaceName),
                SessionId,
                () =>
                {
                    DeleteDataFlowDebugSessionRequest request = new DeleteDataFlowDebugSessionRequest();
                    request.SessionId = this.SessionId;
                    SynapseAnalyticsClient.DeleteDataFlowDebugSession(request);
                    if (this.PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        } 
    }
}
