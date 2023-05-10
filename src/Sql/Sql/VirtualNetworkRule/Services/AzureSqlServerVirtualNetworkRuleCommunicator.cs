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

namespace Microsoft.Azure.Commands.Sql.VirtualNetworkRule.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlServerVirtualNetworkRuleCommunicator
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
        /// Creates a communicator for Azure Sql Server Virtual Network Rules
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServerVirtualNetworkRuleCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Server Virtual Network Rules
        /// </summary>
        public Management.Sql.Models.VirtualNetworkRule Get(string resourceGroupName, string serverName, string vnetFirewallRuleName)
        {
            return GetCurrentSqlClient().VirtualNetworkRules.Get(resourceGroupName, serverName, vnetFirewallRuleName);
        }

        /// <summary>
        /// Lists Azure Sql Databases Server FirewallRules
        /// </summary>
        public IList<Management.Sql.Models.VirtualNetworkRule> List(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().VirtualNetworkRules.ListByServer(resourceGroupName, serverName).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database Server FirewallRule
        /// </summary>
        public Management.Sql.Models.VirtualNetworkRule CreateOrUpdate(string resourceGroupName, string serverName, string vnetFirewallRuleName, Management.Sql.Models.VirtualNetworkRule parameters)
        {
            return GetCurrentSqlClient().VirtualNetworkRules.CreateOrUpdate(resourceGroupName, serverName, vnetFirewallRuleName, parameters);
        }

        /// <summary>
        /// Deletes an Azure Sql Database Server FirewallRule
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string vnetFirewallRuleName)
        {
            GetCurrentSqlClient().VirtualNetworkRules.Delete(resourceGroupName, serverName, vnetFirewallRuleName);
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
