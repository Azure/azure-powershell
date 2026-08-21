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

namespace Microsoft.Azure.Commands.Sql.Server.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the deleted server REST endpoints
    /// </summary>
    public class AzureSqlDeletedServerCommunicator
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
        /// Creates a communicator for Azure Sql Deleted Servers
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlDeletedServerCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the deleted Azure Sql Database Server
        /// </summary>
        public Management.Sql.Models.DeletedServer GetDeleted(string location, string serverName, string subscriptionId = null)
        {
            return GetCurrentSqlClient(subscriptionId).DeletedServers.Get(location, serverName);
        }

        /// <summary>
        /// Lists all deleted Azure Sql Database Servers in a location
        /// </summary>
        public IEnumerable<Management.Sql.Models.DeletedServer> ListDeletedServers(string location, string subscriptionId = null)
        {
            return GetCurrentSqlClient(subscriptionId).DeletedServers.ListByLocation(location);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient(string subscriptionId = null)
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }

            if (subscriptionId != null)
            {
                var crossSubClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
                crossSubClient.SubscriptionId = subscriptionId;
                return crossSubClient;
            }
            return SqlClient;
        }
    }
}