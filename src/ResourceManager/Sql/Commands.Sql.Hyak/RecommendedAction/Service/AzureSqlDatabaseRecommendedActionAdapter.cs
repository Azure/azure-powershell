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
    /// Adapter for Database Recommended Action operations
    /// </summary>
    public class AzureSqlDatabaseRecommendedActionAdapter
    {
        /// <summary>
        /// Gets or sets the Communicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseRecommendedActionCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs adapter
        /// </summary>
        public AzureSqlDatabaseRecommendedActionAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlDatabaseRecommendedActionCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Database Recommended Action by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="databaseName">The name of the Azure Sql Database</param>
        /// <param name="advisorName">The name of the Azure Sql Database Advisor</param>
        /// <param name="RecommendedActionName">The name of the Azure Sql Database Recommended Action</param>
        /// <returns>The Azure Sql Database RecommendedAction object</returns>
        internal AzureSqlDatabaseRecommendedActionModel GetDatabaseRecommendedAction(string resourceGroupName, string serverName, string databaseName, string advisorName, string RecommendedActionName)
        {
            var response = Communicator.Get(resourceGroupName, serverName, databaseName, advisorName, RecommendedActionName, Util.GenerateTracingId());
            return new AzureSqlDatabaseRecommendedActionModel(resourceGroupName, serverName, databaseName, advisorName, response);
        }

        /// <summary>
        /// Gets a list of Azure Sql Database Recommended Actions.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="databaseName">The name of the Azure Sql Database</param>
        /// <param name="advisorName">The name of the Azure Sql Database Advisor</param>
        /// <returns>A list of Database Recommended Action objects</returns>
        internal ICollection<AzureSqlDatabaseRecommendedActionModel> ListDatabaseRecommendedActions(string resourceGroupName, string serverName, string databaseName, string advisorName)
        {
            var response = Communicator.List(resourceGroupName, serverName, databaseName, advisorName, Util.GenerateTracingId());
            return response.Select(adv => new AzureSqlDatabaseRecommendedActionModel(resourceGroupName, serverName, databaseName, advisorName, adv)).ToList();
        }

        /// <summary>
        /// Updates Auto Execute Status of Azure Sql Database Recommended Action.
        /// </summary>
        /// <param name="model">The input parameters for the update operation</param>
        /// <returns>The upserted Azure Sql Database Recommended Action</returns>
        internal AzureSqlDatabaseRecommendedActionModel UpdateState(AzureSqlDatabaseRecommendedActionModel model)
        {
            var response = Communicator.UpdateState(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.AdvisorName, model.RecommendedActionName, model.State.CurrentValue, Util.GenerateTracingId());
            return new AzureSqlDatabaseRecommendedActionModel(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.AdvisorName, response);
        }
    }
}
