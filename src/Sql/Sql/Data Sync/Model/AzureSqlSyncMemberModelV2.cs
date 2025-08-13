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
using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01.Models;
using Microsoft.Azure.Management.Sql.DataSyncV2.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.DataSync.Model
{
    /// <summary>
    /// Represents a sync member object 
    /// </summary>
    public class AzureSqlSyncMemberModelV2
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
        public string SyncMemberName { get; set; }

        /// <summary>
        /// Gets or sets the sync direction name
        /// </summary>
        public string SyncDirection { get; set; }

        /// <summary>
        /// Gets or sets the database type of the member database.
        /// </summary>
        public string MemberDatabaseType { get; set; }

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
        public string MemberDatabaseUserName { get; set; }

        /// <summary>
        /// Gets or sets the password of Azure SQL database
        /// </summary>
        public SecureString MemberDatabasePassword { get; set; }

        /// <summary>
        /// Gets or sets the sync state of a sync member
        /// </summary>
        public string SyncState { get; set; }

        /// <summary>
        /// Gets or sets the sync member resource Id
        /// </summary>
        public string SyncMemberAzureDatabaseResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether to use private link connection
        /// </summary>
        public bool? UsePrivateLinkConnection { get; set; }

        /// <summary>
        /// Gets or sets the identity of the sync member
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
        /// Construct AzureSqlSyncMemberModel
        /// </summary>
        public AzureSqlSyncMemberModelV2()
        {

        }

        /// <summary>
        /// Construct AzureSqlSyncMemberModel for Management.Sql.Models.syncMember object
        /// </summary>
        /// <param name="resourceGroup">Resource group name</param>
        /// <param name="serverName">Server name</param>
        /// <param name="databaseName">Database name</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        /// <param name="syncMember">sync member object</param>
        public AzureSqlSyncMemberModelV2(string resourceGroup, string serverName, string databaseName, string syncGroupName, SyncMember syncMember)
        {
            ResourceGroupName = resourceGroup;
            ServerName = serverName;
            DatabaseName = databaseName;
            ResourceId = syncMember.Id;
            SyncGroupName = syncGroupName;
            SyncMemberName = syncMember.Name;
            SyncDirection = syncMember.SyncDirection == null ? null : syncMember.SyncDirection.ToString();
            SyncAgentId = syncMember.SyncAgentId;
            SqlServerDatabaseId = syncMember.SqlServerDatabaseId == null ? null : syncMember.SqlServerDatabaseId.ToString();
            MemberServerName = syncMember.ServerName;
            MemberDatabaseName = syncMember.DatabaseName;
            MemberDatabaseUserName = syncMember.UserName;
            MemberDatabaseType = syncMember.DatabaseType == null ? null : syncMember.DatabaseType.ToString();
            SyncState = syncMember.SyncState;
            UsePrivateLinkConnection = syncMember.UsePrivateLinkConnection;
            SyncMemberAzureDatabaseResourceId = syncMember.SyncMemberAzureDatabaseResourceId;
            Identity = syncMember.Identity;
            if (Identity != null)
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
