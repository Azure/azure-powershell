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

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlDatabaseAgentJobCredentialCommunicator
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
        public AzureSqlDatabaseAgentJobCredentialCommunicator(IAzureContext context)
        {
            Context = context;
            if (Context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
            }
        }

        /// <summary>
        /// Creates an Azure SQL Database Agent Job Credential
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="credentialName">The credential name</param>
        /// <param name="parameters">The agent's create parameters</param>
        /// <returns>The newly created agent</returns>
        public Management.Sql.Models.JobCredential CreateOrUpdate(
            string resourceGroupName, 
            string serverName, 
            string agentName, 
            string credentialName, 
            Management.Sql.Models.JobCredential parameters)
        {
            return GetCurrentSqlClient().JobCredentials.CreateOrUpdate(resourceGroupName, serverName, agentName, credentialName, parameters);
        }

        /// <summary>
        /// Gets the associated Job Credential associated to the Azure SQL Database Agent
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="agentName"></param>
        /// <param name="credentialName"></param>
        /// <returns>The agent belonging to specified server</returns>
        public Management.Sql.Models.JobCredential Get(
            string resourceGroupName, 
            string serverName, 
            string agentName, 
            string credentialName)
        {
            return GetCurrentSqlClient().JobCredentials.Get(resourceGroupName, serverName, agentName, credentialName);
        }

        /// <summary>
        /// Lists the credentials associated to the Azure SQL Database Agent.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>A list of credentials belonging to specified agent</returns>
        public IPage<Management.Sql.Models.JobCredential> List(
            string resourceGroupName, 
            string serverName, 
            string agentName)
        {
            return GetCurrentSqlClient().JobCredentials.ListByAgent(resourceGroupName, serverName, agentName);
        }

        /// <summary>
        /// Deletes the credential associated to the agent.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="credentialName">The credential name</param>
        public void Remove(
            string resourceGroupName, 
            string serverName, 
            string agentName, 
            string credentialName)
        {
            GetCurrentSqlClient().JobCredentials.Delete(resourceGroupName, serverName, agentName, credentialName);
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