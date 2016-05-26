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
using Microsoft.Azure.Commands.Sql.Model;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Service
{
    /// <summary>
    /// This class is responsible for all the REST communication with the server upgrade REST endpoints
    /// </summary>
    public class AzureSqlDatabaseIndexRecommendationCommunicator
    {
        /// <summary>
        /// Expand string
        /// </summary>
        private const string Expand = "schemas/tables/recommendedIndexes";

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
        /// Creates a communicator for Azure Sql Databases
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
        public AzureSqlDatabaseIndexRecommendationCommunicator(AzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// List all recommended indexes. If database name is null get recommendations for all databases on server.
        /// </summary>
        /// <param name="resourceGroupName">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="databaseName">Database name</param>
        /// <param name="clientRequestId">Request id</param>
        /// <returns>List of all recommended indexes for specified server</returns>
        public List<IndexRecommendation> ListRecommendedIndexes(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            var databases = new List<Management.Sql.Models.Database>();

            var recommendedIndexes = new List<IndexRecommendation>();
            if (string.IsNullOrEmpty(databaseName))
            {
                var response = GetCurrentSqlClient(clientRequestId).Databases.ListExpanded(resourceGroupName, serverName, Expand);
                databases.AddRange(response.Databases);
            }
            else
            {
                var response = GetCurrentSqlClient(clientRequestId).Databases.GetExpanded(resourceGroupName, serverName, databaseName, Expand);
                databases.Add(response.Database);
            }

            foreach (var database in databases)
            {
                foreach (var schema in database.Properties.Schemas)
                {
                    foreach (var table in schema.Properties.Tables)
                    {
                        foreach (var recommended in table.Properties.RecommendedIndexes)
                        {
                            var recommendation = new IndexRecommendation(recommended.Properties);
                            recommendation.DatabaseName = database.Name;
                            recommendation.Name = recommended.Name;
                            recommendedIndexes.Add(recommendation);
                        }
                    }
                }
            }
            return recommendedIndexes;
        }

        /// <summary>
        /// Update recommended index state
        /// </summary>
        /// <param name="resourceGroupName">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="databaseName">Database name</param>
        /// <param name="schema">Schema name</param>
        /// <param name="table">Table name</param>
        /// <param name="recommendedIndexName">Recommended index</param>
        /// <param name="state">State</param>
        /// <param name="clientRequestId">Request id</param>
        public void UpdateRecommendedIndexState(string resourceGroupName, string serverName, string databaseName, string schema, string table, string recommendedIndexName, string state, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).RecommendedIndexes.Update(resourceGroupName, serverName, databaseName, schema, table, recommendedIndexName,
                    new RecommendedIndexUpdateParameters
                    {
                        Properties = new RecommendedIndexUpdateProperties()
                        {
                            State = state
                        }
                    });
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
