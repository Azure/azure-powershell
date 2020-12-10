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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.Auditing.Services
{
    /// <summary>
    /// The SqlAuditClient class is responsible for transforming the data that was received form the endpoints to the cmdlets model of auditing policy and vice versa
    /// </summary>
    public class SqlAuditAdapter
    {
        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        private IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// The auditing endpoints communicator used by this adapter
        /// </summary>
        private AuditingEndpointsCommunicator Communicator { get; set; }

        /// <summary>
        /// The Azure endpoints communicator used by this adapter
        /// </summary>
        private AzureEndpointsCommunicator AzureCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        private Guid RoleAssignmentId { get; }

        public SqlAuditAdapter(IAzureContext context, Guid roleAssignmentId = default(Guid))
        {
            Context = context;
            Subscription = context?.Subscription;
            Communicator = new AuditingEndpointsCommunicator(Context);
            AzureCommunicator = new AzureEndpointsCommunicator(Context);
            RoleAssignmentId = roleAssignmentId;
        }

        internal void GetAuditingSettings(
            string resourceGroup, string serverName, string databaseName,
            DatabaseAuditModel model)
        {
            ExtendedDatabaseBlobAuditingPolicy policy = Communicator.GetAuditingPolicy(resourceGroup, serverName, databaseName);
            model.DiagnosticsEnablingAuditCategory =
                Communicator.GetDiagnosticsEnablingAuditCategory(out string nextDiagnosticSettingsName,
                    resourceGroup, serverName, databaseName);
            model.NextDiagnosticSettingsName = nextDiagnosticSettingsName;
            ModelizeDatabaseAuditPolicy(model, policy);
        }

        internal void GetAuditingSettings(
            string resourceGroup, string serverName,
            ServerAuditModel model)
        {
            ExtendedServerBlobAuditingPolicy policy = Communicator.GetAuditingPolicy(resourceGroup, serverName);
            model.DiagnosticsEnablingAuditCategory =
                Communicator.GetDiagnosticsEnablingAuditCategory(out string nextDiagnosticSettingsName,
                    resourceGroup, serverName);
            model.NextDiagnosticSettingsName = nextDiagnosticSettingsName;
            ModelizeServerAuditPolicy(model, policy);
        }

        private AuditActionGroups[] ExtractAuditActionGroups(IEnumerable<string> auditActionsAndGroups)
        {
            var groups = new List<AuditActionGroups>();
            if (auditActionsAndGroups != null)
            {
                auditActionsAndGroups.ForEach(item =>
                {
                    if (Enum.TryParse(item, true, out AuditActionGroups group))
                    {
                        groups.Add(group);
                    }
                });
            }

            return groups.ToArray();
        }

        private string[] ExtractAuditActions(IEnumerable<string> auditActionsAndGroups)
        {
            var actions = new List<string>();
            if (auditActionsAndGroups != null)
            {
                auditActionsAndGroups.ForEach(item =>
                {
                    if (!Enum.TryParse(item, true, out AuditActionGroups group))
                    {
                        actions.Add(item);
                    }
                });
            }

            return actions.ToArray();
        }

        private static void ModelizeRetentionInfo(dynamic model, int? retentionDays)
        {
            model.RetentionInDays = Convert.ToUInt32(retentionDays);
        }

        private void ModelizeStorageInfo(ServerAuditModel model,
            string storageEndpoint, bool? isSecondary, Guid? storageAccountSubscriptionId,
            bool isAuditEnabled, int? retentionDays)
        {
            if (string.IsNullOrEmpty(storageEndpoint))
            {
                return;
            }

            model.StorageKeyType = GetStorageKeyKind(isSecondary);

            if (isAuditEnabled)
            {
                if (storageAccountSubscriptionId == null || Guid.Empty.Equals(storageAccountSubscriptionId))
                {
                    storageAccountSubscriptionId = Subscription.GetId();
                }

                model.StorageAccountResourceId = AzureCommunicator.RetrieveStorageAccountIdAsync(
                    storageAccountSubscriptionId.Value,
                    GetStorageAccountName(storageEndpoint)).GetAwaiter().GetResult();

                ModelizeRetentionInfo(model, retentionDays);
            }
        }

        private static StorageKeyKind GetStorageKeyKind(bool? isSecondary)
        {
            if (isSecondary.HasValue)
            {
                return isSecondary.Value ? StorageKeyKind.Secondary : StorageKeyKind.Primary;
            }

            return StorageKeyKind.Primary;
        }

        private static string GetStorageAccountName(string storageEndpoint)
        {
            int accountNameStartIndex = storageEndpoint.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase) ? 8 : 7; // https:// or http://
            int accountNameEndIndex = storageEndpoint.IndexOf(".blob", StringComparison.InvariantCultureIgnoreCase);
            return storageEndpoint.Substring(accountNameStartIndex, accountNameEndIndex - accountNameStartIndex);
        }

        private bool IsAuditEnabled(BlobAuditingPolicyState state)
        {
            return state == BlobAuditingPolicyState.Enabled;
        }

        private void ModelizeServerAuditPolicy(
            ServerAuditModel model,
            ExtendedServerBlobAuditingPolicy policy)
        {
            model.IsAzureMonitorTargetEnabled = policy.IsAzureMonitorTargetEnabled;
            model.PredicateExpression = policy.PredicateExpression;
            model.AuditActionGroup = ExtractAuditActionGroups(policy.AuditActionsAndGroups);
            ModelizeStorageInfo(model, policy.StorageEndpoint, policy.IsStorageSecondaryKeyInUse, policy.StorageAccountSubscriptionId,
                IsAuditEnabled(policy.State), policy.RetentionDays);
            DetermineTargetsState(model, policy.State);
        }

        private void ModelizeDatabaseAuditPolicy(
            DatabaseAuditModel model,
            ExtendedDatabaseBlobAuditingPolicy policy)
        {
            model.IsAzureMonitorTargetEnabled = policy.IsAzureMonitorTargetEnabled;
            model.PredicateExpression = policy.PredicateExpression;
            model.AuditActionGroup = ExtractAuditActionGroups(policy.AuditActionsAndGroups);
            model.AuditAction = ExtractAuditActions(policy.AuditActionsAndGroups);
            ModelizeStorageInfo(model, policy.StorageEndpoint, policy.IsStorageSecondaryKeyInUse, policy.StorageAccountSubscriptionId,
                IsAuditEnabled(policy.State), policy.RetentionDays);
            DetermineTargetsState(model, policy.State);
        }

        private static void DetermineTargetsState(
            ServerAuditModel model,
            BlobAuditingPolicyState policyState)
        {
            if (policyState == BlobAuditingPolicyState.Disabled)
            {
                model.BlobStorageTargetState = AuditStateType.Disabled;
                model.EventHubTargetState = AuditStateType.Disabled;
                model.LogAnalyticsTargetState = AuditStateType.Disabled;
            }
            else
            {
                if (string.IsNullOrEmpty(model.StorageAccountResourceId))
                {
                    model.BlobStorageTargetState = AuditStateType.Disabled;
                }
                else
                {
                    model.BlobStorageTargetState = AuditStateType.Enabled;
                }

                if (model.IsAzureMonitorTargetEnabled == null ||
                    model.IsAzureMonitorTargetEnabled == false ||
                    model.DiagnosticsEnablingAuditCategory == null)
                {
                    model.EventHubTargetState = AuditStateType.Disabled;
                    model.LogAnalyticsTargetState = AuditStateType.Disabled;
                }
                else
                {
                    DiagnosticSettingsResource eventHubSettings = model.DiagnosticsEnablingAuditCategory.FirstOrDefault(
                        settings => !string.IsNullOrEmpty(settings.EventHubAuthorizationRuleId));
                    if (eventHubSettings == null)
                    {
                        model.EventHubTargetState = AuditStateType.Disabled;
                    }
                    else
                    {
                        model.EventHubTargetState = AuditStateType.Enabled;
                        model.EventHubName = eventHubSettings.EventHubName;
                        model.EventHubAuthorizationRuleResourceId = eventHubSettings.EventHubAuthorizationRuleId;
                    }

                    DiagnosticSettingsResource logAnalyticsSettings = model.DiagnosticsEnablingAuditCategory.FirstOrDefault(
                        settings => !string.IsNullOrEmpty(settings.WorkspaceId));
                    if (logAnalyticsSettings == null)
                    {
                        model.LogAnalyticsTargetState = AuditStateType.Disabled;
                    }
                    else
                    {
                        model.LogAnalyticsTargetState = AuditStateType.Enabled;
                        model.WorkspaceResourceId = logAnalyticsSettings.WorkspaceId;
                    }
                }
            }
        }

        private bool SetAudit(DatabaseAuditModel model)
        {
            ValidateDatabaseInServiceTierForPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName);

            if (string.IsNullOrEmpty(model.PredicateExpression))
            {
                DatabaseBlobAuditingPolicy policy = new DatabaseBlobAuditingPolicy();
                PolicizeAuditModel(model, policy);
                return Communicator.SetAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, policy);
            }
            else
            {
                ExtendedDatabaseBlobAuditingPolicy policy = new ExtendedDatabaseBlobAuditingPolicy
                {
                    PredicateExpression = model.PredicateExpression
                };

                PolicizeAuditModel(model, policy);
                return Communicator.SetExtendedAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, policy);
            }
        }

        private bool SetAudit(ServerAuditModel model)
        {
            if (string.IsNullOrEmpty(model.PredicateExpression))
            {
                var policy = new ServerBlobAuditingPolicy();
                PolicizeAuditModel(model, policy);
                return Communicator.SetAuditingPolicy(model.ResourceGroupName, model.ServerName, policy);
            }
            else
            {
                var policy = new ExtendedServerBlobAuditingPolicy
                {
                    PredicateExpression = model.PredicateExpression
                };
                PolicizeAuditModel(model, policy);
                return Communicator.SetExtendedAuditingPolicy(model.ResourceGroupName, model.ServerName, policy);
            }
        }

        private bool CreateOrUpdateAudit(ServerAuditModel model)
        {
            return (model is DatabaseAuditModel dbModel) ?
                SetAudit(dbModel) : SetAudit(model);
        }

        internal bool CreateDiagnosticSettings(
            string eventHubName, string eventHubAuthorizationRuleId, string workspaceId,
            ServerAuditModel model)
        {
            DiagnosticSettingsResource settings;
            if (model is DatabaseAuditModel databaseAuditModel)
            {
                settings = Communicator.CreateDiagnosticSettings(databaseAuditModel.NextDiagnosticSettingsName,
                    eventHubName, eventHubAuthorizationRuleId, workspaceId,
                    databaseAuditModel.ResourceGroupName, databaseAuditModel.ServerName, databaseAuditModel.DatabaseName);
            }
            else
            {
                settings = Communicator.CreateDiagnosticSettings(model.NextDiagnosticSettingsName,
                    eventHubName, eventHubAuthorizationRuleId, workspaceId,
                    model.ResourceGroupName, model.ServerName);
            }

            if (settings == null)
            {
                return false;
            }

            IList<DiagnosticSettingsResource> diagnosticsEnablingAuditCategory = model.DiagnosticsEnablingAuditCategory;
            if (diagnosticsEnablingAuditCategory == null)
            {
                diagnosticsEnablingAuditCategory = new List<DiagnosticSettingsResource>();
            }

            diagnosticsEnablingAuditCategory.Add(settings);
            model.DiagnosticsEnablingAuditCategory = diagnosticsEnablingAuditCategory;
            return true;
        }

        internal bool UpdateDiagnosticSettings(
            DiagnosticSettingsResource settings,
            ServerAuditModel model)
        {
            DiagnosticSettingsResource modifiedSettings;
            if (model is DatabaseAuditModel databaseAuditModel)
            {
                modifiedSettings = Communicator.UpdateDiagnosticSettings(settings,
                    databaseAuditModel.ResourceGroupName, databaseAuditModel.ServerName, databaseAuditModel.DatabaseName);
            }
            else
            {
                modifiedSettings = Communicator.UpdateDiagnosticSettings(settings,
                    model.ResourceGroupName, model.ServerName);
            }

            if (modifiedSettings == null)
            {
                return false;
            }

            List<DiagnosticSettingsResource> diagnosticsEnablingAuditCategory = new List<DiagnosticSettingsResource>();
            foreach (DiagnosticSettingsResource existingSettings in model.DiagnosticsEnablingAuditCategory)
            {
                if (!string.Equals(modifiedSettings.Id, existingSettings.Id))
                {
                    diagnosticsEnablingAuditCategory.Add(existingSettings);
                }
                else if (AuditingEndpointsCommunicator.IsAuditCategoryEnabled(modifiedSettings))
                {
                    diagnosticsEnablingAuditCategory.Add(modifiedSettings);
                }
            }

            model.DiagnosticsEnablingAuditCategory = diagnosticsEnablingAuditCategory.Any() ? diagnosticsEnablingAuditCategory : null;
            return true;
        }

        internal bool RemoveFirstDiagnosticSettings(dynamic model)
        {
            IList<DiagnosticSettingsResource> diagnosticsEnablingAuditCategory = model.DiagnosticsEnablingAuditCategory;
            DiagnosticSettingsResource settings = diagnosticsEnablingAuditCategory.FirstOrDefault();
            if (settings == null ||
                (model is DatabaseAuditModel dbModel ?
                Communicator.RemoveDiagnosticSettings(settings.Name, dbModel.ResourceGroupName, dbModel.ServerName, dbModel.DatabaseName) :
                Communicator.RemoveDiagnosticSettings(settings.Name, model.ResourceGroupName, model.ServerName)) == false)
            {
                return false;
            }

            diagnosticsEnablingAuditCategory.RemoveAt(0);
            model.DiagnosticsEnablingAuditCategory = diagnosticsEnablingAuditCategory.Any() ? diagnosticsEnablingAuditCategory : null;
            return true;
        }

        private void ValidateDatabaseInServiceTierForPolicy(string resourceGroupName, string serverName, string databaseName)
        {
            var dbCommunicator = new AzureSqlDatabaseCommunicator(Context);
            var database = dbCommunicator.Get(resourceGroupName, serverName, databaseName);

            if (!Enum.TryParse(database.Edition, true, out Database.Model.DatabaseEdition edition))
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture,
                    Properties.Resources.UnsupportedDatabaseEditionForAuditingPolicy, database.Edition));
            }

            if (edition == Database.Model.DatabaseEdition.None || edition == Database.Model.DatabaseEdition.Free)
            {
                throw new Exception(Properties.Resources.DatabaseNotInServiceTierForAuditingPolicy);
            }
        }

        private void PolicizeAuditModel(ServerAuditModel model, dynamic policy)
        {
            policy.State = model.BlobStorageTargetState == AuditStateType.Enabled ||
                           model.EventHubTargetState == AuditStateType.Enabled ||
                           model.LogAnalyticsTargetState == AuditStateType.Enabled ?
                           BlobAuditingPolicyState.Enabled : BlobAuditingPolicyState.Disabled;

            policy.IsAzureMonitorTargetEnabled = model.IsAzureMonitorTargetEnabled;
            if (model is DatabaseAuditModel dbModel)
            {
                policy.AuditActionsAndGroups = ExtractAuditActionsAndGroups(dbModel.AuditActionGroup, dbModel.AuditAction);
            }
            else
            {
                policy.AuditActionsAndGroups = ExtractAuditActionsAndGroups(model.AuditActionGroup);
            }

            if (model.BlobStorageTargetState == AuditStateType.Enabled)
            {
                PolicizeStorageInfo(model, policy);
            }
        }

        private void PolicizeStorageInfo(ServerAuditModel model, dynamic policy)
        {
            ExtractStorageAccountProperties(model.StorageAccountResourceId, out string storageAccountName, out Guid storageAccountSubscriptionId);
            policy.StorageEndpoint = GetStorageAccountEndpoint(storageAccountName);
            policy.StorageAccountSubscriptionId = storageAccountSubscriptionId;

            if (AzureCommunicator.IsStorageAccountInVNet(model.StorageAccountResourceId))
            {
                Guid? principalId = Communicator.AssignServerIdentityIfNotAssigned(model.ResourceGroupName, model.ServerName);
                AzureCommunicator.AssignRoleForServerIdentityOnStorageIfNotAssigned(model.StorageAccountResourceId, principalId.Value, RoleAssignmentId);
            }
            else
            {
                policy.IsStorageSecondaryKeyInUse = model.StorageKeyType == StorageKeyKind.Secondary;
                policy.StorageAccountAccessKey = AzureCommunicator.RetrieveStorageKeysAsync(
                    model.StorageAccountResourceId).GetAwaiter().GetResult()[model.StorageKeyType == StorageKeyKind.Secondary ? StorageKeyKind.Secondary : StorageKeyKind.Primary];
            }

            if (model.RetentionInDays != null)
            {
                policy.RetentionDays = (int)model.RetentionInDays;
            }
        }

        private void ExtractStorageAccountProperties(string storageAccountResourceId, out string storageAccountName, out Guid storageAccountSubscriptionId)
        {
            const string separator = "subscriptions/";
            storageAccountResourceId = storageAccountResourceId.Substring(storageAccountResourceId.IndexOf(separator) + separator.Length);
            string[] segments = storageAccountResourceId.Split('/');
            storageAccountSubscriptionId = Guid.Parse(segments[0]);
            storageAccountName = segments[6];
        }

        private static IList<string> ExtractAuditActionsAndGroups(AuditActionGroups[] auditActionGroup, string[] auditAction = null)
        {
            var actionsAndGroups = new List<string>();
            if (auditAction != null)
            {
                actionsAndGroups.AddRange(auditAction);
            }

            auditActionGroup.ToList().ForEach(aag => actionsAndGroups.Add(aag.ToString()));
            if (actionsAndGroups.Count == 0) // default audit actions and groups in case nothing was defined by the user
            {
                actionsAndGroups.Add("SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP");
                actionsAndGroups.Add("FAILED_DATABASE_AUTHENTICATION_GROUP");
                actionsAndGroups.Add("BATCH_COMPLETED_GROUP");
            }

            return actionsAndGroups;
        }

        /// <summary>
        /// Extracts the storage account name from the given model
        /// </summary>
        private string GetStorageAccountEndpoint(string storageAccountName)
        {
            return string.Format("https://{0}.blob.{1}", storageAccountName, Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix));
        }

        internal void PersistAuditChanges(ServerAuditModel model)
        {
            VerifyAuditBeforePersistChanges(model);

            DiagnosticSettingsResource currentSettings = model.DiagnosticsEnablingAuditCategory?.FirstOrDefault();
            if (currentSettings == null)
            {
                ChangeAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);
            }
            else
            {
                ChangeAuditWhenDiagnosticsEnablingAuditCategoryExist(model, currentSettings);
            }
        }

        internal void RemoveAuditingSettings(ServerAuditModel model)
        {
            model.BlobStorageTargetState = AuditStateType.Disabled;
            model.EventHubTargetState = AuditStateType.Disabled;
            model.LogAnalyticsTargetState = AuditStateType.Disabled;

            DisableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);

            Exception exception = null;
            while (model.DiagnosticsEnablingAuditCategory != null &&
                model.DiagnosticsEnablingAuditCategory.Any())
            {
                DiagnosticSettingsResource settings = model.DiagnosticsEnablingAuditCategory.First();
                if (IsAnotherCategoryEnabled(settings))
                {
                    if (DisableAuditCategory(model, settings) == false)
                    {
                        exception = DefinitionsCommon.UpdateDiagnosticSettingsException;
                    }
                }
                else
                {
                    if (RemoveFirstDiagnosticSettings(model) == false)
                    {
                        exception = DefinitionsCommon.RemoveDiagnosticSettingsException;
                    }
                }
            }

            if (exception != null)
            {
                throw exception;
            }
        }

        private void ChangeAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(
            ServerAuditModel model)
        {
            if (model.EventHubTargetState == AuditStateType.Enabled ||
                model.LogAnalyticsTargetState == AuditStateType.Enabled)
            {
                EnableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);
            }
            else
            {
                DisableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);
            }
        }

        private void EnableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(
            ServerAuditModel model)
        {
            if (CreateDiagnosticSettings(
                model.EventHubTargetState == AuditStateType.Enabled ?
                model.EventHubName : null,
                model.EventHubTargetState == AuditStateType.Enabled ?
                model.EventHubAuthorizationRuleResourceId : null,
                model.LogAnalyticsTargetState == AuditStateType.Enabled ?
                model.WorkspaceResourceId : null,
                model) == false)
            {
                throw DefinitionsCommon.CreateDiagnosticSettingsException;
            }

            try
            {
                model.IsAzureMonitorTargetEnabled = true;
                if (CreateOrUpdateAudit(model) == false)
                {
                    throw DefinitionsCommon.SetAuditingSettingsException;
                }
            }
            catch (Exception)
            {
                try
                {
                    RemoveFirstDiagnosticSettings(model);
                }
                catch (Exception) { }

                throw;
            }
        }

        private void DisableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(
            ServerAuditModel model)
        {
            model.IsAzureMonitorTargetEnabled = null;
            if (CreateOrUpdateAudit(model) == false)
            {
                throw DefinitionsCommon.SetAuditingSettingsException;
            }
        }

        private void ChangeAuditWhenDiagnosticsEnablingAuditCategoryExist(
            ServerAuditModel model,
            DiagnosticSettingsResource settings)
        {
            if (IsAnotherCategoryEnabled(settings))
            {
                ChangeAuditWhenMultipleCategoriesAreEnabled(model, settings);
            }
            else
            {
                ChangeAuditWhenOnlyAuditCategoryIsEnabled(model, settings);
            }
        }

        private void ChangeAuditWhenMultipleCategoriesAreEnabled(
            ServerAuditModel model,
            DiagnosticSettingsResource settings)
        {
            if (DisableAuditCategory(model, settings) == false)
            {
                throw DefinitionsCommon.UpdateDiagnosticSettingsException;
            }

            try
            {
                ChangeAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);
            }
            catch (Exception)
            {
                try
                {
                    EnableAuditCategory(model, settings);
                }
                catch (Exception) { }

                throw;
            }
        }

        private void ChangeAuditWhenOnlyAuditCategoryIsEnabled(
            ServerAuditModel model,
            DiagnosticSettingsResource settings)
        {
            string oldEventHubName = settings.EventHubName;
            string oldEventHubAuthorizationRuleId = settings.EventHubAuthorizationRuleId;
            string oldWorkspaceId = settings.WorkspaceId;

            if (model.EventHubTargetState == AuditStateType.Enabled ||
                model.LogAnalyticsTargetState == AuditStateType.Enabled)
            {
                EnableDiagnosticsAuditWhenOnlyAuditCategoryIsEnabled(model, settings, oldEventHubName, oldEventHubAuthorizationRuleId, oldWorkspaceId);
            }
            else
            {
                DisableDiagnosticsAuditWhenOnlyAuditCategoryIsEnabled(model, settings, oldEventHubName, oldEventHubAuthorizationRuleId, oldWorkspaceId);
            }
        }

        private void EnableDiagnosticsAuditWhenOnlyAuditCategoryIsEnabled(
            ServerAuditModel model,
            DiagnosticSettingsResource settings,
            string oldEventHubName,
            string oldEventHubAuthorizationRuleId,
            string oldWorkspaceId)
        {
            settings.EventHubName = model.EventHubTargetState == AuditStateType.Enabled ?
                model.EventHubName : null;
            settings.EventHubAuthorizationRuleId = model.EventHubTargetState == AuditStateType.Enabled ?
                model.EventHubAuthorizationRuleResourceId : null;
            settings.WorkspaceId = model.LogAnalyticsTargetState == AuditStateType.Enabled ?
                model.WorkspaceResourceId : null;

            if (UpdateDiagnosticSettings(settings, model) == false)
            {
                throw DefinitionsCommon.UpdateDiagnosticSettingsException;
            }

            try
            {
                model.IsAzureMonitorTargetEnabled = true;
                if (CreateOrUpdateAudit(model) == false)
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
                    UpdateDiagnosticSettings(settings, model);
                }
                catch (Exception) { }

                throw;
            }
        }

        private void DisableDiagnosticsAuditWhenOnlyAuditCategoryIsEnabled(
            ServerAuditModel model,
            DiagnosticSettingsResource settings,
            string oldEventHubName,
            string oldEventHubAuthorizationRuleId,
            string oldWorkspaceId)
        {
            if (RemoveFirstDiagnosticSettings(model) == false)
            {
                throw DefinitionsCommon.RemoveDiagnosticSettingsException;
            }

            try
            {
                DisableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);
            }
            catch (Exception)
            {
                try
                {
                    CreateDiagnosticSettings(oldEventHubName, oldEventHubAuthorizationRuleId, oldWorkspaceId, model);
                }
                catch (Exception) { }

                throw;
            }
        }

        private bool SetAuditCategoryState(
            dynamic model,
            DiagnosticSettingsResource settings,
            bool isEnabled)
        {
            var log = settings?.Logs?.FirstOrDefault(l => string.Equals(l.Category, DefinitionsCommon.SQLSecurityAuditCategory));
            if (log != null)
            {
                log.Enabled = isEnabled;
            }

            return UpdateDiagnosticSettings(settings, model);
        }

        internal bool EnableAuditCategory(
            dynamic model,
            DiagnosticSettingsResource settings)
        {
            return SetAuditCategoryState(model, settings, true);
        }

        internal bool DisableAuditCategory(
            dynamic model,
            DiagnosticSettingsResource settings)
        {
            return SetAuditCategoryState(model, settings, false);
        }

        private void VerifyAuditBeforePersistChanges(ServerAuditModel model)
        {
            if (model.BlobStorageTargetState == AuditStateType.Enabled &&
                string.IsNullOrEmpty(model.StorageAccountResourceId))
            {
                throw DefinitionsCommon.StorageAccountNameParameterException;
            }

            if (model.EventHubTargetState == AuditStateType.Enabled &&
                string.IsNullOrEmpty(model.EventHubAuthorizationRuleResourceId))
            {
                throw DefinitionsCommon.EventHubAuthorizationRuleResourceIdParameterException;
            }

            if (model.LogAnalyticsTargetState == AuditStateType.Enabled &&
                string.IsNullOrEmpty(model.WorkspaceResourceId))
            {
                throw DefinitionsCommon.WorkspaceResourceIdParameterException;
            }

            if (model.DiagnosticsEnablingAuditCategory != null && model.DiagnosticsEnablingAuditCategory.Count > 1)
            {
                throw DefinitionsCommon.MultipleDiagnosticsException;
            }
        }

        internal static bool IsAnotherCategoryEnabled(DiagnosticSettingsResource settings)
        {
            return settings.Logs.FirstOrDefault(l => l.Enabled &&
                !string.Equals(l.Category, DefinitionsCommon.SQLSecurityAuditCategory)) != null ||
                settings.Metrics.FirstOrDefault(m => m.Enabled) != null;
        }
    }
}
