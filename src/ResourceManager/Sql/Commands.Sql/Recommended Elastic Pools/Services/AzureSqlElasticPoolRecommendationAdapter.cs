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
using System.Linq;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Sql.ElasticPoolRecommendation.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ElasticPoolRecommendation.Services
{
    /// <summary>
    /// Adapter for RecommendedElasticPool operations
    /// </summary>
    public class AzureSqlElasticPoolRecommendationAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlElasticPoolRecommendationCommunicator RecommendationCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureProfile Profile { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a recommended elastic pool adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlElasticPoolRecommendationAdapter(AzureProfile profile, AzureSubscription subscription)
        {
            _subscription = subscription;
            Profile = profile;
            RecommendationCommunicator = new AzureSqlElasticPoolRecommendationCommunicator(profile, subscription);
        }

        /// <summary>
        /// Gets an Azure Sql Recommended Elastic Pool by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="poolName">The name of the Azure Sql Database RecommendedElasticPool</param>
        /// <returns>The Azure Sql Database RecommendedElasticPool object</returns>
        internal AzureSqlElasticPoolRecommendationModel GetElasticPoolRecommendation(string resourceGroupName, string serverName, string poolName)
        {
            var resp = RecommendationCommunicator.Get(resourceGroupName, serverName, poolName, Util.GenerateTracingId());
            return CreateRecommendedElasticPoolModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Recommended Elastic Pool.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlElasticPoolRecommendationModel> ListElasticPoolRecommendations(string resourceGroupName, string serverName)
        {
            var resp = RecommendationCommunicator.List(resourceGroupName, serverName, Util.GenerateTracingId());
            return resp.Select((db) => CreateRecommendedElasticPoolModelFromResponse(resourceGroupName, serverName, db)).ToList();
        }

        /// <summary>
        /// Gets a database in an recommended elastic pool
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="poolName">The name of the Azure Sql RecommendedElasticPool</param>
        /// <param name="databaseName">The name of the database</param>
        /// <returns></returns>
        public AzureSqlDatabaseModel GetElasticPoolRecommendationDatabase(string resourceGroupName, string serverName, string poolName, string databaseName)
        {
            var resp = RecommendationCommunicator.GetDatabase(resourceGroupName, serverName, poolName, databaseName, Util.GenerateTracingId());
            return AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Databases in an RecommendedElasticPool.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="poolName">The name of the recommended elastic pool the database are in</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlDatabaseModel> ListElasticPoolRecommendationDatabases(string resourceGroupName, string serverName, string poolName)
        {
            var resp = RecommendationCommunicator.ListDatabases(resourceGroupName, serverName, poolName, Util.GenerateTracingId());
            return resp.Select((db) => AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroupName, serverName, db)).ToList();
        }

        /// <summary>
        /// Gets a list of Recommended Elastic Pool Metrics
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="poolName">The name of the recommended elastic pool</param>
        /// <returns>A list of RecommendedElastic Pool Activities</returns>
        internal IList<AzureSqlElasticPoolRecommendationMetricModel> GetElasticPoolRecommendationMetrics(string resourceGroupName, string serverName, string poolName)
        {
            var resp = RecommendationCommunicator.ListMetrics(resourceGroupName, serverName, poolName, Util.GenerateTracingId());
            return resp.Select(CreateMetricModelFromResponse).ToList();
        }

        /// <summary>
        /// Converts a RecommendedElasticPoolMetric metric to the powershell metric.
        /// </summary>
        /// <param name="metric">The metric from the service</param>
        /// <returns>The converted metric</returns>
        private AzureSqlElasticPoolRecommendationMetricModel CreateMetricModelFromResponse(RecommendedElasticPoolMetric metric)
        {
            return new AzureSqlElasticPoolRecommendationMetricModel()
            {
                DateTime = metric.DateTime,
                Dtu = metric.Dtu,
                SizeGB = metric.SizeGB
            };
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="pool">The service response</param>
        /// <returns>The converted model</returns>
        private AzureSqlElasticPoolRecommendationModel CreateRecommendedElasticPoolModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.RecommendedElasticPool pool)
        {
            AzureSqlElasticPoolRecommendationModel recommendationModel = new AzureSqlElasticPoolRecommendationModel();

            recommendationModel.ResourceGroupName = resourceGroup;
            recommendationModel.ServerName = serverName;
            recommendationModel.RecommendedElasticPoolName = pool.Name;
            
            DatabaseEdition edition = DatabaseEdition.None;
            Enum.TryParse<DatabaseEdition>(pool.Properties.DatabaseEdition, out edition);
            recommendationModel.DatabaseEdition = edition;

            recommendationModel.Dtu = pool.Properties.Dtu;
            recommendationModel.DatabaseDtuMax = pool.Properties.DatabaseDtuMax;
            recommendationModel.DatabaseDtuMin = pool.Properties.DatabaseDtuMin;
            recommendationModel.StorageMB = pool.Properties.StorageMB;
            recommendationModel.ObservationPeriodStart = pool.Properties.ObservationPeriodStart;
            recommendationModel.ObservationPeriodEnd = pool.Properties.ObservationPeriodEnd;
            recommendationModel.MaxObservedDtu = pool.Properties.MaxObservedDtu;
            recommendationModel.MaxObservedStorageMB = pool.Properties.MaxObservedStorageMB;
            recommendationModel.Tags = pool.Tags as Dictionary<string, string>;

            return recommendationModel;
        }
    }
}
