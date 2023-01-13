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
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Server.Adapter;

namespace Microsoft.Azure.Commands.Sql.DataSync.Services
{
    /// <summary>
    /// Adapter for data sync operations
    /// </summary>
    public class AzureSqlDataSyncAdapter
    {
        /// <summary>
        /// Gets or sets the AzureDataSyncCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDataSyncCommunicator Communicator { get; set; }

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
        public AzureSqlDataSyncAdapter(IAzureContext context)
        {
            Context = context;
            _subscription = context?.Subscription;
            Communicator = new AzureSqlDataSyncCommunicator(Context);
        }

        /// <summary>
        /// Gets a sync group by name
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync group is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        /// <returns>The sync group object</returns>
        public AzureSqlSyncGroupModel GetSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            var resp = Communicator.GetSyncGroup(resourceGroupName, serverName, databaseName, syncGroupName);
            return CreateSyncGroupModelFromResponse(resourceGroupName, serverName, databaseName, resp);
        }

        /// <summary>
        /// Gets a list of sync groups
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync group is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <returns>A list of sync group objects</returns>
        internal ICollection<AzureSqlSyncGroupModel> ListSyncGroups(string resourceGroupName, string serverName, string databaseName)
        {
            var resp = Communicator.ListSyncGroups(resourceGroupName, serverName, databaseName);
            return resp.Select((db) =>{
                return CreateSyncGroupModelFromResponse(resourceGroupName, serverName, databaseName, db);
            }).ToList();
        }

        /// <summary>
        /// Gets a list of sync group logs
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync group is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="parameters">Parameters of get sync group log</param>
        /// <returns>A list of sync group log objects</returns>
        internal ICollection<AzureSqlSyncGroupLogModel> ListSyncGroupLogs(string resourceGroupName, string serverName, string databaseName, SyncGroupLogGetParameters parameters)
        {
            List<AzureSqlSyncGroupLogModel> result = new List<AzureSqlSyncGroupLogModel>();
            var resp = Communicator.ListSyncGroupLogs(resourceGroupName, serverName, databaseName, parameters);
            result.AddRange(resp.SyncGroupLogs.Select((db) =>
            {
                return CreateSyncGroupLogModelFromResponse(db);
            }));

            while(!string.IsNullOrEmpty(resp.NextLink))
            {
                resp = Communicator.ListNextSyncGroupLog(resourceGroupName, serverName, databaseName, parameters.SyncGroupName, resp.NextLink);
                result.AddRange(resp.SyncGroupLogs.Select((db) =>
                {
                    return CreateSyncGroupLogModelFromResponse(db);
                }));
            }
            return result;
        }

