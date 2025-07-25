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
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Synapse.Properties;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.DataFlowDebugSessionPackage,
           DefaultParameterSetName = AddByName,SupportsShouldProcess = true)]
    [OutputType(typeof(PSAddDataFlowToDebugSessionResponse))]
    public class AddAzureSynapseDataFlowDebugSessionPackage : SynapseArtifactsCmdletBase
    {     
        private const string AddByName = "AddByName";
        private const string AddByObject = "AddByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = AddByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = AddByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.JsonFilePath)]
        [ValidateNotNullOrEmpty]
        [Alias("File")]
        public string PackageFile { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.DataFlowDebugSessionId)]
        [ValidateNotNullOrEmpty]
        public string SessionId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.AddDataFlowDebugSessionPackage, this.SessionId, this.WorkspaceName)))
            {
                string rawJsonContent = SynapseAnalyticsClient.ReadJsonFileContent(this.TryResolvePath(PackageFile));
                WriteObject(new PSAddDataFlowToDebugSessionResponse(SynapseAnalyticsClient.AddDataFlowDebugSessionPackage(rawJsonContent, this.SessionId)));
            }
        }
    }
}
