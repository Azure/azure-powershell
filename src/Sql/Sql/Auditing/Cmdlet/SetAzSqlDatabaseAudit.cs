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

using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Commands.Sql.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DefinitionsCommon.DatabaseAuditCmdletsSuffix,
        DefaultParameterSetName = DefinitionsCommon.DatabaseParameterSetName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class SetAzSqlDatabaseAudit : SqlDatabaseAuditCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.AuditActionGroupsHelpMessage)]
        public AuditActionGroups[] AuditActionGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.AuditActionHelpMessage)]
        public string[] AuditAction { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.PredicateExpressionHelpMessage)]
        [ValidateNotNull]
        public string PredicateExpression { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.BlobStorageTargetState)]
        [ValidateSet(SecurityConstants.Enabled, SecurityConstants.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string BlobStorageTargetState { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.AuditStorageAccountResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.StorageKeyTypeHelpMessage)]
        [ValidateSet(
            SecurityConstants.Primary,
            SecurityConstants.Secondary,
            IgnoreCase = false)]
        public string StorageKeyType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.RetentionInDaysHelpMessage)]
        [ValidateNotNullOrEmpty]
        public uint? RetentionInDays { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.EventHubTargetState)]
        [ValidateSet(SecurityConstants.Enabled, SecurityConstants.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string EventHubTargetState { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.EventHubNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string EventHubName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.EventHubAuthorizationRuleIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string EventHubAuthorizationRuleResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.LogAnalyticsTargetState)]
        [ValidateSet(SecurityConstants.Enabled, SecurityConstants.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string LogAnalyticsTargetState { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.WorkspaceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        public Guid RoleAssignmentId { get; set; } = default(Guid);

        protected override DatabaseAuditModel ApplyUserInputToModel(DatabaseAuditModel model)
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
                model.BlobStorageTargetState = BlobStorageTargetState == SecurityConstants.Enabled ?
                    AuditStateType.Enabled : AuditStateType.Disabled;
            }

            if (StorageAccountResourceId != null)
            {
                model.StorageAccountResourceId = StorageAccountResourceId;
            }

            if (MyInvocation.BoundParameters.ContainsKey(SecurityConstants.StorageKeyType))
            {
                model.StorageKeyType = (StorageKeyType == SecurityConstants.Primary) ? StorageKeyKind.Primary : StorageKeyKind.Secondary;
            }

            if (RetentionInDays != null)
            {
                model.RetentionInDays = RetentionInDays;
            }

            if (EventHubTargetState != null)
            {
                model.EventHubTargetState = EventHubTargetState == SecurityConstants.Enabled ?
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
                model.LogAnalyticsTargetState = LogAnalyticsTargetState == SecurityConstants.Enabled ?
                    AuditStateType.Enabled : AuditStateType.Disabled;
            }

            if (WorkspaceResourceId != null)
            {
                model.WorkspaceResourceId = WorkspaceResourceId;
            }

            return model;
        }

        protected override DatabaseAuditModel PersistChanges(DatabaseAuditModel entity)
        {
            ModelAdapter.PersistAuditChanges(entity);
            return null;
        }

        protected override SqlDatabaseAuditAdapter InitModelAdapter()
        {
            return new SqlDatabaseAuditAdapter(DefaultProfile.DefaultContext, DatabaseName, RoleAssignmentId);
        }

        protected override bool WriteResult() => PassThru;
    }
}
