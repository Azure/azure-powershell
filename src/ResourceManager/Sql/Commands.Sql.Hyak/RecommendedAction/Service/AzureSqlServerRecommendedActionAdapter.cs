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
    /// Adapter for Server Recommended Action operations
    /// </summary>
    public class AzureSqlServerRecommendedActionAdapter
    {
        /// <summary>
        /// Gets or sets the Communicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerRecommendedActionCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs adapter
        /// </summary>
        public AzureSqlServerRecommendedActionAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerRecommendedActionCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Server Recommended Action by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Server</param>
        /// <param name="advisorName">The name of the Azure Sql Server Advisor</param>
        /// <param name="RecommendedActionName">The name of the Azure Sql Server Recommended Action</param>
        /// <returns>The Azure Sql Server RecommendedAction object</returns>
        internal AzureSqlServerRecommendedActionModel GetServerRecommendedAction(string resourceGroupName, string serverName, string advisorName, string RecommendedActionName)
        {
            var response = Communicator.Get(resourceGroupName, serverName, advisorName, RecommendedActionName, Util.GenerateTracingId());
            return new AzureSqlServerRecommendedActionModel(resourceGroupName, serverName, advisorName, response);
        }

        /// <summary>
        /// Gets a list of Azure Sql Server Recommended Actions.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Server</param>
        /// <param name="advisorName">The name of the Azure Sql Server Advisor</param>
        /// <returns>A list of Server Recommended Action objects</returns>
        internal ICollection<AzureSqlServerRecommendedActionModel> ListServerRecommendedActions(string resourceGroupName, string serverName, string advisorName)
        {
            var response = Communicator.List(resourceGroupName, serverName, advisorName, Util.GenerateTracingId());
            return response.Select(adv => new AzureSqlServerRecommendedActionModel(resourceGroupName, serverName, advisorName, adv)).ToList();
        }

        /// <summary>
        /// Updates Auto Execute Status of Azure Sql Server Recommended Action.
        /// </summary>
        /// <param name="model">The input parameters for the update operation</param>
        /// <returns>The upserted Azure Sql Server Recommended Action</returns>
        internal AzureSqlServerRecommendedActionModel UpdateState(AzureSqlServerRecommendedActionModel model)
        {
            var response = Communicator.UpdateState(model.ResourceGroupName, model.ServerName, model.AdvisorName, model.RecommendedActionName, model.State.CurrentValue, Util.GenerateTracingId());
            return new AzureSqlServerRecommendedActionModel(model.ResourceGroupName, model.ServerName, model.AdvisorName, response);
        }
    }
}
