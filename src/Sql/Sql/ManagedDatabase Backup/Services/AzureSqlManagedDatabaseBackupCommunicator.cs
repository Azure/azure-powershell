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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlManagedDatabaseBackupCommunicator
    {
        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Managed Databases
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlManagedDatabaseBackupCommunicator(IAzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Managed Backup Short Term Retention Policy
        /// </summary>
        public Management.Sql.Models.ManagedBackupShortTermRetentionPolicy GetShortTermRetentionLiveDatabase(string resourceGroupName, string managedInstanceName, string databaseName)
        {
            return GetCurrentSqlClient().ManagedBackupShortTermRetentionPolicies.Get(resourceGroupName, managedInstanceName, databaseName);
        }

        /// <summary>
        /// Lists Azure Sql Managed Backup Short Term Retention Policies
        /// </summary>
        public IList<Management.Sql.Models.ManagedBackupShortTermRetentionPolicy> ListShortTermRetentionLiveDatabase(string resourceGroupName, string managedInstanceName, string databaseName)
        {
            return new List<Management.Sql.Models.ManagedBackupShortTermRetentionPolicy>(GetCurrentSqlClient().ManagedBackupShortTermRetentionPolicies.ListByDatabase(resourceGroupName, managedInstanceName, databaseName));
        }

        /// <summary>
        /// Gets the Azure Sql Managed Backup Short Term Retention Policy
        /// </summary>
        public Management.Sql.Models.ManagedBackupShortTermRetentionPolicy GetShortTermRetentionDroppedDatabase(string resourceGroupName, string managedInstanceName, string databaseName, DateTime deletionDate)
        {
            return GetCurrentSqlClient().ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies.Get(resourceGroupName, managedInstanceName, databaseName + "," + deletionDate.ToFileTimeUtc());
        }

        /// <summary>
        /// Lists Azure Sql Managed Backup Short Term Retention Policies
        /// </summary>
        public IList<Management.Sql.Models.ManagedBackupShortTermRetentionPolicy> ListGetShortTermRetentionDroppedDatabase(string resourceGroupName, string managedInstanceName, string databaseName, DateTime deletionDate)
        {
            return new List<Management.Sql.Models.ManagedBackupShortTermRetentionPolicy>(GetCurrentSqlClient().ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies.ListByRestorableDroppedDatabase(resourceGroupName, managedInstanceName, databaseName + "," + deletionDate.ToFileTimeUtc()));
        }

        /// <summary>
        /// Creates or updates an Azure Sql Managed Backup Short Term Retention Policy for live databases
        /// </summary>
        public Management.Sql.Models.ManagedBackupShortTermRetentionPolicy CreateOrUpdateShortTermRetentionLiveDatabase(string resourceGroupName, string managedInstanceName, string databaseName, Management.Sql.Models.ManagedBackupShortTermRetentionPolicy parameters)
        {
            return GetCurrentSqlClient().ManagedBackupShortTermRetentionPolicies.CreateOrUpdate(resourceGroupName, managedInstanceName, databaseName, parameters);
        }


        /// <summary>
        /// Creates or updates an Azure Sql Managed Backup Short Term Retention Policy for deleted databases
        /// </summary>
        public Management.Sql.Models.ManagedBackupShortTermRetentionPolicy CreateOrUpdateShortTermRetentionDroppedDatabase(string resourceGroupName, string managedInstanceName, string databaseName, Management.Sql.Models.ManagedBackupShortTermRetentionPolicy parameters)
        {
            return GetCurrentSqlClient().ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies.CreateOrUpdate(resourceGroupName, managedInstanceName, databaseName, parameters);
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
            var sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return sqlClient;
        }

        /// <summary>
        /// Lists the restorable deleted databases for a given Sql Azure Server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <returns>List of restore points</returns>
        public IList<RestorableDroppedManagedDatabase> ListDeletedDatabaseBackups(string resourceGroupName, string serverName)
        {
            return new List<RestorableDroppedManagedDatabase>(GetCurrentSqlClient().RestorableDroppedManagedDatabases.ListByInstance(resourceGroupName, serverName));
        }


        /// <summary>
        /// Get a restorable deleted database for a given Sql Azure Database
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="instanceName">The name of the Managed Instance</param>
        /// <param name="databaseName">The name of the Managed database</param>
        /// <returns>List of restore points</returns>
        public RestorableDroppedManagedDatabase GetDeletedDatabaseBackup(string resourceGroupName, string instanceName, string databaseName)
        {
            return GetCurrentSqlClient().RestorableDroppedManagedDatabases.Get(resourceGroupName, instanceName, databaseName);
        }

        /// <summary>
        /// Get a backup LongTermRetention policy for a Azure SQL Database
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="instanceName">The name of the Managed Instance</param>
        /// <param name="databaseName">The name of the Managed Database</param>
        /// <returns>A backup LongTermRetention policy</returns>
        public ManagedInstanceLongTermRetentionPolicy GetManagedDatabaseLongTermRetentionPolicy(
            string resourceGroupName,
            string instanceName,
            string databaseName)
        {
            return GetCurrentSqlClient().ManagedInstanceLongTermRetentionPolicies.Get(
                resourceGroupName,
                instanceName,
                databaseName);
        }

        /// <summary>
        /// Sets a database's Long Term Retention policy.
        /// </summary>
        /// <param name="resourceGroup">The resource group name.</param>
        /// <param name="instanceName">The instance name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="policy">The Long Term Retention policy to apply.</param>
        public Management.Sql.Models.ManagedInstanceLongTermRetentionPolicy SetManagedDatabaseLongTermRetentionPolicy(
            string resourceGroup,
            string instanceName,
            string databaseName,
            ManagedInstanceLongTermRetentionPolicy policy)
        {
            return GetCurrentSqlClient().ManagedInstanceLongTermRetentionPolicies.CreateOrUpdate(resourceGroup, instanceName, databaseName, policy);
        }


        /// <summary>
        /// Gets the Long Term Retention backup.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <param name="instanceName">The instance name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="backupName">The backup name.</param>
        /// <param name="resourceGroupName">The resource group name</param>
        public ManagedInstanceLongTermRetentionBackup GetManagedDatabaseLongTermRetentionBackup(
            string locationName,
            string instanceName,
            string databaseName,
            string backupName,
            string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                return GetCurrentSqlClient().LongTermRetentionManagedInstanceBackups.Get(locationName, instanceName, databaseName, backupName);
            }
            else
            {
                return GetCurrentSqlClient().LongTermRetentionManagedInstanceBackups.GetByResourceGroup(resourceGroupName, locationName, instanceName, databaseName, backupName);
            }
        }

        /// <summary>
        /// Gets the Long Term Retention backups.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <param name="instanceName">The instance name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="onlyLatestPerDatabase">Whether or not to only get the latest backup per database.</param>
        /// <param name="databaseState">The state of databases to get backups for: All, Live, Deleted.</param>
        public Rest.Azure.IPage<ManagedInstanceLongTermRetentionBackup> GetManagedDatabaseLongTermRetentionBackups(
            string locationName,
            string instanceName,
            string databaseName,
            string resourceGroupName,
            bool? onlyLatestPerDatabase,
            string databaseState)
        {
            if (!string.IsNullOrWhiteSpace(databaseName))
            {
                if (string.IsNullOrWhiteSpace(resourceGroupName))
                {
                    return GetCurrentSqlClient().LongTermRetentionManagedInstanceBackups.ListByDatabase(locationName, instanceName, databaseName, onlyLatestPerDatabase, databaseState);
                }
                else
                {
                    return GetCurrentSqlClient().LongTermRetentionManagedInstanceBackups.ListByResourceGroupDatabase(resourceGroupName, locationName, instanceName, databaseName, onlyLatestPerDatabase, databaseState);
                }
            }
            else if (!string.IsNullOrWhiteSpace(instanceName))
            {
                if (string.IsNullOrWhiteSpace(resourceGroupName))
                {
                    return GetCurrentSqlClient().LongTermRetentionManagedInstanceBackups.ListByInstance(locationName, instanceName, onlyLatestPerDatabase, databaseState);
                }
                else
                {
                    return GetCurrentSqlClient().LongTermRetentionManagedInstanceBackups.ListByResourceGroupInstance(resourceGroupName, locationName, instanceName, onlyLatestPerDatabase, databaseState);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(resourceGroupName))
                {
                    return GetCurrentSqlClient().LongTermRetentionManagedInstanceBackups.ListByLocation(locationName, onlyLatestPerDatabase, databaseState);
                }
                else
                {
                    return GetCurrentSqlClient().LongTermRetentionManagedInstanceBackups.ListByResourceGroupLocation(resourceGroupName, locationName, onlyLatestPerDatabase, databaseState);
                }
            }
        }

        /// <summary>
        /// Removes a Long Term Retention backup.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <param name="instanceName">The instance name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="backupName">The backup name.</param>
        /// <param name="resourceGroupName">The resource group name</param>
        public void RemoveManagedDatabaseLongTermRetentionBackup(
            string locationName,
            string instanceName,
            string databaseName,
            string backupName,
            string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                GetCurrentSqlClient().LongTermRetentionManagedInstanceBackups.Delete(locationName, instanceName, databaseName, backupName);
            }
            else
            {
                GetCurrentSqlClient().LongTermRetentionManagedInstanceBackups.DeleteByResourceGroup(resourceGroupName, locationName, instanceName, databaseName, backupName);
            }
        }
    }
}
