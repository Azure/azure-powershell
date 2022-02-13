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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(
        VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + DefinitionsCommon.SqlPoolAuditCmdletsSuffix,
        DefaultParameterSetName = DefinitionsCommon.SqlPoolParameterSetName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    [Alias("Set-AzSynapseSqlPoolAudit")]
    public class SetAzureSynapseSqlPoolAudit : SynapseSqlPoolAuditCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.AuditActionGroup)]
        public AuditActionGroups[] AuditActionGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.AuditAction)]
        public string[] AuditAction { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.PredicateExpression)]
        [ValidateNotNull]
        public string PredicateExpression { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.BlobStorageTargetState)]
        [ValidateSet(SynapseConstants.Security.Enabled, SynapseConstants.Security.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string BlobStorageTargetState { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.AuditStorageAccountResourceId)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountResourceId { get; set; }

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

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.EventHubTargetState)]
        [ValidateSet(SynapseConstants.Security.Enabled, SynapseConstants.Security.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string EventHubTargetState { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.EventHubName)]
        [ValidateNotNullOrEmpty]
        public string EventHubName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.EventHubAuthorizationRuleId)]
        [ValidateNotNullOrEmpty]
        public string EventHubAuthorizationRuleResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.LogAnalyticsTargetState)]
        [ValidateSet(SynapseConstants.Security.Enabled, SynapseConstants.Security.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string LogAnalyticsTargetState { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.WorkspaceId)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public Guid RoleAssignmentId { get; set; } = default(Guid);

        protected override SqlPoolAuditModel ApplyUserInputToModel(SqlPoolAuditModel model)
        {
            base.ApplyUserInputToModel(model);

            if (AuditAction != null)
            {
                model.AuditAction = AuditAction;
            }

            if (AuditActionGroup != null)
            {
                model.AuditActionGroup = AuditActionGroup;
            }

            if (PredicateExpression != null)
            {
                model.PredicateExpression = PredicateExpression;
            }

            if (BlobStorageTargetState != null)
            {
                model.BlobStorageTargetState = BlobStorageTargetState == SynapseConstants.Security.Enabled ?
                    AuditStateType.Enabled : AuditStateType.Disabled;
            }

            if (StorageAccountResourceId != null)
            {
                model.StorageAccountResourceId = StorageAccountResourceId;
            }

            if (this.IsParameterBound(c => c.StorageKeyType))
            {
                model.StorageKeyType = (StorageKeyType == SynapseConstants.Security.Primary) ? StorageKeyKind.Primary : StorageKeyKind.Secondary;
            }

            if (RetentionInDays != null)
            {
                model.RetentionInDays = RetentionInDays;
            }

            if (EventHubTargetState != null)
            {
                model.EventHubTargetState = EventHubTargetState == SynapseConstants.Security.Enabled ?
                    AuditStateType.Enabled : AuditStateType.Disabled;
            }

            if (EventHubName != null)
            {
                model.EventHubName = EventHubName;
            }

            if (EventHubAuthorizationRuleResourceId != null)
            {
                model.EventHubAuthorizationRuleResourceId = EventHubAuthorizationRuleResourceId;
            }

            if (LogAnalyticsTargetState != null)
            {
                model.LogAnalyticsTargetState = LogAnalyticsTargetState == SynapseConstants.Security.Enabled ?
                    AuditStateType.Enabled : AuditStateType.Disabled;
            }

            if (WorkspaceResourceId != null)
            {
                model.WorkspaceResourceId = WorkspaceResourceId;
            }

            return model;
        }

        protected override SqlPoolAuditModel PersistChanges(SqlPoolAuditModel entity)
        {
            ModelAdapter.PersistAuditChanges(entity);
            return null;
        }

        protected override SynapseSqlPoolAuditAdapter InitModelAdapter()
        {
            return new SynapseSqlPoolAuditAdapter(DefaultProfile.DefaultContext, SqlPoolName, RoleAssignmentId);
        }

        protected override bool WriteResult() => PassThru;
    }
}
