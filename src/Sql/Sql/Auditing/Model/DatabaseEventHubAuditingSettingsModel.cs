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
