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

using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.Auditing;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(
        VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + DefinitionsCommon.WorkspaceAuditCmdletsSuffix,
        DefaultParameterSetName = DefinitionsCommon.WorkspaceParameterSetName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    [Alias("Set-AzSynapseSqlAudit")]
    public class SetAzureSynapseWorkspaceAudit : SetSynapseWorkspaceAuditCmdlet<ExtendedServerBlobAuditingPolicy, WorkspaceAuditModel, SynapseWorkspaceAuditAdapter>
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.AuditActionGroup)]
        public AuditActionGroups[] AuditActionGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.PredicateExpression)]
        [ValidateNotNull]
        public string PredicateExpression { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.StorageKeyType)]
        [ValidateSet(
            SynapseConstants.Security.Primary,
            SynapseConstants.Security.Secondary,
            IgnoreCase = false)]
        public string StorageKeyType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.RetentionInDays)]
        [ValidateNotNullOrEmpty]
        public uint? RetentionInDays { get; set; }

        protected override WorkspaceAuditModel ApplyUserInputToModel(WorkspaceAuditModel model)
        {
            base.ApplyUserInputToModel(model);

            if (AuditActionGroup != null)
            {
                model.AuditActionGroup = AuditActionGroup;
            }

            if (PredicateExpression != null)
            {
                model.PredicateExpression = PredicateExpression;
            }

            if (this.IsParameterBound(c => c.StorageKeyType))
            {
                model.StorageKeyType = (StorageKeyType == SynapseConstants.Security.Primary) ? StorageKeyKind.Primary : StorageKeyKind.Secondary;
            }

            if (RetentionInDays != null)
            {
                model.RetentionInDays = RetentionInDays;
            }

            return model;
        }

        protected override SynapseWorkspaceAuditAdapter InitModelAdapter()
        {
            return new SynapseWorkspaceAuditAdapter(DefaultProfile.DefaultContext, RoleAssignmentId);
        }
    }
}
