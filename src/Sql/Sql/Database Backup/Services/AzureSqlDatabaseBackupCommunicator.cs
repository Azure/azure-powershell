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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Backup.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the database backup REST endpoints.
    /// </summary>
    public class AzureSqlDatabaseBackupCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static Management.Sql.LegacySdk.SqlManagementClient LegacyClient { get; set; }

        /// <summary>
        /// The resources management client used by this communicator
        /// </summary>
        private static ResourceManagementClient ResourcesClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Database backup REST endpoints.
        /// </summary>
        /// <param name="context">Azure context</param>
        public AzureSqlDatabaseBackupCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                LegacyClient = null;
            }
        }

        /// <summary>
        /// Lists the restore points for a given Sql Azure Database.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <returns>List of restore points</returns>
        public IEnumerable<Management.Sql.Models.RestorePoint> ListRestorePoints(string resourceGroupName, string serverName, string databaseName)
        {
            return GetCurrentSqlClient().RestorePoints.ListByDatabaseWithHttpMessagesAsync(resourceGroupName, serverName, databaseName).Result.Body;
        }

        /// <summary>
        /// Creates a new restore point for a given Sql Azure Database.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <param name="restoreDefinition">The definition for creating the restore point of this database</param>
        /// <returns>A restore point</returns>
        public Management.Sql.Models.RestorePoint NewRestorePoint(string resourceGroupName, string serverName, string databaseName, Management.Sql.Models.CreateDatabaseRestorePointDefinition restoreDefinition)
        {
            return GetCurrentSqlClient().RestorePoints.CreateWithHttpMessagesAsync(resourceGroupName, serverName, databaseName, restoreDefinition).Result.Body;
        }

        /// <summary>
        /// Removes a given restore point for a given Sql Azure Database.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <param name="restorePointCreationDate">The name of the restore point</param>
        /// <returns>void</returns>
        public void RemoveRestorePoint(string resourceGroupName, string serverName, string databaseName, string restorePointCreationDate)
        {
            GetCurrentSqlClient().RestorePoints.DeleteWithHttpMessagesAsync(resourceGroupName, serverName, databaseName, restorePointCreationDate);
        }

        /// <summary>
        /// Lists the geo backups for a given Sql Azure Server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <returns>List of restore points</returns>
        public IList<Management.Sql.LegacySdk.Models.GeoBackup> ListGeoBackups(string resourceGroupName, string serverName)
        {
            return GetLegacySqlClient().DatabaseBackup.ListGeoBackups(resourceGroupName, serverName).GeoBackups;
        }

        /// <summary>
        /// Lists the restorable deleted databases for a given Sql Azure Server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <returns>List of restore points</returns>
        public IList<Management.Sql.LegacySdk.Models.DeletedDatabaseBackup> ListDeletedDatabaseBackups(string resourceGroupName, string serverName)
        {
            return GetLegacySqlClient().DatabaseBackup.ListDeletedDatabaseBackups(resourceGroupName, serverName).DeletedDatabaseBackups;
        }

        /// <summary>
        /// Get a geo backup for a given Sql Azure Database
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <returns>List of restore points</returns>
        public Management.Sql.LegacySdk.Models.GeoBackup GetGeoBackup(string resourceGroupName, string serverName, string databaseName)
        {
            return GetLegacySqlClient().DatabaseBackup.GetGeoBackup(resourceGroupName, serverName, databaseName).GeoBackup;
        }

        /// <summary>
        /// Get a restorable deleted database for a given Sql Azure Database
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <returns>List of restore points</returns>
        public Management.Sql.LegacySdk.Models.DeletedDatabaseBackup GetDeletedDatabaseBackup(string resourceGroupName, string serverName, string databaseName)
        {
            return GetLegacySqlClient().DatabaseBackup.GetDeletedDatabaseBackup(resourceGroupName, serverName, databaseName).DeletedDatabaseBackup;
        }

        /// <summary>
        /// Get a backup LongTermRetention vault for a given Azure SQL Server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="baVaultName">The name of the Azure SQL Database backup LongTermRetention vault.</param>
        /// <returns>A backup vault</returns>
        public Management.Sql.LegacySdk.Models.BackupLongTermRetentionVault GetBackupLongTermRetentionVault(
            string resourceGroupName,
            string serverName,
            string baVaultName)
        {
            return GetLegacySqlClient().DatabaseBackup.GetBackupLongTermRetentionVault(
                resourceGroupName,
                serverName,
                baVaultName).BackupLongTermRetentionVault;
        }

        /// <summary>
        /// Get a backup LongTermRetention policy for a Azure SQL Database
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <param name="baPolicyName">The name of the Azure SQL Database backup LongTermRetention policy.</param>
        /// <returns>A backup LongTermRetention policy</returns>
        public Management.Sql.LegacySdk.Models.DatabaseBackupLongTermRetentionPolicy GetDatabaseBackupLongTermRetentionPolicy(
            string resourceGroupName,
            string serverName,
            string databaseName,
            string baPolicyName)
        {
            return GetLegacySqlClient().DatabaseBackup.GetDatabaseBackupLongTermRetentionPolicy(
                resourceGroupName,
                serverName,
                databaseName,
                baPolicyName).DatabaseBackupLongTermRetentionPolicy;
        }

        /// <summary>
        /// Creates or updates a backup LongTermRetention vault
        /// </summary>
        public Management.Sql.LegacySdk.Models.BackupLongTermRetentionVault SetBackupLongTermRetentionVault(
            string resourceGroupName,
            string serverName,
            string baVaultName,
            BackupLongTermRetentionVaultCreateOrUpdateParameters parameters)
        {
            return GetLegacySqlClient().DatabaseBackup.CreateOrUpdateBackupLongTermRetentionVault(
                resourceGroupName,
                serverName,
                baVaultName,
                parameters).BackupLongTermRetentionVault;
        }

        /// <summary>
        /// Creates or updates a backup LongTermRetention policy
        /// </summary>
        public Management.Sql.LegacySdk.Models.DatabaseBackupLongTermRetentionPolicy SetDatabaseBackupLongTermRetentionPolicy(
            string resourceGroupName,
            string serverName,
            string databaseName,
            string baPolicyName,
            DatabaseBackupLongTermRetentionPolicyCreateOrUpdateParameters parameters)
        {
            return GetLegacySqlClient().DatabaseBackup.CreateOrUpdateDatabaseBackupLongTermRetentionPolicy(
                resourceGroupName,
                serverName,
                databaseName,
                baPolicyName,
                parameters).DatabaseBackupLongTermRetentionPolicy;
        }

        /// <summary>
        /// Gets a database's Long Term Retention policy.
        /// </summary>
        /// <param name="resourceGroup">The resource group name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        public Management.Sql.Models.LongTermRetentionPolicy GetDatabaseLongTermRetentionPolicy(
            string resourceGroup,
            string serverName,
            string databaseName)
        {
            return GetCurrentSqlClient().LongTermRetentionPolicies.Get(resourceGroup, serverName, databaseName);
        }

        /// <summary>
        /// Sets a database's Long Term Retention policy.
        /// </summary>
        /// <param name="resourceGroup">The resource group name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="policy">The Long Term Retention policy to apply.</param>
        public Management.Sql.Models.LongTermRetentionPolicy SetDatabaseLongTermRetentionPolicy(
            string resourceGroup,
            string serverName,
            string databaseName,
            Management.Sql.Models.LongTermRetentionPolicy policy)
        {
            return GetCurrentSqlClient().LongTermRetentionPolicies.CreateOrUpdate(resourceGroup, serverName, databaseName, policy);
        }

        /// <summary>
        /// Gets the Long Term Retention backup.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="backupName">The backup name.</param>
        /// <param name="resourceGroupName">The resource group name</param>
        public Management.Sql.Models.LongTermRetentionBackup GetDatabaseLongTermRetentionBackup(
            string locationName,
            string serverName,
            string databaseName,
            string backupName,
            string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                return GetCurrentSqlClient().LongTermRetentionBackups.Get(locationName, serverName, databaseName, backupName);
            }
            else
            {
                return GetCurrentSqlClient().LongTermRetentionBackups.GetByResourceGroup(resourceGroupName, locationName, serverName, databaseName, backupName);
            }
        }

        /// <summary>
        /// Gets the Long Term Retention backups.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="onlyLatestPerDatabase">Whether or not to only get the latest backup per database.</param>
        /// <param name="databaseState">The state of databases to get backups for: All, Live, Deleted.</param>
        public Rest.Azure.IPage<Management.Sql.Models.LongTermRetentionBackup> GetDatabaseLongTermRetentionBackups(
            string locationName,
            string serverName,
            string databaseName,
            string resourceGroupName,
            bool? onlyLatestPerDatabase,
            string databaseState)
        {
            if (!string.IsNullOrWhiteSpace(databaseName))
            {
                if(string.IsNullOrWhiteSpace(resourceGroupName))
                {
                    return GetCurrentSqlClient().LongTermRetentionBackups.ListByDatabase(locationName, serverName, databaseName, onlyLatestPerDatabase, databaseState);
                }
                else
                {
                    return GetCurrentSqlClient().LongTermRetentionBackups.ListByResourceGroupDatabase(resourceGroupName, locationName, serverName, databaseName, onlyLatestPerDatabase, databaseState);
                }
            }
            else if (!string.IsNullOrWhiteSpace(serverName))
            {
                if (string.IsNullOrWhiteSpace(resourceGroupName))
                {
                    return GetCurrentSqlClient().LongTermRetentionBackups.ListByServer(locationName, serverName, onlyLatestPerDatabase, databaseState);
                }
                else
                {
                    return GetCurrentSqlClient().LongTermRetentionBackups.ListByResourceGroupServer(resourceGroupName, locationName, serverName, onlyLatestPerDatabase, databaseState);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(resourceGroupName))
                {
                    return GetCurrentSqlClient().LongTermRetentionBackups.ListByLocation(locationName, onlyLatestPerDatabase, databaseState);
                }
                else
                {
                    return GetCurrentSqlClient().LongTermRetentionBackups.ListByResourceGroupLocation(resourceGroupName, locationName, onlyLatestPerDatabase, databaseState);
                }
            }
        }

        /// <summary>
        /// Copies a Long Term Retention backup to another server/database.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="backupName">The backup name.</param>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="parameters">The parameters needed for long term retention copy request</param>
        public Management.Sql.Models.LongTermRetentionBackupOperationResult CopyDatabaseLongTermRetentionBackup(
            string locationName,
            string serverName,
            string databaseName,
            string backupName,
            string resourceGroupName,
            Management.Sql.Models.CopyLongTermRetentionBackupParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                return GetCurrentSqlClient().LongTermRetentionBackups.Copy(locationName, serverName, databaseName, backupName, parameters);
            }
            else
            {
                return GetCurrentSqlClient().LongTermRetentionBackups.CopyByResourceGroup(resourceGroupName, locationName, serverName, databaseName, backupName, parameters);
            }
        }

        /// <summary>
        /// Updates a Long Term Retention backup.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="backupName">The backup name.</param>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="parameters">The requested backup resource state</param>
        public Management.Sql.Models.LongTermRetentionBackupOperationResult UpdateDatabaseLongTermRetentionBackup(
            string locationName,
            string serverName,
            string databaseName,
            string backupName,
            string resourceGroupName,
            Management.Sql.Models.UpdateLongTermRetentionBackupParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                return GetCurrentSqlClient().LongTermRetentionBackups.Update(locationName, serverName, databaseName, backupName, parameters);
            }
            else
            {
                return GetCurrentSqlClient().LongTermRetentionBackups.UpdateByResourceGroup(resourceGroupName, locationName, serverName, databaseName, backupName, parameters);
            }
        }


        /// <summary>
        /// Removes a Long Term Retention backup.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="backupName">The backup name.</param>
        /// <param name="resourceGroupName">The resource group name</param>
        public void RemoveDatabaseLongTermRetentionBackup(
            string locationName,
            string serverName,
            string databaseName,
            string backupName,
            string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                GetCurrentSqlClient().LongTermRetentionBackups.Delete(locationName, serverName, databaseName, backupName);
            }
            else
            {
                GetCurrentSqlClient().LongTermRetentionBackups.DeleteByResourceGroup(resourceGroupName, locationName, serverName, databaseName, backupName);
            }
        }

        /// <summary>
        /// Get a geo backup policy for a Azure SQL Database
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <param name="policyName">The name of the geo backup policy</param>
        /// <returns>A geo backup policy</returns>
        public Management.Sql.LegacySdk.Models.GeoBackupPolicy GetDatabaseGeoBackupPolicy(
            string resourceGroupName,
            string serverName,
            string databaseName,
            string policyName)
        {
            return GetLegacySqlClient().DatabaseBackup.GetGeoBackupPolicy(
                resourceGroupName,
                serverName,
                databaseName,
                policyName).GeoBackupPolicy;
        }

        /// <summary>
        /// Creates or updates a geo backup policy
        /// </summary>
        public Management.Sql.LegacySdk.Models.GeoBackupPolicy SetDatabaseGeoBackupPolicy(
            string resourceGroupName,
            string serverName,
            string databaseName,
            string policyName,
            GeoBackupPolicyCreateOrUpdateParameters parameters)
        {
            return GetLegacySqlClient().DatabaseBackup.CreateOrUpdateGeoBackupPolicy(
                resourceGroupName,
                serverName,
                databaseName,
                policyName,
                parameters).GeoBackupPolicy;
        }

        /// <summary>
        /// Restore a given Sql Azure Database
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <param name="parameters">Parameters describing the database restore request</param>
        /// <returns>Restored database object</returns>
        public Management.Sql.LegacySdk.Models.Database LegacyRestoreDatabase(string resourceGroupName, string serverName, string databaseName, DatabaseCreateOrUpdateParameters parameters)
        {
            return GetLegacySqlClient().Databases.CreateOrUpdate(resourceGroupName, serverName, databaseName, parameters).Database;
        }

        /// <summary>
        /// Restore a given Sql Azure Database
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <param name="model">Sql Database Model with required parameters</param>
        /// <param name="customHeaders">Custom headers</param>
        /// <returns>Restored database object</returns>
        public Management.Sql.Models.Database RestoreDatabase(string resourceGroupName, string serverName, string databaseName, Management.Sql.Models.Database model, Dictionary<string, List<string>> customHeaders = null)
        {
            if (customHeaders == null)
            {
                // Execute the create call without the custom headers. 
                return GetCurrentSqlClient().Databases.CreateOrUpdate(resourceGroupName, serverName, databaseName, model);
            }
            else
            {
                // Execute the create call and pass the custom headers. 
                using (var _result = GetCurrentSqlClient().Databases.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, serverName, databaseName, model, customHeaders).ConfigureAwait(false).GetAwaiter().GetResult())
                {
                    return _result.Body;
                }
            }
        }

        /// <summary>
        /// Get the ShortTermRetention policy for a Azure SQL Database
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <returns>A BackupShortTermRetention policy</returns>
        public Management.Sql.Models.BackupShortTermRetentionPolicy GetDatabaseBackupShortTermRetentionPolicy(
            string resourceGroupName,
            string serverName,
            string databaseName)
        {
            return GetCurrentSqlClient().BackupShortTermRetentionPolicies.Get(
                resourceGroupName,
                serverName,
                databaseName);
        }

        /// <summary>
        /// Sets a database's backup Short Term Retention policy.
        /// </summary>
        /// <param name="resourceGroup">The resource group name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="policy">The Short Term Retention policy to apply.</param>
        /// <returns>A backup ShortTermRetention policy</returns>
        public Management.Sql.Models.BackupShortTermRetentionPolicy SetDatabaseBackupShortTermRetentionPolicy(
            string resourceGroup,
            string serverName,
            string databaseName,
            Management.Sql.Models.BackupShortTermRetentionPolicy policy)
        {
            return GetCurrentSqlClient().BackupShortTermRetentionPolicies.CreateOrUpdate(resourceGroup, serverName, databaseName, policy);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.LegacySdk.SqlManagementClient GetLegacySqlClient()
        {
            // Get the SQL management client for the current subscription
            if (LegacyClient == null)
            {
                LegacyClient = AzureSession.Instance.ClientFactory.CreateClient<Management.Sql.LegacySdk.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return LegacyClient;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            // Note: client is not cached in static field because that causes ObjectDisposedException in functional tests.
            return AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// Lazy creation of a single instance of a resoures client
        /// </summary>
        private ResourceManagementClient GetCurrentResourcesClient()
        {
            if (ResourcesClient == null)
            {
                ResourcesClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return ResourcesClient;
        }
    }
}
