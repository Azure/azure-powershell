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
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.LegacySdk;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlManagedDatabaseCommunicator
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
        public AzureSqlManagedDatabaseCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Managed Database
        /// </summary>
        public Management.Sql.Models.ManagedDatabase Get(string resourceGroupName, string managedInstanceName, string databaseName)
        {
            return GetCurrentSqlClient().ManagedDatabases.Get(resourceGroupName, managedInstanceName, databaseName);
        }

        /// <summary>
        /// Lists Azure Sql Managed Databases
        /// </summary>
        public IList<Management.Sql.Models.ManagedDatabase> List(string resourceGroupName, string managedInstanceName)
        {
            return new List<Management.Sql.Models.ManagedDatabase>(GetCurrentSqlClient().ManagedDatabases.ListByInstance(resourceGroupName, managedInstanceName));
        }

        /// <summary>
        /// Creates or updates a managed database
        /// </summary>
        public Management.Sql.Models.ManagedDatabase CreateOrUpdate(string resourceGroupName, string managedInstanceName, string databaseName, Management.Sql.Models.ManagedDatabase parameters)
        {
            return GetCurrentSqlClient().ManagedDatabases.CreateOrUpdate(resourceGroupName, managedInstanceName, databaseName, parameters);
        }

        /// <summary>
        /// Deletes a managed database
        /// </summary>
        public void Remove(string resourceGroupName, string managedInstanceName, string databaseName)
        {
            GetCurrentSqlClient().ManagedDatabases.Delete(resourceGroupName, managedInstanceName, databaseName);
        }

        /// <summary>
        /// Restore a given Sql Azure Managed Database
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure SQL Managed Instance</param>
        /// <param name="managedDatabaseName">The name of the Azure SQL Managed database</param>
        /// <param name="model">Model describing the managed database restore request</param>
        /// <returns>Restored database object</returns>
        public Management.Sql.Models.ManagedDatabase RestoreDatabase(string resourceGroupName, string managedInstanceName, string managedDatabaseName, Management.Sql.Models.ManagedDatabase model)
        {
            return GetCurrentSqlClient().ManagedDatabases.CreateOrUpdate(resourceGroupName, managedInstanceName, managedDatabaseName, model);
        }

        /// <summary>
        /// Restore a given Sql Azure Managed Database
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure SQL Managed Instance</param>
        /// <param name="managedDatabaseName">The name of the Azure SQL Managed database</param>
        /// <param name="resourceId">The resource ID of the Azure SQL Managed database</param>
        /// <param name="model">Model describing the managed database restore request</param>
        /// <returns>Restored database object</returns>
        public Management.Sql.Models.ManagedDatabase RecoverDatabase(string resourceGroupName, string managedInstanceName, string managedDatabaseName, string resourceId, AzureSqlRecoverableManagedDatabaseModel model)
        {
            GenericResource resource = new GenericResource
            {
                Properties = new Dictionary<string, object>
                {
                    { "RecoverableDatabaseId", model.RecoverableDatabaseId },
                    { "createMode", "Recovery" },
                }
            };

            GenericResource database = GetCurrentResourcesClient().Resources.CreateOrUpdate(resourceGroupName, "Microsoft.Sql", string.Format("managedInstances/{0}", managedInstanceName), "databases", managedDatabaseName, "2017-03-01-preview", resource);

            if (database != null)
            {
                return GetCurrentSqlClient().ManagedDatabases.Get(resourceGroupName, managedInstanceName, managedDatabaseName);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Completes log replay restore execution.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure SQL Managed Instance</param>
        /// <param name="databaseName">The name of the Azure SQL Managed database</param>
        /// <param name="lastBackupName"></param>
        public void CompleteLogReplay(string resourceGroupName, string managedInstanceName, string databaseName, string lastBackupName)
        {
            GetCurrentSqlClient().ManagedDatabases.CompleteRestore(
                resourceGroupName,
                managedInstanceName,
                databaseName,
                new CompleteDatabaseRestoreDefinition(lastBackupName));
        }

        /// <summary>
        /// Starts log replay restore execution.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure SQL Managed Instance</param>
        /// <param name="databaseName">The name of the Azure SQL Managed database</param>
        /// <param name="model">Model describing the managed database log replay request</param>
        public Management.Sql.Models.ManagedDatabase StartLogReplay(string resourceGroupName, string managedInstanceName, string databaseName, Management.Sql.Models.ManagedDatabase model)
        {
            return GetCurrentSqlClient().ManagedDatabases.CreateOrUpdate(
                resourceGroupName,
                managedInstanceName,
                databaseName,
                model);
        }


        /// <summary>
        /// Get the status of log replay restore.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure SQL Managed Instance</param>
        /// <param name="databaseName">The name of the Azure SQL Managed database</param>
        /// <returns>The managed database restore details.</returns>
        public ManagedDatabaseRestoreDetailsResult GetLogReplayStatus(string resourceGroupName, string managedInstanceName, string databaseName)
        {
            return GetCurrentSqlClient().ManagedDatabaseRestoreDetails.Get(
                resourceGroupName,
                managedInstanceName,
                databaseName);
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
        /// Lazy creation of a single instance of a resoures client
        /// </summary>
        private ResourceManagementClient GetCurrentResourcesClient()
        {
            ResourceManagementClient resourcesClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return resourcesClient;
        }
    }
}
