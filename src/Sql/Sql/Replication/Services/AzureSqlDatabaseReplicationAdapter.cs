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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Sql.Replication.Model;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
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
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private IAzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a database adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlDatabaseReplicationAdapter(IAzureContext context)
        {
            Context = context;
            _subscription = context?.Subscription;
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
            var resp = DatabaseCommunicator.Get(resourceGroupName, serverName, databaseName);
            return AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Creates an Azure SQL Database Copy with Legacy SDK (Hyak SDK)
        /// </summary>
        /// <param name="copyResourceGroup">The name of the resource group</param>
        /// <param name="copyServerName">The name of the Azure SQL Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The Azure SQL Database Copy object</returns>
        internal AzureSqlDatabaseCopyModel CopyDatabase(string copyResourceGroup, string copyServerName, AzureSqlDatabaseCopyModel model)
        {
            var resp = ReplicationCommunicator.CreateCopy(copyResourceGroup, copyServerName, model.CopyDatabaseName, new DatabaseCreateOrUpdateParameters()
            {
                Location = model.CopyLocation,
                Properties = new DatabaseCreateOrUpdateProperties()
                {
                    SourceDatabaseId = string.Format(AzureReplicationLinkModel.SourceIdTemplate, _subscription.Id.ToString(),
                        model.ResourceGroupName, model.ServerName, model.DatabaseName),
                    CreateMode = Management.Sql.LegacySdk.Models.DatabaseCreateMode.Copy,
                    ElasticPoolName = model.ElasticPoolName,
                    RequestedServiceObjectiveName = model.ServiceObjectiveName,
                }
            });

            return CreateDatabaseCopyModelFromDatabaseCreateOrUpdateResponse(model.CopyResourceGroupName, model.CopyServerName, model.CopyDatabaseName,
                model.ResourceGroupName, model.ServerName, model.DatabaseName, resp);
        }

        /// <summary>
        /// Creates an Azure SQL Database Copy with new AutoRest SDK
        /// </summary>
        /// <param name="copyResourceGroup">The name of the resource group</param>
        /// <param name="copyServerName">The name of the Azure SQL server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns></returns>
        internal AzureSqlDatabaseCopyModel CopyDatabaseWithNewSdk(string copyResourceGroup, string copyServerName, AzureSqlDatabaseCopyModel model)
        {
            // Construct the ARM resource Id of the pool
            string elasticPoolId = string.IsNullOrWhiteSpace(model.ElasticPoolName) ? null : AzureSqlDatabaseModel.PoolIdTemplate.FormatInvariant(
                        _subscription.Id,
                        copyResourceGroup,
                        copyServerName,
                        model.ElasticPoolName);

            // Create copy of the database
            var resp = ReplicationCommunicator.CreateCopy(copyResourceGroup, copyServerName, model.CopyDatabaseName, new Management.Sql.Models.Database(model.CopyLocation, tags: model.Tags)
            {
                CreateMode = Management.Sql.Models.CreateMode.Copy,
                SourceDatabaseId = string.Format(AzureReplicationLinkModel.SourceIdTemplate, _subscription.Id.ToString(),
                        model.ResourceGroupName, model.ServerName, model.DatabaseName),
                ElasticPoolId = elasticPoolId,
                Sku = string.IsNullOrWhiteSpace(model.SkuName) ? null : new Management.Sql.Models.Sku()
                {
                    Name = model.SkuName,
                    Tier = model.Edition,
                    Family = model.Family,
                    Capacity = model.Capacity
                },
                LicenseType = model.LicenseType,
                RequestedBackupStorageRedundancy = model.RequestedBackupStorageRedundancy,
                ZoneRedundant = model.ZoneRedundant
            });

            return CreateDatabaseCopyModelFromResponse(model.CopyResourceGroupName, model.CopyServerName, model.ResourceGroupName,
                model.ServerName, model.DatabaseName, resp);
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
        /// <param name="response">The database create response</param>
        /// <returns>A powershell DatabaseCopy object</returns>
        private AzureSqlDatabaseCopyModel CreateDatabaseCopyModelFromDatabaseCreateOrUpdateResponse(string copyResourceGroupName, string copyServerName, string copyDatabaseName,
            string resourceGroupName, string serverName, string databaseName, Management.Sql.LegacySdk.Models.DatabaseCreateOrUpdateResponse response)
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
        /// Converts the response from the service to a powershell DatabaseCopy object
        /// </summary>
        /// <param name="copyResourceGroup">The copy's resource group name</param>
        /// <param name="copyServerName">The copy's Azure SQL Server name</param>
        /// <param name="resourceGroupName">The source's resource group name</param>
        /// <param name="serverName">The source's Azure SQL Server name</param>
        /// <param name="databaseName">The source database name</param>
        /// <param name="database">The database create response</param>
        /// <returns>A powershell DatabaseCopy object</returns>
        private AzureSqlDatabaseCopyModel CreateDatabaseCopyModelFromResponse(string copyResourceGroup, string copyServerName, string resourceGroupName, 
            string serverName, string databaseName, Management.Sql.Models.Database database)
        {
            AzureSqlDatabaseCopyModel model = new AzureSqlDatabaseCopyModel();

            model.CopyResourceGroupName = copyResourceGroup;
            model.CopyServerName = copyServerName;
            model.CopyDatabaseName = database.Name;
            model.ResourceGroupName = resourceGroupName;
            model.ServerName = serverName;
            model.DatabaseName = databaseName;
            model.Location = GetServerLocation(resourceGroupName, serverName);
            model.CopyLocation = database.Location;
            model.CreationDate = database.CreationDate.Value;
            model.LicenseType = database.LicenseType;
            model.RequestedBackupStorageRedundancy = database.RequestedBackupStorageRedundancy;
            model.ZoneRedundant = database.ZoneRedundant;

            return model;
        }

        /// <summary>
        /// Creates an Azure SQL Database Secondary using Legacy sdk
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="model">The input parameters for the create operation</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        internal AzureReplicationLinkModel CreateLink(string resourceGroupName, string serverName, AzureReplicationLinkModel model)
        {
            var resp = ReplicationCommunicator.CreateCopy(resourceGroupName, serverName, model.DatabaseName, new DatabaseCreateOrUpdateParameters()
            {
                Location = model.PartnerLocation,
                Properties = new DatabaseCreateOrUpdateProperties()
                {
                    SourceDatabaseId = string.Format(AzureReplicationLinkModel.SourceIdTemplate, _subscription.Id.ToString(),
                        model.ResourceGroupName, model.ServerName, model.DatabaseName),
                    CreateMode = model.AllowConnections.HasFlag(AllowConnections.All) ? Management.Sql.LegacySdk.Models.DatabaseCreateMode.Secondary : Management.Sql.LegacySdk.Models.DatabaseCreateMode.NonReadableSecondary,
                    ElasticPoolName = model.SecondaryElasticPoolName,
                    RequestedServiceObjectiveName = model.SecondaryServiceObjectiveName,
                }
            });

            return GetLink(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.PartnerResourceGroupName, model.PartnerServerName);
        }

        /// <summary>
        /// Creates an Azure SQL Database Secondary using new Autorest sdk
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="model">The input parameters for the create operation</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        internal AzureReplicationLinkModel CreateLinkWithNewSdk(string resourceGroupName, string serverName, AzureReplicationLinkModel model)
        {
            // Construct the ARM resource Id of the pool
            string elasticPoolId = string.IsNullOrWhiteSpace(model.SecondaryElasticPoolName) ? null : AzureSqlDatabaseModel.PoolIdTemplate.FormatInvariant(
                        _subscription.Id,
                        resourceGroupName,
                        serverName,
                        model.SecondaryElasticPoolName);

            var resp = ReplicationCommunicator.CreateCopy(resourceGroupName, serverName, model.PartnerDatabaseName, new Management.Sql.Models.Database
            {
                Location = model.PartnerLocation,
                SourceDatabaseId = string.Format(AzureReplicationLinkModel.SourceIdTemplate, _subscription.Id.ToString(),
                    model.ResourceGroupName, model.ServerName, model.DatabaseName),
                CreateMode = Management.Sql.Models.CreateMode.Secondary,
                ElasticPoolId = elasticPoolId,
                Sku = string.IsNullOrWhiteSpace(model.SkuName) ? null : new Management.Sql.Models.Sku()
                {
                    Name = model.SkuName,
                    Tier = model.Edition,
                    Family = model.Family,
                    Capacity = model.Capacity
                },
                LicenseType = model.LicenseType,
                RequestedBackupStorageRedundancy = model.RequestedBackupStorageRedundancy,
                SecondaryType = model.SecondaryType,
                HighAvailabilityReplicaCount = model.HighAvailabilityReplicaCount,
                ZoneRedundant = model.ZoneRedundant,
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

            var resp = ReplicationCommunicator.GetLink(resourceGroupName, serverName, databaseName, linkId);

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

            var resp = ReplicationCommunicator.ListLinks(resourceGroupName, serverName, databaseName);

            return resp.Select((link) =>
            {
                return CreateReplicationLinkModelFromReplicationLinkResponse(resourceGroupName, serverName, databaseName, partnerResourceGroupName, link);
            }).ToList();
        }

        private void CheckPartnerResourceGroupValid(string partnerResourceGroupName)
        {
            // checking if the resource group is valid as a partner resource group
            ServerCommunicator.ListByResourceGroup(partnerResourceGroupName);
        }

        /// <summary>
        /// Converts the response from the service to a powershell Secondary Link object
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="databaseName">The name of primary database</param>
        /// <param name="partnerResourceGroupName">The name of the Resource Group containing the secondary database</param>
        /// <param name="resp">The replication link response</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        private AzureReplicationLinkModel CreateReplicationLinkModelFromReplicationLinkResponse(string resourceGroupName,
            string serverName, string databaseName, string partnerResourceGroupName, Management.Sql.LegacySdk.Models.ReplicationLink resp)
        {
            // partnerResourceGroupName is required because it is not exposed in any reponse from the service.
            // AllowConnections.ReadOnly is not yet supported
            AllowConnections allowConnections = (resp.Properties.Role.Equals(Management.Sql.LegacySdk.Models.DatabaseCreateMode.Secondary)
                || resp.Properties.PartnerRole.Equals(Management.Sql.LegacySdk.Models.DatabaseCreateMode.Secondary)) ? AllowConnections.All : AllowConnections.No;

            AzureReplicationLinkModel model = new AzureReplicationLinkModel();

            model.LinkId = new Guid(resp.Name);
            model.PartnerResourceGroupName = partnerResourceGroupName;
            model.PartnerServerName = resp.Properties.PartnerServer;
            model.PartnerDatabaseName = resp.Properties.PartnerDatabase;
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
        /// Converts the response from the service to a powershell Secondary Link object
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="databaseName">The name of primary database</param>
        /// <param name="partnerResourceGroupName">The name of the Resource Group containing the secondary database</param>
        /// <param name="resp">The replication link response</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        private AzureReplicationLinkModel CreateReplicationLinkModelFromResponse(string resourceGroupName, string serverName, string databaseName, string partnerResourceGroupName, Management.Sql.Models.ReplicationLink resp)
        {
            // partnerResourceGroupName is required because it is not exposed in any reponse from the service.
            // AllowConnections.ReadOnly is not yet supported
            AllowConnections allowConnections = (resp.Role.ToString().Equals(Management.Sql.Models.CreateMode.Secondary)
                || resp.PartnerRole.ToString().Equals(Management.Sql.Models.CreateMode.Secondary)) ? AllowConnections.All : AllowConnections.No;

            AzureReplicationLinkModel model = new AzureReplicationLinkModel();

            model.LinkId = new Guid(resp.Name);
            model.PartnerResourceGroupName = partnerResourceGroupName;
            model.PartnerServerName = resp.PartnerServer;
            model.PartnerDatabaseName = resp.PartnerDatabase;
            model.ResourceGroupName = resourceGroupName;
            model.ServerName = serverName;
            model.DatabaseName = databaseName;
            model.AllowConnections = allowConnections;
            model.Location = GetServerLocation(resourceGroupName, serverName);
            model.PartnerLocation = resp.PartnerLocation;
            model.PercentComplete = resp.PercentComplete.ToString();
            model.ReplicationState = resp.ReplicationState;
            model.PartnerRole = resp.PartnerRole.ToString();
            model.Role = resp.Role.ToString();
            model.StartTime = resp.StartTime.ToString();

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

            ReplicationCommunicator.RemoveLink(link.ResourceGroupName, link.ServerName, link.DatabaseName, link.LinkId);
        }

        /// <summary>
        /// Finds and removes the Secondary Link by the secondary resource group and Azure SQL Server
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="serverName">The name of the Azure SQL Server containing the primary database</param>
        /// <param name="databaseName">The name of primary database</param>
        /// <param name="partnerResourceGroupName">The name of the Resource Group containing the secondary database</param>
        /// <param name="allowDataLoss">Whether the failover operation will allow data loss</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        internal AzureReplicationLinkModel FailoverLink(string resourceGroupName, string serverName, string databaseName, string partnerResourceGroupName, bool allowDataLoss)
        {
            IList<AzureReplicationLinkModel> links = ListLinks(resourceGroupName, serverName, databaseName, partnerResourceGroupName).ToList();

            // Resource Management executes in context of the Secondary
            AzureReplicationLinkModel link = links.First();

            if (allowDataLoss)
            {
                ReplicationCommunicator.FailoverLinkAllowDataLoss(link.ResourceGroupName, link.ServerName, link.DatabaseName, link.LinkId);
            }
            else
            {
                ReplicationCommunicator.FailoverLink(link.ResourceGroupName, link.ServerName, link.DatabaseName, link.LinkId);
            }

            return GetLink(link.PartnerResourceGroupName, link.PartnerServerName, link.DatabaseName, link.PartnerResourceGroupName, link.PartnerServerName);
        }

        /// <summary>
        /// Map internal BackupStorageRedundancy value (GZRS/GRS/LRS/ZRS) to external (GeoZone/Geo/Local/Zone)
        /// </summary>
        /// <param name="backupStorageRedundancy">Backup storage redundancy</param>
        /// <returns>internal backupStorageRedundancy</returns>
        private static string MapInternalBackupStorageRedundancyToExternal(string backupStorageRedundancy)
        {
            switch (backupStorageRedundancy)
            {
                case "GZRS":
                    return "GeoZone";
                case "GRS":
                    return "Geo";
                case "LRS":
                    return "Local";
                case "ZRS":
                    return "Zone";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Map external BackupStorageRedundancy value (GeoZone/Geo/Local/Zone) to internal (GZRS/GRS/LRS/ZRS)
        /// </summary>
        /// <param name="backupStorageRedundancy">Backup storage redundancy</param>
        /// <returns>internal backupStorageRedundancy</returns>
        private static string MapExternalBackupStorageRedundancyToInternal(string backupStorageRedundancy)
        {
            if (string.IsNullOrWhiteSpace(backupStorageRedundancy))
            {
                return null;
            }

            switch (backupStorageRedundancy.ToLower())
            {
                case "geozone":
                    return "GZRS";
                case "geo":
                    return "GRS";
                case "local":
                    return "LRS";
                case "zone":
                    return "ZRS";
                default:
                    return null;
            }
        }
    }
}
