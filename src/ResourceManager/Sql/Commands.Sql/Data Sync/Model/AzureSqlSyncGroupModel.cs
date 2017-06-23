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

using System;
using System.Security;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;

namespace Microsoft.Azure.Commands.Sql.DataSync.Model
{
    /// <summary>
    /// Represents a sync group object 
    /// </summary>
    public class AzureSqlSyncGroupModel
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
        /// Gets or sets the policy of resolving confliction between hub and member database in the sync group
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
        public AzureSqlSyncGroupSchemaModel Schema { get; set; }

        /// <summary>
        /// Construct AzureSqlSyncGroupModel
        /// </summary>
        public AzureSqlSyncGroupModel()
        {

        }

        /// <summary>
        /// Construct AzureSqlSyncGroupModel for Management.Sql.Models.syncGroup object
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="serverName">Server name</param>
        /// <param name="databaseName">Databse name</param>
        /// <param name="syncGroup">sync group object</param>
        public AzureSqlSyncGroupModel(string resourceGroupName, string serverName, string databaseName, SyncGroup syncGroup )
        {
            ResourceGroupName = resourceGroupName;
            ServerName = serverName;
            DatabaseName = databaseName;
            ResourceId = syncGroup.Id;
            SyncGroupName = syncGroup.Name;
            IntervalInSeconds = syncGroup.Properties.Interval;
            SyncDatabaseId = syncGroup.Properties.SyncDatabaseId;
            HubDatabaseUserName = syncGroup.Properties.HubDatabaseUserName;
            ConflictResolutionPolicy = syncGroup.Properties.ConflictResolutionPolicy == null ? null : syncGroup.Properties.ConflictResolutionPolicy.ToString();
            SyncState = syncGroup.Properties.SyncState;
            LastSyncTime = syncGroup.Properties.LastSyncTime;
            Schema = syncGroup.Properties.Schema == null ? null : new AzureSqlSyncGroupSchemaModel(syncGroup.Properties.Schema);
        }
    }
}
