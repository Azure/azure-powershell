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
using System.Security.Permissions;
using System.Security;
using System;
using System.Runtime.InteropServices;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Services
{
    /// <summary>
    /// Adapter for Azure SQL Database Agent operations
    /// </summary>
    public class AzureSqlDatabaseAgentJobCredentialAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseAgentJobCredentialCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public AzureSqlDatabaseAgentJobCredentialAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlDatabaseAgentJobCredentialCommunicator(Context);
        }

        /// <summary>
        /// Upserts an Azure SQL Database Agent to a server
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The upserted Azure SQL Database Agent</returns>
        public AzureSqlDatabaseAgentJobCredentialModel UpsertJobCredential(AzureSqlDatabaseAgentJobCredentialModel model)
        {
            // Construct database id
            string databaseId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases/{3}",
                AzureSqlDatabaseAgentJobCredentialCommunicator.Subscription.Id,
                model.ResourceGroupName,
                model.ServerName,
                model.CredentialName);

            var param = new Management.Sql.Models.JobCredential
            {
                Username = model.UserName,
                Password = model.Password != null ? Decrypt(model.Password) : null
            };

            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.AgentName, model.CredentialName, param);

            return CreateAgentCredentialModelFromResponse(model.ResourceGroupName, model.ServerName, model.AgentName, resp);
        }

        /// <summary>
        /// Gets a SQL Database Agent associated to a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>The converted agent model</returns>
        public AzureSqlDatabaseAgentJobCredentialModel GetJobCredential(string resourceGroupName, string serverName, string agentName, string credentialName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, agentName, credentialName);
            return CreateAgentCredentialModelFromResponse(resourceGroupName, serverName, agentName, resp);
        }

        /// <summary>
        /// Gets a list of SQL Database Agents associated to a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server the agents are in</param>
        /// <returns>The converted agent model(s)</returns>
        public List<AzureSqlDatabaseAgentJobCredentialModel> GetJobCredential(string resourceGroupName, string serverName, string agentName)
        {
            var resp = Communicator.List(resourceGroupName, serverName, agentName);
            return resp.Select(credentialName => CreateAgentCredentialModelFromResponse(resourceGroupName, serverName, agentName, credentialName)).ToList();
        }

        /// <summary>
        /// Deletes an Azure SQL Database Agent associated to a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        public void RemoveJobCredential(string resourceGroupName, string serverName, string agentName, string credentialName)
        {
            Communicator.Remove(resourceGroupName, serverName, agentName, credentialName);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.JobAgent to AzureSqlDatabaseAgentJobCredentialModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted agent model</returns>
        private static AzureSqlDatabaseAgentJobCredentialModel CreateAgentCredentialModelFromResponse(string resourceGroupName, string serverName, string agentName, Management.Sql.Models.JobCredential resp)
        {
            // Parse credential name from id
            // This is not expected to ever fail, but in case we have a bug here it's better to provide a more detailed error message
            int lastSlashIndex = resp.Id.LastIndexOf('/');
            string credentialName = resp.Id.Substring(lastSlashIndex + 1);

            AzureSqlDatabaseAgentJobCredentialModel credential = new AzureSqlDatabaseAgentJobCredentialModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = agentName,
                CredentialName = resp.Name,
                UserName = resp.Username,
                ResourceId = resp.Id
            };

            return credential;
        }

        /// <summary>
        /// Convert a <see cref="SecureString"/> to a plain-text string representation.
        /// This should only be used in a proetected context, and must be done in the same logon and process context
        /// in which the <see cref="SecureString"/> was constructed.
        /// </summary>
        /// <param name="secureString">The encrypted <see cref="SecureString"/>.</param>
        /// <returns>The plain-text string representation.</returns>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        internal static string Decrypt(SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}