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

using Microsoft.Azure.ServiceManagemenet.Common;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.WindowsAzure.Management.Storage;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Sql.DataSync.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlDataSyncCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Data Sync
        /// </summary>
        /// <param name="context">The current Azure profile</param>
        public AzureSqlDataSyncCommunicator(IAzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Lists all databases connected by a given sync agent
        /// </summary>
        public IList<SyncAgentLinkedDatabase> ListSyncAgentLinkedDatabases(string resourceGroupName, string serverName, string syncAgentName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DataSync.ListSyncAgentLinkedDatabase(resourceGroupName, serverName, syncAgentName).LinkedDatabases;
        }

        /// <summary>
        /// Get the full schema of member database of a sync member
        /// </summary>
        public  SyncFullSchema GetSyncMemberSchema(string resourceGroupName, string serverName, string databaseName, string clientRequestId, SyncMemberGeneralParameters parameters)
        {
            var result = GetCurrentSqlClient(clientRequestId).DataSync.GetSyncMemberSchema(resourceGroupName, serverName, databaseName, parameters);
            return result.FullSchema == null || !result.FullSchema.Any() ? null : result.FullSchema.FirstOrDefault();
        }

        /// <summary>
        /// Start synchronization of sync group
        /// </summary>
        public void StartSynchronization(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).DataSync.StartSyncGroupSynchronization(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Stop synchronization of sync group
        /// </summary>
        public void StopSynchronization(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).DataSync.StopSyncGroupSynchronization(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Invoke the schema of member database refreshing 
        /// </summary>
        public void InvokeSyncMemberSchemaRefresh(string resourceGroupName, string serverName, string databaseName, string clientRequestId, SyncMemberGeneralParameters parameters)
        {
            GetCurrentSqlClient(clientRequestId).DataSync.InvokeSyncMemberSchemaRefresh(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Remove a sync group
        /// </summary>
        public void RemoveSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).DataSync.DeleteSyncGroup(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Create a sync group
        /// </summary>
        public SyncGroup CreateSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncDatabaseId, string clientRequestId, SyncGroupCreateOrUpdateParameters parameters)
        {
            SqlManagementClient client = GetCurrentSqlClient(clientRequestId);
            parameters.Properties.SyncDatabaseId = syncDatabaseId == null ? null : string.Format("/subscriptions/{0}/{1}", client.Credentials.SubscriptionId, syncDatabaseId);            
            return client.DataSync.CreateOrUpdateSyncGroup(resourceGroupName, serverName, databaseName, parameters).SyncGroup;
        }

        /// <summary>
        /// Update a sync group
        /// </summary>
        public SyncGroup UpdateSyncGroup(string resourceGroupName, string serverName, string databaseName, string clientRequestId, SyncGroupCreateOrUpdateParameters parameters)
        {
            SqlManagementClient client = GetCurrentSqlClient(clientRequestId);
            return GetCurrentSqlClient(clientRequestId).DataSync.UpdateSyncGroup(resourceGroupName, serverName, databaseName, parameters).SyncGroup;
        }

        /// <summary>
        /// Get a sync group
        /// </summary>
        public SyncGroup GetSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DataSync.GetSyncGroup(resourceGroupName, serverName, databaseName, syncGroupName).SyncGroup;
        }

        /// <summary>
        /// List all sync groups
        /// </summary>
        public IList<SyncGroup> ListSyncGroups(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DataSync.ListSyncGroup(resourceGroupName, serverName, databaseName).SyncGroups;
        }

        /// <summary>
        /// List sync group logs
        /// </summary>
        public SyncGroupLogListResponse ListSyncGroupLogs(string resourceGroupName, string serverName, string databaseName, string clientRequestId, SyncGroupLogGetParameters parameters)
        {
            return GetCurrentSqlClient(clientRequestId).DataSync.ListSyncGroupLog(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// List next sync group logs
        /// </summary>
        public SyncGroupLogListResponse ListNextSyncGroupLog(string resourceGroupName, string serverName, string databaseName, string clientRequestId, string syncGroupName, string nextLink)
        {
            return GetCurrentSqlClient(clientRequestId).DataSync.ListNextSyncGroupLog(resourceGroupName, serverName, databaseName, syncGroupName, nextLink);
        }

        /// <summary>
        /// Invoke the schema of hub database refreshing
        /// </summary>
        public void InvokeSyncHubSchemaRefresh(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).DataSync.InvokeSyncHubSchemaRefresh(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Get the hub database full schema of a sync member
        /// </summary>
        public SyncFullSchema GetSyncHubSchema(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string clientRequestId)
        {
            var result = GetCurrentSqlClient(clientRequestId).DataSync.GetSyncHubSchema(resourceGroupName, serverName, databaseName, syncGroupName);
            return result.FullSchema == null || !result.FullSchema.Any() ? null : result.FullSchema.FirstOrDefault();
        }

        /// <summary>
        /// Get a sync group
        /// </summary>
        public SyncMember GetSyncMember(string resourceGroupName, string serverName, string databaseName, string clientRequestId, SyncMemberGeneralParameters parameters)
        {
            return GetCurrentSqlClient(clientRequestId).DataSync.GetSyncMember(resourceGroupName, serverName, databaseName, parameters).SyncMember;
        }

        /// <summary>
        /// List all sync members
        /// </summary>
        public IList<SyncMember> ListSyncMembers(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DataSync.ListSyncMember(resourceGroupName, serverName, databaseName, syncGroupName).SyncMembers;
        }

        /// <summary>
        /// Remove a specified sync member
        /// </summary>
        public void RemoveSyncMember(string resourceGroupName, string serverName, string databaseName, string clientRequestId, SyncMemberGeneralParameters parameters)
        {
            GetCurrentSqlClient(clientRequestId).DataSync.DeleteSyncMember(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Create a new sync member
        /// </summary>
        public SyncMember CreateSyncMember(string resourceGroupName, string serverName, string databaseName, string syncAgentId, string clientRequestId, SyncMemberCreateOrUpdateParameters parameters)
        {
            SqlManagementClient client = GetCurrentSqlClient(clientRequestId);
            if (syncAgentId != null)
            {
                parameters.Properties.SyncAgentId = string.Format("/subscriptions/{0}/{1}", client.Credentials.SubscriptionId, syncAgentId);
            }
            return GetCurrentSqlClient(clientRequestId).DataSync.CreateOrUpdateSyncMember(resourceGroupName, serverName, databaseName, parameters).SyncMember;
        }

        /// <summary>
        /// Update an existing sync member
        /// </summary>
        public SyncMember UpdateSyncMember(string resourceGroupName, string serverName, string databaseName, string clientRequestId, SyncMemberCreateOrUpdateParameters parameters)
        {
            return GetCurrentSqlClient(clientRequestId).DataSync.UpdateSyncMember(resourceGroupName, serverName, databaseName, parameters).SyncMember;
        }

        /// <summary>
        /// Get a sync agent
        /// </summary>
        public SyncAgent GetSyncAgent(string resourceGroupName, string serverName, string syncAgentName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DataSync.GetSyncAgent(resourceGroupName, serverName, syncAgentName).SyncAgent;
        }

        /// <summary>
        /// List all sync agents
        /// </summary>
        public IList<Management.Sql.LegacySdk.Models.SyncAgent> ListSyncAgents(string resourceGroupName, string serverName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DataSync.ListSyncAgent(resourceGroupName, serverName).SyncAgents;
        }

        /// <summary>
        /// Remove a sync agent
        /// </summary>
        public void RemoveSyncAgent(string resourceGroupName, string serverName, string syncAgentName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).DataSync.DeleteSyncAgent(resourceGroupName, serverName, syncAgentName);
        }

        /// <summary>
        /// Create a sync agent
        /// </summary>
        public SyncAgent CreateSyncAgent(string resourceGroupName, string serverName, string syncAgentName, string syncDatabaseId, string clientRequestId, SyncAgentCreateOrUpdateParameters parameters)
        {
            SqlManagementClient client = GetCurrentSqlClient(clientRequestId);
            if (syncDatabaseId != null)
            {
                parameters.Properties.SyncDatabaseId = string.Format("/subscriptions/{0}/{1}", client.Credentials.SubscriptionId, syncDatabaseId);
            }     
            return GetCurrentSqlClient(clientRequestId).DataSync.CreateOrUpdateSyncAgent(resourceGroupName, serverName, syncAgentName, parameters).SyncAgent;
        }

        /// <summary>
        /// Generate a sync agent key
        /// </summary>
        public SyncAgentKeyResponse CreateSyncAgentKey(string resourceGroupName, string serverName, string syncAgentName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DataSync.CreateSyncAgentKey(resourceGroupName, serverName, syncAgentName);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient(String clientRequestId)
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            SqlClient.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return SqlClient;
        }
    }
}