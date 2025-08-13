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

using Microsoft.Azure.Management.Sql.DataSyncV2.Models;
using System;
using System.Linq;
using System.Security;

namespace Microsoft.Azure.Commands.Sql.DataSync.Model
{
    /// <summary>
    /// Represents a sync group object 
    /// </summary>
    public class AzureSqlSyncGroupModelV2
    {
        /// <summary>
        /// Gets or sets the resource Id
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the database name
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the sync group
        /// </summary>
        public string SyncGroupName { get; set; }

        /// <summary>
        /// Gets or sets the sync database resource Id
        /// </summary>
        public string SyncDatabaseId { get; set; }

        /// <summary>
        /// Gets or sets the frequency (in seconds) time of doing data synchronization
        /// </summary>
        public int? IntervalInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the hub database user name
        /// </summary>
        public string HubDatabaseUserName { get; set; }

        /// <summary>
        /// Gets or sets the hub database password
        /// </summary>
        public SecureString HubDatabasePassword { get; set; }

        /// <summary>
        /// Gets or sets the policy of resolving conflicts between hub and member database in the sync group
        /// </summary>
        public string ConflictResolutionPolicy { get; set; }

        /// <summary>
        /// Gets or sets the sync state of sync group
        /// </summary>
        public string SyncState { get; set; }

        /// <summary>
        /// Gets or sets the last sync time of a sync group
        /// </summary>
        public DateTime? LastSyncTime { get; set; }

        /// <summary>
        /// Gets or sets the simple schema of member database
        /// </summary>
        public AzureSqlSyncGroupSchemaModelV2 Schema { get; set; }

        /// <summary>
        /// Gets or sets if private link connection should be used
        /// </summary>
        public bool? UsePrivateLinkConnection { get; set; }

        /// <summary>
        /// Gets or sets the identity of the sync group
        /// </summary>
        public DataSyncParticipantIdentity Identity { get; set; }

        // ---- Display helper properties ----

        /// <summary>
        /// Gets the identity type of the sync group.
        /// Possible values include: 'None', 'SystemAssigned', 'UserAssigned', 'SystemAssignedUserAssigned'.
        /// </summary>
        public string IdentityType { get; private set; }

        /// <summary>
        /// Gets the Resource ID associated with the sync group EntraID.
        /// </summary>
        public string IdentityId { get; private set; }

        /// <summary>
        /// Construct AzureSqlSyncGroupModelV2
        /// </summary>
        public AzureSqlSyncGroupModelV2()
        {

        }

        /// <summary>
        /// Construct AzureSqlSyncGroupModelV2 for Management.Sql.DataSyncV2.Models.syncGroup object
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="serverName">Server name</param>
        /// <param name="databaseName">Database name</param>
        /// <param name="syncGroup">sync group object</param>
        public AzureSqlSyncGroupModelV2(string resourceGroupName, string serverName, string databaseName, SyncGroup syncGroup)
        {
            ResourceGroupName = resourceGroupName;
            ServerName = serverName;
            DatabaseName = databaseName;
            ResourceId = syncGroup.Id;
            SyncGroupName = syncGroup.Name;
            IntervalInSeconds = syncGroup.Interval;
            SyncDatabaseId = syncGroup.SyncDatabaseId;
            HubDatabaseUserName = syncGroup.HubDatabaseUserName;
            ConflictResolutionPolicy = syncGroup.ConflictResolutionPolicy == null ? null : syncGroup.ConflictResolutionPolicy.ToString();
            SyncState = syncGroup.SyncState;
            LastSyncTime = syncGroup.LastSyncTime;
            Schema = syncGroup.Schema == null ? null : new AzureSqlSyncGroupSchemaModelV2(syncGroup.Schema);
            UsePrivateLinkConnection = syncGroup.UsePrivateLinkConnection;
            Identity = syncGroup.Identity;
            if (syncGroup.Identity != null)
            {
                IdentityType = Identity.Type == null ? null : Identity.Type;
                if (Identity.UserAssignedIdentities != null && Identity.UserAssignedIdentities.Count > 0)
                {
                    // Get the first identity resource ID
                    IdentityId = Identity.UserAssignedIdentities.Keys.FirstOrDefault();
                }
            }
            else
            {
                IdentityType = "None";
                IdentityId = null;
            }
        }
    }
}
