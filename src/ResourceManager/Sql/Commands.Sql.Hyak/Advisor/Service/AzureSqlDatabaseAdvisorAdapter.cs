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
    /// Adapter for database advisor operations
    /// </summary>
    public class AzureSqlDatabaseAdvisorAdapter
    {
        /// <summary>
        /// Gets or sets the Communicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseAdvisorCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs adapter
        /// </summary>
        public AzureSqlDatabaseAdvisorAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlDatabaseAdvisorCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Database Advisor by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="databaseName">The name of the Azure Sql Database</param>
        /// <param name="advisorName">The name of the Azure Sql Database Advisor</param>
        /// <param name="expandRecommendedActions">Whether recommended actions should be expanded in the response</param>
        /// <returns>The Azure Sql Database Advisor object</returns>
        internal AzureSqlDatabaseAdvisorModel GetDatabaseAdvisor(string resourceGroupName, string serverName, string databaseName, string advisorName, bool expandRecommendedActions)
        {
            var response = Communicator.Get(resourceGroupName, serverName, databaseName, advisorName, expandRecommendedActions, Util.GenerateTracingId());
            return new AzureSqlDatabaseAdvisorModel(resourceGroupName, serverName, databaseName, response);
        }

        /// <summary>
        /// Gets a list of Azure Sql Database Advisors.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="databaseName">The name of the Azure Sql Database</param>
        /// <param name="expandRecommendedActions">Whether recommended actions should be expanded in the response</param>
        /// <returns>A list of database advisor objects</returns>
        internal ICollection<AzureSqlDatabaseAdvisorModel> ListDatabaseAdvisors(string resourceGroupName, string serverName, string databaseName, bool expandRecommendedActions)
        {
            var response = Communicator.List(resourceGroupName, serverName, databaseName, expandRecommendedActions, Util.GenerateTracingId());
            return response.Select(adv => new AzureSqlDatabaseAdvisorModel(resourceGroupName, serverName, databaseName, adv)).ToList();
        }

        /// <summary>
        /// Updates Auto Execute Status of Azure Sql Database Advisor.
        /// </summary>
        /// <param name="model">The input parameters for the update operation</param>
        /// <returns>The upserted Azure Sql Database Advisor</returns>
        internal AzureSqlDatabaseAdvisorModel UpdateAutoExecuteStatus(AzureSqlDatabaseAdvisorModel model)
        {
            var response = Communicator.UpdateAutoExecuteStatus(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.AdvisorName, model.AutoExecuteStatus, Util.GenerateTracingId());
            return new AzureSqlDatabaseAdvisorModel(model.ResourceGroupName, model.ServerName, model.DatabaseName, response);
        }
    }
}
