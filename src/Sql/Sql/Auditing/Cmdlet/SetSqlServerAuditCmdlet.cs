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
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    public abstract class SetSqlServerAuditCmdlet<ServerAuditPolicyType, ServerAuditModelType, ServerAuditAdapterType> : SqlServerAuditCmdlet<ServerAuditPolicyType, ServerAuditModelType, ServerAuditAdapterType> 
        where ServerAuditPolicyType : ProxyResource
        where ServerAuditModelType : ServerDevOpsAuditModel, new()
        where ServerAuditAdapterType : SqlAuditAdapter<ServerAuditPolicyType, ServerAuditModelType> 
    {
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

        protected override ServerAuditModelType ApplyUserInputToModel(ServerAuditModelType model)
        {
            base.ApplyUserInputToModel(model);

            if (BlobStorageTargetState != null)
            {
                model.BlobStorageTargetState = BlobStorageTargetState == SecurityConstants.Enabled ?
                    AuditStateType.Enabled : AuditStateType.Disabled;
            }

            if (StorageAccountResourceId != null)
            {
                model.StorageAccountResourceId = StorageAccountResourceId;
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

        protected override ServerAuditModelType PersistChanges(ServerAuditModelType entity)
        {
            ModelAdapter.PersistAuditChanges(entity);
            return null;
        }

        protected override bool WriteResult() => PassThru;
    }
}
