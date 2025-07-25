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
using Microsoft.Azure.Commands.Synapse.Models.Auditing;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    public abstract class SynapseWorkspaceAuditCmdlet<ServerAuditPolicyType, ServerAuditModelType, ServerAuditAdapterType> : AzureSynapseSqlManagementCmdletBase<ServerAuditModelType, ServerAuditAdapterType>
        where ServerAuditPolicyType : ProxyResource 
        where ServerAuditModelType : WorkspaceDevOpsAuditModel, new()
        where ServerAuditAdapterType : SqlAuditAdapter<ServerAuditPolicyType, ServerAuditModelType>
    {
        [Parameter(
            ParameterSetName = DefinitionsCommon.WorkspaceParameterSetName,
            Mandatory = false,
            Position = 0,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.WorkspaceParameterSetName,
            Mandatory = true,
            Position = 1,
            HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.WorkspaceObjectParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        [Alias("InputObject")]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.WorkspaceResourceIdParameterSetName,
            Mandatory = true,
            HelpMessage = HelpMessages.WorkspaceResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        protected override ServerAuditModelType GetEntity()
        {
            if (WorkspaceObject != null)
            {
                ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                WorkspaceName = WorkspaceObject.Name;
            }

            if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ResourceName;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            ServerAuditModelType model = new ServerAuditModelType()
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = WorkspaceName
            };

            ModelAdapter.GetAuditingSettings(ResourceGroupName, WorkspaceName, model);
            return model;
        }
    }
}
