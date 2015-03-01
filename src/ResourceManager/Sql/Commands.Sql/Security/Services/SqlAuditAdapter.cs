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

using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Common.Extensions.Models;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.WindowsAzure.Management.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.Security.Services
{
    /// <summary>
    /// The SqlAuditClient class is resposible for transforming the data that was recevied form the ednpoints to the cmdlets model of auditing policy and vice versa
    /// </summary>
    public class SqlAuditAdapter
    {
        private AzureSubscription Subscription { get; set; }

        private AuditingEndpointsCommunicator Communicator { get; set; }
        private AzureEndpointsCommunicator AzureCommunicator { get; set; }

        // cacheing the fetched properties to prevent constly network interaction in cases it is not needed
        private string FetchedStorageAccountName { get; set; }
        private string FetchedStorageAccountResourceGroup { get; set; }
        private string FetchedStorageAccountSubscription { get; set; }
        private string FetchedStorageAccountTableEndpoint { get; set; }

        // In cases when storage is not needed and not provided, theres's no need to perform storage related network interaction that may fail
        public bool IgnoreStorage { get; set; }

        public SqlAuditAdapter(AzureSubscription subscription)
        {
            Subscription = subscription;
            Communicator = new AuditingEndpointsCommunicator(subscription);
            AzureCommunicator = new AzureEndpointsCommunicator(subscription);
            IgnoreStorage = false;
        }

        /// <summary>
        /// Returns the storage account name of the given database server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resouce group to which the server belongs</param>
        /// <param name="serverName">The server's name</param>
        /// <param name="requestId">The Id to use in the request</param>
        /// <returns>The name of the storage accunt, null if it doesn't exist</returns>
        public string GetServerStorageAccount(string resourceGroupName, string serverName, string requestId)
        {
            return Communicator.GetServerAuditingPolicy(resourceGroupName, serverName, requestId).Properties.StorageAccountName;
        }
        
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
        private DatabaseAuditingPolicyModel ModelizeDatabaseAuditPolicy(DatabaseAuditingPolicy policy)
        {
            DatabaseAuditingPolicyModel dbPolicyModel = new DatabaseAuditingPolicyModel();
            DatabaseAuditingPolicyProperties properties = policy.Properties;
            dbPolicyModel.AuditState = ModelizeAuditState(properties.AuditingState);
            dbPolicyModel.UseServerDefault = properties.UseServerDefault == Constants.AuditingEndpoint.Enabled ? UseServerDefaultOptions.Enabled : UseServerDefaultOptions.Disabled;
            ModelizeStorageInfo(dbPolicyModel,properties.StorageAccountName, properties.StorageAccountKey, properties.StorageAccountSecondaryKey);
            ModelizeEventTypesInfo(dbPolicyModel, properties.EventTypesToAudit);
            return dbPolicyModel;
        }

        private ServerAuditingPolicyModel ModelizeServerAuditPolicy(ServerAuditingPolicy policy)
        {
            ServerAuditingPolicyModel serverPolicyModel = new ServerAuditingPolicyModel();
            ServerAuditingPolicyProperties properties = policy.Properties;
            serverPolicyModel.AuditState = ModelizeAuditState(properties.AuditingState);
            ModelizeStorageInfo(serverPolicyModel, properties.StorageAccountName, properties.StorageAccountKey, properties.StorageAccountSecondaryKey);
            ModelizeEventTypesInfo(serverPolicyModel, properties.EventTypesToAudit);
            return serverPolicyModel;
        }

        private AuditStateType ModelizeAuditState(string auditState)
        {
            if (auditState == Constants.AuditingEndpoint.New) return AuditStateType.New;
            if (auditState == Constants.AuditingEndpoint.Enabled) return AuditStateType.Enabled;
            return AuditStateType.Disabled;
        }

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

        private string PolicizeAuditState(AuditStateType AuditState)
        {
            switch(AuditState)
            {
                case AuditStateType.Enabled:
                    return Constants.AuditingEndpoint.Enabled;
                case AuditStateType.New:
                    return Constants.AuditingEndpoint.New;
                case AuditStateType.Disabled:
                default:
                    return Constants.AuditingEndpoint.Disabled;
            }
        }

        public void ModelizeEventTypesInfo(BaseAuditingPolicyModel model, string eventTypesToAudit)
        { 
            HashSet<AuditEventType> events = new HashSet<AuditEventType>();
            if (eventTypesToAudit.IndexOf(Constants.DataAccess) != -1) events.Add(AuditEventType.DataAccess);
            if (eventTypesToAudit.IndexOf(Constants.DataChanges) != -1) events.Add(AuditEventType.DataChanges);
            if (eventTypesToAudit.IndexOf(Constants.RevokePermissions) != -1) events.Add(AuditEventType.RevokePermissions);
            if (eventTypesToAudit.IndexOf(Constants.SchemaChanges) != -1) events.Add(AuditEventType.SchemaChanges);
            if (eventTypesToAudit.IndexOf(Constants.SecurityExceptions) != -1) events.Add(AuditEventType.SecurityExceptions);
            model.EventType = events.ToArray();
        }

        public void SetServerAuditingPolicy(ServerAuditingPolicyModel model, String clientId)
        {
            ServerAuditingPolicyCreateOrUpdateParameters parameters = PolicizeServerAuditingModel(model);
            Communicator.SetServerAuditingPolicy(model.ResourceGroupName, model.ServerName, clientId, parameters);
        }

        public void SetDatabaseAuditingPolicy(DatabaseAuditingPolicyModel model, String clientId)
        {
            DatabaseAuditingPolicyCreateOrUpdateParameters parameters = PolicizeDatabaseAuditingModel(model);
            Communicator.SetDatabaseAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId, parameters);
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="policy">The AuditingPolicy object</param>
        /// <returns>The communication model object</returns>
        private DatabaseAuditingPolicyCreateOrUpdateParameters PolicizeDatabaseAuditingModel(DatabaseAuditingPolicyModel model)
        {
            DatabaseAuditingPolicyCreateOrUpdateParameters updateParameters = new DatabaseAuditingPolicyCreateOrUpdateParameters();
            DatabaseAuditingPolicyProperties properties = new DatabaseAuditingPolicyProperties();
            updateParameters.Properties = properties;
            properties.AuditingState = PolicizeAuditState(model.AuditState);
            properties.UseServerDefault = (model.UseServerDefault == UseServerDefaultOptions.Enabled) ? Constants.AuditingEndpoint.Enabled : Constants.AuditingEndpoint.Disabled;
            properties.StorageAccountName = ExtractStorageAccountName(model);
            properties.StorageAccountResourceGroupName = ExtractStorageAccountResourceGroup(properties.StorageAccountName);
            properties.StorageAccountSubscriptionId = ExtractStorageAccountSubscriptionId(properties.StorageAccountName);
            properties.StorageTableEndpoint = ExtractStorageAccountTableEndpoint(properties.StorageAccountName);
            properties.StorageAccountKey = ExtractStorageAccountKey(properties.StorageAccountName, model, properties.StorageAccountResourceGroupName, StorageKeyKind.Primary);
            properties.StorageAccountSecondaryKey = ExtractStorageAccountKey(properties.StorageAccountName, model, properties.StorageAccountResourceGroupName, StorageKeyKind.Secondary);
            properties.EventTypesToAudit = ExtractEventTypes(model);
            return updateParameters;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="policy">The AuditingPolicy object</param>
        /// <returns>The communication model object</returns>
        private ServerAuditingPolicyCreateOrUpdateParameters PolicizeServerAuditingModel(ServerAuditingPolicyModel model)
        {
            ServerAuditingPolicyCreateOrUpdateParameters updateParameters = new ServerAuditingPolicyCreateOrUpdateParameters();
            ServerAuditingPolicyProperties properties = new ServerAuditingPolicyProperties();
            updateParameters.Properties = properties;
            properties.AuditingState = PolicizeAuditState(model.AuditState);
            properties.StorageAccountName = ExtractStorageAccountName(model);
            properties.StorageAccountResourceGroupName = ExtractStorageAccountResourceGroup(properties.StorageAccountName);
            properties.StorageAccountSubscriptionId = ExtractStorageAccountSubscriptionId(properties.StorageAccountName);
            properties.StorageTableEndpoint = ExtractStorageAccountTableEndpoint(properties.StorageAccountName);
            properties.StorageAccountKey = ExtractStorageAccountKey(properties.StorageAccountName, model, properties.StorageAccountResourceGroupName, StorageKeyKind.Primary);
            properties.StorageAccountSecondaryKey = ExtractStorageAccountKey(properties.StorageAccountName, model, properties.StorageAccountResourceGroupName, StorageKeyKind.Secondary);
            properties.EventTypesToAudit = ExtractEventTypes(model);
            return updateParameters;
        }

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

        private string ExtractEventTypes(BaseAuditingPolicyModel model)
        {
            if (model.EventType == null)
            {
                return null;
            }
            HashSet<AuditEventType> eventTypes = new HashSet<AuditEventType>(model.EventType);
            StringBuilder events = new StringBuilder();
            if(IsEventTypeOn(AuditEventType.DataAccess, model.EventType))
            {
                events.Append(Constants.AuditingEndpoint.DataAccess).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.DataChanges, model.EventType))
            {
                events.Append(Constants.AuditingEndpoint.DataChanges).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.RevokePermissions, model.EventType))
            {
                events.Append(Constants.AuditingEndpoint.RevokePermissions).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.SchemaChanges, model.EventType))
            {
                events.Append(Constants.AuditingEndpoint.SchemaChanges).Append(",");
            }
            if (IsEventTypeOn(AuditEventType.SecurityExceptions, model.EventType))
            {
                events.Append(Constants.AuditingEndpoint.SecurityExceptions).Append(",");
            }
            if(events.Length != 0) 
            {
                events.Remove(events.Length - 1, 1); // remove trailing comma
            }
            return events.ToString();
        }

        private bool IsEventTypeOn(AuditEventType lookedForType, AuditEventType[] userSelectedTypes)
        {
            if (userSelectedTypes.Contains(lookedForType))
            {
                return true;
            }
            return false;    
        }

        private string ExtractStorageAccountTableEndpoint(string storageName)
        {
            if (IgnoreStorage)
            {
                return null;
            }
            if (storageName == FetchedStorageAccountName && FetchedStorageAccountTableEndpoint != null)
            {
                return FetchedStorageAccountTableEndpoint;
            }
            return AzureCommunicator.GetStorageTableEndpoint(storageName);
        }

        private string ExtractStorageAccountSubscriptionId(string storageName)
        {
             if (IgnoreStorage)
            {
                return null;
            }
             if (storageName == FetchedStorageAccountName && FetchedStorageAccountSubscription!= null)
            {
                return FetchedStorageAccountSubscription;
            }
            return Subscription.Id.ToString();
        }

        private string ExtractStorageAccountResourceGroup(string storageName)
        {
            if (IgnoreStorage)
            {
                return null;
            }
            if (storageName == FetchedStorageAccountName && FetchedStorageAccountResourceGroup != null)
            {
                return FetchedStorageAccountResourceGroup;
            }
            return AzureCommunicator.GetStorageResourceGroup(storageName);
        }

        private string ExtractStorageAccountKey(string storageName, BaseAuditingPolicyModel model, string storageAccountResourceGroup, StorageKeyKind keyType)
        {
            if (IgnoreStorage)
            {
                return null;
            }
            if (model.StorageKeyType == keyType)
            {
                return AzureCommunicator.GetStorageKeys(storageAccountResourceGroup, storageName)[keyType];
            }
            return null;
        }
    }
}
