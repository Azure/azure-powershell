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
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ThreatDetection.Model;

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
        private static Management.Sql.LegacySdk.SqlManagementClient LegacySqlClient { get; set; }

        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static Management.Sql.SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public ThreatDetectionEndpointsCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                LegacySqlClient = null;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the server security alert policy for the given server in the given resource group
        /// </summary>
        public Management.Sql.Models.ServerSecurityAlertPolicy GetServerSecurityAlertPolicy(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().ServerSecurityAlertPolicies.Get(resourceGroupName, serverName);
        }

        /// <summary>
        /// Gets the managed instance security alert policy for the given instance security in the given resource group
        /// </summary>
        public Management.Sql.Models.ManagedServerSecurityAlertPolicy GetManageInstanceSecurityAlertPolicy(string resourceGroupName, string managedInstanceName)
        {
            return GetCurrentSqlClient().ManagedServerSecurityAlertPolicies.Get(resourceGroupName, managedInstanceName);
        }

        /// <summary>
        /// Calls the set security alert APIs for the server security alert policy in the given resource group
        /// </summary>
        public void SetServerSecurityAlertPolicy(string resourceGroupName, string serverName, Management.Sql.Models.ServerSecurityAlertPolicy policyToSet)
        {
            GetCurrentSqlClient().ServerSecurityAlertPolicies.CreateOrUpdate(resourceGroupName, serverName, policyToSet);
        }

        /// <summary>
        /// Calls the set security alert APIs for the managed instance security alert policy in the given resource group
        /// </summary>
        public void SetManagedInstanceSecurityAlertPolicy(string resourceGroupName, string managedInstanceName, Management.Sql.Models.ManagedServerSecurityAlertPolicy policyToSet)
        {
            GetCurrentSqlClient().ManagedServerSecurityAlertPolicies.CreateOrUpdate(resourceGroupName, managedInstanceName, policyToSet);
        }

        /// <summary>
        /// Returns the operation status of a server create or update operation
        /// </summary>
        public OperationStatus GetServerCreateOrUpdateOperationStatus(string operationStatusLink)
        {
            var operations = GetLegacySqlClient().SecurityAlertPolicy;
            return operations.GetOperationStatus(operationStatusLink).OperationResult.Properties.State;
        }

        /// <summary>
        /// Gets the database security alert policy for the given database in the given database server in the given resource group
        /// </summary>
        public Management.Sql.LegacySdk.Models.DatabaseSecurityAlertPolicy GetDatabaseSecurityAlertPolicy(string resourceGroupName, string serverName, string databaseName)
        {
            ISecurityAlertPolicyOperations operations = GetLegacySqlClient().SecurityAlertPolicy;
            DatabaseSecurityAlertPolicyGetResponse response = operations.GetDatabaseSecurityAlertPolicy(resourceGroupName, serverName, databaseName);
            return response.SecurityAlertPolicy;
        }

        /// <summary>
        /// Calls the set security alert APIs for the database security alert policy for the given database in the given database server in the given resource group
        /// </summary>
        public void SetDatabaseSecurityAlertPolicy(string resourceGroupName, string serverName, string databaseName, DatabaseSecurityAlertPolicyCreateOrUpdateParameters parameters)
        {
            ISecurityAlertPolicyOperations operations = GetLegacySqlClient().SecurityAlertPolicy;
            operations.CreateOrUpdateDatabaseSecurityAlertPolicy(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.LegacySdk.SqlManagementClient GetLegacySqlClient()
        {
            // Get the SQL management client for the current subscription
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
        private Management.Sql.SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }
    }
}
