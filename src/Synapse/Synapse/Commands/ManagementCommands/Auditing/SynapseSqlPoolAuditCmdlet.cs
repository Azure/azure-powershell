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
using Microsoft.Azure.Commands.Synaspe.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    public class SynapseSqlPoolAuditCmdlet : AzureSynapseSqlPoolManagementCmdletBase<SqlPoolAuditModel, SynapseSqlPoolAuditAdapter>
    {
        [Parameter(
            ParameterSetName = DefinitionsCommon.SqlPoolParameterSetName,
            Mandatory = false,
            Position = 0,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.SqlPoolParameterSetName,
            Mandatory = true,
            Position = 1,
            HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.SqlPoolParentObjectParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.SqlPoolParentObjectParameterSetName,
            Mandatory = true,
            HelpMessage = HelpMessages.SqlPoolName)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.SqlPoolParameterSetName,
            Mandatory = true,
            Position = 2,
            HelpMessage = HelpMessages.SqlPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlPool,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public override string SqlPoolName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.SqlPoolObjectParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = HelpMessages.SqlPoolObject)]
        [ValidateNotNull]
        [Alias("InputObject")]
        public PSSynapseSqlPool SqlPoolObject { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.SqlPoolResourceIdParameterSetName,
            Mandatory = true,
            HelpMessage = HelpMessages.SqlPoolResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        protected override SqlPoolAuditModel GetEntity()
        {
            if (SqlPoolObject != null)
            {
                var resourceIdentifier = new ResourceIdentifier(this.SqlPoolObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SqlPoolName = resourceIdentifier.ResourceName;
            }

            if (WorkspaceObject != null)
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SqlPoolName = resourceIdentifier.ResourceName;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            SqlPoolAuditModel model = new SqlPoolAuditModel
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = WorkspaceName,
                SqlPoolName = SqlPoolName
            };

            ModelAdapter.SqlPoolName = SqlPoolName;
            ModelAdapter.GetAuditingSettings(ResourceGroupName, WorkspaceName, model);

            return model;
        }

        protected override SynapseSqlPoolAuditAdapter InitModelAdapter()
        {
            return new SynapseSqlPoolAuditAdapter(DefaultProfile.DefaultContext, SqlPoolName);
        }
    }
}
