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
using Microsoft.Azure.Management.Sql.LegacySdk;
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
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Service Tier Advisor
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServiceTierAdvisorCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
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
        /// <returns></returns>
        public Management.Sql.LegacySdk.Models.Database GetDatabaseExpanded(string resourceGroupName, string serverName, string databaseName, string expand)
        {
            return GetCurrentSqlClient().Databases.GetExpanded(resourceGroupName, serverName, databaseName, expand).Database;
        }

        /// <summary>
        /// List databases expanded
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of Azure Sql server</param>
        /// <param name="expand">Expand string</param>
        /// <returns>List of databases</returns>
        public IList<Management.Sql.LegacySdk.Models.Database> ListDatabasesExpanded(string resourceGroupName, string serverName, string expand)
        {
            return GetCurrentSqlClient().Databases.ListExpanded(resourceGroupName, serverName, expand).Databases;
        }

        /// <summary>
        /// Get recommended elastic pools
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of Azure Sql server</param>
        /// <param name="expand">Expand string</param>
        /// <returns>List of recommended elastic pools</returns>
        public IList<Management.Sql.LegacySdk.Models.RecommendedElasticPool> GetRecommendedElasticPoolsExpanded(string resourceGroupName, string serverName, string expand)
        {
            return GetCurrentSqlClient().RecommendedElasticPools.ListExpanded(resourceGroupName, serverName, expand).RecommendedElasticPools;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }
    }
}
