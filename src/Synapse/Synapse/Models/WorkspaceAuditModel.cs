using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse.Models
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

    public enum StorageKeyKind { None, Primary, Secondary };

    public class WorkspaceAuditModel
    {
        public string ResourceGroupName { get; set; }

        public string WorkspaceName { get; set; }

        public AuditActionGroups[] AuditActionGroup { get; set; }

        public string PredicateExpression { get; set; }

        public AuditStateType BlobStorageTargetState { get; set; }

        public string StorageAccountResourceId { get; set; }

        public StorageKeyKind StorageKeyType { get; set; }

        public uint? RetentionInDays { get; set; }

        [Hidden]
        internal bool? IsAzureMonitorTargetEnabled { get; set; }
    }
}
