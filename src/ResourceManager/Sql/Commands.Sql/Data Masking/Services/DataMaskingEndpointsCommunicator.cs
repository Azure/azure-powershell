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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.DataMasking.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the data masking endpoints
    /// </summary>
    public class DataMaskingEndpointsCommunicator
    {
        /// <summary>
        /// The sql management client used by this communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        private static AzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        public DataMaskingEndpointsCommunicator(AzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Get the data masking policy for a specific database
        /// </summary>
        public DataMaskingPolicy GetDatabaseDataMaskingPolicy(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            IDataMaskingOperations operations = GetCurrentSqlClient(clientRequestId).DataMasking;
            DataMaskingPolicyGetResponse response = operations.GetPolicy(resourceGroupName, serverName, databaseName);
            return response.DataMaskingPolicy;
        }

        /// <summary>
        /// Set (or create) the data masking policy for a specific database
        /// </summary>
        public void SetDatabaseDataMaskingPolicy(string resourceGroupName, string serverName, string databaseName, string clientRequestId, DataMaskingPolicyCreateOrUpdateParameters parameters)
        {
            IDataMaskingOperations operations = GetCurrentSqlClient(clientRequestId).DataMasking;
            operations.CreateOrUpdatePolicy(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Calls to list all the data masking rules for a specific database
        /// </summary>
        public IList<DataMaskingRule> ListDataMaskingRules(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            IDataMaskingOperations operations = GetCurrentSqlClient(clientRequestId).DataMasking;
            DataMaskingRuleListResponse response = operations.List(resourceGroupName, serverName, databaseName);
            return response.DataMaskingRules;
        }

        /// <summary>
        /// Sets the data masking rules for a specific database
        /// </summary>
        public void SetDatabaseDataMaskingRule(string resourceGroupName, string serverName, string databaseName, string ruleId, string clientRequestId, DataMaskingRuleCreateOrUpdateParameters parameters)
        {
            IDataMaskingOperations operations = GetCurrentSqlClient(clientRequestId).DataMasking;
            operations.CreateOrUpdateRule(resourceGroupName, serverName, databaseName, ruleId, parameters);
        }

        /// <summary>
        /// Deletes a data masking rule from the list of rules of a specific database
        /// </summary>
        public void DeleteDataMaskingRule(string resourceGroupName, string serverName, string databaseName, string ruleId, string clientRequestId)
        {
            IDataMaskingOperations operations = GetCurrentSqlClient(clientRequestId).DataMasking;
            operations.Delete(resourceGroupName, serverName, databaseName, ruleId);
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