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
using Microsoft.Azure.Commands.Sql.Advisor.Model;
using Microsoft.Azure.Commands.Sql.Services;

namespace Microsoft.Azure.Commands.Sql.Advisor.Service
{
    /// <summary>
    /// Adapter for Elastic Pool advisor operations
    /// </summary>
    public class AzureSqlElasticPoolAdvisorAdapter
    {
        /// <summary>
        /// Gets or sets the Communicator which has all the needed management clients
        /// </summary>
        private AzureSqlElasticPoolAdvisorCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs adapter
        /// </summary>
        public AzureSqlElasticPoolAdvisorAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlElasticPoolAdvisorCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Elastic Pool Advisor by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Elastic Pool Server</param>
        /// <param name="elasticPoolName">The name of the Azure Sql Elastic Pool</param>
        /// <param name="advisorName">The name of the Azure Sql Elastic Pool Advisor</param>
        /// <param name="expandRecommendedActions">Whether recommended actions should be expanded in the response</param>
        /// <returns>The Azure Sql Elastic Pool Advisor object</returns>
        internal AzureSqlElasticPoolAdvisorModel GetElasticPoolAdvisor(string resourceGroupName, string serverName, string elasticPoolName, string advisorName, bool expandRecommendedActions)
        {
            var response = Communicator.Get(resourceGroupName, serverName, elasticPoolName, advisorName, expandRecommendedActions, Util.GenerateTracingId());
            return new AzureSqlElasticPoolAdvisorModel(resourceGroupName, serverName, elasticPoolName, response);
        }

        /// <summary>
        /// Gets a list of Azure Sql Elastic Pool Advisors.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Elastic Pool Server</param>
        /// <param name="elasticPoolName">The name of the Azure Sql Elastic Pool</param>
        /// <param name="expandRecommendedActions">Whether recommended actions should be expanded in the response</param>
        /// <returns>A list of elastic pool advisor objects</returns>
        internal ICollection<AzureSqlElasticPoolAdvisorModel> ListElasticPoolAdvisors(string resourceGroupName, string serverName, string elasticPoolName, bool expandRecommendedActions)
        {
            var response = Communicator.List(resourceGroupName, serverName, elasticPoolName, expandRecommendedActions, Util.GenerateTracingId());
            return response.Select(adv => new AzureSqlElasticPoolAdvisorModel(resourceGroupName, serverName, elasticPoolName, adv)).ToList();
        }

        /// <summary>
        /// Updates Auto Execute Status of Azure Sql Elastic Pool Advisor.
        /// </summary>
        /// <param name="model">The input parameters for the update operation</param>
        /// <returns>The upserted Azure Sql Elastic Pool Advisor</returns>
        internal AzureSqlElasticPoolAdvisorModel UpdateAutoExecuteStatus(AzureSqlElasticPoolAdvisorModel model)
        {
            var response = Communicator.UpdateAutoExecuteStatus(model.ResourceGroupName, model.ServerName, model.ElasticPoolName, model.AdvisorName, model.AutoExecuteStatus, Util.GenerateTracingId());
            return new AzureSqlElasticPoolAdvisorModel(model.ResourceGroupName, model.ServerName, model.ElasticPoolName, response);
        }
    }
}
