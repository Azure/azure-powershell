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
using System.Collections.Generic;
using Microsoft.Azure.Management.Sql.DataSyncV2;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Sql.DataSync.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlDataSyncCommunicatorV2
    {
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
        public AzureSqlDataSyncCommunicatorV2(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
            }
        }

        /// <summary>
        /// Create a sync group
        /// </summary>
        public Management.Sql.DataSyncV2.Models.SyncGroup CreateSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncDatabaseId, string syncGroupName, Management.Sql.DataSyncV2.Models.SyncGroup parameters)
        {
            Management.Sql.DataSyncV2.SqlManagementClient client = GetCurrentSqlClient();
            parameters.SyncDatabaseId = syncDatabaseId == null ? null : string.Format("/subscriptions/{0}/{1}", Subscription.Id, syncDatabaseId);
            return client.SyncGroups.CreateOrUpdate(resourceGroupName, serverName, databaseName, syncGroupName, parameters);
        }

        /// <summary>
        /// Update a sync group
        /// </summary>
        public Management.Sql.DataSyncV2.Models.SyncGroup UpdateSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName, Management.Sql.DataSyncV2.Models.SyncGroup parameters)
        {
            return GetCurrentSqlClient().SyncGroups.Update(resourceGroupName, serverName, databaseName, syncGroupName, parameters);
        }

        /// <summary>
        /// Get a sync group
        /// </summary>
        public Management.Sql.DataSyncV2.Models.SyncGroup GetSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            return GetCurrentSqlClient().SyncGroups.Get(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// List all sync groups
        /// </summary>
        public IEnumerable<Management.Sql.DataSyncV2.Models.SyncGroup> ListSyncGroups(string resourceGroupName, string serverName, string databaseName)
        {
            return GetCurrentSqlClient().SyncGroups.ListByDatabase(resourceGroupName, serverName, databaseName);
        }


        /// <summary>
        /// Get a sync group
        /// </summary>
        public Management.Sql.DataSyncV2.Models.SyncMember GetSyncMember(string resourceGroupName, string serverName, string databaseName, SyncMemberGeneralParameters parameters)
        {
            return GetCurrentSqlClient().SyncMembers.Get(resourceGroupName, serverName, databaseName, parameters.SyncGroupName, parameters.SyncMemberName);
        }

        /// <summary>
        /// List all sync members
        /// </summary>
        public IEnumerable<Management.Sql.DataSyncV2.Models.SyncMember> ListSyncMembers(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            return GetCurrentSqlClient().SyncMembers.ListBySyncGroup(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Create a new sync member
        /// </summary>
        public Management.Sql.DataSyncV2.Models.SyncMember CreateSyncMember(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, string syncAgentId, Management.Sql.DataSyncV2.Models.SyncMember parameters)
        {
            Management.Sql.DataSyncV2.SqlManagementClient client = GetCurrentSqlClient();
            if (syncAgentId != null)
            {
                parameters.SyncAgentId = string.Format("/subscriptions/{0}/{1}", Subscription.Id, syncAgentId);
            }
            return client.SyncMembers.CreateOrUpdate(resourceGroupName, serverName, databaseName, syncGroupName, syncMemberName, parameters);
        }

        /// <summary>
        /// Update an existing sync member
        /// </summary>
        public Management.Sql.DataSyncV2.Models.SyncMember UpdateSyncMember(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, Management.Sql.DataSyncV2.Models.SyncMember parameters)
        {
            return GetCurrentSqlClient().SyncMembers.Update(resourceGroupName, serverName, databaseName, syncGroupName, syncMemberName, parameters);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        public static Management.Sql.DataSyncV2.SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            // Note: client is not cached in static field because that causes ObjectDisposedException in functional tests.
            var sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.DataSyncV2.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return sqlClient;
        }
    }
}