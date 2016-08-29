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
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Sql.ThreatDetection.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the security alert REST endpoints
    /// </summary>
    public class ThreatDetectionEndpointsCommunicator
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

        public ThreatDetectionEndpointsCommunicator(AzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the server security alert policy for the given server in the given resource group
        /// </summary>
        public ServerSecurityAlertPolicy GetServerSecurityAlertPolicy(string resourceGroupName, string serverName, string clientRequestId)
        {
            ISecurityAlertPolicyOperations operations = GetCurrentSqlClient(clientRequestId).SecurityAlertPolicy;
            var response = operations.GetServerSecurityAlertPolicy(resourceGroupName, serverName);
            return response.SecurityAlertPolicy;
        }

        /// <summary>
        /// Calls the set security alert APIs for the server security alert policy in the given resource group
        /// </summary>
        public void SetServerSecurityAlertPolicy(string resourceGroupName, string serverName, string clientRequestId, ServerSecurityAlertPolicyCreateOrUpdateParameters parameters)
        {
            ISecurityAlertPolicyOperations operations = GetCurrentSqlClient(clientRequestId).SecurityAlertPolicy;
            var statusLink = operations.CreateOrUpdateServerSecurityAlertPolicy(resourceGroupName, serverName, parameters).OperationStatusLink;
            if (string.IsNullOrEmpty(statusLink))
            {
                return;
            }
            for (var iterationCount = 0; iterationCount < 1800; iterationCount++) // wait for at most an hour
            {
                var status = GetServerCreateOrUpdateOperationStatus(statusLink, clientRequestId);
                if (status == OperationStatus.Succeeded)
                {
                    break;
                }
                TestMockSupport.Delay(2000); // wait 2 seconds between each poll
            }
        }

        /// <summary>
        /// Returns the operation status of a server create or update operation
        /// </summary>
        public OperationStatus GetServerCreateOrUpdateOperationStatus(string operationStatusLink, string clientRequestId)
        {
            var operations = GetCurrentSqlClient(clientRequestId).SecurityAlertPolicy;
            return operations.GetOperationStatus(operationStatusLink).OperationResult.Properties.State;
        }

        /// <summary>
        /// Gets the database security alert policy for the given database in the given database server in the given resource group
        /// </summary>
        public DatabaseSecurityAlertPolicy GetDatabaseSecurityAlertPolicy(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            ISecurityAlertPolicyOperations operations = GetCurrentSqlClient(clientRequestId).SecurityAlertPolicy;
            DatabaseSecurityAlertPolicyGetResponse response = operations.GetDatabaseSecurityAlertPolicy(resourceGroupName, serverName, databaseName);
            return response.SecurityAlertPolicy;
        }

        /// <summary>
        /// Calls the set security alert APIs for the database security alert policy for the given database in the given database server in the given resource group
        /// </summary>
        public void SetDatabaseSecurityAlertPolicy(string resourceGroupName, string serverName, string databaseName, string clientRequestId, DatabaseSecurityAlertPolicyCreateOrUpdateParameters parameters)
        {
            ISecurityAlertPolicyOperations operations = GetCurrentSqlClient(clientRequestId).SecurityAlertPolicy;
            operations.CreateOrUpdateDatabaseSecurityAlertPolicy(resourceGroupName, serverName, databaseName, parameters);
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