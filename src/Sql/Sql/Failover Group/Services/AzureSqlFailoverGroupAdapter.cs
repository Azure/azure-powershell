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
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

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
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private IAzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a database adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlFailoverGroupAdapter(IAzureContext context)
        {
            _subscription = context?.Subscription;
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
            var response = Communicator.GetV2(resourceGroupName, serverName, failoverGroupName);
            return CreateCurrentFailoverGroupModelFromResponse(response);
        }

        /// <summary>
        /// Gets a list of Azure Sql Databases FailoverGroup.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlFailoverGroupModel> ListFailoverGroups(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName);

            return resp.Select((db) =>
            {
                return CreateCurrentFailoverGroupModelFromResponse(db);
            }).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database FailoverGroup.
        /// </summary>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <param name="useV2">Whether to use the V2 function and current model, or the legacy functaion and model</param>
        /// <returns>The upserted Azure Sql Database FailoverGroup</returns>
        internal AzureSqlFailoverGroupModel UpsertFailoverGroup(AzureSqlFailoverGroupModel model, bool useV2 = false)
        {
            List<FailoverGroupPartnerServer> partnerServers;

            if (model.PartnerServers != null)
            {
                partnerServers = model.PartnerServers.ToList();
            }
            else
            {
                partnerServers = new List<FailoverGroupPartnerServer>();
                FailoverGroupPartnerServer partnerServer = new FailoverGroupPartnerServer();
                partnerServer.Id = string.Format(
                    AzureSqlFailoverGroupModel.PartnerServerIdTemplate,
                    model.PartnerSubscriptionId == null ? _subscription.Id.ToString() : model.PartnerSubscriptionId.ToString(),
                    model.PartnerResourceGroupName,
                    model.PartnerServerName);
                partnerServers.Add(partnerServer);
            }

            ReadOnlyEndpoint readOnlyEndpoint = new ReadOnlyEndpoint();
            readOnlyEndpoint.FailoverPolicy = model.ReadOnlyFailoverPolicy;
            ReadWriteEndpoint readWriteEndpoint = new ReadWriteEndpoint();
            readWriteEndpoint.FailoverPolicy = model.ReadWriteFailoverPolicy;

            if (model.FailoverWithDataLossGracePeriodHours.HasValue)
            {
                readWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = checked(model.FailoverWithDataLossGracePeriodHours * 60);
            }

            if (useV2)
            {
                Management.Sql.Models.FailoverGroup updateV2Params = new Management.Sql.Models.FailoverGroup()
                {
                    ReadWriteEndpoint = model.FailoverGroupReadWriteEndpointV2,
                    ReadOnlyEndpoint = model.FailoverGroupReadOnlyEndpointV2,
                    Databases = model.Databases,
                    PartnerServers = ConvertPartnerServerList(partnerServers)
                };
                var response = Communicator.CreateOrUpdateV2(model.ResourceGroupName, model.ServerName, model.FailoverGroupName, updateV2Params);
                return CreateCurrentFailoverGroupModelFromResponse(response);
            }

            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.FailoverGroupName, new FailoverGroupCreateOrUpdateParameters()
            {
                Location = model.Location,
                Properties = new FailoverGroupCreateOrUpdateProperties()
                {
                    PartnerServers = partnerServers,
                    ReadOnlyEndpoint = readOnlyEndpoint,
                    ReadWriteEndpoint = readWriteEndpoint,
                }
            });

            return CreateFailoverGroupModelFromResponse(resp);
        }

        /// <summary>
        /// Patch updates an Azure Sql Database FailoverGroup.
        /// </summary>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <param name="useV2">Whether to use the V2 function and current model, or the legacy functaion and model</param>
        /// <returns>The upserted Azure Sql Database FailoverGroup</returns>
        internal AzureSqlFailoverGroupModel PatchUpdateFailoverGroup(AzureSqlFailoverGroupModel model, bool useV2 = false)
        {
            ReadOnlyEndpoint readOnlyEndpoint = new ReadOnlyEndpoint();
            readOnlyEndpoint.FailoverPolicy = model.ReadOnlyFailoverPolicy;

            ReadWriteEndpoint readWriteEndpoint = new ReadWriteEndpoint();
            readWriteEndpoint.FailoverPolicy = model.ReadWriteFailoverPolicy;

            if (model.FailoverWithDataLossGracePeriodHours.HasValue)
            {
                readWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = checked(model.FailoverWithDataLossGracePeriodHours * 60);
            }

            if (useV2)
            {
                FailoverGroupUpdate updateV2Params = new FailoverGroupUpdate()
                {
                    ReadOnlyEndpoint = model.FailoverGroupReadOnlyEndpointV2,
                    ReadWriteEndpoint = model.FailoverGroupReadWriteEndpointV2,
                    PartnerServers = ConvertPartnerServerList(model.PartnerServers.ToList()),
                    Databases = model.Databases

                };
                var response = Communicator.PatchUpdateV2(model.ResourceGroupName, model.ServerName, model.FailoverGroupName, updateV2Params);
                return CreateCurrentFailoverGroupModelFromResponse(response);
            }

            var resp = Communicator.PatchUpdate(model.ResourceGroupName, model.ServerName, model.FailoverGroupName, new FailoverGroupPatchUpdateParameters()
            {
                Location = model.Location,
                Properties = new FailoverGroupPatchUpdateProperties()
                {
                    ReadOnlyEndpoint = readOnlyEndpoint,
                    ReadWriteEndpoint = readWriteEndpoint,
                }
            });

            return CreateFailoverGroupModelFromResponse(resp);
        }
        /// <summary>
        /// Deletes a failvoer group
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="failoverGroupName">The name of the Azure SQL Database Failover Group to delete</param>
        public void RemoveFailoverGroup(string resourceGroupName, string serverName, string failoverGroupName)
        {
            Communicator.Remove(resourceGroupName, serverName, failoverGroupName);
        }

        /// <summary>
        /// Gets a list of Azure Sql Databases in a secondary server.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlDatabaseModel> ListDatabasesOnServer(string resourceGroupName, string serverName)
        {
            var resp = Communicator.ListDatabasesOnServer(resourceGroupName, serverName);

            return resp.Select((db) =>
            {
                return AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroupName, serverName, db);
            }).ToList();
        }

        /// <summary>
        /// Patch updates an Azure Sql Database FailoverGroup.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="failoverGroupName">The name of the Azure Sql Database FailoverGroup</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The updated Azure Sql Database FailoverGroup</returns>
        internal AzureSqlFailoverGroupModel AddOrRemoveDatabaseToFailoverGroup(string resourceGroupName, string serverName, string failoverGroupName, AzureSqlFailoverGroupModel model)
        {
            var resp = Communicator.PatchUpdateV2(resourceGroupName, serverName, failoverGroupName, new FailoverGroupUpdate()
            {
                Databases = model.Databases,
            });

            return CreateCurrentFailoverGroupModelFromResponse(resp);
        }

        /// <summary>
        /// Finds and removes the Secondary Link by the secondary resource group and Azure SQL Server
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="failoverGroupName">The name of the Azure Sql Database FailoverGroup</param>
        /// <param name="allowDataLoss">Whether the failover operation will allow data loss</param>
        /// <param name="tryPlannedBeforeForcedFailover">Whether the failover operation will try planned before forced failover</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        internal AzureSqlFailoverGroupModel Failover(string resourceGroupName, string serverName, string failoverGroupName, bool allowDataLoss, bool tryPlannedBeforeForcedFailover)
        {
            if (tryPlannedBeforeForcedFailover)
            {
                Communicator.TryPlannedBeforeForcedFailover(resourceGroupName, serverName, failoverGroupName);
                return null;
            }
            if (!allowDataLoss)
            {
                Communicator.Failover(resourceGroupName, serverName, failoverGroupName);
            }
            else
            {
                Communicator.ForceFailoverAllowDataLoss(resourceGroupName, serverName, failoverGroupName);
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
        /// <param name="failoverGroup">Recommended Action object</param>
        /// <returns>The converted model</returns>
        private AzureSqlFailoverGroupModel CreateFailoverGroupModelFromResponse(Management.Sql.LegacySdk.Models.FailoverGroup failoverGroup)
        {
            AzureSqlFailoverGroupModel model = new AzureSqlFailoverGroupModel();

            model.FailoverGroupName = failoverGroup.Name;
            model.Databases = failoverGroup.Properties.Databases;
            model.ReadOnlyFailoverPolicy = failoverGroup.Properties.ReadOnlyEndpoint.FailoverPolicy;
            model.ReadWriteFailoverPolicy = failoverGroup.Properties.ReadWriteEndpoint.FailoverPolicy;
            model.ReplicationRole = failoverGroup.Properties.ReplicationRole;
            model.ReplicationState = failoverGroup.Properties.ReplicationState;
            model.PartnerServers = failoverGroup.Properties.PartnerServers;
            model.FailoverWithDataLossGracePeriodHours = failoverGroup.Properties.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes == null ?
                                                        null : failoverGroup.Properties.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes / 60;

            model.Id = failoverGroup.Id;
            model.Location = failoverGroup.Location;

            model.DatabaseNames = failoverGroup.Properties.Databases
                .Select(dbId => GetUriSegment(dbId, 10))
                .ToList();

            model.ResourceGroupName = GetUriSegment(failoverGroup.Id, 4);
            model.ServerName = GetUriSegment(failoverGroup.Id, 8);

            FailoverGroupPartnerServer partnerServer = failoverGroup.Properties.PartnerServers.FirstOrDefault();
            if (partnerServer != null)
            {
                model.PartnerSubscriptionId = GetUriSegment(partnerServer.Id, 2);
                model.PartnerResourceGroupName = GetUriSegment(partnerServer.Id, 4);
                model.PartnerServerName = GetUriSegment(partnerServer.Id, 8);
                model.PartnerLocation = partnerServer.Location;
            }

            return model;
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object.
        /// Accepts current client model instead of legacy.
        /// </summary>
        /// <param name="failoverGroup">Recommended Action object</param>
        /// <returns>The converted model</returns>
        private AzureSqlFailoverGroupModel CreateCurrentFailoverGroupModelFromResponse(Management.Sql.Models.FailoverGroup failoverGroup)
        {
            AzureSqlFailoverGroupModel model = new AzureSqlFailoverGroupModel();

            model.FailoverGroupName = failoverGroup.Name;
            model.Databases = failoverGroup.Databases;
            model.ReadOnlyFailoverPolicy = failoverGroup.ReadOnlyEndpoint.FailoverPolicy;
            model.ReadWriteFailoverPolicy = failoverGroup.ReadWriteEndpoint.FailoverPolicy;
            model.FailoverGroupReadOnlyEndpointV2 = failoverGroup.ReadOnlyEndpoint;
            model.ReplicationRole = failoverGroup.ReplicationRole;
            model.ReplicationState = failoverGroup.ReplicationState;
            model.PartnerServers = ConvertPartnerInfoList(failoverGroup.PartnerServers.ToList());
            model.FailoverWithDataLossGracePeriodHours = failoverGroup.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes == null ?
                                                        null : failoverGroup.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes / 60;

            model.Id = failoverGroup.Id;
            model.Location = failoverGroup.Location;

            model.DatabaseNames = failoverGroup.Databases
                .Select(dbId => GetUriSegment(dbId, 10))
                .ToList();

            model.ResourceGroupName = GetUriSegment(failoverGroup.Id, 4);
            model.ServerName = GetUriSegment(failoverGroup.Id, 8);

            if (failoverGroup.PartnerServers.Count == 1)
            {
                PartnerInfo partnerServer = failoverGroup.PartnerServers.FirstOrDefault();
                if (partnerServer != null)
                {
                    model.PartnerSubscriptionId = GetUriSegment(partnerServer.Id, 2);
                    model.PartnerResourceGroupName = GetUriSegment(partnerServer.Id, 4);
                    model.PartnerServerName = GetUriSegment(partnerServer.Id, 8);
                    model.PartnerLocation = partnerServer.Location;
                }
            } 

            model.PartnerServers = ConvertPartnerInfoList(failoverGroup.PartnerServers.ToList());


            return model;
        }

        private string GetUriSegment(string uri, int segmentNum)
        {
            if (uri != null)
            {
                var segments = uri.Split('/');

                if (segments.Length > segmentNum)
                {
                    return segments[segmentNum];
                }
            }

            return null;
        }

        private List<PartnerInfo> ConvertPartnerServerList(List<FailoverGroupPartnerServer> partnerServersLegacy)
        {
            List<PartnerInfo> partnerServersV2 = new List<PartnerInfo>();

            foreach (FailoverGroupPartnerServer partnerServer in partnerServersLegacy)
            {
                partnerServersV2.Add(new PartnerInfo(partnerServer.Id, partnerServer.Location, partnerServer.ReplicationRole));
            }
            return partnerServersV2;
        }

        private List<FailoverGroupPartnerServer> ConvertPartnerInfoList(List<PartnerInfo> partnerServersV2)
        {
            List<FailoverGroupPartnerServer> partnerServersLegacy = new List<FailoverGroupPartnerServer>();

            foreach (PartnerInfo partnerServer in partnerServersV2)
            {
                partnerServersLegacy.Add(new FailoverGroupPartnerServer() 
                {
                    Id = partnerServer.Id, 
                    Location = partnerServer.Location, 
                    ReplicationRole = partnerServer.ReplicationRole
                });
            }
            return partnerServersLegacy;
        }
    }
}
