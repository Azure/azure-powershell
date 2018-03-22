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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Services
{
    /// <summary>
    /// Adapter for Azure SQL Database Agent operations
    /// </summary>
    public class AzureSqlDatabaseAgentAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseAgentCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public AzureSqlDatabaseAgentAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlDatabaseAgentCommunicator(Context);
        }

        /// <summary>
        /// PUT: Upserts an Azure SQL Database Agent
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The upserted Azure SQL Database Agent</returns>
        public AzureSqlDatabaseAgentModel UpsertSqlDatabaseAgent(AzureSqlDatabaseAgentModel model)
        {
            // Construct database id
            string databaseId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases/{3}",
                AzureSqlDatabaseAgentCommunicator.Subscription.Id,
                model.ResourceGroupName,
                model.ServerName,
                model.DatabaseName);

            var param = new Management.Sql.Models.JobAgent
            {
                Location = model.Location,
                Tags = model.Tags,
                DatabaseId = databaseId
            };

            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.AgentName, param);

            return CreateAgentModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// PATCH: Updates an Azure SQL Database Agent (Mainly used for updating tags)
        /// </summary>
        /// <param name="model">The existing agent entity</param>
        /// <returns>The updated agent entity</returns>
        public AzureSqlDatabaseAgentModel UpdateSqlDatabaseAgent(AzureSqlDatabaseAgentModel model)
        {
            var param = new Management.Sql.Models.JobAgentUpdate
            {
                Tags = model.Tags
            };

            var resp = Communicator.Update(model.ResourceGroupName, model.ServerName, model.AgentName, param);

            return CreateAgentModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Gets a SQL Database Agent associated to a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>The converted agent model</returns>
        public AzureSqlDatabaseAgentModel GetSqlDatabaseAgent(string resourceGroupName, string serverName, string agentName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, agentName);
            return CreateAgentModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of SQL Database Agents associated to a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server the agents are in</param>
        /// <returns>The converted agent model(s)</returns>
        public IEnumerable<AzureSqlDatabaseAgentModel> GetSqlDatabaseAgent(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName);
            return resp.Select(agent => CreateAgentModelFromResponse(resourceGroupName, serverName, agent)).ToList();
        }

        /// <summary>
        /// Deletes an Azure SQL Database Agent associated to a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        public void RemoveSqlDatabaseAgent(string resourceGroupName, string serverName, string agentName)
        {
            Communicator.Remove(resourceGroupName, serverName, agentName);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.JobAgent to AzureSqlDatabaseAgentModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted agent model</returns>
        private static AzureSqlDatabaseAgentModel CreateAgentModelFromResponse(string resourceGroupName, string serverName, Management.Sql.Models.JobAgent resp)
        {
            // Parse database name from database id
            // This is not expected to ever fail, but in case we have a bug here it's better to provide a more detailed error message
            int lastSlashIndex = resp.DatabaseId.LastIndexOf('/');
            string databaseName = resp.DatabaseId.Substring(lastSlashIndex + 1);
            int? workerCount = resp.Sku.Capacity;

            AzureSqlDatabaseAgentModel agent = new AzureSqlDatabaseAgentModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = resp.Name,
                Location = resp.Location,
                DatabaseName = databaseName,
                WorkerCount = workerCount,
                ResourceId = resp.Id,
                Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(resp.Tags), false),
                DatabaseId = resp.DatabaseId
            };

            return agent;
        }

        /// <summary>
        /// Gets the Location of the server. Throws an exception if the server does not support Azure SQL Database Agents.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        /// <remarks>
        /// These 2 operations (get location, throw if not supported) are combined in order to minimize round trips.
        /// </remarks>
        public string GetServerLocationAndThrowIfAgentNotSupportedByServer(string resourceGroupName, string serverName)
        {
            AzureSqlServerCommunicator serverCommunicator = new AzureSqlServerCommunicator(Context);
            var server = serverCommunicator.Get(resourceGroupName, serverName);
            return server.Location;
        }
    }
}