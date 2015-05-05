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

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Sql.Common;

namespace Microsoft.Azure.Commands.Sql.ElasticPoolRecommendation.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlElasticPoolRecommendationCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }
        
        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static AzureSubscription Subscription {get ; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureProfile Profile { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Recommended Elastic Pool
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
        public AzureSqlElasticPoolRecommendationCommunicator(AzureProfile profile, AzureSubscription subscription)
        {
            Profile = profile;
            if (subscription != Subscription)
            {
                Subscription = subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Recommended Elastic Pool
        /// </summary>
        public Management.Sql.Models.RecommendedElasticPool Get(string resourceGroupName, string serverName, string recommendedElasticPoolName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).RecommendedElasticPools.Get(resourceGroupName, serverName, recommendedElasticPoolName).RecommendedElasticPool;
        }

        /// <summary>
        /// Gets the Azure Sql Database in the Recommended Elastic Pool
        /// </summary>
        public Management.Sql.Models.Database GetDatabase(string resourceGroupName, string serverName, string recommendedElasticPoolName, string databaseName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).RecommendedElasticPools.GetDatabases(resourceGroupName, serverName, recommendedElasticPoolName, databaseName).Database;
        }
        
        /// <summary>
        /// Lists Azure Sql Recommended Elastic Pool
        /// </summary>
        public IList<Management.Sql.Models.RecommendedElasticPool> List(string resourceGroupName, string serverName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).RecommendedElasticPools.List(resourceGroupName, serverName).RecommendedElasticPools;
        }

        /// <summary>
        /// Gets Recommended Elastic Pool Metrics
        /// </summary>
        public IList<Management.Sql.Models.RecommendedElasticPoolMetric> ListMetrics(string resourceGroupName, string serverName, string poolName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).RecommendedElasticPools.ListMetrics(resourceGroupName, serverName, poolName).RecommendedElasticPoolsMetrics;
        }

        /// <summary>
        /// Gets Recommended Elastic Pool Databases
        /// </summary>
        internal IList<Management.Sql.Models.Database> ListDatabases(string resourceGroupName, string serverName, string poolName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).RecommendedElasticPools.ListDatabases(resourceGroupName, serverName, poolName).Databases;
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
                SqlClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(Profile, Subscription, AzureEnvironment.Endpoint.ResourceManager);
            }
            SqlClient.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return SqlClient;
        }
    }
}