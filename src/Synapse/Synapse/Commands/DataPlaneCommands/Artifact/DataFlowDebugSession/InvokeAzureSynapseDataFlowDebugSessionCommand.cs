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
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.DataFlowDebugSessionCommand,
          DefaultParameterSetName = InvokeByName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSDataFlowDebugCommandResponse))]
    public class InvokeAzureSynapseDataFlowDebugSessionCommand : SynapseArtifactsCmdletBase
    {
        private const string InvokeByName = "InvokeByName";
        private const string InvokeByObject = "InvokeByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = InvokeByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = InvokeByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.DataFlowDebugSessionId)]
        [ValidateNotNullOrEmpty]
        public string SessionId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.DebugSessionCommand)]
        [ValidateNotNullOrEmpty]
        public string Command { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.DebugSessionStreamName)]
        [ValidateNotNullOrEmpty]
        public string StreamName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.DebugSessionRowLimit)]
        [ValidateNotNullOrEmpty]
        public int? RowLimit { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.DebugSessionExpression)]
        [ValidateNotNullOrEmpty]
        public string Expression { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.DebugSessionColumns)]
        [ValidateNotNullOrEmpty]
        public List<string> Column { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            DataFlowDebugCommandRequest request = new DataFlowDebugCommandRequest();
            request.SessionId = SessionId;
            request.Command = Command;
            request.CommandPayload = new DataFlowDebugCommandPayload(StreamName)
            {
                RowLimits = RowLimit,
                Expression = Expression
            };
            Column?.ForEach(item => request.CommandPayload.Columns.Add(item));
          
            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.InvokeDataFlowDebugSessionCommand, this.SessionId, this.WorkspaceName)))
            {               
                WriteObject(new PSDataFlowDebugCommandResponse(SynapseAnalyticsClient.InvokeDataFlowDebugSessionCommand(request)));
            }
        }
    }
}
