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

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Services
{
    /// <summary>
    /// Adapter for Azure SQL Database Agent operations
    /// </summary>
    public class AzureSqlDatabaseAgentTargetGroupAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseAgentTargetGroupCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public AzureSqlDatabaseAgentTargetGroupAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlDatabaseAgentTargetGroupCommunicator(Context);
        }

        /// <summary>
        /// Upserts an Azure SQL Database Agent to a server
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The upserted Azure SQL Database Agent</returns>
        public AzureSqlDatabaseAgentTargetGroupModel UpsertTargetGroup(AzureSqlDatabaseAgentTargetGroupModel model)
        {
            var param = new Management.Sql.Models.JobTargetGroup
            {
                Members = model.Members,
            };

            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.AgentName, model.TargetGroupName, param);
            return CreateTargetGroupModelFromResponse(model.ResourceGroupName, model.ServerName, model.AgentName, resp);
        }

        /// <summary>
        /// Gets a SQL Database Agent associated to a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>The converted agent model</returns>
        public AzureSqlDatabaseAgentTargetGroupModel GetTargetGroup(string resourceGroupName, string serverName, string agentName, string targetGroupName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, agentName, targetGroupName);
            return CreateTargetGroupModelFromResponse(resourceGroupName, serverName, agentName, resp);
        }

        /// <summary>
        /// Gets a SQL Database Agent associated to a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>The converted agent model</returns>
        public List<AzureSqlDatabaseAgentTargetGroupModel> GetTargetGroup(string resourceGroupName, string serverName, string agentName)
        {
            var resp = Communicator.List(resourceGroupName, serverName, agentName);
            return resp.Select(targetGroup => CreateTargetGroupModelFromResponse(resourceGroupName, serverName, agentName, targetGroup)).ToList();
        }

        /// <summary>
        /// Deletes an Azure SQL Database Agent associated to a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        public void RemoveTargetGroup(string resourceGroupName, string serverName, string agentName, string targetGroupName)
        {
            Communicator.Remove(resourceGroupName, serverName, agentName, targetGroupName);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.JobAgent to AzureSqlDatabaseAgentTargetGroupModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted agent model</returns>
        private static AzureSqlDatabaseAgentTargetGroupModel CreateTargetGroupModelFromResponse(string resourceGroupName, string serverName, string agentName, Management.Sql.Models.JobTargetGroup resp)
        {
            AzureSqlDatabaseAgentTargetGroupModel targetGroup = new AzureSqlDatabaseAgentTargetGroupModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = agentName,
                TargetGroupName = resp.Name,
                Members = resp.Members,
                ResourceId = resp.Id
            };

            return targetGroup;
        }
    }
}