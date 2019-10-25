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

using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Model
{
    public enum AuditStateType { Enabled, Disabled };

    public enum AuditActionGroups
    {
        BATCH_STARTED_GROUP,
        BATCH_COMPLETED_GROUP,
        APPLICATION_ROLE_CHANGE_PASSWORD_GROUP,
        BACKUP_RESTORE_GROUP,
        DATABASE_LOGOUT_GROUP,
        DATABASE_OBJECT_CHANGE_GROUP,
        DATABASE_OBJECT_OWNERSHIP_CHANGE_GROUP,
        DATABASE_OBJECT_PERMISSION_CHANGE_GROUP,
        DATABASE_OPERATION_GROUP,
        DATABASE_PERMISSION_CHANGE_GROUP,
        DATABASE_PRINCIPAL_CHANGE_GROUP,
        DATABASE_PRINCIPAL_IMPERSONATION_GROUP,
        DATABASE_ROLE_MEMBER_CHANGE_GROUP,
        FAILED_DATABASE_AUTHENTICATION_GROUP,
        SCHEMA_OBJECT_ACCESS_GROUP,
        SCHEMA_OBJECT_CHANGE_GROUP,
        SCHEMA_OBJECT_OWNERSHIP_CHANGE_GROUP,
        SCHEMA_OBJECT_PERMISSION_CHANGE_GROUP,
        SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP,
        USER_CHANGE_PASSWORD_GROUP
    }

    public enum StorageKeyKind { Primary, Secondary };

    public class ServerAuditModel
    {
        public string ResourceGroupName { get; set; }

        public string ServerName { get; set; }

        public AuditActionGroups[] AuditActionGroup { get; set; }

        public string PredicateExpression { get; set; }

        public AuditStateType BlobStorageTargetState { get; set; }

        public string StorageAccountResourceId { get; set; }

        public StorageKeyKind StorageKeyType { get; set; }

        public uint? RetentionInDays { get; set; }

        public AuditStateType EventHubTargetState { get; set; }

        public string EventHubName { get; set; }

        public string EventHubAuthorizationRuleResourceId { get; set; }

        public AuditStateType LogAnalyticsTargetState { get; set; }

        public string WorkspaceResourceId { get; set; }

        [Hidden]
        internal bool? IsAzureMonitorTargetEnabled { get; set; }

        [Hidden]
        internal IList<DiagnosticSettingsResource> DiagnosticsEnablingAuditCategory { get; set; }

        [Hidden]
        internal string NextDiagnosticSettingsName { get; set; }
    }
}
