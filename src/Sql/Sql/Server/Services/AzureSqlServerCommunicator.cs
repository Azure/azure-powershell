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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.Server.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlServerCommunicator
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
        /// Creates a communicator for Azure Sql Databases
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServerCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database SErver
        /// </summary>
        public Management.Sql.Models.Server Get(string resourceGroupName, string serverName, string expand = null)
        {
            return GetCurrentSqlClient().Servers.Get(resourceGroupName, serverName, expand);
        }

        /// <summary>
        /// Lists Azure Sql Servers in a resource group
        /// </summary>
        public IList<Management.Sql.Models.Server> ListByResourceGroup(string resourceGroupName, string expand = null)
        {
            return GetCurrentSqlClient().Servers.ListByResourceGroup(resourceGroupName, expand).ToList();
        }

        /// <summary>
        /// Lists Azure Sql Servers
        /// </summary>
        public IList<Management.Sql.Models.Server> List(string expand = null)
        {
            return GetCurrentSqlClient().Servers.List(expand).ToList();
        }

        /// <summary>
        /// Creates or updates a Azure Sql Database SErver
        /// </summary>
        public Management.Sql.Models.Server CreateOrUpdate(string resourceGroupName, string serverName, Management.Sql.Models.Server parameters)
        {
            return GetCurrentSqlClient().Servers.CreateOrUpdate(resourceGroupName, serverName, parameters);
        }

        /// <summary>
        /// Deletes a Azure Sql Database SErver
        /// </summary>
        public void Remove(string resourceGroupName, string serverName)
        {
            GetCurrentSqlClient().Servers.Delete(resourceGroupName, serverName);
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
