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
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Ipv6FirewallRule.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlServerIpv6FirewallRuleCommunicator
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
        /// Creates a communicator for Azure Sql Databases FirewallRules
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServerIpv6FirewallRuleCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database Server IPv6FirewallRules
        /// </summary>
        public Management.Sql.Models.IPv6FirewallRule Get(string resourceGroupName, string serverName, string ipv6FirewallRuleName)
        {
            return GetCurrentSqlClient().IPv6FirewallRules.Get(resourceGroupName, serverName, ipv6FirewallRuleName);
        }

        /// <summary>
        /// Lists Azure Sql Databases Server IPv6FirewallRules
        /// </summary>
        public Microsoft.Rest.Azure.IPage<Management.Sql.Models.IPv6FirewallRule> List(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().IPv6FirewallRules.ListByServer(resourceGroupName, serverName);
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database Server IPv6FirewallRule
        /// </summary>
        public Management.Sql.Models.IPv6FirewallRule CreateOrUpdate(string resourceGroupName, string serverName, string ipv6FirewallRuleName, IPv6FirewallRule parameters)
        {
            return GetCurrentSqlClient().IPv6FirewallRules.CreateOrUpdate(resourceGroupName, serverName, ipv6FirewallRuleName, parameters);
        }

        /// <summary>
        /// Deletes an Azure Sql Database Server IPv6FirewallRule
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string ipv6FirewallRuleName)
        {
            GetCurrentSqlClient().IPv6FirewallRules.Delete(resourceGroupName, serverName, ipv6FirewallRuleName);
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
