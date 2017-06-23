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
        private static SqlManagementClient LegacySqlClient { get; set; }

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
        public SyncGroup CreateSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncDatabaseId, SyncGroupCreateOrUpdateParameters parameters)
        {
            SqlManagementClient client = GetLegacySqlClient();
            parameters.Properties.SyncDatabaseId = syncDatabaseId == null ? null : string.Format("/subscriptions/{0}/{1}", client.Credentials.SubscriptionId, syncDatabaseId);            
            return client.DataSync.CreateOrUpdateSyncGroup(resourceGroupName, serverName, databaseName, parameters).SyncGroup;
        }

        /// <summary>
        /// Update a sync group
        /// </summary>
        public SyncGroup UpdateSyncGroup(string resourceGroupName, string serverName, string databaseName, SyncGroupCreateOrUpdateParameters parameters)
        {
            return GetLegacySqlClient().DataSync.UpdateSyncGroup(resourceGroupName, serverName, databaseName, parameters).SyncGroup;
        }

        /// <summary>
        /// Get a sync group
        /// </summary>
        public SyncGroup GetSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            return GetLegacySqlClient().DataSync.GetSyncGroup(resourceGroupName, serverName, databaseName, syncGroupName).SyncGroup;
        }

        /// <summary>
        /// List all sync groups
        /// </summary>
        public IList<SyncGroup> ListSyncGroups(string resourceGroupName, string serverName, string databaseName)
        {
            return GetLegacySqlClient().DataSync.ListSyncGroup(resourceGroupName, serverName, databaseName).SyncGroups;
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
        public SyncMember GetSyncMember(string resourceGroupName, string serverName, string databaseName, SyncMemberGeneralParameters parameters)
        {
            return GetLegacySqlClient().DataSync.GetSyncMember(resourceGroupName, serverName, databaseName, parameters).SyncMember;
        }

        /// <summary>
        /// List all sync members
        /// </summary>
        public IList<SyncMember> ListSyncMembers(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            return GetLegacySqlClient().DataSync.ListSyncMember(resourceGroupName, serverName, databaseName, syncGroupName).SyncMembers;
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
        public SyncMember CreateSyncMember(string resourceGroupName, string serverName, string databaseName, string syncAgentId, SyncMemberCreateOrUpdateParameters parameters)
        {
            SqlManagementClient client = GetLegacySqlClient();
            if (syncAgentId != null)
            {
                parameters.Properties.SyncAgentId = string.Format("/subscriptions/{0}/{1}", client.Credentials.SubscriptionId, syncAgentId);
            }
            return client.DataSync.CreateOrUpdateSyncMember(resourceGroupName, serverName, databaseName, parameters).SyncMember;
        }

        /// <summary>
        /// Update an existing sync member
        /// </summary>
        public SyncMember UpdateSyncMember(string resourceGroupName, string serverName, string databaseName, SyncMemberCreateOrUpdateParameters parameters)
        {
            return GetLegacySqlClient().DataSync.UpdateSyncMember(resourceGroupName, serverName, databaseName, parameters).SyncMember;
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
            SqlManagementClient client = GetLegacySqlClient();
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