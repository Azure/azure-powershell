﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.Security.Services
{
    /// <summary>
    /// The SqlClient class is responsible for the mapping of data between two models: 
    /// The communication model as defined by the endpoint APIs and the cmdlet model that is defined by the
    /// AuditingPolicy class. This class knows how to wrap a policy in its communication model and return 
    /// a policy in its cmdlet model and vice versa (i.e., unwrapping).
    /// </summary>
    public class SqlClient
    {
        private AzureSubscription Subscription { get; set; }

        private AzureProfile Profile { get; set; }

        private EndpointsCommunicator Communicator { get; set; }

        // Caching the fetched properties to prevent costly network interaction in cases it is not needed
        private DatabaseSecurityPolicyProperties FetchedProperties;

        // In cases when storage is not needed and not provided, theres's no need to perform storage related network interaction that may fail
        public bool IgnoreStorage { get; set; }

        public SqlClient(AzureProfile profile, AzureSubscription subscription)
        {
            Profile = profile;
            Subscription = subscription;
            Communicator = new EndpointsCommunicator(profile, subscription);
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
            return Communicator.GetServerSecurityPolicy(resourceGroupName, serverName, requestId).Properties.StorageAccountName;
        }
        
        public AuditingPolicy GetDatabaseAuditingPolicy(string resourceGroup, string serverName, string databaseName, string requestId)
        {
            DatabaseSecurityPolicy policy = Communicator.GetDatabaseSecurityPolicy(resourceGroup, serverName, databaseName, requestId);
            AuditingPolicy wrapper = WrapPolicy(policy);
            wrapper.ResourceGroupName = resourceGroup;
            wrapper.ServerName = serverName;
            wrapper.DatabaseName = databaseName;
            AddConnectionStringsToWrapperFromPolicy(wrapper, policy.Properties);
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
            wrapper.DirectAccessEnabled = !properties.IsBlockDirectAccessEnabled;
            addStorageInfoToWrapperFromPolicy(wrapper, properties);
            AddEventTypesToWrapperFromPolicy(wrapper, properties);
            this.FetchedProperties = properties;           
            return wrapper;
        }

        private void addStorageInfoToWrapperFromPolicy(AuditingPolicy wrapper, DatabaseSecurityPolicyProperties properties)
        {
            wrapper.StorageAccountName = properties.StorageAccountName;
            if (properties.StorageAccountKey != null) 
                wrapper.StorageKeyType = Constants.StorageKeyTypes.Primary; // TODO - until we have in prodcution the secondary field - handle as alway primary
            if (properties.SecondaryStorageAccountKey != null) 
                wrapper.StorageKeyType = Constants.StorageKeyTypes.Secondary;
        }

        private void AddConnectionStringsToWrapperFromPolicy(AuditingPolicy wrapper, DatabaseSecurityPolicyProperties properties)
        {
            wrapper.ConnectionStrings.AdoNetConnectionString = ConstructAdoNetConnectionString(wrapper, properties);
            wrapper.ConnectionStrings.OdbcConnectionString = ConstructOdbcConnectionString(wrapper, properties);
            wrapper.ConnectionStrings.JdbcConnectionString = ConstructJdbcConnectionString(wrapper, properties);
            wrapper.ConnectionStrings.PhpConnectionString = ConstructPhpConnectionString(wrapper, properties);
        }

        private string ConstructPhpConnectionString(AuditingPolicy wrapper, DatabaseSecurityPolicyProperties properties)
        {
            string enterUser = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterUserId;
            string enterPassword = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterPassword;
            string pdoTitle = Microsoft.Azure.Commands.Sql.Properties.Resources.PdoTitle;
            string sqlServerSampleTitle = Microsoft.Azure.Commands.Sql.Properties.Resources.sqlSampleTitle;
            string connectionError = Microsoft.Azure.Commands.Sql.Properties.Resources.PhpConnectionError;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Server: {0}, {1}", properties.ProxyDnsName, properties.ProxyPort)).Append(Environment.NewLine);
            sb.Append(string.Format("SQL Database: {0}",  wrapper.DatabaseName)).Append(Environment.NewLine);
            sb.Append(string.Format("User Name: {0}", enterUser)).Append(Environment.NewLine).Append(Environment.NewLine);
            sb.Append(pdoTitle).Append(Environment.NewLine);
            sb.Append("try{").Append(Environment.NewLine);
            sb.Append(string.Format("$conn = new PDO ( \"sqlsrv:server = tcp:{0},{1}; Database = \"{2}\", \"{3}\", \"{4}\");", 
                                                properties.ProxyDnsName, properties.ProxyPort, wrapper.DatabaseName, enterUser, enterPassword)).Append(Environment.NewLine);
            sb.Append("$conn->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );").Append(Environment.NewLine);
            sb.Append("}").Append(Environment.NewLine);
            sb.Append("catch ( PDOException $e ) {").Append(Environment.NewLine);
            sb.Append(string.Format("print( \"{0}\" );", connectionError)).Append(Environment.NewLine);
            sb.Append("die(print_r($e));").Append(Environment.NewLine);
            sb.Append("}").Append(Environment.NewLine);
            sb.Append(sqlServerSampleTitle).Append(Environment.NewLine).Append(Environment.NewLine);
            sb.Append(string.Format("connectionInfo = array(\"UID\" => \"{0}@{1}\", \"pwd\" => \"{2}\", \"Database\" => \"{3}\", \"LoginTimeout\" => 30, \"Encrypt\" => 1);", 
                                                enterUser, wrapper.ServerName, enterPassword, wrapper.DatabaseName)).Append(Environment.NewLine);
            sb.Append(string.Format("$serverName = \"tcp:{0},{1}\";", properties.ProxyDnsName, properties.ProxyPort)).Append(Environment.NewLine);
            sb.Append("$conn = sqlsrv_connect($serverName, $connectionInfo);");
            return sb.ToString();
        }

        private string ConstructOdbcConnectionString(AuditingPolicy wrapper, DatabaseSecurityPolicyProperties properties)
        {
            string enterUser = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterUserId;
            string enterPassword = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterPassword;
            StringBuilder sb = new StringBuilder();
            sb.Append("Driver={SQL Server Native Client 11.0};");
            sb.Append(string.Format("Server=tcp:{0},{1};", properties.ProxyDnsName, properties.ProxyPort));
            sb.Append(string.Format("Database={0};", wrapper.DatabaseName));
            sb.Append(string.Format("Uid={0}@{1};", enterUser, wrapper.ServerName));
            sb.Append(string.Format("Pwd={0};", enterPassword));
            sb.Append("Encrypt=yes;Connection Timeout=30;");
            return sb.ToString();
        }

        private string ConstructJdbcConnectionString(AuditingPolicy wrapper, DatabaseSecurityPolicyProperties properties)
        {
            string enterUser = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterUserId;
            string enterPassword = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterPassword;
            return string.Format("jdbc:sqlserver://{0}:{1};database={2};user={3}@{4};password={5};encrypt=true;hostNameInCertificate=*.database.secure.windows.net;loginTimeout=30;",
                properties.ProxyDnsName, properties.ProxyPort, wrapper.DatabaseName, enterUser, wrapper.ServerName, enterPassword);
        }

        private string ConstructAdoNetConnectionString(AuditingPolicy wrapper,DatabaseSecurityPolicyProperties properties)
        {
            string enterUser = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterUserId;
            string enterPassword = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterPassword;
            return string.Format("Server=tcp:{0},{1};Database={2};User ID={3}@{4};Password={5};Trusted_Connection=False;Encrypt=True;Connection Timeout=30", 
                properties.ProxyDnsName, properties.ProxyPort, wrapper.DatabaseName, enterUser, wrapper.ServerName, enterPassword);
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
            properties.IsBlockDirectAccessEnabled = !policy.DirectAccessEnabled;
            UpdateEventTypes(policy, properties);
            UpdateStorage(policy, properties);
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
        private void UpdateStorage(AuditingPolicy policy, DatabaseSecurityPolicyProperties properties)
        {
            string storageAccountName = policy.StorageAccountName;
            if (storageAccountName != null)
                properties.StorageAccountName = storageAccountName;

            if (string.IsNullOrEmpty(properties.StorageAccountName) && (!IgnoreStorage)) // can happen if the user didn't provide account name for a policy that lacked it 
            {
                throw new Exception(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.NoStorageAccountWhenConfiguringAuditingPolicy));
            }

            // no need to do time consuming http interaction to fetch these properties if the storage account was not changed
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
                properties.StorageTableEndpoint = Communicator.GetStorageTableEndpoint(Profile, properties.StorageAccountName);
            }

            if (!IgnoreStorage)
            {
                // storage keys are not sent when fetching the policy, so if they are needed, they should be fetched 
                Dictionary<Constants.StorageKeyTypes, string> keys = Communicator.GetStorageKeys(properties.StorageAccountResourceGroupName, properties.StorageAccountName);
                if (policy.StorageKeyType == Constants.StorageKeyTypes.Primary)
                    properties.StorageAccountKey = keys[Constants.StorageKeyTypes.Primary];
                else
                    properties.SecondaryStorageAccountKey = keys[Constants.StorageKeyTypes.Secondary];
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