        /// <summary>
        /// Trigger synchronization of a sync group
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync group is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        public void StartSynchronization(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            Communicator.StartSynchronization(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Cancel synchronization of a sync group
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync group is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        public void StopSynchronization(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            Communicator.StopSynchronization(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Invoke the member database schema of sync member refreshing
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync member is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        /// <param name="syncMemberName">The name of the sync member</param>
        public void InvokeSyncMemberSchemaRefresh(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName)
        {
            Communicator.InvokeSyncMemberSchemaRefresh(resourceGroupName, serverName, databaseName, new SyncMemberGeneralParameters()
            {
                SyncGroupName = syncGroupName,
                SyncMemberName = syncMemberName,
            });
        }

        /// <summary>
        /// Create a sync group
        /// </summary>
        /// <param name="model">AzureSqlSyncGroupModel object</param>
        /// <param name="syncDatabaseId">The sync database resource id</param>
        /// <returns>Created AzureSqlSyncGroupModel object</returns>
        internal AzureSqlSyncGroupModel CreateSyncGroup(AzureSqlSyncGroupModel model, string syncDatabaseId)
        {
            var createResp = Communicator.CreateSyncGroup(model.ResourceGroupName, model.ServerName, model.DatabaseName, syncDatabaseId, model.SyncGroupName, new Management.Sql.Models.SyncGroup()
            {
                ConflictResolutionPolicy = model.ConflictResolutionPolicy,
                Interval = model.IntervalInSeconds,
                HubDatabaseUserName = model.HubDatabaseUserName,
                HubDatabasePassword = model.HubDatabasePassword == null ? null : AzureSqlServerAdapter.Decrypt(model.HubDatabasePassword),
                Schema = model.Schema == null ? null : model.Schema.ToSyncGroupSchema(),
                UsePrivateLinkConnection = model.UsePrivateLinkConnection,
            });

            // Workaround for Rest API return response value incorrect issue. Remove this line after backend fix is deployed
            var resp = Communicator.GetSyncGroup(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName);
            return CreateSyncGroupModelFromResponse(model.ResourceGroupName, model.ServerName, model.DatabaseName, resp);
        }

        /// <summary>
        /// Update a sync group
        /// </summary>
        /// <param name="model">AzureSqlSyncGroupModel object</param>
        /// <returns>Updated AzureSqlSyncGroupModel object</returns>
        internal AzureSqlSyncGroupModel UpdateSyncGroup(AzureSqlSyncGroupModel model)
        {
            var updateResp = Communicator.UpdateSyncGroup(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName, new Management.Sql.Models.SyncGroup()
            {
                Interval = model.IntervalInSeconds,
                HubDatabaseUserName = model.HubDatabaseUserName,
                HubDatabasePassword = model.HubDatabasePassword == null ? null: AzureSqlServerAdapter.Decrypt(model.HubDatabasePassword),
                Schema = model.Schema == null ? null : model.Schema.ToSyncGroupSchema(),
                UsePrivateLinkConnection = model.UsePrivateLinkConnection,
            });
            
            // Workaround for Rest API return response value incorrect issue. Remove this line after backend fix is deployed
            var resp = Communicator.GetSyncGroup(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName);
            return CreateSyncGroupModelFromResponse(model.ResourceGroupName, model.ServerName, model.DatabaseName, resp);
        }

        /// <summary>
        /// Remove a sync group
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync group is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        public void RemoveSyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            Communicator.RemoveSyncGroup(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Invoke the hub database schema of sync member refresh
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync member is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        public void InvokeSyncHubSchemaRefresh(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            Communicator.InvokeSyncHubSchemaRefresh(resourceGroupName, serverName, databaseName, syncGroupName);
        }

        /// <summary>
        /// Gets the full schema of hub database of a sync group
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync member is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        /// <returns>The sync member object</returns>
        public AzureSqlSyncFullSchemaModel GetSyncHubSchema(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            var resp = Communicator.GetSyncHubSchema(resourceGroupName, serverName, databaseName, syncGroupName);
            return new AzureSqlSyncFullSchemaModel(resp);
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
        public AzureSqlSyncMemberModel GetSyncMember(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName)
        {
            var resp = Communicator.GetSyncMember(resourceGroupName, serverName, databaseName, new SyncMemberGeneralParameters()
            {
                SyncGroupName = syncGroupName,
                SyncMemberName = syncMemberName,
            });
            return CreateSyncMemberModelFromResponse(resourceGroupName, serverName, databaseName, syncGroupName, resp);
        }

        /// <summary>
        /// Gets a list of sync members
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync members are in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        /// <returns>A list of sync member objects</returns>
        internal ICollection<AzureSqlSyncMemberModel> ListSyncMembers(string resourceGroupName, string serverName, string databaseName, string syncGroupName)
        {
            var resp = Communicator.ListSyncMembers(resourceGroupName, serverName, databaseName, syncGroupName);
            return resp.Select((db) =>
            {
                return CreateSyncMemberModelFromResponse(resourceGroupName, serverName, databaseName, syncGroupName, db);
            }).ToList();
        }

        /// <summary>
        /// Remove a sync member
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync member is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        /// <param name="syncMemberName">The name of the sync member</param>
        public void RemoveSyncMember(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName)
        {
            Communicator.RemoveSyncMember(resourceGroupName, serverName, databaseName, new SyncMemberGeneralParameters()
            {
                SyncGroupName = syncGroupName,
                SyncMemberName = syncMemberName,
            });
        }

        /// <summary>
        /// Create a sync member
        /// </summary>
        /// <param name="model">AzureSqlSyncMemberModel object</param>
        /// <param name="syncAgentId">The sync agent resource id</param>
        /// <returns>Created AzureSqlSyncGroupModel object</returns>
        internal AzureSqlSyncMemberModel CreateSyncMember(AzureSqlSyncMemberModel model, string syncAgentId)
        {
            Management.Sql.Models.SyncMember properties = new Management.Sql.Models.SyncMember()
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
            return CreateSyncMemberModelFromResponse(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName, resp);
        }

        /// <summary>
        /// Update a sync member
        /// </summary>
        /// <param name="model">AzureSqlSyncMemberModel object</param>
        /// <returns>Updated AzureSqlSyncGroupModel object</returns>
        internal AzureSqlSyncMemberModel UpdateSyncMember(AzureSqlSyncMemberModel model)
        {
            Management.Sql.Models.SyncMember properties = new Management.Sql.Models.SyncMember()
            {
                DatabaseType = model.MemberDatabaseType,
                DatabaseName = model.MemberDatabaseName,
                ServerName = model.MemberServerName,
                UserName = model.MemberDatabaseUserName,
                Password = model.MemberDatabasePassword == null ? null : AzureSqlServerAdapter.Decrypt(model.MemberDatabasePassword),
                UsePrivateLinkConnection = model.UsePrivateLinkConnection,
                SyncMemberAzureDatabaseResourceId = model.SyncMemberAzureDatabaseResourceId
            };
            var updateResp = Communicator.UpdateSyncMember(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName, model.SyncMemberName, properties);

            // Workaround for Rest API return response value incorrect issue. Remove this line after backend fix is deployed
            var resp = Communicator.GetSyncMember(model.ResourceGroupName, model.ServerName, model.DatabaseName, new SyncMemberGeneralParameters()
            {
                SyncGroupName = model.SyncGroupName,
                SyncMemberName = model.SyncMemberName,
            });
            return CreateSyncMemberModelFromResponse(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.SyncGroupName, resp);
        }

        /// <summary>
        /// Gets the full schema of member database of a sync member
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync member is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroupName">The name of the sync group</param>
        /// <param name="syncMemberName">The name of the sync member</param>
        /// <returns>The sync member object</returns>
        public AzureSqlSyncFullSchemaModel GetSyncMemberSchema(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName)
        {
            var resp = Communicator.GetSyncMemberSchema(resourceGroupName, serverName, databaseName, new SyncMemberGeneralParameters()
            {
                SyncGroupName = syncGroupName,
                SyncMemberName = syncMemberName,
            });
            return new AzureSqlSyncFullSchemaModel(resp);
        }

        /// <summary>
        /// Gets a sync agent by name
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync agent is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="syncAgentName">The name of the sync agent</param>
        /// <returns>The sync agent object</returns>
        public AzureSqlSyncAgentModel GetSyncAgent(string resourceGroupName, string serverName, string syncAgentName)
        {
            var resp = Communicator.GetSyncAgent(resourceGroupName, serverName, syncAgentName);
            return CreateSyncAgentModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of sync agents
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync agents are in</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns>A list of sync agent objects</returns>
        internal ICollection<AzureSqlSyncAgentModel> ListSyncAgents(string resourceGroupName, string serverName)
        {
            var resp = Communicator.ListSyncAgents(resourceGroupName, serverName);

            return resp.Select((db) =>
            {
                return CreateSyncAgentModelFromResponse(resourceGroupName, serverName, db);
            }).ToList();
        }

        /// <summary>
        /// Create a sync agent
        /// </summary>
        /// <param name="model">AzureSqlSyncAgentModel object</param>
        /// <param name="syncDatabaseId">The sync database resource id</param>
        /// <returns>Created AzureSqlSyncAgentModel object</returns>
        internal AzureSqlSyncAgentModel CreateSyncAgent(AzureSqlSyncAgentModel model, string syncDatabaseId)
        {
            var resp = Communicator.CreateSyncAgent(model.ResourceGroupName, model.ServerName, model.SyncAgentName, syncDatabaseId, new SyncAgentCreateOrUpdateParameters()
            {
                Properties = new SyncAgentCreateOrUpdateProperties()
                {
                    SyncDatabaseId = model.SyncDatabaseId
                }
            });

            // Workaround for Rest API return response value incorrect issue. Remove this line after backend fix is deployed
            resp = Communicator.GetSyncAgent(model.ResourceGroupName, model.ServerName, model.SyncAgentName);
            return CreateSyncAgentModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Remove a sync agent
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync agent is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="syncAgentName">The name of the sync agent</param>
        public void RemoveSyncAgent(string resourceGroupName, string serverName, string syncAgentName)
        {
            Communicator.RemoveSyncAgent(resourceGroupName, serverName, syncAgentName);
        }

        /// <summary>
        /// Generate a sync agent key
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync agent is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="syncAgentName">The name of the sync agent</param>
        internal AzureSqlSyncAgentKeyModel CreateSyncAgentKey(string resourceGroupName, string serverName, string syncAgentName)
        {
            var resp = Communicator.CreateSyncAgentKey(resourceGroupName, serverName, syncAgentName);
            return new AzureSqlSyncAgentKeyModel()
            {
                SyncAgentKey = resp.SyncAgentKey,
            };
        }

        /// <summary>
        /// Get all linked databases connected by a specified sync agent
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync agent is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="syncAgentName">The name of the sync agent</param>
        internal ICollection<AzureSqlSyncAgentLinkedDatabaseModel> ListSyncAgentLinkedDatabases(string resourceGroupName, string serverName, string syncAgentName)
        {
            var resp = Communicator.ListSyncAgentLinkedDatabases(resourceGroupName, serverName, syncAgentName);
            return resp.Select((db) =>
            {
                return new AzureSqlSyncAgentLinkedDatabaseModel(db);
            }).ToList();
        }

        /// <summary>
        /// Converts the response from the service to a powershell sync group object
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sync group is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="syncGroup">The sync group object from the response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlSyncGroupModel CreateSyncGroupModelFromResponse(string resourceGroupName, string serverName, string databaseName, Management.Sql.Models.SyncGroup syncGroup)
        {
            return new AzureSqlSyncGroupModel(resourceGroupName, serverName, databaseName, syncGroup);
        }

        /// <summary>
        /// Converts the response from the service to a powershell sync group log object
        /// </summary>
        /// <param name="syncGroupLog">The sync group log object from the response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlSyncGroupLogModel CreateSyncGroupLogModelFromResponse(SyncGroupLog syncGroupLog)
        {
            return new AzureSqlSyncGroupLogModel(syncGroupLog);
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
        public static AzureSqlSyncMemberModel CreateSyncMemberModelFromResponse(string resourceGroupName, string serverName, string databaseName, string syncGroupName, Management.Sql.Models.SyncMember syncMember)
        {
            return new AzureSqlSyncMemberModel(resourceGroupName, serverName, databaseName, syncGroupName, syncMember);
        }

        /// <summary>
        /// Converts the response from the service to a powershell sync agent object
        /// </summary>
        /// <param name="resourceGroupName">The resource group the agent is in</param>
        /// <param name="serverName">The server name</param>
        /// <param name="syncAgent">The sync agent object from the response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlSyncAgentModel CreateSyncAgentModelFromResponse(string resourceGroupName, string serverName, SyncAgent syncAgent)
        {
            return new AzureSqlSyncAgentModel(resourceGroupName, serverName, syncAgent);
        }
    }
}
