using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Management.Monitor.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Model
{
    public abstract class ServerDiagnosticAuditingSettingsModel : ServerBlobAuditingSettingsModel
    {
        [Hidden]
        public override string StorageAccountName { get; set; }

        [Hidden]
        public override StorageKeyKind StorageKeyType { get; set; }

        [Hidden]
        public override uint? RetentionInDays { get; internal set; }

        [Hidden]
        public override Guid StorageAccountSubscriptionId { get; set; }

        protected override bool IsAuditStateDisabled =>
            IsGlobalAuditEnabled == false ||
            IsAzureMonitorTargetEnabled == false ||
            DiagnosticsEnablingAuditCategory == null ||
            DiagnosticsEnablingAuditCategory.Any() == false;

        internal override void PersistChanges(SqlAuditAdapter adapter) => PersistDiagnosticSettingsChanges(adapter);
    }
}
