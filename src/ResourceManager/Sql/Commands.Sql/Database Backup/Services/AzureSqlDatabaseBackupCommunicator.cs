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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.ServiceManagemenet.Common;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.WindowsAzure.Management.Storage;

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
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static AzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Database backup REST endpoints.
        /// </summary>
        /// <param name="profile">Azure profile</param>
        /// <param name="subscription">Associated subscription</param>
        public AzureSqlDatabaseBackupCommunicator(AzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Lists the restore points for a given Sql Azure Database.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <returns>List of restore points</returns>
        public IList<Management.Sql.Models.RestorePoint> ListRestorePoints(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DatabaseBackup.ListRestorePoints(resourceGroupName, serverName, databaseName).RestorePoints;
        }

        /// <summary>
        /// Lists the geo backups for a given Sql Azure Server
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <returns>List of restore points</returns>
        public IList<Management.Sql.Models.GeoBackup> ListGeoBackups(string resourceGroupName, string serverName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DatabaseBackup.ListGeoBackups(resourceGroupName, serverName).GeoBackups;
        }

        /// <summary>
        /// Lists the restorable deleted databases for a given Sql Azure Server
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <returns>List of restore points</returns>
        public IList<Management.Sql.Models.DeletedDatabaseBackup> ListDeletedDatabaseBackups(string resourceGroupName, string serverName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DatabaseBackup.ListDeletedDatabaseBackups(resourceGroupName, serverName).DeletedDatabaseBackups;
        }

        /// <summary>
        /// Get a geo backup for a given Sql Azure Database
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <returns>List of restore points</returns>
        public Management.Sql.Models.GeoBackup GetGeoBackup(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DatabaseBackup.GetGeoBackup(resourceGroupName, serverName, databaseName).GeoBackup;
        }

        /// <summary>
        /// Get a restorable deleted database for a given Sql Azure Database
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <returns>List of restore points</returns>
        public Management.Sql.Models.DeletedDatabaseBackup GetDeletedDatabaseBackup(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DatabaseBackup.GetDeletedDatabaseBackup(resourceGroupName, serverName, databaseName).DeletedDatabaseBackup;
        }

        /// <summary>
        /// Restore a given Sql Azure Database
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <param name="parameters">Parameters describing the database restore request</param>
        /// <returns>Restored database object</returns>
        public Management.Sql.Models.Database RestoreDatabase(string resourceGroupName, string serverName, string databaseName, string clientRequestId, DatabaseCreateOrUpdateParameters parameters)
        {
            return GetCurrentSqlClient(clientRequestId).Databases.CreateOrUpdate(resourceGroupName, serverName, databaseName, parameters).Database;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient(String clientRequestId)
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            SqlClient.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return SqlClient;
        }
    }
}