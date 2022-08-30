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
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Database.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlDatabaseCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static Management.Sql.LegacySdk.SqlManagementClient LegacySqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Expand string used for getting additional database information
        /// </summary>
        public const string ExpandDatabase = "serviceTierAdvisors";

        /// <summary>
        /// Creates a communicator for Azure Sql Databases
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlDatabaseCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                LegacySqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database
        /// </summary>
        public Management.Sql.Models.Database Get(string resourceGroupName, string serverName, string databaseName)
        {
            return GetCurrentSqlClient().Databases.Get(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Gets the Azure Sql Database expanded additional details.
        /// </summary>
        public Management.Sql.LegacySdk.Models.Database GetExpanded(string resourceGroupName, string serverName, string databaseName)
        {
            return GetLegacySqlClient().Databases.GetExpanded(resourceGroupName, serverName, databaseName, ExpandDatabase).Database;
        }

        /// <summary>
        /// Lists Azure Sql Databases
        /// </summary>
        public IList<Management.Sql.Models.Database> List(string resourceGroupName, string serverName)
        {
            List<Management.Sql.Models.Database> resultsList = new List<Management.Sql.Models.Database>();

            var pagedResponse = GetCurrentSqlClient().Databases.ListByServer(resourceGroupName, serverName);
            resultsList.AddRange(pagedResponse);

            while (!string.IsNullOrEmpty(pagedResponse.NextPageLink))
            {
                pagedResponse = GetCurrentSqlClient().Databases.ListByServerNext(pagedResponse.NextPageLink);
                resultsList.AddRange(pagedResponse);
            }

            return resultsList;
        }

        /// <summary>
        /// Lists Azure Sql Databases expanded with additional details.
        /// </summary>
        public IList<Management.Sql.LegacySdk.Models.Database> ListExpanded(string resourceGroupName, string serverName)
        {
            return GetLegacySqlClient().Databases.ListExpanded(resourceGroupName, serverName, ExpandDatabase).Databases;
        }

        /// <summary>
        /// Creates or updates a database
        /// </summary>
        public Management.Sql.Models.Database CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Management.Sql.Models.Database parameters)
        {
            return GetCurrentSqlClient().Databases.CreateOrUpdate(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Lists database activities
        /// </summary>
        public Microsoft.Rest.Azure.IPage<Management.Sql.Models.DatabaseOperation> ListOperations(string resourceGroupName, string serverName, string databaseName)
        {
            return GetCurrentSqlClient().DatabaseOperations.ListByDatabase(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Cancels database activity
        /// </summary>
        public void CancelOperation(string resourceGroupName, string serverName, string databaseName, Guid operationId)
        {
            GetCurrentSqlClient().DatabaseOperations.Cancel(resourceGroupName, serverName, databaseName, operationId);
        }

        /// <summary>
        /// Deletes a database
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string databaseName)
        {
            GetCurrentSqlClient().Databases.Delete(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Failovers a database
        /// </summary>
        public void Failover(string resourceGroupName, string serverName, string databaseName, string replicaType)
        {
            GetCurrentSqlClient().Databases.Failover(resourceGroupName, serverName, databaseName, replicaType);
        }

        /// <summary>
        /// Renames a database
        /// </summary>
        internal void Rename(string resourceGroupName, string serverName, string databaseName, string newName)
        {
            var client = GetCurrentSqlClient();
            client.Databases.Rename(
                resourceGroupName,
                serverName,
                databaseName,
                new ResourceMoveDefinition
                {
                    Id = AzureSqlDatabaseModel.IdTemplate.FormatInvariant(
                        client.SubscriptionId,
                        resourceGroupName,
                        serverName,
                        newName)
                });
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
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.LegacySdk.SqlManagementClient GetLegacySqlClient()
        {
            // Get the SQL management client for the current subscription
            if (LegacySqlClient == null)
            {
                LegacySqlClient = AzureSession.Instance.ClientFactory.CreateClient<Management.Sql.LegacySdk.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return LegacySqlClient;
        }
    }
}
