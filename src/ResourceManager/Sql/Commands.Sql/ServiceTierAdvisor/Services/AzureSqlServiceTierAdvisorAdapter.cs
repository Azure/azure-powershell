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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ServiceTierAdvisor.Services
{
    /// <summary>
    /// Adapter for Service Tier Advisor operations
    /// </summary>
    public class AzureSqlServiceTierAdvisorAdapter
    {
        /// <summary>
        /// Master database name
        /// </summary>
        private const string MasterDatabase = "master";

        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServiceTierAdvisorCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a service tier advisor adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlServiceTierAdvisorAdapter(AzureContext context)
        {
            _subscription = context.Subscription;
            Context = context;
            Communicator = new AzureSqlServiceTierAdvisorCommunicator(Context);
        }

        /// <summary>
        /// Get upgrade database hints for database.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of Azure Sql server</param>
        /// <param name="databaseName">The name of Azure Sql database</param>
        /// <param name="excludeEpCandidates">Exclude databases if it is already recommended for elastic pool</param>
        /// <returns>Upgrade database hints</returns>
        public RecommendedDatabaseProperties GetUpgradeDatabaseHints(string resourceGroupName, string serverName, string databaseName, bool excludeEpCandidates)
        {
            // if excludeEpCandidates is set and database is included in recommended elastic pools return null
            if (excludeEpCandidates)
            {
                var pools = Communicator.GetRecommendedElasticPoolsExpanded(resourceGroupName, serverName, "databases", Util.GenerateTracingId());
                if (pools.SelectMany(pool => pool.Properties.Databases).Any(poolDatabase => databaseName == poolDatabase.Name))
                {
                    return null;
                }
            }
            var database = Communicator.GetDatabaseExpanded(resourceGroupName, serverName, databaseName, "upgradeHint", Util.GenerateTracingId());
            return CreateUpgradeDatabaseHint(database);
        }

        /// <summary>
        /// List recommended database service tier and SLO for all databases on server. 
        /// </summary>
        /// <param name="resourceGroupName">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="excludeEpCandidates">Exclude databases that are already recommended for elastic pools</param>
        /// <returns>List of UpgradeDatabaseHint</returns>
        public ICollection<RecommendedDatabaseProperties> ListUpgradeDatabaseHints(string resourceGroupName, string serverName, bool excludeEpCandidates)
        {
            var databases = Communicator.ListDatabasesExpanded(resourceGroupName, serverName, "upgradeHint", Util.GenerateTracingId());

            // if excludeEpCandidates flag is set filter out databases that are in recommended elastic pools
            if (excludeEpCandidates && databases.Count > 0)
            {
                var pools = Communicator.GetRecommendedElasticPoolsExpanded(resourceGroupName, serverName, "databases", Util.GenerateTracingId());
                var pooledDatabaseNames = new HashSet<string>(pools.SelectMany(pool => pool.Properties.Databases).Select(d => d.Name));
                databases = databases.Where(database => !pooledDatabaseNames.Contains(database.Name)).ToList();
            }

            return databases.Where(d => d.Name != MasterDatabase)
                .Select(CreateUpgradeDatabaseHint).ToList();
        }

        /// <summary>
        /// Creates UpgradeDatabaseHint from database object by using same edition and SLO from upgrade hint.
        /// </summary>
        /// <param name="database">Database object</param>
        /// <returns>Returns UpgradeDatabaseHint</returns>
        private RecommendedDatabaseProperties CreateUpgradeDatabaseHint(Management.Sql.Models.Database database)
        {
            return new RecommendedDatabaseProperties()
            {
                Name = database.Name,
                TargetEdition = SloToEdition(database.Properties.UpgradeHint.TargetServiceLevelObjective),
                TargetServiceLevelObjective = database.Properties.UpgradeHint.TargetServiceLevelObjective
            };
        }

        /// <summary>
        /// Map SLO to Edition
        /// </summary>
        /// <param name="ServiceLevelObjective">Service level objective string</param>
        /// <returns>Edition</returns>
        private string SloToEdition(string ServiceLevelObjective)
        {
            if (ServiceLevelObjective.StartsWith("B")) return "Basic";
            if (ServiceLevelObjective.StartsWith("S")) return "Standard";
            if (ServiceLevelObjective.StartsWith("P")) return "Premium";
            return null;
        }
    }
}
