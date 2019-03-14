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
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
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
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <returns>List of restore points</returns>
        public IList<RestorableDroppedManagedDatabase> ListDeletedDatabaseBackups(string resourceGroupName, string serverName)
        {
            return new List<RestorableDroppedManagedDatabase>(GetCurrentSqlClient().RestorableDroppedManagedDatabases.ListByInstance(resourceGroupName, serverName));
        }


        /// <summary>
        /// Get a restorable deleted database for a given Sql Azure Database
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <returns>List of restore points</returns>
        public RestorableDroppedManagedDatabase GetDeletedDatabaseBackup(string resourceGroupName, string serverName, string databaseName)
        {
            return GetCurrentSqlClient().RestorableDroppedManagedDatabases.Get(resourceGroupName, serverName, databaseName);
        }
    }
}
