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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.Auditing.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AuditingEndpointsCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static AzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        public AuditingEndpointsCommunicator(AzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the database auditing policy for the given database in the given database server in the given resource group
        /// </summary>
        public void GetDatabaseAuditingPolicy(string resourceGroupName, string serverName, string databaseName, string clientRequestId, out DatabaseAuditingPolicy policy)
        {
            IAuditingPolicyOperations operations = GetCurrentSqlClient(clientRequestId).AuditingPolicy;
            DatabaseAuditingPolicyGetResponse response = operations.GetDatabasePolicy(resourceGroupName, serverName, databaseName);
            policy = response.AuditingPolicy;
        }

        /// <summary>
        /// Gets the database server auditing policy for the given database server in the given resource group
        /// </summary>
        public void GetServerAuditingPolicy(string resourceGroupName, string serverName, string clientRequestId, out ServerAuditingPolicy policy)
        {
            IAuditingPolicyOperations operations = GetCurrentSqlClient(clientRequestId).AuditingPolicy;
            ServerAuditingPolicyGetResponse response = operations.GetServerPolicy(resourceGroupName, serverName);
            policy = response.AuditingPolicy;
        }

        /// <summary>
        /// Calls the set audit APIs for the database auditing policy for the given database in the given database server in the given resource group
        /// </summary>
        public void SetDatabaseAuditingPolicy(string resourceGroupName, string serverName, string databaseName, string clientRequestId, DatabaseAuditingPolicyCreateOrUpdateParameters parameters)
        {
            IAuditingPolicyOperations operations = GetCurrentSqlClient(clientRequestId).AuditingPolicy;
            operations.CreateOrUpdateDatabasePolicy(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Sets the database server auditing policy of the given database server in the given resource group
        /// </summary>
        public void SetServerAuditingPolicy(string resourceGroupName, string serverName, string clientRequestId, ServerAuditingPolicyCreateOrUpdateParameters parameters)
        {
            IAuditingPolicyOperations operations = GetCurrentSqlClient(clientRequestId).AuditingPolicy;
            operations.CreateOrUpdateServerPolicy(resourceGroupName, serverName, parameters);
        }

        /// <summary>
        /// Gets the database blob auditing policy for the given database in the given database server in the given resource group
        /// </summary>
        public void GetDatabaseAuditingPolicy(string resourceGroupName, string serverName, string databaseName, string clientRequestId, out BlobAuditingPolicy policy)
        {
            var operations = GetCurrentSqlClient(clientRequestId).BlobAuditing;
            var response = operations.GetDatabaseBlobAuditingPolicy(resourceGroupName, serverName, databaseName);
            policy = response.AuditingPolicy;
        }

        /// <summary>
        /// Gets the database server blob auditing policy for the given database server in the given resource group
        /// </summary>
        public void GetServerAuditingPolicy(string resourceGroupName, string serverName, string clientRequestId, out BlobAuditingPolicy policy)
        {
            var operations = GetCurrentSqlClient(clientRequestId).BlobAuditing;
            var response = operations.GetServerPolicy(resourceGroupName, serverName);
            policy = response.AuditingPolicy;
        }

        /// <summary>
        /// Calls the set blob audit APIs for the database auditing policy for the given database in the given database server in the given resource group
        /// </summary>
        public void SetDatabaseAuditingPolicy(string resourceGroupName, string serverName, string databaseName, string clientRequestId, BlobAuditingCreateOrUpdateParameters parameters)
        {
            var operations = GetCurrentSqlClient(clientRequestId).BlobAuditing;
            operations.CreateOrUpdateDatabasePolicy(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Sets the database server blob auditing policy of the given database server in the given resource group
        /// </summary>
        public void SetServerAuditingPolicy(string resourceGroupName, string serverName, string clientRequestId, BlobAuditingCreateOrUpdateParameters parameters)
        {
            var operations = GetCurrentSqlClient(clientRequestId).BlobAuditing;
            var statusLink =  operations.CreateOrUpdateServerPolicy(resourceGroupName, serverName, parameters).OperationStatusLink;
            for (var iterationCount = 0; iterationCount < 1800; iterationCount++) // wait for at most an hour
            {
                var status = GetServerCreateOrUpdateOperationStatus(statusLink, clientRequestId);
                if (status == OperationStatus.Succeeded)
                {
                    break;
                }
                Task.Delay(2000); // wait 2 seconds between each poll
            }
        }

        /// <summary>
        /// Returns the operation status of a server create or update operation
        /// </summary>
        public OperationStatus GetServerCreateOrUpdateOperationStatus(string operationStatusLink, string clientRequestId)
        {
            var operations = GetCurrentSqlClient(clientRequestId).BlobAuditing;
            return operations.GetOperationStatus(operationStatusLink).OperationResult.Properties.State;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient(String clientRequestId)
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            SqlClient.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return SqlClient;
        }
    }
}