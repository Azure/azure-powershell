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

using System.Security;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;

namespace Microsoft.Azure.Commands.Sql.DataSync.Model
{
    /// <summary>
    /// Represents a sync member object 
    /// </summary>
    public class AzureSqlSyncMemberModel
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
        /// Gets or sets the sync group name
        /// </summary>
        public string SyncGroupName { get; set; }

        /// <summary>
        /// Gets or sets the sync member name
        /// </summary>
        public string SyncMemberName { get; set;}

        /// <summary>
        /// Gets or sets the sync direction name
        /// </summary>
        public string SyncDirection { get; set; }

        /// <summary>
        /// Gets or sets the database type.
        /// </summary>
        public string DatabaseType { get; set; }

        /// <summary>
        /// Gets or sets the sync agent name
        /// </summary>
        public string SyncAgentId { get; set; }

        /// <summary>
        /// Gets or sets the id of the SQL server database which is connected by the sync agent
        /// </summary>
        public string SqlServerDatabaseId { get; set; }

        /// <summary>
        /// Gets or sets the Azure SQL Server Name of the member database
        /// </summary>
        public string MemberServerName { get; set; }

        /// <summary>
        /// Gets or sets the Azure SQL Server database name of the member database
        /// </summary>
        public string MemberDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the user name of Azure SQL database
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password of Azure SQL database
        /// </summary>
        public SecureString Password { get; set; }

        /// <summary>
        /// Gets or sets the sync state of a sync member
        /// </summary>
        public string SyncState { get; set; }

        /// <summary>
        /// Construct AzureSqlSyncMemberModel
        /// </summary>
        public AzureSqlSyncMemberModel()
        {

        }

        /// <summary>
        /// Construct AzureSqlSyncMemberModel for Management.Sql.Models.syncMember object
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="serverName">Server name</param>
        /// <param name="databaseName">Databse name</param>
        /// <param name="syncGroup">sync member object</param>
        public AzureSqlSyncMemberModel(string resourceGroup, string serverName, string databaseName, string syncGroupName, SyncMember syncMember)
        {
            ResourceGroupName = resourceGroup;
            ServerName = serverName;
            DatabaseName = databaseName;
            ResourceId = syncMember.Id;
            SyncGroupName = syncGroupName;
            SyncMemberName = syncMember.Name;
            SyncDirection = syncMember.Properties.SyncDirection == null ? null : syncMember.Properties.SyncDirection.ToString();
            SyncAgentId = syncMember.Properties.SyncAgentId;
            SqlServerDatabaseId = syncMember.Properties.SqlServerDatabaseId;
            MemberServerName = syncMember.Properties.ServerName;
            MemberDatabaseName = syncMember.Properties.DatabaseName;
            UserName = syncMember.Properties.UserName;
            DatabaseType = syncMember.Properties.DatabaseType == null ? null : syncMember.Properties.DatabaseType.ToString();
            SyncState = syncMember.Properties.SyncState;
        }
    }
}
