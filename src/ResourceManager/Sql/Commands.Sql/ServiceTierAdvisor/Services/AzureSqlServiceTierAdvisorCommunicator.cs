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
using Microsoft.Azure.Management.Sql;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ServiceTierAdvisor.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlServiceTierAdvisorCommunicator
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
        /// Creates a communicator for Azure Sql Service Tier Advisor
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
        public AzureSqlServiceTierAdvisorCommunicator(AzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Get database with expanded properties
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of Azure Sql server</param>
        /// <param name="databaseName">Database name</param>
        /// <param name="expand">Expand string</param>
        /// <param name="clientRequestId">Request identifier</param>
        /// <returns></returns>
        public Management.Sql.Models.Database GetDatabaseExpanded(string resourceGroupName, string serverName, string databaseName, string expand, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).Databases.GetExpanded(resourceGroupName, serverName, databaseName, expand).Database;
        }

        /// <summary>
        /// List databases expanded
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of Azure Sql server</param>
        /// <param name="expand">Expand string</param>
        /// <param name="clientRequestId">Request identifier</param>
        /// <returns>List of databases</returns>
        public IList<Management.Sql.Models.Database> ListDatabasesExpanded(string resourceGroupName, string serverName, string expand, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).Databases.ListExpanded(resourceGroupName, serverName, expand).Databases;
        }

        /// <summary>
        /// Get recommended elastic pools
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of Azure Sql server</param>
        /// <param name="clientRequestId">Request identifier</param>
        /// <returns>List of recommended elastic pools</returns>
        public IList<Management.Sql.Models.RecommendedElasticPool> GetRecommendedElasticPoolsExpanded(string resourceGroupName, string serverName, string expand, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).RecommendedElasticPools.ListExpanded(resourceGroupName, serverName, expand).RecommendedElasticPools;
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