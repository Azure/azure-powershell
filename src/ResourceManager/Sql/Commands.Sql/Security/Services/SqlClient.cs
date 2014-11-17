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
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.WindowsAzure.Commands.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.Security.Services
{
    /// <summary>
    /// The SqlClient class is resposible for the mapping of data between two models: 
    /// The communication model as defined by the endpoint APIs and the cmdlet model that is defined by the
    /// AuditingPolicy class. This class knows how to wrap a policy in its communication model and return 
    /// a policy in its cmdlet model and vice versa (i.e., unwrapping).
    /// </summary>
    public class SqlClient
    {
        private AzureSubscription Subscription { get; set; }

        private EndpointsCommunicator Communicator { get; set; }

        // cacheing the fetched properties to prevent constly network interaction in cases it is not needed
        private DatabaseSecurityPolicyProperties FetchedProperties;

        // In cases when storage is not needed and not provided, theres's no need to perform storage related network interaction that may fail
        public bool IgnoreStorage { get; set; }

        public SqlClient(AzureSubscription subscription)
        {
            Subscription = subscription;
            Communicator = new EndpointsCommunicator(subscription);
            IgnoreStorage = false;
        }
        
        public AuditingPolicy GetDatabaseAuditingPolicy(string resourceGroup, string serverName, string databaseName, string requestId)
        {
            DatabaseSecurityPolicy policy = Communicator.GetDatabaseSecurityPolicy(resourceGroup, serverName, databaseName, requestId);
            AuditingPolicy wrapper = WrapPolicy(policy);
            wrapper.ResourceGroupName = resourceGroup;
            wrapper.ServerName = serverName;
            wrapper.DatabaseName = databaseName;
            return wrapper;
        }

        public AuditingPolicy GetServerAuditingPolicy(string resourceGroup, string serverName, string requestId)
        {
            DatabaseSecurityPolicy policy = Communicator.GetServerSecurityPolicy(resourceGroup, serverName, requestId);
            AuditingPolicy wrapper = WrapPolicy(policy);
            wrapper.ResourceGroupName = resourceGroup;
            wrapper.ServerName = serverName;
            return wrapper;
        }

        private AuditingPolicy WrapPolicy(DatabaseSecurityPolicy policy)
        {
            AuditingPolicy wrapper = new AuditingPolicy();
            DatabaseSecurityPolicyProperties properties = policy.Properties;
            wrapper.UseServerDefault = properties.UseServerDefault;
            wrapper.IsEnabled = properties.IsAuditingEnabled;
            wrapper.StorageAccountName = properties.StorageAccountName;
            AddEventTypesToWrapperFromPolicy(wrapper, properties);
            AddConnectionStringsToWrapperFromPolicy(wrapper, properties);
            this.FetchedProperties = properties;           
            return wrapper;
        }

        private void AddConnectionStringsToWrapperFromPolicy(AuditingPolicy wrapper, DatabaseSecurityPolicyProperties properties)
        {
            wrapper.ConnectionStrings.AdoNetConnectionString = properties.AdoNetConnectionString;
            wrapper.ConnectionStrings.OdbcConnectionString = properties.OdbcConnectionString;
            wrapper.ConnectionStrings.JdbcConnectionString = properties.JdbcConnectionString;
            wrapper.ConnectionStrings.PhpConnectionString = properties.PhpConnectionString;
        }

        private void AddEventTypesToWrapperFromPolicy(AuditingPolicy wrapper, DatabaseSecurityPolicyProperties properties)
        {
            HashSet<string> events = new HashSet<string>();
            if (properties.IsEventTypeDataAccessEnabled) events.Add(Constants.Access);
            if (properties.IsEventTypeDataChangesEnabled) events.Add(Constants.Data);
            if (properties.IsEventTypeSchemaChangeEnabled) events.Add(Constants.Schema);
            if (properties.IsEventTypeGrantRevokePermissionsEnabled) events.Add(Constants.RevokePermissions);
            if (properties.IsEventTypeSecurityExceptionsEnabled) events.Add(Constants.Security);
            wrapper.EventType = events.ToArray();
        }

        public void SetServerAuditingPolicy(AuditingPolicy policy, String clientId)
        {
            DatabaseSecurityPolicyUpdateParameters parameters = UnwrapPolicy(policy);
            Communicator.SetServerSecurityPolicy(policy.ResourceGroupName, policy.ServerName, clientId, parameters);
        }

        public void SetDatabaseAuditingPolicy(AuditingPolicy policy, String clientId)
        {
            DatabaseSecurityPolicyUpdateParameters parameters = UnwrapPolicy(policy);
            Communicator.SetDatabaseSecurityPolicy(policy.ResourceGroupName, policy.ServerName, policy.DatabaseName, clientId, parameters);
        }

        /// <summary>
        /// Unwrap the cmdlets model object and transform it to the communication model object
        /// </summary>
        /// <param name="policy">The AuditingPolicy object</param>
        /// <returns>The communication model object</returns>
        private DatabaseSecurityPolicyUpdateParameters UnwrapPolicy(AuditingPolicy policy)
        {
            DatabaseSecurityPolicyUpdateParameters updateParameters = new DatabaseSecurityPolicyUpdateParameters();
            DatabaseSecurityPolicyProperties properties = new DatabaseSecurityPolicyProperties();
            updateParameters.Properties = properties;
            properties.RetentionDays = 90;
            properties.IsAuditingEnabled = policy.IsEnabled;
            properties.UseServerDefault = policy.UseServerDefault;
            UpdateEventTypes(policy, properties);
            UpdateStorage(policy.StorageAccountName, properties);
            return updateParameters;
        }

        /// <summary>
        /// Check that the user didn't enter a shortcut option (All or None) with other event types.
        /// </summary>
        private bool ValidateShortcutUsage(HashSet<String> userEnteredEventType, string option)
        {
            return userEnteredEventType.Count == 1 || !userEnteredEventType.Contains(option);
        }

        /// <summary>
        /// Updates the storage properties of the policy that this object operates on
        /// </summary>
        private void UpdateEventTypes(AuditingPolicy wrappedPolicy, DatabaseSecurityPolicyProperties properties)
        {
            string[] userEnteredEventType = wrappedPolicy.EventType;
            if (userEnteredEventType == null || userEnteredEventType.Length == 0)
                return;
            HashSet<String> eventTypes = new HashSet<String>(userEnteredEventType);

            if (!ValidateShortcutUsage(eventTypes, Constants.All))
                throw new Exception(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.InvalidEventTypeSet, Constants.All));
            if (!ValidateShortcutUsage(eventTypes, Constants.None))
                throw new Exception(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.InvalidEventTypeSet, Constants.None));
            
            properties.IsEventTypeDataAccessEnabled = ValueOfProperty(eventTypes, Constants.Access);
            properties.IsEventTypeSchemaChangeEnabled = ValueOfProperty(eventTypes, Constants.Schema);
            properties.IsEventTypeDataChangesEnabled = ValueOfProperty(eventTypes, Constants.Data);
            properties.IsEventTypeSecurityExceptionsEnabled = ValueOfProperty(eventTypes, Constants.Security);
            properties.IsEventTypeGrantRevokePermissionsEnabled = ValueOfProperty(eventTypes, Constants.RevokePermissions);
            
            // we need to re-add the event types to the AuditingPolicy object to replace the All / None with the real values 
            if (userEnteredEventType.Contains(Constants.All) || userEnteredEventType.Contains(Constants.None))
                AddEventTypesToWrapperFromPolicy(wrappedPolicy, properties);
        }

        /// <summary>
        /// Updates the storage properties of the policy that this object operates on
        /// </summary>
        private void UpdateStorage(string storageAccountName, DatabaseSecurityPolicyProperties properties)
        {
            if (storageAccountName != null)
                properties.StorageAccountName = storageAccountName;

            if (string.IsNullOrEmpty(properties.StorageAccountName) && (!IgnoreStorage)) // can happen if the user didn't provide account name for a policy that lacked it 
            {
                throw new Exception(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.NoStorageAccountWhenConfiguringAuditingPolicy));
            }

            // no need to do time consuming http inteaction to fetch these properties if the storage account was not changed
            if (properties.StorageAccountName == this.FetchedProperties.StorageAccountName)
            {
                properties.StorageAccountResourceGroupName = this.FetchedProperties.StorageAccountResourceGroupName;
                properties.StorageAccountSubscriptionId = this.FetchedProperties.StorageAccountSubscriptionId;
                properties.StorageTableEndpoint = this.FetchedProperties.StorageTableEndpoint;
            }
            else
            {
                properties.StorageAccountSubscriptionId = Subscription.Id.ToString();
                properties.StorageAccountResourceGroupName = Communicator.GetStorageResourceGroup(properties.StorageAccountName);
                properties.StorageTableEndpoint = Communicator.GetStorageTableEndpoint(properties.StorageAccountName);
            }

            if (!IgnoreStorage)
            {
                // storage keys are not sent when fetching the policy, so if they are needed, they should be fetched 
                Dictionary<Constants.StorageKeyTypes, string> keys = Communicator.GetStorageKeys(properties.StorageAccountName);
                properties.StorageAccountKey = keys[Constants.StorageKeyTypes.Primary];
            }
        }

        /// <summary>
        /// The value of a property from a set of event types
        /// </summary>
        /// <param name="eventTypes">A set of the event types that the user selected to use</param>
        /// <param name="propertyName">The property for which we'd like to know if the user selected to enable or disable</param>
        /// <returns>A bool stating whether the user selected to enable or disable the given property</returns>
        private bool ValueOfProperty(HashSet<String> eventTypes, String propertyName)
        {
            if (eventTypes.Contains(Constants.None)) return false;
            if (eventTypes.Contains(Constants.All)) return true;
            return eventTypes.Contains(propertyName);
        }
    }
}
