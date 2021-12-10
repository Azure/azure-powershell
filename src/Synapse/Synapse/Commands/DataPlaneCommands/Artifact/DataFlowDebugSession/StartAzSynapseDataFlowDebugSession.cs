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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Common;
using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Text.Json;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.DataFlowDebugSession, 
        DefaultParameterSetName = StartByName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSCreateDataFlowDebugSessionResponse))]
    public class StartAzSynapseDataFlowDebugSession : SynapseArtifactsCmdletBase
    {
        private const string StartByName = "StartByName";
        private const string StartByObject = "StartByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StartByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StartByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.JsonFilePath)]
        [ValidateNotNullOrEmpty]
        [Alias("File")]
        public string IntegrationRuntimeFile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            CreateDataFlowDebugSessionRequest request = new CreateDataFlowDebugSessionRequest
            {
                TimeToLive = 60
            };

            if (!string.IsNullOrWhiteSpace(IntegrationRuntimeFile))
            {
                string rawJsonContent = SynapseAnalyticsClient.ReadJsonFileContent(this.TryResolvePath(IntegrationRuntimeFile));
                IntegrationRuntimeDebugResource createdataflowsessionrequest = JsonSerializer.Deserialize<IntegrationRuntimeDebugResource>(rawJsonContent);
                request.IntegrationRuntime = createdataflowsessionrequest;
            }

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.StartDataFlowDebugSession,  this.WorkspaceName)))
            {
                WriteObject(new PSCreateDataFlowDebugSessionResponse(SynapseAnalyticsClient.CreateDataFlowDebugSession(request)));
            }
        }
    }
}
