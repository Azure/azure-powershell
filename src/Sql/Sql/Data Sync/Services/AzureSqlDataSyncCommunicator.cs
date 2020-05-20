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

using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Commands.Common.Authentication;
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
        private static Management.Sql.LegacySdk.SqlManagementClient LegacySqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public static IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Data Sync
        /// </summary>
        /// <param name="context">The current Azure profile</param>
        public AzureSqlDataSyncCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                LegacySqlClient = null;
            }
        }

        /// <summary>
        /// Lists all databases connected by a given sync agent
        /// </summary>
        public IList<SyncAgentLinkedDatabase> ListSyncAgentLinkedDatabases(string resourceGroupName, string serverName, string syncAgentName)
        {
            return GetLegacySqlClient().DataSync.ListSyncAgentLinkedDatabase(resourceGroupName, serverName, syncAgentName).LinkedDatabases;
        }

        /// <summary>
        /// Get the full schema of member database of a sync member
        /// </summary>
        public  SyncFullSchema GetSyncMemberSchema(string resourceGroupName, string serverName, string databaseName, SyncMemberGeneralParameters parameters)
        {
            var result = GetLegacySqlClient().DataSync.GetSyncMemberSchema(resourceGroupName, serverName, databaseName, parameters);
            return result.FullSchema == null || !result.FullSchema.Any() ? null : result.FullSchema.FirstOrDefault();
        }

        /// <summary>
        /// Start synchronization of sync group
        /// </summary>
        public void StartSynchronization(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            GetLegacySqlClient().DataSync.StartSyncGroupSynchronization(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Stop synchronization of sync group
        /// </summary>
        public void StopSynchronization(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            GetLegacySqlClient().DataSync.StopSyncGroupSynchronization(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Invoke the schema of member database refreshing 
        /// </summary>
        public void InvokeSyncMemberSchemaRefresh(string resourceGroupName, string serverName, string databaseName, SyncMemberGeneralParameters parameters)
        {
            GetLegacySqlClient().DataSync.InvokeSyncMemberSchemaRefresh(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Remove a sync group
        /// </summary>
        public void RemoveSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            GetLegacySqlClient().DataSync.DeleteSyncGroup(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Create a sync group
        /// </summary>
        public Management.Sql.Models.SyncGroup CreateSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncDatabaseId, string syncGroupName, Management.Sql.Models.SyncGroup parameters)
        {
            Management.Sql.SqlManagementClient client = GetCurrentSqlClient();
            parameters.SyncDatabaseId = syncDatabaseId == null ? null : string.Format("/subscriptions/{0}/{1}", Subscription.Id, syncDatabaseId);            
            return client.SyncGroups.CreateOrUpdate(resourceGroupName, serverName, databaseName, syncGroupName, parameters);
        }

        /// <summary>
        /// Update a sync group
        /// </summary>
        public Management.Sql.Models.SyncGroup UpdateSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName, Management.Sql.Models.SyncGroup parameters)
        {
            return GetCurrentSqlClient().SyncGroups.Update(resourceGroupName, serverName, databaseName, syncGroupName, parameters);
        }

        /// <summary>
        /// Get a sync group
        /// </summary>
        public Management.Sql.Models.SyncGroup GetSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            return GetCurrentSqlClient().SyncGroups.Get(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// List all sync groups
        /// </summary>
        public IEnumerable<Management.Sql.Models.SyncGroup> ListSyncGroups(string resourceGroupName, string serverName, string databaseName)
        {
            return GetCurrentSqlClient().SyncGroups.ListByDatabase(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// List sync group logs
        /// </summary>
        public SyncGroupLogListResponse ListSyncGroupLogs(string resourceGroupName, string serverName, string databaseName, SyncGroupLogGetParameters parameters)
        {
            return GetLegacySqlClient().DataSync.ListSyncGroupLog(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// List next sync group logs
        /// </summary>
        public SyncGroupLogListResponse ListNextSyncGroupLog(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string nextLink)
        {
            return GetLegacySqlClient().DataSync.ListNextSyncGroupLog(resourceGroupName, serverName, databaseName, syncGroupName, nextLink);
        }

        /// <summary>
        /// Invoke the schema of hub database refreshing
        /// </summary>
        public void InvokeSyncHubSchemaRefresh(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            GetLegacySqlClient().DataSync.InvokeSyncHubSchemaRefresh(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Get the hub database full schema of a sync member
        /// </summary>
        public SyncFullSchema GetSyncHubSchema(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            var result = GetLegacySqlClient().DataSync.GetSyncHubSchema(resourceGroupName, serverName, databaseName, syncGroupName);
            return result.FullSchema == null || !result.FullSchema.Any() ? null : result.FullSchema.FirstOrDefault();
        }

        /// <summary>
        /// Get a sync group
        /// </summary>
        public Management.Sql.Models.SyncMember GetSyncMember(string resourceGroupName, string serverName, string databaseName, SyncMemberGeneralParameters parameters)
        {
            return GetCurrentSqlClient().SyncMembers.Get(resourceGroupName, serverName, databaseName, parameters.SyncGroupName, parameters.SyncMemberName);
        }

        /// <summary>
        /// List all sync members
        /// </summary>
        public IEnumerable<Management.Sql.Models.SyncMember> ListSyncMembers(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            return GetCurrentSqlClient().SyncMembers.ListBySyncGroup(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Remove a specified sync member
        /// </summary>
        public void RemoveSyncMember(string resourceGroupName, string serverName, string databaseName, SyncMemberGeneralParameters parameters)
        {
            GetLegacySqlClient().DataSync.DeleteSyncMember(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Create a new sync member
        /// </summary>
        public Management.Sql.Models.SyncMember CreateSyncMember(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, string syncAgentId, Management.Sql.Models.SyncMember parameters)
        {
            Management.Sql.SqlManagementClient client = GetCurrentSqlClient();
            if (syncAgentId != null)
            {
                parameters.SyncAgentId = string.Format("/subscriptions/{0}/{1}", Subscription.Id, syncAgentId);
            }
            return client.SyncMembers.CreateOrUpdate(resourceGroupName, serverName, databaseName, syncGroupName, syncMemberName, parameters);
        }

        /// <summary>
        /// Update an existing sync member
        /// </summary>
        public Management.Sql.Models.SyncMember UpdateSyncMember(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, Management.Sql.Models.SyncMember parameters)
        {
            return GetCurrentSqlClient().SyncMembers.Update(resourceGroupName, serverName, databaseName, syncGroupName, syncMemberName, parameters);
        }

        /// <summary>
        /// Get a sync agent
        /// </summary>
        public SyncAgent GetSyncAgent(string resourceGroupName, string serverName, string syncAgentName)
        {
            return GetLegacySqlClient().DataSync.GetSyncAgent(resourceGroupName, serverName, syncAgentName).SyncAgent;
        }

        /// <summary>
        /// List all sync agents
        /// </summary>
        public IList<Management.Sql.LegacySdk.Models.SyncAgent> ListSyncAgents(string resourceGroupName, string serverName)
        {
            return GetLegacySqlClient().DataSync.ListSyncAgent(resourceGroupName, serverName).SyncAgents;
        }

        /// <summary>
        /// Remove a sync agent
        /// </summary>
        public void RemoveSyncAgent(string resourceGroupName, string serverName, string syncAgentName)
        {
            GetLegacySqlClient().DataSync.DeleteSyncAgent(resourceGroupName, serverName, syncAgentName);
        }

        /// <summary>
        /// Create a sync agent
        /// </summary>
        public SyncAgent CreateSyncAgent(string resourceGroupName, string serverName, string syncAgentName, string syncDatabaseId, SyncAgentCreateOrUpdateParameters parameters)
        {
            Management.Sql.LegacySdk.SqlManagementClient client = GetLegacySqlClient();
            if (syncDatabaseId != null)
            {
                parameters.Properties.SyncDatabaseId = string.Format("/subscriptions/{0}/{1}", client.Credentials.SubscriptionId, syncDatabaseId);
            }     
            return client.DataSync.CreateOrUpdateSyncAgent(resourceGroupName, serverName, syncAgentName, parameters).SyncAgent;
        }

        /// <summary>
        /// Generate a sync agent key
        /// </summary>
        public SyncAgentKeyResponse CreateSyncAgentKey(string resourceGroupName, string serverName, string syncAgentName)
        {
            return GetLegacySqlClient().DataSync.CreateSyncAgentKey(resourceGroupName, serverName, syncAgentName);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        public static Management.Sql.SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            // Note: client is not cached in static field because that causes ObjectDisposedException in functional tests.
            var sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return sqlClient;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.LegacySdk.SqlManagementClient GetLegacySqlClient()
        {
            // Get the SQL management client for the current subscription
            if (LegacySqlClient == null)
            {
                LegacySqlClient = AzureSession.Instance.ClientFactory.CreateClient<Management.Sql.LegacySdk.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return LegacySqlClient;
        }
    }
}