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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Azure.Management.Sql.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Services
{
    /// <summary>
    /// Adapter for managed database operations
    /// </summary>
    public class AzureSqlManagedDatabaseBackupAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlManagedDatabaseCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlManagedDatabaseBackupCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private IAzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a managed database adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlManagedDatabaseBackupAdapter(IAzureContext context)
        {
            Context = context;
            _subscription = context.Subscription;
            Communicator = new AzureSqlManagedDatabaseBackupCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Managed Database short term retention policy.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="databaseName">The name of the Azure Sql Managed Database</param>
        /// <returns>The Azure Sql Database object</returns>
        internal AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel ManagedBackupShortTermRetentionPolicies(string resourceGroupName, string managedInstanceName, string databaseName)
        {
            var resp = Communicator.GetShortTermRetentionLiveDatabase(resourceGroupName, managedInstanceName, databaseName);
            return CreateManagedDatabaseBackupShortTermRetentionPolicyModelFromResponse(resourceGroupName, managedInstanceName, databaseName, resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Managed Databases short term retention polices.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="databaseName">The name of the Azure Sql Managed Database</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel> ListManagedBackupShortTermRetentionPolicies(string resourceGroupName, string managedInstanceName, string databaseName)
        {
            var resp = Communicator.ListShortTermRetentionLiveDatabase(resourceGroupName, managedInstanceName, databaseName);

            return resp.Select((db) => CreateManagedDatabaseBackupShortTermRetentionPolicyModelFromResponse(resourceGroupName, managedInstanceName, databaseName, db)).ToList();
        }

        /// <summary>
        /// Gets an Azure Sql Managed Database by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="databaseName">The name of the Azure Sql Managed Database</param>
        /// <param name="deletionDate">Deletion date for deleted databases</param>
        /// <returns>The Azure Sql Database object</returns>
        internal AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel ManagedBackupShortTermRetentionPoliciesDropped(string resourceGroupName, string managedInstanceName, string databaseName, DateTime deletionDate)
        {
            var resp = Communicator.GetShortTermRetentionDroppedDatabase(resourceGroupName, managedInstanceName, databaseName, deletionDate);
            return CreateManagedDatabaseBackupShortTermRetentionPolicyModelFromResponse(resourceGroupName, managedInstanceName, databaseName, resp, deletionDate);
        }

        /// <summary>
        /// Gets a list of Azure Sql Managed Databases.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="databaseName">The name of the Azure Sql Managed Database</param>
        /// <param name="deletionDate">Deletion date for deleted databases</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel> ListManagedBackupShortTermRetentionPoliciesDropped(string resourceGroupName, string managedInstanceName, string databaseName, DateTime deletionDate)
        {
            var resp = Communicator.ListGetShortTermRetentionDroppedDatabase(resourceGroupName, managedInstanceName, databaseName, deletionDate);
            return resp.Select((db) => CreateManagedDatabaseBackupShortTermRetentionPolicyModelFromResponse(resourceGroupName, managedInstanceName, databaseName, db, deletionDate)).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure Sql Managed Database short term retention policy.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="databaseName">The name of database</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database from AutoRest SDK</returns>
        internal AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel UpsertManagedDatabaseRetentionPolicy(string resourceGroup, string managedInstanceName, string databaseName, AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel model)
        {
            ManagedBackupShortTermRetentionPolicy newPolicy = new ManagedBackupShortTermRetentionPolicy(retentionDays: model.RetentionDays);

            var resp = Communicator.CreateOrUpdateShortTermRetentionLiveDatabase(resourceGroup, managedInstanceName, databaseName, newPolicy);

            return CreateManagedDatabaseBackupShortTermRetentionPolicyModelFromResponse(resourceGroup, managedInstanceName, databaseName, resp);
        }

        /// <summary>
        /// Creates or updates an Azure Sql Deleted Managed Database short term retention policy.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="databaseName">The name of database</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database from AutoRest SDK</returns>
        internal AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel UpsertDeletedManagedDatabaseRetentionPolicy(string resourceGroup, string managedInstanceName, string databaseName, AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel model)
        {
            ManagedBackupShortTermRetentionPolicy newPolicy = new ManagedBackupShortTermRetentionPolicy(retentionDays: model.RetentionDays);

            var resp = Communicator.CreateOrUpdateShortTermRetentionDroppedDatabase(resourceGroup, managedInstanceName, databaseName, newPolicy);

            return CreateManagedDatabaseBackupShortTermRetentionPolicyModelFromResponse(resourceGroup, managedInstanceName, databaseName, resp);
        }

        /// <summary>
        /// Converts the response from the service to a powershell managed database object
        /// </summary>
        /// <param name="resourceGroup">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="managedDatabaseName">The name of the Azure Sql Managed Database</param>
        /// <param name="managedBackupShortTermRetentionPolicy"></param>
        /// <param name="deletionDate">Deletion date for deleted databases</param>
        /// <returns>The converted model</returns>
        public static AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel CreateManagedDatabaseBackupShortTermRetentionPolicyModelFromResponse(string resourceGroup, string managedInstanceName, string managedDatabaseName, ManagedBackupShortTermRetentionPolicy managedBackupShortTermRetentionPolicy, DateTime? deletionDate = null)
        {
            return new AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel(resourceGroup, managedInstanceName, managedDatabaseName, managedBackupShortTermRetentionPolicy, deletionDate);
        }

        /// <summary>
        /// Lists the restorable deleted databases for a given Sql Azure Server.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <returns>List of restorable deleted databases</returns>
        internal ICollection<AzureSqlDeletedManagedDatabaseBackupModel> ListDeletedDatabaseBackups(string resourceGroup, string serverName)
        {
            var resp = Communicator.ListDeletedDatabaseBackups(resourceGroup, serverName);
            return resp.Select((deletedDatabaseBackup) =>
            {
                return new AzureSqlDeletedManagedDatabaseBackupModel()
                {
                    ResourceGroupName = resourceGroup,
                    ManagedInstanceName = serverName,
                    Name = deletedDatabaseBackup.DatabaseName,
                    CreationDate = deletedDatabaseBackup.CreationDate.Value,
                    DeletionDate = deletedDatabaseBackup.DeletionDate.Value,
                    Id = deletedDatabaseBackup.Id,
                    EarliestRestorePoint = deletedDatabaseBackup.EarliestRestoreDate,
                };
            }).ToList();
        }

        /// <summary>
        /// Get a restorable deleted databases for a given Sql Azure Database.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <returns>A restorable deleted database</returns>
        internal AzureSqlDeletedManagedDatabaseBackupModel GetDeletedDatabaseBackup(string resourceGroup, string serverName, string databaseName)
        {
            var deletedDatabaseBackup = Communicator.GetDeletedDatabaseBackup(resourceGroup, serverName, databaseName);
            return new AzureSqlDeletedManagedDatabaseBackupModel()
            {
                ResourceGroupName = resourceGroup,
                ManagedInstanceName = serverName,
                Name = deletedDatabaseBackup.DatabaseName,
                CreationDate = deletedDatabaseBackup.CreationDate.Value,
                DeletionDate = deletedDatabaseBackup.DeletionDate.Value,
                Id = deletedDatabaseBackup.Id,
                EarliestRestorePoint = deletedDatabaseBackup.EarliestRestoreDate,
            };
        }

        /// <summary>
        /// Get a backup LongTermRetention policy for a Managed Database
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="instanceName">The name of the Managed Instance</param>
        /// <param name="databaseName">The name of the Managed Database</param>
        /// <returns>A backup LongTermRetention policy</returns>
        internal AzureSqlManagedDatabaseBackupLongTermRetentionPolicyModel GetManagedDatabaseLongTermRetentionPolicy(
            string resourceGroup,
            string instanceName,
            string databaseName)
        {
            ManagedInstanceLongTermRetentionPolicy response = Communicator.GetManagedDatabaseLongTermRetentionPolicy(
                    resourceGroup,
                    instanceName,
                    databaseName);
            return new AzureSqlManagedDatabaseBackupLongTermRetentionPolicyModel()
            {
                ResourceGroupName = resourceGroup,
                ManagedInstanceName = instanceName,
                DatabaseName = databaseName,
                WeeklyRetention = response.WeeklyRetention,
                MonthlyRetention = response.MonthlyRetention,
                YearlyRetention = response.YearlyRetention,
                WeekOfYear = response.WeekOfYear
            };
        }

        /// <summary>
        /// Create or update a backup LongTermRetention policy for a Managed Database
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <param name="model"></param>
        /// <returns>A backup LongTermRetention policy</returns>
        internal AzureSqlManagedDatabaseBackupLongTermRetentionPolicyModel SetManagedDatabaseBackupLongTermRetentionPolicy(
            string resourceGroup,
            string managedInstanceName,
            string databaseName,
            AzureSqlManagedDatabaseBackupLongTermRetentionPolicyModel model)
        {
            ManagedInstanceLongTermRetentionPolicy response = Communicator.SetManagedDatabaseLongTermRetentionPolicy(
                    resourceGroup,
                    managedInstanceName,
                    databaseName,
                    new ManagedInstanceLongTermRetentionPolicy()
                    {
                        WeeklyRetention = model.WeeklyRetention,
                        MonthlyRetention = model.MonthlyRetention,
                        YearlyRetention = model.YearlyRetention,
                        WeekOfYear = model.WeekOfYear
                    });
            return new AzureSqlManagedDatabaseBackupLongTermRetentionPolicyModel()
            {
                ResourceGroupName = resourceGroup,
                ManagedInstanceName = managedInstanceName,
                DatabaseName = databaseName,
                WeeklyRetention = response.WeeklyRetention,
                MonthlyRetention = response.MonthlyRetention,
                YearlyRetention = response.YearlyRetention,
                WeekOfYear = response.WeekOfYear
            };
        }

        private AzureSqlManagedDatabaseLongTermRetentionBackupModel GetBackupModel(ManagedInstanceLongTermRetentionBackup backup, string locationName)
        {
            return new AzureSqlManagedDatabaseLongTermRetentionBackupModel()
            {
                BackupExpirationTime = backup.BackupExpirationTime,
                BackupName = backup.Name,
                BackupTime = backup.BackupTime,
                DatabaseDeletionTime = backup.DatabaseDeletionTime,
                DatabaseName = backup.DatabaseName,
                Location = locationName,
                ResourceId = backup.Id,
                InstanceCreateTime = backup.ManagedInstanceCreateTime,
                ManagedInstanceName = backup.ManagedInstanceName,
                ResourceGroupName = GetResourceGroupNameFromResourceId(backup.Id)
            };
        }

        private string GetResourceGroupNameFromResourceId(string resourceId)
        {
            if (resourceId.Contains("/resourceGroups/"))
            {
                return resourceId.Split('/')[4];
            }
            return null;
        }

        /// <summary>
        /// Gets the Long Term Retention backups.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <param name="managedInstanceName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="backupName">The backup name.</param>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="onlyLatestPerDatabase">Whether or not to only get the latest backup per database.</param>
        /// <param name="databaseState">The state of databases to get backups for: All, Live, Deleted.</param>
        internal IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> GetManagedDatabaseLongTermRetentionBackups(
            string locationName,
            string managedInstanceName,
            string databaseName,
            string backupName,
            string resourceGroupName,
            bool? onlyLatestPerDatabase,
            string databaseState)
        {
            if (!string.IsNullOrWhiteSpace(backupName) && !WildcardPattern.ContainsWildcardCharacters(backupName))
            {
                return new List<AzureSqlManagedDatabaseLongTermRetentionBackupModel>()
                {
                    GetBackupModel(Communicator.GetManagedDatabaseLongTermRetentionBackup(locationName, managedInstanceName, databaseName, backupName, resourceGroupName), locationName)
                };
            }
            else
            {
                return Communicator.GetManagedDatabaseLongTermRetentionBackups(locationName, managedInstanceName, databaseName, resourceGroupName, onlyLatestPerDatabase, databaseState)
                    .Select(b => GetBackupModel(b, locationName));
            }
        }

        /// <summary>
        /// Removes a Long Term Retention backup.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="backupName">The backup name.</param>
        /// <param name="resourceGroupName">The name of the resource group</param>
        internal void RemoveManagedDatabaseLongTermRetentionBackup(
            string locationName,
            string serverName,
            string databaseName,
            string backupName,
            string resourceGroupName)
        {
            Communicator.RemoveManagedDatabaseLongTermRetentionBackup(locationName, serverName, databaseName, backupName, resourceGroupName);
        }
    }
}
