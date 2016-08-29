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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.WindowsAzure.Management.Storage;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ElasticPool.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlElasticPoolCommunicator
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
        /// Creates a communicator for Azure Sql Elastic Pool
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
        public AzureSqlElasticPoolCommunicator(AzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database Elastic Pool
        /// </summary>
        public Management.Sql.Models.ElasticPool Get(string resourceGroupName, string serverName, string elasticPoolName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).ElasticPools.Get(resourceGroupName, serverName, elasticPoolName).ElasticPool;
        }

        /// <summary>
        /// Gets the Azure Sql Database in the Elastic Pool
        /// </summary>
        public Management.Sql.Models.Database GetDatabase(string resourceGroupName, string serverName, string elasticPoolName, string databaseName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).ElasticPools.GetDatabases(resourceGroupName, serverName, elasticPoolName, databaseName).Database;
        }

        /// <summary>
        /// Lists the Azure Sql Database in the Elastic Pool
        /// </summary>
        public IList<Management.Sql.Models.Database> ListDatabases(string resourceGroupName, string serverName, string elasticPoolName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).ElasticPools.ListDatabases(resourceGroupName, serverName, elasticPoolName).Databases;
        }

        /// <summary>
        /// Lists Azure Sql Databases Elastic Pool
        /// </summary>
        public IList<Management.Sql.Models.ElasticPool> List(string resourceGroupName, string serverName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).ElasticPools.List(resourceGroupName, serverName).ElasticPools;
        }

        /// <summary>
        /// Creates or updates an Elastic Pool
        /// </summary>
        public Management.Sql.Models.ElasticPool CreateOrUpdate(string resourceGroupName, string serverName, string elasticPoolName, string clientRequestId, ElasticPoolCreateOrUpdateParameters parameters)
        {
            var resp = GetCurrentSqlClient(clientRequestId).ElasticPools.CreateOrUpdate(resourceGroupName, serverName, elasticPoolName, parameters);
            return resp.ElasticPool;
        }

        /// <summary>
        /// Deletes an Elastic Pool
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string elasticPoolName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).ElasticPools.Delete(resourceGroupName, serverName, elasticPoolName);
        }

        /// <summary>
        /// Gets Elastic Pool Activity
        /// </summary>
        public IList<Management.Sql.Models.ElasticPoolActivity> ListActivity(string resourceGroupName, string serverName, string elasticPoolName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).ElasticPools.ListActivity(resourceGroupName, serverName, elasticPoolName).ElasticPoolActivities;
        }

        /// <summary>
        /// Gets Elastic Pool Database Activity
        /// </summary>
        internal IList<Management.Sql.Models.ElasticPoolDatabaseActivity> ListDatabaseActivity(string resourceGroupName, string serverName, string poolName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).ElasticPools.ListDatabaseActivity(resourceGroupName, serverName, poolName).ElasticPoolDatabaseActivities;
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