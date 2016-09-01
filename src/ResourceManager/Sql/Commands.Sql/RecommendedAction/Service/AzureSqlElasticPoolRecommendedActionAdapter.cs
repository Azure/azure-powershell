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
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Sql.RecommendedAction.Model;
using Microsoft.Azure.Commands.Sql.Services;

namespace Microsoft.Azure.Commands.Sql.RecommendedAction.Service
{
    /// <summary>
    /// Adapter for Elastic Pool Recommended Action operations
    /// </summary>
    public class AzureSqlElasticPoolRecommendedActionAdapter
    {
        /// <summary>
        /// Gets or sets the Communicator which has all the needed management clients
        /// </summary>
        private AzureSqlElasticPoolRecommendedActionCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs adapter
        /// </summary>
        public AzureSqlElasticPoolRecommendedActionAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlElasticPoolRecommendedActionCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql ElasticPool Recommended Action by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql ElasticPool Server</param>
        /// <param name="elasticPoolName">The name of the Azure Sql Elastic Pool</param>
        /// <param name="advisorName">The name of the Azure Sql Elastic Pool Advisor</param>
        /// <param name="RecommendedActionName">The name of the Azure Sql Elastic Pool Recommended Action</param>
        /// <returns>The Azure Sql Elastic Pool Recommended Action object</returns>
        internal AzureSqlElasticPoolRecommendedActionModel GetElasticPoolRecommendedAction(string resourceGroupName, string serverName, string elasticPoolName, string advisorName, string RecommendedActionName)
        {
            var response = Communicator.Get(resourceGroupName, serverName, elasticPoolName, advisorName, RecommendedActionName, Util.GenerateTracingId());
            return new AzureSqlElasticPoolRecommendedActionModel(resourceGroupName, serverName, elasticPoolName, advisorName, response);
        }

        /// <summary>
        /// Gets a list of Azure Sql ElasticPool Recommended Actions.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Elastic Pool Server</param>
        /// <param name="elasticPoolName">The name of the Azure Sql Elastic Pool</param>
        /// <param name="advisorName">The name of the Azure Sql Elastic Pool Advisor</param>
        /// <returns>A list of Elastic Pool Recommended Action objects</returns>
        internal ICollection<AzureSqlElasticPoolRecommendedActionModel> ListElasticPoolRecommendedActions(string resourceGroupName, string serverName, string elasticPoolName, string advisorName)
        {
            var response = Communicator.List(resourceGroupName, serverName, elasticPoolName, advisorName, Util.GenerateTracingId());
            return response.Select(adv => new AzureSqlElasticPoolRecommendedActionModel(resourceGroupName, serverName, elasticPoolName, advisorName, adv)).ToList();
        }

        /// <summary>
        /// Updates Auto Execute Status of Azure Sql Elastic Pool Recommended Action.
        /// </summary>
        /// <param name="model">The input parameters for the update operation</param>
        /// <returns>The upserted Azure Sql Elastic Pool Recommended Action</returns>
        internal AzureSqlElasticPoolRecommendedActionModel UpdateState(AzureSqlElasticPoolRecommendedActionModel model)
        {
            var response = Communicator.UpdateState(model.ResourceGroupName, model.ServerName, model.ElasticPoolName, model.AdvisorName, model.RecommendedActionName, model.State.CurrentValue, Util.GenerateTracingId());
            return new AzureSqlElasticPoolRecommendedActionModel(model.ResourceGroupName, model.ServerName, model.ElasticPoolName, model.AdvisorName, response);
        }
    }
}
