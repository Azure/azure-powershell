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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Sql.ElasticPool.Services;
using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Backup.Services
{
    /// <summary>
    /// Adapter for database backup operations
    /// </summary>
    public class AzureSqlDatabaseBackupAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlDatabaseBackupCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseBackupCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a database backup adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseBackupAdapter(AzureContext context)
        {
            Context = context;
            _subscription = context.Subscription;
            Communicator = new AzureSqlDatabaseBackupCommunicator(Context);
        }

        /// <summary>
        /// Lists the restore points for a given Sql Azure Database.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <returns>List of restore points</returns>
        internal IEnumerable<AzureSqlDatabaseRestorePointModel> ListRestorePoints(string resourceGroup, string serverName, string databaseName)
        {
            var resp = Communicator.ListRestorePoints(resourceGroup, serverName, databaseName, Util.GenerateTracingId());
            return resp.Select((restorePoint) =>
            {
                return new AzureSqlDatabaseRestorePointModel()
                {
                    ResourceGroupName = resourceGroup,
                    ServerName = serverName,
                    DatabaseName = databaseName,
                    Location = restorePoint.Location,
                    RestorePointType = restorePoint.Properties.RestorePointType,
                    RestorePointCreationDate = restorePoint.Properties.RestorePointCreationDate,
                    EarliestRestoreDate = restorePoint.Properties.EarliestRestoreDate
                };
            }).ToList();
        }

        /// <summary>
        /// Lists the recoverable databases (geo backups) for a given Sql Azure Server.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <returns>List of geo backups</returns>
        internal ICollection<AzureSqlDatabaseGeoBackupModel> ListGeoBackups(string resourceGroup, string serverName)
        {
            var resp = Communicator.ListGeoBackups(resourceGroup, serverName, Util.GenerateTracingId());
            return resp.Select((geoBackup) =>
            {
                return new AzureSqlDatabaseGeoBackupModel()
                {
                    ResourceGroupName = resourceGroup,
                    DatabaseName = geoBackup.Name,
                    ServerName = serverName,
                    ResourceId = geoBackup.Id,
                    Edition = geoBackup.Properties.Edition,
                    LastAvailableBackupDate = geoBackup.Properties.LastAvailableBackupDate
                };
            }).ToList();
        }

        /// <summary>
        /// Lists the restorable deleted databases for a given Sql Azure Server.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <returns>List of restorable deleted databases</returns>
        internal ICollection<AzureSqlDeletedDatabaseBackupModel> ListDeletedDatabaseBackups(string resourceGroup, string serverName)
        {
            var resp = Communicator.ListDeletedDatabaseBackups(resourceGroup, serverName, Util.GenerateTracingId());
            return resp.Select((deletedDatabaseBackup) =>
            {
                return new AzureSqlDeletedDatabaseBackupModel()
                {
                    ResourceGroupName = resourceGroup,
                    ServerName = serverName,
                    DatabaseName = deletedDatabaseBackup.Properties.DatabaseName,
                    Edition = deletedDatabaseBackup.Properties.Edition,
                    MaxSizeBytes = deletedDatabaseBackup.Properties.MaxSizeBytes,
                    ServiceLevelObjective = deletedDatabaseBackup.Properties.ServiceLevelObjective,
                    ElasticPoolName = deletedDatabaseBackup.Properties.ElasticPoolName,
                    CreationDate = deletedDatabaseBackup.Properties.CreationDate,
                    DeletionDate = deletedDatabaseBackup.Properties.DeletionDate,
                    RecoveryPeriodStartDate = deletedDatabaseBackup.Properties.EarliestRestoreDate,
                    ResourceId = deletedDatabaseBackup.Id
                };
            }).ToList();
        }

        /// <summary>
        /// Get a recoverable databases (geo backup) for a given Sql Azure Database.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <returns>List of geo backups</returns>
        internal AzureSqlDatabaseGeoBackupModel GetGeoBackup(string resourceGroup, string serverName, string databaseName)
        {
            var geoBackup = Communicator.GetGeoBackup(resourceGroup, serverName, databaseName, Util.GenerateTracingId());
            return new AzureSqlDatabaseGeoBackupModel()
            {
                ResourceGroupName = resourceGroup,
                DatabaseName = geoBackup.Name,
                ServerName = serverName,
                ResourceId = geoBackup.Id,
                Edition = geoBackup.Properties.Edition,
                LastAvailableBackupDate = geoBackup.Properties.LastAvailableBackupDate
            };
        }

        /// <summary>
        /// Get a restorable deleted databases for a given Sql Azure Database.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <returns>List of restorable deleted databases</returns>
        internal AzureSqlDeletedDatabaseBackupModel GetDeletedDatabaseBackup(string resourceGroup, string serverName, string databaseName)
        {
            var deletedDatabaseBackup = Communicator.GetDeletedDatabaseBackup(resourceGroup, serverName, databaseName, Util.GenerateTracingId());
            return new AzureSqlDeletedDatabaseBackupModel()
            {
                ResourceGroupName = resourceGroup,
                ServerName = serverName,
                DatabaseName = deletedDatabaseBackup.Properties.DatabaseName,
                Edition = deletedDatabaseBackup.Properties.Edition,
                MaxSizeBytes = deletedDatabaseBackup.Properties.MaxSizeBytes,
                ServiceLevelObjective = deletedDatabaseBackup.Properties.ServiceLevelObjective,
                ElasticPoolName = deletedDatabaseBackup.Properties.ElasticPoolName,
                CreationDate = deletedDatabaseBackup.Properties.CreationDate,
                DeletionDate = deletedDatabaseBackup.Properties.DeletionDate,
                RecoveryPeriodStartDate = deletedDatabaseBackup.Properties.EarliestRestoreDate,
                ResourceId = deletedDatabaseBackup.Id
            };
        }

        /// <summary>
        /// Restore a given Sql Azure Database
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="restorePointInTime">A point to time to restore to (for PITR and dropped DB restore)</param>
        /// <param name="resourceId">The resource ID of the DB to restore (live, geo backup, or deleted database)</param>
        /// <param name="model">An object modeling the database to create via restore</param>
        /// <param name="parameters">Parameters describing the database restore request</param>
        /// <returns>Restored database object</returns>
        internal AzureSqlDatabaseModel RestoreDatabase(string resourceGroup, DateTime restorePointInTime, string resourceId, AzureSqlDatabaseModel model)
        {
            DatabaseCreateOrUpdateParameters parameters = new DatabaseCreateOrUpdateParameters()
                {
                    Location = model.Location,
                    Properties = new DatabaseCreateOrUpdateProperties()
                    {
                        Edition = model.Edition == DatabaseEdition.None ? null : model.Edition.ToString(),
                        RequestedServiceObjectiveId = model.RequestedServiceObjectiveId,
                        ElasticPoolName = model.ElasticPoolName,
                        RequestedServiceObjectiveName = model.RequestedServiceObjectiveName,
                        SourceDatabaseId = resourceId,
                        RestorePointInTime = restorePointInTime,
                        CreateMode = model.CreateMode
                    }
                };
            var resp = Communicator.RestoreDatabase(resourceGroup, model.ServerName, model.DatabaseName, Util.GenerateTracingId(), parameters);
            return AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroup, model.ServerName, resp);
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
        /// Gets a SQL database by name
        /// </summary>
        /// <param name="resourceGroupName">The resource group the database is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <returns></returns>
        public AzureSqlDatabaseModel GetDatabase(string resourceGroupName, string serverName, string databaseName)
        {
            AzureSqlDatabaseAdapter databaseAdapter = new AzureSqlDatabaseAdapter(Context);
            return databaseAdapter.GetDatabase(resourceGroupName, serverName, databaseName);
        }
    }
}
