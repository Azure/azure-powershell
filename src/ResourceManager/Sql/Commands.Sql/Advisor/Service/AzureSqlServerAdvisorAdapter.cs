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
    /// Adapter for Server Advisor operations
    /// </summary>
    public class AzureSqlServerAdvisorAdapter
    {
        /// <summary>
        /// Gets or sets the Communicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerAdvisorCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs adapter
        /// </summary>
        public AzureSqlServerAdvisorAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerAdvisorCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Server Advisor by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Server</param>
        /// <param name="advisorName">The name of the Azure Sql Server Advisor</param>
        /// <param name="expandRecommendedActions">Whether recommended actions should be expanded in the response</param>
        /// <returns>The Azure Sql Server Advisor object</returns>
        internal AzureSqlServerAdvisorModel GetServerAdvisor(string resourceGroupName, string serverName, string advisorName, bool expandRecommendedActions)
        {
            var response = Communicator.Get(resourceGroupName, serverName, advisorName, expandRecommendedActions, Util.GenerateTracingId());
            return new AzureSqlServerAdvisorModel(resourceGroupName, serverName, response);
        }

        /// <summary>
        /// Gets a list of Azure Sql Server Advisors.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Server</param>
        /// <param name="expandRecommendedActions">Whether recommended actions should be expanded in the response</param>
        /// <returns>A list of database advisor objects</returns>
        internal ICollection<AzureSqlServerAdvisorModel> ListServerAdvisors(string resourceGroupName, string serverName, bool expandRecommendedActions)
        {
            var response = Communicator.List(resourceGroupName, serverName, expandRecommendedActions, Util.GenerateTracingId());
            return response.Select(adv => new AzureSqlServerAdvisorModel(resourceGroupName, serverName, adv)).ToList();
        }

        /// <summary>
        /// Updates Auto Execute Status of Azure Sql Server Advisor.
        /// </summary>
        /// <param name="model">The input parameters for the update operation</param>
        /// <returns>The upserted Azure Sql Server Advisor</returns>
        internal AzureSqlServerAdvisorModel UpdateAutoExecuteStatus(AzureSqlServerAdvisorModel model)
        {
            var response = Communicator.UpdateAutoExecuteStatus(model.ResourceGroupName, model.ServerName, model.AdvisorName, model.AutoExecuteStatus, Util.GenerateTracingId());
            return new AzureSqlServerAdvisorModel(model.ResourceGroupName, model.ServerName, response);
        }
    }
}
