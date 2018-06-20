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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

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
        /// Caching the fetched storage account name to prevent costly network interaction in cases it is not needed
        /// </summary>
        private string FetchedStorageAccountName { get; set; }

        /// <summary>
        /// Caching the fetched storage account resource group to prevent costly network interaction in cases it is not needed
        /// </summary>
        private string FetchedStorageAccountResourceGroup { get; set; }

        /// <summary>
        /// Caching the fetched storage account subscription to prevent costly network interaction in cases it is not needed
        /// </summary>
        private string FetchedStorageAccountSubscription { get; set; }

        /// <summary>
        /// Caching the fetched storage account table name to prevent costly network interaction in cases it is not needed
        /// </summary>
        private string FetchedStorageAccountTableEndpoint { get; set; }


        /// <summary>
        /// In cases when storage is not needed and not provided, there's no need to perform storage related network interaction that may fail
        /// </summary>
        public bool IgnoreStorage { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public SqlAuditAdapter(IAzureContext context)
        {
            Context = context;
            Subscription = context.Subscription;
            Communicator = new AuditingEndpointsCommunicator(Context);
            AzureCommunicator = new AzureEndpointsCommunicator(Context);
            IgnoreStorage = false;
        }

        /// <summary>
        /// Returns the storage account name of the given database server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to which the server belongs</param>
        /// <param name="serverName">The server's name</param>
        /// <param name="requestId">The Id to use in the request</param>
        /// <returns>The name of the storage account, null if it doesn't exist</returns>
        public string GetServerStorageAccount(string resourceGroupName, string serverName)
        {
            ServerAuditingPolicy policy;
            Communicator.GetServerAuditingPolicy(resourceGroupName, serverName, out policy);
            return policy.Properties.StorageAccountName;
        }

        /// <summary>
        /// Provides a database audit policy model for the given database
        /// </summary>
        public void GetDatabaseAuditingPolicy(string resourceGroup, string serverName, string databaseName, out DatabaseAuditingPolicyModel model)
        {
            DatabaseAuditingPolicy policy;
            Communicator.GetDatabaseAuditingPolicy(resourceGroup, serverName, databaseName, out policy);
            var dbPolicyModel = ModelizeDatabaseAuditPolicy(policy);
            dbPolicyModel.AuditType = AuditType.Table;
            dbPolicyModel.ResourceGroupName = resourceGroup;
            dbPolicyModel.ServerName = serverName;
            dbPolicyModel.DatabaseName = databaseName;

            FetchedStorageAccountName = policy.Properties.StorageAccountName;
            FetchedStorageAccountResourceGroup = policy.Properties.StorageAccountResourceGroupName;
            FetchedStorageAccountSubscription = policy.Properties.StorageAccountSubscriptionId;
            FetchedStorageAccountTableEndpoint = policy.Properties.StorageTableEndpoint;

            model = dbPolicyModel;
        }

        /// <summary>
        /// Provides a database audit policy model for the given database
        /// </summary>
        public void GetDatabaseAuditingPolicy(string resourceGroup, string serverName, string databaseName, out DatabaseBlobAuditingPolicyModel model)
        {
            BlobAuditingPolicy policy;
            Communicator.GetDatabaseAuditingPolicy(resourceGroup, serverName, databaseName, out policy);
            model = new DatabaseBlobAuditingPolicyModel();
            ModelizeDatabaseAuditPolicy(policy, model);
            model.AuditType = AuditType.Blob;
            model.ResourceGroupName = resourceGroup;
            model.ServerName = serverName;
            model.DatabaseName = databaseName;
        }

        /// <summary>
        /// Provides a database audit policy model for the given database
        /// </summary>
        public void GetDatabaseBlobAuditingPolicyV2(string resourceGroup, string serverName, string databaseName, out DatabaseBlobAuditingSettingsModel model)
        {
            BlobAuditingPolicy policy;
            model = new DatabaseBlobAuditingSettingsModel();
            Communicator.GetDatabaseAuditingPolicy(resourceGroup, serverName, databaseName, out policy);
            ModelizeDatabaseAuditPolicy(policy, model);
            model.ResourceGroupName = resourceGroup;
            model.ServerName = serverName;
            model.DatabaseName = databaseName;
        }

        /// <summary>
        /// Provides a database server audit policy model for the given database
        /// </summary>
        public void GetServerBlobAuditingPolicyV2(string resourceGroup, string serverName, out ServerBlobAuditingSettingsModel model)
        {
            BlobAuditingPolicy policy;
            model = new ServerBlobAuditingSettingsModel();
            Communicator.GetServerAuditingPolicy(resourceGroup, serverName, out policy);
            ModelizeServerAuditPolicy(policy, model);
            model.ResourceGroupName = resourceGroup;
            model.ServerName = serverName;
        }

        /// <summary>
        /// Provides a database server audit policy model for the given database
        /// </summary>
        public void GetServerAuditingPolicy(string resourceGroup, string serverName, out ServerAuditingPolicyModel model)
        {
            ServerAuditingPolicy policy;
            Communicator.GetServerAuditingPolicy(resourceGroup, serverName, out policy);
            var serverPolicyModel = ModelizeServerAuditPolicy(policy);
            serverPolicyModel.AuditType = AuditType.Table;
            serverPolicyModel.ResourceGroupName = resourceGroup;
            serverPolicyModel.ServerName = serverName;

            FetchedStorageAccountName = policy.Properties.StorageAccountName;
            FetchedStorageAccountResourceGroup = policy.Properties.StorageAccountResourceGroupName;
            FetchedStorageAccountSubscription = policy.Properties.StorageAccountSubscriptionId;
            FetchedStorageAccountTableEndpoint = policy.Properties.StorageTableEndpoint;

            model = serverPolicyModel;
        }

        /// <summary>
        /// Provides a database server audit policy model for the given database
        /// </summary>
        public void GetServerAuditingPolicy(string resourceGroup, string serverName, out ServerBlobAuditingPolicyModel model)
        {
            BlobAuditingPolicy policy;
            model = new ServerBlobAuditingPolicyModel();
            Communicator.GetServerAuditingPolicy(resourceGroup, serverName, out policy);
            ModelizeServerAuditPolicy(policy, model);
            model.AuditType = AuditType.Blob;
            model.ResourceGroupName = resourceGroup;
            model.ServerName = serverName;
        }

        /// <summary>
        /// Transforms the given database policy object to its cmdlet model representation
        /// </summary>
        private DatabaseAuditingPolicyModel ModelizeDatabaseAuditPolicy(DatabaseAuditingPolicy policy)
        {
            var dbPolicyModel = new DatabaseAuditingPolicyModel();
            var properties = policy.Properties;
            dbPolicyModel.AuditState = ModelizeAuditState(properties.AuditingState);
            dbPolicyModel.UseServerDefault = properties.UseServerDefault == SecurityConstants.AuditingEndpoint.Enabled ? UseServerDefaultOptions.Enabled : UseServerDefaultOptions.Disabled;
            ModelizeStorageInfo(dbPolicyModel, properties.StorageAccountName, properties.StorageAccountKey, properties.StorageAccountSecondaryKey);
            ModelizeEventTypesInfo(dbPolicyModel, properties.EventTypesToAudit);
            ModelizeRetentionInfo(dbPolicyModel, properties.RetentionDays, properties.AuditLogsTableName, properties.FullAuditLogsTableName);
            return dbPolicyModel;
        }

        private void ModelizeDatabaseAuditPolicy(BlobAuditingPolicy policy, DatabaseBlobAuditingSettingsModel dbPolicyModel)
        {
            var properties = policy.Properties;
            dbPolicyModel.AuditState = ModelizeAuditState(properties.State);
            ModelizeStorageInfo(dbPolicyModel, properties.StorageEndpoint, properties.IsStorageSecondaryKeyInUse, properties.StorageAccountSubscriptionId);
            ModelizeAuditActionGroups(dbPolicyModel, properties.AuditActionsAndGroups);
            ModelizeAuditActions(dbPolicyModel, properties.AuditActionsAndGroups);
            ModelizeRetentionInfo(dbPolicyModel, properties.RetentionDays);
        }

        private void ModelizeAuditActionGroups(BaseBlobAuditingPolicyModel policyModel, IEnumerable<string> auditActionsAndGroups)
        {
            var groups = new List<AuditActionGroups>();
            auditActionsAndGroups.ForEach(item =>
            {
                AuditActionGroups group;
                if (Enum.TryParse(item, true, out group))
                {
                    groups.Add(group);
                }
            });
            policyModel.AuditActionGroup = groups.ToArray();
        }

        private void ModelizeAuditActions(DatabaseBlobAuditingSettingsModel policyModel, IEnumerable<string> auditActionsAndGroups)
        {
            var actions = new List<string>();
            auditActionsAndGroups.ForEach(item =>
            {
                AuditActionGroups group;
                if (!Enum.TryParse(item, true, out group))
                {
                    actions.Add(item);
                }
            });
            policyModel.AuditAction = actions.ToArray();
        }

        private void ModelizeRetentionInfo(BaseBlobAuditingPolicyModel model, int retentionDays)
        {
            model.RetentionInDays = Convert.ToUInt32(retentionDays);
        }

        private static void ModelizeStorageInfo(BaseBlobAuditingPolicyModel model, string storageEndpoint, bool isSecondary, string storageAccountSubscriptionId)
        {
            if (string.IsNullOrEmpty(storageEndpoint))
            {
                return;
            }
            var accountNameStartIndex = storageEndpoint.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase)? 8 : 7; // https:// or http://
            var accountNameEndIndex = storageEndpoint.IndexOf(".blob", StringComparison.InvariantCultureIgnoreCase);
            model.StorageAccountName = storageEndpoint.Substring(accountNameStartIndex, accountNameEndIndex- accountNameStartIndex);
            model.StorageKeyType = (isSecondary) ? StorageKeyKind.Secondary : StorageKeyKind.Primary;
            model.StorageAccountSubscriptionId = Guid.Parse(storageAccountSubscriptionId);
        }

        /// <summary>
        /// Transforms the given server policy object to its cmdlet model representation
        /// </summary>
        private ServerAuditingPolicyModel ModelizeServerAuditPolicy(ServerAuditingPolicy policy)
        {
            var serverPolicyModel = new ServerAuditingPolicyModel();
            var properties = policy.Properties;
            serverPolicyModel.AuditState = ModelizeAuditState(properties.AuditingState);
            ModelizeStorageInfo(serverPolicyModel, properties.StorageAccountName, properties.StorageAccountKey, properties.StorageAccountSecondaryKey);
            ModelizeEventTypesInfo(serverPolicyModel, properties.EventTypesToAudit);
            ModelizeRetentionInfo(serverPolicyModel, properties.RetentionDays, properties.AuditLogsTableName, properties.FullAuditLogsTableName);
            return serverPolicyModel;
        }

        /// <summary>
        /// Transforms the given server policy object to its cmdlet model representation
        /// </summary>
        private void ModelizeServerAuditPolicy(BlobAuditingPolicy policy, ServerBlobAuditingSettingsModel serverPolicyModel)
        {
            var properties = policy.Properties;
            serverPolicyModel.AuditState = ModelizeAuditState(properties.State);
            ModelizeStorageInfo(serverPolicyModel, properties.StorageEndpoint, properties.IsStorageSecondaryKeyInUse, properties.StorageAccountSubscriptionId);
            ModelizeAuditActionGroups(serverPolicyModel, properties.AuditActionsAndGroups);
            ModelizeRetentionInfo(serverPolicyModel, properties.RetentionDays);
        }

        /// <summary>
        /// Transforms the given policy state in a string form to its cmdlet model representation
        /// </summary>
        private static AuditStateType ModelizeAuditState(string auditState)
        {
            AuditStateType value;
            Enum.TryParse(auditState, true, out value);           
            return value;
        }

        /// <summary>
        /// Updates the content of the model object with all the storage related information
        /// </summary>
        private static void ModelizeStorageInfo(BaseTableAuditingPolicyModel model, string accountName, string primary, string secondary)
        {
            model.StorageAccountName = accountName;
            if (!string.IsNullOrEmpty(secondary))
            {
                model.StorageKeyType = StorageKeyKind.Secondary;
            }
            else
            {
                model.StorageKeyType = StorageKeyKind.Primary;
            }
        }

        /// <summary>
        /// Updates the given model with all the event types information
        /// </summary>
        private static void ModelizeEventTypesInfo(BaseTableAuditingPolicyModel model, string eventTypesToAudit)
        {
            HashSet<AuditEventType> events = new HashSet<AuditEventType>();
            if (eventTypesToAudit != null)
            {
                if (eventTypesToAudit.IndexOf(SecurityConstants.PlainSQL_Success) != -1) events.Add(AuditEventType.PlainSQL_Success);
                if (eventTypesToAudit.IndexOf(SecurityConstants.PlainSQL_Failure) != -1) events.Add(AuditEventType.PlainSQL_Failure);
                if (eventTypesToAudit.IndexOf(SecurityConstants.ParameterizedSQL_Success) != -1) events.Add(AuditEventType.ParameterizedSQL_Success);
                if (eventTypesToAudit.IndexOf(SecurityConstants.ParameterizedSQL_Failure) != -1) events.Add(AuditEventType.ParameterizedSQL_Failure);
                if (eventTypesToAudit.IndexOf(SecurityConstants.StoredProcedure_Success) != -1) events.Add(AuditEventType.StoredProcedure_Success);
                if (eventTypesToAudit.IndexOf(SecurityConstants.StoredProcedure_Failure) != -1) events.Add(AuditEventType.StoredProcedure_Failure);
                if (eventTypesToAudit.IndexOf(SecurityConstants.Login_Success) != -1) events.Add(AuditEventType.Login_Success);
                if (eventTypesToAudit.IndexOf(SecurityConstants.Login_Failure) != -1) events.Add(AuditEventType.Login_Failure);
                if (eventTypesToAudit.IndexOf(SecurityConstants.TransactionManagement_Success) != -1) events.Add(AuditEventType.TransactionManagement_Success);
                if (eventTypesToAudit.IndexOf(SecurityConstants.TransactionManagement_Failure) != -1) events.Add(AuditEventType.TransactionManagement_Failure);
            }

            model.EventType = events.ToArray();
        }

        /// <summary>
        /// Updates the content of the model object with all the retention information
        /// </summary>
        private static void ModelizeRetentionInfo(BaseTableAuditingPolicyModel model, string retentionDays, string auditLogsTableName, string fullAuditLogsTableName)
        {
            model.TableIdentifier = auditLogsTableName;
            model.FullAuditLogsTableName = fullAuditLogsTableName;
            uint retentionDaysForModel;
            if (!(uint.TryParse(retentionDays, out retentionDaysForModel)))
            {
                retentionDaysForModel = 0;
            }
            model.RetentionInDays = retentionDaysForModel;
        }

        /// <summary>
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetDatabaseAuditingPolicy(DatabaseAuditingPolicyModel model, string storageEndpointSuffix)
        {
            if (!IsDatabaseInServiceTierForPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName))
            {
                throw new Exception(Properties.Resources.DatabaseNotInServiceTierForAuditingPolicy);
            }
            var parameters = PolicizeDatabaseAuditingModel(model, storageEndpointSuffix);
            Communicator.SetDatabaseAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, parameters);
        }

        /// <summary>
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetDatabaseAuditingPolicy(DatabaseBlobAuditingPolicyModel model, string storageEndpointSuffix)
        {
            if (!IsDatabaseInServiceTierForPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName))
            {
                throw new Exception(Properties.Resources.DatabaseNotInServiceTierForAuditingPolicy);
            }
            var parameters = PolicizeBlobAuditingModel(model, storageEndpointSuffix);
            Communicator.SetDatabaseAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, parameters);
        }

        /// <summary>
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetServerAuditingPolicy(ServerAuditingPolicyModel model, string storageEndpointSuffix)
        {
            var parameters = PolicizeServerAuditingModel(model, storageEndpointSuffix);
            Communicator.SetServerAuditingPolicy(model.ResourceGroupName, model.ServerName, parameters);
        }


        /// <summary>
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetDatabaseBlobAuditingPolicyV2(DatabaseBlobAuditingSettingsModel model, string storageEndpointSuffix)
        {
            if (!IsDatabaseInServiceTierForPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName))
            {
                throw new Exception(Properties.Resources.DatabaseNotInServiceTierForAuditingPolicy);
            }
            var parameters = PolicizeBlobAuditingModel(model, storageEndpointSuffix);
            Communicator.SetDatabaseAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, parameters);
        }

        /// <summary>
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetServerAuditingPolicy(ServerBlobAuditingSettingsModel model, string storageEndpointSuffix)
        {
            var parameters = PolicizeBlobAuditingModel(model, storageEndpointSuffix);
            Communicator.SetServerAuditingPolicy(model.ResourceGroupName, model.ServerName, parameters);
        }


        private bool IsDatabaseInServiceTierForPolicy(string resourceGroupName, string serverName, string databaseName)
        {
            var dbCommunicator = new AzureSqlDatabaseCommunicator(Context);
            var database = dbCommunicator.Get(resourceGroupName, serverName, databaseName);
            DatabaseEdition edition;
            Enum.TryParse(database.Edition, true, out edition);
            if (edition != DatabaseEdition.None && edition != DatabaseEdition.Free)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The AuditingPolicy model object</param>
        /// <param name="storageEndpointSuffix">The suffix of the storage endpoint</param>
        /// <returns>The communication model object</returns>
        private DatabaseAuditingPolicyCreateOrUpdateParameters PolicizeDatabaseAuditingModel(DatabaseAuditingPolicyModel model, string storageEndpointSuffix)
        {
            var updateParameters = new DatabaseAuditingPolicyCreateOrUpdateParameters();
            var properties = new DatabaseAuditingPolicyProperties();
            updateParameters.Properties = properties;
            properties.AuditingState = model.AuditState.ToString();
            properties.UseServerDefault = (model.UseServerDefault == UseServerDefaultOptions.Enabled) ? SecurityConstants.AuditingEndpoint.Enabled : SecurityConstants.AuditingEndpoint.Disabled;
            properties.StorageAccountName = ExtractStorageAccountName(model);
            properties.StorageAccountResourceGroupName = ExtractStorageAccountResourceGroup(properties.StorageAccountName);
            properties.StorageAccountSubscriptionId = ExtractStorageAccountSubscriptionId(properties.StorageAccountName);
            properties.StorageTableEndpoint = ExtractStorageAccountTableEndpoint(properties.StorageAccountName, storageEndpointSuffix);
            properties.StorageAccountKey = ExtractStorageAccountKey(properties.StorageAccountName, model, properties.StorageAccountResourceGroupName, StorageKeyKind.Primary);
            properties.StorageAccountSecondaryKey = ExtractStorageAccountKey(properties.StorageAccountName, model, properties.StorageAccountResourceGroupName, StorageKeyKind.Secondary);
            properties.EventTypesToAudit = ExtractEventTypes(model);
            properties.RetentionDays = model.RetentionInDays.ToString();
            properties.AuditLogsTableName = model.TableIdentifier;
            return updateParameters;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The AuditingPolicy model object</param>
        /// <param name="storageEndpointSuffix">The suffix of the storage endpoint</param>
        /// <returns>The communication model object</returns>
        private BlobAuditingCreateOrUpdateParameters PolicizeBlobAuditingModel(BaseBlobAuditingPolicyModel model, string storageEndpointSuffix)
        {
            var updateParameters = new BlobAuditingCreateOrUpdateParameters();
            var properties = new BlobAuditingProperties();
            updateParameters.Properties = properties;
            properties.State = model.AuditState.ToString();
            if (!IgnoreStorage && (model.AuditState == AuditStateType.Enabled))
            {
                properties.StorageEndpoint = ExtractStorageAccountName(model, storageEndpointSuffix);
                properties.StorageAccountAccessKey = Subscription.GetId().Equals(model.StorageAccountSubscriptionId) ?
                    ExtractStorageAccountKey(model.StorageAccountName, model.StorageKeyType) :
                    ExtractStorageAccountKey(model.StorageAccountSubscriptionId, model.StorageAccountName, model.StorageKeyType);
                properties.IsStorageSecondaryKeyInUse = model.StorageKeyType == StorageKeyKind.Secondary;
                properties.StorageAccountSubscriptionId = Subscription.GetId().Equals(model.StorageAccountSubscriptionId) ?
                    ExtractStorageAccountSubscriptionId(model.StorageAccountName) : model.StorageAccountSubscriptionId.ToString();
            }
            properties.AuditActionsAndGroups = ExtractAuditActionsAndGroups(model);
            if (model.RetentionInDays != null)
            {
                properties.RetentionDays = (int) model.RetentionInDays;
            }

            return updateParameters;
        }

        private static IList<string> ExtractAuditActionsAndGroups(BaseBlobAuditingPolicyModel model)
        {
            var dbPolicyModel = model as DatabaseBlobAuditingSettingsModel;
            var actionsAndGroups = new List<string>();
            if (dbPolicyModel != null)
            {
                actionsAndGroups.AddRange(dbPolicyModel.AuditAction);
            }
            
            model.AuditActionGroup.ToList().ForEach(aag => actionsAndGroups.Add(aag.ToString()));
            if (actionsAndGroups.Count == 0) // default audit actions and groups in case nothing was defined by the user
            {
                actionsAndGroups.Add("SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP");
                actionsAndGroups.Add("FAILED_DATABASE_AUTHENTICATION_GROUP");
                actionsAndGroups.Add("BATCH_COMPLETED_GROUP");
            }
            return actionsAndGroups;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The AuditingPolicy model object</param>
        /// <param name="storageEndpointSuffix">The suffix of the storage endpoint</param>
        /// <returns>The communication model object</returns>
        private ServerAuditingPolicyCreateOrUpdateParameters PolicizeServerAuditingModel(ServerAuditingPolicyModel model, string storageEndpointSuffix)
        {
            var updateParameters = new ServerAuditingPolicyCreateOrUpdateParameters();
            var properties = new ServerAuditingPolicyProperties();
            updateParameters.Properties = properties;
            properties.AuditingState = model.AuditState.ToString();
            properties.StorageAccountName = ExtractStorageAccountName(model);
            properties.StorageAccountResourceGroupName = ExtractStorageAccountResourceGroup(properties.StorageAccountName);
            properties.StorageAccountSubscriptionId = ExtractStorageAccountSubscriptionId(properties.StorageAccountName);
            properties.StorageTableEndpoint = ExtractStorageAccountTableEndpoint(properties.StorageAccountName, storageEndpointSuffix);
            properties.StorageAccountKey = ExtractStorageAccountKey(properties.StorageAccountName, model, properties.StorageAccountResourceGroupName, StorageKeyKind.Primary);
            properties.StorageAccountSecondaryKey = ExtractStorageAccountKey(properties.StorageAccountName, model, properties.StorageAccountResourceGroupName, StorageKeyKind.Secondary);
            properties.EventTypesToAudit = ExtractEventTypes(model);
            properties.RetentionDays = model.RetentionInDays.ToString();
            properties.AuditLogsTableName = model.TableIdentifier;
            return updateParameters;
        }

        /// <summary>
        /// Extracts the storage account name from the given model
        /// </summary>
        private static string ExtractStorageAccountName(BaseBlobAuditingPolicyModel model, string endpointSuffix)
        {
            return string.Format("https://{0}.blob.{1}", model.StorageAccountName, endpointSuffix);
        }

        /// <summary>
        /// Extracts the storage account name from the given model
        /// </summary>
        private string ExtractStorageAccountName(BaseTableAuditingPolicyModel model)
        {
            string storageAccountName;

            if (model.StorageAccountName == FetchedStorageAccountName) // the user provided the same storage account that was given before
            {
                storageAccountName = FetchedStorageAccountName;
            }
            else if (model.StorageAccountName == null) // the user did not provided storage account for a policy for which such account is already defined
            {
                storageAccountName = FetchedStorageAccountName;
            }
            else // the user updates the name of the storage account
            {
                storageAccountName = model.StorageAccountName;
            }
            if (string.IsNullOrEmpty(storageAccountName) && (!IgnoreStorage)) // can happen if the user didn't provide account name for a policy that lacked it 
            {
                throw new Exception(string.Format(Properties.Resources.NoStorageAccountWhenConfiguringAuditingPolicy));
            }
            return storageAccountName;
        }

        /// <summary>
        /// Extracts the event types from the given model
        /// </summary>
        private static string ExtractEventTypes(BaseTableAuditingPolicyModel model)
        {
            if (model.EventType == null)
            {
                return null;
            }

            if (model.EventType.Any(t => t == AuditEventType.None))
            {
                if (model.EventType.Count() == 1)
                {
                    return string.Empty;
                }
                if (model.EventType.Any(t => t != AuditEventType.None))
                {
                    throw new Exception(Properties.Resources.InvalidEventTypeSet);
                }
            }
            return string.Join(",", model.EventType.Select(t => t.ToString()));
        }

        /// <summary>
        /// Extracts the storage account endpoint
        /// </summary>
        private string ExtractStorageAccountTableEndpoint(string storageName, string endpointSuffix)
        {
            if (IgnoreStorage || (storageName == FetchedStorageAccountName && FetchedStorageAccountTableEndpoint != null))
            {
                return FetchedStorageAccountTableEndpoint;
            }
            return string.Format("https://{0}.table.{1}", storageName, endpointSuffix);
        }

        /// <summary>
        /// Extracts the storage account subscription id
        /// </summary>
        private string ExtractStorageAccountSubscriptionId(string storageName)
        {
            if (IgnoreStorage || (storageName == FetchedStorageAccountName && FetchedStorageAccountSubscription != null))
            {
                return FetchedStorageAccountSubscription;
            }
            return Subscription.Id.ToString();
        }

        /// <summary>
        /// Extracts the storage account resource group
        /// </summary>
        private string ExtractStorageAccountResourceGroup(string storageName)
        {
            if (IgnoreStorage || (storageName == FetchedStorageAccountName && FetchedStorageAccountResourceGroup != null))
            {
                return FetchedStorageAccountResourceGroup;
            }
            return AzureCommunicator.GetStorageResourceGroup(storageName);
        }

        private string ExtractStorageAccountKey(Guid storageAccountSubscriptionId, string storageAccountName, StorageKeyKind storageKeyKind)
        {
            return AzureCommunicator.RetrieveStorageKeys(storageAccountSubscriptionId, storageAccountName)[storageKeyKind];
        }

        /// <summary>
        /// Extracts the storage account requested key
        /// </summary>
        private string ExtractStorageAccountKey(string storageName, BaseTableAuditingPolicyModel model, string storageAccountResourceGroup, StorageKeyKind keyType)
        {
            if (!IgnoreStorage && (model.StorageKeyType == keyType))
            {
                return AzureCommunicator.GetStorageKeys(storageAccountResourceGroup, storageName)[keyType];
            }
            return null;
        }

        /// <summary>
        /// Extracts the storage account requested key
        /// </summary>
        private string ExtractStorageAccountKey(string storageName, StorageKeyKind storageKeyKind)
        {
                return AzureCommunicator.GetStorageKeys(storageName)[storageKeyKind];
        }

        internal void ClearStorageDetailsCache()
        {
            FetchedStorageAccountName = null;
            FetchedStorageAccountResourceGroup = null;
            FetchedStorageAccountSubscription = null;
            FetchedStorageAccountTableEndpoint = null;
        }
    }
}
