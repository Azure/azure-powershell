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

namespace Microsoft.Azure.Commands.Sql.InstanceActiveDirectoryAdministrator.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlInstanceActiveDirectoryAdministratorCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure SQL Instance Active Directory administrator
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlInstanceActiveDirectoryAdministratorCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure SQL Instance Active Directory administrator
        /// </summary>
        public ManagedInstanceAdministrator Get(string resourceGroupName, string managedInstanceName)
        {
            return GetCurrentSqlClient().ManagedInstanceAdministrators.Get(resourceGroupName, managedInstanceName);
        }

        /// <summary>
        /// Lists Azure SQL Instance Active Directory administrators
        /// </summary>
        public IPage<ManagedInstanceAdministrator> List(string resourceGroupName, string managedInstanceName)
        {
            return GetCurrentSqlClient().ManagedInstanceAdministrators.ListByInstance(resourceGroupName, managedInstanceName);	
        }

        /// <summary>
        /// Creates or updates a Azure SQL Instance Active Directory Administrator
        /// </summary>
        public ManagedInstanceAdministrator CreateOrUpdate(string resourceGroupName, string managedInstanceName, ManagedInstanceAdministrator parameters)
        {
            return GetCurrentSqlClient().ManagedInstanceAdministrators.CreateOrUpdate(resourceGroupName, managedInstanceName, parameters);
        }

        /// <summary>
        /// Deletes a Azure SQL Instance Active Directory Administrator
        /// </summary>
        public void Remove(string resourceGroupName, string managedInstanceName)
        {
            GetCurrentSqlClient().ManagedInstanceAdministrators.Delete(resourceGroupName, managedInstanceName);
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
