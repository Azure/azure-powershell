using Microsoft.Azure.Management.Monitor.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.Auditing.Model
{
    public class DatabsaeEventHubAuditingSettingsModel : DatabaseDiagnosticAuditingSettingsModel
    {
        public string EventHubName { get; set; }

        public string EventHubAuthorizationRuleResourceId { get; set; }

        protected override bool IsAuditStateDisabled =>
            base.IsAuditStateDisabled ||
            DiagnosticsEnablingAuditCategory.All(s =>
                string.IsNullOrEmpty(s.EventHubAuthorizationRuleId));

        protected override void MarkAuditStateAsDisabled()
        {
            AuditState = AuditStateType.Disabled;
            EventHubName = null;
            EventHubAuthorizationRuleResourceId = null;
        }

        protected override void MarkAuditStateAsEnabled()
        {
            AuditState = AuditStateType.Enabled;
            DiagnosticSettingsResource settings = DiagnosticsEnablingAuditCategory.FirstOrDefault(
                s => !string.IsNullOrEmpty(s.EventHubAuthorizationRuleId));
            EventHubName = settings.EventHubName;
            EventHubAuthorizationRuleResourceId = settings.EventHubAuthorizationRuleId;
        }

        protected override void VerifySettingsBeforePersistChanges()
        {
            if (AuditState == AuditStateType.Enabled &&
                string.IsNullOrEmpty(EventHubAuthorizationRuleResourceId))
            {
                throw DefinitionsCommon.EventHubAuthorizationRuleResourceIdParameterException;
            }
        }

        protected override string GetEventHubNameOnCreateOrUpdate(
            DiagnosticSettingsResource settings) => EventHubName;

        protected override string GetEventHubAuthorizationRuleIdOnCreateOrUpdate(
            DiagnosticSettingsResource settings) => EventHubAuthorizationRuleResourceId;

        protected override string GetWorkspaceIdOnCreateOrUpdate(
            DiagnosticSettingsResource settings) => settings?.WorkspaceId;

        protected override string GetEventHubNameOnDisablePolicy(DiagnosticSettingsResource settings) => null;

        protected override string GetEventHubAuthorizationRuleIdOnDisablePolicy(
            DiagnosticSettingsResource settings) => null;

        protected override string GetWorkspaceIdOnOnDisablePolicy(DiagnosticSettingsResource settings) => settings?.WorkspaceId;

        protected override bool ShoudDiagnosticSettingsBeRemovedOnDisabledPolicy(
            DiagnosticSettingsResource settings) =>
            base.ShoudDiagnosticSettingsBeRemovedOnDisabledPolicy(settings) ||
                string.IsNullOrEmpty(settings.WorkspaceId);
    }
}
