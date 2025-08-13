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
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Server.Adapter;

namespace Microsoft.Azure.Commands.Sql.DataSync.Services
{
    /// <summary>
    /// Adapter for data sync operations
    /// </summary>
    public class AzureSqlDataSyncAdapterV2
    {
        /// <summary>
        /// Gets or sets the AzureDataSyncCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDataSyncCommunicatorV2 Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private IAzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a data sync adapter
        /// </summary>
        /// <param name="context">The current azure profile</param>
        public AzureSqlDataSyncAdapterV2(IAzureContext context)
        {
            Context = context;
            _subscription = context?.Subscription;
            Communicator = new AzureSqlDataSyncCommunicatorV2(Context);
            
        }

        /// <summary>
        /// Gets a sync group by name
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync group is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        /// <returns>The sync group object</returns>
        public AzureSqlSyncGroupModelV2 GetSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            var resp = Communicator.GetSyncGroup(resourceGroupName, serverName, databaseName, syncGroupName);
            return CreateSyncGroupModelFromResponseV2(resourceGroupName, serverName, databaseName, resp);
        }

        /// <summary>
        /// Gets a list of sync groups
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync group is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <returns>A list of sync group objects</returns>
        internal ICollection<AzureSqlSyncGroupModelV2> ListSyncGroups(string resourceGroupName, string serverName, string databaseName)
        {
            var resp = Communicator.ListSyncGroups(resourceGroupName, serverName, databaseName);
            return resp.Select((db) => {
                return CreateSyncGroupModelFromResponseV2(resourceGroupName, serverName, databaseName, db);
            }).ToList();
        }

        /// <summary>
        /// Create a sync group
        /// </summary>
        /// <param name="model">AzureSqlSyncGroupModel object</param>
        /// <param name="syncDatabaseId">The sync database resource id</param>
        /// <returns>Created AzureSqlSyncGroupModel object</returns>
        internal AzureSqlSyncGroupModelV2 CreateSyncGroup(AzureSqlSyncGroupModelV2 model, string syncDatabaseId)
        {
            var createResp = Communicator.CreateSyncGroup(model.ResourceGroupName, model.ServerName, model.DatabaseName, syncDatabaseId, model.SyncGroupName, new Management.Sql.DataSyncV2.Models.SyncGroup()
            {
                ConflictResolutionPolicy = model.ConflictResolutionPolicy,
                Interval = model.IntervalInSeconds,
                HubDatabaseUserName = model.HubDatabaseUserName,
                HubDatabasePassword = model.HubDatabasePassword == null ? null : AzureSqlServerAdapter.Decrypt(model.HubDatabasePassword),
                Schema = model.Schema == null ? null : model.Schema.ToSyncGroupSchema(),
                UsePrivateLinkConnection = model.UsePrivateLinkConnection,
                Identity = model.Identity
            });

            // Workaround for Rest API return response value incorrect issue. Remove this line after backend fix is deployed
            var resp = Communicator.GetSyncGroup(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName);
            return CreateSyncGroupModelFromResponseV2(model.ResourceGroupName, model.ServerName, model.DatabaseName, resp);
        }

        /// <summary>
        /// Update a sync group
        /// </summary>
        /// <param name="model">AzureSqlSyncGroupModel object</param>
        /// <returns>Updated AzureSqlSyncGroupModel object</returns>
        internal AzureSqlSyncGroupModelV2 UpdateSyncGroup(AzureSqlSyncGroupModelV2 model)
        {
            var updateResp = Communicator.UpdateSyncGroup(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName, new Management.Sql.DataSyncV2.Models.SyncGroup()
            {
                Interval = model.IntervalInSeconds,
                HubDatabaseUserName = model.HubDatabaseUserName,
                HubDatabasePassword = model.HubDatabasePassword == null ? null : AzureSqlServerAdapter.Decrypt(model.HubDatabasePassword),
                Schema = model.Schema == null ? null : model.Schema.ToSyncGroupSchema(),
                UsePrivateLinkConnection = model.UsePrivateLinkConnection,
                Identity = model.Identity
            });

            // Workaround for Rest API return response value incorrect issue. Remove this line after backend fix is deployed
            var resp = Communicator.GetSyncGroup(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName);
            return CreateSyncGroupModelFromResponseV2(model.ResourceGroupName, model.ServerName, model.DatabaseName, resp);
        }

        /// <summary>
        /// Gets a sync member by name
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync member is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        /// <param name="syncMemberName">The name of the sync member</param>
        /// <returns>The sync member object</returns>
        public AzureSqlSyncMemberModelV2 GetSyncMember(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName)
        {
            var resp = Communicator.GetSyncMember(resourceGroupName, serverName, databaseName, new SyncMemberGeneralParameters()
            {
                SyncGroupName = syncGroupName,
                SyncMemberName = syncMemberName,
            });
            return CreateSyncMemberModelFromResponseV2(resourceGroupName, serverName, databaseName, syncGroupName, resp);
        }

