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

using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public class ServerBlobAuditingSettingsModel
    {
        public string ResourceGroupName { get; set; }

        public string ServerName { get; set; }

        public AuditStateType AuditState { get; set; }

        public AuditActionGroups[] AuditActionGroup { get; set; }

        public string PredicateExpression { get; set; }

        [Hidden]
        internal bool? IsAzureMonitorTargetEnabled { get; set; }

        [Hidden]
        internal bool IsGlobalAuditEnabled { get; set; }

        [Hidden]
        internal IList<DiagnosticSettingsResource> DiagnosticsEnablingAuditCategory { get; set; }

        [Hidden]
        internal string NextDiagnosticSettingsName { get; set; }

        public virtual string StorageAccountName { get; set; }

        public virtual Guid StorageAccountSubscriptionId { get; set; }

        public virtual StorageKeyKind StorageKeyType { get; set; }

        public virtual uint? RetentionInDays { get; internal set; }

        internal void DetermineAuditState()
        {
            if (IsAuditStateDisabled)
            {
                MarkAuditStateAsDisabled();
            }
            else
            {
                MarkAuditStateAsEnabled();
            }
        }

        internal virtual void PersistChanges(SqlAuditAdapter adapter)
        {
            VerifySettingsBeforePersistChanges();
            IsGlobalAuditEnabled = AuditState == AuditStateType.Enabled ||
                (IsGlobalAuditEnabled && IsAzureMonitorTargetEnabled == true);
            if (SetAuditingPolicy(adapter) == false)
            {
                throw DefinitionsCommon.SetAuditingSettingsException;
            }
        }

        protected virtual void MarkAuditStateAsDisabled()
        {
            AuditState = AuditStateType.Disabled;
        }

        protected virtual void MarkAuditStateAsEnabled()
        {
            AuditState = AuditStateType.Enabled;
        }

        protected virtual bool IsAuditStateDisabled =>
            IsGlobalAuditEnabled == false || string.IsNullOrEmpty(StorageAccountName);

        protected virtual void VerifySettingsBeforePersistChanges()
        {
            if (AuditState == AuditStateType.Enabled && string.IsNullOrEmpty(StorageAccountName))
            {
                throw new PSArgumentException("Storage acount name is not provided",
                    DefinitionsCommon.StorageAccountNameParameterName);
            }
        }

        protected virtual bool SetAuditingPolicy(SqlAuditAdapter adapter) => adapter.SetAuditingPolicy(this);

        protected virtual string GetEventHubNameOnCreateOrUpdate(DiagnosticSettingsResource settings) => null;

        protected virtual string GetEventHubAuthorizationRuleIdOnCreateOrUpdate(
            DiagnosticSettingsResource settings) => null;

        protected virtual string GetWorkspaceIdOnCreateOrUpdate(DiagnosticSettingsResource settings) => null;

        protected virtual string GetEventHubNameOnDisablePolicy(DiagnosticSettingsResource settings) => null;

        protected virtual string GetEventHubAuthorizationRuleIdOnDisablePolicy(DiagnosticSettingsResource settings) => null;

        protected virtual string GetWorkspaceIdOnOnDisablePolicy(DiagnosticSettingsResource settings) => null;

        protected virtual bool ShoudDiagnosticSettingsBeRemovedOnDisabledPolicy(
            DiagnosticSettingsResource settings) =>
            IsGlobalAuditEnabled == false || IsAzureMonitorTargetEnabled != true;

        protected void PersistDiagnosticSettingsChanges(SqlAuditAdapter adapter)
        {
            VerifySettingsBeforePersistChanges();

            if (DiagnosticsEnablingAuditCategory != null && DiagnosticsEnablingAuditCategory.Count > 1)
            {
                throw new Exception(DefinitionsCommon.MultipleDiagnosticsErrorMessage);
            }

            DiagnosticSettingsResource currentSettings = DiagnosticsEnablingAuditCategory?.FirstOrDefault();
            if (currentSettings == null)
            {
                ChangeWhenDiagnosticsEnablingAuditCategoryDoNotExist(adapter);
            }
            else
            {
                ChangeWhenDiagnosticSettingsExist(adapter, currentSettings);
            }
        }

        private void ChangeWhenDiagnosticsEnablingAuditCategoryDoNotExist(SqlAuditAdapter adapter)
        {
            if (AuditState == AuditStateType.Enabled)
            {
                EnableWhenDiagnosticsEnablingAuditCategoryDoNotExist(adapter);
            }
            else
            {
                DisableWhenDiagnosticsEnablingAuditCategoryDoNotExist(adapter);
            }
        }

        private void EnableWhenDiagnosticsEnablingAuditCategoryDoNotExist(SqlAuditAdapter adapter, DiagnosticSettingsResource currentSettings = null)
        {
            if (adapter.CreateDiagnosticSettings(
                    GetEventHubNameOnCreateOrUpdate(currentSettings),
                    GetEventHubAuthorizationRuleIdOnCreateOrUpdate(currentSettings),
                    GetWorkspaceIdOnCreateOrUpdate(currentSettings),
                    this) == false)
            {
                throw DefinitionsCommon.CreateDiagnosticSettingsException;
            }

            if (IsGlobalAuditEnabled && IsAzureMonitorTargetEnabled == true)
            {
                return;
            }

            try
            {
                IsGlobalAuditEnabled = true;
                IsAzureMonitorTargetEnabled = true;
                if (SetAuditingPolicy(adapter) == false)
                {
                    throw DefinitionsCommon.SetAuditingSettingsException;
                }
            }
            catch (Exception)
            {
                try
                {
                    adapter.RemoveDiagnosticSettings(this);
                }
                catch (Exception) { }

                throw;
            }
        }

        private void DisableWhenDiagnosticsEnablingAuditCategoryDoNotExist(SqlAuditAdapter adapter)
        {
            if (IsGlobalAuditEnabled == false ||
                (IsAzureMonitorTargetEnabled != true && !string.IsNullOrEmpty(StorageAccountName)))
            {
                return;
            }

            IsAzureMonitorTargetEnabled = false;
            if (string.IsNullOrEmpty(StorageAccountName))
            {
                IsGlobalAuditEnabled = false;
            }

            if (SetAuditingPolicy(adapter) == false)
            {
                throw DefinitionsCommon.SetAuditingSettingsException;
            }
        }

        private void ChangeWhenDiagnosticSettingsExist(SqlAuditAdapter adapter, DiagnosticSettingsResource settings)
        {
            if (IsAnotherCategoryEnabled(settings))
            {
                ChangeWhenMultipleCategoriesAreEnabled(adapter, settings);
            }
            else
            {
                ChangeWhenOnlyAuditCategoryIsEnabled(adapter, settings);
            }
        }

        private void ChangeWhenMultipleCategoriesAreEnabled(SqlAuditAdapter adapter, DiagnosticSettingsResource settings)
        {
            if (DisableAuditCategory(adapter, settings) == false)
            {
                throw DefinitionsCommon.UpdateDiagnosticSettingsException;
            }

            try
            {
                if (AuditState == AuditStateType.Enabled)
                {
                    EnableWhenDiagnosticsEnablingAuditCategoryDoNotExist(adapter, settings);
                }
                else
                {
                    if (ShoudDiagnosticSettingsBeRemovedOnDisabledPolicy(settings))
                    {
                        DisableWhenDiagnosticsEnablingAuditCategoryDoNotExist(adapter);
                    }
                    else
                    {
                        if (adapter.CreateDiagnosticSettings(
                            GetEventHubNameOnDisablePolicy(settings),
                            GetEventHubAuthorizationRuleIdOnDisablePolicy(settings),
                            GetWorkspaceIdOnOnDisablePolicy(settings), this) == false)
                        {
                            throw DefinitionsCommon.CreateDiagnosticSettingsException;
                        }
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    EnableAuditCategory(adapter, settings);
                }
                catch (Exception) { }

                throw;

            }

        }

        private void EnableWhenOnlyAuditCategoryIsEnabled(SqlAuditAdapter adapter, DiagnosticSettingsResource settings,
            string oldEventHubName, string oldEventHubAuthorizationRuleId, string oldWorkspaceId)
        {
            settings.EventHubName = GetEventHubNameOnCreateOrUpdate(settings);
            settings.EventHubAuthorizationRuleId = GetEventHubAuthorizationRuleIdOnCreateOrUpdate(settings);
            settings.WorkspaceId = GetWorkspaceIdOnCreateOrUpdate(settings);
            if (adapter.UpdateDiagnosticSettings(settings, this) == false)
            {
                throw DefinitionsCommon.UpdateDiagnosticSettingsException;
            }

            if (IsGlobalAuditEnabled && IsAzureMonitorTargetEnabled == true)
            {
                return;
            }

            try
            {
                IsGlobalAuditEnabled = true;
                IsAzureMonitorTargetEnabled = true;
                if (SetAuditingPolicy(adapter) == false)
                {
                    throw DefinitionsCommon.SetAuditingSettingsException;
                }
            }
            catch (Exception)
            {
                try
                {
                    settings.EventHubName = oldEventHubName;
                    settings.EventHubAuthorizationRuleId = oldEventHubAuthorizationRuleId;
                    settings.WorkspaceId = oldWorkspaceId;
                    adapter.UpdateDiagnosticSettings(settings, this);
                }
                catch (Exception) { }

                throw;
            }
        }

        private void DisableWhenOnlyAuditCategoryIsEnabled(SqlAuditAdapter adapter, DiagnosticSettingsResource settings, string oldEventHubName, string oldEventHubAuthorizationRuleId, string oldWorkspaceId)
        {
            if (ShoudDiagnosticSettingsBeRemovedOnDisabledPolicy(settings))
            {
                if (adapter.RemoveDiagnosticSettings(this) == false)
                {
                    throw new Exception("Failed to remove Diagnostic Settings");
                }

                try
                {
                    DisableWhenDiagnosticsEnablingAuditCategoryDoNotExist(adapter);
                }
                catch (Exception)
                {
                    try
                    {
                        adapter.CreateDiagnosticSettings(oldEventHubName,
                            oldEventHubAuthorizationRuleId, oldWorkspaceId, this);
                    }
                    catch (Exception) { }

                    throw;
                }
            }
            else
            {
                settings.EventHubName = GetEventHubNameOnDisablePolicy(settings);
                settings.EventHubAuthorizationRuleId = GetEventHubAuthorizationRuleIdOnDisablePolicy(settings);
                settings.WorkspaceId = GetWorkspaceIdOnOnDisablePolicy(settings);
                if (adapter.UpdateDiagnosticSettings(settings, this) == false)
                {
                    throw DefinitionsCommon.UpdateDiagnosticSettingsException;
                }
            }
        }

        private void ChangeWhenOnlyAuditCategoryIsEnabled(SqlAuditAdapter adapter, DiagnosticSettingsResource settings)
        {
            string oldEventHubName = settings.EventHubName;
            string oldEventHubAuthorizationRuleId = settings.EventHubAuthorizationRuleId;
            string oldWorkspaceId = settings.WorkspaceId;

            if (AuditState == AuditStateType.Enabled)
            {
                EnableWhenOnlyAuditCategoryIsEnabled(adapter, settings, oldEventHubName, oldEventHubAuthorizationRuleId, oldWorkspaceId);
            }
            else
            {
                DisableWhenOnlyAuditCategoryIsEnabled(adapter, settings, oldEventHubName, oldEventHubAuthorizationRuleId, oldWorkspaceId);
            }
        }

        private bool SetAuditCategoryState(SqlAuditAdapter adapter, DiagnosticSettingsResource settings, bool isEenabled)
        {
            var log = settings?.Logs?.FirstOrDefault(l => string.Equals(l.Category, DefinitionsCommon.SQLSecurityAuditCategory));
            if (log != null)
            {
                log.Enabled = isEenabled;
            }

            return adapter.UpdateDiagnosticSettings(settings, this);
        }

        private bool EnableAuditCategory(SqlAuditAdapter adapter, DiagnosticSettingsResource settings)
        {
            return SetAuditCategoryState(adapter, settings, true);
        }

        private bool DisableAuditCategory(SqlAuditAdapter adapter, DiagnosticSettingsResource settings)
        {
            return SetAuditCategoryState(adapter, settings, false);
        }

        private bool IsAnotherCategoryEnabled(DiagnosticSettingsResource settings)
        {
            return settings.Logs.FirstOrDefault(l => l.Enabled &&
                !string.Equals(l.Category, DefinitionsCommon.SQLSecurityAuditCategory)) != null ||
                settings.Metrics.FirstOrDefault(m => m.Enabled) != null;
        }
    }
}