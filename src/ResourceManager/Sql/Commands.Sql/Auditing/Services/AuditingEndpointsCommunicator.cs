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
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System.Threading;

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
        /// The Legacy Sql client to be used by this end points communicator
        /// </summary>
        private static Management.Sql.LegacySdk.SqlManagementClient LegacySqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public AuditingEndpointsCommunicator(IAzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                LegacySqlClient = null;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the database auditing policy for the given database in the given database server in the given resource group
        /// </summary>
        public void GetDatabaseAuditingPolicy(string resourceGroupName, string serverName, string databaseName, out Management.Sql.LegacySdk.Models.DatabaseAuditingPolicy policy)
        {
            policy = Management.Sql.LegacySdk.AuditingPolicyOperationsExtensions.GetDatabasePolicy(
                GetCurrentLegacySqlClient().AuditingPolicy, resourceGroupName, serverName, databaseName).AuditingPolicy;
        }

        /// <summary>
        /// Gets the database server auditing policy for the given database server in the given resource group
        /// </summary>
        public void GetServerAuditingPolicy(string resourceGroupName, string serverName, out Management.Sql.LegacySdk.Models.ServerAuditingPolicy policy)
        {
            policy = Management.Sql.LegacySdk.AuditingPolicyOperationsExtensions.GetServerPolicy(
                GetCurrentLegacySqlClient().AuditingPolicy, resourceGroupName, serverName).AuditingPolicy;
        }

        /// <summary>
        /// Calls the set audit APIs for the database auditing policy for the given database in the given database server in the given resource group
        /// </summary>
        public void SetDatabaseAuditingPolicy(string resourceGroupName, string serverName, string databaseName, Management.Sql.LegacySdk.Models.DatabaseAuditingPolicyCreateOrUpdateParameters parameters)
        {
            Management.Sql.LegacySdk.AuditingPolicyOperationsExtensions.CreateOrUpdateDatabasePolicy(
                GetCurrentLegacySqlClient().AuditingPolicy, resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Sets the database server auditing policy of the given database server in the given resource group
        /// </summary>
        public void SetServerAuditingPolicy(string resourceGroupName, string serverName, Management.Sql.LegacySdk.Models.ServerAuditingPolicyCreateOrUpdateParameters parameters)
        {
            Management.Sql.LegacySdk.AuditingPolicyOperationsExtensions.CreateOrUpdateServerPolicy(
                GetCurrentLegacySqlClient().AuditingPolicy, resourceGroupName, serverName, parameters);
        }

        /// <summary>
        /// Calls the set blob audit APIs for the database auditing policy for the given database in the given database server in the given resource group
        /// </summary>
        public void SetDatabaseAuditingPolicy(string resourceGroupName, string serverName, string databaseName, DatabaseBlobAuditingPolicy policy)
        {
            var operations = GetCurrentSqlClient().DatabaseBlobAuditingPolicies;
            operations.CreateOrUpdate(resourceGroupName, serverName, databaseName, policy);
        }

        /// <summary>
        /// Sets the database server blob auditing policy of the given database server in the given resource group
        /// </summary>
        public void SetServerAuditingPolicy(string resourceGroupName, string serverName, ServerBlobAuditingPolicy policy)
        {
            var client = GetCurrentSqlClient();
            AzureOperationResponse<ServerBlobAuditingPolicy> response =
                client.ServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName, serverName, policy).Result;
            var result = client.GetLongRunningOperationResultAsync(response, null, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the database extended blob auditing policy for the given database in the given database server in the given resource group
        /// </summary>
        public void GetExtendedDatabaseAuditingPolicy(string resourceGroupName, string serverName, string databaseName, out ExtendedDatabaseBlobAuditingPolicy policy)
        {
            policy = GetCurrentSqlClient().ExtendedDatabaseBlobAuditingPolicies.Get(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Gets the server extended blob auditing policy for the given database server in the given resource group
        /// </summary>
        public void GetExtendedServerAuditingPolicy(string resourceGroupName, string serverName, out ExtendedServerBlobAuditingPolicy policy)
        {
            policy = GetCurrentSqlClient().ExtendedServerBlobAuditingPolicies.Get(resourceGroupName, serverName);
        }

        /// <summary>
        /// Calls the set extended blob audit APIs for the database auditing policy for the given database in the given database server in the given resource group
        /// </summary>
        public void SetExtendedDatabaseAuditingPolicy(string resourceGroupName, string serverName, string databaseName, ExtendedDatabaseBlobAuditingPolicy policy)
        {
            var operations = GetCurrentSqlClient().ExtendedDatabaseBlobAuditingPolicies;
            operations.CreateOrUpdate(resourceGroupName, serverName, databaseName, policy);
        }

        /// <summary>
        /// Sets the server extended blob auditing policy of the given database server in the given resource group
        /// </summary>
        public void SetExtendedServerAuditingPolicy(string resourceGroupName, string serverName, ExtendedServerBlobAuditingPolicy policy)
        {
            var client = GetCurrentSqlClient();
            AzureOperationResponse<ExtendedServerBlobAuditingPolicy> response =
                client.ExtendedServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName, serverName, policy).Result;
            var result = client.GetLongRunningOperationResultAsync(response, null, CancellationToken.None).Result;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.LegacySdk.SqlManagementClient GetCurrentLegacySqlClient()
        {
            // Get the Legacy SQL management client for the current subscription
            if (LegacySqlClient == null)
            {
                LegacySqlClient = AzureSession.Instance.ClientFactory.CreateClient<Management.Sql.LegacySdk.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return LegacySqlClient;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }

            return SqlClient;
        }
    }
}
