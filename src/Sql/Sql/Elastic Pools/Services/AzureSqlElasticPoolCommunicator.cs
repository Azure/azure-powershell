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
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

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
        private static Management.Sql.SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// The old version of Sql client to be used by this end points communicator
        /// </summary>
        public Management.Sql.LegacySdk.SqlManagementClient LegacySqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Elastic Pool
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlElasticPoolCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database Elastic Pool
        /// </summary>
        public Management.Sql.Models.ElasticPool Get(string resourceGroupName, string serverName, string elasticPoolName)
        {
            return GetCurrentSqlClient().ElasticPools.Get(resourceGroupName, serverName, elasticPoolName);
        }

        /// <summary>
        /// Gets the Azure Sql Database
        /// </summary>
        public Management.Sql.Models.Database GetDatabase(string resourceGroupName, string serverName, string databaseName)
        {
            return GetCurrentSqlClient().Databases.Get(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// List Azure Sql databases in the Elastic Pool
        /// </summary>
        public IList<Management.Sql.Models.Database> ListDatabases(string resourceGroupName, string serverName, string elasticPoolName)
        {
            return GetCurrentSqlClient().Databases.ListByElasticPool(resourceGroupName, serverName, elasticPoolName).ToList();
        }

        /// <summary>
        /// Lists Azure Sql Databases Elastic Pool
        /// </summary>
        public IList<Management.Sql.Models.ElasticPool> List(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().ElasticPools.ListByServer(resourceGroupName, serverName).ToList();
        }

        /// <summary>
        /// Creates an Elastic Pool
        /// </summary>
        public Management.Sql.Models.ElasticPool Create(string resourceGroupName, string serverName, string elasticPoolName, Management.Sql.Models.ElasticPool parameters)
        {
            // Occasionally after PUT elastic pool, if we poll for operation results immediately then
            // the polling may fail with 404. This is mitigated in the client by adding a brief wait.
            var client = GetCurrentSqlClient();
            AzureOperationResponse<Management.Sql.Models.ElasticPool> createOrUpdateResponse =
                client.ElasticPools.BeginCreateOrUpdateWithHttpMessagesAsync(
                    resourceGroupName, serverName, elasticPoolName, parameters).Result;

            // Sleep 5 seconds
            TestMockSupport.Delay(5000);

            return client.GetPutOrPatchOperationResultAsync(
                createOrUpdateResponse, null, CancellationToken.None).Result.Body;
        }

        /// <summary>
        /// Updates an Elastic Pool using Patch
        /// </summary>
        public Management.Sql.Models.ElasticPool CreateOrUpdate(string resourceGroupName, string serverName, string elasticPoolName, ElasticPoolUpdate parameters)
        {
            return GetCurrentSqlClient().ElasticPools.Update(resourceGroupName, serverName, elasticPoolName, parameters);
        }

        /// <summary>
        /// Deletes an Elastic Pool
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string elasticPoolName)
        {
            GetCurrentSqlClient().ElasticPools.Delete(resourceGroupName, serverName, elasticPoolName);
        }

        /// <summary>
        /// Gets Elastic Pool Activity
        /// </summary>
        public IList<ElasticPoolActivity> ListActivity(string resourceGroupName, string serverName, string elasticPoolName)
        {
            return GetCurrentSqlClient().ElasticPoolActivities.ListByElasticPool(resourceGroupName, serverName, elasticPoolName).ToList();
        }

        /// <summary>
        /// Gets Elastic Pool Operations
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="elasticPoolName"></param>
        /// <returns></returns>
        public IList<ElasticPoolOperation> ListOperation(string resourceGroupName, string serverName, string elasticPoolName)
        {
            return GetCurrentSqlClient().ElasticPoolOperations.ListByElasticPool(resourceGroupName, serverName, elasticPoolName).ToList();
        }

        /// <summary>
        /// Cancel elastic pool activities
        /// </summary>
        public void CancelOperation(string resourceGroupName, string serverName, string elasticPoolName, Guid operationId)
        {
            GetCurrentSqlClient().ElasticPoolOperations.Cancel(resourceGroupName, serverName, elasticPoolName, operationId);
        }

        /// <summary>
        /// Failovers an Elastic Pool
        /// </summary>
        public void Failover(string resourceGroupName, string serverName, string elasticPoolName)
        {
            GetCurrentSqlClient().ElasticPools.Failover(resourceGroupName, serverName, elasticPoolName);
        }

        /// <summary>
        /// Gets Elastic Pool Database Activity
        /// </summary>
        internal IList<Management.Sql.Models.ElasticPoolDatabaseActivity> ListDatabaseActivity(string resourceGroupName, string serverName, string poolName)
        {
            return GetCurrentSqlClient().ElasticPoolDatabaseActivities.ListByElasticPool(resourceGroupName, serverName, poolName).ToList();
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

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }
    }
}
