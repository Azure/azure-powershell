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

using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Sql.Database.Model;

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
        private AzureSubscription Subscription { get; set; }

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
        public AzureContext Context { get; set; }

        public SqlAuditAdapter(AzureContext context)
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
        public string GetServerStorageAccount(string resourceGroupName, string serverName, string requestId)
        {
            return Communicator.GetServerAuditingPolicy(resourceGroupName, serverName, requestId).Properties.StorageAccountName;
        }

        /// <summary>
        /// Provides a database audit policy model for the given database
        /// </summary>
        public DatabaseAuditingPolicyModel GetDatabaseAuditingPolicy(string resourceGroup, string serverName, string databaseName, string requestId)
        {
            DatabaseAuditingPolicy policy = Communicator.GetDatabaseAuditingPolicy(resourceGroup, serverName, databaseName, requestId);
            DatabaseAuditingPolicyModel dbPolicyModel = ModelizeDatabaseAuditPolicy(policy);
            dbPolicyModel.ResourceGroupName = resourceGroup;
            dbPolicyModel.ServerName = serverName;
            dbPolicyModel.DatabaseName = databaseName;

            FetchedStorageAccountName = policy.Properties.StorageAccountName;
            FetchedStorageAccountResourceGroup = policy.Properties.StorageAccountResourceGroupName;
            FetchedStorageAccountSubscription = policy.Properties.StorageAccountSubscriptionId;
            FetchedStorageAccountTableEndpoint = policy.Properties.StorageTableEndpoint;

            return dbPolicyModel;
        }

        /// <summary>
        /// Provides a database server audit policy model for the given database
        /// </summary>
        public ServerAuditingPolicyModel GetServerAuditingPolicy(string resourceGroup, string serverName, string requestId)
        {
            ServerAuditingPolicy policy = Communicator.GetServerAuditingPolicy(resourceGroup, serverName, requestId);
            ServerAuditingPolicyModel serverPolicyModel = ModelizeServerAuditPolicy(policy);
            serverPolicyModel.ResourceGroupName = resourceGroup;
            serverPolicyModel.ServerName = serverName;

            FetchedStorageAccountName = policy.Properties.StorageAccountName;
            FetchedStorageAccountResourceGroup = policy.Properties.StorageAccountResourceGroupName;
            FetchedStorageAccountSubscription = policy.Properties.StorageAccountSubscriptionId;
            FetchedStorageAccountTableEndpoint = policy.Properties.StorageTableEndpoint;

            return serverPolicyModel;
        }

        /// <summary>
        /// Transforms the given database policy object to its cmdlet model representation
        /// </summary>
        private DatabaseAuditingPolicyModel ModelizeDatabaseAuditPolicy(DatabaseAuditingPolicy policy)
        {
            DatabaseAuditingPolicyModel dbPolicyModel = new DatabaseAuditingPolicyModel();
            DatabaseAuditingPolicyProperties properties = policy.Properties;
            dbPolicyModel.AuditState = ModelizeAuditState(properties.AuditingState);
            dbPolicyModel.UseServerDefault = properties.UseServerDefault == SecurityConstants.AuditingEndpoint.Enabled ? UseServerDefaultOptions.Enabled : UseServerDefaultOptions.Disabled;
            ModelizeStorageInfo(dbPolicyModel, properties.StorageAccountName, properties.StorageAccountKey, properties.StorageAccountSecondaryKey);
            ModelizeEventTypesInfo(dbPolicyModel, properties.EventTypesToAudit);
            ModelizeRetentionInfo(dbPolicyModel, properties.RetentionDays, properties.AuditLogsTableName, properties.FullAuditLogsTableName);
            return dbPolicyModel;
        }

        /// <summary>
        /// Transforms the given server policy object to its cmdlet model representation
        /// </summary>
        private ServerAuditingPolicyModel ModelizeServerAuditPolicy(ServerAuditingPolicy policy)
        {
            ServerAuditingPolicyModel serverPolicyModel = new ServerAuditingPolicyModel();
            ServerAuditingPolicyProperties properties = policy.Properties;
            serverPolicyModel.AuditState = ModelizeAuditState(properties.AuditingState);
            ModelizeStorageInfo(serverPolicyModel, properties.StorageAccountName, properties.StorageAccountKey, properties.StorageAccountSecondaryKey);
            ModelizeEventTypesInfo(serverPolicyModel, properties.EventTypesToAudit);
            ModelizeRetentionInfo(serverPolicyModel, properties.RetentionDays, properties.AuditLogsTableName, properties.FullAuditLogsTableName);
            return serverPolicyModel;
        }

        /// <summary>
        /// Transforms the given policy state in a string form to its cmdlet model representation
        /// </summary>
        private AuditStateType ModelizeAuditState(string auditState)
        {
            if (auditState == SecurityConstants.AuditingEndpoint.New) return AuditStateType.New;
            if (auditState == SecurityConstants.AuditingEndpoint.Enabled) return AuditStateType.Enabled;
            return AuditStateType.Disabled;
        }

        /// <summary>
        /// Updates the content of the model object with all the storage related information
        /// </summary>
        private void ModelizeStorageInfo(BaseAuditingPolicyModel model, string accountName, string primary, string secondary)
        {
            model.StorageAccountName = accountName;
            if (!String.IsNullOrEmpty(secondary))
            {
                model.StorageKeyType = StorageKeyKind.Secondary;
            }
            else
            {
                model.StorageKeyType = StorageKeyKind.Primary;
            }
        }

        /// <summary>
        /// Transforms the given policy state into a string representation
        /// </summary>
        private string PolicizeAuditState(AuditStateType auditState)
        {
            switch (auditState)
            {
                case AuditStateType.Enabled:
                    return SecurityConstants.AuditingEndpoint.Enabled;
                case AuditStateType.New:
                    return SecurityConstants.AuditingEndpoint.New;
                case AuditStateType.Disabled:
                default:
                    return SecurityConstants.AuditingEndpoint.Disabled;
            }
        }

        /// <summary>
        /// Updates the given model with all the event types information
        /// </summary>
        private void ModelizeEventTypesInfo(BaseAuditingPolicyModel model, string eventTypesToAudit)
        {
            HashSet<AuditEventType> events = new HashSet<AuditEventType>();
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
            model.EventType = events.ToArray();
        }

        /// <summary>
        /// Updates the content of the model object with all the retention information
        /// </summary>
        private void ModelizeRetentionInfo(BaseAuditingPolicyModel model, string retentionDays, string auditLogsTableName, string fullAuditLogsTableName)
        {
            model.TableIdentifier = auditLogsTableName;
            model.FullAuditLogsTableName = fullAuditLogsTableName;
            uint retentionDaysForModel;
            if (!(UInt32.TryParse(retentionDays, out retentionDaysForModel)))
            {
                retentionDaysForModel = 0;
            }
            model.RetentionInDays = retentionDaysForModel;
        }

        /// <summary>
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetServerAuditingPolicy(ServerAuditingPolicyModel model, String clientId, string storageEndpointSuffix)
        {
            ServerAuditingPolicyCreateOrUpdateParameters parameters = PolicizeServerAuditingModel(model, storageEndpointSuffix);
            Communicator.SetServerAuditingPolicy(model.ResourceGroupName, model.ServerName, clientId, parameters);
        }

        /// <summary>
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetDatabaseAuditingPolicy(DatabaseAuditingPolicyModel model, String clientId, string storageEndpointSuffix)
        {
            if (!IsDatabaseInServiceTierForPolicy(model, clientId))
            {
                throw new Exception(Microsoft.Azure.Commands.Sql.Properties.Resources.DatabaseNotInServiceTierForAuditingPolicy);
            }
            DatabaseAuditingPolicyCreateOrUpdateParameters parameters = PolicizeDatabaseAuditingModel(model, storageEndpointSuffix);
            Communicator.SetDatabaseAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId, parameters);
        }

        private bool IsDatabaseInServiceTierForPolicy(DatabaseAuditingPolicyModel model, string clientId)
        {
            AzureSqlDatabaseCommunicator dbCommunicator = new AzureSqlDatabaseCommunicator(Context);
            Management.Sql.Models.Database database = dbCommunicator.Get(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId);
            DatabaseEdition edition = DatabaseEdition.None;
            Enum.TryParse<DatabaseEdition>(database.Properties.Edition, true, out edition);
            if (edition == DatabaseEdition.Basic || edition == DatabaseEdition.Standard || edition == DatabaseEdition.Premium || edition == DatabaseEdition.DataWarehouse)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The AuditingPolicy model object</param>
        /// <returns>The communication model object</returns>
        private DatabaseAuditingPolicyCreateOrUpdateParameters PolicizeDatabaseAuditingModel(DatabaseAuditingPolicyModel model, string storageEndpointSuffix)
        {
            DatabaseAuditingPolicyCreateOrUpdateParameters updateParameters = new DatabaseAuditingPolicyCreateOrUpdateParameters();
            DatabaseAuditingPolicyProperties properties = new DatabaseAuditingPolicyProperties();
            updateParameters.Properties = properties;
            properties.AuditingState = PolicizeAuditState(model.AuditState);
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
        /// <returns>The communication model object</returns>
        private ServerAuditingPolicyCreateOrUpdateParameters PolicizeServerAuditingModel(ServerAuditingPolicyModel model, string storageEndpointSuffix)
        {
            ServerAuditingPolicyCreateOrUpdateParameters updateParameters = new ServerAuditingPolicyCreateOrUpdateParameters();
            ServerAuditingPolicyProperties properties = new ServerAuditingPolicyProperties();
            updateParameters.Properties = properties;
            properties.AuditingState = PolicizeAuditState(model.AuditState);
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
        private string ExtractStorageAccountName(BaseAuditingPolicyModel model)
        {
            string storageAccountName = null;

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
                throw new Exception(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.NoStorageAccountWhenConfiguringAuditingPolicy));
            }
            return storageAccountName;
        }

        /// <summary>
        /// Extracts the event types from the given model
        /// </summary>
        private string ExtractEventTypes(BaseAuditingPolicyModel model)
        {
            if (model.EventType == null)
            {
                return null;
            }

            StringBuilder events = new StringBuilder();
            if (IsEventTypeOn(AuditEventType.PlainSQL_Success, model.EventType))
            {
                events.Append(SecurityConstants.AuditingEndpoint.PlainSQL_Success).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.PlainSQL_Failure, model.EventType))
            {
                events.Append(SecurityConstants.AuditingEndpoint.PlainSQL_Failure).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.ParameterizedSQL_Success, model.EventType))
            {
                events.Append(SecurityConstants.AuditingEndpoint.ParameterizedSQL_Success).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.ParameterizedSQL_Failure, model.EventType))
            {
                events.Append(SecurityConstants.AuditingEndpoint.ParameterizedSQL_Failure).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.StoredProcedure_Success, model.EventType))
            {
                events.Append(SecurityConstants.AuditingEndpoint.StoredProcedure_Success).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.StoredProcedure_Failure, model.EventType))
            {
                events.Append(SecurityConstants.AuditingEndpoint.StoredProcedure_Failure).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.Login_Success, model.EventType))
            {
                events.Append(SecurityConstants.AuditingEndpoint.Login_Success).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.Login_Failure, model.EventType))
            {
                events.Append(SecurityConstants.AuditingEndpoint.Login_Failure).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.TransactionManagement_Success, model.EventType))
            {
                events.Append(SecurityConstants.AuditingEndpoint.TransactionManagement_Success).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.TransactionManagement_Failure, model.EventType))
            {
                events.Append(SecurityConstants.AuditingEndpoint.TransactionManagement_Failure).Append(",");
            }
            if (events.Length != 0)
            {
                events.Remove(events.Length - 1, 1); // remove trailing comma
            }
            return events.ToString();
        }

        /// <summary>
        /// Checks whether the given event type was used
        /// </summary>
        private bool IsEventTypeOn(AuditEventType lookedForType, AuditEventType[] userSelectedTypes)
        {
            if (userSelectedTypes.Contains(lookedForType))
            {
                return true;
            }
            return false;
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

        /// <summary>
        /// Extracts the storage account requested key
        /// </summary>
        private string ExtractStorageAccountKey(string storageName, BaseAuditingPolicyModel model, string storageAccountResourceGroup, StorageKeyKind keyType)
        {
            if (IgnoreStorage || (model.StorageKeyType == keyType))
            {
                return AzureCommunicator.GetStorageKeys(storageAccountResourceGroup, storageName)[keyType];
            }
            return null;
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