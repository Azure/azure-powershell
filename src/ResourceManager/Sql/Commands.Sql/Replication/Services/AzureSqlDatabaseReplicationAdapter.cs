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
using Microsoft.Azure.Commands.Sql.Replication.Model;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ReplicationLink.Services
{
    /// <summary>
    /// Adapter for database operations
    /// </summary>
    public class AzureSqlDatabaseReplicationAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlDatabaseCopyCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseReplicationCommunicator ReplicationCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the AzureSqlDatabaseCopyCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseCommunicator DatabaseCommunicator { get; set; }

        private AzureSqlServerCommunicator ServerCommunicator { get; set; }
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
        public AzureSqlDatabaseReplicationAdapter(AzureContext context)
        {
            Context = context;
            _subscription = context.Subscription;
            ReplicationCommunicator = new AzureSqlDatabaseReplicationCommunicator(Context);
            DatabaseCommunicator = new AzureSqlDatabaseCommunicator(Context);
            ServerCommunicator = new AzureSqlServerCommunicator(Context);
        }

        /// <summary>
        /// Gets the Location of the Azure SQL Server
        /// </summary>
        /// <param name="resourceGroupName">The resource group the Azure SQL Server is in</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <returns>The region hosting the Azure SQL Server</returns>
        internal string GetServerLocation(string resourceGroupName, string serverName)
        {
            AzureSqlServerAdapter serverAdapter = new AzureSqlServerAdapter(Context);
            var server = serverAdapter.GetServer(resourceGroupName, serverName);
            return server.Location;
        }

        /// <summary>
        /// Gets an Azure SQL Database by name
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <returns>The Azure SQL Database object</returns>
        internal AzureSqlDatabaseModel GetDatabase(string resourceGroupName, string serverName, string databaseName)
        {
            var resp = DatabaseCommunicator.Get(resourceGroupName, serverName, databaseName, Util.GenerateTracingId());
            return AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Creates an Azure SQL Database Copy
        /// </summary>
        /// <param name="copyResourceGroup">The name of the resource group</param>
        /// <param name="copyServerName">The name of the Azure SQL Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The Azure SQL Database Copy object</returns>
        internal AzureSqlDatabaseCopyModel CopyDatabase(string copyResourceGroup, string copyServerName, AzureSqlDatabaseCopyModel model)
        {
            var resp = ReplicationCommunicator.CreateCopy(copyResourceGroup, copyServerName, model.CopyDatabaseName, Util.GenerateTracingId(), new DatabaseCreateOrUpdateParameters()
            {
                Location = model.CopyLocation,
                Properties = new DatabaseCreateOrUpdateProperties()
                {
                    SourceDatabaseId = string.Format(AzureReplicationLinkModel.SourceIdTemplate, _subscription.Id.ToString(),
                        model.ResourceGroupName, model.ServerName, model.DatabaseName),
                    CreateMode = Management.Sql.Models.DatabaseCreateMode.Copy,
                    ElasticPoolName = model.ElasticPoolName,
                    RequestedServiceObjectiveName = model.ServiceObjectiveName,
                }
            });

            return CreateDatabaseCopyModelFromDatabaseCreateOrUpdateResponse(model.CopyResourceGroupName, model.CopyServerName, model.CopyDatabaseName,
                model.ResourceGroupName, model.ServerName, model.DatabaseName, resp);
        }

        /// <summary>
        /// Converts the response from the service to a powershell DatabaseCopy object
        /// </summary>
        /// <param name="copyResourceGroupName">The copy's resource group name</param>
        /// <param name="copyServerName">The copy's Azure SQL Server name</param>
        /// <param name="copyDatabaseName">The copy's database name</param>
        /// <param name="resourceGroupName">The source's resource group name</param>
        /// <param name="serverName">The source's Azure SQL Server name</param>
        /// <param name="databaseName">The source database name</param>
        /// <param name="elasticPoolName">The copy's target elastic pool</param>
        /// <param name="serviceLevelObjective">The copy's nondefault service level objective</param>
        /// <param name="response">The database create response</param>
        /// <returns>A powershell DatabaseCopy object</returns>
        private AzureSqlDatabaseCopyModel CreateDatabaseCopyModelFromDatabaseCreateOrUpdateResponse(string copyResourceGroupName, string copyServerName, string copyDatabaseName,
            string resourceGroupName, string serverName, string databaseName, Management.Sql.Models.DatabaseCreateOrUpdateResponse response)
        {
            // the response does not contain the majority of the information we wish to expose to the user, so most of the data is passed from the inputs.
            AzureSqlDatabaseCopyModel model = new AzureSqlDatabaseCopyModel();

            model.CopyResourceGroupName = copyResourceGroupName;
            model.CopyServerName = copyServerName;
            model.CopyDatabaseName = response.Database.Name;
            model.ResourceGroupName = resourceGroupName;
            model.ServerName = serverName;
            model.DatabaseName = databaseName;
            model.Location = GetServerLocation(resourceGroupName, serverName);
            model.CopyLocation = response.Database.Location;
            model.CreationDate = response.Database.Properties.CreationDate;

            return model;
        }

        /// <summary>
        /// Creates an Azure SQL Database Secondary
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="model">The input parameters for the create operation</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        internal AzureReplicationLinkModel CreateLink(string resourceGroupName, string serverName, AzureReplicationLinkModel model)
        {
            var resp = ReplicationCommunicator.CreateCopy(resourceGroupName, serverName, model.DatabaseName, Util.GenerateTracingId(), new DatabaseCreateOrUpdateParameters()
            {
                Location = model.PartnerLocation,
                Properties = new DatabaseCreateOrUpdateProperties()
                {
                    SourceDatabaseId = string.Format(AzureReplicationLinkModel.SourceIdTemplate, _subscription.Id.ToString(),
                        model.ResourceGroupName, model.ServerName, model.DatabaseName),
                    CreateMode = model.AllowConnections.HasFlag(AllowConnections.All) ? Management.Sql.Models.DatabaseCreateMode.Secondary : Management.Sql.Models.DatabaseCreateMode.NonReadableSecondary,
                    ElasticPoolName = model.SecondaryElasticPoolName,
                    RequestedServiceObjectiveName = model.SecondaryServiceObjectiveName,
                }
            });

            return GetLink(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.PartnerResourceGroupName, model.PartnerServerName);
        }

        /// <summary>
        /// Gets the Secondary Link by linkId
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="databaseName">The name of primary database</param>
        /// <param name="partnerResourceGroupName">The name of the Resource Group containing the secondary database</param>
        /// <param name="linkId">The linkId of the replication link to the secondary</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        internal AzureReplicationLinkModel GetLink(string resourceGroupName, string serverName, string databaseName,
            string partnerResourceGroupName, Guid linkId)
        {
            // partnerResourceGroupName is required because it is not exposed in any reponse from the service.

            var resp = ReplicationCommunicator.GetLink(resourceGroupName, serverName, databaseName, linkId, Util.GenerateTracingId());

            return CreateReplicationLinkModelFromReplicationLinkResponse(resourceGroupName, serverName, databaseName, partnerResourceGroupName, resp);
        }

        /// <summary>
        /// Lists Azure SQL Database Secondaries for the specified primary for the specified partner resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="databaseName">The name of primary database</param>
        /// <param name="partnerResourceGroupName">The name of the Resource Group containing the secondary database</param>
        /// <returns>The collection of Azure SQL Database ReplicationLink objects for the primary</returns>
        internal ICollection<AzureReplicationLinkModel> ListLinks(string resourceGroupName, string serverName, string databaseName,
            string partnerResourceGroupName)
        {
            CheckPartnerResourceGroupValid(partnerResourceGroupName);

            var resp = ReplicationCommunicator.ListLinks(resourceGroupName, serverName, databaseName, Util.GenerateTracingId());

            return resp.Select((link) =>
            {
                return CreateReplicationLinkModelFromReplicationLinkResponse(resourceGroupName, serverName, databaseName, partnerResourceGroupName, link);
            }).ToList();
        }

        private void CheckPartnerResourceGroupValid(string partnerResourceGroupName)
        {
            // checking if the resource group is valid as a partner resource group
            ServerCommunicator.List(partnerResourceGroupName, Util.GenerateTracingId());
        }

        /// <summary>
        /// Converts the response from the service to a powershell Secondary Link object
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="databaseName">The name of primary database</param>
        /// <param name="partnerResourceGroupName">The name of the Resource Group containing the secondary database</param>
        /// <param name="linkId">The linkId of the replication link to the secondary</param>
        /// <param name="response">The replication link response</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        private AzureReplicationLinkModel CreateReplicationLinkModelFromReplicationLinkResponse(string resourceGroupName,
            string serverName, string databaseName, string partnerResourceGroupName, Management.Sql.Models.ReplicationLink resp)
        {
            // partnerResourceGroupName is required because it is not exposed in any reponse from the service.
            // AllowConnections.ReadOnly is not yet supported
            AllowConnections allowConnections = (resp.Properties.Role.Equals(Management.Sql.Models.DatabaseCreateMode.Secondary)
                || resp.Properties.PartnerRole.Equals(Management.Sql.Models.DatabaseCreateMode.Secondary)) ? AllowConnections.All : AllowConnections.No;

            AzureReplicationLinkModel model = new AzureReplicationLinkModel();

            model.LinkId = new Guid(resp.Name);
            model.PartnerResourceGroupName = partnerResourceGroupName;
            model.PartnerServerName = resp.Properties.PartnerServer;
            model.ResourceGroupName = resourceGroupName;
            model.ServerName = serverName;
            model.DatabaseName = databaseName;
            model.AllowConnections = allowConnections;
            model.Location = resp.Location;
            model.PartnerLocation = resp.Properties.PartnerLocation;
            model.PercentComplete = resp.Properties.PercentComplete;
            model.ReplicationState = resp.Properties.ReplicationState;
            model.PartnerRole = resp.Properties.PartnerRole;
            model.Role = resp.Properties.Role;
            model.StartTime = resp.Properties.StartTime.ToString();

            return model;
        }

        /// <summary>
        /// Gets the Secondary Link by the secondary resource group and Azure SQL Server
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="databaseName">The name of primary database</param>
        /// <param name="partnerResourceGroupName">The name of the Resource Group containing the secondary database</param>
        /// <param name="partnerServerName">The name of the Azure SQL Server containing the secondary database</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        internal AzureReplicationLinkModel GetLink(string resourceGroupName, string serverName, string databaseName,
            string partnerResourceGroupName, string partnerServerName)
        {
            IList<AzureReplicationLinkModel> links = ListLinks(resourceGroupName, serverName, databaseName, partnerResourceGroupName).ToList();

            // Resource Management executes in context of the Secondary
            return links.FirstOrDefault(l => l.PartnerServerName == partnerServerName);
        }

        /// <summary>
        /// Finds and removes the Secondary Link by the secondary resource group and Azure SQL Server
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="databaseName">The name of primary database</param>
        /// <param name="partnerResourceGroupName">The name of the Resource Group containing the secondary database</param>
        /// <param name="partnerServerName">The name of the Azure SQL Server containing the secondary database</param>
        internal void RemoveLink(string resourceGroupName, string serverName, string databaseName, string partnerResourceGroupName, string partnerServerName)
        {
            AzureReplicationLinkModel link = GetLink(resourceGroupName, serverName, databaseName, partnerResourceGroupName, partnerServerName);

            ReplicationCommunicator.RemoveLink(link.ResourceGroupName, link.ServerName, link.DatabaseName, link.LinkId, Util.GenerateTracingId());
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
        internal AzureReplicationLinkModel FailoverLink(string resourceGroupName, string serverName, string databaseName, string partnerResourceGroupName, bool allowDataLoss)
        {
            IList<AzureReplicationLinkModel> links = ListLinks(resourceGroupName, serverName, databaseName, partnerResourceGroupName).ToList();

            // Resource Management executes in context of the Secondary
            AzureReplicationLinkModel link = links.First();

            if (allowDataLoss)
            {
                ReplicationCommunicator.FailoverLinkAllowDataLoss(link.ResourceGroupName, link.ServerName, link.DatabaseName, link.LinkId, Util.GenerateTracingId());
            }
            else
            {
                ReplicationCommunicator.FailoverLink(link.ResourceGroupName, link.ServerName, link.DatabaseName, link.LinkId, Util.GenerateTracingId());
            }

            return GetLink(link.PartnerResourceGroupName, link.PartnerServerName, link.DatabaseName, link.PartnerResourceGroupName, link.PartnerServerName);
        }
    }
}
