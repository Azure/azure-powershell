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

namespace Microsoft.Azure.Commands.Sql.RecommendedElasticPools.Services
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
        public AzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a recommended elastic pool adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlElasticPoolRecommendationAdapter(AzureContext context)
        {
            _subscription = context.Subscription;
            Context = context;
            RecommendationCommunicator = new AzureSqlElasticPoolRecommendationCommunicator(Context);
        }

        /// <summary>
        /// Gets a list of Azure Sql Recommended Elastic Pool.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<UpgradeRecommendedElasticPoolProperties> ListRecommendedElasticPoolProperties(string resourceGroupName, string serverName)
        {
            var resp = RecommendationCommunicator.ListExpanded(resourceGroupName, serverName, "databases", Util.GenerateTracingId());
            return resp.Select(CreateRecommendedElasticPoolPropertiesFromResponse).ToList();
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="pool">The service response</param>
        /// <returns>The converted model</returns>
        private UpgradeRecommendedElasticPoolProperties CreateRecommendedElasticPoolPropertiesFromResponse(RecommendedElasticPool pool)
        {
            var model = new UpgradeRecommendedElasticPoolProperties();

            model.DatabaseCollection = pool.Properties.Databases.Select(database => database.Name).ToList();
            model.DatabaseDtuMax = (int)pool.Properties.DatabaseDtuMax;
            model.DatabaseDtuMin = (int)pool.Properties.DatabaseDtuMin;
            model.Dtu = (int)pool.Properties.Dtu;
            model.Edition = pool.Properties.DatabaseEdition;
            model.IncludeAllDatabases = false;
            model.Name = pool.Name;
            return model;
        }
    }
}
