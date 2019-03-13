using Microsoft.Azure.Management.Monitor.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.Auditing.Model
{
    public class DatabaseLogAnalyticsAuditingSettingsModel : DatabaseDiagnosticAuditingSettingsModel
    {
        public string WorkspaceResourceId { get; set; }

        protected override bool IsAuditStateDisabled =>
            base.IsAuditStateDisabled ||
            DiagnosticsEnablingAuditCategory.All(s => string.IsNullOrEmpty(s.WorkspaceId));

        protected override void MarkAuditStateAsDisabled()
        {
            AuditState = AuditStateType.Disabled;
            WorkspaceResourceId = null;
        }

        protected override void MarkAuditStateAsEnabled()
        {
            AuditState = AuditStateType.Enabled;
            DiagnosticSettingsResource settings = DiagnosticsEnablingAuditCategory.FirstOrDefault(
                s => !string.IsNullOrEmpty(s.WorkspaceId));
            WorkspaceResourceId = settings.WorkspaceId;
        }

        protected override void VerifySettingsBeforePersistChanges()
        {
            if (AuditState == AuditStateType.Enabled &&
                string.IsNullOrEmpty(WorkspaceResourceId))
            {
                throw DefinitionsCommon.WorkspaceResourceIdParameterException;
            }
        }

        protected override string GetEventHubNameOnCreateOrUpdate(
            DiagnosticSettingsResource settings) => settings?.EventHubName;

        protected override string GetEventHubAuthorizationRuleIdOnCreateOrUpdate(
            DiagnosticSettingsResource settings) => settings?.EventHubAuthorizationRuleId;

        protected override string GetWorkspaceIdOnCreateOrUpdate(
            DiagnosticSettingsResource settings) => WorkspaceResourceId;

        protected override string GetEventHubNameOnDisablePolicy(
            DiagnosticSettingsResource settings) => settings?.EventHubName;

        protected override string GetEventHubAuthorizationRuleIdOnDisablePolicy(
            DiagnosticSettingsResource settings) => settings?.EventHubAuthorizationRuleId;

        protected override string GetWorkspaceIdOnOnDisablePolicy(DiagnosticSettingsResource settings) => null;

        protected override bool ShoudDiagnosticSettingsBeRemovedOnDisabledPolicy(
            DiagnosticSettingsResource settings) =>
            base.ShoudDiagnosticSettingsBeRemovedOnDisabledPolicy(settings) ||
                string.IsNullOrEmpty(settings.EventHubAuthorizationRuleId);
    }
}
