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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Sql;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlDatabaseAgentTargetGroupCommunicator
    {
        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        internal static IAzureSubscription Subscription { get; private set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates an Azure SQL Database Agent Communicator
        /// </summary>
        /// <param name="context"></param>
        public AzureSqlDatabaseAgentTargetGroupCommunicator(IAzureContext context)
        {
            Context = context;
            if (Context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
            }
        }

        /// <summary>
        /// Creates an Azure SQL Database Agent Target Group
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="targetGroupName">The target groups name</param>
        /// <param name="parameters">The target group's create parameters</param>
        /// <returns>The created target group</returns>
        public Management.Sql.Models.JobTargetGroup CreateOrUpdate(
            string resourceGroupName,
            string serverName,
            string agentName,
            string targetGroupName,
            Management.Sql.Models.JobTargetGroup parameters)
        {
            return GetCurrentSqlClient().JobTargetGroups.CreateOrUpdate(resourceGroupName, serverName, agentName, targetGroupName, parameters);
        }

        /// <summary>
        /// Gets the associated Target group associated to the Azure SQL Database Agent
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="agentName"></param>
        /// <param name="targetGroupName"></param>
        /// <returns>The target group belonging to specified agent</returns>
        public Management.Sql.Models.JobTargetGroup Get(
            string resourceGroupName,
            string serverName,
            string agentName,
            string targetGroupName)
        {
            return GetCurrentSqlClient().JobTargetGroups.Get(resourceGroupName, serverName, agentName, targetGroupName);
        }

        /// <summary>
        /// Lists the target groups associated to the Azure SQL Database Agent.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>A list of target groups belonging to specified agent</returns>
        public IPage<Management.Sql.Models.JobTargetGroup> List(
            string resourceGroupName,
            string serverName,
            string agentName)
        {
            return GetCurrentSqlClient().JobTargetGroups.ListByAgent(resourceGroupName, serverName, agentName);
        }

        /// <summary>
        /// Deletes the target groups associated to the agent.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="targetGroupName">The target group name</param>
        public void Remove(
            string resourceGroupName,
            string serverName,
            string agentName,
            string targetGroupName)
        {
            GetCurrentSqlClient().JobTargetGroups.Delete(resourceGroupName, serverName, agentName, targetGroupName);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            // Note: client is not cached in static field because that causes ObjectDisposedException in functional tests.
            var sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return sqlClient;
        }
    }
}