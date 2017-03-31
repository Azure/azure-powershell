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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Sql.FailoverGroup.Model;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.Sql.FailoverGroup.Services
{
    /// <summary>
    /// Adapter for FailoverGroup operations
    /// </summary>
    public class AzureSqlFailoverGroupAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlFailoverGroupCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a database adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlFailoverGroupAdapter(AzureContext context)
        {
            _subscription = context.Subscription;
            Context = context;
            Communicator = new AzureSqlFailoverGroupCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Database FailoverGroup by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="failoverGroupName">The name of the Azure Sql Database FailoverGroup</param>
        /// <returns>The Azure Sql Database FailoverGroup object</returns>
        internal AzureSqlFailoverGroupModel GetFailoverGroup(string resourceGroupName, string serverName, string failoverGroupName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, failoverGroupName, Util.GenerateTracingId());

            return CreateFailoverGroupModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Databases FailoverGroup.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlFailoverGroupModel> ListFailoverGroups(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName, Util.GenerateTracingId());

            return resp.Select((db) =>
            {
                return CreateFailoverGroupModelFromResponse(resourceGroupName, serverName, db);
            }).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database FailoverGroup.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database FailoverGroup</returns>
        internal AzureSqlFailoverGroupModel UpsertFailoverGroup(AzureSqlFailoverGroupModel model)
        {
            List < FailoverGroupPartnerServer >  partnerServers = new List<FailoverGroupPartnerServer>();
            FailoverGroupPartnerServer partnerServer = new FailoverGroupPartnerServer();
            partnerServer.Id = string.Format(
                AzureSqlFailoverGroupModel.PartnerServerIdTemplate,
                _subscription.Id.ToString(),
                model.PartnerResourceGroupName,
                model.PartnerServerName);
            partnerServers.Add(partnerServer);

            ReadOnlyEndpoint readOnlyEndpoint = new ReadOnlyEndpoint();
            readOnlyEndpoint.FailoverPolicy = model.ReadOnlyFailoverPolicy == null ? AllowReadOnlyFailoverToPrimary.Disabled.ToString() : model.ReadOnlyFailoverPolicy;
            ReadWriteEndpoint readWriteEndpoint = new ReadWriteEndpoint();
            readWriteEndpoint.FailoverPolicy = model.ReadWriteFailoverPolicy == null ? FailoverPolicy.Manual.ToString() : model.ReadWriteFailoverPolicy;

            if (model.FailoverWithDataLossGracePeriodHours.HasValue && !string.Equals(model.ReadWriteFailoverPolicy, FailoverPolicy.Manual.ToString()))
            {
                readWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = model.FailoverWithDataLossGracePeriodHours * 60;
            }
            else
            {
                readWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = null;
            }

            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.FailoverGroupName, Util.GenerateTracingId(), new FailoverGroupCreateOrUpdateParameters()
            {
                Location = model.Location,
                Tags = model.Tags,
                Properties = new FailoverGroupCreateOrUpdateProperties()
                {
                    PartnerServers = partnerServers,
                    ReadOnlyEndpoint = readOnlyEndpoint,
                    ReadWriteEndpoint = readWriteEndpoint,
                }
            });

            return CreateFailoverGroupModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Patch updates an Azure Sql Database FailoverGroup.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database FailoverGroup</returns>
        internal AzureSqlFailoverGroupModel PatchUpdateFailoverGroup(AzureSqlFailoverGroupModel model)
        {
            ReadOnlyEndpoint readOnlyEndpoint = new ReadOnlyEndpoint();
            readOnlyEndpoint.FailoverPolicy = model.ReadOnlyFailoverPolicy == null ? AllowReadOnlyFailoverToPrimary.Disabled.ToString() : model.ReadOnlyFailoverPolicy;

            ReadWriteEndpoint readWriteEndpoint = new ReadWriteEndpoint();
            readWriteEndpoint.FailoverPolicy = model.ReadWriteFailoverPolicy == null ? FailoverPolicy.Manual.ToString() : model.ReadWriteFailoverPolicy;

            if (!string.Equals(model.ReadWriteFailoverPolicy, FailoverPolicy.Manual.ToString()))
            {
                if (!model.FailoverWithDataLossGracePeriodHours.HasValue)
                {
                    readWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = 0;
                }
                else
                {
                    readWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = model.FailoverWithDataLossGracePeriodHours * 60;
                }
            }
            else
            {
                readWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = null;
            }


            var resp = Communicator.PatchUpdate(model.ResourceGroupName, model.ServerName, model.FailoverGroupName, Util.GenerateTracingId(), new FailoverGroupPatchUpdateParameters()
            {
                Location = model.Location,
                Tags = model.Tags,
                Properties = new FailoverGroupPatchUpdateProperties()
                {
                    ReadOnlyEndpoint = readOnlyEndpoint,
                    ReadWriteEndpoint = readWriteEndpoint,
                }
            });

            return CreateFailoverGroupModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }
        /// <summary>
        /// Deletes a failvoer group
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="failvoerGroupName">The name of the Azure SQL Database Failover Group to delete</param>
        public void RemoveFailoverGroup(string resourceGroupName, string serverName, string failoverGroupName)
        {
            Communicator.Remove(resourceGroupName, serverName, failoverGroupName, Util.GenerateTracingId());
        }

        /// <summary>
        /// Gets a list of Azure Sql Databases in a secondary server.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlDatabaseModel> ListDatabasesOnServer(string resourceGroupName, string serverName)
        {
            var resp = Communicator.ListDatabasesOnServer(resourceGroupName, serverName,Util.GenerateTracingId());

            return resp.Select((db) =>
            {
                return AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroupName, serverName, db);
            }).ToList();
        }

        /// <summary>
        /// Patch updates an Azure Sql Database FailoverGroup.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The updated Azure Sql Database FailoverGroup</returns>
        internal AzureSqlFailoverGroupModel AddOrRemoveDatabaseToFailoverGroup(string resourceGroupName, string serverName, string failoverGroupName, AzureSqlFailoverGroupModel model)
        {
            var resp = Communicator.PatchUpdate(resourceGroupName, serverName, failoverGroupName, Util.GenerateTracingId(), new FailoverGroupPatchUpdateParameters()
            {
                Location = model.Location,
                Tags = model.Tags,
                Properties = new FailoverGroupPatchUpdateProperties()
                {
                    Databases = model.Databases,
                }
            });

            return CreateFailoverGroupModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Finds and removes the Secondary Link by the secondary resource group and Azure SQL Server
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="databaseName">The name of primary database</param>
        /// <param name="partnerResourceGroupName">The name of the Resource Group containing the secondary database</param>
        /// <param name="partnerServerName">The name of the Azure SQL Server containing the secondary database</param>
        /// <param name="allowDataLoss">Whether the failover operation will allow data loss</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        internal AzureSqlFailoverGroupModel Failover(string resourceGroupName, string serverName, string failoverGroupName, bool allowDataLoss)
        {

            if (!allowDataLoss)
            {
                Communicator.Failover(resourceGroupName, serverName, failoverGroupName, Util.GenerateTracingId());
            }
            else
            {
                Communicator.ForceFailoverAllowDataLoss(resourceGroupName, serverName, failoverGroupName, Util.GenerateTracingId());
            }

            return null;
        }

        /// <summary>
        /// Gets the Location of the server.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns></returns>
        public string GetServerLocation(string resourceGroupName, string serverName)
        {
            AzureSqlServerAdapter serverAdapter = new AzureSqlServerAdapter(Context);
            var server = serverAdapter.GetServer(resourceGroupName, serverName);
            return server.Location;
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="pool">The service response</param>
        /// <returns>The converted model</returns>
        private AzureSqlFailoverGroupModel CreateFailoverGroupModelFromResponse(string resourceGroup, string serverName, Management.Sql.LegacySdk.Models.FailoverGroup failoverGroup)
        {
            AzureSqlFailoverGroupModel model = new AzureSqlFailoverGroupModel();

            model.ResourceGroupName = resourceGroup;
            model.ServerName = serverName;
            model.FailoverGroupName = failoverGroup.Name;
            model.Databases = failoverGroup.Properties.Databases;
            model.ReadOnlyFailoverPolicy = failoverGroup.Properties.ReadOnlyEndpoint.FailoverPolicy;
            model.ReadWriteFailoverPolicy = failoverGroup.Properties.ReadWriteEndpoint.FailoverPolicy;
            model.ReplicationRole = failoverGroup.Properties.ReplicationRole;
            model.ReplicationState = failoverGroup.Properties.ReplicationState;
            model.PartnerServers = failoverGroup.Properties.PartnerServers;
            model.FailoverWithDataLossGracePeriodHours = failoverGroup.Properties.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes == null ?
                                                        null : failoverGroup.Properties.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes / 60;

            model.Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(failoverGroup.Tags), false);
            model.Location = failoverGroup.Location;;

            return model;
        }
    }
}
