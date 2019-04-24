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

        public SqlAuditAdapter(IAzureContext context)
        {
            Context = context;
            Subscription = context?.Subscription;
            Communicator = new AuditingEndpointsCommunicator(Context);
            AzureCommunicator = new AzureEndpointsCommunicator(Context);
        }

        internal void GetAuditingSettings(
            string resourceGroup, string serverName, string databaseName,
            DatabaseBlobAuditingSettingsModel model)
        {
            ExtendedDatabaseBlobAuditingPolicy policy = Communicator.GetAuditingPolicy(resourceGroup, serverName, databaseName);
            ModelizeDatabaseAuditPolicy(model, policy);
            if (model is DatabaseDiagnosticAuditingSettingsModel diagnosticModel)
            {
                diagnosticModel.DiagnosticsEnablingAuditCategory =
                    Communicator.GetDiagnosticsEnablingAuditCategory(out string nextDiagnosticSettingsName,
                        resourceGroup, serverName, databaseName);
                diagnosticModel.NextDiagnosticSettingsName = nextDiagnosticSettingsName;
            }

            model.DetermineAuditState();
        }

        internal void GetAuditingSettings(
            string resourceGroup, string serverName, ServerBlobAuditingSettingsModel model)
        {
            ExtendedServerBlobAuditingPolicy policy = Communicator.GetAuditingPolicy(resourceGroup, serverName);
            ModelizeServerAuditPolicy(model, policy);
            if (model is ServerDiagnosticAuditingSettingsModel diagnosticModel)
            {
                diagnosticModel.DiagnosticsEnablingAuditCategory =
                    Communicator.GetDiagnosticsEnablingAuditCategory(out string nextDiagnosticSettingsName,
                        resourceGroup, serverName);
                diagnosticModel.NextDiagnosticSettingsName = nextDiagnosticSettingsName;
            }

            model.DetermineAuditState();
        }

        private void ModelizeAuditActionGroups(dynamic model, IEnumerable<string> auditActionsAndGroups)
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

            model.AuditActionGroup = groups.ToArray();
        }

        private void ModelizeAuditActions(DatabaseBlobAuditingSettingsModel model, IEnumerable<string> auditActionsAndGroups)
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

            model.AuditAction = actions.ToArray();
        }

        private void ModelizeRetentionInfo(dynamic model, int? retentionDays)
        {
            model.RetentionInDays = Convert.ToUInt32(retentionDays);
        }

        private static void ModelizeStorageInfo(dynamic model, string storageEndpoint, bool? isSecondary, Guid? storageAccountSubscriptionId)
        {
            if (string.IsNullOrEmpty(storageEndpoint))
            {
                return;
            }

            var accountNameStartIndex = storageEndpoint.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase) ? 8 : 7; // https:// or http://
            var accountNameEndIndex = storageEndpoint.IndexOf(".blob", StringComparison.InvariantCultureIgnoreCase);
            model.StorageAccountName = storageEndpoint.Substring(accountNameStartIndex, accountNameEndIndex - accountNameStartIndex);
            model.StorageKeyType = (isSecondary ?? false) ? StorageKeyKind.Secondary : StorageKeyKind.Primary;
            model.StorageAccountSubscriptionId = storageAccountSubscriptionId ?? Guid.Empty;
        }

        private void ModelizeServerAuditPolicy(ServerBlobAuditingSettingsModel model, ExtendedServerBlobAuditingPolicy policy)
        {
            model.IsGlobalAuditEnabled = policy.State == BlobAuditingPolicyState.Enabled;
            model.IsAzureMonitorTargetEnabled = policy.IsAzureMonitorTargetEnabled;
            model.PredicateExpression = policy.PredicateExpression;
            ModelizeAuditActionGroups(model, policy.AuditActionsAndGroups);
            ModelizeStorageInfo(model, policy.StorageEndpoint, policy.IsStorageSecondaryKeyInUse, policy.StorageAccountSubscriptionId);
            ModelizeRetentionInfo(model, policy.RetentionDays);
        }

        private void ModelizeDatabaseAuditPolicy(DatabaseBlobAuditingSettingsModel model, ExtendedDatabaseBlobAuditingPolicy policy)
        {
            model.IsGlobalAuditEnabled = policy.State == BlobAuditingPolicyState.Enabled;
            model.IsAzureMonitorTargetEnabled = policy.IsAzureMonitorTargetEnabled;
            model.PredicateExpression = policy.PredicateExpression;
            ModelizeAuditActionGroups(model, policy.AuditActionsAndGroups);
            ModelizeAuditActions(model, policy.AuditActionsAndGroups);
            ModelizeStorageInfo(model, policy.StorageEndpoint, policy.IsStorageSecondaryKeyInUse, policy.StorageAccountSubscriptionId);
            ModelizeRetentionInfo(model, policy.RetentionDays);
        }

        public bool SetAuditingPolicy(DatabaseBlobAuditingSettingsModel model)
        {
            if (!IsDatabaseInServiceTierForPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName))
            {
                throw new Exception(Properties.Resources.DatabaseNotInServiceTierForAuditingPolicy);
            }

            if (string.IsNullOrEmpty(model.PredicateExpression))
            {
                DatabaseBlobAuditingPolicy policy = new DatabaseBlobAuditingPolicy();
                PolicizeAuditingModel(model, policy);
                return Communicator.SetAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, policy);
            }
            else
            {
                ExtendedDatabaseBlobAuditingPolicy policy = new ExtendedDatabaseBlobAuditingPolicy
                {
                    PredicateExpression = model.PredicateExpression
                };

                PolicizeAuditingModel(model, policy);
                return Communicator.SetExtendedAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, policy);
            }
        }

        public bool SetAuditingPolicy(ServerBlobAuditingSettingsModel model)
        {
            if (string.IsNullOrEmpty(model.PredicateExpression))
            {
                var policy = new ServerBlobAuditingPolicy();
                PolicizeAuditingModel(model, policy);
                return Communicator.SetAuditingPolicy(model.ResourceGroupName, model.ServerName, policy);
            }
            else
            {
                var policy = new ExtendedServerBlobAuditingPolicy
                {
                    PredicateExpression = model.PredicateExpression
                };
                PolicizeAuditingModel(model, policy);
                return Communicator.SetAuditingPolicy(model.ResourceGroupName, model.ServerName, policy);
            }
        }

        internal bool CreateDiagnosticSettings(string eventHubName, string eventHubAuthorizationRuleId, string workspaceId,
            ServerBlobAuditingSettingsModel model)
        {
            DiagnosticSettingsResource settings = model is DatabaseBlobAuditingSettingsModel dbModel ?
                Communicator.CreateDiagnosticSettings(dbModel.NextDiagnosticSettingsName,
                eventHubName, eventHubAuthorizationRuleId, workspaceId,
                dbModel.ResourceGroupName, dbModel.ServerName, dbModel.DatabaseName) :
                Communicator.CreateDiagnosticSettings(model.NextDiagnosticSettingsName,
                eventHubName, eventHubAuthorizationRuleId, workspaceId,
                model.ResourceGroupName, model.ServerName);

            if (settings == null)
            {
                return false;
            }

            model.DiagnosticsEnablingAuditCategory = new List<DiagnosticSettingsResource> { settings };
            return true;
        }

        internal bool UpdateDiagnosticSettings(DiagnosticSettingsResource settings, ServerBlobAuditingSettingsModel model)
        {
            DiagnosticSettingsResource updatedSettings = model is DatabaseBlobAuditingSettingsModel dbModel ?
                Communicator.UpdateDiagnosticSettings(settings, dbModel.ResourceGroupName, dbModel.ServerName, dbModel.DatabaseName) :
                Communicator.UpdateDiagnosticSettings(settings, model.ResourceGroupName, model.ServerName);
            if (updatedSettings == null)
            {
                return false;
            }

            model.DiagnosticsEnablingAuditCategory = AuditingEndpointsCommunicator.IsAuditCategoryEnabled(updatedSettings) ?
                new List<DiagnosticSettingsResource> { updatedSettings } : null;
            return true;
        }

        internal bool RemoveDiagnosticSettings(ServerBlobAuditingSettingsModel model)
        {
            DiagnosticSettingsResource settings = model.DiagnosticsEnablingAuditCategory.FirstOrDefault();
            if (settings == null ||
                (model is DatabaseBlobAuditingSettingsModel dbModel ?
                Communicator.RemoveDiagnosticSettings(settings.Name, dbModel.ResourceGroupName, dbModel.ServerName, dbModel.DatabaseName) :
                Communicator.RemoveDiagnosticSettings(settings.Name, model.ResourceGroupName, model.ServerName)) == false)
            {
                return false;
            }

            model.DiagnosticsEnablingAuditCategory = null;
            return true;
        }

        private bool IsDatabaseInServiceTierForPolicy(string resourceGroupName, string serverName, string databaseName)
        {
            var dbCommunicator = new AzureSqlDatabaseCommunicator(Context);
            var database = dbCommunicator.Get(resourceGroupName, serverName, databaseName);
            Enum.TryParse(database.Edition, true, out Database.Model.DatabaseEdition edition);
            return edition != Database.Model.DatabaseEdition.None &&
                edition != Database.Model.DatabaseEdition.Free;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The AuditingPolicy model object</param>
        /// <param name="policy">The policy to be modified</param>
        /// <returns>The communication model object</returns>
        private void PolicizeAuditingModel(dynamic model, dynamic policy)
        {
            policy.State = model.IsGlobalAuditEnabled ? BlobAuditingPolicyState.Enabled : BlobAuditingPolicyState.Disabled;
            policy.IsAzureMonitorTargetEnabled = model.IsAzureMonitorTargetEnabled;
            policy.AuditActionsAndGroups = ExtractAuditActionsAndGroups(model);
            if (model.RetentionInDays != null)
            {
                policy.RetentionDays = (int)model.RetentionInDays;
            }

            if (model.AuditState == AuditStateType.Enabled && !string.IsNullOrEmpty(model.StorageAccountName))
            {
                string storageEndpointSuffix = Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix);
                policy.StorageEndpoint = ExtractStorageAccountName(model, storageEndpointSuffix);
                policy.StorageAccountAccessKey = Subscription.GetId().Equals(model.StorageAccountSubscriptionId) ?
                    ExtractStorageAccountKey(model.StorageAccountName, model.StorageKeyType) :
                    ExtractStorageAccountKey(model.StorageAccountSubscriptionId, model.StorageAccountName, model.StorageKeyType);
                policy.IsStorageSecondaryKeyInUse = model.StorageKeyType == StorageKeyKind.Secondary;
                policy.StorageAccountSubscriptionId = model.StorageAccountSubscriptionId;
            }
        }

        private static IList<string> ExtractAuditActionsAndGroups(dynamic model)
        {
            var actionsAndGroups = new List<string>();
            if (model is DatabaseBlobAuditingSettingsModel dbModel)
            {
                actionsAndGroups.AddRange(dbModel.AuditAction);
            }

            AuditActionGroups[] auditActionGroup = model.AuditActionGroup;
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
        private static string ExtractStorageAccountName(dynamic model, string endpointSuffix)
        {
            return string.Format("https://{0}.blob.{1}", model.StorageAccountName, endpointSuffix);
        }

        private string ExtractStorageAccountKey(Guid storageAccountSubscriptionId, string storageAccountName, StorageKeyKind storageKeyKind)
        {
            return AzureCommunicator.RetrieveStorageKeys(storageAccountSubscriptionId, storageAccountName)[storageKeyKind];
        }

        /// <summary>
        /// Extracts the storage account requested key
        /// </summary>
        private string ExtractStorageAccountKey(string storageName, StorageKeyKind storageKeyKind)
        {
            return AzureCommunicator.GetStorageKeys(storageName)[storageKeyKind];
        }
    }
}