        /// <summary>
        /// Gets a list of sync members
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync members are in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        /// <returns>A list of sync member objects</returns>
        internal ICollection<AzureSqlSyncMemberModelV2> ListSyncMembers(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            var resp = Communicator.ListSyncMembers(resourceGroupName, serverName, databaseName, syncGroupName);
            return resp.Select((db) =>
            {
                return CreateSyncMemberModelFromResponseV2(resourceGroupName, serverName, databaseName, syncGroupName, db);
            }).ToList();
        }

        /// <summary>
        /// Create a sync member
        /// </summary>
        /// <param name="model">AzureSqlSyncMemberModel object</param>
        /// <param name="syncAgentId">The sync agent resource id</param>
        /// <returns>Created AzureSqlSyncGroupModel object</returns>
        internal AzureSqlSyncMemberModelV2 CreateSyncMember(AzureSqlSyncMemberModelV2 model, string syncAgentId)
        {
            Management.Sql.DataSyncV2.Models.SyncMember properties = new Management.Sql.DataSyncV2.Models.SyncMember()
            {
                SyncDirection = model.SyncDirection,
                DatabaseType = model.MemberDatabaseType,
            };

            if (properties.DatabaseType == DatabaseTypeEnum.AzureSqlDatabase.ToString())
            {
                properties.DatabaseName = model.MemberDatabaseName;
                properties.ServerName = model.MemberServerName;
                properties.UserName = model.MemberDatabaseUserName;
                properties.Password = model.MemberDatabasePassword == null ? null : AzureSqlServerAdapter.Decrypt(model.MemberDatabasePassword);
                properties.UsePrivateLinkConnection = model.UsePrivateLinkConnection;
                properties.SyncMemberAzureDatabaseResourceId = model.SyncMemberAzureDatabaseResourceId;
                properties.Identity = model.Identity;
            }
            else
            {
                properties.SqlServerDatabaseId = model.SqlServerDatabaseId == null ? null : (Guid?)Guid.Parse(model.SqlServerDatabaseId);
                properties.SyncAgentId = model.SyncAgentId;
            }
            var createResp = Communicator.CreateSyncMember(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName, model.SyncMemberName, syncAgentId, properties);

            // Workaround for Rest API return response value incorrect issue. Remove this line after backend fix is deployed
            var resp = Communicator.GetSyncMember(model.ResourceGroupName, model.ServerName, model.DatabaseName, new SyncMemberGeneralParameters()
            {
                SyncGroupName = model.SyncGroupName,
                SyncMemberName = model.SyncMemberName,
            });
            return CreateSyncMemberModelFromResponseV2(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName, resp);
        }

        /// <summary>
        /// Update a sync member
        /// </summary>
        /// <param name="model">AzureSqlSyncMemberModel object</param>
        /// <returns>Updated AzureSqlSyncGroupModel object</returns>
        internal AzureSqlSyncMemberModelV2 UpdateSyncMember(AzureSqlSyncMemberModelV2 model)
        {
            Management.Sql.DataSyncV2.Models.SyncMember properties = new Management.Sql.DataSyncV2.Models.SyncMember()
            {
                DatabaseType = model.MemberDatabaseType,
                DatabaseName = model.MemberDatabaseName,
                ServerName = model.MemberServerName,
                UserName = model.MemberDatabaseUserName,
                Password = model.MemberDatabasePassword == null ? null : AzureSqlServerAdapter.Decrypt(model.MemberDatabasePassword),
                UsePrivateLinkConnection = model.UsePrivateLinkConnection,
                SyncMemberAzureDatabaseResourceId = model.SyncMemberAzureDatabaseResourceId,
                Identity = model.Identity
            };
            var updateResp = Communicator.UpdateSyncMember(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName, model.SyncMemberName, properties);

            // Workaround for Rest API return response value incorrect issue. Remove this line after backend fix is deployed
            var resp = Communicator.GetSyncMember(model.ResourceGroupName, model.ServerName, model.DatabaseName, new SyncMemberGeneralParameters()
            {
                SyncGroupName = model.SyncGroupName,
                SyncMemberName = model.SyncMemberName,
            });
            return CreateSyncMemberModelFromResponseV2(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName, resp);
        }

        /// <summary>
        /// Converts the response from the service to a powershell sync group object
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync group is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroup">The sync group object from the response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlSyncGroupModelV2 CreateSyncGroupModelFromResponseV2(string resourceGroupName, string serverName, string databaseName, Management.Sql.DataSyncV2.Models.SyncGroup syncGroup)
        {
            return new AzureSqlSyncGroupModelV2(resourceGroupName, serverName, databaseName, syncGroup);
        }

        /// <summary>
        /// Converts the response from the service to a powershell sync member object
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync member is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        /// <param name="syncMember">The sync member object from the response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlSyncMemberModelV2 CreateSyncMemberModelFromResponseV2(string resourceGroupName, string serverName, string databaseName, string syncGroupName, Management.Sql.DataSyncV2.Models.SyncMember syncMember)
        {
            return new AzureSqlSyncMemberModelV2(resourceGroupName, serverName, databaseName, syncGroupName, syncMember);
        }
    }
}
